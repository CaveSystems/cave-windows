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
    /// Symbol Flags
    /// </summary>
    public enum SYMFLAG
    {
        /// <summary>
        /// The symbol is a CLR token.
        /// </summary>
        CLR_TOKEN = 0x00040000,

        /// <summary>
        /// The symbol is a constant.
        /// </summary>
        CONSTANT = 0x00000100,

        /// <summary>
        /// The symbol is from the export table.
        /// </summary>
        EXPORT = 0x00000200,

        /// <summary>
        /// The symbol is a forwarder.
        /// </summary>
        FORWARDER = 0x00000400,

        /// <summary>
        /// Offsets are frame relative.
        /// </summary>
        FRAMEREL = 0x00000020,

        /// <summary>
        /// The symbol is a known function.
        /// </summary>
        FUNCTION = 0x00000800,

        /// <summary>
        /// The symbol address is an offset relative to the beginning of the intermediate language block. This applies to managed code only.
        /// </summary>
        ILREL = 0x00010000,

        /// <summary>
        /// The symbol is a local variable.
        /// </summary>
        LOCAL = 0x00000080,

        /// <summary>
        /// The symbol is managed metadata.
        /// </summary>
        METADATA = 0x00020000,

        /// <summary>
        /// The symbol is a parameter.
        /// </summary>
        PARAMETER = 0x00000040,

        /// <summary>
        /// The symbol is a register. The Register member is used.
        /// </summary>
        REGISTER = 0x00000008,

        /// <summary>
        /// Offsets are register relative.
        /// </summary>
        REGREL = 0x00000010,

        /// <summary>
        /// The symbol is a managed code slot.
        /// </summary>
        SLOT = 0x00008000,

        /// <summary>
        /// The symbol is a thunk.
        /// </summary>
        THUNK = 0x00002000,

        /// <summary>
        /// The symbol is an offset into the TLS data area.
        /// </summary>
        TLSREL = 0x00004000,

        /// <summary>
        /// The Value member is used.
        /// </summary>
        VALUEPRESENT = 0x00000001,

        /// <summary>
        /// The symbol is a virtual symbol created by the SymAddSymbol function.
        /// </summary>
        VIRTUAL = 0x00001000,
    }
}
