using System;

namespace Cave.Windows
{
    /// <summary>
    /// microsoft windows process specific access rights
    /// </summary>
    
    [Flags]
    public enum ACCESS_PROCESS : uint
    {
        /// <summary>right to terminate the process</summary>
        TERMINATE = 0x0001,

        /// <summary>right to create a thread</summary>
        CREATE_THREAD = 0x0002,

        /// <summary>right to set the session id of the process</summary>
        SET_SESSIONID = 0x0004,

        /// <summary></summary>
        VM_OPERATION = 0x0008,

        /// <summary>right to read the virtual memory of the process</summary>
        VM_READ = 0x0010,

        /// <summary>right to write the virtual memory of the process</summary>
        VM_WRITE = 0x0020,

        /// <summary></summary>
        DUP_HANDLE = 0x0040,

        /// <summary>right to create a process</summary>
        CREATE_PROCESS = 0x0080,

        /// <summary>right to set the quota of the process</summary>
        SET_QUOTA = 0x0100,

        /// <summary></summary>
        SET_INFORMATION = 0x0200,

        /// <summary>right to query information about a process</summary>
        QUERY_INFORMATION = 0x0400,

        /// <summary>right to suspend and resume a process</summary>
        SUSPEND_RESUME = 0x0800,

        /// <summary></summary>
        QUERY_LIMITED_INFORMATION = 0x1000,

        /// <summary>full access rights for nt..xp processes</summary>
        ALaCCESS_NT = (ACCESS.STANDARD_RIGHTS_REQUIRED | ACCESS.SYNCHRONIZE | 0xFFF),

        /// <summary>full access rights for vista+ processes</summary>
        ALaCCESS_VISTA = (ACCESS.STANDARD_RIGHTS_REQUIRED | ACCESS.SYNCHRONIZE | 0xFFFF),
    }
}
