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

namespace Cave.Windows
{
    /// <summary>
    /// Provides access to the WaveMapper WINMM api using the <see cref="WaveOut"/> and <see cref="WaveIn"/> classes
    /// </summary>
    public class WaveMapper : AudioAPI
    {
        internal static WAVEFORMATEX GetFormat(IAudioConfiguration config)
        {
            WAVEFORMATEX format = new WAVEFORMATEX();
            format.SamplesPerSec = config.SamplingRate;
            format.BitsPerSample = (short)(config.BytesPerSample * 8);
            format.Channels = (short)config.Channels;
            format.Size = 0;
            switch (config.Format)
            {
                case AudioSampleFormat.Int16:
                case AudioSampleFormat.Int32:
                    format.FormatTag = WAVEFORMATTAG.PCM;
                    break;
                case AudioSampleFormat.Float:
                case AudioSampleFormat.Double:
                    format.FormatTag = WAVEFORMATTAG.IEEE_FLOAT;
                    break;
                default: throw new NotSupportedException(string.Format("AudioConfiguration {0} not supported!", config.Format));
            }
            format.BlockAlign = (short)((format.BitsPerSample / 8) * format.Channels);
            format.AvgBytesPerSec = format.BlockAlign * format.SamplesPerSec;
            return format;
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public WaveMapper() { }

        /// <summary>Gets the preference value.</summary>
        /// <value>Constant value = 0.</value>
        /// <remarks>Small values represent a higher priority</remarks>
        public override int Preference { get { return 0; } }

        /// <summary>
        /// Checks whether at least one input or output device is available or not.
        /// </summary>
        public override bool IsAvailable
        {
            get
            {
                try { return WINMM.waveOutGetNumDevs() + WINMM.waveInGetNumDevs() > 0; }
                catch { }
                return false;
            }
        }

        /// <summary>
        /// Obtains the output devices
        /// </summary>
        public override IAudioDevice[] OutputDevices
        {
            get
            {
                List<AudioDevice> result = new List<AudioDevice>();
                for (int i = 0; i < WINMM.waveOutGetNumDevs(); i++)
                {
                    result.Add(new WaveOut(this, i));
                }
                return result.ToArray();
            }
        }

        /// <summary>
        /// Obtains the input devices
        /// </summary>
        public override IAudioDevice[] InputDevices
        {
            get
            {
                List<AudioDevice> result = new List<AudioDevice>();
                for (int i = 0; i < WINMM.waveInGetNumDevs(); i++)
                {
                    result.Add(new WaveIn(this, i));
                }
                return result.ToArray();
            }
        }
    }
}
