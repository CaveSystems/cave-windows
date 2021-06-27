using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// The WAVEOUTCAPS structure describes the capabilities of a waveform-audio output device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WAVEOUTCAPS
    {
        private const int MAXPNAMELEN = 32;

        /// <summary>
        /// Manufacturer identifier for the device driver for the device. Manufacturer identifiers are defined in Manufacturer and Product Identifiers.
        /// </summary>
        public short wMid;

        /// <summary>
        /// Product identifier for the device. Product identifiers are defined in Manufacturer and Product Identifiers.
        /// </summary>
        public short wPid;

        /// <summary>
        /// Version number of the device driver for the device. The high-order byte is the major version number, and the low-order byte is the minor version number.
        /// </summary>
        public int vDriverVersion;

        /// <summary>
        /// Product Name (szPname)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAXPNAMELEN)]
        public string productName;

        /// <summary>
        /// Standard formats that are supported.
        /// </summary>
        public WAVE_FORMAT dwFormats;

        /// <summary>
        /// Number specifying whether the device supports mono (1) or stereo (2) output.
        /// Some devices return 0 or -1 for user definable channel layouts, headphone mode, ...
        /// </summary>
        public short wChannels;

        /// <summary>
        /// Packing.
        /// </summary>
        public short wReserved1;
        
        /// <summary>
        /// Optional functionality supported by the device
        /// </summary>
        public WAVECAPS dwSupport; 
    }
}
