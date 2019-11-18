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

#if !NETSTANDARD20

using System;
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// Provides access to a windows control via handle
    /// </summary>
    public class CONTROL
    {
        /// <summary>
        /// Obtains the class name
        /// </summary>
        public string ClassName;

        /// <summary>
        /// Obtains the caption
        /// </summary>
        public string Caption;

        /// <summary>
        /// Obtains the handle
        /// </summary>
        public IntPtr Handle;

        /// <summary>
        /// Creates a new instance by reading the handle
        /// </summary>
        /// <param name="handle"></param>
        public CONTROL(IntPtr handle)
        {
            Handle = handle;
            StringBuilder caption = new StringBuilder(255);
            USER32.GetWindowText(handle, caption, 255);
            Caption = caption.ToString();
            StringBuilder className = new StringBuilder(255);
            USER32.GetClassName(handle, className, 255);
            ClassName = className.ToString();
        }

        /// <summary>
        /// Internally initializes the instance without checking any values
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="className"></param>
        /// <param name="caption"></param>
        internal CONTROL(IntPtr handle, string className, string caption)
        {
            Handle = handle;
            ClassName = className;
            Caption = caption;
        }

        /// <summary>
        /// Obtains the <see cref="WINDOWINFO"/> for the control
        /// </summary>
        public WINDOWINFO Info
        {
            get
            {
                WINDOWINFO result = new WINDOWINFO();
                USER32.GetWindowInfo(Handle, ref result);
                return result;
            }
        }
    }
}

#endif