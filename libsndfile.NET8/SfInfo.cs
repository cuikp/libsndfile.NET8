using System.Runtime.InteropServices;


namespace libsndfile.NET8
{

    internal struct SfInfo
    {
        public long Frames;
        public int SampleRate;
        public int Channels;
        public SfFormat__ Format;
        public int Sections;

        [MarshalAs(UnmanagedType.Bool)]
        public bool Seekable;

        public static explicit operator SfInfo(SfFormat format)
        {
            return format.ToInfo();
        }
    }
}