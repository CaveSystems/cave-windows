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
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// interface to windows api gdi32.dll
    /// </summary>
    public static class GDI32
    {
        /// <summary>
        /// This enum lists the binary raster-operation codes used by the GetROP2 and SetROP2 functions. Raster-operation codes define how GDI combines the bits from the selected pen with the bits in the destination bitmap.
        /// All Boolean operations are presented in reverse Polish notation
        /// </summary>
        public enum BinaryRasterOperations
        {
            /// <summary>
            /// Bitwise OR
            /// </summary>
            R2_BLACK = 1,

            /// <summary>
            /// Target bitmap, Selected pen, Bitwise OR, Bitwise NOT (inverse),
            /// </summary>
            R2_NOTMERGEPEN = 2,

            /// <summary>
            /// Target bitmap, Selected pen, Bitwise NOT (inverse), Bitwise AND
            /// </summary>
            R2_MASKNOTPEN = 3,

            /// <summary>
            /// Selected pen, Bitwise NOT (inverse),
            /// </summary>
            R2_NOTCOPYPEN = 4,

            /// <summary>
            /// Selected pen, Target bitmap, Bitwise NOT (inverse), Bitwise AND,
            /// </summary>
            R2_MASKPENNOT = 5,

            /// <summary>
            /// Target bitmap, Bitwise NOT (inverse),
            /// </summary>
            R2_NOT = 6,

            /// <summary>
            /// Target bitmap, Selected pen, Bitwise exclusive OR (XOR), Bitwise NOT (inverse),
            /// </summary>
            R2_XORPEN = 7,

            /// <summary>
            /// Target bitmap, Selected pen, Bitwise AND, Bitwise NOT (inverse),
            /// </summary>
            R2_NOTMASKPEN = 8,

            /// <summary>
            /// Target bitmap, Selected pen, Bitwise AND,
            /// </summary>
            R2_MASKPEN = 9,

            /// <summary>
            /// Target bitmap, Selected pen, Bitwise exclusive OR (XOR),
            /// </summary>
            R2_NOTXORPEN = 10,

            /// <summary>
            /// Target bitmap,
            /// </summary>
            R2_NOP = 11,

            /// <summary>
            /// Target bitmap, Selected pen, Bitwise NOT (inverse), Bitwise OR,
            /// </summary>
            R2_MERGENOTPEN = 12,

            /// <summary>
            /// Selected pen
            /// </summary>
            R2_COPYPEN = 13,

            /// <summary>
            /// PTarget bitmap, Bitwise NOT (inverse), Bitwise OR,
            /// </summary>
            R2_MERGEPENNOT = 14,

            /// <summary>
            /// Target bitmap, Selected pen, Bitwise OR,
            /// </summary>
            R2_MERGEPEN = 15,

            /// <summary>
            /// 1
            /// </summary>
            R2_WHITE = 16,
        }

        /// <summary>
        /// Used by BitBlt to define how the color data for the source rectangle is to be combined with the color data for the destination rectangle to achieve the final color.
        /// </summary>
        public enum TernaryRasterOperations : int
        {
            /// <summary>
            /// Include layered windows
            /// </summary>
            CAPTUREBLT = 0x40000000,

            /// <summary>
            /// Copies the source rectangle directly to the destination rectangle.
            /// </summary>
            SRCCOPY = 0x00CC0020,

            /// <summary>
            /// Combines the colors of the source and destination rectangles by using the Boolean OR operator.
            /// </summary>
            SRCPAINT = 0x00EE0086, /* dest = source OR dest */

            /// <summary>
            /// Combines the colors of the source and destination rectangles by using the Boolean AND operator.
            /// </summary>
            SRCAND = 0x008800C6,

            /// <summary>
            /// Combines the colors of the source and destination rectangles by using the Boolean XOR operator.
            /// </summary>
            SRCINVERT = 0x00660046,

            /// <summary>
            /// Combines the inverted colors of the destination rectangle with the colors of the source rectangle by using the Boolean AND operator.
            /// </summary>
            SRCERASE = 0x00440328,

            /// <summary>
            /// Copies the inverted source rectangle to the destination.
            /// </summary>
            NOTSRCCOPY = 0x00330008,

            /// <summary>
            /// Combines the colors of the source and destination rectangles by using the Boolean OR operator and then inverts the resultant color.
            /// </summary>
            NOTSRCERASE = 0x001100A6,

            /// <summary>
            /// Merges the colors of the source rectangle with the specified pattern by using the Boolean AND operator.
            /// </summary>
            MERGECOPY = 0x00C000CA,

            /// <summary>
            /// Merges the colors of the inverted source rectangle with the colors of the destination rectangle by using the Boolean OR operator.
            /// </summary>
            MERGEPAINT = 0x00BB0226,

            /// <summary>
            /// Copies the specified pattern into the destination bitmap.
            /// </summary>
            PATCOPY = 0x00F00021,

            /// <summary>
            /// Combines the colors of the pattern with the colors of the inverted source rectangle by using the Boolean OR operator.
            /// </summary>
            PATPAINT = 0x00FB0A09,

            /// <summary>
            /// Combines the colors of the specified pattern with the colors of the destination rectangle by using the Boolean XOR operator.
            /// </summary>
            PATINVERT = 0x005A0049,

            /// <summary>
            /// Inverts the destination rectangle.
            /// </summary>
            DSTINVERT = 0x00550009,

            /// <summary>
            /// Fills the destination rectangle using the color associated with index 0 in the physical palette.
            /// This color is black for the default physical palette.
            /// </summary>
            BLACKNESS = 0x00000042,

            /// <summary>
            /// Fills the destination rectangle using the color associated with index 1 in the physical palette.
            /// This color is white for the default physical palette.
            /// </summary>
            WHITENESS = 0x00FF0062
        }

        internal static class SafeNativeMethods
        {
            #region GDI - gdi32.dll imports

            /// <summary>
            /// This function transfers pixels from a specified source rectangle to a specified destination rectangle, altering the pixels according to the selected raster operation (ROP) code.
            /// </summary>
            /// <param name="hdcDst">A handle to the destination device context.</param>
            /// <param name="xDst">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
            /// <param name="yDst">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
            /// <param name="widthDst">The width, in logical units, of the source and destination rectangles.</param>
            /// <param name="heightDst">The height, in logical units, of the source and the destination rectangles.</param>
            /// <param name="hdcSrc">A handle to the source device context.</param>
            /// <param name="xSrc">The x-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
            /// <param name="ySrc">The y-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
            /// <param name="ulRop">A raster-operation code. These codes define how the color data for the source rectangle is to be combined with the color data for the destination rectangle to achieve the final color.</param>
            /// <returns></returns>
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hdcDst, int xDst, int yDst, int widthDst, int heightDst, IntPtr hdcSrc, int xSrc, int ySrc, TernaryRasterOperations ulRop);

            /// <summary>
            /// The StretchBlt function copies a bitmap from a source rectangle into a destination rectangle, stretching or compressing the bitmap to fit the dimensions of the destination rectangle, if necessary. The system stretches or compresses the bitmap according to the stretching mode currently set in the destination device context.
            /// </summary>
            /// <param name="hdcDst">A handle to the destination device context.</param>
            /// <param name="xDst">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
            /// <param name="yDst">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
            /// <param name="widthDst">The width, in logical units, of the destination rectangle.</param>
            /// <param name="heightDst">The height, in logical units, of the destination rectangle.</param>
            /// <param name="hdcSrc">A handle to the source device context.</param>
            /// <param name="xSrc">The x-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
            /// <param name="ySrc">The y-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
            /// <param name="widthSrc">The width, in logical units, of the source rectangle.</param>
            /// <param name="heightSrc">The height, in logical units, of the source rectangle.</param>
            /// <param name="ulRop">A raster-operation code. These codes define how the color data for the source rectangle is to be combined with the color data for the destination rectangle to achieve the final color.</param>
            /// <returns></returns>
            [DllImport("gdi32.dll")]
            public static extern bool StretchBlt(IntPtr hdcDst, int xDst, int yDst, int widthDst, int heightDst, IntPtr hdcSrc, int xSrc, int ySrc, int widthSrc, int heightSrc, TernaryRasterOperations ulRop);

            /// <summary>
            /// The CreateDC function creates a device context (DC) for a device using the specified name.
            /// </summary>
            /// <param name="lpszDriver"></param>
            /// <param name="lpszDevice"></param>
            /// <param name="lpszOutput"></param>
            /// <param name="lpInitData"></param>
            /// <returns></returns>
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateDC(IntPtr lpszDriver, string lpszDevice, IntPtr lpszOutput, IntPtr lpInitData);

            /// <summary>
            /// The DeleteDC function deletes the specified device context (DC).
            /// </summary>
            /// <param name="hdc"></param>
            /// <returns></returns>
            [DllImport("gdi32.dll")]
            public static extern IntPtr DeleteDC(IntPtr hdc);

            #endregion
        }
    }
}
