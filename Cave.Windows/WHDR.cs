using System;

namespace Cave.Windows
{
    /// <summary>
    /// Wave Header Flags enumeration
    /// </summary>
    [Flags]
    public enum WHDR
    {
        /// <summary>No flags</summary>
        NONE = 0x00000000,

        /// <summary>
        /// Set by the device driver to indicate that it is finished with the buffer and is returning it to the application.
        /// </summary>
        DONE = 0x00000001,

        /// <summary>
        /// Set by Windows to indicate that the buffer has been prepared with the waveInPrepareHeader or waveOutPrepareHeader function.
        /// </summary>
        PREPARED = 0x00000002,

        /// <summary>
        /// This buffer is the first buffer in a loop. This flag is used only with output buffers.
        /// </summary>
        BEGINLOOP = 0x00000004,

        /// <summary>
        /// This buffer is the last buffer in a loop. This flag is used only with output buffers.
        /// </summary>
        ENDLOOP = 0x00000008,

        /// <summary>
        /// Set by Windows to indicate that the buffer is queued for playback.
        /// </summary>
        INQUEUE = 0x00000010,
    }
}
