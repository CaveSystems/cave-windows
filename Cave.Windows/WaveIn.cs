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
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Provides access to the WaveIn functions of the WINMM api 
    /// </summary>
    public class WaveIn : AudioDevice
    {
        #region static implementation
        static string GetName(int devNumber)
        {
            WAVEINCAPS caps = new WAVEINCAPS();
            WINMM.waveInGetDevCaps(new IntPtr(devNumber), out caps, Marshal.SizeOf(caps));
            return caps.productName;
        }

        static AudioDeviceCapabilities GetCapabilities(int devNumber)
        {
            List<AudioConfiguration> configs = new List<AudioConfiguration>();
            WAVEINCAPS caps = new WAVEINCAPS();
            WINMM.waveInGetDevCaps(new IntPtr(devNumber), out caps, Marshal.SizeOf(caps));

            foreach (WAVE_FORMAT l_Format in Enum.GetValues(typeof(WAVE_FORMAT)))
            {
                if ((caps.dwFormats & l_Format) == 0) continue;
                switch (l_Format)
                {
                    case WAVE_FORMAT.Pcm11KhzMono16Bit: configs.Add(new AudioConfiguration(11025, AudioSampleFormat.Int16, AudioChannelSetup.Mono)); break;
                    case WAVE_FORMAT.Pcm22KhzMono16Bit: configs.Add(new AudioConfiguration(22050, AudioSampleFormat.Int16, AudioChannelSetup.Mono)); break;
                    case WAVE_FORMAT.Pcm44KhzMono16Bit: configs.Add(new AudioConfiguration(44100, AudioSampleFormat.Int16, AudioChannelSetup.Mono)); break;
                    case WAVE_FORMAT.Pcm48KhzMono16Bit: configs.Add(new AudioConfiguration(48000, AudioSampleFormat.Int16, AudioChannelSetup.Mono)); break;
                    case WAVE_FORMAT.Pcm96KhzMono16Bit: configs.Add(new AudioConfiguration(96000, AudioSampleFormat.Int16, AudioChannelSetup.Mono)); break;

                    case WAVE_FORMAT.Pcm11KhzStereo16Bit: configs.Add(new AudioConfiguration(11025, AudioSampleFormat.Int16, AudioChannelSetup.Stereo)); break;
                    case WAVE_FORMAT.Pcm22KhzStereo16Bit: configs.Add(new AudioConfiguration(22050, AudioSampleFormat.Int16, AudioChannelSetup.Stereo)); break;
                    case WAVE_FORMAT.Pcm44KhzStereo16Bit: configs.Add(new AudioConfiguration(44100, AudioSampleFormat.Int16, AudioChannelSetup.Stereo)); break;
                    case WAVE_FORMAT.Pcm48KhzStereo16Bit: configs.Add(new AudioConfiguration(48000, AudioSampleFormat.Int16, AudioChannelSetup.Stereo)); break;
                    case WAVE_FORMAT.Pcm96KhzStereo16Bit: configs.Add(new AudioConfiguration(96000, AudioSampleFormat.Int16, AudioChannelSetup.Stereo)); break;

                    default:/*not implemented*/ break;
                }
            }
            return new AudioDeviceCapabilities(AudioDeviceType.Output, configs.ToArray());
        }
        #endregion

        /// <summary>Creates an instance using the specified devicenumber</summary>
        /// <param name="api">The API.</param>
        /// <param name="devNumber">The dev number.</param>
        public WaveIn(IAudioAPI api, int devNumber)
            : base(api, GetName(devNumber), GetCapabilities(devNumber))
        {
        }

        /// <summary>
        /// Obtains whether the device supports playback or not
        /// </summary>
        public override bool SupportsPlayback
        {
            get { return false; }
        }

        /// <summary>
        /// Obtains whether the device supports recording or not
        /// </summary>
        public override bool SupportsRecording
        {
            get { return true; }
        }

        /// <summary>
        /// This function is not supported!
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public override AudioOut CreateAudioOut(IAudioConfiguration configuration)
        {
            throw new NotSupportedException();
        }

        /// <summary>Disposes all unmanged resources.</summary>
        public override void Dispose() { }
    }
}
