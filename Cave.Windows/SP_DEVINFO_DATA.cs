using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// An SP_DEVINFO_DATA structure defines a device instance that is a member of a device information set.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SP_DEVINFO_DATA
    {
        /// <summary>
        /// The size, in bytes, of the SP_DEVINFO_DATA structure.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// The GUID of the device's setup class.
        /// </summary>
        public Guid ClassGuid;

        /// <summary>
        /// An opaque handle to the device instance (also known as a handle to the devnode).
        /// </summary>
        public uint DevInst;

        /// <summary>
        /// Reserved. For internal use only.
        /// </summary>
        public IntPtr Reserved;
    }
}
