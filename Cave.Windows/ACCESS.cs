using System;
using System.Diagnostics.CodeAnalysis;

namespace Cave.Windows
{
    /// <summary>
    /// common microsoft windows access rights
    /// </summary>
    
    [Flags]
    [SuppressMessage("Design", "CA1069", Justification = "Duplicate enum values in winapi.")]
    public enum ACCESS : int
    {
        /// <summary>
        /// The right to delete the object.
        /// </summary>
        DELETE = 0x00010000,

        /// <summary>
        /// The right to read the information in the object's security descriptor, not including the information in the system access control list  (SACL).
        /// </summary>
        READ_CONTROL = 0x00020000,

        /// <summary>
        /// The right to modify the discretionary access control list  (DACL) in the object's security descriptor.
        /// </summary>
        WRITE_DAC = 0x00040000,

        /// <summary>
        /// The right to change the owner in the object's security descriptor.
        /// </summary>
        WRITE_OWNER = 0x00080000,

        /// <summary>
        /// The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state. Some object types do not support this access right.
        /// </summary>
        SYNCHRONIZE = 0x00100000,

        /// <summary>
        /// Combines DELETE, READ_CONTROL, WRITE_DAC, and WRITE_OWNER access.
        /// </summary>
        STANDARD_RIGHTS_REQUIRED = 0x000F0000,

        /// <summary>
        /// Combines DELETE, READ_CONTROL, WRITE_DAC, WRITE_OWNER, and SYNCHRONIZE access.
        /// </summary>
        STANDARD_RIGHTS_ALL = 0x001F0000,

        /// <summary>
        /// Grants SPECIFIC_RIGHTS_ALL permissions.
        /// </summary>
        SPECIFIC_RIGHTS_ALL = 0x0000FFFF,

        /// <summary>
        /// Grants standard ACCESS_SYSTEM_SECURITY permissions.
        /// </summary>
        ACCESS_SYSTEM_SECURITY = 0x01000000,

        /// <summary>
        /// Grants standard MAXIMUM_ALLOWED permissions.
        /// </summary>
        MAXIMUM_ALLOWED = 0x02000000,

        /// <summary>
        /// Read access
        /// </summary>
        GENERIC_READ = unchecked((int)0x80000000),

        /// <summary>
        /// Write access
        /// </summary>
        GENERIC_WRITE = 0x40000000,

        /// <summary>
        /// Execute access
        /// </summary>
        GENERIC_EXECUTE = 0x20000000,

        /// <summary>
        /// Read, write, and execute access
        /// </summary>
        GENERIC_ALL = 0x10000000,

        /// <summary>
        /// Currently defined to equal READ_CONTROL.
        /// </summary>
        STANDARD_RIGHTS_WRITE = READ_CONTROL,

        /// <summary>
        /// Includes READ_CONTROL, which is the right to read the information in the file or directory object's security descriptor. This does not include the information in the SACL.
        /// </summary>
        STANDARD_RIGHTS_READ = READ_CONTROL,

        /// <summary>
        /// Currently defined to equal READ_CONTROL.
        /// </summary>
        STANDARD_RIGHTS_EXECUTE = READ_CONTROL,

        /// <summary>
        /// For a file object, the right to read the corresponding file data. For a directory object, the right to read the corresponding directory data.
        /// </summary>
        FILE_READ_DATA = 0x0001,

        /// <summary>
        /// For a directory, the right to list the contents of the directory.
        /// </summary>
        FILE_LIST_DIRECTORY = FILE_READ_DATA,

        /// <summary>
        /// For a file object, the right to write data to the file. For a directory object, the right to create a file in the directory (FILE_ADD_FILE).
        /// </summary>
        FILE_WRITE_DATA = 0x0002,

        /// <summary>
        /// For a directory, the right to create a file in the directory.
        /// </summary>
        FILE_ADD_FILE = FILE_WRITE_DATA,

        /// <summary>
        /// For a file object, the right to append data to the file. (For local files, write operations will not overwrite existing data if this flag is specified without FILE_WRITE_DATA.) For a directory object, the right to create a subdirectory (FILE_ADD_SUBDIRECTORY).
        /// </summary>
        FILE_APPEND_DATA = 0x0004,

        /// <summary>
        /// For a directory, the right to create a subdirectory.
        /// </summary>
        FILE_ADD_SUBDIRECTORY = FILE_APPEND_DATA,

        /// <summary>
        /// For a named pipe, the right to create a pipe.
        /// </summary>
        FILE_CREATE_PIPE_INSTANCE = FILE_APPEND_DATA,

        /// <summary>
        /// The right to read extended file attributes.
        /// </summary>
        FILE_READ_EA = 0x0008,

        /// <summary>
        /// The right to write extended file attributes.
        /// </summary>
        FILE_WRITE_EA = 0x0010,

        /// <summary>
        /// For a native code file, the right to execute the file. This access right given to scripts may cause the script to be executable, depending on the script interpreter.
        /// </summary>
        FILE_EXECUTE = 0x0020,

        /// <summary>
        /// For a directory, the right to traverse the directory. By default, users are assigned the BYPASS_TRAVERSE_CHECKING privilege, which ignores the FILE_TRAVERSE access right. See the remarks in File Security and Access Rights for more information.
        /// </summary>
        FILE_TRAVERSE = FILE_EXECUTE,

        /// <summary>
        /// For a directory, the right to delete a directory and all the files it contains, including read-only files.
        /// </summary>
        FILE_DELETE_CHILD = 0x0040,

        /// <summary>
        /// The right to read file attributes.
        /// </summary>
        FILE_READ_ATTRIBUTES = 0x80,

        /// <summary>
        /// The right to write file attributes.
        /// </summary>
        FILE_WRITE_ATTRIBUTES = 0x100,

        /// <summary>
        /// All possible access rights for a file.
        /// </summary>
        FILE_ALaCCESS = (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x1FF),

        /// <summary>
        /// FILE_EXECUTE | FILE_READ_ATTRIBUTES | STANDARD_RIGHTS_EXECUTE | SYNCHRONIZE
        /// </summary>
        FILE_GENERIC_EXECUTE = FILE_EXECUTE | FILE_READ_ATTRIBUTES | STANDARD_RIGHTS_EXECUTE | SYNCHRONIZE,

        /// <summary>
        /// FILE_READ_ATTRIBUTES | FILE_READ_DATA | FILE_READ_EA | STANDARD_RIGHTS_READ | SYNCHRONIZE
        /// </summary>
        FILE_GENERIC_READ = FILE_READ_ATTRIBUTES | FILE_READ_DATA | FILE_READ_EA | STANDARD_RIGHTS_READ | SYNCHRONIZE,

        /// <summary>
        /// FILE_APPEND_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_DATA | FILE_WRITE_EA | STANDARD_RIGHTS_WRITE | SYNCHRONIZE
        /// </summary>
        FILE_GENERIC_WRITE = FILE_APPEND_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_DATA | FILE_WRITE_EA | STANDARD_RIGHTS_WRITE | SYNCHRONIZE,

        /// <summary>
        /// Required to attach a primary token to a process. The SE_ASSIGNPRIMARYTOKEN_NAME privilege is also required to accomplish this task.
        /// </summary>
        TOKEN_ASSIGN_PRIMARY = 0x0001,

        /// <summary>
        /// Required to duplicate an access token.
        /// </summary>
        TOKEN_DUPLICATE = 0x0002,

        /// <summary>
        /// Required to attach an impersonation access token to a process.
        /// </summary>
        TOKEN_IMPERSONATE = 0x0004,

        /// <summary>
        /// Required to query an access token.
        /// </summary>
        TOKEN_QUERY = 0x0008,

        /// <summary>
        /// Required to query the source of an access token.
        /// </summary>
        TOKEN_QUERY_SOURCE = 0x0010,

        /// <summary>
        /// Required to enable or disable the privileges in an access token.
        /// </summary>
        TOKEN_ADJUST_PRIVILEGES = 0x0020,

        /// <summary>
        /// Required to adjust the attributes of the groups in an access token.
        /// </summary>
        TOKEN_ADJUST_GROUPS = 0x0040,

        /// <summary>
        /// Required to change the default owner, primary group, or DACL of an access token.
        /// </summary>
        TOKEN_ADJUST_DEFAULT = 0x0080,

        /// <summary>
        /// Required to adjust the session ID of an access token. The SE_TCB_NAME privilege is required.
        /// </summary>
        TOKEN_ADJUST_SESSIONID = 0x0100,

    }
}
