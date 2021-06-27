using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Contains a 64-bit value representing the number of 100-nanosecond intervals since January 1, 1601 (UTC).
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct FILETIME
    {
        /// <summary>
        /// The low-order part of the file time.
        /// </summary>
        [FieldOffset(0)]
        public uint dwLowDateTime;

        /// <summary>
        /// The high-order part of the file time.
        /// </summary>
        [FieldOffset(4)]
        public uint dwHighDateTime;

        /// <summary>
        /// Full file time value.
        /// </summary>
        [FieldOffset(0)]
        public long qwDateTime;

        /// <summary>
        /// DateTime Value
        /// </summary>
        public DateTime Value
        {
            get => DateTime.FromFileTime(qwDateTime);
            set => qwDateTime = value.ToFileTime();
        }
    }
}
