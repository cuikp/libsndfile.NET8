using System.Runtime.InteropServices;


namespace libsndfile.NET8
{

    [StructLayout(LayoutKind.Sequential)]
    public struct SfLoop
    {
        public SfLoopMode Mode;
        public uint Start;
        public uint End;
        public uint Count;
    }
}