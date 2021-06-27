using System;

namespace Cave.Windows
{
    /// <summary>
    /// Standard formats
    /// </summary>
    [Flags]
    public enum WAVE_FORMAT
    { 
        /// <summary>
        /// 11.025 kHz, Mono, 8-bit
        /// </summary>
        Pcm11KhzMono8Bit = 0x00000001,
        /// <summary>
        /// 11.025 kHz, Stereo, 8-bit
        /// </summary>
        Pcm11KhzStereo8Bit = 0x00000002,
        /// <summary>
        /// 11.025 kHz, Mono, 16-bit
        /// </summary>
        Pcm11KhzMono16Bit = 0x00000004,
        /// <summary>
        /// 11.025 kHz, Stereo, 16-bit
        /// </summary>
        Pcm11KhzStereo16Bit = 0x00000008,

        /// <summary>
        /// 22.05 kHz, Mono, 8-bit
        /// </summary>
        Pcm22KhzMono8Bit = 0x00000010,
        /// <summary>
        /// 22.05 kHz, Stereo, 8-bit
        /// </summary>
        Pcm22KhzStereo8Bit = 0x00000020,
        /// <summary>
        /// 22.05 kHz, Mono, 16-bit
        /// </summary>
        Pcm22KhzMono16Bit = 0x00000040,
        /// <summary>
        /// 22.05 kHz, Stereo, 16-bit
        /// </summary>
        Pcm22KhzStereo16Bit = 0x00000080,

        /// <summary>
        /// 44.1 kHz, Mono, 8-bit
        /// </summary>
        Pcm44KhzMono8Bit = 0x00000100,
        /// <summary>
        /// 44.1 kHz, Stereo, 8-bit
        /// </summary>
        Pcm44KhzStereo8Bit = 0x00000200,
        /// <summary>
        /// 44.1 kHz, Mono, 16-bit
        /// </summary>
        Pcm44KhzMono16Bit = 0x00000400,
        /// <summary>
        /// 44.1 kHz, Stereo, 16-bit
        /// </summary>
        Pcm44KhzStereo16Bit = 0x00000800,

        /// <summary>
        /// 48 kHz, Mono, 8-bit
        /// </summary>
        Pcm48KhzMono8Bit = 0x00001000,
        /// <summary>
        /// 48 kHz, Stereo, 8-bit
        /// </summary>
        Pcm48KhzStereo8Bit = 0x00002000,
        /// <summary>
        /// 48 kHz, Mono, 16-bit
        /// </summary>
        Pcm48KhzMono16Bit = 0x00004000,
        /// <summary>
        /// 48 kHz, Stereo, 16-bit
        /// </summary>
        Pcm48KhzStereo16Bit = 0x00008000,

        /// <summary>
        /// 96 kHz, Mono, 8-bit
        /// </summary>
        Pcm96KhzMono8Bit = 0x00010000,
        /// <summary>
        /// 96 kHz, Stereo, 8-bit
        /// </summary>
        Pcm96KhzStereo8Bit = 0x00020000,
        /// <summary>
        /// 96 kHz, Mono, 16-bit
        /// </summary>
        Pcm96KhzMono16Bit = 0x00040000,
        /// <summary>
        /// 96 kHz, Stereo, 16-bit
        /// </summary>
        Pcm96KhzStereo16Bit = 0x00080000,
    }
}
