using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;


namespace libsndfile.NET8
{
    [SuppressMessage("ReSharper", "ConvertIfStatementToReturnStatement")]
    public static class SfCommands
    {
        #region Static


        public static unsafe string GetLibVersion()
        {
            return GetString(null, SfCommand.GetLibVersion, 128);
        }


        public static unsafe string GetLogInfo(SndFile? sndFile)
        {
            return GetString(sndFile != null ? sndFile.Handle : null, SfCommand.GetLogInfo, 2048);
        }

        private static SfFormatInfo? GetFormatInfo(SfCommand command, int format)
        {
            return GetStructure(null, command, new SfFormatInfo(format), 0);
        }


        public static SfFormatInfo? GetFormatInfo(SfFormatMajor major)
        {
            return GetFormatInfo(SfCommand.GetFormatInfo, (int) major);
        }


        public static SfFormatInfo? GetFormatInfo(SfFormatSubtype subtype)
        {
            return GetFormatInfo(SfCommand.GetFormatInfo, (int) subtype);
        }


        public static SfFormatInfo? GetFormatMajor(int major)
        {
            return GetFormatInfo(SfCommand.GetFormatMajor, major);
        }


        public static int GetFormatMajorCount()
        {
            return GetInt(SfCommand.GetFormatMajorCount);
        }


        public static SfFormatInfo? GetFormatSubtype(int subtype)
        {
            return GetFormatInfo(SfCommand.GetFormatSubtype, subtype);
        }


        public static int GetFormatSubtypeCount()
        {
            return GetInt(SfCommand.GetFormatSubtypeCount);
        }


        public static SfFormatInfo? GetSimpleFormat(int format)
        {
            return GetFormatInfo(SfCommand.GetSimpleFormat, format);
        }


        public static int GetSimpleFormatCount()
        {
            return GetInt(SfCommand.GetSimpleFormatCount);
        }

        #endregion

        #region Extensions


        public static double[] CalcMaxAllChannels(this SndFile sndFile)
        {
            return GetDoubles(sndFile, SfCommand.CalcMaxAllChannels, 0);
        }


        public static double[] CalcNormMaxAllChannels(this SndFile sndFile)
        {
            return GetDoubles(sndFile, SfCommand.CalcNormMaxAllChannels, 0);
        }


        public static double? CalcNormSignalMax(this SndFile sndFile)
        {
            return GetDouble(sndFile, SfCommand.CalcNormSignalMax, 0);
        }


        public static double? CalcSignalMax(this SndFile sndFile)
        {
            return GetDouble(sndFile, SfCommand.CalcSignalMax, 0);
        }


        public static bool FileTruncate(this SndFile sndFile, long frames)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            return SetLong(sndFile, SfCommand.FileTruncate, frames);
        }


        public static SfAmbisonic? GetAmbisonic(this SndFile sndFile)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile, SfCommand.WavexGetAmbisonic, IntPtr.Zero, 0);
            if (i == 0)
                return null;

            return (SfAmbisonic) i;
        }


        public static SfBroadcastInfo? GetBroadcastInfo(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetBroadcastInfo, SfBroadcastInfo.Empty, SF_TRUE);
        }


        public static SfCartInfo? GetCartInfo(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetCartInfo, SfCartInfo.Empty, SF_TRUE);
        }


        public static bool GetClipping(this SndFile sndFile)
        {
            return GetBool(sndFile, SfCommand.GetClipping);
        }


        public static SfCues? GetCue(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetCue, SfCues.Empty, SF_TRUE);
        }


        public static unsafe uint? GetCueCount(this SndFile sndFile)
        {
            var u = default(uint);

            var i = sf_command(sndFile, SfCommand.GetCueCount, &u, sizeof(uint));
            if (i != SF_TRUE)
                return null;

            return u;
        }


        public static SfEmbedFileInfo? GetEmbedFileInfo(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetEmbedFileInfo, SfEmbedFileInfo.Empty, 0);
        }


        public static SfInstrument? GetInstrument(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetInstrument, SfInstrument.Empty, SF_TRUE);
        }


        public static SfLoopInfo? GetLoopInfo(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetLoopInfo, SfLoopInfo.Empty, SF_TRUE);
        }


        public static double[] GetMaxAllChannels(this SndFile sndFile)
        {
            return GetDoubles(sndFile, SfCommand.GetMaxAllChannels, SF_TRUE);
        }


        public static bool GetNormDouble(this SndFile sndFile)
        {
            return GetBool(sndFile, SfCommand.GetNormDouble);
        }


        public static bool GetNormFloat(this SndFile sndFile)
        {
            return GetBool(sndFile, SfCommand.GetNormFloat);
        }


        public static double? GetSignalMax(this SndFile sndFile)
        {
            return GetDouble(sndFile, SfCommand.GetSignalMax, SF_TRUE);
        }


        public static bool RawNeedsEndswap(this SndFile sndFile)
        {
            return GetBool(sndFile, SfCommand.RawDataNeedsEndswap);
        }


        public static bool Rf64AutoDowngrade(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.Rf64AutoDowngrade, enable);
        }


        public static bool SetAddPeakChunk(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetAddPeakChunk, enable);
        }


        public static SfAmbisonic? SetAmbisonic(this SndFile sndFile, SfAmbisonic ambisonic)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile, SfCommand.WavexSetAmbisonic, IntPtr.Zero, (int) ambisonic);
            if (i == 0)
                return null;

            return (SfAmbisonic) i;
        }


        public static bool SetBroadcastInfo(this SndFile sndFile, SfBroadcastInfo broadcastInfo)
        {
            return SetStructure(sndFile, SfCommand.SetBroadcastInfo, broadcastInfo, SF_TRUE);
        }


        public static bool SetCartInfo(this SndFile sndFile, SfCartInfo cartInfo)
        {
            return SetStructure(sndFile, SfCommand.SetCartInfo, cartInfo, SF_TRUE);
        }


        public static bool SetClipping(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetClipping, enable);
        }


        public static bool SetCompressionLevel(this SndFile sndFile, double level)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            if (level < 0.0d || level > 1.0d)
                throw new ArgumentOutOfRangeException(nameof(level));

            return SetDouble(sndFile, SfCommand.SetCompressionLevel, level);
        }


        public static bool SetCue(this SndFile sndFile, SfCues cues)
        {
            return SetStructure(sndFile, SfCommand.SetCue, cues, SF_TRUE);
        }


        public static bool SetInstrument(this SndFile sndFile, SfInstrument instrument)
        {
            return SetStructure(sndFile, SfCommand.SetInstrument, instrument, SF_TRUE);
        }


        public static bool SetNormDouble(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetNormDouble, enable);
        }


        public static bool SetNormFloat(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetNormFloat, enable);
        }


        public static bool SetScaleIntFloatWrite(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetScaleIntFloatWrite, enable);
        }


        public static bool SetScaleFloatIntRead(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetScaleFloatIntRead, enable);
        }


        public static bool SetRawStartOffset(this SndFile sndFile, long offset)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            return SetLong(sndFile, SfCommand.SetRawStartOffset, offset);
        }


        public static bool SetUpdateHeaderAuto(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetUpdateHeaderAuto, enable);
        }


        public static bool SetVbrEncodingQuality(this SndFile sndFile, double quality)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            if (quality < 0.0d || quality > 1.0d)
                throw new ArgumentOutOfRangeException(nameof(quality));

            return SetDouble(sndFile, SfCommand.SetVbrEncodingQuality, quality);
        }


        public static void UpdateHeaderNow(this SndFile sndFile)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            sf_command(sndFile, SfCommand.UpdateHeaderNow, IntPtr.Zero, 0);
        }

        #endregion

        #region Helpers

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private const int SF_FALSE = 0;

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private const int SF_TRUE = 1;

        private static bool GetBool(SndFile sndFile, SfCommand command)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            return SetBool(sndFile, command, false);
        }

        private static unsafe double? GetDouble(SndFile sndFile, SfCommand command, int match)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var d = default(double);

            var i = sf_command(sndFile, command, &d, sizeof(double));
            if (i != match)
                return null;

            return d;
        }

        private static unsafe double[] GetDoubles(SndFile sndFile, SfCommand command, int match)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var doubles = new double[sndFile.Format.Channels];

            fixed (double* d = doubles)
            {
                var i = sf_command(sndFile.Handle, command, d, sizeof(double) * doubles.Length);
                if (i != match)
                    return null;

                return doubles;
            }
        }

        private static unsafe int GetInt(SfCommand command)
        {
            var i = default(int);
            sf_command((SndFile__*) null, command, &i, sizeof(int));
            return i;
        }

        private static unsafe string GetString(SndFile__* sndFile, SfCommand command, int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            var ptr = stackalloc sbyte[size];
            var cmd = sf_command(sndFile, command, ptr, size);
            var str = new string(ptr);

            return str;
        }

        [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
        private static unsafe T? GetStructure<T>(SndFile? sndFile, SfCommand command, T structure, int valid)
            where T : struct
        {
            using (var m = new Marshaller<T>(structure))
            {
                var handle = sndFile != null ? sndFile.Handle : null;

                var i = sf_command(handle, command, m.Address, m.Size);
                if (i != valid)
                    return null;

                return m.Pop();
            }
        }

        private static bool SetBool(SndFile sndFile, SfCommand command, bool value)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile, command, IntPtr.Zero, value ? SF_TRUE : SF_FALSE);

            switch (i)
            {
                case SF_TRUE:
                    return true;
                case SF_FALSE:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i));
            }
        }

        private static unsafe bool SetDouble(SndFile sndFile, SfCommand command, double value)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile, command, &value, sizeof(double));

            switch (i)
            {
                case SF_TRUE:
                    return true;
                case SF_FALSE:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i));
            }
        }

        private static unsafe bool SetLong(SndFile sndFile, SfCommand command, long value)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));


            var i = sf_command(sndFile, command, &value, sizeof(long));
            return i == 0;
        }

        private static bool SetStructure<T>(SndFile sndFile, SfCommand command, T structure, int valid) where T : struct
        {
            using (var m = new Marshaller<T>(structure))
            {
                var i = sf_command(sndFile, command, m.Address, m.Size);
                return i == valid;
            }
        }

        #endregion


        #region Native

        private static unsafe int sf_command(SndFile sndFile, SfCommand cmd, IntPtr data, int dataSize)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile.Handle, cmd, data, dataSize);

            return i;
        }

        private static unsafe int sf_command(SndFile sndFile, SfCommand cmd, void* data, int dataSize)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile.Handle, cmd, data, dataSize);

            return i;
        }

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int sf_command(SndFile__* sndFile, SfCommand cmd, IntPtr data, int dataSize);

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int sf_command(SndFile__* sndFile, SfCommand cmd, void* data, int dataSize);

        #endregion
    }
}