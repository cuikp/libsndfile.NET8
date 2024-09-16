﻿using System.Runtime.InteropServices;


namespace libsndfile.NET8
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SfCartTimer
    {
        public const int UsageSize = 4;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = UsageSize)]
        public string Usage;

        public int Value;
    }
}