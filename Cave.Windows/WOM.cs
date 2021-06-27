namespace Cave.Windows
{
    /// <summary>
    /// WaveOutMessage (Windows messages sent by winmm)
    /// </summary>
    public enum WOM
    {
        /// <summary>
        /// The WOM_OPEN message is sent to a waveform-audio output callback function when a waveform-audio output device is opened.
        /// </summary>
        OPEN = 0x3BB,

        /// <summary>
        /// The WOM_CLOSE message is sent to a waveform-audio output callback function when a waveform-audio output device is closed. The device handle is no longer valid after this message has been sent.
        /// </summary>
        CLOSE = 0x3BC,

        /// <summary>
        /// The WOM_DONE message is sent to a waveform-audio output callback function when the specified output buffer is being returned to the application. Buffers are returned to the application when they have been played, or as the result of a call to the waveOutReset function.
        /// dwParam1 = Pointer to a WAVEHDR structure identifying the buffer.
        /// </summary>
        DONE = 0x3BD,
    }
}
