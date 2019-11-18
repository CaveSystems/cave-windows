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
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// Native interface to the SHLWAPI.DLL
    /// </summary>
    public static class SHLWAPI
    {
        /// <summary>
        /// Extracts a specified text resource when given that resource in the form of an indirect string (a string that begins with the '@' symbol).
        /// </summary>
        /// <param name="pszSource">A pointer to a buffer that contains the indirect string from which the resource will be retrieved. This string should begin with the '@' symbol and use one of the forms discussed in the Remarks section. This function will successfully accept a string that does not begin with an '@' symbol, but the string will be simply passed unchanged to pszOutBuf.</param>
        /// <param name="pszOutBuf">A pointer to a buffer that, when this function returns successfully, receives the text resource. Both pszOutBuf and pszSource can point to the same buffer, in which case the original string will be overwritten.</param>
        /// <param name="cchOutBuf">The size of the buffer pointed to by pszOutBuf, in characters.</param>
        /// <param name="ppvReserved">Not used; set to NULL.</param>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [DllImport("shlwapi.dll", BestFitMapping = false, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false, ThrowOnUnmappableChar = true)]
        public static extern int SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, int cchOutBuf, IntPtr ppvReserved);

        /// <summary>
        /// Extracts a specified text resource when given that resource in the form of an indirect string (a string that begins with the '@' symbol).
        /// </summary>
        /// <param name="source">@fileName,resource[;version]</param>
        /// <returns></returns>
        public static string GetResource(string source)
        {
            if (source == null) throw new ArgumentNullException("Source");
            if (!source.StartsWith("@")) throw new ArgumentOutOfRangeException(nameof(source));

            StringBuilder str = new StringBuilder(2048);
            int result = SHLoadIndirectString(Environment.ExpandEnvironmentVariables(source), str, str.Capacity, IntPtr.Zero);
            if (result != 0) throw new Win32ErrorException(result & 0xFFFF);
            return result.ToString();
        }
    }
}
