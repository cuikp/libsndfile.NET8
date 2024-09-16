# libsndfile.NET8

[![NuGet](https://img.shields.io/nuget/v/libsndfile.NET8.svg)](https://www.nuget.org/packages/libsndfile.NET8/1.0.1)

This repository is an upgrade and update to an existing one (not associated with this repository) found at:  
https://github.com/aybe/libsndfile.NET

This is an upgrade of that repository, from .NET Standard 2.0 to .NET8.

In addition, since the libsndfile library has since been able to read/write mp3 files, this repo adds the corresponding support in the SfFormats of:
SfFormatMajor.MPEG
SfFormatSubtype.MPEG_LAYER_III, 
and their combination as:
SfFormat.DefaultMp3

