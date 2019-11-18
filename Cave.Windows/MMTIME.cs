#region CopyRight 2018
/*
    Copyright (c) 2003-2018 Andreas Rohleder (andreas@rohleder.cc)
    All rights reserved
*/
#endregion
#region License MSPL
/*
    This file contains some sourcecode that uses Microsoft Windows API calls
    to provide functionality that is part of the underlying operating system.
    The API calls and their documentation are copyrighted work of Microsoft
    and/or its suppliers. Use of the Software is governed by the terms of the
    MICROSOFT LIMITED PUBLIC LICENSE.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE.MSPL file
    found at the installation directory or the distribution package.
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
   Information source:
     Microsoft Corporation

   Implementation:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:
 */
#endregion

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
