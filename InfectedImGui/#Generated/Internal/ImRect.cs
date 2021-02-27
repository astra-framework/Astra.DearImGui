// <auto-generated>
// This file was automatically generated by Biohazrd and should not be modified by hand!
// </auto-generated>
#nullable enable
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace InfectedImGui.Internal
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public unsafe partial struct ImRect
    {
        [FieldOffset(0)] public ImVec2 Min;

        [FieldOffset(8)] public ImVec2 Max;

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__InlineHelper37", ExactSpelling = true)]
        private static extern void Constructor_PInvoke(ImRect* @this);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Constructor()
        {
            fixed (ImRect* @this = &this)
            { Constructor_PInvoke(@this); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__InlineHelper38", ExactSpelling = true)]
        private static extern void Constructor_PInvoke(ImRect* @this, ImVec2* min, ImVec2* max);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Constructor(ImVec2* min, ImVec2* max)
        {
            fixed (ImRect* @this = &this)
            { Constructor_PInvoke(@this, min, max); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__InlineHelper39", ExactSpelling = true)]
        private static extern void Constructor_PInvoke(ImRect* @this, ImVec4* v);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Constructor(ImVec4* v)
        {
            fixed (ImRect* @this = &this)
            { Constructor_PInvoke(@this, v); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__InlineHelper40", ExactSpelling = true)]
        private static extern void Constructor_PInvoke(ImRect* @this, float x1, float y1, float x2, float y2);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Constructor(float x1, float y1, float x2, float y2)
        {
            fixed (ImRect* @this = &this)
            { Constructor_PInvoke(@this, x1, y1, x2, y2); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?GetCenter@ImRect@@QEBA?AUImVec2@@XZ", ExactSpelling = true)]
        private static extern ImVec2* GetCenter_PInvoke(ImRect* @this, out ImVec2 __returnBuffer);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ImVec2 GetCenter()
        {
            fixed (ImRect* @this = &this)
            {
                ImVec2 __returnBuffer;
                GetCenter_PInvoke(@this, out __returnBuffer);
                return __returnBuffer;
            }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?GetSize@ImRect@@QEBA?AUImVec2@@XZ", ExactSpelling = true)]
        private static extern ImVec2* GetSize_PInvoke(ImRect* @this, out ImVec2 __returnBuffer);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ImVec2 GetSize()
        {
            fixed (ImRect* @this = &this)
            {
                ImVec2 __returnBuffer;
                GetSize_PInvoke(@this, out __returnBuffer);
                return __returnBuffer;
            }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?GetWidth@ImRect@@QEBAMXZ", ExactSpelling = true)]
        private static extern float GetWidth_PInvoke(ImRect* @this);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe float GetWidth()
        {
            fixed (ImRect* @this = &this)
            { return GetWidth_PInvoke(@this); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?GetHeight@ImRect@@QEBAMXZ", ExactSpelling = true)]
        private static extern float GetHeight_PInvoke(ImRect* @this);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe float GetHeight()
        {
            fixed (ImRect* @this = &this)
            { return GetHeight_PInvoke(@this); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?GetTL@ImRect@@QEBA?AUImVec2@@XZ", ExactSpelling = true)]
        private static extern ImVec2* GetTL_PInvoke(ImRect* @this, out ImVec2 __returnBuffer);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ImVec2 GetTL()
        {
            fixed (ImRect* @this = &this)
            {
                ImVec2 __returnBuffer;
                GetTL_PInvoke(@this, out __returnBuffer);
                return __returnBuffer;
            }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?GetTR@ImRect@@QEBA?AUImVec2@@XZ", ExactSpelling = true)]
        private static extern ImVec2* GetTR_PInvoke(ImRect* @this, out ImVec2 __returnBuffer);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ImVec2 GetTR()
        {
            fixed (ImRect* @this = &this)
            {
                ImVec2 __returnBuffer;
                GetTR_PInvoke(@this, out __returnBuffer);
                return __returnBuffer;
            }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?GetBL@ImRect@@QEBA?AUImVec2@@XZ", ExactSpelling = true)]
        private static extern ImVec2* GetBL_PInvoke(ImRect* @this, out ImVec2 __returnBuffer);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ImVec2 GetBL()
        {
            fixed (ImRect* @this = &this)
            {
                ImVec2 __returnBuffer;
                GetBL_PInvoke(@this, out __returnBuffer);
                return __returnBuffer;
            }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?GetBR@ImRect@@QEBA?AUImVec2@@XZ", ExactSpelling = true)]
        private static extern ImVec2* GetBR_PInvoke(ImRect* @this, out ImVec2 __returnBuffer);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ImVec2 GetBR()
        {
            fixed (ImRect* @this = &this)
            {
                ImVec2 __returnBuffer;
                GetBR_PInvoke(@this, out __returnBuffer);
                return __returnBuffer;
            }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?Contains@ImRect@@QEBA_NAEBUImVec2@@@Z", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool Contains_PInvoke(ImRect* @this, ImVec2* p);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe bool Contains(ImVec2* p)
        {
            fixed (ImRect* @this = &this)
            { return Contains_PInvoke(@this, p); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?Contains@ImRect@@QEBA_NAEBU1@@Z", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool Contains_PInvoke(ImRect* @this, ImRect* r);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe bool Contains(ImRect* r)
        {
            fixed (ImRect* @this = &this)
            { return Contains_PInvoke(@this, r); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?Overlaps@ImRect@@QEBA_NAEBU1@@Z", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool Overlaps_PInvoke(ImRect* @this, ImRect* r);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe bool Overlaps(ImRect* r)
        {
            fixed (ImRect* @this = &this)
            { return Overlaps_PInvoke(@this, r); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?Add@ImRect@@QEAAXAEBUImVec2@@@Z", ExactSpelling = true)]
        private static extern void Add_PInvoke(ImRect* @this, ImVec2* p);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Add(ImVec2* p)
        {
            fixed (ImRect* @this = &this)
            { Add_PInvoke(@this, p); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?Add@ImRect@@QEAAXAEBU1@@Z", ExactSpelling = true)]
        private static extern void Add_PInvoke(ImRect* @this, ImRect* r);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Add(ImRect* r)
        {
            fixed (ImRect* @this = &this)
            { Add_PInvoke(@this, r); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?Expand@ImRect@@QEAAXM@Z", ExactSpelling = true)]
        private static extern void Expand_PInvoke(ImRect* @this, float amount);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Expand(float amount)
        {
            fixed (ImRect* @this = &this)
            { Expand_PInvoke(@this, amount); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?Expand@ImRect@@QEAAXAEBUImVec2@@@Z", ExactSpelling = true)]
        private static extern void Expand_PInvoke(ImRect* @this, ImVec2* amount);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Expand(ImVec2* amount)
        {
            fixed (ImRect* @this = &this)
            { Expand_PInvoke(@this, amount); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?Translate@ImRect@@QEAAXAEBUImVec2@@@Z", ExactSpelling = true)]
        private static extern void Translate_PInvoke(ImRect* @this, ImVec2* d);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Translate(ImVec2* d)
        {
            fixed (ImRect* @this = &this)
            { Translate_PInvoke(@this, d); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?TranslateX@ImRect@@QEAAXM@Z", ExactSpelling = true)]
        private static extern void TranslateX_PInvoke(ImRect* @this, float dx);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void TranslateX(float dx)
        {
            fixed (ImRect* @this = &this)
            { TranslateX_PInvoke(@this, dx); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?TranslateY@ImRect@@QEAAXM@Z", ExactSpelling = true)]
        private static extern void TranslateY_PInvoke(ImRect* @this, float dy);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void TranslateY(float dy)
        {
            fixed (ImRect* @this = &this)
            { TranslateY_PInvoke(@this, dy); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?ClipWith@ImRect@@QEAAXAEBU1@@Z", ExactSpelling = true)]
        private static extern void ClipWith_PInvoke(ImRect* @this, ImRect* r);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void ClipWith(ImRect* r)
        {
            fixed (ImRect* @this = &this)
            { ClipWith_PInvoke(@this, r); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?ClipWithFull@ImRect@@QEAAXAEBU1@@Z", ExactSpelling = true)]
        private static extern void ClipWithFull_PInvoke(ImRect* @this, ImRect* r);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void ClipWithFull(ImRect* r)
        {
            fixed (ImRect* @this = &this)
            { ClipWithFull_PInvoke(@this, r); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?Floor@ImRect@@QEAAXXZ", ExactSpelling = true)]
        private static extern void Floor_PInvoke(ImRect* @this);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Floor()
        {
            fixed (ImRect* @this = &this)
            { Floor_PInvoke(@this); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?IsInverted@ImRect@@QEBA_NXZ", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsInverted_PInvoke(ImRect* @this);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe bool IsInverted()
        {
            fixed (ImRect* @this = &this)
            { return IsInverted_PInvoke(@this); }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?ToVec4@ImRect@@QEBA?AUImVec4@@XZ", ExactSpelling = true)]
        private static extern ImVec4* ToVec4_PInvoke(ImRect* @this, out ImVec4 __returnBuffer);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ImVec4 ToVec4()
        {
            fixed (ImRect* @this = &this)
            {
                ImVec4 __returnBuffer;
                ToVec4_PInvoke(@this, out __returnBuffer);
                return __returnBuffer;
            }
        }
    }
}
