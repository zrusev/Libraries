namespace ImageContainer.Structs
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    internal struct InputUnion
    {
        [FieldOffset(0)]
        internal MouseInput mi;
        [FieldOffset(0)]
        internal KeyBoardInput ki;
        [FieldOffset(0)]
        internal HardwareInput hi;
    }
}
