using System;

namespace Cave.Windows
{
    /// <summary>
    /// Functionality flags
    /// </summary>
    [Flags]
    public enum WAVECAPS
    {
        /// <summary>
        /// Supports pitch control.
        /// </summary>
        Pitch = 0x0001,

        /// <summary>
        /// Supports playback rate control.
        /// </summary>
        PlaybackRate = 0x0002,

        /// <summary>
        /// Supports volume control.
        /// </summary>
        Volume = 0x0004,

        /// <summary>
        /// Supports separate left and right volume control.
        /// </summary>
        LRVolume = 0x0008,

        /// <summary>
        /// The driver is synchronous and will block while playing a buffer.
        /// </summary>
        Sync = 0x0010,

        /// <summary>
        /// Returns sample-accurate position information.
        /// </summary>
        SampleAccurate = 0x0020,
    }
}
