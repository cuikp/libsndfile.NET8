﻿using System;
using System.Runtime.InteropServices;

namespace libsndfile.NET8
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long SfVirtualTell(IntPtr userData);
}