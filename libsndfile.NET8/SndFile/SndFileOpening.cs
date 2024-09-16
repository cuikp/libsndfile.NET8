using System;
using System.Runtime.InteropServices;


namespace libsndfile.NET8
{
    public sealed partial class SndFile
    {
        #region Public


        public static SndFile OpenRead(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return Open__(path, SfFormat.Empty, SfMode.Read);
        }



        public static SndFile OpenRead(SfVirtual @virtual, IntPtr userData = default)
        {
            return Open__(@virtual, SfMode.Read, userData, SfFormat.Empty);
        }



        public static SndFile OpenWrite(string path, SfFormat format)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return Open__(path, format, SfMode.Write);
        }



        public static SndFile OpenWrite(SfVirtual @virtual, SfFormat format, IntPtr userData = default)
        {
            return Open__(@virtual, SfMode.Write, userData, format);
        }

        #endregion

        #region Private

        private unsafe SndFile(SndFile__* file, SfInfo info)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Handle = file;
            Info = info;
        }

      private static void CheckOpenParameters(SfFormat format, SfMode mode)
      {
         if (format == SfFormat.Empty && mode != SfMode.Read)
            throw new ArgumentNullException(nameof(format));
      }


      private static unsafe SndFile? Open__(string path, SfFormat format, SfMode mode)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            CheckOpenParameters(format, mode);

            var info = format.ToInfo();
            var sndFile = sf_wchar_open(path, mode, ref info);
            return sndFile == null ? null : new SndFile(sndFile, info);
        }


        private static unsafe SndFile Open__(
            SfVirtual @virtual, SfMode mode, IntPtr userData, SfFormat format)
        {
            if (@virtual == SfVirtual.Empty)
                throw new ArgumentNullException(nameof(@virtual));

            CheckOpenParameters(format, mode);

            var info = format.ToInfo();
            var sndFile = sf_open_virtual(ref @virtual, mode, ref info, userData);
            return sndFile == null ? null : new SndFile(sndFile, info);
        }

        #endregion

        #region Native methods

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SndFile__* sf_wchar_open(
            [MarshalAs(UnmanagedType.LPWStr)] string path,
            SfMode mode,
            ref SfInfo info
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SndFile__* sf_open_virtual(
            ref SfVirtual @virtual,
            SfMode mode,
            ref SfInfo info,
            IntPtr userData
        );

        #endregion
    }
}