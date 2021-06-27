namespace Cave.Windows
{
    /// <summary>
    /// MMTIME format
    /// </summary>
    public enum MMTIME_FORMAT : uint
    {
        /// <summary>
        /// Time in milliseconds.
        /// </summary>
        MS = 0x1,

        /// <summary>
        /// Number of waveform-audio samples.
        /// </summary>
        SAMPLES = 0x2,

        /// <summary>
        /// Current byte offset from beginning of the file.
        /// </summary>
        BYTES = 0x4,
        /// <summary>
        /// SMPTE (Society of Motion Picture and Television Engineers) time.
        /// </summary>
        SMPTE = 0x8,

        /// <summary>
        /// MIDI time.
        /// </summary>
        MIDI = 0x10,

        /// <summary>
        /// Ticks within a MIDI stream.
        /// </summary>
        TICKS = 0x20,
    }
}
