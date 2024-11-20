@echo off
setlocal

:: Start in the directory containing this script
cd %~dp0

:: Ensure Dear ImGui has been cloned
if not exist external\imgui\ (
    echo Dear ImGui source not found, did you forget to clone recursively? 1>&2
    exit /B 1
)

:: Run generator (will also build Astra.DearImGui.Native)
echo Generating Astra.DearImGui...
dotnet run --configuration Release --project Astra.DearImGui.Generator -- "external/imgui/" "Astra.DearImGui.Native/" "Astra.DearImGui/#Generated/"
