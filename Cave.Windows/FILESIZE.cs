using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Contains a 64-bit value representing the size of a file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct FILESIZE
    {
        /// <summary>
        /// The low-order part of the file size.
        /// </summary>
        [FieldOffset(4)]
        public uint dwLowFileSize;

        /// <summary>
        /// The high-order part of the file size.
        /// </summary>
        [FieldOffset(0)]
        public uint dwHighFileSize;

        /// <summary>
        /// Full file size value.
        /// </summary>
        public long Value
        {
            get
            {
                long result = dwHighFileSize;
                result <<= 32;
                result |= dwLowFileSize;
                return result;
            }
            set
            {
                dwLowFileSize = (uint)(value & 0xFFFFFFFF);
                dwHighFileSize = (uint)(value >> 32);
            }
        }
    }
}
