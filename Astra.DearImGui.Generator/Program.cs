using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Biohazrd;
using Biohazrd.OutputGeneration;
using Spectre.Console;
using System.Threading;
using Biohazrd.CSharp;
using Biohazrd.Transformation.Common;
using Biohazrd.Utilities;

namespace Astra.DearImGui.Generator;

internal static class Program
{
    const string canonical_build_variant = "Release";

    private static string dotNetRid;
    private static string nativeRuntimeBuildScript;
    private static string importLibraryName;
    private static bool itaniumExportMode;

    private static TranslatedLibraryBuilder libraryBuilder = null!;
    private static TranslatedLibrary library = null!;
    private static TranslatedLibraryConstantEvaluator constantEvaluator = null!;
    private static OutputSession outputSession = null!;
    private static BrokenDeclarationExtractor brokenDeclarationExtractor = null!;
    private static string[] backendFiles = null!;

    private static string imGuiLibFilePath = null!;
    private static string imGuiInlineExporterFilePath = null!;
    private static string nativeBuildScript = null!;
    private static string dearImGuiNativeRootPath = null!;
    private static string sourceDirectoryPath = null!;


    private static int Main(string[] args)
    {
        Console.Clear();
        if (args.Length != 3)
        {
            AnsiConsole.MarkupLine("[red]Usage:[/] [yellow]Astra.DearImGui.Generator [/][red]<path-to-dear-imgui-source> <path-to-astra-dearimgui-native> <path-to-output>[/]");
            return 1;
        }

        AnsiConsole.Status()
            .Start("Resolving Information", ctx =>
            {
                resolveOsAndRid(ctx);
                ctx.Status("Setting up builder");
                setupBuilder(args);
                ctx.Status("Performing library-specific transformations");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));
                performTransformations(ctx);
                ctx.Status("Performing post-translation validation");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));
                performPostTranslationValidation();
                ctx.Status("Emitting translation");
                emitTranslation();
            });


        return 0;
    }


    private static void emitTranslation()
    {
        ImmutableArray<TranslationDiagnostic> generationDiagnostics = CSharpLibraryGenerator.Generate
        (
            CSharpGenerationOptions.Default with
            {
                TargetRuntime = TargetRuntime.Net6,
                InfrastructureTypesNamespace = "Astra.DearImGui.Infrastructure",
            },
            outputSession,
            library
        );

        // Write out diagnostics log
        DiagnosticWriter diagnostics = new();
        diagnostics.AddFrom(library);
        diagnostics.AddFrom(brokenDeclarationExtractor);
        diagnostics.AddCategory("Generation Diagnostics", generationDiagnostics, "Generation completed successfully");

        using StreamWriter diagnosticsOutput = outputSession.Open<StreamWriter>("Diagnostics.log");
        diagnostics.WriteOutDiagnostics(diagnosticsOutput, writeToConsole: true);

        // Remove copied backend files
        foreach (string file in backendFiles)
        {
            string path = Path.Combine(sourceDirectoryPath, file);
            if (File.Exists(path) == false) continue;
            File.Delete(path);
        }

    }


    private static void performPostTranslationValidation()
    {
        library = new CSharpTranslationVerifier().Transform(library);
        library = brokenDeclarationExtractor.Transform(library);
    }


    private static void performTransformations(StatusContext ctx)
    {
        library = new RemoveUnneededDeclarationsTransformation().Transform(library);
        library = new ImGuiEnumTransformation().Transform(library);

        brokenDeclarationExtractor = new BrokenDeclarationExtractor();
        library = brokenDeclarationExtractor.Transform(library);

        library = new RemoveExplicitBitFieldPaddingFieldsTransformation().Transform(library);
        library = new AddBaseVTableAliasTransformation().Transform(library);
        library = new ConstOverloadRenameTransformation().Transform(library);
        library = new MakeEverythingPublicTransformation().Transform(library);
        library = new ImGuiCSharpTypeReductionTransformation().Transform(library);
        library = new MiscFixesTransformation().Transform(library);
        library = new LiftAnonymousRecordFieldsTransformation().Transform(library);
        library = new AddTrampolineMethodOptionsTransformation(MethodImplOptions.AggressiveInlining).Transform(library);
        library = new ImGuiInternalFixupTransformation().Transform(library);
        library = new AstraDearImGuiNamespaceTransformation().Transform(library);
        library = new RemoveIllegalImVectorReferencesTransformation().Transform(library);
        library = new MoveLooseDeclarationsIntoTypesTransformation
        (
            (_, d) =>
            {
                if (d.Namespace == "Astra.DearImGui")
                {
                    return "ImGui";
                }

                if (d.Namespace == "Astra.DearImGui.Internal")
                {
                    return "ImGuiInternal";
                }

                if (d.Namespace == "Astra.DearImGui.Backends.Direct3D11")
                {
                    return "ImGuiImplD3D11";
                }

                if (d.Namespace == "Astra.DearImGui.Backends.Win32")
                {
                    return "ImGuiImplWin32";
                }

                return "Globals";
            }
        ).Transform(library);
        library = new AutoNameUnnamedParametersTransformation().Transform(library);
        library = new CreateTrampolinesTransformation
        {
            TargetRuntime = TargetRuntime.Net8
        }.Transform(library);
        library = new ImGuiCreateStringWrappersTransformation().Transform(library);
        library = new StripUnreferencedLazyDeclarationsTransformation().Transform(library);
        library = new ImGuiKeyIssueWorkaroundTransformation().Transform(library);
        library = new DeduplicateNamesTransformation().Transform(library);
        library = new OrganizeOutputFilesByNamespaceTransformation("Astra.DearImGui").Transform(library); // Relies on AstraImGuiNamespaceTransformation, MoveLooseDeclarationsIntoTypesTransformation
        library = new ImVersionConstantsTransformation(library, constantEvaluator).Transform(library);
        library = new VectorTypeTransformation().Transform(library);

        // Generate the inline export helper
        library = new InlineExportHelper(outputSession, imGuiInlineExporterFilePath) { __ItaniumExportMode = itaniumExportMode }.Transform(library);

        // Rebuild the native DLL so that the librarian can access a version of the library including the inline-exported functions
        writeLogMessage("Rebuilding Astra.DearImGui.Native...");
        ctx.Status("Building Astra.DearImGui.Native");
        ctx.Spinner(Spinner.Known.Default);
        ctx.SpinnerStyle(Style.Parse("green"));
        Process.Start(new ProcessStartInfo(nativeBuildScript)
        {
            WorkingDirectory = dearImGuiNativeRootPath,
            UseShellExecute = true
        })!.WaitForExit();

        // Use librarian to identifiy DLL exports
        LinkImportsTransformation linkImports = new()
        {
            ErrorOnMissing = true,
            TrackVerboseImportInformation = true,
            WarnOnAmbiguousSymbols = true
        };
        linkImports.AddLibrary(imGuiLibFilePath);
        library = linkImports.Transform(library);

        writeLogMessage("Finished building Astra.DearImGui.Native...");
    }


    private static bool setupBuilder(string[] args)
    {
        sourceDirectoryPath = Path.GetFullPath(args[0]);
        string mainHeaderFilePath = Path.Combine(sourceDirectoryPath, "imgui.h");

        string imGuiBackendsDirectoryPath = Path.Combine(sourceDirectoryPath, "backends");
        dearImGuiNativeRootPath = Path.GetFullPath(args[1]);
        imGuiLibFilePath = Path.Combine(dearImGuiNativeRootPath, "..", "bin", "Astra.DearImGui.Native", dotNetRid, canonical_build_variant, importLibraryName);
        imGuiInlineExporterFilePath = Path.Combine(dearImGuiNativeRootPath, "InlineExportHelper.gen.cpp");
        nativeBuildScript = Path.Combine(dearImGuiNativeRootPath, nativeRuntimeBuildScript);

        string outputDirectoryPath = Path.GetFullPath(args[2]);


        if (!Directory.Exists(sourceDirectoryPath))
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] [yellow]'{sourceDirectoryPath}' not found.[/]");
            return false;
        }

        if (!File.Exists(mainHeaderFilePath))
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] [yellow]'Dear ImGui header file not found at {mainHeaderFilePath}'[/]");
            return false;
        }

        string imGuiConfigFilePath = Path.Combine(dearImGuiNativeRootPath, "DearImGuiConfig.h");

        if (!File.Exists(imGuiConfigFilePath))
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] [yellow]Dear ImGui config file not found at '{imGuiConfigFilePath}'[/]");
            return false;
        }

        backendFiles =
        [
            "imgui_impl_win32.h",
            "imgui_impl_win32.cpp",
            "imgui_impl_dx11.h",
            "imgui_impl_dx11.cpp"
        ];

        // Copy backend files to sourceDirectory temporarily
        foreach (string file in backendFiles)
        {
            string path = Path.Combine(imGuiBackendsDirectoryPath, file);
            if (File.Exists(path) == false) continue;
            File.Copy(path, Path.Combine(sourceDirectoryPath, file), true);
        }

        libraryBuilder = new TranslatedLibraryBuilder
        {
            Options = new TranslationOptions
            {
                // The only template that appears on the public API is ImVector<T>, which we special-case as a C# generic.
                // ImPool<T>, ImChunkStream<T>, and ImSpan<T> do appear on the internal API but for now we just want them to be dropped.
                //TODO: In theory this could be made to work, but there's a few wrinkles that need to be ironed out and these few API points are not a high priority.
                EnableTemplateSupport = false,
            }
        };
        libraryBuilder.AddCommandLineArgument("--language=c++");
        libraryBuilder.AddCommandLineArgument($"-I{sourceDirectoryPath}");
        libraryBuilder.AddCommandLineArgument($"-DIMGUI_USER_CONFIG=\"{imGuiConfigFilePath}\"");
        libraryBuilder.AddFile(mainHeaderFilePath);
        libraryBuilder.AddFile(Path.Combine(sourceDirectoryPath, "imgui_internal.h"));

        // Include backend header files
        foreach (string file in backendFiles)
        {
            string path = Path.Combine(sourceDirectoryPath, file);
            if (file.Contains("loader")) continue;
            if (File.Exists(path) == false || file.Split('.').Last() != "h") continue;
            writeLogMessage($"Added backend header file: [green]{file}[/]");
            libraryBuilder.AddFile(path);
        }

        library = libraryBuilder.Create();
        constantEvaluator = libraryBuilder.CreateConstantEvaluator();

        // Start output session
        outputSession = new OutputSession();
        outputSession.AutoRenameConflictingFiles = true;
        outputSession.BaseOutputDirectory = outputDirectoryPath;
        outputSession.ConservativeFileLogging = false;

        return true;
    }


    private static bool resolveOsAndRid(StatusContext ctx)
    {
        if (OperatingSystem.IsWindows())
        {
            dotNetRid = "win-x64";
            nativeRuntimeBuildScript = "build-native.cmd";
            importLibraryName = "Astra.DearImGui.Native.lib";
            itaniumExportMode = false;
        }
        else if (OperatingSystem.IsLinux())
        {
            dotNetRid = "linux-x64";
            nativeRuntimeBuildScript = "build-native.sh";
            importLibraryName = "libAstra.DearImGui.Native.so";
            itaniumExportMode = true;
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] [yellow]Unsupported OS -> '{RuntimeInformation.OSDescription}'[/]");
            return false;
        }

        writeLogMessage($"Resolved OS: [yellow]{RuntimeInformation.OSDescription}[/] RID: [yellow]{dotNetRid}[/]");
        return true;
    }


    private static void writeLogMessage(string message)
    {
        AnsiConsole.MarkupLine("[grey]LOG:[/] " + message + "[grey]...[/]");
    }
}