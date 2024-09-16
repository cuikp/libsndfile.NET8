using System.Runtime.InteropServices;


namespace libsndfile.NET8
{

    [StructLayout(LayoutKind.Sequential)]
    public struct SfLoopInfo
    {
        public const int FutureSize = 6;

        public static SfLoopInfo Empty { get; } = new SfLoopInfo {Future = new int[FutureSize]};

        public short TimeSigNum;

        public short TimeSigDen;

        public int LoopMode;

        public int NumBeats;

        public float Bpm;

        public int RootKey;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = FutureSize, ArraySubType = UnmanagedType.I4)]
        public int[] Future;
    }
}