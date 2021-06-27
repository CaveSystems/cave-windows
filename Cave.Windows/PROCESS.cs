using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
            var list = new PROCESSLIST();
            list.Update();
            var result = (Array.IndexOf(list.Items, processID) > -1);
            list.Dispose();
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
            Exception error = null;
            var result = new StringBuilder(65536);
            var len = result.Capacity;

            if ((Environment.OSVersion.Platform == PlatformID.Win32NT) && (Environment.OSVersion.Version >= new Version("6.0")))
            {
                var processHandle = KERNEL32.SafeNativeMethods.OpenProcess(ACCESS_PROCESS.QUERY_INFORMATION, false, processID);
                if (processHandle == IntPtr.Zero)
                {
                    //try limited
                    processHandle = KERNEL32.SafeNativeMethods.OpenProcess(ACCESS_PROCESS.QUERY_LIMITED_INFORMATION, false, processID);
                }
                if (processHandle == IntPtr.Zero)
                {
                    error = new Win32ErrorException();

                }
                else if (!KERNEL32.SafeNativeMethods.QueryFullProcessImageName(processHandle, 0, result, ref len))
                {
                    error = new Win32ErrorException();
                }
                KERNEL32.SafeNativeMethods.CloseHandle(processHandle);
            }
            else
            {
                var processHandle = KERNEL32.SafeNativeMethods.OpenProcess(ACCESS_PROCESS.QUERY_INFORMATION | ACCESS_PROCESS.VM_READ, false, processID);
                if (processHandle == IntPtr.Zero)
                {
                    error = new Win32ErrorException();
                }
                else
                {
                    len = PSAPI.GetModuleFileNameEx(processHandle, IntPtr.Zero, result, len);
                    if (len == 0) error = new Win32ErrorException();
                }
                KERNEL32.SafeNativeMethods.CloseHandle(processHandle);
            }
            if (throwExException && (error != null)) throw error;
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
            public long Size => End.ToInt64() - Start.ToInt64();

            /// <summary>
            /// Provides "start-end"
            /// </summary>
            /// <returns></returns>
            public override string ToString() => Start.ToString("X") + "-" + End.ToString("X");
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

        Process process = null;
        Stack<int> suspendedThreadIDs = new();

        /// <summary>
        /// creates a new process instance from a wmi managed process object
        /// </summary>
        /// <param name="processID"></param>
        [SuppressMessage("Maintainability", "CA1507")]
        public PROCESS(int processID)
        {
            var searcher = new ManagementObjectSearcher(new ManagementScope(), new ObjectQuery("SELECT Name,CommandLine,ExecutablePath,ProcessID FROM Win32_Process WHERE ProcessID=" + processID.ToString()));
            var count = 0;
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
            : this(process.Id) => this.process = process;

        /// <summary>
        /// obtains the process
        /// </summary>
        /// <returns></returns>
        public Process Process
        {
            get
            {
                if (process == null)
                {
                    process = Process.GetProcessById(ProcessID);
                }
                return process;
            }
        }

        /// <summary>
        /// Obtains whether the process is running or not
        /// </summary>
        public bool IsRunning() => IsRunning(ProcessID);

        /// <summary>
        /// retrieves the name process
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;

        /// <summary>
        /// compares two csProcess instances
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is not PROCESS other) return false;

            return
                (other.ProcessID == ProcessID) &&
                (other.Name == Name);
        }

        /// <summary>
        /// retrieves the hash code for the process
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => ToString().GetHashCode();

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
                foreach (ProcessThread processThread in Process.Threads)
                {
                    var threadHandle = KERNEL32.SafeNativeMethods.OpenThread(ACCESS_THREAD.SUSPEND_RESUME, false, processThread.Id);
                    if (threadHandle != IntPtr.Zero)
                    {
                        var suspended = KERNEL32.SafeNativeMethods.SuspendThread(threadHandle) != -1;
                        if (suspended)
                        {
                            suspendedThreadIDs.Push(processThread.Id);
                        }
                        KERNEL32.SafeNativeMethods.CloseHandle(threadHandle);
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
                var allResumed = true;
                while (suspendedThreadIDs.Count > 0)
                {
                    var threadHandle = KERNEL32.SafeNativeMethods.OpenThread(ACCESS_THREAD.SUSPEND_RESUME, false, suspendedThreadIDs.Pop());
                    if (threadHandle != IntPtr.Zero)
                    {
                        allResumed &= KERNEL32.SafeNativeMethods.ResumeThread(threadHandle) != -1;
                        KERNEL32.SafeNativeMethods.CloseHandle(threadHandle);
                    }
                }
                return allResumed;
            }
            catch { return false; }
        }

        /// <summary>
        /// retrieves whether a process is suspended or not
        /// </summary>
        public bool IsSuspended => suspendedThreadIDs.Count != 0;

        /// <summary>
        /// retrieves the data memoryblocks of the 32 bit process
        /// </summary>
        /// <returns></returns>
        IList<MemoryLocation> GetProcessMemoryLocations32()
        {
            //create result array
            var memory = new List<MemoryLocation>();
            //retrieve the memory base address of the process
            var address = Process.MainModule.BaseAddress.ToInt64();
            //get process handle
            var handle = KERNEL32.SafeNativeMethods.OpenProcess(ACCESS_PROCESS.ALaCCESS_NT, false, ProcessID);
            //retrieve size of struct
            var size = new IntPtr(Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION_32)));
            //create unmanages struct
            var buffer = Marshal.AllocHGlobal(size);
            //read all memory blocks of the process
            while (true)
            {
                //set start address
                var start = new IntPtr(address);
                //retrieve memory info
                var result = KERNEL32.SafeNativeMethods.VirtualQueryEx(handle, start, buffer, size);
                //didnt get anymore info ? -> end
                if (result == IntPtr.Zero) break;
                //marshal unmanaged struct
                var memoryInfo = (MEMORY_BASIC_INFORMATION_32)Marshal.PtrToStructure(buffer, typeof(MEMORY_BASIC_INFORMATION_32));
                //is private data memory ?
                if ((memoryInfo.State == MEM_STATE.COMMIT) &&
                    (memoryInfo.Protect == MEM_PROTECT.PAGE_READWRITE) &&
                    (memoryInfo.Type == MEM_TYPE.PRIVATE))
                {
                    //yes, add to resultset
                    var end = new IntPtr(memoryInfo.BaseAddress + memoryInfo.RegionSize);
                    memory.Add(new MemoryLocation(start, end));
                }
                //go to next memory block
                address += memoryInfo.RegionSize;
            }
            //free unmanaged struct
            Marshal.FreeHGlobal(buffer);
            //free handle
            KERNEL32.SafeNativeMethods.CloseHandle(handle);
            return memory;
        }

        /// <summary>
        /// retrieves the data memoryblocks of the 64 bit process
        /// </summary>
        /// <returns></returns>
        IList<MemoryLocation> GetProcessMemoryLocations64()
        {
            //create result array
            var memory = new List<MemoryLocation>();
            //retrieve the memory base address of the process
            var address = Process.MainModule.BaseAddress.ToInt64();
            //get process handle
            var handle = KERNEL32.SafeNativeMethods.OpenProcess(ACCESS_PROCESS.ALaCCESS_NT, false, ProcessID);
            //retrieve size of struct
            var size = new IntPtr(Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION_64)));
            //create unmanages struct
            var buffer = Marshal.AllocHGlobal(size);
            //read all memory blocks of the process
            while (true)
            {
                //set start address
                var start = new IntPtr(address);
                //retrieve memory info
                var result = KERNEL32.SafeNativeMethods.VirtualQueryEx(handle, start, buffer, size);
                //didnt get anymore info ? -> end
                if (result == IntPtr.Zero) break;
                //marshal unmanaged struct
                var memoryInfo = (MEMORY_BASIC_INFORMATION_64)Marshal.PtrToStructure(buffer, typeof(MEMORY_BASIC_INFORMATION_64));
                //is private data memory ?
                if ((memoryInfo.State == MEM_STATE.COMMIT) &&
                    (memoryInfo.Protect == MEM_PROTECT.PAGE_READWRITE) &&
                    (memoryInfo.Type == MEM_TYPE.PRIVATE))
                {
                    //yes, add to resultset
                    var end = new IntPtr((long)(memoryInfo.BaseAddress + memoryInfo.RegionSize));
                    memory.Add(new MemoryLocation(start, end));
                }
                //go to next memory block
                address += (long)memoryInfo.RegionSize;
            }
            //free unmanaged struct
            Marshal.FreeHGlobal(buffer);
            //free handle
            KERNEL32.SafeNativeMethods.CloseHandle(handle);
            return memory;
        }

        /// <summary>
        /// retrieves the data memoryblocks of the 32 bit process
        /// </summary>
        /// <returns></returns>
        public IList<MemoryLocation> GetProcessMemoryLocations()
        {
            return IntPtr.Size switch
            {
                4 => GetProcessMemoryLocations32(),
                8 => GetProcessMemoryLocations64(),
                _ => throw new NotImplementedException(string.Format("Unknown process bitsize!")),
            };
        }

        /// <summary>
        /// retrieves a process all access handle for memory dumping
        /// </summary>
        public IntPtr GetProcessAccessHandle(ACCESS_PROCESS desiredAccess) => KERNEL32.SafeNativeMethods.OpenProcess(desiredAccess, false, ProcessID);

        /// <summary>
        /// closes the process access handle retrieved by GetProcessAccessHandle()
        /// </summary>
        public void CloseProcessAccessHandle(IntPtr processAccessHandle) => KERNEL32.SafeNativeMethods.CloseHandle(processAccessHandle);

        /// <summary>
        /// retrieves a process memory block
        /// </summary>
        /// <param name="processAccessHandle"></param>
        /// <param name="processMemoryLocation"></param>
        /// <returns></returns>
        public byte[] GetProcessMemoryData(IntPtr processAccessHandle, MemoryLocation processMemoryLocation)
        {
            //calculate size of block
            var size = new IntPtr(processMemoryLocation.End.ToInt64() - processMemoryLocation.Start.ToInt64());
            //get handle of process

            //get unmanaged byte buffer
            var buffer = Marshal.AllocHGlobal(size);
            byte[] result = null;
            //read process memory
            if (KERNEL32.SafeNativeMethods.ReadProcessMemory(processAccessHandle, processMemoryLocation.Start, buffer, size, out var bytesRead))
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
            var size = new IntPtr(processMemoryLocation.End.ToInt64() - processMemoryLocation.Start.ToInt64());
            //get handle of process

            //get unmanaged byte buffer
            var buffer = Marshal.AllocHGlobal(size);
            string result = null;
            //read process memory
            if (KERNEL32.SafeNativeMethods.ReadProcessMemory(processAccessHandle, processMemoryLocation.Start, buffer, size, out var bytesRead))
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
            if (process != null)
            {
                process.Dispose();
                process = null;
            }
            if (suspendedThreadIDs != null)
            {
                if (suspendedThreadIDs.Count > 0) Resume();
                suspendedThreadIDs = null;
            }
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
