// <auto-generated>
// This file was automatically generated by Biohazrd and should not be modified by hand!
// </auto-generated>
#nullable enable
using System.Diagnostics;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Size = 32)]
public unsafe partial struct ImGuiWindowClass
{
    [FieldOffset(0)] public uint ClassId;

    [FieldOffset(4)] public uint ParentViewportId;

    [FieldOffset(8)] public ImGuiViewportFlags ViewportFlagsOverrideSet;

    [FieldOffset(12)] public ImGuiViewportFlags ViewportFlagsOverrideClear;

    [FieldOffset(16)] public ImGuiTabItemFlags TabItemFlagsOverrideSet;

    [FieldOffset(20)] public ImGuiDockNodeFlags DockNodeFlagsOverrideSet;

    [FieldOffset(24)] public ImGuiDockNodeFlags DockNodeFlagsOverrideClear;

    [FieldOffset(28)] [MarshalAs(UnmanagedType.I1)] public bool DockingAlwaysTabBar;

    [FieldOffset(29)] [MarshalAs(UnmanagedType.I1)] public bool DockingAllowUnclassed;

    [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "??0ImGuiWindowClass@@QEAA@XZ", ExactSpelling = true)]
    private static extern void Constructor_PInvoke(ImGuiWindowClass* @this);

    [DebuggerStepThrough, DebuggerHidden]
    public unsafe void Constructor()
    {
        fixed (ImGuiWindowClass* @this = &this)
        { Constructor_PInvoke(@this); }
    }
}
