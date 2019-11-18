#region CopyRight 2018
/*
    Copyright (c) 2003-2018 Andreas Rohleder (andreas@rohleder.cc)
    All rights reserved
*/
#endregion
#region License LGPL-3
/*
    This program/library/sourcecode is free software; you can redistribute it
    and/or modify it under the terms of the GNU Lesser General Public License
    version 3 as published by the Free Software Foundation subsequent called
    the License.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE file
    found at the installation directory or the distribution package.

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the
    "Software"), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be included
    in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion License
#region Authors & Contributors
/*
   Author:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:
 */
#endregion Authors & Contributors

using Cave.Media;
using Cave.Media.Audio;
using Cave.Media.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Cave.Windows
{
    class WaveAudioOut : AudioOut
    {
        #region private implementation
        IntPtr m_Device;
        WAVEFORMATEX m_Format;
        int m_DeviceNumber;
        Thread m_Thread;
        long m_BytesQueued;
        Queue<IAudioData> m_Queue = new Queue<IAudioData>();
        uint m_BytesPassedLo;
        uint m_BytesPassedHi;
		long m_BufferUnderflowCount;

		bool m_Dequeue(IntPtr hdr, WHDR flags)
        {
            //dequeue old buffers
            WAVEHDR header = WINMM.ReadWAVEHDR(hdr);
            if ((header.dwFlags & flags) == flags)
            {
                WINMM.RESULT result = WINMM.waveOutUnprepareHeader(m_Device, hdr, Marshal.SizeOf(header));
                switch (result)
                {
                    case WINMM.RESULT.WaveStillPlaying: return false;
                    case WINMM.RESULT.NoError: return true;
                    default: WINMM.CheckError(result); break;
                }
                throw new Exception(result.ToString());
            }
            return false;
        }

        void m_Worker()
        {
            Queue<IntPtr> bufferHeaders = new Queue<IntPtr>();
            int bytesBuffered=0;
            int bytesPerSecond = Configuration.BytesPerTick * Configuration.SamplingRate;
            while (State < AudioDeviceState.Closed)
            {
                Thread.Sleep(1);
                lock (this)
                {
                    //dequeue old buffers
                    while ((bufferHeaders.Count > 0) && (m_Dequeue(bufferHeaders.Peek(), WHDR.DONE)))
                    {
                        IntPtr ptr = bufferHeaders.Dequeue();
                        WAVEHDR header = WINMM.ReadWAVEHDR(ptr);
                        Marshal.FreeHGlobal(header.lpData);
                        Marshal.FreeHGlobal(ptr);
                        bytesBuffered -= header.dwBufferLength;
                    }
                    if (m_Queue.Count == 0) Monitor.Wait(this, 1000);
                }
                while (bytesBuffered < bytesPerSecond / 10)
                {
                    if (m_Queue.Count == 0) break;
                    IAudioData audioData = m_Queue.Dequeue();
                    if (Volume != 1) audioData = audioData.ChangeVolume(Volume);
                    WAVEHDR header = new WAVEHDR();
                    header.dwBufferLength = audioData.Length;
                    header.lpData = Marshal.AllocHGlobal(header.dwBufferLength);
                    Marshal.Copy(audioData.Data, 0, header.lpData, audioData.Length);
                    IntPtr ptrHeader = WINMM.AllocWAVEHDR(header);
                    WINMM.CheckError(WINMM.waveOutPrepareHeader(m_Device, ptrHeader, Marshal.SizeOf(header)));
                    WINMM.CheckError(WINMM.waveOutWrite(m_Device, ptrHeader, Marshal.SizeOf(header)));
                    bufferHeaders.Enqueue(ptrHeader);
					if (bytesBuffered == 0) m_BufferUnderflowCount++;
					bytesBuffered += header.dwBufferLength;
                }
            }
            //clean up
            for (int i = 0; i < 10; i++)
            {
                WINMM.waveOutReset(m_Device);
                lock (this)
                {
                    while ((bufferHeaders.Count > 0) && (m_Dequeue(bufferHeaders.Peek(), WHDR.NONE)))
                    {
                        IntPtr ptr = bufferHeaders.Dequeue();
                        WAVEHDR header = WINMM.ReadWAVEHDR(ptr);
                        Marshal.FreeHGlobal(header.lpData);
                        Marshal.FreeHGlobal(ptr);
                    }
                }
                if (WINMM.waveOutClose(m_Device) == WINMM.RESULT.NoError) break;
                Thread.Sleep(100);
            }
        }
        #endregion

        #region constructor
        /// <summary>Initializes a new instance of the <see cref="WaveAudioOut"/> class.</summary>
        /// <param name="waveOut">The wave out.</param>
        /// <param name="configuration">The configuration.</param>
        internal WaveAudioOut(WaveOut waveOut, IAudioConfiguration configuration)
            : base(waveOut, configuration)
        {
            m_DeviceNumber = waveOut.DeviceNumber;
            m_Format = WaveMapper.GetFormat(configuration);
            WINMM.CheckError(WINMM.waveOutOpen(out m_Device, new IntPtr(m_DeviceNumber), ref m_Format, null, IntPtr.Zero, WINMM.OPEN_FLAGS.CALLBACK_NULL));
            WINMM.CheckError(WINMM.waveOutPause(m_Device));
            m_Thread = new Thread(m_Worker);
            m_Thread.Start();
        }
        #endregion

        #region protected overrides

        protected override void StartPlayback()
        {
            WINMM.CheckError(WINMM.waveOutRestart(m_Device));
        }

        protected override void StopPlayback()
        {
            WINMM.CheckError(WINMM.waveOutPause(m_Device));
        }

        protected override void Dispose(bool disposing)
        {
        }
		#endregion

		#region public overrides

		/// <summary>Gets the buffer underflow count.</summary>
		/// <value>The buffer underflow count.</value>
		public override long BufferUnderflowCount => m_BufferUnderflowCount;

		/// <summary>Obtains whether the IAudioQueue supports 3D positioning or not</summary>
		public override bool Supports3D { get { return false; } }

        /// <summary>Obtains the latency of the queue</summary>
        public override TimeSpan Latency { get { return new TimeSpan(TimeSpan.TicksPerSecond / Configuration.SamplingRate); } }

        /// <summary>Obtains the number of bytes passed since starting this queue</summary>
        /// <exception cref="Exception"></exception>
        public override long BytesPassed
        {
            get
            {
                MMTIME time = new MMTIME();
                lock (this)
                {
                    WINMM.CheckError(WINMM.waveOutGetPosition(m_Device, out time, Marshal.SizeOf(time)));
                    if (time.cb < m_BytesPassedLo)
                    {
                        m_BytesPassedHi++;
                    }
                    m_BytesPassedLo = time.cb;
                    if (time.wType != MMTIME_FORMAT.BYTES) throw new Exception();
                    return m_BytesPassedHi * 0x100000000 + m_BytesPassedLo;
                }
            }
        }

        /// <summary>Obtains the bytes buffered (bytes to play until queue gets empty)</summary>
        public override long BytesBuffered
        {
            get
            {
                lock (this) return m_BytesQueued - BytesPassed;
            }
        }

        /// <summary>Gets or sets the volume.</summary>
        /// <value>The volume in range 0..x.</value>
        public override float Volume { get; set; }

        #pragma warning disable 0809

        /// <summary>Gets or sets the pitch.</summary>
        /// <value>The pitch.</value>
        [Obsolete("NOT SUPPORTED")]
        public override float Pitch { get; set; }

        /// <summary>sets / gets the 3d position of the sound source</summary>
        [Obsolete("NOT SUPPORTED")]
        public override Vector3 Position3D { get; set; }

        #pragma warning restore 0809

        /// <summary>Writes a buffer to the device.</summary>
        /// <param name="audioData">The buffer.</param>
        public override void Write(IAudioData audioData)
        {
            //write buffered data to the device
            lock (this)
            {
                m_Queue.Enqueue(audioData);
                m_BytesQueued += audioData.Length;
                Monitor.Pulse(this);
            }
        }

        /// <summary>Closes the stream and releases both managed and unmanaged resources</summary>
        public override void Close()
        {
            base.Close();
            m_Thread?.Join(1000);
        }

        #endregion
    }
}
