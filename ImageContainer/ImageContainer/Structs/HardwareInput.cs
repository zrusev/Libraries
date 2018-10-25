namespace ImageContainer.Structs
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct HardwareInput
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    }
}
