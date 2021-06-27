using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Contains information about a range of pages in the virtual address space of a process. The VirtualQuery and VirtualQueryEx functions use this structure. 64 bit version.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MEMORY_BASIC_INFORMATION64
    {
        /// <summary></summary>
        public ulong BaseAddress;
        /// <summary></summary>
        public ulong AllocationBase;
        /// <summary></summary>
        public uint AllocationProtect;
        /// <summary></summary>
        public uint __alignment1;
        /// <summary></summary>
        public ulong RegionSize;
        /// <summary></summary>
        public MEM_STATE State;
        /// <summary></summary>
        public MEM_PROTECT Protect;
        /// <summary></summary>
        public MEM_TYPE Type;
        /// <summary></summary>
        public uint __alignment2;
    }
}
