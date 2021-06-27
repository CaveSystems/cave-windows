using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// The MMTIME structure contains timing information for different types of multimedia data.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct MMTIME
    {
        /// <summary>
        /// Time format.
        /// </summary>
        [FieldOffset(0)]
        public MMTIME_FORMAT wType;

        /// <summary>
        /// Number of milliseconds. Used when wType is TIME_MS.
        /// </summary>
        [FieldOffset(4)]
        public uint ms;

        /// <summary>
        /// Number of samples. Used when wType is TIME_SAMPLES.
        /// </summary>
        [FieldOffset(4)]
        public uint sample;

        /// <summary>
        /// Byte count. Used when wType is TIME_BYTES.
        /// </summary>
        [FieldOffset(4)]
        public uint cb;

        /// <summary>
        /// Ticks in MIDI stream. Used when wType is TIME_TICKS.
        /// </summary>
        [FieldOffset(4)]
        public uint ticks;

        /// <summary>
        /// SMPTE time structure. Used when wType is TIME_SMPTE.
        /// </summary>
        [FieldOffset(4)]
        public byte smpteHour;

        /// <summary>
        /// SMPTE time structure. Used when wType is TIME_SMPTE.
        /// </summary>
        [FieldOffset(5)]
        public byte smpteMin;

        /// <summary>
        /// SMPTE time structure. Used when wType is TIME_SMPTE.
        /// </summary>
        [FieldOffset(6)]
        public byte smpteSec;

        /// <summary>
        /// SMPTE time structure. Used when wType is TIME_SMPTE.
        /// </summary>
        [FieldOffset(7)]
        public byte smpteFrame;

        /// <summary>
        /// SMPTE time structure. Used when wType is TIME_SMPTE.
        /// </summary>
        [FieldOffset(8)]
        public byte smpteFps;

        /// <summary>
        /// SMPTE time structure. Used when wType is TIME_SMPTE.
        /// </summary>
        [FieldOffset(9)]
        public byte smpteDummy;

        /// <summary>
        /// SMPTE time structure. Used when wType is TIME_SMPTE.
        /// </summary>
        [FieldOffset(10)]
        public byte smptePad0;

        /// <summary>
        /// SMPTE time structure. Used when wType is TIME_SMPTE.
        /// </summary>
        [FieldOffset(11)]
        public byte smptePad1;

        /// <summary>
        /// MIDI time structure. Used when wType is TIME_MIDI.
        /// </summary>
        [FieldOffset(4)]
        public uint midiSongPtrPos;

        /// <summary>
        /// Obtains a string describing the instance
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch(wType)
            {
                case MMTIME_FORMAT.BYTES: return cb + "b";
                case MMTIME_FORMAT.MS: return ms + "ms";
                case MMTIME_FORMAT.SAMPLES: return "sample: " + sample;
                case MMTIME_FORMAT.SMPTE: return string.Format("smpte: {0}:{1:2}:{2:2} frame {3}", smpteHour, smpteMin, smpteSec, smpteFrame);
                case MMTIME_FORMAT.MIDI: return "midi: " + midiSongPtrPos;
                default: return wType.ToString().ToLower();
            }
        }
    }
}
