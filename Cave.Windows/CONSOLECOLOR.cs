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
    /// Provides windows console colors
    /// </summary>
    [Flags]
    public enum CONSOLECOLOR : byte
    {
        /// <summary>
        /// Foreground bits
        /// </summary>
        FOREGROUND = 0xF,

        /// <summary>
        /// Background bits
        /// </summary>
        BACKGROUND = 0xF0,

        /// <summary>
        /// Blue foreground
        /// </summary>
        FOREGROUND_BLUE = 1,

        /// <summary>
        /// Green foreground
        /// </summary>
        FOREGROUND_GREEN = 2,

        /// <summary>
        /// Red foreground
        /// </summary>
        FOREGROUND_RED = 4,

        /// <summary>
        /// Cyan foreground
        /// </summary>
        FOREGROUND_CYAN = FOREGROUND_GREEN + FOREGROUND_BLUE,

        /// <summary>
        /// Magenta foreground
        /// </summary>
        FOREGROUND_MAGENTA = FOREGROUND_BLUE + FOREGROUND_RED,

        /// <summary>
        /// Yellow foreground
        /// </summary>
        FOREGROUND_YELLOW = FOREGROUND_GREEN + FOREGROUND_RED,

        /// <summary>
        /// White foreground
        /// </summary>
        FOREGROUND_WHITE =  FOREGROUND_BLUE + FOREGROUND_GREEN + FOREGROUND_RED,

        /// <summary>
        /// Intense (lighter) foreground
        /// </summary>
        FOREGROUND_INTENSITY = 8,

        /// <summary>
        /// blue background
        /// </summary>
        BACKGROUND_BLUE = FOREGROUND_BLUE << 4,

        /// <summary>
        /// green background
        /// </summary>
        BACKGROUND_GREEN = FOREGROUND_GREEN << 4,

        /// <summary>
        /// red background
        /// </summary>
        BACKGROUND_RED = FOREGROUND_RED << 4,

        /// <summary>
        /// cyan background
        /// </summary>
        BACKGROUND_CYAN = FOREGROUND_CYAN << 4,

        /// <summary>
        /// magenta background
        /// </summary>
        BACKGROUND_MAGENTA = FOREGROUND_MAGENTA << 4,

        /// <summary>
        /// yellow background
        /// </summary>
        BACKGROUND_YELLOW = FOREGROUND_YELLOW << 4,

        /// <summary>
        /// white background
        /// </summary>
        BACKGROUND_WHITE = FOREGROUND_WHITE << 4,

        /// <summary>
        /// Intense (lighter) background
        /// </summary>
        BACKGROUND_INTENSITY = FOREGROUND_INTENSITY << 4,
    }
}
