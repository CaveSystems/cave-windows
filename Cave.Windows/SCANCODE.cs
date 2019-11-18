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

//do not warn for missing comments in this class
#pragma warning disable 1591

namespace Cave.Windows
{
    /// <summary>
    /// Provides keyboard scancodes
    /// </summary>
    public class SCANCODE
    {
        /// <summary>
        /// Scancodes for german extended 102 keyboard
        /// </summary>
        public enum GERMAN_102 : int
        {
            ESCAPE = 0x01,
            NUMBER1 = 0x02,
            NUMBER2 = 0x03,
            NUMBER3 = 0x04,
            NUMBER4 = 0x05,
            NUMBER5 = 0x06,
            NUMBER6 = 0x07,
            NUMBER7 = 0x08,
            NUMBER8 = 0x09,
            NUMBER9 = 0x0A,
            NUMBER0 = 0x0B,
            QUESTIONMARK = 0x0C,
            APOSTROPHE = 0x0D,
            BACKSPACE = 0x0E,
            TAB = 0x0F,
            Q = 0x10,
            W = 0x11,
            E = 0x12,
            R=0x13,
            T = 0x14,
            Z = 0x15,
            U = 0x16,
            I = 0x17,
            O = 0x18,
            P = 0x19,
            HASH = 0x01A,
            PLUS = 0x01B,
            ENTER=0x1C,
            NUM_ENTER = 0x11C,
            STRG_LEFT = 0x1D,
            STRG_RIGHT = 0x11D,
            A=0x1E,
            S=0x1F,
            D=0x20,
            MUTE = 0x120,
            F=0x21,
            G=0x22,
            MM_PLAYPAUSE = 0x122,
            H=0x23,
            J=0x24,
            MM_STOP = 0x124,
            K=0x25,
            L = 0x26,
            UMLAUT_O=0x27,
            UMLAUT_A = 0x28,
            SHIFT_LEFT=0x2A,
            GREATER_SMALLER=0x2B,
            Y = 0x2C,
            X = 0x2D,
            C = 0x2E,
            MM_QUIETER = 0x12E,
            V = 0x2F,
            B = 0x30,
            MM_LOUDER = 0x130,
            N = 0x31,
            M = 0x32,
            START_WWW = 0x132,
            COMMA = 0x33,
            POINT = 0x34,
            DASH = 0x35,
            NUM_SLASH = 0x135,
            SHIFT_RIGHT = 0x36,
            NUM_MULTIPLY = 0x37,
            PRINT = 0x137,
            ALT_LEFT=0x38,
            ALT_RIGHT = 0x138,
            SPACE = 0x39,
            CAPS =0x3A,
            F1=0x3B,
            F2=0x3C,
            F3=0x3D,
            F4=0x3E,
            F5=0x3F,
            F6=0x40,
            F7 = 0x41,
            F8 = 0x42,
            F9 = 0x43,
            F10 = 0x44,
            NUM_LOCK=0x45,
            SCROLL_LOCK=0x46,
            CTRbREAK = 0x146,
            NUM_7 = 0x47,
            HOME = 0x147,
            NUM_8 = 0x48,
            UP = 0x148,
            NUM_9 = 0x49,
            PAGEUP = 0x149,
            NUM_MINUS = 0x4A,
            NUM_4 = 0x4B,
            LEFT = 0x14B,
            NUM_5=0x4C,
            NUM_6 = 0x4D,
            RIGHT = 0x14D,
            NUM_PLUS = 0x4E,
            NUM_1 = 0x4F,
            END = 0x14F,
            NUM_2 = 0x50,
            DOWN = 0x150,
            NUM_3 = 0x51,
            PAGEDOWN = 0x151,
            NUM_0 = 0x52,
            INSERT = 0x152,
            NUM_DELETE = 0x53,
            DELETE = 0x153,
            F11 = 0x57,
            F12 = 0x58,
            WINDOWS_LEFT = 0x15B,
            WINDOWS_RIGHT = 0x15C,
            WINDOWS_CONTEXT = 0x15D,
            POWER = 0x15E,
            SLEEP = 0x15F,
        }
    }
}

#pragma warning restore 1591

