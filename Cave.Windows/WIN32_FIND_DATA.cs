using System.IO;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Contains information about the file that is found by the FindFirstFile, FindFirstFileEx, or FindNextFile function.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 4+8+8+8+8+4+4+260+14, Pack = 1)]
    public struct WIN32_FIND_DATA
    {
        /// <summary>
        /// The file attributes of a file.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public FileAttributes FileAttributes;

        /// <summary>
        /// A <see cref="FILETIME"/> structure that specifies when a file or directory was created.
        /// </summary>
        public FILETIME CreationTime;

        /// <summary>
        /// A <see cref="FILETIME"/> structure.For a file, the structure specifies when the file was last read from, written to, or for executable files, run.
        /// For a directory, the structure specifies when the directory is created. If the underlying file system does not support last access time, this member is zero.
        /// On the FAT file system, the specified date for both files and directories is correct, but the time of day is always set to midnight.
        /// </summary>
        public FILETIME LastAccessTime;

        /// <summary>
        /// A <see cref="FILETIME"/> structure.
        /// For a file, the structure specifies when the file was last written to, truncated, or overwritten, for example, when WriteFile or SetEndOfFile are used. The date and time are not updated when file attributes or security descriptors are changed.
        /// For a directory, the structure specifies when the directory is created. If the underlying file system does not support last write time, this member is zero.
        /// </summary>
        public FILETIME LastWriteTime;

        /// <summary>
        /// A <see cref="FILESIZE"/> structure representing the size of the file or 0 for directories.
        /// </summary>
        public FILESIZE FileSize;

        /// <summary>
        /// If the FileAttributes member includes the FILE_ATTRIBUTE_REPARSE_POINT attribute, this member specifies the reparse point tag.
        /// Otherwise, this value is undefined and should not be used.
        /// </summary>
        public uint Reserved0;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public uint Reserved1;

        /// <summary>
        /// The name of the file. (This is again subject to the MAX_PATH limitation!)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = KERNEL32.MAX_PATH)]
        public string FileName;

        /// <summary>
        /// An alternative name for the file.
        /// This name is in the classic 8.3 file name format.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = KERNEL32.MAX_SHORT_NAME)]
        public string Alternate;
    }
}
