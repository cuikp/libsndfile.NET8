﻿using System;
using System.Runtime.InteropServices;

namespace libsndfile.NET8
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long SfVirtualWrite(IntPtr ptr, long count, IntPtr userData);
}