using System;

namespace Cave.Windows
{
    /// <summary>
    /// thread-specific access rights.
    /// </summary>
    
    [Flags]
    public enum ACCESS_THREAD : uint
    {
        /// <summary>right to terminate a thread</summary>
        TERMINATE = (0x0001),

        /// <summary>right to suspend and resume a thread</summary>
        SUSPEND_RESUME = (0x0002),

        /// <summary>right to retrieve the threadcontext</summary>
        GET_CONTEXT = (0x0008),

        /// <summary>right to set the threadcontext</summary>
        SET_CONTEXT = (0x0010),

        /// <summary>right to set the threadinformation</summary>
        SET_INFORMATION = (0x0020),

        /// <summary>right to retrieve the threadinformation</summary>
        QUERY_INFORMATION = (0x0040),

        /// <summary></summary>
        SET_THREAD_TOKEN = (0x0080),

        /// <summary></summary>
        IMPERSONATE = (0x0100),

        /// <summary></summary>
        DIRECT_IMPERSONATION = (0x0200),

        /// <summary></summary>
        SET_LIMITED_INFORMATION = (0x0400),

        /// <summary></summary>
        THREAD_QUERY_LIMITED_INFORMATION = (0x0800),

        /// <summary>full access rights for nt..xp threads</summary>
        ALL_ACCESS_NT = (ACCESS.STANDARD_RIGHTS_REQUIRED | ACCESS.SYNCHRONIZE | 0x3FF),

        /// <summary>full access rights for vista+ threads</summary>
        ALL_ACCESS_VISTA = (ACCESS.STANDARD_RIGHTS_REQUIRED | ACCESS.SYNCHRONIZE | 0xFFFF),
    }
}
