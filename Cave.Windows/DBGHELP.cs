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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// provides an interface to the windows dbghelp.dll
    /// </summary>
    public static class DBGHELP
    {
        internal static class UnsafeNativeMethods
        {
            const string DLL = "dbghelp.dll";

            /// <summary>
            /// Initializes the symbol handler for a process.
            /// </summary>
            /// <param name="hProcess">A handle that identifies the caller. This value should be unique and nonzero, but need not be a process handle. However, if you do use a process handle, be sure to use the correct handle. If the application is a debugger, use the process handle for the process being debugged. Do not use the handle returned by GetCurrentProcess when debugging another process, because calling functions like SymLoadModuleEx can have unexpected results. </param>
            /// <param name="UserSearchPath">The path, or series of paths separated by a semicolon (;), that is used to search for symbol files. If this parameter is NULL, the library attempts to form a symbol path from the default sources.</param>
            /// <param name="fInvadeProcess">If this value is TRUE, enumerates the loaded modules for the process and effectively calls the SymLoadModule64 function for each module.</param>
            /// <returns>If the function succeeds, the return value is TRUE.</returns>
            [DllImport(DLL, SetLastError = true, CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SymInitialize(IntPtr hProcess, string UserSearchPath, [MarshalAs(UnmanagedType.Bool)]bool fInvadeProcess);

            /// <summary>
            /// Deallocates all resources associated with the process handle.
            /// </summary>
            /// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
            /// <returns>If the function succeeds, the return value is TRUE.</returns>
            [DllImport("dbghelp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SymCleanup(IntPtr hProcess);

            /// <summary>
            /// Loads the symbol table for the specified module.
            /// </summary>
            /// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
            /// <param name="hFile">A handle to the file for the executable image. This argument is used mostly by debuggers, where the debugger passes the file handle obtained from a debugging event. A value of NULL indicates that hFile is not used.</param>
            /// <param name="ImageName">The name of the executable image. This name can contain a partial path, a full path, or no path at all. If the file cannot be located by the name provided, the symbol search path is used.</param>
            /// <param name="ModuleName">A shortcut name for the module. If the pointer value is NULL, the library creates a name using the base name of the symbol file.</param>
            /// <param name="BaseOfDll">The load address of the module. If the value is zero, the library obtains the load address from the symbol file. The load address contained in the symbol file is not necessarily the actual load address. Debuggers and other applications having an actual load address should use the real load address when calling this function. <br />
            /// If the image is a .pdb file, this parameter cannot be zero.</param>
            /// <param name="DllSize">The size of the module, in bytes. If the value is zero, the library obtains the size from the symbol file. The size contained in the symbol file is not necessarily the actual size. Debuggers and other applications having an actual size should use the real size when calling this function.<br />
            /// If the image is a .pdb file, this parameter cannot be zero.</param>
            /// <param name="Data">A pointer to a MODLOAD_DATA structure that represents headers other than the standard PE header. This parameter is optional and can be NULL.</param>
            /// <param name="Flags">This parameter can be zero or one or more of the enum values. If this parameter is zero, the function loads the modules and the symbols for the module.</param>
            /// <returns>If the function succeeds, the return value is the base address of the loaded module. If the function fails, the return value is zero.<br />
            /// If the module is already loaded, the return value is zero and GetLastError returns ERROR_SUCCESS.</returns>
            [DllImport("dbghelp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern ulong SymLoadModuleEx(IntPtr hProcess, IntPtr hFile, string ImageName, string ModuleName, long BaseOfDll, int DllSize, IntPtr Data, SYMFLAGS Flags);

            /// <summary>
            /// Enumerates all the symbols for a specified module.
            /// This function is provided only for compatibility. Applications should use SymEnumSymbols, which is faster and more powerful.
            /// </summary>
            /// <param name="hProcess">A handle to the process. This handle must have been previously passed to the SymInitialize function.</param>
            /// <param name="BaseOfDll">The base address of the module for which symbols are to be enumerated.</param>
            /// <param name="EnumSymbolsCallback">The callback function that receives the symbol information. For more information, see SymEnumerateSymbolsProc64.</param>
            /// <param name="UserContext">A user-defined value or NULL. This value is passed to the callback function. Typically, this parameter is used by an application to pass a pointer to a data structure that enables the callback function establish some type of context.</param>
            /// <returns></returns>
            [DllImport("dbghelp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SymEnumerateSymbols64(IntPtr hProcess, ulong BaseOfDll, SymEnumerateSymbolsProc64 EnumSymbolsCallback, IntPtr UserContext);

            /// <summary>
            /// Enumerates all symbols in a process.
            /// </summary>
            /// <param name="hProcess">A handle to the process. This handle must have been previously passed to the SymInitialize function.</param>
            /// <param name="BaseOfDll">The base address of the module for which symbols are to be enumerated.</param>
            /// <param name="Mask">A wildcard string that indicates the names of the symbols to be enumerated. The text can optionally contain the wildcards, "*" and "?".</param>
            /// <param name="EnumSymbolsCallback">The callback function that receives the symbol information. For more information, see SymEnumerateSymbolsProc64.</param>
            /// <param name="UserContext">A user-defined value or NULL. This value is passed to the callback function. Typically, this parameter is used by an application to pass a pointer to a data structure that enables the callback function establish some type of context.</param>
            /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE. To retrieve extended error information, call GetLastError.</returns>
            [DllImport("dbghelp.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool SymEnumSymbols(IntPtr hProcess, ulong BaseOfDll, string Mask, SymEnumerateSymbolsProc64 EnumSymbolsCallback, IntPtr UserContext);
        }

        /// <summary>
        /// An application-defined callback function used with the SymEnumerateSymbols64 function. It is called once for each enumerated symbol, and receives the symbol information.
        /// </summary>
        /// <param name="symbolName">The name of the symbol. The name can be undecorated if the SYMOPT_UNDNAME option is used with the SymSetOptions function.</param>
        /// <param name="symbolAddress">The virtual address for the beginning of the symbol.</param>
        /// <param name="SymbolSize">The size of the symbol, in bytes. The size is calculated and is actually a best-guess value. In some cases, the value can be zero.</param>
        /// <param name="userContext">The user-defined value specified in SymEnumerateSymbols64, or NULL. Typically, this parameter is used by an application to pass a pointer to a data structure that lets the callback function establish some type of context.</param>
        /// <returns>If the function returns TRUE, the enumeration will continue.</returns>
        public delegate bool SymEnumerateSymbolsProc64(string symbolName, ulong symbolAddress, uint SymbolSize, IntPtr userContext);

        /// <summary>
        /// An application-defined callback function used with the SymEnumSymbols, SymEnumTypes, and SymEnumTypesByName functions.
        /// </summary>
        /// <param name="symbolInfo">A pointer to a SYMBOL_INFO structure that provides information about the symbol.</param>
        /// <param name="symbolSize">The size of the symbol, in bytes. The size is calculated and is actually a guess. In some cases, this value can be zero.</param>
        /// <param name="userContext">The user-defined value passed from the SymEnumSymbols or SymEnumTypes function, or NULL. This parameter is typically used by an application to pass a pointer to a data structure that provides context information for the callback function.</param>
        /// <returns></returns>
        public delegate bool SymEnumSymbolsProc(IntPtr symbolInfo, ulong symbolSize, IntPtr userContext);

        /// <summary>
        /// Enumerates all symbols of the given file
        /// </summary>
        /// <param name="fileName">The file</param>
        /// <param name="callback">The callback to be called for every smybol</param>
        public static void EnumSymbols(string fileName, SymEnumerateSymbolsProc64 callback)
        {
            IntPtr ptr = Process.GetCurrentProcess().Handle;
            bool result = UnsafeNativeMethods.SymInitialize(ptr, null, false);
            if (!result) throw new Win32ErrorException();

            ulong baseOfDll = UnsafeNativeMethods.SymLoadModuleEx(ptr, IntPtr.Zero, fileName, null, 0, 0, IntPtr.Zero, 0);
            int error = Marshal.GetLastWin32Error();
            if ((baseOfDll == 0) && (error != 0))
            {
                UnsafeNativeMethods.SymCleanup(ptr);
                throw new Win32ErrorException(error);
            }
            if (UnsafeNativeMethods.SymEnumerateSymbols64(ptr, baseOfDll, callback, IntPtr.Zero) == false) throw new Exception("Failed to enum symbols");
            UnsafeNativeMethods.SymCleanup(ptr);
        }
    }
}
