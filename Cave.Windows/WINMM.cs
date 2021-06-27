using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Provides access to the windows multimedia dll (winmm)
    /// </summary>
    [SuppressMessage("Interoperability", "CA1401")]
    public class WINMM
    {
        /// <summary>
        /// Windows multimedia error codes from mmsystem.h.
        /// </summary>
        public enum RESULT
        {
            /// <summary>no error, MMSYSERR_NOERROR</summary>
            NoError = 0,
            /// <summary>unspecified error, MMSYSERR_ERROR</summary>
            UnspecifiedError = 1,
            /// <summary>device ID out of range, MMSYSERR_BADDEVICEID</summary>
            BadDeviceId = 2,
            /// <summary>driver failed enable, MMSYSERR_NOTENABLED</summary>
            NotEnabled = 3,
            /// <summary>device already allocated, MMSYSERR_ALLOCATED</summary>
            AlreadyAllocated = 4,
            /// <summary>device handle is invalid, MMSYSERR_INVALHANDLE</summary>
            InvalidHandle = 5,
            /// <summary>no device driver present, MMSYSERR_NODRIVER</summary>
            NoDriver = 6,
            /// <summary>memory allocation error, MMSYSERR_NOMEM</summary>
            MemoryAllocationError = 7,
            /// <summary>function isn't supported, MMSYSERR_NOTSUPPORTED</summary>
            NotSupported = 8,
            /// <summary>error value out of range, MMSYSERR_BADERRNUM</summary>
            BadErrorNumber = 9,
            /// <summary>invalid flag passed, MMSYSERR_INVALFLAG</summary>
            InvalidFlag = 10,
            /// <summary>invalid parameter passed, MMSYSERR_INVALPARAM</summary>
            InvalidParameter = 11,
            /// <summary>handle being used simultaneously on another thread (eg callback),MMSYSERR_HANDLEBUSY</summary>
            HandleBusy = 12,
            /// <summary>specified alias not found, MMSYSERR_INVALIDALIAS</summary>
            InvalidAlias = 13,
            /// <summary>bad registry database, MMSYSERR_BADDB</summary>
            BadRegistryDatabase = 14,
            /// <summary>registry key not found, MMSYSERR_KEYNOTFOUND</summary>
            RegistryKeyNotFound = 15,
            /// <summary>registry read error, MMSYSERR_READERROR</summary>
            RegistryReadError = 16,
            /// <summary>registry write error, MMSYSERR_WRITEERROR</summary>
            RegistryWriteError = 17,
            /// <summary>registry delete error, MMSYSERR_DELETEERROR</summary>
            RegistryDeleteError = 18,
            /// <summary>registry value not found, MMSYSERR_VALNOTFOUND</summary>
            RegistryValueNotFound = 19,
            /// <summary>driver does not call DriverCallback, MMSYSERR_NODRIVERCB</summary>
            NoDriverCallback = 20,
            /// <summary>more data to be returned, MMSYSERR_MOREDATA</summary>
            MoreData = 21,

            /// <summary>unsupported wave format, WAVERR_BADFORMAT</summary>
            WaveBadFormat = 32,
            /// <summary>still something playing, WAVERR_STILLPLAYING</summary>
            WaveStillPlaying = 33,
            /// <summary>header not prepared, WAVERR_UNPREPARED</summary>
            WaveHeaderUnprepared = 34,
            /// <summary>device is synchronous, WAVERR_SYNC</summary>
            WaveSync = 35,

            // ACM error codes, found in msacm.h

            /// <summary>Conversion not possible (ACMERR_NOTPOSSIBLE)</summary>
            AcmNotPossible = 512,
            /// <summary>Busy (ACMERR_BUSY)</summary>
            AcmBusy = 513,
            /// <summary>Header Unprepared (ACMERR_UNPREPARED)</summary>
            AcmHeaderUnprepared = 514,
            /// <summary>Cancelled (ACMERR_CANCELED)</summary>
            AcmCancelled = 515,

            // Mixer error codes, found in mmresult.h

            /// <summary>invalid line (MIXERR_INVALLINE)</summary>
            MixerInvalidLine = 1024,
            /// <summary>invalid control (MIXERR_INVALCONTROL)</summary>
            MixerInvalidControl = 1025,
            /// <summary>invalid value (MIXERR_INVALVALUE)</summary>
            MixerInvalidValue = 1026,
        }

        /// <summary>
        /// Windows multimedia open flags
        /// </summary>
        [Flags]
        public enum OPEN_FLAGS : uint
        {
            /// <summary>
            /// No callback mechanism. This is the default setting.
            /// </summary>
            CALLBACK_NULL = 0,

            /// <summary>
            /// The dwCallback parameter is a window handle.
            /// </summary>
            CALLBACK_WINDOW = 0x10000,

            /// <summary>
            /// The dwCallback parameter is a thread identifier.
            /// </summary>
            CALLBACK_THREAD = 0x20000,

            /// <summary>
            /// The dwCallback parameter is a callback procedure address.
            /// </summary>
            CALLBACK_FUNCTION = 0x30000,

            /// <summary>
            /// The dwCallback parameter is an event handle.
            /// </summary>
            CALLBACK_EVENT = 0x50000,

            /// <summary>
            /// If this flag is specified, waveOutOpen queries the device to determine if it supports the given format, but the device is not actually opened.
            /// </summary>
            WAVE_FORMAT_QUERY = 0x0001,

            /// <summary>
            /// If this flag is specified, a synchronous waveform-audio device can be opened. If this flag is not specified while opening a synchronous driver, the device will fail to open.
            /// </summary>
            WAVE_ALLOWSYNC = 0x0002,

            /// <summary>
            /// If this flag is specified, the uDeviceID parameter specifies a waveform-audio device to be mapped to by the wave mapper.
            /// </summary>
            WAVE_MAPPED = 0x0004,

            /// <summary>
            /// If this flag is specified, the ACM driver does not perform conversions on the audio data.
            /// </summary>
            WAVE_FORMAT_DIRECT = 0x0008,

            /// <summary>
            /// If this flag is specified and the uDeviceID parameter is WAVE_MAPPER, the function opens the default communication device.
            /// This flag applies only when uDeviceID equals WAVE_MAPPER. Note  Requires Windows 7
            /// </summary>
            WAVE_MAPPED_DEFAULT_COMMUNICATION_DEVICE = 0x0010,
        }

        /// <summary>
        /// The waveInProc function is the callback function used with the waveform-audio input device. This function is a placeholder for the application-defined function name. The address of this function can be specified in the callback-address parameter of the waveInOpen function.
        /// </summary>
        /// <param name="hwi">Handle to the waveform-audio device associated with the callback function.</param>
        /// <param name="uMsg">Waveform-audio input message.</param>
        /// <param name="dwInstance">User instance data specified with waveInOpen.</param>
        /// <param name="dwParam1">Message parameter.</param>
        /// <param name="dwParam2">Message parameter.</param>
        public delegate void WaveInProc(IntPtr hwi, WIM uMsg, IntPtr dwInstance, ref IntPtr dwParam1, IntPtr dwParam2);

        /// <summary>
        /// The waveOutProc function is the callback function used with the waveform-audio output device. The waveOutProc function is a placeholder for the application-defined function name. The address of this function can be specified in the callback-address parameter of the waveOutOpen function.
        /// </summary>
        /// <param name="hwo">Handle to the waveform-audio device associated with the callback. </param>
        /// <param name="uMsg">Waveform-audio output message</param>
        /// <param name="dwInstance">User-instance data specified with waveOutOpen. </param>
        /// <param name="dwParam1">Message parameter. </param>
        /// <param name="dwParam2">Message parameter. </param>
        public delegate void WaveOutProc(IntPtr hwo, WOM uMsg, IntPtr dwInstance, ref IntPtr dwParam1, IntPtr dwParam2);

        /// <summary>
        /// The mmioStringToFOURCC function converts a null-terminated string to a four-character code.
        /// </summary>
        /// <param name="s">String to convert to a four-character code.</param>
        /// <param name="flags">Flags for the conversion:<br/>
        /// MMIO_TOUPPER</param>
        /// <returns>Returns the four-character code created from the given string.</returns>
        [DllImport("winmm.dll")]
        public static extern int mmioStringToFOURCC([MarshalAs(UnmanagedType.LPWStr)] string s, int flags);

        /// <summary>Timers use fast period (1ms) resolution.</summary>
        /// <exception cref="Exception">Timer cannot use 1ms resolution mode!</exception>
        public static void TimeBeginFastPeriod()
        {
            if ((uint)ErrorCode.NO_ERROR != timeBeginPeriod(1)) throw new Exception("Timer cannot use 1ms resolution mode!");
        }

        /// <summary>Timers use fast period (1ms) resolution.</summary>
        /// <exception cref="Exception">Timer cannot use 1ms resolution mode!</exception>
        public static void TimeEndFastPeriod()
        {
            if ((uint)ErrorCode.NO_ERROR != timeEndPeriod(1)) throw new Exception("Timer cannot use 1ms resolution mode!");
        }

        /// <summary>
        /// The timeBeginPeriod function requests a minimum resolution for periodic timers.
        /// </summary>
        /// <param name="uMilliseconds">Minimum timer resolution, in milliseconds, for the application or device driver. A lower value specifies a higher (more accurate) resolution.</param>
        /// <returns>Returns TIMERR_NOERROR if successful or TIMERR_NOCANDO if the resolution specified in uPeriod is out of range.</returns>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern uint timeBeginPeriod(uint uMilliseconds);

        /// <summary>
        /// The timeEndPeriod function clears a previously set minimum timer resolution.
        /// </summary>
        /// <param name="uMilliseconds">Minimum timer resolution specified in the previous call to the timeBeginPeriod function.</param>
        /// <returns>Returns TIMERR_NOERROR if successful or TIMERR_NOCANDO if the resolution specified in uPeriod is out of range.</returns>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern uint timeEndPeriod(uint uMilliseconds);

        #region wave out
        /// <summary>
        /// The waveOutGetNumDevs function retrieves the number of waveform-audio output devices present in the system.
        /// </summary>
        /// <returns>Returns the number of devices. A return value of zero means that no devices are present or that an error occurred.</returns>
        [DllImport("winmm.dll")]
        public static extern int waveOutGetNumDevs();

        /// <summary>
        /// The waveOutPrepareHeader function prepares a waveform-audio data block for playback.
        /// </summary>
        /// <param name="hWaveOut">Handle to the waveform-audio output device. </param>
        /// <param name="lpWaveOutHdr">Pointer to a WAVEHDR structure that identifies the data block to be prepared. </param>
        /// <param name="uSize">Size, in bytes, of the WAVEHDR structure. </param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutPrepareHeader(IntPtr hWaveOut, IntPtr lpWaveOutHdr, int uSize);

        /// <summary>
        /// The waveOutUnprepareHeader function cleans up the preparation performed by the waveOutPrepareHeader function. This function must be called after the device driver is finished with a data block. You must call this function before freeing the buffer.
        /// </summary>
        /// <param name="hWaveOut">Handle to the waveform-audio output device.</param>
        /// <param name="lpWaveOutHdr">Pointer to a WAVEHDR structure identifying the data block to be cleaned up.</param>
        /// <param name="uSize">Size, in bytes, of the WAVEHDR structure.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. </returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutUnprepareHeader(IntPtr hWaveOut, IntPtr lpWaveOutHdr, int uSize);

        /// <summary>
        /// The waveOutWrite function sends a data block to the given waveform-audio output device.
        /// </summary>
        /// <param name="hWaveOut">Handle to the waveform-audio output device.</param>
        /// <param name="lpWaveOutHdr">Pointer to a WAVEHDR structure containing information about the data block.</param>
        /// <param name="uSize">Size, in bytes, of the WAVEHDR structure.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. </returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutWrite(IntPtr hWaveOut, IntPtr lpWaveOutHdr, int uSize);

        /// <summary>
        /// The waveOutOpen function opens the given waveform-audio output device for playback.
        /// </summary>
        /// <param name="hWaveOut">Pointer to a buffer that receives a handle identifying the open waveform-audio output device. Use the handle to identify the device when calling other waveform-audio output functions. This parameter might be NULL if the WAVE_FORMAT_QUERY flag is specified for fdwOpen. </param>
        /// <param name="uDeviceID">Identifier of the waveform-audio output device to open. It can be either a device identifier or a handle of an open waveform-audio input device. You can also use the following flag instead of a device identifier: WAVE_MAPPER</param>
        /// <param name="lpFormat">Pointer to a WAVEFORMATEX structure that identifies the format of the waveform-audio data to be sent to the device. You can free this structure immediately after passing it to waveOutOpen. </param>
        /// <param name="dwCallback">Specifies the callback mechanism. </param>
        /// <param name="dwInstance">User-instance data passed to the callback mechanism. This parameter is not used with the window callback mechanism. </param>
        /// <param name="dwFlags">Flags for opening the device. The following values are defined.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutOpen(out IntPtr hWaveOut, IntPtr uDeviceID, ref WAVEFORMATEX lpFormat, WaveOutProc dwCallback, IntPtr dwInstance, OPEN_FLAGS dwFlags);

        /// <summary>
        /// The waveOutReset function stops playback on the given waveform-audio output device and resets the current position to zero. All pending playback buffers are marked as done (WHDR_DONE) and returned to the application.
        /// </summary>
        /// <param name="hWaveOut">Handle to the waveform-audio output device.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutReset(IntPtr hWaveOut);

        /// <summary>
        /// The waveOutClose function closes the given waveform-audio output device.
        /// </summary>
        /// <param name="hWaveOut">Handle to the waveform-audio output device. If the function succeeds, the handle is no longer valid after this call.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutClose(IntPtr hWaveOut);

        /// <summary>
        /// The waveOutPause function pauses playback on the given waveform-audio output device. The current position is saved. Use the waveOutRestart function to resume playback from the current position.
        /// </summary>
        /// <param name="hWaveOut">Handle to the waveform-audio output device.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. </returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutPause(IntPtr hWaveOut);

        /// <summary>
        /// The waveOutRestart function resumes playback on a paused waveform-audio output device.
        /// </summary>
        /// <param name="hWaveOut">Handle to the waveform-audio output device.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutRestart(IntPtr hWaveOut);

        /// <summary>
        /// The waveOutGetPosition function retrieves the current playback position of the given waveform-audio output device.
        /// </summary>
        /// <param name="hWaveOut">Handle to the waveform-audio output device.</param>
        /// <param name="lpInfo">Pointer to an MMTIME structure.</param>
        /// <param name="uSize">Size, in bytes, of the MMTIME structure.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutGetPosition(IntPtr hWaveOut, out MMTIME lpInfo, int uSize);

        /// <summary>
        /// This function sets the volume of a waveform output device.
        /// </summary>
        /// <param name="hWaveOut">Handle to an open waveform-audio output device. This parameter can also be a device identifier.</param>
        /// <param name="dwVolume">Specifies a new volume setting. The low-order word contains the left-channel volume setting, and the high-order word contains the right-channel setting. A value of 0xFFFF represents full volume, and a value of 0x0000 is silence.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutSetVolume(IntPtr hWaveOut, uint dwVolume);

        /// <summary>
        /// This function queries the current volume setting of a waveform output device.
        /// </summary>
        /// <param name="hWaveOut">Handle to an open waveform-audio output device. This parameter can also be a device identifier.</param>
        /// <param name="dwVolume">Pointer to a variable to be filled with the current volume setting. The low-order word of this location contains the left-channel volume setting, and the high-order word contains the right-channel setting. A value of 0xFFFF represents full volume, and a value of 0x0000 is silence.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveOutGetVolume(IntPtr hWaveOut, out uint dwVolume);

        /// <summary>
        /// The waveOutGetDevCaps function retrieves the capabilities of a given waveform-audio output device.
        /// </summary>
        /// <param name="deviceID">Identifier of the waveform-audio output device. It can be either a device identifier or a handle of an open waveform-audio output device.</param>
        /// <param name="waveOutCaps">Pointer to a WAVEOUTCAPS structure to be filled with information about the capabilities of the device.</param>
        /// <param name="waveOutCapsSize">Size, in bytes, of the WAVEOUTCAPS structure.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern RESULT waveOutGetDevCaps(IntPtr deviceID, out WAVEOUTCAPS waveOutCaps, int waveOutCapsSize);
        #endregion

        #region wave in
        /// <summary>
        /// The waveInGetNumDevs function returns the number of waveform-audio input devices present in the system.
        /// </summary>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        public static extern int waveInGetNumDevs();

        /// <summary>
        /// The waveInGetDevCaps function retrieves the capabilities of a given waveform-audio input device.
        /// </summary>
        /// <param name="deviceID">Identifier of the waveform-audio output device. It can be either a device identifier or a handle of an open waveform-audio input device.</param>
        /// <param name="waveInCaps">Pointer to a WAVEINCAPS structure to be filled with information about the capabilities of the device.</param>
        /// <param name="waveInCapsSize">Size, in bytes, of the WAVEINCAPS structure.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. </returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern RESULT waveInGetDevCaps(IntPtr deviceID, out WAVEINCAPS waveInCaps, int waveInCapsSize);

        /// <summary>
        /// The waveInAddBuffer function sends an input buffer to the given waveform-audio input device. When the buffer is filled, the application is notified.
        /// </summary>
        /// <param name="hWaveIn">Handle to the waveform-audio input device.</param>
        /// <param name="pwh">Pointer to a WAVEHDR structure that identifies the buffer.</param>
        /// <param name="cbwh">Size, in bytes, of the WAVEHDR structure.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveInAddBuffer(IntPtr hWaveIn, IntPtr pwh, int cbwh);

        /// <summary>
        /// This function closes the specified waveform-audio input device.
        /// </summary>
        /// <param name="hWaveIn">Handle to the waveform-audio input device. If the function succeeds, the handle is no longer valid after this call.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveInClose(IntPtr hWaveIn);

        /// <summary>
        /// The waveInOpen function opens the given waveform-audio input device for recording. 
        /// </summary>
        /// <param name="hWaveIn">Pointer to a buffer that receives a handle identifying the open waveform-audio input device. Use this handle to identify the device when calling other waveform-audio input functions. This parameter can be NULL if WAVE_FORMAT_QUERY is specified for fdwOpen.</param>
        /// <param name="uDeviceID">Identifier of the waveform-audio input device to open. It can be either a device identifier or a handle of an open waveform-audio input device. You can use the following flag instead of a device identifier: WAVE_MAPPER</param>
        /// <param name="lpFormat">Pointer to a WAVEFORMATEX structure that identifies the desired format for recording waveform-audio data. You can free this structure immediately after waveInOpen returns. </param>
        /// <param name="dwCallback">Pointer to a fixed callback function, an event handle, a handle to a window, or the identifier of a thread to be called during waveform-audio recording to process messages related to the progress of recording. If no callback function is required, this value can be zero. For more information on the callback function, see waveInProc. </param>
        /// <param name="dwInstance">User-instance data passed to the callback mechanism. This parameter is not used with the window callback mechanism. </param>
        /// <param name="dwFlags">Flags for opening the device. </param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveInOpen(out IntPtr hWaveIn, IntPtr uDeviceID, ref WAVEFORMATEX lpFormat, WaveInProc dwCallback, IntPtr dwInstance, OPEN_FLAGS dwFlags);

        /// <summary>
        /// This function prepares a buffer for waveform input. This function allows both the audio driver and the operating system (OS) to do time consuming processing of the header and/or buffer once at initialization. The application can use the buffer repeatedly without additional processing by the driver or the OS.
        /// </summary>
        /// <param name="hWaveIn">Handle to the waveform-audio input device.</param>
        /// <param name="lpWaveInHdr">Pointer to a WAVEHDR structure that identifies the buffer to be prepared. The buffer's base address must be aligned with the respect to the sample size.</param>
        /// <param name="uSize">Size, in bytes, of the WAVEHDR structure.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveInPrepareHeader(IntPtr hWaveIn, ref IntPtr lpWaveInHdr, int uSize);

        /// <summary>
        /// This function cleans up the preparation performed by waveInPrepareHeader. The function must be called after the device driver fills a data buffer and returns it to the application. You must call this function before freeing the data buffer.
        /// </summary>
        /// <param name="hWaveIn">Handle to the waveform-audio input device.</param>
        /// <param name="lpWaveInHdr">Pointer to a WAVEHDR structure identifying the buffer to be cleaned up.</param>
        /// <param name="uSize">Size, in bytes, of the WAVEHDR structure.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise.</returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveInUnprepareHeader(IntPtr hWaveIn, ref IntPtr lpWaveInHdr, int uSize);

        /// <summary>
        /// The waveInReset function stops input on the given waveform-audio input device and resets the current position to zero. All pending buffers are marked as done and returned to the application.
        /// </summary>
        /// <param name="hWaveIn">Handle to the waveform-audio input device.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. </returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveInReset(IntPtr hWaveIn);

        /// <summary>
        /// This function starts input on the specified waveform input device.
        /// </summary>
        /// <param name="hWaveIn">Handle to the waveform-audio input device.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. </returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveInStart(IntPtr hWaveIn);

        /// <summary>
        /// The waveInStop function stops waveform-audio input.
        /// </summary>
        /// <param name="hWaveIn">Handle to the waveform-audio input device.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. </returns>
        [DllImport("winmm.dll")]
        public static extern RESULT waveInStop(IntPtr hWaveIn);
        #endregion

        /// <summary>
        /// Reads a WAVEHDR structure from the given address without destroying the pointer
        /// </summary>
        /// <param name="intPtr"></param>
        /// <returns></returns>
        public static WAVEHDR ReadWAVEHDR(IntPtr intPtr) => (WAVEHDR)Marshal.PtrToStructure(intPtr, typeof(WAVEHDR));

        /// <summary>
        /// Writes a WAVEHDR structure to the given pointer without destroying the pointer or structure
        /// </summary>
        /// <param name="intPtr"></param>
        /// <param name="wAVEHDR"></param>
        public static void WriteWAVEHDR(IntPtr intPtr, WAVEHDR wAVEHDR) => Marshal.StructureToPtr(wAVEHDR, intPtr, true);

        /// <summary>
        /// Allocates a pointer for a WAVEHDR structure
        /// </summary>
        /// <param name="wAVEHDR"></param>
        /// <returns></returns>
        public static IntPtr AllocWAVEHDR(WAVEHDR wAVEHDR)
        {
            var result = Marshal.AllocHGlobal(Marshal.SizeOf(wAVEHDR));
            Marshal.StructureToPtr(wAVEHDR, result, true);
            return result;
        }

        /// <summary>Checks for an error.</summary>
        /// <param name="result">The result.</param>
        /// <exception cref="MMSystemException"></exception>
        public static void CheckError(RESULT result)
        {
            if (result == RESULT.NoError) return;
            throw new MMSystemException(result);
        }
    }
}
