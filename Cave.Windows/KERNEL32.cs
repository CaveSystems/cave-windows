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

using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// provides an interface to the windows kernel32.dll
    /// </summary>
    public static class KERNEL32
    {
        /// <summary>
        /// Obtains the default buffer size used when retrieving information from KERNEL32
        /// </summary>
        public const int DefaultStructBufferSize = 65540;

        /// <summary>
        /// Maximum chars for short paths
        /// </summary>
        public const int MAX_PATH = 260;

        /// <summary>
        /// Maximum chars for long paths including zero termination
        /// </summary>
        public const int MAX_LONG_PATH = 32000;

        /// <summary>
        /// Maximum chars for short names including zerotermination
        /// </summary>
        public const int MAX_SHORT_NAME = 14;

        /// <summary>
        ///
        /// </summary>
        /// <returns>Idle, Kernel and User times</returns>
        public unsafe static SYSTEMTIMES GetSystemTimes()
        {
            long l_Idle;
            long l_User;
            long l_Kernel;
            if (!SafeNativeMethods.GetSystemTimes(out l_Idle, out l_User, out l_Kernel)) throw new NotSupportedException();
            return new SYSTEMTIMES(new TimeSpan(l_Idle), new TimeSpan(l_User), new TimeSpan(l_Kernel));
        }

        /// <summary>
        /// Creates or opens a file or I/O device. The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, and pipe. The function returns a handle that can be used to access the file or device for various types of I/O depending on the file or device and the flags and attributes specified.
        /// </summary>
        /// <param name="fileName">The name of the file or device to be created or opened.</param>
        /// <param name="fileAccess">The requested access to the file or device, which can be summarized as read, write, both or neither zero).</param>
        /// <param name="shareMode">The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table). Access requests to attributes or extended attributes are not affected by this flag.</param>
        /// <param name="creationDisposition">An action to take on a file or device that exists or does not exist. For devices other than files, this parameter is usually set to OPEN_EXISTING.</param>
        /// <param name="flagsAndAttributes">The file or device attributes and flags, FILE_ATTRIBUTE_NORMAL being the most common default value for files. This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*). All other file attributes override FILE_ATTRIBUTE_NORMAL.</param>
        /// <returns></returns>
        public static SafeFileHandle CreateFileHandle(string fileName, FileAccess fileAccess, FileShare shareMode, DISPOSITION creationDisposition, FILE_FLAG flagsAndAttributes)
        {
            ACCESS access;
            switch (fileAccess)
            {
                case FileAccess.Read:
                    access = ACCESS.FILE_GENERIC_READ;
                    break;
                case FileAccess.Write:
                    access = ACCESS.FILE_GENERIC_WRITE;
                    break;
                case FileAccess.ReadWrite:
                default:
                    access = ACCESS.FILE_GENERIC_READ | ACCESS.FILE_GENERIC_WRITE;
                    break;
            }
            IntPtr ptr = SafeNativeMethods.CreateFile(fileName, access, shareMode, IntPtr.Zero, creationDisposition, flagsAndAttributes, IntPtr.Zero);
            SafeFileHandle handle = new SafeFileHandle(ptr, true);
            CheckLastError(183);
            if (handle.IsInvalid) throw new Win32ErrorException();
            return handle;
        }

        /// <summary>
        /// Creates or opens a file or I/O device. The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, and pipe. The function returns a handle that can be used to access the file or device for various types of I/O depending on the file or device and the flags and attributes specified.
        /// </summary>
        /// <param name="fileName">The name of the file or device to be created or opened.</param>
        /// <param name="fileAccess">The requested access to the file or device, which can be summarized as read, write, both or neither zero).</param>
        /// <param name="shareMode">The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table). Access requests to attributes or extended attributes are not affected by this flag.</param>
        /// <param name="creationDisposition">An action to take on a file or device that exists or does not exist. For devices other than files, this parameter is usually set to OPEN_EXISTING.</param>
        /// <param name="flagsAndAttributes">The file or device attributes and flags, FILE_ATTRIBUTE_NORMAL being the most common default value for files. This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*). All other file attributes override FILE_ATTRIBUTE_NORMAL.</param>
        /// <returns></returns>
        public static FileStream CreateFile(string fileName, FileAccess fileAccess, FileShare shareMode, DISPOSITION creationDisposition, FILE_FLAG flagsAndAttributes)
        {
            return new FileStream(CreateFileHandle(fileName, fileAccess, shareMode, creationDisposition, flagsAndAttributes), fileAccess);
        }

        /// <summary>
        /// Obtains all available volumes
        /// </summary>
        /// <returns></returns>
        public static string[] GetVolumes()
        {
            List<string> result = new List<string>();
            StringBuilder buffer = new StringBuilder(DefaultStructBufferSize);
            IntPtr handle = SafeNativeMethods.FindFirstVolume(buffer, DefaultStructBufferSize);
            int l_ErrorCode = Marshal.GetLastWin32Error();
            switch (l_ErrorCode)
            {
                case 18:
                case 234: break;
                default: throw new Win32ErrorException((ErrorCode)l_ErrorCode);
            }
            bool l_Good = handle.ToInt64() > -1;
            while (l_Good)
            {
                string str = buffer.ToString();
                result.Add(str);
                l_Good = SafeNativeMethods.FindNextVolume(handle, buffer, DefaultStructBufferSize);
            }
            SafeNativeMethods.FindVolumeClose(handle);
            return result.ToArray();
        }

        /// <summary>
        /// Obtains all mount points of a given volume
        /// </summary>
        /// <param name="volume">A volume GUID path for the volume to scan for mounted folders. A trailing backslash is required.</param>
        /// <returns></returns>
        public static string[] GetMountPoints(string volume)
        {
            List<string> result = new List<string>();
            StringBuilder buffer = new StringBuilder(DefaultStructBufferSize);
            IntPtr handle = SafeNativeMethods.FindFirstVolumeMountPoint(volume, buffer, DefaultStructBufferSize);
            int l_ErrorCode = Marshal.GetLastWin32Error();
            switch (l_ErrorCode)
            {
                case 18:
                case 234: break;
                default: throw new Win32ErrorException(l_ErrorCode);
            }
            bool l_Good = handle.ToInt64() > -1;
            while (l_Good)
            {
                string str = buffer.ToString();
                result.Add(str);
                l_Good = SafeNativeMethods.FindNextVolumeMountPoint(handle, buffer, DefaultStructBufferSize);
            }
            SafeNativeMethods.FindVolumeMountPointClose(handle);
            return result.ToArray();
        }

        /// <summary>
        /// Retrieves information about MS-DOS device names.
        /// </summary>
        /// <returns>Returns a list of all existing MS-DOS device names.</returns>
        public static string[] QueryDosDevices()
        {
            int bufferSize = DefaultStructBufferSize;
            IntPtr buffer = Marshal.AllocHGlobal(bufferSize);
            int size = 0;
            while (true)
            {
                size = SafeNativeMethods.QueryDosDevice(null, buffer, bufferSize);
                if (size == 0)
                {
                    int l_ErrorCode = Marshal.GetLastWin32Error();
                    if (l_ErrorCode == 0x7A)
                    {//buffer too small
                        Marshal.FreeHGlobal(buffer);
                        bufferSize *= 16;
                        buffer = Marshal.AllocHGlobal(bufferSize);
                        continue;
                    }
                    throw new Win32ErrorException(l_ErrorCode);
                }
                break;
            }
            string data = Marshal.PtrToStringAuto(buffer, size);
            Marshal.FreeHGlobal(buffer);
            return data.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Retrieves a list of drive letters and mounted folder paths for the specified volume.
        /// </summary>
        /// <param name="volume">A volume GUID path for the volume. A volume GUID path is of the form "\\?\Volume{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}\".</param>
        /// <returns></returns>
        public static string[] GetVolumePathNames(string volume)
        {
            int bufferSize = DefaultStructBufferSize;
            IntPtr buffer = Marshal.AllocHGlobal(bufferSize);
            int size = 0;
            while (true)
            {
                SafeNativeMethods.GetVolumePathNamesForVolumeName(volume, buffer, bufferSize, ref size);
                if (size == 0)
                {
                    int l_ErrorCode = Marshal.GetLastWin32Error();
                    if (l_ErrorCode == 0x7A)
                    {//buffer too small
                        Marshal.FreeHGlobal(buffer);
                        bufferSize *= 16;
                        buffer = Marshal.AllocHGlobal(bufferSize);
                        continue;
                    }
                    throw new Win32ErrorException(l_ErrorCode);
                }
                break;
            }
            string data = Marshal.PtrToStringAuto(buffer, size);
            Marshal.FreeHGlobal(buffer);
            return data.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Does a call to <see cref="Marshal.GetLastWin32Error()"/> and checks the resulting error code. Any errorcode != ERROR.SUCCESS will result in throwing a <see cref="Win32ErrorException"/>.
        /// </summary>
        public static void CheckLastError()
        {
            ErrorCode l_LastError = (ErrorCode)Marshal.GetLastWin32Error();
            if (l_LastError == ErrorCode.SUCCESS) return;
            throw new Win32ErrorException(l_LastError);
        }

        /// <summary>
        /// Does a call to <see cref="Marshal.GetLastWin32Error()"/> and checks the resulting error code. Any errorcode != ERROR.SUCCESS and != valid errors will result in throwing a <see cref="Win32ErrorException"/>.
        /// </summary>
        /// <param name="validErrors"></param>
        public static void CheckLastError(params int[] validErrors)
        {
            int l_LastError = Marshal.GetLastWin32Error();
            if (l_LastError == (int)ErrorCode.SUCCESS) return;
            if (Array.IndexOf(validErrors, l_LastError) >= 0) return;
            throw new Win32ErrorException(l_LastError);
        }

        /// <summary>
        /// Retrieves information about the system's current usage of both physical and virtual memory.
        /// </summary>
        /// <returns>Information about current memory availability.</returns>
        /// <exception cref="Win32ErrorException"></exception>
        public static MEMORYSTATUSEX GlobalMemoryStatusEx()
        {
            MEMORYSTATUSEX result = new MEMORYSTATUSEX();
            result.SetLength();
            if (!SafeNativeMethods.GlobalMemoryStatusEx(ref result)) throw new Win32ErrorException();
            return result;
        }

        /// <summary>
        /// Allocates a new console for the calling process.
        /// If you use Cave.Console you should call SystemConsole.ReInitialize() afterwards.
        /// </summary>
        public static void AllocConsole()
        {
            SafeNativeMethods.AllocConsole();
            {
                IntPtr defaultStdout = SafeNativeMethods.CreateFile("CONOUT$", ACCESS.GENERIC_READ | ACCESS.GENERIC_WRITE, FileShare.ReadWrite, IntPtr.Zero, DISPOSITION.OPEN_EXISTING, 0, IntPtr.Zero);
                IntPtr currentStdout = SafeNativeMethods.GetStdHandle(STD_HANDLE.OUTPUT);
                if (currentStdout != defaultStdout) SafeNativeMethods.SetStdHandle(STD_HANDLE.OUTPUT, defaultStdout);
                System.Console.SetOut(new StreamWriter(System.Console.OpenStandardOutput()) { AutoFlush = true });
            }
            {
                IntPtr defaultStdin = SafeNativeMethods.CreateFile("CONIN$", ACCESS.GENERIC_READ | ACCESS.GENERIC_WRITE, FileShare.ReadWrite, IntPtr.Zero, DISPOSITION.OPEN_EXISTING, 0, IntPtr.Zero);
                IntPtr currentStdin = SafeNativeMethods.GetStdHandle(STD_HANDLE.INPUT);
                if (currentStdin != defaultStdin) SafeNativeMethods.SetStdHandle(STD_HANDLE.INPUT, defaultStdin);
                System.Console.SetIn(new StreamReader(System.Console.OpenStandardInput()));
            }
        }

        /// <summary>
        /// Native interop
        /// </summary>
        public static class SafeNativeMethods
        {
            #region function imports

            /// <summary>
            /// Retrieves the number of milliseconds that have elapsed since the system was started.
            /// <remarks>
            /// The resolution of the GetTickCount64 function is limited to the resolution of the system timer, which is typically in the range of 10 milliseconds to 16 milliseconds. The resolution of the GetTickCount64 function is not affected by adjustments made by the GetSystemTimeAdjustment function.
            /// If you need a higher resolution timer, use a multimedia timer or a high-resolution timer.
            /// To obtain the time the system has spent in the working state since it was started, use the QueryUnbiasedInterruptTime function. 
            /// </remarks>
            /// </summary>
            /// <returns>The number of milliseconds.</returns>
            [DllImport(@"kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern ulong GetTickCount64();

            /// <summary>
            /// Retrieves information about the system's current usage of both physical and virtual memory.
            /// </summary>
            /// <param name="lpBuffer">A pointer to a MEMORYSTATUSEX structure that receives information about current memory availability.</param>
            /// <returns>If the function succeeds, the return value is nonzero.
            /// If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
            [DllImport(@"kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

            /// <summary>
            /// Retrieves the current directory for the current process.
            /// </summary>
            /// <param name="nBufferLength">The length of the buffer for the current directory string, in TCHARs. The buffer length must include room for a terminating null character.</param>
            /// <param name="lpBuffer">A pointer to the buffer that receives the current directory string. This null-terminated string specifies the absolute path to the current directory.</param>
            /// <returns>If the function succeeds, the return value specifies the number of characters that are written to the buffer, not including the terminating null character.</returns>
            [DllImport(@"kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern uint GetCurrentDirectory(uint nBufferLength, StringBuilder lpBuffer);

            /// <summary>
            /// Changes the current directory for the current process.
            /// </summary>
            /// <param name="lpPathName">The path to the new current directory. This parameter may specify a relative path or a full path. In either case, the full path of the specified directory is calculated and stored as the current directory. </param>
            /// <returns></returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool SetCurrentDirectory([MarshalAs(UnmanagedType.LPTStr)]string lpPathName);

            /// <summary>
            /// Sets the date and time that the specified file or directory was created, last accessed, or last modified.
            /// </summary>
            /// <param name="hFile">A handle to the file or directory. The handle must have been created using the CreateFile function with the FILE_WRITE_ATTRIBUTES access right.</param>
            /// <param name="lpCreationTime">A pointer to a FILETIME structure that contains the new creation date and time for the file or directory. </param>
            /// <param name="lpLastAccessTime">A pointer to a FILETIME structure that contains the new last access date and time for the file or directory. The last access time includes the last time the file or directory was written to, read from, or (in the case of executable files) run.</param>
            /// <param name="lpLastWriteTime">A pointer to a FILETIME structure that contains the new last modified date and time for the file or directory.</param>
            /// <returns>If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
            [DllImport(@"kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool SetFileTime(SafeFileHandle hFile, ref long lpCreationTime, ref long lpLastAccessTime, ref long lpLastWriteTime);

            /// <summary>
            /// Sets the attributes for a file or directory.
            /// </summary>
            /// <param name="lpFileName">The name of the file whose attributes are to be set. </param>
            /// <param name="dwFileAttributes">The file attributes to set for the file.</param>
            /// <returns>If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
            [DllImport(@"kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
            public static extern bool SetFileAttributes([MarshalAs(UnmanagedType.LPTStr)]string lpFileName, FileAttributes dwFileAttributes);

            /// <summary>
            /// Copies an existing file to a new file.
            /// </summary>
            /// <param name="src">The name of an existing file.</param>
            /// <param name="dst">The name of the new file.</param>
            /// <param name="failIfExists">If this parameter is TRUE and the new file specified by lpNewFileName already exists, the function fails. If this parameter is FALSE and the new file already exists, the function overwrites the existing file and succeeds.</param>
            /// <returns>If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool CopyFile(string src, string dst, bool failIfExists);

            /// <summary>
            /// Searches a directory for a file or subdirectory with a name that matches a specific name (or partial name if wildcards are used).
            /// </summary>
            /// <param name="lpFileName">The directory or path, and the file name, which can include wildcard characters, for example, an asterisk (*) or a question mark (?).</param>
            /// <param name="lpFindFileData">A pointer to the WIN32_FIND_DATA structure that receives information about a found file or directory.</param>
            /// <returns>If the function succeeds, the return value is a search handle used in a subsequent call to FindNextFile or FindClose, and the lpFindFileData parameter contains information about the first file or directory found.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern SafeFindHandle FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

            /// <summary>
            /// Continues a file search from a previous call to the FindFirstFile, FindFirstFileEx, or FindFirstFileTransacted functions.
            /// </summary>
            /// <param name="hFindFile">The search handle returned by a previous call to the FindFirstFile or FindFirstFileEx function.</param>
            /// <param name="lpFindFileData">A pointer to the WIN32_FIND_DATA structure that receives information about the found file or subdirectory.</param>
            /// <returns>If the function fails, the return value is zero and the contents of lpFindFileData are indeterminate. To get extended error information, call the GetLastError function.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool FindNextFile(SafeFindHandle hFindFile, out WIN32_FIND_DATA lpFindFileData);

            /// <summary>
            /// Closes a file search handle opened by the FindFirstFile, FindFirstFileEx functions.
            /// </summary>
            /// <param name="hFindFile">The file search handle. </param>
            /// <returns>If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool FindClose(SafeFindHandle hFindFile);

            /// <summary>
            /// Retrieves the full path and file name of the specified file.
            /// </summary>
            /// <param name="lpFileName">The name of the file.</param>
            /// <param name="nBufferLength">The size of the buffer to receive the null-terminated string for the drive and path, in TCHARs. </param>
            /// <param name="lpBuffer">A pointer to a buffer that receives the null-terminated string for the drive and path.</param>
            /// <param name="lpFilePart">A pointer to a buffer that receives the address (within lpBuffer) of the final file name component in the path. </param>
            /// <returns></returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern uint GetFullPathName(string lpFileName, uint nBufferLength, StringBuilder lpBuffer, IntPtr lpFilePart);

            /// <summary>
            /// Deletes an existing file.
            /// </summary>
            /// <param name="lpFileName">The name of the file to be deleted.</param>
            /// <returns>If the function fails, the return value is zero (0). To get extended error information, call GetLastError.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool DeleteFile(string lpFileName);

            /// <summary>
            /// Deletes an existing empty directory.
            /// </summary>
            /// <param name="lpPathName">The path of the directory to be removed. This path must specify an empty directory, and the calling process must have delete access to the directory.</param>
            /// <returns>If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool RemoveDirectory(string lpPathName);

            /// <summary>
            /// Creates a new directory. If the underlying file system supports security on files and directories, the function applies a specified security descriptor to the new directory.
            /// </summary>
            /// <param name="lpPathName">The path of the directory to be created.</param>
            /// <param name="lpSecurityAttributes">A pointer to a SECURITY_ATTRIBUTES structure. The lpSecurityDescriptor member of the structure specifies a security descriptor for the new directory. If lpSecurityAttributes is NULL, the directory gets a default security descriptor. The ACLs in the default security descriptor for a directory are inherited from its parent directory.</param>
            /// <returns></returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool CreateDirectory(string lpPathName, IntPtr lpSecurityAttributes);

            /// <summary>
            /// Moves an existing file or a directory, including its children.
            /// </summary>
            /// <param name="lpPathNameFrom">The current name of the file or directory on the local computer.</param>
            /// <param name="lpPathNameTo">The new name for the file or directory. The new name must not already exist. A new file may be on a different file system or drive. A new directory must be on the same drive.</param>
            /// <returns>If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool MoveFile(string lpPathNameFrom, string lpPathNameTo);

            /// <summary>
            /// Creates or opens a file or I/O device. The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, and pipe. The function returns a handle that can be used to access the file or device for various types of I/O depending on the file or device and the flags and attributes specified.
            /// </summary>
            /// <param name="lpFileName">The name of the file or device to be created or opened. You may use either forward slashes (/) or backslashes (\) in this name.</param>
            /// <param name="dwDesiredAccess">The requested access to the file or device, which can be summarized as read, write, both or neither zero).</param>
            /// <param name="dwShareMode">The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table). Access requests to attributes or extended attributes are not affected by this flag.</param>
            /// <param name="lpSecurityAttributes">A pointer to a SECURITY_ATTRIBUTES structure that contains two separate but related data members: an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes.</param>
            /// <param name="dwCreationDisposition">An action to take on a file or device that exists or does not exist.</param>
            /// <param name="dwFlagsAndAttributes">The file or device attributes and flags, FILE_ATTRIBUTE_NORMAL being the most common default value for files.</param>
            /// <param name="hTemplateFile">A valid handle to a template file with the GENERIC_READ access right. The template file supplies file attributes and extended attributes for the file that is being created. This parameter can be NULL.</param>
            /// <returns>If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern SafeFileHandle CreateFile(string lpFileName, ACCESS dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

            /// <summary>
            /// Retrieves file system attributes for a specified file or directory.
            /// </summary>
            /// <param name="lpFileName">The name of the file or directory. </param>
            /// <returns>If the function fails, the return value is INVALID_FILE_ATTRIBUTES. To get extended error information, call GetLastError.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern FileAttributes GetFileAttributes(string lpFileName);

            /// <summary>
            /// Retrieves the size of the specified file.
            /// </summary>
            /// <param name="handle">A handle to the file. The handle must have been created with either the GENERIC_READ or GENERIC_WRITE access right or equivalent. For more information, see File Security and Access Rights.</param>
            /// <param name="lpFileSize">A pointer to a LARGE_INTEGER structure that receives the file size, in bytes.</param>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool GetFileSizeEx(IntPtr handle, ref long lpFileSize);

            /// <summary>
            /// Retrieves the date and time that a file or directory was created, last accessed, and last modified.
            /// </summary>
            /// <param name="handle">A handle to the file or directory for which dates and times are to be retrieved. The handle must have been created using the CreateFile function with the GENERIC_READ access right. For more information, see File Security and Access Rights.</param>
            /// <param name="lpCreationTime">A pointer to a FILETIME structure to receive the date and time the file or directory was created. This parameter can be NULL if the application does not require this information.</param>
            /// <param name="lpLastAccessTime">A pointer to a FILETIME structure to receive the date and time the file or directory was last accessed. The last access time includes the last time the file or directory was written to, read from, or, in the case of executable files, run. This parameter can be NULL if the application does not require this information.</param>
            /// <param name="lpLastWriteTime">A pointer to a FILETIME structure to receive the date and time the file or directory was last written to, truncated, or overwritten (for example, with WriteFile or SetEndOfFile). This date and time is not updated when file attributes or security descriptors are changed. This parameter can be NULL if the application does not require this information.</param>
            /// <returns>If the function succeeds, the return value is nonzero.
            /// If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool GetFileTime(IntPtr handle, ref long lpCreationTime, ref long lpLastAccessTime, ref long lpLastWriteTime);

            /// <summary>
            /// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
            /// For additional load options, use the LoadLibraryEx function.
            /// </summary>
            /// <param name="lpFileName">
            /// The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file). The name specified is the file name of the module and is not related to the name stored in the library module itself, as specified by the LIBRARY keyword in the module-definition (.def) file.
            /// If the string specifies a full path, the function searches only that path for the module.
            /// If the string specifies a relative path or a module name without a path, the function uses a standard search strategy to find the module; for more information, see the Remarks.
            /// If the function cannot find the module, the function fails. When specifying a path, be sure to use backslashes (\), not forward slashes (/). For more information about paths, see Naming a File or Directory.
            /// If the string specifies a module name without a path and the file name extension is omitted, the function appends the default library extension .dll to the module name. To prevent the function from appending .dll to the module name, include a trailing point character (.) in the module name string.
            /// </param>
            /// <returns>
            /// If the function succeeds, the return value is a handle to the module.
            /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern IntPtr LoadLibrary(string lpFileName);

            /// <summary>
            /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
            /// </summary>
            /// <param name="hModule">
            /// A handle to the DLL module that contains the function or variable. The LoadLibrary, LoadLibraryEx, LoadPackagedLibrary, or GetModuleHandle function returns this handle.
            /// The GetProcAddress function does not retrieve addresses from modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag. For more information, see LoadLibraryEx.
            /// </param>
            /// <param name="procedureName">
            /// The function or variable name, or the function's ordinal value. If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.
            /// </param>
            /// <returns>
            /// If the function succeeds, the return value is the address of the exported function or variable.
            /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

            /// <summary>
            /// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count. When the reference count reaches zero, the module is unloaded from the address space of the calling process and the handle is no longer valid.
            /// </summary>
            /// <param name="hModule">A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or GetModuleHandleEx function returns this handle.</param>
            /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool FreeLibrary(IntPtr hModule);

            /// <summary>
            /// Enables an application to inform the system that it is in use, thereby preventing the system from entering sleep or turning off the display while the application is running.
            /// </summary>
            /// <param name="flags">The thread's execution requirements.</param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool SetThreadExecutionState(ES flags);

            /// <summary>
            /// Retrieves the full name of the executable image for the specified process.
            /// </summary>
            /// <param name="processHandle">A handle to the process. This handle must be created with the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.</param>
            /// <param name="flags">0=The name should use the Win32 path format.</param>
            /// <param name="exeName"></param>
            /// <param name="count"></param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool QueryFullProcessImageName(IntPtr processHandle, int flags, StringBuilder exeName, ref int count);

            /// <summary>
            /// Opens an existing local process object.
            /// </summary>
            /// <param name="desiredAccess">The access to the process object. This access right is checked against the security descriptor for the process. This parameter can be one or more of the process access rights. </param>
            /// <param name="inheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
            /// <param name="processID">The identifier of the local process to be opened.</param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern IntPtr OpenProcess(ACCESS_PROCESS desiredAccess, bool inheritHandle, int processID);

            /// <summary>
            /// Opens an existing thread object.
            /// </summary>
            /// <param name="desiredAccess">The access to the thread object. This access right is checked against the security descriptor for the thread. This parameter can be one or more of the thread access rights.</param>
            /// <param name="inheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
            /// <param name="threadID">The identifier of the thread to be opened.</param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern IntPtr OpenThread(ACCESS_THREAD desiredAccess, bool inheritHandle, int threadID);

            /// <summary>
            /// Suspends the specified thread.
            /// </summary>
            /// <param name="handle">A handle to the thread that is to be suspended. </param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern int SuspendThread(IntPtr handle);

            /// <summary>
            /// Decrements a thread's suspend count. When the suspend count is decremented to zero, the execution of the thread is resumed.
            /// </summary>
            /// <param name="handle">A handle to the thread to be restarted. </param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern int ResumeThread(IntPtr handle);

            /// <summary>
            /// Closes an open object handle.
            /// </summary>
            /// <param name="handle">A valid handle to an open object.</param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern int CloseHandle(IntPtr handle);

            /// <summary>
            /// Retrieves information about a range of pages within the virtual address space of a specified process.
            /// </summary>
            /// <param name="handle">A handle to the process whose memory information is queried. The handle must have been opened with the PROCESS_QUERY_INFORMATION access right, which enables using the handle to read information from the process object. For more information, see Process Security and Access Rights.</param>
            /// <param name="address">A pointer to the base address of the region of pages to be queried. This value is rounded down to the next page boundary. To determine the size of a page on the host computer, use the GetSystemInfo function.</param>
            /// <param name="buffer">A pointer to a MEMORY_BASIC_INFORMATION structure in which information about the specified page range is returned.</param>
            /// <param name="bufferSize">The size of the buffer pointed to by the lpBuffer parameter, in bytes.</param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern IntPtr VirtualQueryEx(IntPtr handle, IntPtr address, IntPtr buffer, IntPtr bufferSize);

            /// <summary>
            /// Reserves or commits a region of memory within the virtual address space of a specified process. The function initializes the memory it allocates to zero, unless MEM_RESET is used.
            /// </summary>
            /// <param name="hProcess">The handle to a process. The function allocates memory within the virtual address space of this process.</param>
            /// <param name="dwSize">The size of the region of memory to allocate, in bytes.</param>
            /// <param name="flAllocationType">The type of memory allocation. This parameter must contain one of the following values.</param>
            /// <param name="flProtect"></param>
            /// <param name="lpAddress"></param>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, MEM_STATE flAllocationType, MEM_PROTECT flProtect);

            /// <summary>
            /// Releases, decommits, or releases and decommits a region of memory within the virtual address space of a specified process.
            /// </summary>
            /// <param name="hProcess">A handle to a process. The function frees memory within the virtual address space of the process. </param>
            /// <param name="pointer">A pointer to the starting address of the region of memory to be freed. </param>
            /// <param name="dwSize">The size of the region of memory to free, in bytes. </param>
            /// <param name="dwFreeType">The type of free operation. This parameter can be one of the following values. </param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr pointer, uint dwSize, MEM_STATE dwFreeType);

            /// <summary>
            /// Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the operation fails.
            /// </summary>
            /// <param name="handle">A handle to the process with memory that is being read. The handle must have PROCESS_VM_READ access to the process.</param>
            /// <param name="address">A pointer to the base address in the specified process from which to read.</param>
            /// <param name="buffer">A pointer to a buffer that receives the contents from the address space of the specified process.</param>
            /// <param name="bufferSize">The number of bytes to be read from the specified process.</param>
            /// <param name="bytesRead">A pointer to a variable that receives the number of bytes transferred into the specified buffer. If lpNumberOfBytesRead is NULL, the parameter is ignored.</param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool ReadProcessMemory(IntPtr handle, IntPtr address, IntPtr buffer, IntPtr bufferSize, out IntPtr bytesRead);

            /// <summary>
            /// Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the operation fails.
            /// </summary>
            /// <param name="handle">A handle to the process with memory that is being read. The handle must have PROCESS_VM_READ access to the process.</param>
            /// <param name="address">A pointer to the base address in the specified process from which to read.</param>
            /// <param name="buffer">A pointer to a buffer that receives the contents from the address space of the specified process.</param>
            /// <param name="bufferSize">The number of bytes to be read from the specified process.</param>
            /// <param name="bytesRead">A pointer to a variable that receives the number of bytes transferred into the specified buffer. If lpNumberOfBytesRead is NULL, the parameter is ignored.</param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool ReadProcessMemory(IntPtr handle, IntPtr address, ref byte[] buffer, IntPtr bufferSize, out IntPtr bytesRead);


            /// <summary>
            /// Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation fails.
            /// </summary>
            /// <param name="handle">A handle to the process memory to be modified. The handle must have PROCESS_VM_WRITE and PROCESS_VM_OPERATION access to the process.</param>
            /// <param name="address">A pointer to the base address in the specified process to which data is written. Before data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for write access, and if it is not accessible, the function fails.</param>
            /// <param name="buffer">A pointer to the buffer that contains data to be written in the address space of the specified process.</param>
            /// <param name="bufferSize">The number of bytes to be written to the specified process.</param>
            /// <param name="bytesWritten">A pointer to a variable that receives the number of bytes transferred into the specified process. This parameter is optional. If lpNumberOfBytesWritten is NULL, the parameter is ignored.</param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool WriteProcessMemory(IntPtr handle, IntPtr address, IntPtr buffer, IntPtr bufferSize, out IntPtr bytesWritten);

            /// <summary>
            /// Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation fails.
            /// </summary>
            /// <param name="handle">A handle to the process memory to be modified. The handle must have PROCESS_VM_WRITE and PROCESS_VM_OPERATION access to the process.</param>
            /// <param name="address">A pointer to the base address in the specified process to which data is written. Before data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for write access, and if it is not accessible, the function fails.</param>
            /// <param name="buffer">A pointer to the buffer that contains data to be written in the address space of the specified process.</param>
            /// <param name="bufferSize">The number of bytes to be written to the specified process.</param>
            /// <param name="bytesWritten">A pointer to a variable that receives the number of bytes transferred into the specified process. This parameter is optional. If lpNumberOfBytesWritten is NULL, the parameter is ignored.</param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool WriteProcessMemory(IntPtr handle, IntPtr address, byte[] buffer, IntPtr bufferSize, out IntPtr bytesWritten);

            /// <summary>
            /// Retrieves system timing information. On a multiprocessor system, the values returned are the sum of the designated times across all processors.
            /// </summary>
            /// <param name="lpIdleTime"></param>
            /// <param name="lpKernelTime"></param>
            /// <param name="lpUserTime"></param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool GetSystemTimes(out long lpIdleTime, out long lpKernelTime, out long lpUserTime);

            /// <summary>
            /// retrieves the current value of the high-resolution performance counter
            /// </summary>
            /// <param name="lpPerformanceCount"></param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

            /// <summary>
            /// retrieves the frequency of the high-resolution performance counter, if one exists
            /// </summary>
            /// <param name="lpFrequency"></param>
            /// <returns></returns>
            [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool QueryPerformanceFrequency(out long lpFrequency);

            /// <summary>
            /// Creates or opens a file or I/O device. The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, and pipe. The function returns a handle that can be used to access the file or device for various types of I/O depending on the file or device and the flags and attributes specified.
            /// </summary>
            /// <param name="lpFileName">The name of the file or device to be created or opened.</param>
            /// <param name="dwDesiredAccess">The requested access to the file or device, which can be summarized as read, write, both or neither zero).</param>
            /// <param name="dwShareMode">The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table). Access requests to attributes or extended attributes are not affected by this flag.</param>
            /// <param name="pSecurityAttributes">A pointer to a SECURITY_ATTRIBUTES structure that contains two separate but related data members: an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes. This parameter can be NULL.</param>
            /// <param name="dwCreationDisposition">An action to take on a file or device that exists or does not exist. For devices other than files, this parameter is usually set to OPEN_EXISTING.</param>
            /// <param name="dwFlagsAndAttributes">The file or device attributes and flags, FILE_ATTRIBUTE_NORMAL being the most common default value for files. This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*). All other file attributes override FILE_ATTRIBUTE_NORMAL.</param>
            /// <param name="hTemplateFile">A valid handle to a template file with the GENERIC_READ access right. The template file supplies file attributes and extended attributes for the file that is being created. This parameter can be NULL.</param>
            /// <returns>If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot. If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Auto)]
            public static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPTStr)]string lpFileName, ACCESS dwDesiredAccess, FileShare dwShareMode, IntPtr pSecurityAttributes, DISPOSITION dwCreationDisposition, FILE_FLAG dwFlagsAndAttributes, IntPtr hTemplateFile);

            /// <summary>Creates a symbolic link.</summary>
            /// <param name="lpSymlinkFileName">The symbolic link to be created.</param>
            /// <param name="lpTargetFileName">The name of the target for the symbolic link to be created.</param>
            /// <param name="dwFlags">Indicates whether the link target, lpTargetFileName, is a directory.</param>
            /// <returns></returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Auto)]
            public static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, LINKTYPE dwFlags);

            /// <summary>
            /// Allocates a new console for the calling process.
            /// </summary>
            /// <returns></returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool AllocConsole();

            /// <summary>Retrieves a handle to the specified standard device (standard input, standard output, or standard error).</summary>
            /// <param name="nStdHandle">The standard device. </param>
            /// <returns></returns>
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetStdHandle(STD_HANDLE nStdHandle);

            /// <summary>Sets the handle for the specified standard device (standard input, standard output, or standard error).</summary>
            /// <param name="nStdHandle">The standard device for which the handle is to be set. </param>
            /// <param name="handle">The handle.</param>
            [DllImport("kernel32.dll")]
            public static extern void SetStdHandle(STD_HANDLE nStdHandle, IntPtr handle);

            /// <summary>
            /// Sets the console icon.
            /// </summary>
            /// <param name="hIcon">The icon.</param>
            /// <returns></returns>
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool SetConsoleIcon(IntPtr hIcon);

            /// <summary>
            /// Detaches the calling process from its console.
            /// </summary>
            /// <returns></returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool FreeConsole();

            /// <summary>
            /// Retrieves the name of a volume on a computer. FindFirstVolume is used to begin scanning the volumes of a computer.
            /// </summary>
            /// <param name="lpszVolumeName">A pointer to a buffer that receives a null-terminated string that specifies a volume GUID path for the first volume that is found.</param>
            /// <param name="cchBufferLength">The length of the buffer to receive the volume GUID path, in TCHARs.</param>
            /// <returns>If the function succeeds, the return value is a search handle used in a subsequent call to the FindNextVolume and FindVolumeClose functions.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr FindFirstVolume([MarshalAs(UnmanagedType.LPTStr)]StringBuilder lpszVolumeName, int cchBufferLength);

            /// <summary>
            /// Continues a volume search started by a call to the FindFirstVolume function. FindNextVolume finds one volume per call.
            /// </summary>
            /// <param name="hFindVolume">The volume search handle returned by a previous call to the FindFirstVolume function.</param>
            /// <param name="lpszVolumeName">A pointer to a string that receives the volume GUID path that is found.</param>
            /// <param name="cchBufferLength">The length of the buffer that receives the volume GUID path, in TCHARs.</param>
            /// <returns>If the function succeeds, the return value is nonzero.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool FindNextVolume(IntPtr hFindVolume, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder lpszVolumeName, int cchBufferLength);

            /// <summary>
            /// Closes the specified volume search handle. The FindFirstVolume and FindNextVolume functions use this search handle to locate volumes.
            /// </summary>
            /// <param name="hFindVolume">The volume search handle to be closed. This handle must have been previously opened by the FindFirstVolume function.</param>
            /// <returns>If the function succeeds, the return value is nonzero.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern bool FindVolumeClose(IntPtr hFindVolume);

            /// <summary>
            /// Retrieves the name of a mounted folder on the specified volume. FindFirstVolumeMountPoint is used to begin scanning the mounted folders on a volume.
            /// </summary>
            /// <param name="lpszRootPathName">A volume GUID path for the volume to scan for mounted folders. A trailing backslash is required.</param>
            /// <param name="lpszVolumeMountPoint">A pointer to a buffer that receives the name of the first mounted folder that is found.</param>
            /// <param name="cchBufferLength">The length of the buffer that receives the path to the mounted folder, in TCHARs.</param>
            /// <returns>If the function succeeds, the return value is a search handle used in a subsequent call to the FindNextVolumeMountPoint and FindVolumeMountPointClose functions.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr FindFirstVolumeMountPoint([MarshalAs(UnmanagedType.LPTStr)]string lpszRootPathName, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder lpszVolumeMountPoint, int cchBufferLength);

            /// <summary>
            /// Continues a mounted folder search started by a call to the FindFirstVolumeMountPoint function. FindNextVolumeMountPoint finds one mounted folder per call.
            /// </summary>
            /// <param name="hFindVolumeMountPoint">A mounted folder search handle returned by a previous call to the FindFirstVolumeMountPoint function.</param>
            /// <param name="lpszVolumeMountPoint">A pointer to a buffer that receives the name of the mounted folder that is found.</param>
            /// <param name="cchBufferLength">The length of the buffer that receives the mounted folder name, in TCHARs.</param>
            /// <returns>If the function succeeds, the return value is nonzero.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool FindNextVolumeMountPoint(IntPtr hFindVolumeMountPoint, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder lpszVolumeMountPoint, int cchBufferLength);

            /// <summary>
            /// Closes the specified mounted folder search handle. The FindFirstVolumeMountPoint and FindNextVolumeMountPoint functions use this search handle to locate mounted folders on a specified volume.
            /// </summary>
            /// <param name="hFindVolumeMountPoint">The mounted folder search handle to be closed. This handle must have been previously opened by the FindFirstVolumeMountPoint function.</param>
            /// <returns>If the function succeeds, the return value is nonzero.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool FindVolumeMountPointClose(IntPtr hFindVolumeMountPoint);

            /// <summary>
            /// Retrieves information about MS-DOS device names. The function can obtain the current mapping for a particular MS-DOS device name. The function can also obtain a list of all existing MS-DOS device names.
            /// </summary>
            /// <param name="lpDeviceName">An MS-DOS device name string specifying the target of the query. The device name cannot have a trailing backslash; for example, use "C:", not "C:\".
            /// This parameter can be NULL. In that case, the QueryDosDevice function will store a list of all existing MS-DOS device names into the buffer pointed to by lpTargetPath.</param>
            /// <param name="lpTargetPath">A pointer to a buffer that will receive the result of the query. The function fills this buffer with one or more null-terminated strings. The final null-terminated string is followed by an additional NULL.
            /// <br />
            /// If lpDeviceName is non-NULL, the function retrieves information about the particular MS-DOS device specified by lpDeviceName. The first null-terminated string stored into the buffer is the current mapping for the device. The other null-terminated strings represent undeleted prior mappings for the device.
            /// <br />
            /// If lpDeviceName is NULL, the function retrieves a list of all existing MS-DOS device names. Each null-terminated string stored into the buffer is the name of an existing MS-DOS device, for example, \Device\HarddiskVolume1 or \Device\Floppy0.
            /// </param>
            /// <param name="ucchMax">The maximum number of TCHARs that can be stored into the buffer pointed to by lpTargetPath.</param>
            /// <returns>If the function succeeds, the return value is the number of TCHARs stored into the buffer pointed to by lpTargetPath.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int QueryDosDevice([MarshalAs(UnmanagedType.LPTStr)]string lpDeviceName, IntPtr lpTargetPath, int ucchMax);

            /// <summary>
            /// Retrieves the volume mount point where the specified path is mounted.
            /// </summary>
            /// <param name="lpszFileName">A pointer to the input path string. Both absolute and relative file and directory names, for example "..", are acceptable in this path.</param>
            /// <param name="lpszVolumePathName">A pointer to a string that receives the volume mount point for the input path.</param>
            /// <param name="cchBufferLength">The length of the output buffer, in TCHARs.</param>
            /// <returns>If the function succeeds, the return value is nonzero.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool GetVolumePathName([MarshalAs(UnmanagedType.LPTStr)]string lpszFileName, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder lpszVolumePathName, int cchBufferLength);

            /// <summary>
            /// Retrieves a list of drive letters and mounted folder paths for the specified volume.
            /// </summary>
            /// <param name="lpszVolumeName">A volume GUID path for the volume. A volume GUID path is of the form "\\?\Volume{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}\".</param>
            /// <param name="lpszVolumePathNames">A pointer to a buffer that receives the list of drive letters and mounted folder paths. The list is an array of null-terminated strings terminated by an additional NULL character. If the buffer is not large enough to hold the complete list, the buffer holds as much of the list as possible.</param>
            /// <param name="cchBufferLength">The length of the lpszVolumePathNames buffer, in TCHARs, including all NULL characters.</param>
            /// <param name="lpcchReturnLength">If the call is successful, this parameter is the number of TCHARs copied to the lpszVolumePathNames buffer. Otherwise, this parameter is the size of the buffer required to hold the complete list, in TCHARs.</param>
            /// <returns>If the function succeeds, the return value is nonzero.</returns>
            [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool GetVolumePathNamesForVolumeName([MarshalAs(UnmanagedType.LPTStr)]string lpszVolumeName, IntPtr lpszVolumePathNames, int cchBufferLength, ref int lpcchReturnLength);

            /// <summary>
            /// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer passed into the function. It can come from a message table resource in an already-loaded module. Or the caller can ask the function to search the system's message table resource(s) for the message definition. The function finds the message definition in a message table resource based on a message identifier and a language identifier. The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.
            /// </summary>
            /// <param name="dwFlags"></param>
            /// <param name="lpSource">A handle to the module that contains the message table to search. Or a pointer to a string that consists of unformatted message text. It will be scanned for inserts and formatted accordingly.</param>
            /// <param name="dwMessageId">The message identifier for the requested message. This parameter is ignored if dwFlags includes FORMAT_MESSAGE_FROM_STRING.</param>
            /// <param name="dwLanguageId">The language identifier for the requested message. This parameter is ignored if dwFlags includes FORMAT_MESSAGE_FROM_STRING.</param>
            /// <param name="lpBuffer">A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes FORMAT_MESSAGE_ALLOCATE_BUFFER, the function allocates a buffer using the LocalAlloc function, and places the pointer to the buffer at the address specified in lpBuffer.</param>
            /// <param name="nSize">If the FORMAT_MESSAGE_ALLOCATE_BUFFER flag is not set, this parameter specifies the size of the output buffer, in TCHARs. If FORMAT_MESSAGE_ALLOCATE_BUFFER is set, this parameter specifies the minimum number of TCHARs to allocate for an output buffer.</param>
            /// <param name="args">An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second argument; and so on.</param>
            /// <returns></returns>
            [DllImport(@"kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Auto)]
            public static extern uint FormatMessage(FORMAT_MESSAGE dwFlags, IntPtr lpSource, ErrorCode dwMessageId, uint dwLanguageId, StringBuilder lpBuffer, uint nSize, IntPtr args);

            /// <summary>
            /// Sets the last-error code for the calling thread.
            /// </summary>
            /// <param name="errorCode">The last-error code for the thread.</param>
            [DllImport(@"kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
            public static extern void SetLastError(ErrorCode errorCode);

            /// <summary>
            /// Retrieves the Remote Desktop Services session that is currently attached to the physical console. The physical console is the monitor, keyboard, and mouse. Note that it is not necessary that Remote Desktop Services be running for this function to succeed.
            /// </summary>
            /// <returns>The session identifier of the session that is attached to the physical console. If there is no session attached to the physical console, (for example, if the physical console session is in the process of being attached or detached), this function returns 0xFFFFFFFF.</returns>
            [DllImport(@"kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern int WTSGetActiveConsoleSessionId();

            /// <summary>
            /// Retrieves information about MS-DOS device names. The function can obtain the current mapping for a particular MS-DOS device name. The function can also obtain a list of all existing MS-DOS device names.
            /// </summary>
            /// <param name="lpDeviceName">An MS-DOS device name string specifying the target of the query. The device name cannot have a trailing backslash; for example, use "C:", not "C:\".
            /// This parameter can be NULL. In that case, the QueryDosDevice function will store a list of all existing MS-DOS device names into the buffer pointed to by lpTargetPath.</param>
            /// <param name="lpTargetPath"><para>A pointer to a buffer that will receive the result of the query. The function fills this buffer with one or more null-terminated strings. The final null-terminated string is followed by an additional NULL.</para>
            /// <para>If lpDeviceName is non-NULL, the function retrieves information about the particular MS-DOS device specified by lpDeviceName. The first null-terminated string stored into the buffer is the current mapping for the device. The other null-terminated strings represent undeleted prior mappings for the device.</para>
            /// <para>If lpDeviceName is NULL, the function retrieves a list of all existing MS-DOS device names. Each null-terminated string stored into the buffer is the name of an existing MS-DOS device, for example, \Device\HarddiskVolume1 or \Device\Floppy0.</para></param>
            /// <param name="ucchMax">The maximum number of TCHARs that can be stored into the buffer pointed to by lpTargetPath.</param>
            /// <returns>If the function succeeds, the return value is the number of TCHARs stored into the buffer pointed to by lpTargetPath.</returns>
            [DllImport(@"kernel32.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern uint QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);

            #endregion
        }
    }
}
