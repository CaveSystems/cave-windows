using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Contains information about a range of pages in the virtual address space of a process. The VirtualQuery and VirtualQueryEx functions use this structure.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MEMORY_BASIC_INFORMATION_32
    {
        /// <summary>Address of queried memory page.</summary>
        public uint BaseAddress;
        /// <summary>Base address of allocation. It's different (typically less) to BaseAddress when user allocate more then one page length memory block, and change attributes of a part of allocated block.</summary>
        public uint AllocationBase;
        /// <summary>Access type on memory allocation</summary>
        public MEM_PROTECT AllocationProtect;
        /// <summary>Size of queried region, in bytes.</summary>
        public uint RegionSize;
        /// <summary>State of memory block</summary>
        public MEM_STATE State;
        /// <summary>Current protection of queried memory block.</summary>
        public MEM_PROTECT Protect;
        /// <summary> Type of queried memory block</summary>
        public MEM_TYPE Type;
    }

    /// <summary>
    /// Contains information about a range of pages in the virtual address space of a process. The VirtualQuery and VirtualQueryEx functions use this structure.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MEMORY_BASIC_INFORMATION_64
    {
        /// <summary>Address of queried memory page.</summary>
        public ulong BaseAddress;
        /// <summary>Base address of allocation. It's different (typically less) to BaseAddress when user allocate more then one page length memory block, and change attributes of a part of allocated block.</summary>
        public ulong AllocationBase;
        /// <summary></summary>
        public MEM_PROTECT AllocationProtect;

        /// <summary>
        /// Do not use
        /// </summary>
        [Obsolete("May not be used")]
        public uint Alignment1;

        /// <summary>Size of queried region, in bytes.</summary>
        public ulong RegionSize;
        /// <summary>State of memory block</summary>
        public MEM_STATE State;
        /// <summary>Current protection of queried memory block.</summary>
        public MEM_PROTECT Protect;
        /// <summary> Type of queried memory block</summary>
        public MEM_TYPE Type;

        /// <summary>
        /// Do not use
        /// </summary>
        [Obsolete("May not be used")]
        public uint Alignment2;
    }
}
