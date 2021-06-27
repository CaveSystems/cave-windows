using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// The WAVEHDR structure defines the header used to identify a waveform-audio buffer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WAVEHDR
    {
        /// <summary>
        /// Pointer to the waveform buffer. 
        /// </summary>
        public IntPtr lpData;
        
        /// <summary>
        /// Length, in bytes, of the buffer. 
        /// </summary>
        public int dwBufferLength;

        /// <summary>
        /// When the header is used in input, specifies how much data is in the buffer. 
        /// </summary>
        public int dwBytesRecorded;

        /// <summary>
        /// User data. (Pointer)
        /// </summary>
        public IntPtr dwUser;

        /// <summary>
        /// A bitwise OR of zero of more flags.
        /// </summary>
        public WHDR dwFlags;

        /// <summary>
        /// Number of times to play the loop. This member is used only with output buffers.
        /// </summary>
        public int dwLoops;

        /// <summary>
        /// Reserved
        /// </summary>
        public IntPtr lpNext;

        /// <summary>
        /// Reserved
        /// </summary>
        public IntPtr reserved;
    }
}
