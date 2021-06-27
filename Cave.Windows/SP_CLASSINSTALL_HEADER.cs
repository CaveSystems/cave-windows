using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// An SP_CLASSINSTALL_HEADER is the first member of any class install parameters structure. It contains the device installation request code that defines the format of the rest of the install parameters structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SP_CLASSINSTALL_HEADER
    {
        /// <summary>
        /// The size, in bytes, of the SP_CLASSINSTALL_HEADER structure.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// The device installation request (DIF code) for the class install parameters structure.
        /// </summary>
        public DIF InstallFunction;
    }
}
