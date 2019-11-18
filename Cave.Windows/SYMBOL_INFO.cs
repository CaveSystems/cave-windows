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
    /// 32 bit version of the SYMBOL_INFO struct
    /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/ms680686%28v=vs.85%29.aspx</remarks>
    /// </summary>
    public struct SYMBOL_INFO32
    {
        /// <summary>
        /// The size of the structure, in bytes. This member must be set to sizeof(SYMBOL_INFO). Note that the total size of the data is the SizeOfStruct + (MaxNameLen - 1) * sizeof(TCHAR). The reason to subtract one is that the first character in the name is accounted for in the size of the structure.
        /// </summary>
        public uint SizeOfStruct;

        /// <summary>
        /// A unique value that identifies the type data that describes the symbol. This value does not persist between sessions.
        /// </summary>
        public uint TypeIndex;

        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public ulong Reserved1;

        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public ulong Reserved2;

        /// <summary>
        /// The unique value for the symbol. The value associated with a symbol is not guaranteed to be the same each time you run the process.
        /// For PDB symbols, the index value for a symbol is not generated until the symbol is enumerated or retrieved through a search by name or address. The index values for all CodeView and COFF symbols are generated when the symbols are loaded.
        /// </summary>
        public uint Index;

        /// <summary>
        /// The symbol size, in bytes. This value is meaningful only if the module symbols are from a pdb file; otherwise, this value is typically zero and should be ignored.
        /// </summary>
        public uint Size;

        /// <summary>
        /// The base address of the module that contains the symbol.
        /// </summary>
        public ulong ModBase;

        /// <summary>
        /// This member can be one or more values of the <see cref="SYMFLAG"/> enum
        /// </summary>
        public uint Flags;

        /// <summary>
        /// The value of a constant.
        /// </summary>
        public ulong Value;

        /// <summary>
        /// The virtual address of the start of the symbol.
        /// </summary>
        public ulong Address;

        /// <summary>
        /// The register.
        /// </summary>
        public uint Register;

        /// <summary>
        /// The DIA scope. For more information, see the Debug Interface Access SDK in the Visual Studio documentation. (This resource may not be available in some languages and countries.)
        /// </summary>
        public uint Scope;

        /// <summary>
        /// The PDB classification. These values are defined in Dbghelp.h in the SymTagEnum enumeration type.
        /// </summary>
        public uint Tag;

        /// <summary>
        /// The length of the name, in characters, not including the null-terminating character.
        /// </summary>
        public uint NameLen;

        /// <summary>
        /// The size of the Name buffer, in characters. If this member is 0, the Name member is not used.
        /// </summary>
        public uint MaxNameLen;

        /// <summary>
        /// The name of the symbol. The name can be undecorated if the SYMOPT_UNDNAME option is used with the SymSetOptions function.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 600)]
        public string Name;
    }

    /// <summary>
    /// 64 bit version of the SYMBOL_INFO struct
    /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/ms680686%28v=vs.85%29.aspx</remarks>
    /// </summary>
    public struct SYMBOL_INFO64
    {
        /// <summary>
        /// The size of the structure, in bytes. This member must be set to sizeof(SYMBOL_INFO). Note that the total size of the data is the SizeOfStruct + (MaxNameLen - 1) * sizeof(TCHAR). The reason to subtract one is that the first character in the name is accounted for in the size of the structure.
        /// </summary>
        public ulong SizeOfStruct;

        /// <summary>
        /// A unique value that identifies the type data that describes the symbol. This value does not persist between sessions.
        /// </summary>
        public ulong TypeIndex;

        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public ulong Reserved1;

        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public ulong Reserved2;

        /// <summary>
        /// The unique value for the symbol. The value associated with a symbol is not guaranteed to be the same each time you run the process.
        /// For PDB symbols, the index value for a symbol is not generated until the symbol is enumerated or retrieved through a search by name or address. The index values for all CodeView and COFF symbols are generated when the symbols are loaded.
        /// </summary>
        public ulong Index;

        /// <summary>
        /// The symbol size, in bytes. This value is meaningful only if the module symbols are from a pdb file; otherwise, this value is typically zero and should be ignored.
        /// </summary>
        public ulong Size;

        /// <summary>
        /// The base address of the module that contains the symbol.
        /// </summary>
        public ulong ModBase;

        /// <summary>
        /// This member can be one or more values of the <see cref="SYMFLAG"/> enum
        /// </summary>
        public ulong Flags;

        /// <summary>
        /// The value of a constant.
        /// </summary>
        public ulong Value;

        /// <summary>
        /// The virtual address of the start of the symbol.
        /// </summary>
        public ulong Address;

        /// <summary>
        /// The register.
        /// </summary>
        public ulong Register;

        /// <summary>
        /// The DIA scope. For more information, see the Debug Interface Access SDK in the Visual Studio documentation. (This resource may not be available in some languages and countries.)
        /// </summary>
        public ulong Scope;

        /// <summary>
        /// The PDB classification. These values are defined in Dbghelp.h in the SymTagEnum enumeration type.
        /// </summary>
        public ulong Tag;

        /// <summary>
        /// The length of the name, in characters, not including the null-terminating character.
        /// </summary>
        public ulong NameLen;

        /// <summary>
        /// The size of the Name buffer, in characters. If this member is 0, the Name member is not used.
        /// </summary>
        public ulong MaxNameLen;

        /// <summary>
        /// The name of the symbol. The name can be undecorated if the SYMOPT_UNDNAME option is used with the SymSetOptions function.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 600)]
        public string Name;
    }
}
