using System;
using System.IO;


namespace libsndfile.NET8
{

    public static class SfSeekExtensions
    {
        public static SeekOrigin ToSeekOrigin(this SfSeek seek)
        {
            switch (seek)
            {
                case SfSeek.Begin:
                    return SeekOrigin.Begin;
                case SfSeek.Current:
                    return SeekOrigin.Current;
                case SfSeek.End:
                    return SeekOrigin.End;
                default:
                    throw new ArgumentOutOfRangeException(nameof(seek), seek, null);
            }
        }
    }
}