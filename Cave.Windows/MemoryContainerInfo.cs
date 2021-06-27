using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// provides a memory container for shared memory access
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Ansi)]
    public struct MemoryContainerInfo
    {
        /// <summary>The identifier</summary>
        public uint ID;

        /// <summary>The writer identifier</summary>
        public uint WriterID;

        /// <summary>The current writer position</summary>
        public int Position;

        /// <summary>The length of the container</summary>
        public int Length;

        /// <summary>The pointer to the data</summary>
        public IntPtr Data;

        /// <summary>The name of the container</summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string Name;

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString() => "[" + ID + "] " + Name + " " + Position + ":" + Length;
    }
}
