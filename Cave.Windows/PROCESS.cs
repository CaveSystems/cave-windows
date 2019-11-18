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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using Cave.IO;

namespace Cave.Windows
{
    /// <summary>
    /// provides access to windows processes
    /// </summary>
    public class PROCESS : IComparable, IDisposable
    {
        /// <summary>
        /// checks whether a process is still running or not
        /// </summary>
        /// <param name="processID"></param>
        /// <returns></returns>
        public static bool IsRunning(int processID)
        {
            PROCESSLIST l_List = new PROCESSLIST();
            l_List.Update();
            bool result = (Array.IndexOf(l_List.Items, processID) > -1);
            l_List.Dispose();
            return result;
        }

        /// <summary>
        /// Obtains the executable name of the process
        /// </summary>
        /// <param name="processID"></param>
        /// <param name="throwExException"></param>
        /// <returns></returns>
        public static string GetExecutableName(int processID, bool throwExException)
        {
            Exception l_Error = null;
            StringBuilder result = new StringBuilder(65536);
            int len = result.Capacity;

            if ((Environment.OSVersion.Platform == PlatformID.Win32NT) && (Environment.OSVersion.Version >= new Version("6.0")))
            {
                IntPtr l_ProcessHandle = KERNEL32.SafeNativeMethods.OpenProcess(ACCESS_PROCESS.QUERY_INFORMATION, false, processID);
                if (l_ProcessHandle == IntPtr.Zero)
                {
                    //try limited
                    l_ProcessHandle = KERNEL32.SafeNativeMethods.OpenProcess(ACCESS_PROCESS.QUERY_LIMITED_INFORMATION, false, processID);
                }
                if (l_ProcessHandle == IntPtr.Zero)
                {
                    l_Error = new Win32ErrorException();

                }
                else if (!KERNEL32.SafeNativeMethods.QueryFullProcessImageName(l_ProcessHandle, 0, result, ref len))
                {
                    l_Error = new Win32ErrorException();
                }
                KERNEL32.SafeNativeMethods.CloseHandle(l_ProcessHandle);
            }
            else
            {
                IntPtr l_ProcessHandle = KERNEL32.SafeNativeMethods.OpenProcess(ACCESS_PROCESS.QUERY_INFORMATION | ACCESS_PROCESS.VM_READ, false, processID);
                if (l_ProcessHandle == IntPtr.Zero)
                {
                    l_Error = new Win32ErrorException();
                }
                else
                {
                    len = PSAPI.GetModuleFileNameEx(l_ProcessHandle, IntPtr.Zero, result, len);
                    if (len == 0) l_Error = new Win32ErrorException();
                }
                KERNEL32.SafeNativeMethods.CloseHandle(l_ProcessHandle);
            }
            if (throwExException && (l_Error != null)) throw l_Error;
            return result.ToString();
        }

        /// <summary>
        /// simple struct for process memory block informations
        /// </summary>
        public struct MemoryLocation
        {
            /// <summary>
            /// creates a new MemoryLocation
            /// </summary>
            /// <param name="start"></param>
            /// <param name="end"></param>
            public MemoryLocation(IntPtr start, IntPtr end)
            {
                Start = start;
                End = end;
            }

            /// <summary>
            /// obtains the start address of the memory block
            /// </summary>
            public IntPtr Start;

            /// <summary>
            /// obtains the end address of the memory block
            /// </summary>
            public IntPtr End;

            /// <summary>
            /// obtains the size the memory block
            /// </summary>
            public long Size { get { return End.ToInt64() - Start.ToInt64(); } }

            /// <summary>
            /// Provides "start-end"
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return Start.ToString("X") + "-" + End.ToString("X");
            }
        }

        /// <summary>
        /// obtains the fileName of the process
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// obtains the name of the process
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// obtains the commandline used to start
        /// </summary>
        public string CommandLine { get; } = "";

        /// <summary>
        /// obtains the process id
        /// </summary>
        public int ProcessID { get; } = -1;

        private Process m_Process = null;
        private Stack<int> m_SuspendedThreadIDs = new Stack<int>();

        /// <summary>
        /// creates a new process instance from a wmi managed process object
        /// </summary>
        /// <param name="processID"></param>
        public PROCESS(int processID)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(new ManagementScope(), new ObjectQuery("SELECT Name,CommandLine,ExecutablePath,ProcessID FROM Win32_Process WHERE ProcessID=" + processID.ToString()));
            int count = 0;
            foreach (ManagementObject obj in searcher.Get())
            {
                if (++count != 1) throw new Exception(string.Format("Multiple results for one ProcessID!"));
                ProcessID = processID;
                Name = (string)obj["Name"];
                CommandLine = (string)obj["CommandLine"];
                FileName = (string)obj["ExecutablePath"];
            }
            if (count != 1) throw new Exception(string.Format("ProcessID not found!"));
            searcher.Dispose();

            if (Name == null) throw new Exception(string.Format("ProcessName could not be retrieved !"));
            if (Name.ToLower().EndsWith(".exe")) Name = Name.Substring(0, Name.Length - 4);
            if (!File.Exists(FileName))
            {
                FileName = GetExecutableName(processID, false);
                if (FileName == "") FileName = null;
            }
        }

        /// <summary>
        /// creates a new process instance from a .net process
        /// </summary>
        public PROCESS(Process process)
            : this(process.Id)
        {
            m_Process = process;
        }

        /// <summary>
        /// obtains the process
        /// </summary>
        /// <returns></returns>
        public Process Process
        {
            get
            {
                if (m_Process == null)
                {
                    m_Process = Process.GetProcessById(ProcessID);
                }
                return m_Process;
            }
        }

        /// <summary>
        /// Obtains whether the process is running or not
        /// </summary>
        public bool IsRunning()
        {
            return IsRunning(ProcessID);
        }

        /// <summary>
        /// retrieves the name process
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// compares two csProcess instances
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            PROCESS other = obj as PROCESS;
            if (ReferenceEquals(other, null)) return false;

            return
                (other.ProcessID == ProcessID) &&
                (other.Name == Name);
        }

        /// <summary>
        /// retrieves the hash code for the process
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// compares two instances
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return -1;
            return Name.ToLower().CompareTo(((PROCESS)obj).Name.ToString().ToLower());
        }

        /// <summary>
        /// suspends a process
        /// </summary>
        /// <returns></returns>
        public bool Suspend()
        {
            try
            {
                //suspend all threads
                foreach (ProcessThread l_ProcessThread in Process.Threads)
                {
                    IntPtr l_ThreadHandle = KERNEL32.SafeNativeMethods.OpenThread(ACCESS_THREAD.SUSPEND_RESUME, false, l_ProcessThread.Id);
                    if (l_ThreadHandle != IntPtr.Zero)
                    {
                        bool l_Suspended = KERNEL32.SafeNativeMethods.SuspendThread(l_ThreadHandle) != -1;
                        if (l_Suspended)
                        {
                            m_SuspendedThreadIDs.Push(l_ProcessThread.Id);
                        }
                        KERNEL32.SafeNativeMethods.CloseHandle(l_ThreadHandle);
                    }
                }
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// resumes a process
        /// </summary>
        /// <returns></returns>
        public bool Resume()
        {
            //resume all threads
            try
            {
                bool allResumed = true;
                while (m_SuspendedThreadIDs.Count > 0)
                {
                    IntPtr l_ThreadHandle = KERNEL32.SafeNativeMethods.OpenThread(ACCESS_THREAD.SUSPEND_RESUME, false, m_SuspendedThreadIDs.Pop());
                    if (l_ThreadHandle != IntPtr.Zero)
                    {
                        allResumed &= KERNEL32.SafeNativeMethods.ResumeThread(l_ThreadHandle) != -1;
                        KERNEL32.SafeNativeMethods.CloseHandle(l_ThreadHandle);
                    }
                }
                return allResumed;
            }
            catch { return false; }
        }

        /// <summary>
        /// retrieves whether a process is suspended or not
        /// </summary>
        public bool IsSuspended { get { return m_SuspendedThreadIDs.Count != 0; } }

        /// <summary>
        /// retrieves the data memoryblocks of the 32 bit process
        /// </summary>
        /// <returns></returns>
        IList<MemoryLocation> GetProcessMemoryLocations32()
        {
            //create result array
            List<MemoryLocation> l_Memory = new List<MemoryLocation>();
            //retrieve the memory base address of the process
            long address = Process.MainModule.BaseAddress.ToInt64();
            //get process handle
            IntPtr handle = KERNEL32.SafeNativeMethods.OpenProcess(ACCESS_PROCESS.ALaCCESS_NT, false, ProcessID);
            //retrieve size of struct
            IntPtr size = new IntPtr(Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION_32)));
            //create unmanages struct
            IntPtr buffer = Marshal.AllocHGlobal(size);
            //read all memory blocks of the process
            while (true)
            {
                //set start address
                IntPtr start = new IntPtr(address);
                //retrieve memory info
                IntPtr result = KERNEL32.SafeNativeMethods.VirtualQueryEx(handle, start, buffer, size);
                //didnt get anymore info ? -> end
                if (result == IntPtr.Zero) break;
                //marshal unmanaged struct
                MEMORY_BASIC_INFORMATION_32 l_MemoryInfo = (MEMORY_BASIC_INFORMATION_32)Marshal.PtrToStructure(buffer, typeof(MEMORY_BASIC_INFORMATION_32));
                //is private data memory ?
                if ((l_MemoryInfo.State == MEM_STATE.COMMIT) &&
                    (l_MemoryInfo.Protect == MEM_PROTECT.PAGE_READWRITE) &&
                    (l_MemoryInfo.Type == MEM_TYPE.PRIVATE))
                {
                    //yes, add to resultset
                    IntPtr l_End = new IntPtr(l_MemoryInfo.BaseAddress + l_MemoryInfo.RegionSize);
                    l_Memory.Add(new MemoryLocation(start, l_End));
                }
                //go to next memory block
                address += l_MemoryInfo.RegionSize;
            }
            //free unmanaged struct
            Marshal.FreeHGlobal(buffer);
            //free handle
            KERNEL32.SafeNativeMethods.CloseHandle(handle);
            return l_Memory;
        }

        /// <summary>
        /// retrieves the data memoryblocks of the 64 bit process
        /// </summary>
        /// <returns></returns>
        IList<MemoryLocation> GetProcessMemoryLocations64()
        {
            //create result array
            List<MemoryLocation> l_Memory = new List<MemoryLocation>();
            //retrieve the memory base address of the process
            long address = Process.MainModule.BaseAddress.ToInt64();
            //get process handle
            IntPtr handle = KERNEL32.SafeNativeMethods.OpenProcess(ACCESS_PROCESS.ALaCCESS_NT, false, ProcessID);
            //retrieve size of struct
            IntPtr size = new IntPtr(Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION_64)));
            //create unmanages struct
            IntPtr buffer = Marshal.AllocHGlobal(size);
            //read all memory blocks of the process
            while (true)
            {
                //set start address
                IntPtr start = new IntPtr(address);
                //retrieve memory info
                IntPtr result = KERNEL32.SafeNativeMethods.VirtualQueryEx(handle, start, buffer, size);
                //didnt get anymore info ? -> end
                if (result == IntPtr.Zero) break;
                //marshal unmanaged struct
                MEMORY_BASIC_INFORMATION_64 l_MemoryInfo = (MEMORY_BASIC_INFORMATION_64)Marshal.PtrToStructure(buffer, typeof(MEMORY_BASIC_INFORMATION_64));
                //is private data memory ?
                if ((l_MemoryInfo.State == MEM_STATE.COMMIT) &&
                    (l_MemoryInfo.Protect == MEM_PROTECT.PAGE_READWRITE) &&
                    (l_MemoryInfo.Type == MEM_TYPE.PRIVATE))
                {
                    //yes, add to resultset
                    IntPtr l_End = new IntPtr((long)(l_MemoryInfo.BaseAddress + l_MemoryInfo.RegionSize));
                    l_Memory.Add(new MemoryLocation(start, l_End));
                }
                //go to next memory block
                address += (long)l_MemoryInfo.RegionSize;
            }
            //free unmanaged struct
            Marshal.FreeHGlobal(buffer);
            //free handle
            KERNEL32.SafeNativeMethods.CloseHandle(handle);
            return l_Memory;
        }

        /// <summary>
        /// retrieves the data memoryblocks of the 32 bit process
        /// </summary>
        /// <returns></returns>
        public IList<MemoryLocation> GetProcessMemoryLocations()
        {
            switch (IntPtr.Size)
            {
                case 4: return GetProcessMemoryLocations32();
                case 8: return GetProcessMemoryLocations64();
                default: throw new NotImplementedException(string.Format("Unknown process bitsize!"));
            }
        }

        /// <summary>
        /// retrieves a process all access handle for memory dumping
        /// </summary>
        public IntPtr GetProcessAccessHandle(ACCESS_PROCESS desiredAccess)
        {
            return KERNEL32.SafeNativeMethods.OpenProcess(desiredAccess, false, ProcessID);
        }

        /// <summary>
        /// closes the process access handle retrieved by GetProcessAccessHandle()
        /// </summary>
        public void CloseProcessAccessHandle(IntPtr processAccessHandle)
        {
            KERNEL32.SafeNativeMethods.CloseHandle(processAccessHandle);
        }

        /// <summary>
        /// retrieves a process memory block
        /// </summary>
        /// <param name="processAccessHandle"></param>
        /// <param name="processMemoryLocation"></param>
        /// <returns></returns>
        public byte[] GetProcessMemoryData(IntPtr processAccessHandle, MemoryLocation processMemoryLocation)
        {
            //calculate size of block
            IntPtr size = new IntPtr(processMemoryLocation.End.ToInt64() - processMemoryLocation.Start.ToInt64());
            //get handle of process

            //get unmanaged byte buffer
            IntPtr buffer = Marshal.AllocHGlobal(size);
            IntPtr bytesRead;
            byte[] result = null;
            //read process memory
            if (KERNEL32.SafeNativeMethods.ReadProcessMemory(processAccessHandle, processMemoryLocation.Start, buffer, size, out bytesRead))
            {
                //if memory block could be retrieved, copy it to a managed buffer
                result = new byte[bytesRead.ToInt32()];
                Marshal.Copy(buffer, result, 0, bytesRead.ToInt32());
            }
            Marshal.FreeHGlobal(buffer);
            return result;
        }

        /// <summary>
        /// retrieves a process memory block as ansi string
        /// </summary>
        /// <param name="processAccessHandle"></param>
        /// <param name="processMemoryLocation"></param>
        /// <returns></returns>
        public string GetProcessMemoryDataAsAnsiString(IntPtr processAccessHandle, MemoryLocation processMemoryLocation)
        {
            //calculate size of block
            IntPtr size = new IntPtr(processMemoryLocation.End.ToInt64() - processMemoryLocation.Start.ToInt64());
            //get handle of process

            //get unmanaged byte buffer
            IntPtr buffer = Marshal.AllocHGlobal(size);
            IntPtr bytesRead;
            string result = null;
            //read process memory
            if (KERNEL32.SafeNativeMethods.ReadProcessMemory(processAccessHandle, processMemoryLocation.Start, buffer, size, out bytesRead))
            {
                //if memory block could be retrieved, copy it to a managed string
                result = Marshal.PtrToStringAnsi(buffer, bytesRead.ToInt32());
            }
            Marshal.FreeHGlobal(buffer);
            return result;
        }

        #region IDisposable Member

        /// <summary>
        /// disposes a PROCESS
        /// </summary>
        public void Dispose()
        {
            if (m_Process != null)
            {
                m_Process.Dispose();
                m_Process = null;
            }
            if (m_SuspendedThreadIDs != null)
            {
                if (m_SuspendedThreadIDs.Count > 0) Resume();
                m_SuspendedThreadIDs = null;
            }
        }

        #endregion
    }
}

#endif