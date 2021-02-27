// <auto-generated>
// This file was automatically generated by Biohazrd and should not be modified by hand!
// </auto-generated>
#nullable enable
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace InfectedImGui.Internal
{
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public unsafe partial struct ImGuiTableColumnSettings
    {
        [FieldOffset(0)] public float WidthOrWeight;

        [FieldOffset(4)] public uint UserID;

        [FieldOffset(8)] public sbyte Index;

        [FieldOffset(9)] public sbyte DisplayOrder;

        [FieldOffset(10)] public sbyte SortOrder;

        [FieldOffset(11)] private byte __SortDirection__backingField;
        public byte SortDirection
        {
            get => (byte)((__SortDirection__backingField >> 0) & 0x3U);
            set
            {
                uint shiftedValue = (value & 0x3U) << 0;
                uint otherBits = __SortDirection__backingField & 0xFCU;
                __SortDirection__backingField = (byte)(otherBits | shiftedValue);
            }
        }

        [FieldOffset(11)] private byte __IsEnabled__backingField;
        public byte IsEnabled
        {
            get => (byte)((__IsEnabled__backingField >> 2) & 0x1U);
            set
            {
                uint shiftedValue = (value & 0x1U) << 2;
                uint otherBits = __IsEnabled__backingField & 0xFBU;
                __IsEnabled__backingField = (byte)(otherBits | shiftedValue);
            }
        }

        [FieldOffset(11)] private byte __IsStretch__backingField;
        public byte IsStretch
        {
            get => (byte)((__IsStretch__backingField >> 3) & 0x1U);
            set
            {
                uint shiftedValue = (value & 0x1U) << 3;
                uint otherBits = __IsStretch__backingField & 0xF7U;
                __IsStretch__backingField = (byte)(otherBits | shiftedValue);
            }
        }

        [DllImport("InfectedImGui.Native.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__InlineHelper68", ExactSpelling = true)]
        private static extern void Constructor_PInvoke(ImGuiTableColumnSettings* @this);

        [DebuggerStepThrough, DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Constructor()
        {
            fixed (ImGuiTableColumnSettings* @this = &this)
            { Constructor_PInvoke(@this); }
        }
    }
}
