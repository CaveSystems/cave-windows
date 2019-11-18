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

namespace Cave.Windows
{
    /// <summary>
    /// Virtual Key Codes
    /// </summary>
    public enum VK : int
    {
        /// <summary>
        /// Left mouse button
        /// </summary>
        LBUTTON = 0x01,
        /// <summary>
        /// Right mouse button
        /// </summary>
        RBUTTON = 0x02,
        /// <summary>
        /// Control-break processing
        /// </summary>
        CANCEL = 0x03,
        /// <summary>
        /// Middle mouse button (three-button mouse)
        /// </summary>
        MBUTTON = 0x04,
        /// <summary>
        /// BACKSPACE key
        /// </summary>
        BACK = 0x08,
        /// <summary>
        /// TAB key
        /// </summary>
        TAB = 0x09,
        /// <summary>
        /// CLEAR key
        /// </summary>
        CLEAR = 0x0C,
        /// <summary>
        /// ENTER key
        /// </summary>
        RETURN = 0x0D,
        /// <summary>
        /// SHIFT key
        /// </summary>
        SHIFT = 0x10,
        /// <summary>
        /// CTRL key
        /// </summary>
        CONTROL = 0x11,
        /// <summary>
        /// ALT key
        /// </summary>
        MENU = 0x12,
        /// <summary>
        /// PAUSE key
        /// </summary>
        PAUSE = 0x13,
        /// <summary>
        /// CAPS LOCK key
        /// </summary>
        CAPITAL = 0x14,
        /// <summary>
        /// ESC key
        /// </summary>
        ESCAPE = 0x1B,
        /// <summary>
        /// SPACEBAR
        /// </summary>
        SPACE = 0x20,
        /// <summary>
        /// PAGE UP key
        /// </summary>
        PRIOR = 0x21,
        /// <summary>
        /// PAGE UP key
        /// </summary>
        PAGEUP = PRIOR,
        /// <summary>
        /// PAGE DOWN key
        /// </summary>
        NEXT = 0x22,
        /// <summary>
        /// PAGE DOWN key
        /// </summary>
        PAGEDOWN = NEXT,
        /// <summary>
        /// END key
        /// </summary>
        END = 0x23,
        /// <summary>
        /// HOME key
        /// </summary>
        HOME = 0x24,
        /// <summary>
        /// LEFT ARROW key
        /// </summary>
        LEFT = 0x25,
        /// <summary>
        /// UP ARROW key
        /// </summary>
        UP = 0x26,
        /// <summary>
        /// RIGHT ARROW key
        /// </summary>
        RIGHT = 0x27,
        /// <summary>
        /// DOWN ARROW key
        /// </summary>
        DOWN = 0x28,
        /// <summary>
        /// SELECT key
        /// </summary>
        SELECT = 0x29,
        /// <summary>
        /// PRINT key
        /// </summary>
        PRINT = 0x2A,
        /// <summary>
        /// EXECUTE key
        /// </summary>
        EXECUTE = 0x2B,
        /// <summary>
        /// PRINT SCREEN key
        /// </summary>
        SNAPSHOT = 0x2C,
        /// <summary>
        /// INS key
        /// </summary>
        INSERT = 0x2D,
        /// <summary>
        /// DEL key
        /// </summary>
        DELETE = 0x2E,
        /// <summary>
        /// HELP key
        /// </summary>
        HELP = 0x2F,
        /// <summary>
        /// 0 key
        /// </summary>
        NUMBER0 = 0x30,
        /// <summary>
        /// 1 key
        /// </summary>
        NUMBER1 = 0x31,
        /// <summary>
        /// 2 key
        /// </summary>
        NUMBER2 = 0x32,
        /// <summary>
        /// 3 key
        /// </summary>
        NUMBER3 = 0x33,
        /// <summary>
        /// 4 key
        /// </summary>
        NUMBER4 = 0x34,
        /// <summary>
        /// 5 key
        /// </summary>
        NUMBER5 = 0x35,
        /// <summary>
        /// 6 key
        /// </summary>
        NUMBER6 = 0x36,
        /// <summary>
        /// 7 key
        /// </summary>
        NUMBER7 = 0x37,
        /// <summary>
        /// 8 key
        /// </summary>
        NUMBER8 = 0x38,
        /// <summary>
        /// 9 key
        /// </summary>
        NUMBER9 = 0x39,
        /// <summary>
        /// A key
        /// </summary>
        A = 0x41,
        /// <summary>
        /// B key
        /// </summary>
        B = 0x42,
        /// <summary>
        /// C key
        /// </summary>
        C = 0x43,
        /// <summary>
        /// D key
        /// </summary>
        D = 0x44,
        /// <summary>
        /// E key
        /// </summary>
        E = 0x45,
        /// <summary>
        /// F key
        /// </summary>
        F = 0x46,
        /// <summary>
        /// G key
        /// </summary>
        G = 0x47,
        /// <summary>
        /// H key
        /// </summary>
        H = 0x48,
        /// <summary>
        /// I key
        /// </summary>
        I = 0x49,
        /// <summary>
        /// J key
        /// </summary>
        J = 0x4A,
        /// <summary>
        /// K key
        /// </summary>
        K = 0x4B,
        /// <summary>
        /// L key
        /// </summary>
        L = 0x4C,
        /// <summary>
        /// M key
        /// </summary>
        M = 0x4D,
        /// <summary>
        /// N key
        /// </summary>
        N = 0x4E,
        /// <summary>
        /// O key
        /// </summary>
        O = 0x4F,
        /// <summary>
        /// P key
        /// </summary>
        P = 0x50,
        /// <summary>
        /// Q key
        /// </summary>
        Q = 0x51,
        /// <summary>
        /// R key
        /// </summary>
        R = 0x52,
        /// <summary>
        /// S key
        /// </summary>
        S = 0x53,
        /// <summary>
        /// T key
        /// </summary>
        T = 0x54,
        /// <summary>
        /// U key
        /// </summary>
        U = 0x55,
        /// <summary>
        /// V key
        /// </summary>
        V = 0x56,
        /// <summary>
        /// W key
        /// </summary>
        W = 0x57,
        /// <summary>
        /// X key
        /// </summary>
        X = 0x58,
        /// <summary>
        /// Y key
        /// </summary>
        Y = 0x59,
        /// <summary>
        /// Z key
        /// </summary>
        Z = 0x5A,
        /// <summary>
        /// Numeric keypad 0 key
        /// </summary>
        NUMPAD0 = 0x60,
        /// <summary>
        /// Numeric keypad 1 key
        /// </summary>
        NUMPAD1 = 0x61,
        /// <summary>
        /// Numeric keypad 2 key
        /// </summary>
        NUMPAD2 = 0x62,
        /// <summary>
        /// Numeric keypad 3 key
        /// </summary>
        NUMPAD3 = 0x63,
        /// <summary>
        /// Numeric keypad 4 key
        /// </summary>
        NUMPAD4 = 0x64,
        /// <summary>
        /// Numeric keypad 5 key
        /// </summary>
        NUMPAD5 = 0x65,
        /// <summary>
        /// Numeric keypad 6 key
        /// </summary>
        NUMPAD6 = 0x66,
        /// <summary>
        /// Numeric keypad 7 key
        /// </summary>
        NUMPAD7 = 0x67,
        /// <summary>
        /// Numeric keypad 8 key
        /// </summary>
        NUMPAD8 = 0x68,
        /// <summary>
        /// Numeric keypad 9 key
        /// </summary>
        NUMPAD9 = 0x69,
        /// <summary>
        /// Separator key
        /// </summary>
        SEPARATOR = 0x6C,
        /// <summary>
        /// Subtract key
        /// </summary>
        SUBTRACT = 0x6D,
        /// <summary>
        /// Decimal key
        /// </summary>
        DECIMAL = 0x6E,
        /// <summary>
        /// Divide key
        /// </summary>
        DIVIDE = 0x6F,
        /// <summary>
        /// F1 key
        /// </summary>
        F1 = 0x70,
        /// <summary>
        /// F2 key
        /// </summary>
        F2 = 0x71,
        /// <summary>
        /// F3 key
        /// </summary>
        F3 = 0x72,
        /// <summary>
        /// F4 key
        /// </summary>
        F4 = 0x73,
        /// <summary>
        /// F5 key
        /// </summary>
        F5 = 0x74,
        /// <summary>
        /// F6 key
        /// </summary>
        F6 = 0x75,
        /// <summary>
        /// F7 key
        /// </summary>
        F7 = 0x76,
        /// <summary>
        /// F8 key
        /// </summary>
        F8 = 0x77,
        /// <summary>
        /// F9 key
        /// </summary>
        F9 = 0x78,
        /// <summary>
        /// F10 key
        /// </summary>
        F10 = 0x79,
        /// <summary>
        /// F11 key
        /// </summary>
        F11 = 0x7A,
        /// <summary>
        /// F12 key
        /// </summary>
        F12 = 0x7B,
        /// <summary>
        /// F13 key
        /// </summary>
        F13 = 0x7C,
        /// <summary>
        /// F14 key
        /// </summary>
        F14 = 0x7D,
        /// <summary>
        /// F15 key
        /// </summary>
        F15 = 0x7E,
        /// <summary>
        /// F16 key
        /// </summary>
        F16 = 0x7F,
        /// <summary>
        /// F17 key
        /// </summary>
        F17 = 0x80,
        /// <summary>
        /// F18 key
        /// </summary>
        F18 = 0x81,
        /// <summary>
        /// F19 key
        /// </summary>
        F19 = 0x82,
        /// <summary>
        /// F20 key
        /// </summary>
        F20 = 0x83,
        /// <summary>
        /// F21 key
        /// </summary>
        F21 = 0x84,
        /// <summary>
        /// F22 key
        /// </summary>
        F22 = 0x85,
        /// <summary>
        /// F23 key
        /// </summary>
        F23 = 0x86,
        /// <summary>
        /// F24 key
        /// </summary>
        F24 = 0x87,
        /// <summary>
        /// NUM LOCK key
        /// </summary>
        NUMLOCK = 0x90,
        /// <summary>
        /// SCROLL LOCK key
        /// </summary>
        SCROLL = 0x91,
        /// <summary>
        /// Left SHIFT key
        /// </summary>
        LSHIFT = 0xA0,
        /// <summary>
        /// Right SHIFT key
        /// </summary>
        RSHIFT = 0xA1,
        /// <summary>
        /// Left CONTROL key
        /// </summary>
        LCONTROL = 0xA2,
        /// <summary>
        /// Right CONTROL key
        /// </summary>
        RCONTROL = 0xA3,
        /// <summary>
        /// Left MENU key
        /// </summary>
        LMENU = 0xA4,
        /// <summary>
        /// Right MENU key
        /// </summary>
        RMENU = 0xA5,
        /// <summary>
        /// Play key
        /// </summary>
        PLAY = 0xFA,
        /// <summary>
        /// Zoom key
        /// </summary>
        ZOOM = 0xFB,
    }
}
