namespace Cave.Windows
{
    /// <summary>
    /// WaveInMessage (Windows messages sent by winmm)
    /// </summary>
    public enum WIM
    {
        /// <summary>
        /// This message is sent to a waveInProc callback function when a waveform-audio input device is opened.
        /// </summary>
        OPEN = 0x3BE,

        /// <summary>
        /// The WIM_CLOSE message is sent to the specified waveform-audio input callback function when a waveform-audio input device is closed. The device handle is no longer valid after this message has been sent.
        /// </summary>
        CLOSE = 0x3BF,

        /// <summary>
        /// The WIM_DATA message is sent to the specified waveform-audio input callback function when waveform-audio data is present in the input buffer and the buffer is being returned to the application. The message can be sent when the buffer is full or after the waveInReset function is called.
        /// dwParam1 = Pointer to a WAVEHDR structure that identifies the buffer containing the data.
        /// </summary>
        DATA = 0x3C0,
    }
    
}
