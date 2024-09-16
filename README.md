# libsndfile.NET8

[![NuGet](https://img.shields.io/nuget/v/libsndfile.NET8.svg)](https://www.nuget.org/packages/libsndfile.NET8/)

This repository is an upgrade and update to an existing C# wrapper around libsndfile (not associated with this repository) found at:  
https://github.com/aybe/libsndfile.NET

This is an upgrade of that repository, from .NET Standard 2.0 to .NET8.

Among other functions, libsndfile allows reading and writing of audio files in numerous formats, using byte/float arrays.

Since libsndfile.NET was uploaded, the original libsndfile library has been updated to be able to read/write mp3 files, and this repo adds that corresponding support in the SfFormats of:

SfFormatMajor.MPEG
SfFormatSubtype.MPEG_LAYER_III, 
and their combination as:
SfFormat.DefaultMp3

