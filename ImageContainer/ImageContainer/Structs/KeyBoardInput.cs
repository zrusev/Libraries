namespace ImageContainer.Structs
{
    using ImageContainer.Enums;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct KeyBoardInput
    {
        public ushort wVk;
        public ushort wScan;
        public KeyEventF dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    }
}
