// <auto-generated>
// This file was automatically generated by Biohazrd and should not be modified by hand!
// </auto-generated>
#nullable enable
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace InfectedImGui.Internal
{
    [StructLayout(LayoutKind.Explicit, Size = 14)]
    public unsafe partial struct ImGuiStackSizes
    {
        [FieldOffset(0)] public short SizeOfIDStack;

        [FieldOffset(2)] public short SizeOfColorStack;

        [FieldOffset(4)] public short SizeOfStyleVarStack;

        [FieldOffset(6)] public short SizeOfFontStack;

        [FieldOffset(8)] public short SizeOfFocusScopeStack;

        [FieldOffset(10)] public short SizeOfGroupStack;

        [FieldOffset(12)] public short SizeOfBeginPopupStack;

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__InlineHelper60", ExactSpelling = true)]
        private static extern void Constructor_PInvoke(ImGuiStackSizes* @this);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Constructor()
        {
            fixed (ImGuiStackSizes* @this = &this)
            { Constructor_PInvoke(@this); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?SetToCurrentState@ImGuiStackSizes@@QEAAXXZ", ExactSpelling = true)]
        private static extern void SetToCurrentState_PInvoke(ImGuiStackSizes* @this);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void SetToCurrentState()
        {
            fixed (ImGuiStackSizes* @this = &this)
            { SetToCurrentState_PInvoke(@this); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?CompareWithCurrentState@ImGuiStackSizes@@QEAAXXZ", ExactSpelling = true)]
        private static extern void CompareWithCurrentState_PInvoke(ImGuiStackSizes* @this);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void CompareWithCurrentState()
        {
            fixed (ImGuiStackSizes* @this = &this)
            { CompareWithCurrentState_PInvoke(@this); }
        }
    }
}
