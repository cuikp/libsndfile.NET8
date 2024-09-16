using System;
using System.Runtime.InteropServices;


namespace libsndfile.NET8
{
    public sealed partial class SndFile
    {
        #region Items

        private void CheckReadWriteItemsParameters(Array array, long items)
        {
            if (array == null || array.Length < 1)
                throw new ArgumentOutOfRangeException(nameof(array));

            if (items <= 0)
                throw new ArgumentOutOfRangeException(nameof(items));
        }

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_read_short(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] short[] buffer,
            long items
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_read_int(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] int[] buffer,
            long items
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_read_float(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] float[] buffer,
            long items
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_read_double(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] double[] buffer,
            long items
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_write_short(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] short[] buffer,
            long items
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_write_int(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] int[] buffer,
            long items
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_write_float(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] float[] buffer,
            long items
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_write_double(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] double[] buffer,
            long items
        );


        public unsafe long ReadItems(short[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_read_short(Handle, buffer, items);
        }


        public unsafe long ReadItems(int[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_read_int(Handle, buffer, items);
        }


        public unsafe long ReadItems(float[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_read_float(Handle, buffer, items);
        }


        public unsafe long ReadItems(double[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_read_double(Handle, buffer, items);
        }


        public unsafe long WriteItems(short[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_write_short(Handle, buffer, items);
        }


        public unsafe long WriteItems(int[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_write_int(Handle, buffer, items);
        }


        public unsafe long WriteItems(float[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_write_float(Handle, buffer, items);
        }


        public unsafe long WriteItems(double[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_write_double(Handle, buffer, items);
        }

        #endregion

        #region Frames

        private void CheckReadWriteFramesParameters(Array array, long frames)
        {
            if (array == null || array.Length < Format.Channels)
                throw new ArgumentOutOfRangeException(nameof(array));

            if (frames <= 0)
                throw new ArgumentOutOfRangeException(nameof(frames));
        }

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_short(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] short[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_int(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] int[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_float(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] float[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_double(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] double[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_writef_short(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] short[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_writef_int(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] int[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_writef_float(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] float[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_writef_double(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] double[] buffer,
            long frames
        );


        public unsafe long ReadFrames(short[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_readf_short(Handle, buffer, frames);
        }


        public unsafe long ReadFrames(int[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_readf_int(Handle, buffer, frames);
        }


        public unsafe long ReadFrames(float[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_readf_float(Handle, buffer, frames);
        }


        public unsafe long ReadFrames(double[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_readf_double(Handle, buffer, frames);
        }


        public unsafe long WriteFrames(short[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_writef_short(Handle, buffer, frames);
        }


        public unsafe long WriteFrames(int[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_writef_int(Handle, buffer, frames);
        }


        public unsafe long WriteFrames(float[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_writef_float(Handle, buffer, frames);
        }


        public unsafe long WriteFrames(double[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_writef_double(Handle, buffer, frames);
        }

        #endregion

        #region Other

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void sf_write_sync(
            SndFile__* sndFile
        );


        public unsafe void WriteSync()
        {
            sf_write_sync(Handle);
        }

        #endregion
    }
}