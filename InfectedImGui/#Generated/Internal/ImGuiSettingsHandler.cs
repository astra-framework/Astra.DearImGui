// <auto-generated>
// This file was automatically generated by Biohazrd and should not be modified by hand!
// </auto-generated>
#nullable enable
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace InfectedImGui.Internal
{
    [StructLayout(LayoutKind.Explicit, Size = 72)]
    public unsafe partial struct ImGuiSettingsHandler
    {
        [FieldOffset(0)] public byte* TypeName;

        [FieldOffset(8)] public uint TypeHash;

        [FieldOffset(16)] public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void> ClearAllFn;

        [FieldOffset(24)] public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void> ReadInitFn;

        [FieldOffset(32)] public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, byte*, void*> ReadOpenFn;

        [FieldOffset(40)] public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void*, byte*, void> ReadLineFn;

        [FieldOffset(48)] public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, void> ApplyAllFn;

        [FieldOffset(56)] public delegate* unmanaged[Cdecl]<ImGuiContext*, ImGuiSettingsHandler*, ImGuiTextBuffer*, void> WriteAllFn;

        [FieldOffset(64)] public void* UserData;

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__InlineHelper58", ExactSpelling = true)]
        private static extern void Constructor_PInvoke(ImGuiSettingsHandler* @this);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Constructor()
        {
            fixed (ImGuiSettingsHandler* @this = &this)
            { Constructor_PInvoke(@this); }
        }
    }
}
