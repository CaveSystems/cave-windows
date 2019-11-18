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
