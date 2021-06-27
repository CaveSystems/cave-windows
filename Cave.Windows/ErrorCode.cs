namespace Cave.Windows
{
    /// <summary>
    /// Provides system error codes
    /// </summary>
    public enum ErrorCode : int
    {
        /// <summary>
        /// The operation completed successfully.
        /// </summary>
        SUCCESS = 0x0,

        /// <summary>
        /// The operation completed successfully.
        /// </summary>
        NO_ERROR = SUCCESS,

        /// <summary>
        /// Incorrect function.
        /// </summary>
        INVALID_FUNCTION = 0x1,

        /// <summary>
        /// The system cannot find the file  specified .
        /// </summary>
        FILE_NOT_FOUND = 0x2,

        /// <summary>
        /// The system cannot find the path  specified .
        /// </summary>
        PATH_NOT_FOUND = 0x3,

        /// <summary>
        /// The system cannot open the file.
        /// </summary>
        TOO_MANY_OPEN_FILES = 0x4,

        /// <summary>
        /// Access is denied.
        /// </summary>
        ACCESS_DENIED = 0x5,

        /// <summary>
        /// The handle is invalid.
        /// </summary>
        INVALID_HANDLE = 0x6,

        /// <summary>
        /// The storage control blocks were destroyed.
        /// </summary>
        ARENA_TRASHED = 0x7,

        /// <summary>
        /// Not enough storage is available to process this command.
        /// </summary>
        NOT_ENOUGH_MEMORY = 0x8,

        /// <summary>
        /// The storage control block address is invalid.
        /// </summary>
        INVALID_BLOCK = 0x9,

        /// <summary>
        /// The environment is incorrect.
        /// </summary>
        BAD_ENVIRONMENT = 0xa,

        /// <summary>
        /// An attempt was made to load a program with an incorrect format.
        /// </summary>
        BAD_FORMAT = 0xb,

        /// <summary>
        /// The access code is invalid.
        /// </summary>
        INVALID_ACCESS = 0xc,

        /// <summary>
        /// The data is invalid.
        /// </summary>
        INVALID_DATA = 0xd,

        /// <summary>
        /// Not enough storage is available to complete this operation.
        /// </summary>
        OUTOFMEMORY = 0xe,

        /// <summary>
        /// The system cannot find the drive  specified .
        /// </summary>
        INVALID_DRIVE = 0xf,

        /// <summary>
        /// The directory cannot be removed.
        /// </summary>
        CURRENT_DIRECTORY = 0x10,

        /// <summary>
        /// The system cannot move the file to a different disk drive.
        /// </summary>
        NOT_SAME_DEVICE = 0x11,

        /// <summary>
        /// There are no more files.
        /// </summary>
        NO_MORE_FILES = 0x12,

        /// <summary>
        /// The media is write protected.
        /// </summary>
        WRITE_PROTECT = 0x13,

        /// <summary>
        /// The system cannot find the device  specified .
        /// </summary>
        BAD_UNIT = 0x14,

        /// <summary>
        /// The device is not ready.
        /// </summary>
        NOT_READY = 0x15,

        /// <summary>
        /// The device does not recognize the command.
        /// </summary>
        BAD_COMMAND = 0x16,

        /// <summary>
        /// Data error (cyclic redundancy check).
        /// </summary>
        CRC = 0x17,

        /// <summary>
        /// The program issued a command but the command length is incorrect.
        /// </summary>
        BAD_LENGTH = 0x18,

        /// <summary>
        /// The drive cannot locate a specific area or track on the disk.
        /// </summary>
        SEEK = 0x19,

        /// <summary>
        /// The specified disk or diskette cannot be accessed.
        /// </summary>
        NOT_DOS_DISK = 0x1a,

        /// <summary>
        /// The drive cannot find the sector requested.
        /// </summary>
        SECTOR_NOT_FOUND = 0x1b,

        /// <summary>
        /// The printer is out of paper.
        /// </summary>
        OUT_OF_PAPER = 0x1c,

        /// <summary>
        /// The system cannot write to the specified device.
        /// </summary>
        WRITE_FAULT = 0x1d,

        /// <summary>
        /// The system cannot read from the specified device.
        /// </summary>
        READ_FAULT = 0x1e,

        /// <summary>
        /// A device attached to the system is not functioning.
        /// </summary>
        GEN_FAILURE = 0x1f,

        /// <summary>
        /// The process cannot access the file because it is being used by another process.
        /// </summary>
        SHARING_VIOLATION = 0x20,

        /// <summary>
        /// The process cannot access the file because another process has locked a portion of the file.
        /// </summary>
        LOCK_VIOLATION = 0x21,

        /// <summary>
        /// The wrong diskette is in the drive. Insert %2 (Volume Serial Number: %3) into drive %1.
        /// </summary>
        WRONG_DISK = 0x22,

        /// <summary>
        /// Too many files opened for sharing.
        /// </summary>
        SHARING_BUFFER_EXCEEDED = 0x24,

        /// <summary>
        /// Reached the end of the file.
        /// </summary>
        HANDLE_EOF = 0x26,

        /// <summary>
        /// The disk is full.
        /// </summary>
        HANDLE_DISK_FULL = 0x27,

        /// <summary>
        /// The request is not supported.
        /// </summary>
        NOT_SUPPORTED = 0x32,

        /// <summary>
        /// The request is not supported.
        /// </summary>
        REM_NOT_LIST = 0x33,

        /// <summary>
        /// The request is not supported.
        /// </summary>
        DUname = 0x34,

        /// <summary>
        /// The network path was not found.
        /// </summary>
        BAD_NETPATH = 0x35,

        /// <summary>
        /// The network is busy.
        /// </summary>
        NETWORK_BUSY = 0x36,

        /// <summary>
        /// The specified network resource or device is no longer available.
        /// </summary>
        DEV_NOT_EXIST = 0x37,

        /// <summary>
        /// The network BIOS command limit has been reached.
        /// </summary>
        TOO_MANY_CMDS = 0x38,

        /// <summary>
        /// A network adapter hardware error occurred.
        /// </summary>
        ADAP_HDW_ERR = 0x39,

        /// <summary>
        /// The specified server cannot perform the requested operation.
        /// </summary>
        BAD_NET_RESP = 0x3a,

        /// <summary>
        /// An unexpected network error occurred.
        /// </summary>
        UNEXP_NET_ERR = 0x3b,

        /// <summary>
        /// The remote adapter is not compatible.
        /// </summary>
        BAD_REM_ADAP = 0x3c,

        /// <summary>
        /// The printer queue is full.
        /// </summary>
        PRINTQ_FULL = 0x3d,

        /// <summary>
        /// Space to store the file waiting to be printed is not available on the server.
        /// </summary>
        NO_SPOOL_SPACE = 0x3e,

        /// <summary>
        /// Your file waiting to be printed was deleted.
        /// </summary>
        PRINT_CANCELLED = 0x3f,

        /// <summary>
        /// The specified network name is no longer available.
        /// </summary>
        NETNAME_DELETED = 0x40,

        /// <summary>
        /// Network access is denied.
        /// </summary>
        NETWORK_ACCESS_DENIED = 0x41,

        /// <summary>
        /// The network resource type is not correct.
        /// </summary>
        BAD_DEV_TYPE = 0x42,

        /// <summary>
        /// The network name cannot be found.
        /// </summary>
        BAD_NET_NAME = 0x43,

        /// <summary>
        /// The name limit for the local computer network adapter card was exceeded.
        /// </summary>
        TOO_MANY_NAMES = 0x44,

        /// <summary>
        /// The network BIOS session limit was exceeded.
        /// </summary>
        TOO_MANY_SESS = 0x45,

        /// <summary>
        /// The remote server has been paused or is in the process of being started.
        /// </summary>
        SHARING_PAUSED = 0x46,

        /// <summary>
        /// The remote server has been paused or is in the process of being started.
        /// </summary>
        REQ_NOT_ACCEP = 0x47,

        /// <summary>
        /// The specified printer or disk device has been paused.
        /// </summary>
        REDIR_PAUSED = 0x48,

        /// <summary>
        /// The file exists.
        /// </summary>
        FILE_EXISTS = 0x50,

        /// <summary>
        /// The directory or file cannot be created.
        /// </summary>
        CANNOT_MAKE = 0x52,

        /// <summary>
        /// Fail on INT 24.
        /// </summary>
        FAIL_I24 = 0x53,

        /// <summary>
        /// Storage to process this request is not available.
        /// </summary>
        OUT_OF_STRUCTURES = 0x54,

        /// <summary>
        /// The local device name is already in use.
        /// </summary>
        ALREADY_ASSIGNED = 0x55,

        /// <summary>
        /// The specified network password is not correct.
        /// </summary>
        INVALID_PASSWORD = 0x56,

        /// <summary>
        /// The parameter is incorrect.
        /// </summary>
        INVALID_PARAMETER = 0x57,

        /// <summary>
        /// A write fault occurred on the network.
        /// </summary>
        NET_WRITE_FAULT = 0x58,

        /// <summary>
        /// The system cannot start another process at this time.
        /// </summary>
        NO_PROC_SLOTS = 0x59,

        /// <summary>
        /// Cannot create another system semaphore.
        /// </summary>
        TOO_MANY_SEMAPHORES = 0x64,

        /// <summary>
        /// The exclusive semaphore is owned by another process.
        /// </summary>
        EXCL_SEM_ALREADY_OWNED = 0x65,

        /// <summary>
        /// The semaphore is set and cannot be closed.
        /// </summary>
        SEM_IS_SET = 0x66,

        /// <summary>
        /// The semaphore cannot be set again.
        /// </summary>
        TOO_MANY_SEM_REQUESTS = 0x67,

        /// <summary>
        /// Cannot request exclusive semaphores at interrupt time.
        /// </summary>
        INVALID_AT_INTERRUPT_TIME = 0x68,

        /// <summary>
        /// The previous ownership of this semaphore has ended.
        /// </summary>
        SEM_OWNER_DIED = 0x69,

        /// <summary>
        /// Insert the diskette for drive %1.
        /// </summary>
        SEM_USER_LIMIT = 0x6a,

        /// <summary>
        /// The program stopped because an alternate diskette was not inserted.
        /// </summary>
        DISK_CHANGE = 0x6b,

        /// <summary>
        /// The disk is in use or locked by another process.
        /// </summary>
        DRIVE_LOCKED = 0x6c,

        /// <summary>
        /// The pipe has been ended.
        /// </summary>
        BROKEN_PIPE = 0x6d,

        /// <summary>
        /// The system cannot open the device or file  specified .
        /// </summary>
        OPEN_FAILED = 0x6e,

        /// <summary>
        /// The file name is too long.
        /// </summary>
        BUFFER_OVERFLOW = 0x6f,

        /// <summary>
        /// There is not enough space on the disk.
        /// </summary>
        DISK_FULL = 0x70,

        /// <summary>
        /// No more internal file identifiers available.
        /// </summary>
        NO_MORE_SEARCH_HANDLES = 0x71,

        /// <summary>
        /// The target internal file identifier is incorrect.
        /// </summary>
        INVALID_TARGET_HANDLE = 0x72,

        /// <summary>
        /// The IOCTL call made by the application program is not correct.
        /// </summary>
        INVALID_CATEGORY = 0x75,

        /// <summary>
        /// The verify-on-write switch parameter value is not correct.
        /// </summary>
        INVALID_VERIFY_SWITCH = 0x76,

        /// <summary>
        /// The system does not support the command requested.
        /// </summary>
        BAD_DRIVER_LEVEL = 0x77,

        /// <summary>
        /// This function is not supported on this system.
        /// </summary>
        CALnot_IMPLEMENTED = 0x78,

        /// <summary>
        /// The semaphore timeout period has expired.
        /// </summary>
        SEM_TIMEOUT = 0x79,

        /// <summary>
        /// The data area passed to a system call is too small.
        /// </summary>
        INSUFFICIENT_BUFFER = 0x7a,

        /// <summary>
        /// The fileName, directory name, or volume label syntax is incorrect.
        /// </summary>
        INVALID_NAME = 0x7b,

        /// <summary>
        /// The system call level is not correct.
        /// </summary>
        INVALID_LEVEL = 0x7c,

        /// <summary>
        /// The disk has no volume label.
        /// </summary>
        NO_VOLUME_LABEL = 0x7d,

        /// <summary>
        /// The specified module could not be found.
        /// </summary>
        MOD_NOT_FOUND = 0x7e,

        /// <summary>
        /// The specified procedure could not be found.
        /// </summary>
        PROC_NOT_FOUND = 0x7f,

        /// <summary>
        /// There are no child processes to wait for.
        /// </summary>
        WAIT_NO_CHILDREN = 0x80,

        /// <summary>
        /// The %1 application cannot be run in Win32 mode.
        /// </summary>
        CHILD_NOT_COMPLETE = 0x81,

        /// <summary>
        /// Attempt to use a file handle to an open disk partition for an operation other than raw disk I/O.
        /// </summary>
        DIRECT_ACCESS_HANDLE = 0x82,

        /// <summary>
        /// An attempt was made to move the file pointer before the beginning of the file.
        /// </summary>
        NEGATIVE_SEEK = 0x83,

        /// <summary>
        /// The file pointer cannot be set on the specified device or file.
        /// </summary>
        SEEK_ON_DEVICE = 0x84,

        /// <summary>
        /// A JOIN or SUBST command cannot be used for a drive that contains previously joined drives.
        /// </summary>
        IS_JOIN_TARGET = 0x85,

        /// <summary>
        /// An attempt was made to use a JOIN or SUBST command on a drive that has already been joined.
        /// </summary>
        IS_JOINED = 0x86,

        /// <summary>
        /// An attempt was made to use a JOIN or SUBST command on a drive that has already been substituted.
        /// </summary>
        IS_SUBSTED = 0x87,

        /// <summary>
        /// The system tried to delete the JOIN of a drive that is not joined.
        /// </summary>
        NOT_JOINED = 0x88,

        /// <summary>
        /// The system tried to delete the substitution of a drive that is not substituted.
        /// </summary>
        NOT_SUBSTED = 0x89,

        /// <summary>
        /// The system tried to join a drive to a directory on a joined drive.
        /// </summary>
        JOIN_TO_JOIN = 0x8a,

        /// <summary>
        /// The system tried to substitute a drive to a directory on a substituted drive.
        /// </summary>
        SUBST_TO_SUBST = 0x8b,

        /// <summary>
        /// The system tried to join a drive to a directory on a substituted drive.
        /// </summary>
        JOIN_TO_SUBST = 0x8c,

        /// <summary>
        /// The system tried to SUBST a drive to a directory on a joined drive.
        /// </summary>
        SUBST_TO_JOIN = 0x8d,

        /// <summary>
        /// The system cannot perform a JOIN or SUBST at this time.
        /// </summary>
        BUSY_DRIVE = 0x8e,

        /// <summary>
        /// The system cannot join or substitute a drive to or for a directory on the same drive.
        /// </summary>
        SAME_DRIVE = 0x8f,

        /// <summary>
        /// The directory is not a subdirectory of the root directory.
        /// </summary>
        DIR_NOT_ROOT = 0x90,

        /// <summary>
        /// The directory is not empty.
        /// </summary>
        DIR_NOT_EMPTY = 0x91,

        /// <summary>
        /// The path specified is being used in a substitute.
        /// </summary>
        IS_SUBST_PATH = 0x92,

        /// <summary>
        /// Not enough resources are available to process this command.
        /// </summary>
        IS_JOIN_PATH = 0x93,

        /// <summary>
        /// The path specified cannot be used at this time.
        /// </summary>
        PATH_BUSY = 0x94,

        /// <summary>
        /// The path specified cannot be used at this time.
        /// </summary>
        IS_SUBST_TARGET = 0x95,

        /// <summary>
        /// System trace information was not specified in your CONFIG.SYS file, or tracing is disallowed.
        /// </summary>
        SYSTEM_TRACE = 0x96,

        /// <summary>
        /// The number of specified semaphore events for DosMuxSemWait is not correct.
        /// </summary>
        INVALID_EVENT_COUNT = 0x97,

        /// <summary>
        /// DosMuxSemWait did not execute; too many semaphores are already set.
        /// </summary>
        TOO_MANY_MUXWAITERS = 0x98,

        /// <summary>
        /// The DosMuxSemWait list is not correct.
        /// </summary>
        INVALID_LIST_FORMAT = 0x99,

        /// <summary>
        /// The volume label you entered exceeds the label character limit of the target file system.
        /// </summary>
        LABEL_TOO_LONG = 0x9a,

        /// <summary>
        /// Cannot create another thread.
        /// </summary>
        TOO_MANY_TCBS = 0x9b,

        /// <summary>
        /// The recipient process has refused the signal.
        /// </summary>
        SIGNAL_REFUSED = 0x9c,

        /// <summary>
        /// The segment is already discarded and cannot be locked.
        /// </summary>
        DISCARDED = 0x9d,

        /// <summary>
        /// The segment is already unlocked.
        /// </summary>
        NOT_LOCKED = 0x9e,

        /// <summary>
        /// The address for the thread ID is not correct.
        /// </summary>
        BAD_THREADID_ADDR = 0x9f,

        /// <summary>
        /// One or more arguments are not correct.
        /// </summary>
        BAD_ARGUMENTS = 0xa0,

        /// <summary>
        /// The specified path is invalid.
        /// </summary>
        BAD_PATHNAME = 0xa1,

        /// <summary>
        /// A signal is already pending.
        /// </summary>
        SIGNAL_PENDING = 0xa2,

        /// <summary>
        /// No more threads can be created in the system.
        /// </summary>
        MAX_THRDS_REACHED = 0xa4,

        /// <summary>
        /// Unable to lock a region of a file.
        /// </summary>
        LOCK_FAILED = 0xa7,

        /// <summary>
        /// The requested resource is in use.
        /// </summary>
        BUSY = 0xaa,

        /// <summary>
        /// Device's command support detection is in progress.
        /// </summary>
        DEVICE_SUPPORT_IN_PROGRESS = 0xab,

        /// <summary>
        /// A lock request was not outstanding for the supplied cancel region.
        /// </summary>
        CANCEL_VIOLATION = 0xad,

        /// <summary>
        /// The file system does not support atomic changes to the lock type.
        /// </summary>
        ATOMIC_LOCKS_NOT_SUPPORTED = 0xae,

        /// <summary>
        /// The system detected a segment number that was not correct.
        /// </summary>
        INVALID_SEGMENT_NUMBER = 0xb4,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        INVALID_ORDINAL = 0xb6,

        /// <summary>
        /// Cannot create a file when that file already exists.
        /// </summary>
        ALREADY_EXISTS = 0xb7,

        /// <summary>
        /// The flag passed is not correct.
        /// </summary>
        INVALID_FLAG_NUMBER = 0xba,

        /// <summary>
        /// The specified system semaphore name was not found.
        /// </summary>
        SEM_NOT_FOUND = 0xbb,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        INVALID_STARTING_CODESEG = 0xbc,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        INVALID_STACKSEG = 0xbd,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        INVALID_MODULETYPE = 0xbe,

        /// <summary>
        /// Cannot run %1 in Win32 mode.
        /// </summary>
        INVALID_EXE_SIGNATURE = 0xbf,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        EXE_MARKED_INVALID = 0xc0,

        /// <summary>
        /// %1 is not a valid Win32 application.
        /// </summary>
        BAD_EXE_FORMAT = 0xc1,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        ITERATED_DATA_EXCEEDS_64k = 0xc2,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        INVALID_MINALLOCSIZE = 0xc3,

        /// <summary>
        /// The operating system cannot run this application program.
        /// </summary>
        DYNLINK_FROM_INVALID_RING = 0xc4,

        /// <summary>
        /// The operating system is not presently configured to run this application.
        /// </summary>
        IOPnot_ENABLED = 0xc5,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        INVALID_SEGDPL = 0xc6,

        /// <summary>
        /// The operating system cannot run this application program.
        /// </summary>
        AUTODATASEG_EXCEEDS_64k = 0xc7,

        /// <summary>
        /// The code segment cannot be greater than or equal to 64K.
        /// </summary>
        RING2SEG_MUST_BE_MOVABLE = 0xc8,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        RELOC_CHAIN_XEEDS_SEGLIM = 0xc9,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        INFLOOP_IN_RELOC_CHAIN = 0xca,

        /// <summary>
        /// The system could not find the environment option that was entered.
        /// </summary>
        ENVVAR_NOT_FOUND = 0xcb,

        /// <summary>
        /// No process in the command subtree has a signal handler.
        /// </summary>
        NO_SIGNAL_SENT = 0xcd,

        /// <summary>
        /// The fileName or extension is too long.
        /// </summary>
        FILENAME_EXCED_RANGE = 0xce,

        /// <summary>
        /// The ring 2 stack is in use.
        /// </summary>
        RING2_STACK_IN_USE = 0xcf,

        /// <summary>
        /// The ring 2 stack is in use.
        /// </summary>
        META_EXPANSION_TOO_LONG = 0xd0,

        /// <summary>
        /// The signal being posted is not correct.
        /// </summary>
        INVALID_SIGNAL_NUMBER = 0xd1,

        /// <summary>
        /// The signal handler cannot be set.
        /// </summary>
        THREAD_1_INACTIVE = 0xd2,

        /// <summary>
        /// The segment is locked and cannot be reallocated.
        /// </summary>
        LOCKED = 0xd4,

        /// <summary>
        /// Too many dynamic-link modules are attached to this program or dynamic-link module.
        /// </summary>
        TOO_MANY_MODULES = 0xd6,

        /// <summary>
        /// Cannot nest calls to LoadModule.
        /// </summary>
        NESTING_NOT_ALLOWED = 0xd7,

        /// <summary>
        /// Cannot nest calls to LoadModule.
        /// </summary>
        EXE_MACHINE_TYPE_MISMATCH = 0xd8,

        /// <summary>
        /// The image file %1 is signed, unable to modify.
        /// </summary>
        EXE_CANNOT_MODIFY_SIGNED_BINARY = 0xd9,

        /// <summary>
        /// The image file %1 is strong signed, unable to modify.
        /// </summary>
        EXE_CANNOT_MODIFY_STRONG_SIGNED_BINARY = 0xda,

        /// <summary>
        /// This file is checked out or locked for editing by another user.
        /// </summary>
        FILE_CHECKED_OUT = 0xdc,

        /// <summary>
        /// The file must be checked out before saving changes.
        /// </summary>
        CHECKOUT_REQUIRED = 0xdd,

        /// <summary>
        /// The file type being saved or retrieved has been blocked.
        /// </summary>
        BAD_FILE_TYPE = 0xde,

        /// <summary>
        /// The file size exceeds the limit allowed and cannot be saved.
        /// </summary>
        FILE_TOO_LARGE = 0xdf,

        /// <summary>
        /// The file size exceeds the limit allowed and cannot be saved.
        /// </summary>
        FORMS_AUTH_REQUIRED = 0xe0,

        /// <summary>
        /// The file size exceeds the limit allowed and cannot be saved.
        /// </summary>
        VIRUS_INFECTED = 0xe1,

        /// <summary>
        /// The file size exceeds the limit allowed and cannot be saved.
        /// </summary>
        VIRUS_DELETED = 0xe2,

        /// <summary>
        /// The pipe is local.
        /// </summary>
        PIPE_LOCAL = 0xe5,

        /// <summary>
        /// The pipe state is invalid.
        /// </summary>
        BAD_PIPE = 0xe6,

        /// <summary>
        /// All pipe instances are busy.
        /// </summary>
        PIPE_BUSY = 0xe7,

        /// <summary>
        /// The pipe is being closed.
        /// </summary>
        NO_DATA = 0xe8,

        /// <summary>
        /// No process is on the other end of the pipe.
        /// </summary>
        PIPE_NOT_CONNECTED = 0xe9,

        /// <summary>
        /// More data is available.
        /// </summary>
        MORE_DATA = 0xea,

        /// <summary>
        /// The session was canceled.
        /// </summary>
        VC_DISCONNECTED = 0xf0,

        /// <summary>
        /// The specified extended attribute name was invalid.
        /// </summary>
        INVALID_EA_NAME = 0xfe,

        /// <summary>
        /// The extended attributes are inconsistent.
        /// </summary>
        EA_LIST_INCONSISTENT = 0xff,

        /// <summary>
        /// The wait operation timed out.
        /// </summary>
        WAIT_TIMEOUT = 0x102,

        /// <summary>
        /// No more data is available.
        /// </summary>
        NO_MORE_ITEMS = 0x103,

        /// <summary>
        /// The copy functions cannot be used.
        /// </summary>
        CANNOT_COPY = 0x10a,

        /// <summary>
        /// The directory name is invalid.
        /// </summary>
        DIRECTORY = 0x10b,

        /// <summary>
        /// The extended attributes did not fit in the buffer.
        /// </summary>
        EAS_DIDNT_FIT = 0x113,

        /// <summary>
        /// The extended attribute file on the mounted file system is corrupt.
        /// </summary>
        EA_FILE_CORRUPT = 0x114,

        /// <summary>
        /// The extended attribute table file is full.
        /// </summary>
        EA_TABLE_FULL = 0x115,

        /// <summary>
        /// The specified extended attribute handle is invalid.
        /// </summary>
        INVALID_EA_HANDLE = 0x116,

        /// <summary>
        /// The mounted file system does not support extended attributes.
        /// </summary>
        EAS_NOT_SUPPORTED = 0x11a,

        /// <summary>
        /// Attempt to release mutex not owned by caller.
        /// </summary>
        NOT_OWNER = 0x120,

        /// <summary>
        /// Too many posts were made to a semaphore.
        /// </summary>
        TOO_MANY_POSTS = 0x12a,

        /// <summary>
        /// Only part of a ReadProcessMemory or WriteProcessMemory request was completed.
        /// </summary>
        PARTIAcOPY = 0x12b,

        /// <summary>
        /// The oplock request is denied.
        /// </summary>
        OPLOCK_NOT_GRANTED = 0x12c,

        /// <summary>
        /// An invalid oplock acknowledgment was received by the system.
        /// </summary>
        INVALID_OPLOCK_PROTOCOL = 0x12d,

        /// <summary>
        /// The volume is too fragmented to complete this operation.
        /// </summary>
        DISK_TOO_FRAGMENTED = 0x12e,

        /// <summary>
        /// The file cannot be opened because it is in the process of being deleted.
        /// </summary>
        DELETE_PENDING = 0x12f,

        /// <summary>
        /// Short name settings may not be changed on this volume due to the global registry setting.
        /// </summary>
        INCOMPATIBLE_WITH_GLOBAL_SHORT_NAME_REGISTRY_SETTING = 0x130,

        /// <summary>
        /// Short names are not enabled on this volume.
        /// </summary>
        SHORT_NAMES_NOT_ENABLED_ON_VOLUME = 0x131,

        /// <summary>
        /// The security stream for the specified volume is in an inconsistent state. Please run CHKDSK on the volume.
        /// </summary>
        SECURITY_STREAM_IS_INCONSISTENT = 0x132,

        /// <summary>
        /// A requested file lock operation cannot be processed due to an invalid byte range.
        /// </summary>
        INVALID_LOCK_RANGE = 0x133,

        /// <summary>
        /// The subsystem needed to support the image type is not present.
        /// </summary>
        IMAGE_SUBSYSTEM_NOT_PRESENT = 0x134,

        /// <summary>
        /// The specified file already has a notification GUID associated with it.
        /// </summary>
        NOTIFICATION_GUID_ALREADY_DEFINED = 0x135,

        /// <summary>
        /// An invalid exception handler routine has been detected.
        /// </summary>
        INVALID_EXCEPTION_HANDLER = 0x136,

        /// <summary>
        /// Duplicate privileges were specified for the token.
        /// </summary>
        DUPLICATE_PRIVILEGES = 0x137,

        /// <summary>
        /// No ranges for the specified operation were able to be processed.
        /// </summary>
        NO_RANGES_PROCESSED = 0x138,

        /// <summary>
        /// Operation is not allowed on a file system internal file.
        /// </summary>
        NOT_ALLOWED_ON_SYSTEM_FILE = 0x139,

        /// <summary>
        /// The physical resources of this disk have been exhausted.
        /// </summary>
        DISK_RESOURCES_EXHAUSTED = 0x13a,

        /// <summary>
        /// The token representing the data is invalid.
        /// </summary>
        INVALID_TOKEN = 0x13b,

        /// <summary>
        /// The device does not support the command feature.
        /// </summary>
        DEVICE_FEATURE_NOT_SUPPORTED = 0x13c,

        /// <summary>
        /// The system cannot find message text for message number 0x%1 in the message file for %2.
        /// </summary>
        MR_MID_NOT_FOUND = 0x13d,

        /// <summary>
        /// The scope specified was not found.
        /// </summary>
        SCOPE_NOT_FOUND = 0x13e,

        /// <summary>
        /// The Central Access Policy specified is not defined on the target machine.
        /// </summary>
        UNDEFINED_SCOPE = 0x13f,

        /// <summary>
        /// The Central Access Policy obtained from Active Directory is invalid.
        /// </summary>
        INVALID_CAP = 0x140,

        /// <summary>
        /// The device is unreachable.
        /// </summary>
        DEVICE_UNREACHABLE = 0x141,

        /// <summary>
        /// The target device has insufficient resources to complete the operation.
        /// </summary>
        DEVICE_NO_RESOURCES = 0x142,

        /// <summary>
        /// A data integrity checksum error occurred. Data in the file stream is corrupt.
        /// </summary>
        DATA_CHECKSUM_ERROR = 0x143,

        /// <summary>
        /// An attempt was made to modify both a KERNEL and normal Extended Attribute (EA) in the same operation.
        /// </summary>
        INTERMIXED_KERNEL_EA_OPERATION = 0x144,

        /// <summary>
        /// Device does not support file-level TRIM.
        /// </summary>
        FILE_LEVEL_TRIM_NOT_SUPPORTED = 0x146,

        /// <summary>
        /// The command specified a data offset that does not align to the device's granularity/alignment.
        /// </summary>
        OFFSET_ALIGNMENT_VIOLATION = 0x147,

        /// <summary>
        /// The command specified an invalid field in its parameter list.
        /// </summary>
        INVALID_FIELD_IN_PARAMETER_LIST = 0x148,

        /// <summary>
        /// An operation is currently in progress with the device.
        /// </summary>
        OPERATION_IN_PROGRESS = 0x149,

        /// <summary>
        /// An attempt was made to send down the command via an invalid path to the target device.
        /// </summary>
        BAD_DEVICE_PATH = 0x14a,

        /// <summary>
        /// The command specified a number of descriptors that exceeded the maximum supported by the device.
        /// </summary>
        TOO_MANY_DESCRIPTORS = 0x14b,

        /// <summary>
        /// Scrub is disabled on the specified file.
        /// </summary>
        SCRUB_DATA_DISABLED = 0x14c,

        /// <summary>
        /// The storage device does not provide redundancy.
        /// </summary>
        NOT_REDUNDANT_STORAGE = 0x14d,

        /// <summary>
        /// An operation is not supported on a resident file.
        /// </summary>
        RESIDENT_FILE_NOT_SUPPORTED = 0x14e,

        /// <summary>
        /// An operation is not supported on a compressed file.
        /// </summary>
        COMPRESSED_FILE_NOT_SUPPORTED = 0x14f,

        /// <summary>
        /// An operation is not supported on a directory.
        /// </summary>
        DIRECTORY_NOT_SUPPORTED = 0x150,

        /// <summary>
        /// The specified copy of the requested data could not be read.
        /// </summary>
        NOT_READ_FROM_COPY = 0x151,

        /// <summary>
        /// No action was taken as a system reboot is required.
        /// </summary>
        FAIL_NOACTION_REBOOT = 0x15e,

        /// <summary>
        /// The shutdown operation failed.
        /// </summary>
        FAIL_SHUTDOWN = 0x15f,

        /// <summary>
        /// The restart operation failed.
        /// </summary>
        FAIL_RESTART = 0x160,

        /// <summary>
        /// The maximum number of sessions has been reached.
        /// </summary>
        MAX_SESSIONS_REACHED = 0x161,

        /// <summary>
        /// The thread is already in background processing mode.
        /// </summary>
        THREAD_MODE_ALREADY_BACKGROUND = 0x190,

        /// <summary>
        /// The thread is not in background processing mode.
        /// </summary>
        THREAD_MODE_NOT_BACKGROUND = 0x191,

        /// <summary>
        /// The process is already in background processing mode.
        /// </summary>
        PROCESS_MODE_ALREADY_BACKGROUND = 0x192,

        /// <summary>
        /// The process is not in background processing mode.
        /// </summary>
        PROCESS_MODE_NOT_BACKGROUND = 0x193,

        /// <summary>
        /// User profile cannot be loaded.
        /// </summary>
        USER_PROFILE_LOAD = 0x1f4,

        /// <summary>
        /// Arithmetic result exceeded 32 bits.
        /// </summary>
        ARITHMETIC_OVERFLOW = 0x216,

        /// <summary>
        /// There is a process on other end of the pipe.
        /// </summary>
        PIPE_CONNECTED = 0x217,

        /// <summary>
        /// Waiting for a process to open the other end of the pipe.
        /// </summary>
        PIPE_LISTENING = 0x218,

        /// <summary>
        /// Application verifier has found an error in the current process.
        /// </summary>
        VERIFIER_STOP = 0x219,

        /// <summary>
        /// An error occurred in the ABIOS subsystem.
        /// </summary>
        ABIOS_ERROR = 0x21a,

        /// <summary>
        /// A warning occurred in the WX86 subsystem.
        /// </summary>
        WX86_WARNING = 0x21b,

        /// <summary>
        /// An error occurred in the WX86 subsystem.
        /// </summary>
        WX86_ERROR = 0x21c,

        /// <summary>
        /// An error occurred in the WX86 subsystem.
        /// </summary>
        TIMER_NOT_CANCELED = 0x21d,

        /// <summary>
        /// Unwind exception code.
        /// </summary>
        UNWIND = 0x21e,

        /// <summary>
        /// An invalid or unaligned stack was encountered during an unwind operation.
        /// </summary>
        BAD_STACK = 0x21f,

        /// <summary>
        /// An invalid unwind target was encountered during an unwind operation.
        /// </summary>
        INVALID_UNWIND_TARGET = 0x220,

        /// <summary>
        /// An invalid unwind target was encountered during an unwind operation.
        /// </summary>
        INVALID_PORT_ATTRIBUTES = 0x221,

        /// <summary>
        /// An invalid unwind target was encountered during an unwind operation.
        /// </summary>
        PORT_MESSAGE_TOO_LONG = 0x222,

        /// <summary>
        /// An attempt was made to lower a quota limit below the current usage.
        /// </summary>
        INVALID_QUOTA_LOWER = 0x223,

        /// <summary>
        /// An attempt was made to attach to a device that was already attached to another device.
        /// </summary>
        DEVICE_ALREADY_ATTACHED = 0x224,

        /// <summary>
        /// An attempt was made to attach to a device that was already attached to another device.
        /// </summary>
        INSTRUCTION_MISALIGNMENT = 0x225,

        /// <summary>
        /// Profiling not started.
        /// </summary>
        PROFILING_NOT_STARTED = 0x226,

        /// <summary>
        /// Profiling not stopped.
        /// </summary>
        PROFILING_NOT_STOPPED = 0x227,

        /// <summary>
        /// The passed ACL did not contain the minimum required information.
        /// </summary>
        COULD_NOT_INTERPRET = 0x228,

        /// <summary>
        /// The number of active profiling objects is at the maximum and no more may be started.
        /// </summary>
        PROFILING_AT_LIMIT = 0x229,

        /// <summary>
        /// Used to indicate that an operation cannot continue without blocking for I/O.
        /// </summary>
        CANT_WAIT = 0x22a,

        /// <summary>
        /// Used to indicate that an operation cannot continue without blocking for I/O.
        /// </summary>
        CANT_TERMINATE_SELF = 0x22b,

        /// <summary>
        /// Used to indicate that an operation cannot continue without blocking for I/O.
        /// </summary>
        UNEXPECTED_MM_CREATE_ERR = 0x22c,

        /// <summary>
        /// Used to indicate that an operation cannot continue without blocking for I/O.
        /// </summary>
        UNEXPECTED_MM_MAP_ERROR = 0x22d,

        /// <summary>
        /// Used to indicate that an operation cannot continue without blocking for I/O.
        /// </summary>
        UNEXPECTED_MM_EXTEND_ERR = 0x22e,

        /// <summary>
        /// A malformed function table was encountered during an unwind operation.
        /// </summary>
        BAD_FUNCTION_TABLE = 0x22f,

        /// <summary>
        /// A malformed function table was encountered during an unwind operation.
        /// </summary>
        NO_GUID_TRANSLATION = 0x230,

        /// <summary>
        /// A malformed function table was encountered during an unwind operation.
        /// </summary>
        INVALID_LDT_SIZE = 0x231,

        /// <summary>
        /// A malformed function table was encountered during an unwind operation.
        /// </summary>
        INVALID_LDT_OFFSET = 0x233,

        /// <summary>
        /// Indicates that the user supplied an invalid descriptor when trying to set up Ldt descriptors.
        /// </summary>
        INVALID_LDT_DESCRIPTOR = 0x234,

        /// <summary>
        /// Indicates that the user supplied an invalid descriptor when trying to set up Ldt descriptors.
        /// </summary>
        TOO_MANY_THREADS = 0x235,

        /// <summary>
        /// Indicates that the user supplied an invalid descriptor when trying to set up Ldt descriptors.
        /// </summary>
        THREAD_NOT_IN_PROCESS = 0x236,

        /// <summary>
        /// Page file quota was exceeded.
        /// </summary>
        PAGEFILE_QUOTA_EXCEEDED = 0x237,

        /// <summary>
        /// Page file quota was exceeded.
        /// </summary>
        LOGON_SERVER_CONFLICT = 0x238,

        /// <summary>
        /// Page file quota was exceeded.
        /// </summary>
        SYNCHRONIZATION_REQUIRED = 0x239,

        /// <summary>
        /// Page file quota was exceeded.
        /// </summary>
        NET_OPEN_FAILED = 0x23a,

        /// <summary>
        /// {Privilege Failed} The I/O permissions for the process could not be changed.
        /// </summary>
        IO_PRIVILEGE_FAILED = 0x23b,

        /// <summary>
        /// {Application Exit by CTRL+C} The application terminated as a result of a CTRL+C.
        /// </summary>
        CONTROc_EXIT = 0x23c,

        /// <summary>
        /// {Missing System File} The required system file %hs is bad or missing.
        /// </summary>
        MISSING_SYSTEMFILE = 0x23d,

        /// <summary>
        /// {Application Error} The exception %s (0x%08lx) occurred in the application at location 0x%08lx.
        /// </summary>
        UNHANDLED_EXCEPTION = 0x23e,

        /// <summary>
        /// {Application Error} The exception %s (0x%08lx) occurred in the application at location 0x%08lx.
        /// </summary>
        APP_INIT_FAILURE = 0x23f,

        /// <summary>
        /// {Application Error} The exception %s (0x%08lx) occurred in the application at location 0x%08lx.
        /// </summary>
        PAGEFILE_CREATE_FAILED = 0x240,

        /// <summary>
        /// {Application Error} The exception %s (0x%08lx) occurred in the application at location 0x%08lx.
        /// </summary>
        INVALID_IMAGE_HASH = 0x241,

        /// <summary>
        /// {No Paging File Specified} No paging file was specified in the system configuration.
        /// </summary>
        NO_PAGEFILE = 0x242,

        /// <summary>
        /// {No Paging File Specified} No paging file was specified in the system configuration.
        /// </summary>
        ILLEGAL_FLOAT_CONTEXT = 0x243,

        /// <summary>
        /// {No Paging File Specified} No paging file was specified in the system configuration.
        /// </summary>
        NO_EVENT_PAIR = 0x244,

        /// <summary>
        /// A Windows Server has an incorrect configuration.
        /// </summary>
        DOMAIN_CTRLR_CONFIG_ERROR = 0x245,

        /// <summary>
        /// A Windows Server has an incorrect configuration.
        /// </summary>
        ILLEGAcHARACTER = 0x246,

        /// <summary>
        /// The Unicode character is not defined in the Unicode character set installed on the system.
        /// </summary>
        UNDEFINED_CHARACTER = 0x247,

        /// <summary>
        /// The paging file cannot be created on a floppy diskette.
        /// </summary>
        FLOPPY_VOLUME = 0x248,

        /// <summary>
        /// The paging file cannot be created on a floppy diskette.
        /// </summary>
        BIOS_FAILED_TO_CONNECT_INTERRUPT = 0x249,

        /// <summary>
        /// This operation is only allowed for the Primary Domain Controller of the domain.
        /// </summary>
        BACKUP_CONTROLLER = 0x24a,

        /// <summary>
        /// An attempt was made to acquire a mutant such that its maximum count would have been exceeded.
        /// </summary>
        MUTANT_LIMIT_EXCEEDED = 0x24b,

        /// <summary>
        /// A volume has been accessed for which a file system driver is required that has not yet been loaded.
        /// </summary>
        FS_DRIVER_REQUIRED = 0x24c,

        /// <summary>
        /// A volume has been accessed for which a file system driver is required that has not yet been loaded.
        /// </summary>
        CANNOT_LOAD_REGISTRY_FILE = 0x24d,

        /// <summary>
        /// A volume has been accessed for which a file system driver is required that has not yet been loaded.
        /// </summary>
        DEBUG_ATTACH_FAILED = 0x24e,

        /// <summary>
        /// A volume has been accessed for which a file system driver is required that has not yet been loaded.
        /// </summary>
        SYSTEM_PROCESS_TERMINATED = 0x24f,

        /// <summary>
        /// {Data Not Accepted} The TDI client could not handle the data received during an indication.
        /// </summary>
        DATA_NOT_ACCEPTED = 0x250,

        /// <summary>
        /// NTVDM encountered a hard error.
        /// </summary>
        VDM_HARD_ERROR = 0x251,

        /// <summary>
        /// {Cancel Timeout} The driver %hs failed to complete a cancelled I/O request in the allotted time.
        /// </summary>
        DRIVER_CANCEL_TIMEOUT = 0x252,

        /// <summary>
        /// {Cancel Timeout} The driver %hs failed to complete a cancelled I/O request in the allotted time.
        /// </summary>
        REPLY_MESSAGE_MISMATCH = 0x253,

        /// <summary>
        /// {Cancel Timeout} The driver %hs failed to complete a cancelled I/O request in the allotted time.
        /// </summary>
        LOST_WRITEBEHIND_DATA = 0x254,

        /// <summary>
        /// {Cancel Timeout} The driver %hs failed to complete a cancelled I/O request in the allotted time.
        /// </summary>
        CLIENT_SERVER_PARAMETERS_INVALID = 0x255,

        /// <summary>
        /// The stream is not a tiny stream.
        /// </summary>
        NOT_TINY_STREAM = 0x256,

        /// <summary>
        /// The request must be handled by the stack overflow code.
        /// </summary>
        STACK_OVERFLOW_READ = 0x257,

        /// <summary>
        /// The request must be handled by the stack overflow code.
        /// </summary>
        CONVERT_TO_LARGE = 0x258,

        /// <summary>
        /// The request must be handled by the stack overflow code.
        /// </summary>
        FOUND_OUT_OF_SCOPE = 0x259,

        /// <summary>
        /// The bucket array must be grown. Retry transaction after doing so.
        /// </summary>
        ALLOCATE_BUCKET = 0x25a,

        /// <summary>
        /// The user/kernel marshalling buffer has overflowed.
        /// </summary>
        MARSHALL_OVERFLOW = 0x25b,

        /// <summary>
        /// The supplied variant structure contains invalid data.
        /// </summary>
        INVALID_VARIANT = 0x25c,

        /// <summary>
        /// The specified buffer contains ill-formed data.
        /// </summary>
        BAD_COMPRESSION_BUFFER = 0x25d,

        /// <summary>
        /// {Audit Failed} An attempt to generate a security audit failed.
        /// </summary>
        AUDIT_FAILED = 0x25e,

        /// <summary>
        /// The timer resolution was not previously set by the current process.
        /// </summary>
        TIMER_RESOLUTION_NOT_SET = 0x25f,

        /// <summary>
        /// There is insufficient account information to log you on.
        /// </summary>
        INSUFFICIENT_LOGON_INFO = 0x260,

        /// <summary>
        /// There is insufficient account information to log you on.
        /// </summary>
        BAD_DLL_ENTRYPOINT = 0x261,

        /// <summary>
        /// There is insufficient account information to log you on.
        /// </summary>
        BAD_SERVICE_ENTRYPOINT = 0x262,

        /// <summary>
        /// There is an IP address conflict with another system on the network.
        /// </summary>
        Iaddress_CONFLICT1 = 0x263,

        /// <summary>
        /// There is an IP address conflict with another system on the network.
        /// </summary>
        Iaddress_CONFLICT2 = 0x264,

        /// <summary>
        /// There is an IP address conflict with another system on the network.
        /// </summary>
        REGISTRY_QUOTA_LIMIT = 0x265,

        /// <summary>
        /// A callback return system service cannot be executed when no callback is active.
        /// </summary>
        NO_CALLBACK_ACTIVE = 0x266,

        /// <summary>
        /// A callback return system service cannot be executed when no callback is active.
        /// </summary>
        PWD_TOO_SHORT = 0x267,

        /// <summary>
        /// A callback return system service cannot be executed when no callback is active.
        /// </summary>
        PWD_TOO_RECENT = 0x268,

        /// <summary>
        /// A callback return system service cannot be executed when no callback is active.
        /// </summary>
        PWD_HISTORY_CONFLICT = 0x269,

        /// <summary>
        /// The specified compression format is unsupported.
        /// </summary>
        UNSUPPORTED_COMPRESSION = 0x26a,

        /// <summary>
        /// The specified hardware profile configuration is invalid.
        /// </summary>
        INVALID_HW_PROFILE = 0x26b,

        /// <summary>
        /// The specified Plug and Play registry device path is invalid.
        /// </summary>
        INVALID_PLUGPLAY_DEVICE_PATH = 0x26c,

        /// <summary>
        /// The specified quota list is internally inconsistent with its descriptor.
        /// </summary>
        QUOTA_LIST_INCONSISTENT = 0x26d,

        /// <summary>
        /// The specified quota list is internally inconsistent with its descriptor.
        /// </summary>
        EVALUATION_EXPIRATION = 0x26e,

        /// <summary>
        /// The specified quota list is internally inconsistent with its descriptor.
        /// </summary>
        ILLEGAL_DLL_RELOCATION = 0x26f,

        /// <summary>
        /// The specified quota list is internally inconsistent with its descriptor.
        /// </summary>
        DLL_INIT_FAILED_LOGOFF = 0x270,

        /// <summary>
        /// The validation process needs to continue on to the next step.
        /// </summary>
        VALIDATE_CONTINUE = 0x271,

        /// <summary>
        /// There are no more matches for the current index enumeration.
        /// </summary>
        NO_MORE_MATCHES = 0x272,

        /// <summary>
        /// The range could not be added to the range list because of a conflict.
        /// </summary>
        RANGE_LIST_CONFLICT = 0x273,

        /// <summary>
        /// The server process is running under a SID different than that required by client.
        /// </summary>
        SERVER_SID_MISMATCH = 0x274,

        /// <summary>
        /// A group marked use for deny only cannot be enabled.
        /// </summary>
        CANT_ENABLE_DENY_ONLY = 0x275,

        /// <summary>
        /// {EXCEPTION} Multiple floating point faults.
        /// </summary>
        FLOAT_MULTIPLE_FAULTS = 0x276,

        /// <summary>
        /// {EXCEPTION} Multiple floating point traps.
        /// </summary>
        FLOAT_MULTIPLE_TRAPS = 0x277,

        /// <summary>
        /// The requested interface is not supported.
        /// </summary>
        NOINTERFACE = 0x278,

        /// <summary>
        /// The requested interface is not supported.
        /// </summary>
        DRIVER_FAILED_SLEEP = 0x279,

        /// <summary>
        /// The system file %1 has become corrupt and has been replaced.
        /// </summary>
        CORRUPT_SYSTEM_FILE = 0x27a,

        /// <summary>
        /// The system file %1 has become corrupt and has been replaced.
        /// </summary>
        COMMITMENT_MINIMUM = 0x27b,

        /// <summary>
        /// A device was removed so enumeration must be restarted.
        /// </summary>
        PNP_RESTART_ENUMERATION = 0x27c,

        /// <summary>
        /// A device was removed so enumeration must be restarted.
        /// </summary>
        SYSTEM_IMAGE_BAD_SIGNATURE = 0x27d,

        /// <summary>
        /// Device will not start without a reboot.
        /// </summary>
        PNP_REBOOT_REQUIRED = 0x27e,

        /// <summary>
        /// There is not enough power to complete the requested operation.
        /// </summary>
        INSUFFICIENT_POWER = 0x27f,

        /// <summary>
        /// ERROR_MULTIPLE_FAULT_VIOLATION
        /// </summary>
        MULTIPLE_FAULT_VIOLATION = 0x280,

        /// <summary>
        /// The system is in the process of shutting down.
        /// </summary>
        SYSTEM_SHUTDOWN = 0x281,

        /// <summary>
        /// The system is in the process of shutting down.
        /// </summary>
        PORT_NOT_SET = 0x282,

        /// <summary>
        /// The system is in the process of shutting down.
        /// </summary>
        DS_VERSION_CHECK_FAILURE = 0x283,

        /// <summary>
        /// The specified range could not be found in the range list.
        /// </summary>
        RANGE_NOT_FOUND = 0x284,

        /// <summary>
        /// The driver was not loaded because the system is booting into safe mode.
        /// </summary>
        NOT_SAFE_MODE_DRIVER = 0x286,

        /// <summary>
        /// The driver was not loaded because it failed its initialization call.
        /// </summary>
        FAILED_DRIVER_ENTRY = 0x287,

        /// <summary>
        /// The driver was not loaded because it failed its initialization call.
        /// </summary>
        DEVICE_ENUMERATION_ERROR = 0x288,

        /// <summary>
        /// The driver was not loaded because it failed its initialization call.
        /// </summary>
        MOUNT_POINT_NOT_RESOLVED = 0x289,

        /// <summary>
        /// The driver was not loaded because it failed its initialization call.
        /// </summary>
        INVALID_DEVICE_OBJECT_PARAMETER = 0x28a,

        /// <summary>
        /// A Machine Check Error has occurred. Please check the system eventlog for additional information.
        /// </summary>
        MCA_OCCURED = 0x28b,

        /// <summary>
        /// There was error [%2] processing the driver database.
        /// </summary>
        DRIVER_DATABASE_ERROR = 0x28c,

        /// <summary>
        /// System hive size has exceeded its limit.
        /// </summary>
        SYSTEM_HIVE_TOO_LARGE = 0x28d,

        /// <summary>
        /// The driver could not be loaded because a previous version of the driver is still in memory.
        /// </summary>
        DRIVER_FAILED_PRIOR_UNLOAD = 0x28e,

        /// <summary>
        /// The driver could not be loaded because a previous version of the driver is still in memory.
        /// </summary>
        VOLSNAP_PREPARE_HIBERNATE = 0x28f,

        /// <summary>
        /// The system has failed to hibernate (The error code is %hs). Hibernation will be disabled until the system is restarted.
        /// </summary>
        HIBERNATION_FAILURE = 0x290,

        /// <summary>
        /// The password provided is too long to meet the policy of your user account. Please choose a shorter password.
        /// </summary>
        PWD_TOO_LONG = 0x291,

        /// <summary>
        /// The requested operation could not be completed due to a file system limitation.
        /// </summary>
        FILE_SYSTEM_LIMITATION = 0x299,

        /// <summary>
        /// An assertion failure has occurred.
        /// </summary>
        ASSERTION_FAILURE = 0x29c,

        /// <summary>
        /// An error occurred in the ACPI subsystem.
        /// </summary>
        ACPI_ERROR = 0x29d,

        /// <summary>
        /// WOW Assertion Error.
        /// </summary>
        WOW_ASSERTION = 0x29e,

        /// <summary>
        /// WOW Assertion Error.
        /// </summary>
        PNP_BAD_MPS_TABLE = 0x29f,

        /// <summary>
        /// A translator failed to translate resources.
        /// </summary>
        PNP_TRANSLATION_FAILED = 0x2a0,

        /// <summary>
        /// A IRQ translator failed to translate resources.
        /// </summary>
        PNP_IRQ_TRANSLATION_FAILED = 0x2a1,

        /// <summary>
        /// Driver %2 returned invalid ID for a child device (%3).
        /// </summary>
        PNP_INVALID_ID = 0x2a2,

        /// <summary>
        /// {Kernel Debugger Awakened} the system debugger was awakened by an interrupt.
        /// </summary>
        WAKE_SYSTEM_DEBUGGER = 0x2a3,

        /// <summary>
        /// {Kernel Debugger Awakened} the system debugger was awakened by an interrupt.
        /// </summary>
        HANDLES_CLOSED = 0x2a4,

        /// <summary>
        /// {Kernel Debugger Awakened} the system debugger was awakened by an interrupt.
        /// </summary>
        EXTRANEOUS_INFORMATION = 0x2a5,

        /// <summary>
        /// {Kernel Debugger Awakened} the system debugger was awakened by an interrupt.
        /// </summary>
        RXACT_COMMIT_NECESSARY = 0x2a6,

        /// <summary>
        /// {Media Changed} The media may have changed.
        /// </summary>
        MEDIA_CHECK = 0x2a7,

        /// <summary>
        /// {Media Changed} The media may have changed.
        /// </summary>
        GUID_SUBSTITUTION_MADE = 0x2a8,

        /// <summary>
        /// The create operation stopped after reaching a symbolic link.
        /// </summary>
        STOPPED_ON_SYMLINK = 0x2a9,

        /// <summary>
        /// A long jump has been executed.
        /// </summary>
        LONGJUMP = 0x2aa,

        /// <summary>
        /// The Plug and Play query operation was not successful.
        /// </summary>
        PLUGPLAY_QUERY_VETOED = 0x2ab,

        /// <summary>
        /// A frame consolidation has been executed.
        /// </summary>
        UNWIND_CONSOLIDATE = 0x2ac,

        /// <summary>
        /// A frame consolidation has been executed.
        /// </summary>
        REGISTRY_HIVE_RECOVERED = 0x2ad,

        /// <summary>
        /// A frame consolidation has been executed.
        /// </summary>
        DLL_MIGHT_BE_INSECURE = 0x2ae,

        /// <summary>
        /// A frame consolidation has been executed.
        /// </summary>
        DLL_MIGHT_BE_INCOMPATIBLE = 0x2af,

        /// <summary>
        /// Debugger did not handle the exception.
        /// </summary>
        DBG_EXCEPTION_NOT_HANDLED = 0x2b0,

        /// <summary>
        /// Debugger will reply later.
        /// </summary>
        DBG_REPLY_LATER = 0x2b1,

        /// <summary>
        /// Debugger cannot provide handle.
        /// </summary>
        DBG_UNABLE_TO_PROVIDE_HANDLE = 0x2b2,

        /// <summary>
        /// Debugger terminated thread.
        /// </summary>
        DBG_TERMINATE_THREAD = 0x2b3,

        /// <summary>
        /// Debugger terminated process.
        /// </summary>
        DBG_TERMINATE_PROCESS = 0x2b4,

        /// <summary>
        /// Debugger got control C.
        /// </summary>
        DBG_CONTROc = 0x2b5,

        /// <summary>
        /// Debugger printed exception on control C.
        /// </summary>
        DBG_PRINTEXCEPTION_C = 0x2b6,

        /// <summary>
        /// Debugger received RIP exception.
        /// </summary>
        DBG_RIPEXCEPTION = 0x2b7,

        /// <summary>
        /// Debugger received control break.
        /// </summary>
        DBG_CONTRObREAK = 0x2b8,

        /// <summary>
        /// Debugger command communication exception.
        /// </summary>
        DBG_COMMAND_EXCEPTION = 0x2b9,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        OBJECT_NAME_EXISTS = 0x2ba,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        THREAD_WAS_SUSPENDED = 0x2bb,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        IMAGE_NOT_AT_BASE = 0x2bc,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        RXACT_STATE_CREATED = 0x2bd,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        SEGMENT_NOTIFICATION = 0x2be,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        BAD_CURRENT_DIRECTORY = 0x2bf,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        FT_READ_RECOVERY_FROM_BACKUP = 0x2c0,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        FT_WRITE_RECOVERY = 0x2c1,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        IMAGE_MACHINE_TYPE_MISMATCH = 0x2c2,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        RECEIVE_PARTIAL = 0x2c3,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        RECEIVE_EXPEDITED = 0x2c4,

        /// <summary>
        /// {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        RECEIVE_PARTIAL_EXPEDITED = 0x2c5,

        /// <summary>
        /// {TDI Event Done} The TDI indication has completed successfully.
        /// </summary>
        EVENT_DONE = 0x2c6,

        /// <summary>
        /// {TDI Event Pending} The TDI indication has entered the pending state.
        /// </summary>
        EVENT_PENDING = 0x2c7,

        /// <summary>
        /// Checking file system on %wZ.
        /// </summary>
        CHECKING_FILE_SYSTEM = 0x2c8,

        /// <summary>
        /// {Fatal Application Exit} %hs.
        /// </summary>
        FATAaPP_EXIT = 0x2c9,

        /// <summary>
        /// The specified registry key is referenced by a predefined handle.
        /// </summary>
        PREDEFINED_HANDLE = 0x2ca,

        /// <summary>
        /// The specified registry key is referenced by a predefined handle.
        /// </summary>
        WAS_UNLOCKED = 0x2cb,

        /// <summary>
        /// %hs
        /// </summary>
        SERVICE_NOTIFICATION = 0x2cc,

        /// <summary>
        /// {Page Locked} One of the pages to lock was already locked.
        /// </summary>
        WAS_LOCKED = 0x2cd,

        /// <summary>
        /// Application popup: %1 : %2
        /// </summary>
        LOG_HARD_ERROR = 0x2ce,

        /// <summary>
        /// ERROR_ALREADY_WIN32
        /// </summary>
        ALREADY_WIN32 = 0x2cf,

        /// <summary>
        /// ERROR_ALREADY_WIN32
        /// </summary>
        IMAGE_MACHINE_TYPE_MISMATCH_EXE = 0x2d0,

        /// <summary>
        /// A yield execution was performed and no thread was available to run.
        /// </summary>
        NO_YIELD_PERFORMED = 0x2d1,

        /// <summary>
        /// The resumable flag to a timer API was ignored.
        /// </summary>
        TIMER_RESUME_IGNORED = 0x2d2,

        /// <summary>
        /// The arbiter has deferred arbitration of these resources to its parent.
        /// </summary>
        ARBITRATION_UNHANDLED = 0x2d3,

        /// <summary>
        /// The inserted CardBus device cannot be started because of a configuration error on "%hs".
        /// </summary>
        CARDBUS_NOT_SUPPORTED = 0x2d4,

        /// <summary>
        /// The inserted CardBus device cannot be started because of a configuration error on "%hs".
        /// </summary>
        MP_PROCESSOR_MISMATCH = 0x2d5,

        /// <summary>
        /// The system was put into hibernation.
        /// </summary>
        HIBERNATED = 0x2d6,

        /// <summary>
        /// The system was resumed from hibernation.
        /// </summary>
        RESUME_HIBERNATION = 0x2d7,

        /// <summary>
        /// The system was resumed from hibernation.
        /// </summary>
        FIRMWARE_UPDATED = 0x2d8,

        /// <summary>
        /// The system was resumed from hibernation.
        /// </summary>
        DRIVERS_LEAKING_LOCKED_PAGES = 0x2d9,

        /// <summary>
        /// The system has awoken.
        /// </summary>
        WAKE_SYSTEM = 0x2da,

        /// <summary>
        /// ERROR_WAIT_1
        /// </summary>
        WAIT_1 = 0x2db,

        /// <summary>
        /// ERROR_WAIT_2
        /// </summary>
        WAIT_2 = 0x2dc,

        /// <summary>
        /// ERROR_WAIT_3
        /// </summary>
        WAIT_3 = 0x2dd,

        /// <summary>
        /// ERROR_WAIT_63
        /// </summary>
        WAIT_63 = 0x2de,

        /// <summary>
        /// ERROR_ABANDONED_WAIT_0
        /// </summary>
        ABANDONED_WAIT_0 = 0x2df,

        /// <summary>
        /// ERROR_ABANDONED_WAIT_63
        /// </summary>
        ABANDONED_WAIT_63 = 0x2e0,

        /// <summary>
        /// ERROR_USER_APC
        /// </summary>
        USER_APC = 0x2e1,

        /// <summary>
        /// ERROR_KERNEaPC
        /// </summary>
        KERNEaPC = 0x2e2,

        /// <summary>
        /// ERROR_ALERTED
        /// </summary>
        ALERTED = 0x2e3,

        /// <summary>
        /// The requested operation requires elevation.
        /// </summary>
        ELEVATION_REQUIRED = 0x2e4,

        /// <summary>
        /// The requested operation requires elevation.
        /// </summary>
        REPARSE = 0x2e5,

        /// <summary>
        /// An open/create operation completed while an oplock break is underway.
        /// </summary>
        OPLOCK_BREAK_IN_PROGRESS = 0x2e6,

        /// <summary>
        /// A new volume has been mounted by a file system.
        /// </summary>
        VOLUME_MOUNTED = 0x2e7,

        /// <summary>
        /// A new volume has been mounted by a file system.
        /// </summary>
        RXACT_COMMITTED = 0x2e8,

        /// <summary>
        /// A new volume has been mounted by a file system.
        /// </summary>
        NOTIFY_CLEANUP = 0x2e9,

        /// <summary>
        /// A new volume has been mounted by a file system.
        /// </summary>
        PRIMARY_TRANSPORT_CONNECT_FAILED = 0x2ea,

        /// <summary>
        /// Page fault was a transition fault.
        /// </summary>
        PAGE_FAULT_TRANSITION = 0x2eb,

        /// <summary>
        /// Page fault was a demand zero fault.
        /// </summary>
        PAGE_FAULT_DEMAND_ZERO = 0x2ec,

        /// <summary>
        /// Page fault was a demand zero fault.
        /// </summary>
        PAGE_FAULT_COPY_ON_WRITE = 0x2ed,

        /// <summary>
        /// Page fault was a demand zero fault.
        /// </summary>
        PAGE_FAULT_GUARD_PAGE = 0x2ee,

        /// <summary>
        /// Page fault was satisfied by reading from a secondary storage device.
        /// </summary>
        PAGE_FAULT_PAGING_FILE = 0x2ef,

        /// <summary>
        /// Cached page was locked during operation.
        /// </summary>
        CACHE_PAGE_LOCKED = 0x2f0,

        /// <summary>
        /// Crash dump exists in paging file.
        /// </summary>
        CRASH_DUMP = 0x2f1,

        /// <summary>
        /// Specified buffer contains all zeros.
        /// </summary>
        BUFFER_ALL_ZEROS = 0x2f2,

        /// <summary>
        /// Specified buffer contains all zeros.
        /// </summary>
        REPARSE_OBJECT = 0x2f3,

        /// <summary>
        /// The device has succeeded a query-stop and its resource requirements have changed.
        /// </summary>
        RESOURCE_REQUIREMENTS_CHANGED = 0x2f4,

        /// <summary>
        /// The device has succeeded a query-stop and its resource requirements have changed.
        /// </summary>
        TRANSLATION_COMPLETE = 0x2f5,

        /// <summary>
        /// A process being terminated has no threads to terminate.
        /// </summary>
        NOTHING_TO_TERMINATE = 0x2f6,

        /// <summary>
        /// The specified process is not part of a job.
        /// </summary>
        PROCESS_NOT_IN_JOB = 0x2f7,

        /// <summary>
        /// The specified process is part of a job.
        /// </summary>
        PROCESS_IN_JOB = 0x2f8,

        /// <summary>
        /// {Volume Shadow Copy Service} The system is now ready for hibernation.
        /// </summary>
        VOLSNAP_HIBERNATE_READY = 0x2f9,

        /// <summary>
        /// A file system or file system filter driver has successfully completed an FsFilter operation.
        /// </summary>
        FSFILTER_OP_COMPLETED_SUCCESSFULLY = 0x2fa,

        /// <summary>
        /// The specified interrupt vector was already connected.
        /// </summary>
        INTERRUPT_VECTOR_ALREADY_CONNECTED = 0x2fb,

        /// <summary>
        /// The specified interrupt vector is still connected.
        /// </summary>
        INTERRUPT_STILcONNECTED = 0x2fc,

        /// <summary>
        /// An operation is blocked waiting for an oplock.
        /// </summary>
        WAIT_FOR_OPLOCK = 0x2fd,

        /// <summary>
        /// Debugger handled exception.
        /// </summary>
        DBG_EXCEPTION_HANDLED = 0x2fe,

        /// <summary>
        /// Debugger continued.
        /// </summary>
        DBG_CONTINUE = 0x2ff,

        /// <summary>
        /// An exception occurred in a user mode callback and the kernel callback frame should be removed.
        /// </summary>
        CALLBACK_POP_STACK = 0x300,

        /// <summary>
        /// Compression is disabled for this volume.
        /// </summary>
        COMPRESSION_DISABLED = 0x301,

        /// <summary>
        /// The data provider cannot fetch backwards through a result set.
        /// </summary>
        CANTFETCHBACKWARDS = 0x302,

        /// <summary>
        /// The data provider cannot scroll backwards through a result set.
        /// </summary>
        CANTSCROLLBACKWARDS = 0x303,

        /// <summary>
        /// The data provider requires that previously fetched data is released before asking for more data.
        /// </summary>
        ROWSNOTRELEASED = 0x304,

        /// <summary>
        /// The data provider was not able to interpret the flags set for a column binding in an accessor.
        /// </summary>
        BAD_ACCESSOR_FLAGS = 0x305,

        /// <summary>
        /// One or more errors occurred while processing the request.
        /// </summary>
        ERRORS_ENCOUNTERED = 0x306,

        /// <summary>
        /// The implementation is not capable of performing the request.
        /// </summary>
        NOT_CAPABLE = 0x307,

        /// <summary>
        /// The implementation is not capable of performing the request.
        /// </summary>
        REQUEST_OUT_OF_SEQUENCE = 0x308,

        /// <summary>
        /// A version number could not be parsed.
        /// </summary>
        VERSION_PARSE_ERROR = 0x309,

        /// <summary>
        /// The iterator's start position is invalid.
        /// </summary>
        BADSTARTPOSITION = 0x30a,

        /// <summary>
        /// The hardware has reported an uncorrectable memory error.
        /// </summary>
        MEMORY_HARDWARE = 0x30b,

        /// <summary>
        /// The attempted operation required self healing to be enabled.
        /// </summary>
        DISK_REPAIR_DISABLED = 0x30c,

        /// <summary>
        /// The attempted operation required self healing to be enabled.
        /// </summary>
        INSUFFICIENT_RESOURCE_FOR_SPECIFIED_SHARED_SECTION_SIZE = 0x30d,

        /// <summary>
        /// The system power state is transitioning from %2 to %3.
        /// </summary>
        SYSTEM_POWERSTATE_TRANSITION = 0x30e,

        /// <summary>
        /// The system power state is transitioning from %2 to %3 but could enter %4.
        /// </summary>
        SYSTEM_POWERSTATE_COMPLEX_TRANSITION = 0x30f,

        /// <summary>
        /// A thread is getting dispatched with MCA EXCEPTION because of MCA.
        /// </summary>
        MCA_EXCEPTION = 0x310,

        /// <summary>
        /// Access to %1 is monitored by policy rule %2.
        /// </summary>
        ACCESS_AUDIT_BY_POLICY = 0x311,

        /// <summary>
        /// Access to %1 has been restricted by your Administrator by policy rule %2.
        /// </summary>
        ACCESS_DISABLED_NO_SAFER_UI_BY_POLICY = 0x312,

        /// <summary>
        /// A valid hibernation file has been invalidated and should be abandoned.
        /// </summary>
        ABANDON_HIBERFILE = 0x313,

        /// <summary>
        /// A valid hibernation file has been invalidated and should be abandoned.
        /// </summary>
        LOST_WRITEBEHIND_DATA_NETWORK_DISCONNECTED = 0x314,

        /// <summary>
        /// A valid hibernation file has been invalidated and should be abandoned.
        /// </summary>
        LOST_WRITEBEHIND_DATA_NETWORK_SERVER_ERROR = 0x315,

        /// <summary>
        /// A valid hibernation file has been invalidated and should be abandoned.
        /// </summary>
        LOST_WRITEBEHIND_DATA_LOCAL_DISK_ERROR = 0x316,

        /// <summary>
        /// The resources required for this device conflict with the MCFG table.
        /// </summary>
        BAD_MCFG_TABLE = 0x317,

        /// <summary>
        /// The resources required for this device conflict with the MCFG table.
        /// </summary>
        DISK_REPAIR_REDIRECTED = 0x318,

        /// <summary>
        /// The volume repair was not successful.
        /// </summary>
        DISK_REPAIR_UNSUCCESSFUL = 0x319,

        /// <summary>
        /// One of the volume corruption logs is full. Further corruptions that may be detected won't be logged.
        /// </summary>
        CORRUPT_LOG_OVERFULL = 0x31a,

        /// <summary>
        /// One of the volume corruption logs is full. Further corruptions that may be detected won't be logged.
        /// </summary>
        CORRUPT_LOG_CORRUPTED = 0x31b,

        /// <summary>
        /// One of the volume corruption logs is unavailable for being operated on.
        /// </summary>
        CORRUPT_LOG_UNAVAILABLE = 0x31c,

        /// <summary>
        /// One of the volume corruption logs is unavailable for being operated on.
        /// </summary>
        CORRUPT_LOG_DELETED_FULL = 0x31d,

        /// <summary>
        /// One of the volume corruption logs was cleared by chkdsk and no longer contains real corruptions.
        /// </summary>
        CORRUPT_LOG_CLEARED = 0x31e,

        /// <summary>
        /// One of the volume corruption logs was cleared by chkdsk and no longer contains real corruptions.
        /// </summary>
        ORPHAN_NAME_EXHAUSTED = 0x31f,

        /// <summary>
        /// The oplock that was associated with this handle is now associated with a different handle.
        /// </summary>
        OPLOCK_SWITCHED_TO_NEW_HANDLE = 0x320,

        /// <summary>
        /// An oplock of the requested level cannot be granted. An oplock of a lower level may be available.
        /// </summary>
        CANNOT_GRANT_REQUESTED_OPLOCK = 0x321,

        /// <summary>
        /// An oplock of the requested level cannot be granted. An oplock of a lower level may be available.
        /// </summary>
        CANNOT_BREAK_OPLOCK = 0x322,

        /// <summary>
        /// The handle with which this oplock was associated has been closed. The oplock is now broken.
        /// </summary>
        OPLOCK_HANDLE_CLOSED = 0x323,

        /// <summary>
        /// The specified access control entry (ACE) does not contain a condition.
        /// </summary>
        NO_ACE_CONDITION = 0x324,

        /// <summary>
        /// The specified access control entry (ACE) contains an invalid condition.
        /// </summary>
        INVALID_ACE_CONDITION = 0x325,

        /// <summary>
        /// Access to the specified file handle has been revoked.
        /// </summary>
        FILE_HANDLE_REVOKED = 0x326,

        /// <summary>
        /// An image file was mapped at a different address from the one specified in the image file but fixups will still be automatically performed on the image.
        /// </summary>
        IMAGE_AT_DIFFERENT_BASE = 0x327,

        /// <summary>
        /// Access to the extended attribute was denied.
        /// </summary>
        EA_ACCESS_DENIED = 0x3e2,

        /// <summary>
        /// The I/O operation has been aborted because of either a thread exit or an application request.
        /// </summary>
        OPERATION_ABORTED = 0x3e3,

        /// <summary>
        /// Overlapped I/O event is not in a signaled state.
        /// </summary>
        IO_INCOMPLETE = 0x3e4,

        /// <summary>
        /// Overlapped I/O operation is in progress.
        /// </summary>
        IO_PENDING = 0x3e5,

        /// <summary>
        /// Invalid access to memory location.
        /// </summary>
        NOACCESS = 0x3e6,

        /// <summary>
        /// Recursion too deep; the stack overflowed.
        /// </summary>
        STACK_OVERFLOW = 0x3e9,

        /// <summary>
        /// The window cannot act on the sent message.
        /// </summary>
        INVALID_MESSAGE = 0x3ea,

        /// <summary>
        /// Cannot complete this function.
        /// </summary>
        CAN_NOT_COMPLETE = 0x3eb,

        /// <summary>
        /// Invalid flags.
        /// </summary>
        INVALID_FLAGS = 0x3ec,

        /// <summary>
        /// Invalid flags.
        /// </summary>
        UNRECOGNIZED_VOLUME = 0x3ed,

        /// <summary>
        /// The volume for a file has been externally altered so that the opened file is no longer valid.
        /// </summary>
        FILE_INVALID = 0x3ee,

        /// <summary>
        /// The requested operation cannot be performed in full-screen mode.
        /// </summary>
        FULLSCREEN_MODE = 0x3ef,

        /// <summary>
        /// An attempt was made to reference a token that does not exist.
        /// </summary>
        NO_TOKEN = 0x3f0,

        /// <summary>
        /// The configuration registry database is corrupt.
        /// </summary>
        BADDB = 0x3f1,

        /// <summary>
        /// The configuration registry key is invalid.
        /// </summary>
        BADKEY = 0x3f2,

        /// <summary>
        /// The configuration registry key could not be opened.
        /// </summary>
        CANTOPEN = 0x3f3,

        /// <summary>
        /// The configuration registry key could not be read.
        /// </summary>
        CANTREAD = 0x3f4,

        /// <summary>
        /// The configuration registry key could not be written.
        /// </summary>
        CANTWRITE = 0x3f5,

        /// <summary>
        /// The configuration registry key could not be written.
        /// </summary>
        REGISTRY_RECOVERED = 0x3f6,

        /// <summary>
        /// The configuration registry key could not be written.
        /// </summary>
        REGISTRY_CORRUPT = 0x3f7,

        /// <summary>
        /// The configuration registry key could not be written.
        /// </summary>
        REGISTRY_IO_FAILED = 0x3f8,

        /// <summary>
        /// The configuration registry key could not be written.
        /// </summary>
        NOT_REGISTRY_FILE = 0x3f9,

        /// <summary>
        /// Illegal operation attempted on a registry key that has been marked for deletion.
        /// </summary>
        KEY_DELETED = 0x3fa,

        /// <summary>
        /// System could not allocate the required space in a registry log.
        /// </summary>
        NO_LOG_SPACE = 0x3fb,

        /// <summary>
        /// Cannot create a symbolic link in a registry key that already has subkeys or values.
        /// </summary>
        KEY_HAS_CHILDREN = 0x3fc,

        /// <summary>
        /// Cannot create a stable subkey under a volatile parent key.
        /// </summary>
        CHILD_MUST_BE_VOLATILE = 0x3fd,

        /// <summary>
        /// Cannot create a stable subkey under a volatile parent key.
        /// </summary>
        NOTIFY_ENUM_DIR = 0x3fe,

        /// <summary>
        /// A stop control has been sent to a service that other running services are dependent on.
        /// </summary>
        DEPENDENT_SERVICES_RUNNING = 0x41b,

        /// <summary>
        /// The requested control is not valid for this service.
        /// </summary>
        INVALID_SERVICE_CONTROL = 0x41c,

        /// <summary>
        /// The service did not respond to the start or control request in a timely fashion.
        /// </summary>
        SERVICE_REQUEST_TIMEOUT = 0x41d,

        /// <summary>
        /// A thread could not be created for the service.
        /// </summary>
        SERVICE_NO_THREAD = 0x41e,

        /// <summary>
        /// The service database is locked.
        /// </summary>
        SERVICE_DATABASE_LOCKED = 0x41f,

        /// <summary>
        /// An instance of the service is already running.
        /// </summary>
        SERVICE_ALREADY_RUNNING = 0x420,

        /// <summary>
        /// An instance of the service is already running.
        /// </summary>
        INVALID_SERVICE_ACCOUNT = 0x421,

        /// <summary>
        /// An instance of the service is already running.
        /// </summary>
        SERVICE_DISABLED = 0x422,

        /// <summary>
        /// Circular service dependency was  specified .
        /// </summary>
        CIRCULAR_DEPENDENCY = 0x423,

        /// <summary>
        /// The specified service does not exist as an installed service.
        /// </summary>
        SERVICE_DOES_NOT_EXIST = 0x424,

        /// <summary>
        /// The service cannot accept control messages at this time.
        /// </summary>
        SERVICE_CANNOT_ACCEPT_CTRL = 0x425,

        /// <summary>
        /// The service has not been started.
        /// </summary>
        SERVICE_NOT_ACTIVE = 0x426,

        /// <summary>
        /// The service process could not connect to the service controller.
        /// </summary>
        FAILED_SERVICE_CONTROLLER_CONNECT = 0x427,

        /// <summary>
        /// An exception occurred in the service when handling the control request.
        /// </summary>
        EXCEPTION_IN_SERVICE = 0x428,

        /// <summary>
        /// The database specified does not exist.
        /// </summary>
        DATABASE_DOES_NOT_EXIST = 0x429,

        /// <summary>
        /// The service has returned a service-specific error code.
        /// </summary>
        SERVICE_SPECIFIC_ERROR = 0x42a,

        /// <summary>
        /// The process terminated unexpectedly.
        /// </summary>
        PROCESS_ABORTED = 0x42b,

        /// <summary>
        /// The dependency service or group failed to start.
        /// </summary>
        SERVICE_DEPENDENCY_FAIL = 0x42c,

        /// <summary>
        /// The service did not start due to a logon failure.
        /// </summary>
        SERVICE_LOGON_FAILED = 0x42d,

        /// <summary>
        /// After starting, the service hung in a start-pending state.
        /// </summary>
        SERVICE_START_HANG = 0x42e,

        /// <summary>
        /// The specified service database lock is invalid.
        /// </summary>
        INVALID_SERVICE_LOCK = 0x42f,

        /// <summary>
        /// The specified service has been marked for deletion.
        /// </summary>
        SERVICE_MARKED_FOR_DELETE = 0x430,

        /// <summary>
        /// The specified service already exists.
        /// </summary>
        SERVICE_EXISTS = 0x431,

        /// <summary>
        /// The system is currently running with the last-known-good configuration.
        /// </summary>
        ALREADY_RUNNING_LKG = 0x432,

        /// <summary>
        /// The dependency service does not exist or has been marked for deletion.
        /// </summary>
        SERVICE_DEPENDENCY_DELETED = 0x433,

        /// <summary>
        /// The current boot has already been accepted for use as the last-known-good control set.
        /// </summary>
        BOOT_ALREADY_ACCEPTED = 0x434,

        /// <summary>
        /// No attempts to start the service have been made since the last boot.
        /// </summary>
        SERVICE_NEVER_STARTED = 0x435,

        /// <summary>
        /// The name is already in use as either a service name or a service display name.
        /// </summary>
        DUPLICATE_SERVICE_NAME = 0x436,

        /// <summary>
        /// The name is already in use as either a service name or a service display name.
        /// </summary>
        DIFFERENT_SERVICE_ACCOUNT = 0x437,

        /// <summary>
        /// Failure actions can only be set for Win32 services, not for drivers.
        /// </summary>
        CANNOT_DETECT_DRIVER_FAILURE = 0x438,

        /// <summary>
        /// Failure actions can only be set for Win32 services, not for drivers.
        /// </summary>
        CANNOT_DETECT_PROCESS_ABORT = 0x439,

        /// <summary>
        /// No recovery program has been configured for this service.
        /// </summary>
        NO_RECOVERY_PROGRAM = 0x43a,

        /// <summary>
        /// The executable program that this service is configured to run in does not implement the service.
        /// </summary>
        SERVICE_NOT_IN_EXE = 0x43b,

        /// <summary>
        /// This service cannot be started in Safe Mode.
        /// </summary>
        NOT_SAFEBOOT_SERVICE = 0x43c,

        /// <summary>
        /// The physical end of the tape has been reached.
        /// </summary>
        END_OF_MEDIA = 0x44c,

        /// <summary>
        /// A tape access reached a filemark.
        /// </summary>
        FILEMARK_DETECTED = 0x44d,

        /// <summary>
        /// The beginning of the tape or a partition was encountered.
        /// </summary>
        BEGINNING_OF_MEDIA = 0x44e,

        /// <summary>
        /// A tape access reached the end of a set of files.
        /// </summary>
        SETMARK_DETECTED = 0x44f,

        /// <summary>
        /// No more data is on the tape.
        /// </summary>
        NO_DATA_DETECTED = 0x450,

        /// <summary>
        /// Tape could not be partitioned.
        /// </summary>
        PARTITION_FAILURE = 0x451,

        /// <summary>
        /// When accessing a new tape of a multivolume partition, the current block size is incorrect.
        /// </summary>
        INVALID_BLOCK_LENGTH = 0x452,

        /// <summary>
        /// Tape partition information could not be found when loading a tape.
        /// </summary>
        DEVICE_NOT_PARTITIONED = 0x453,

        /// <summary>
        /// Unable to lock the media eject mechanism.
        /// </summary>
        UNABLE_TO_LOCK_MEDIA = 0x454,

        /// <summary>
        /// Unable to unload the media.
        /// </summary>
        UNABLE_TO_UNLOAD_MEDIA = 0x455,

        /// <summary>
        /// The media in the drive may have changed.
        /// </summary>
        MEDIA_CHANGED = 0x456,

        /// <summary>
        /// The I/O bus was reset.
        /// </summary>
        BUS_RESET = 0x457,

        /// <summary>
        /// No media in drive.
        /// </summary>
        NO_MEDIA_IN_DRIVE = 0x458,

        /// <summary>
        /// No mapping for the Unicode character exists in the target multi-byte code page.
        /// </summary>
        NO_UNICODE_TRANSLATION = 0x459,

        /// <summary>
        /// A dynamic link library (DLL) initialization routine failed.
        /// </summary>
        DLL_INIT_FAILED = 0x45a,

        /// <summary>
        /// A system shutdown is in progress.
        /// </summary>
        SHUTDOWN_IN_PROGRESS = 0x45b,

        /// <summary>
        /// Unable to abort the system shutdown because no shutdown was in progress.
        /// </summary>
        NO_SHUTDOWN_IN_PROGRESS = 0x45c,

        /// <summary>
        /// The request could not be performed because of an I/O device error.
        /// </summary>
        IO_DEVICE = 0x45d,

        /// <summary>
        /// No serial device was successfully initialized. The serial driver will unload.
        /// </summary>
        SERIAL_NO_DEVICE = 0x45e,

        /// <summary>
        /// No serial device was successfully initialized. The serial driver will unload.
        /// </summary>
        IRQ_BUSY = 0x45f,

        /// <summary>
        /// No serial device was successfully initialized. The serial driver will unload.
        /// </summary>
        MORE_WRITES = 0x460,

        /// <summary>
        /// No serial device was successfully initialized. The serial driver will unload.
        /// </summary>
        COUNTER_TIMEOUT = 0x461,

        /// <summary>
        /// No ID address mark was found on the floppy disk.
        /// </summary>
        FLOPPY_ID_MARK_NOT_FOUND = 0x462,

        /// <summary>
        /// Mismatch between the floppy disk sector ID field and the floppy disk controller track address.
        /// </summary>
        FLOPPY_WRONG_CYLINDER = 0x463,

        /// <summary>
        /// The floppy disk controller reported an error that is not recognized by the floppy disk driver.
        /// </summary>
        FLOPPY_UNKNOWN_ERROR = 0x464,

        /// <summary>
        /// The floppy disk controller returned inconsistent results in its registers.
        /// </summary>
        FLOPPY_BAD_REGISTERS = 0x465,

        /// <summary>
        /// While accessing the hard disk, a recalibrate operation failed, even after retries.
        /// </summary>
        DISK_RECALIBRATE_FAILED = 0x466,

        /// <summary>
        /// While accessing the hard disk, a disk operation failed even after retries.
        /// </summary>
        DISK_OPERATION_FAILED = 0x467,

        /// <summary>
        /// While accessing the hard disk, a disk controller reset was needed, but even that failed.
        /// </summary>
        DISK_RESET_FAILED = 0x468,

        /// <summary>
        /// Physical end of tape encountered.
        /// </summary>
        EOM_OVERFLOW = 0x469,

        /// <summary>
        /// Not enough server storage is available to process this command.
        /// </summary>
        NOT_ENOUGH_SERVER_MEMORY = 0x46a,

        /// <summary>
        /// A potential deadlock condition has been detected.
        /// </summary>
        POSSIBLE_DEADLOCK = 0x46b,

        /// <summary>
        /// The base address or the file offset specified does not have the proper alignment.
        /// </summary>
        MAPPED_ALIGNMENT = 0x46c,

        /// <summary>
        /// An attempt to change the system power state was vetoed by another application or driver.
        /// </summary>
        SET_POWER_STATE_VETOED = 0x474,

        /// <summary>
        /// The system BIOS failed an attempt to change the system power state.
        /// </summary>
        SET_POWER_STATE_FAILED = 0x475,

        /// <summary>
        /// An attempt was made to create more links on a file than the file system supports.
        /// </summary>
        TOO_MANY_LINKS = 0x476,

        /// <summary>
        /// The specified program requires a newer version of Windows.
        /// </summary>
        OLD_WIN_VERSION = 0x47e,

        /// <summary>
        /// The specified program is not a Windows or MS-DOS program.
        /// </summary>
        APP_WRONG_OS = 0x47f,

        /// <summary>
        /// Cannot start more than one instance of the specified program.
        /// </summary>
        SINGLE_INSTANCE_APP = 0x480,

        /// <summary>
        /// The specified program was written for an earlier version of Windows.
        /// </summary>
        RMODE_APP = 0x481,

        /// <summary>
        /// One of the library files needed to run this application is damaged.
        /// </summary>
        INVALID_DLL = 0x482,

        /// <summary>
        /// No application is associated with the specified file for this operation.
        /// </summary>
        NO_ASSOCIATION = 0x483,

        /// <summary>
        /// An error occurred in sending the command to the application.
        /// </summary>
        DDE_FAIL = 0x484,

        /// <summary>
        /// One of the library files needed to run this application cannot be found.
        /// </summary>
        DLnot_FOUND = 0x485,

        /// <summary>
        /// The current process has used all of its system allowance of handles for Window Manager objects.
        /// </summary>
        NO_MORE_USER_HANDLES = 0x486,

        /// <summary>
        /// The message can be used only with synchronous operations.
        /// </summary>
        MESSAGE_SYNC_ONLY = 0x487,

        /// <summary>
        /// The indicated source element has no media.
        /// </summary>
        SOURCE_ELEMENT_EMPTY = 0x488,

        /// <summary>
        /// The indicated destination element already contains media.
        /// </summary>
        DESTINATION_ELEMENT_FULL = 0x489,

        /// <summary>
        /// The indicated element does not exist.
        /// </summary>
        ILLEGAL_ELEMENT_ADDRESS = 0x48a,

        /// <summary>
        /// The indicated element is part of a magazine that is not present.
        /// </summary>
        MAGAZINE_NOT_PRESENT = 0x48b,

        /// <summary>
        /// The indicated device requires reinitialization due to hardware errors.
        /// </summary>
        DEVICE_REINITIALIZATION_NEEDED = 0x48c,

        /// <summary>
        /// The device has indicated that cleaning is required before further operations are attempted.
        /// </summary>
        DEVICE_REQUIRES_CLEANING = 0x48d,

        /// <summary>
        /// The device has indicated that its door is open.
        /// </summary>
        DEVICE_DOOR_OPEN = 0x48e,

        /// <summary>
        /// The device is not connected.
        /// </summary>
        DEVICE_NOT_CONNECTED = 0x48f,

        /// <summary>
        /// Element not found.
        /// </summary>
        NOT_FOUND = 0x490,

        /// <summary>
        /// There was no match for the specified key in the index.
        /// </summary>
        NO_MATCH = 0x491,

        /// <summary>
        /// The property set specified does not exist on the object.
        /// </summary>
        SET_NOT_FOUND = 0x492,

        /// <summary>
        /// The point passed to GetMouseMovePoints is not in the buffer.
        /// </summary>
        POINT_NOT_FOUND = 0x493,

        /// <summary>
        /// The tracking (workstation) service is not running.
        /// </summary>
        NO_TRACKING_SERVICE = 0x494,

        /// <summary>
        /// The Volume ID could not be found.
        /// </summary>
        NO_VOLUME_ID = 0x495,

        /// <summary>
        /// Unable to remove the file to be replaced.
        /// </summary>
        UNABLE_TO_REMOVE_REPLACED = 0x497,

        /// <summary>
        /// Unable to remove the file to be replaced.
        /// </summary>
        UNABLE_TO_MOVE_REPLACEMENT = 0x498,

        /// <summary>
        /// Unable to remove the file to be replaced.
        /// </summary>
        UNABLE_TO_MOVE_REPLACEMENT_2 = 0x499,

        /// <summary>
        /// The volume change journal is being deleted.
        /// </summary>
        JOURNAL_DELETE_IN_PROGRESS = 0x49a,

        /// <summary>
        /// The volume change journal is not active.
        /// </summary>
        JOURNAnot_ACTIVE = 0x49b,

        /// <summary>
        /// A file was found, but it may not be the correct file.
        /// </summary>
        POTENTIAfile_FOUND = 0x49c,

        /// <summary>
        /// The journal entry has been deleted from the journal.
        /// </summary>
        JOURNAL_ENTRY_DELETED = 0x49d,

        /// <summary>
        /// A system shutdown has already been scheduled.
        /// </summary>
        SHUTDOWN_IS_SCHEDULED = 0x4a6,

        /// <summary>
        /// The system shutdown cannot be initiated because there are other users logged on to the computer.
        /// </summary>
        SHUTDOWN_USERS_LOGGED_ON = 0x4a7,

        /// <summary>
        /// The specified device name is invalid.
        /// </summary>
        BAD_DEVICE = 0x4b0,

        /// <summary>
        /// The device is not currently connected but it is a remembered connection.
        /// </summary>
        CONNECTION_UNAVAIL = 0x4b1,

        /// <summary>
        /// The local device name has a remembered connection to another network resource.
        /// </summary>
        DEVICE_ALREADY_REMEMBERED = 0x4b2,

        /// <summary>
        /// The local device name has a remembered connection to another network resource.
        /// </summary>
        NO_NET_OR_BAD_PATH = 0x4b3,

        /// <summary>
        /// The specified network provider name is invalid.
        /// </summary>
        BAD_PROVIDER = 0x4b4,

        /// <summary>
        /// Unable to open the network connection profile.
        /// </summary>
        CANNOT_OPEN_PROFILE = 0x4b5,

        /// <summary>
        /// The network connection profile is corrupted.
        /// </summary>
        BAD_PROFILE = 0x4b6,

        /// <summary>
        /// Cannot enumerate a noncontainer.
        /// </summary>
        NOT_CONTAINER = 0x4b7,

        /// <summary>
        /// An extended error has occurred.
        /// </summary>
        EXTENDED_ERROR = 0x4b8,

        /// <summary>
        /// The format of the specified group name is invalid.
        /// </summary>
        INVALID_GROUPNAME = 0x4b9,

        /// <summary>
        /// The format of the specified computer name is invalid.
        /// </summary>
        INVALID_COMPUTERNAME = 0x4ba,

        /// <summary>
        /// The format of the specified event name is invalid.
        /// </summary>
        INVALID_EVENTNAME = 0x4bb,

        /// <summary>
        /// The format of the specified domain name is invalid.
        /// </summary>
        INVALID_DOMAINNAME = 0x4bc,

        /// <summary>
        /// The format of the specified service name is invalid.
        /// </summary>
        INVALID_SERVICENAME = 0x4bd,

        /// <summary>
        /// The format of the specified network name is invalid.
        /// </summary>
        INVALID_NETNAME = 0x4be,

        /// <summary>
        /// The format of the specified share name is invalid.
        /// </summary>
        INVALID_SHARENAME = 0x4bf,

        /// <summary>
        /// The format of the specified password is invalid.
        /// </summary>
        INVALID_PASSWORDNAME = 0x4c0,

        /// <summary>
        /// The format of the specified message name is invalid.
        /// </summary>
        INVALID_MESSAGENAME = 0x4c1,

        /// <summary>
        /// The format of the specified message destination is invalid.
        /// </summary>
        INVALID_MESSAGEDEST = 0x4c2,

        /// <summary>
        /// The format of the specified message destination is invalid.
        /// </summary>
        SESSION_CREDENTIAcONFLICT = 0x4c3,

        /// <summary>
        /// The format of the specified message destination is invalid.
        /// </summary>
        REMOTE_SESSION_LIMIT_EXCEEDED = 0x4c4,

        /// <summary>
        /// The workgroup or domain name is already in use by another computer on the network.
        /// </summary>
        DUP_DOMAINNAME = 0x4c5,

        /// <summary>
        /// The network is not present or not started.
        /// </summary>
        NO_NETWORK = 0x4c6,

        /// <summary>
        /// The operation was canceled by the user.
        /// </summary>
        CANCELLED = 0x4c7,

        /// <summary>
        /// The requested operation cannot be performed on a file with a user-mapped section open.
        /// </summary>
        USER_MAPPED_FILE = 0x4c8,

        /// <summary>
        /// The remote computer refused the network connection.
        /// </summary>
        CONNECTION_REFUSED = 0x4c9,

        /// <summary>
        /// The network connection was gracefully closed.
        /// </summary>
        GRACEFUL_DISCONNECT = 0x4ca,

        /// <summary>
        /// The network transport endpoint already has an address associated with it.
        /// </summary>
        ADDRESS_ALREADY_ASSOCIATED = 0x4cb,

        /// <summary>
        /// An address has not yet been associated with the network endpoint.
        /// </summary>
        ADDRESS_NOT_ASSOCIATED = 0x4cc,

        /// <summary>
        /// An operation was attempted on a nonexistent network connection.
        /// </summary>
        CONNECTION_INVALID = 0x4cd,

        /// <summary>
        /// An invalid operation was attempted on an active network connection.
        /// </summary>
        CONNECTION_ACTIVE = 0x4ce,

        /// <summary>
        /// An invalid operation was attempted on an active network connection.
        /// </summary>
        NETWORK_UNREACHABLE = 0x4cf,

        /// <summary>
        /// An invalid operation was attempted on an active network connection.
        /// </summary>
        HOST_UNREACHABLE = 0x4d0,

        /// <summary>
        /// An invalid operation was attempted on an active network connection.
        /// </summary>
        PROTOCOL_UNREACHABLE = 0x4d1,

        /// <summary>
        /// No service is operating at the destination network endpoint on the remote system.
        /// </summary>
        PORT_UNREACHABLE = 0x4d2,

        /// <summary>
        /// The request was aborted.
        /// </summary>
        REQUEST_ABORTED = 0x4d3,

        /// <summary>
        /// The network connection was aborted by the local system.
        /// </summary>
        CONNECTION_ABORTED = 0x4d4,

        /// <summary>
        /// The operation could not be completed. A retry should be performed.
        /// </summary>
        RETRY = 0x4d5,

        /// <summary>
        /// The operation could not be completed. A retry should be performed.
        /// </summary>
        CONNECTION_COUNT_LIMIT = 0x4d6,

        /// <summary>
        /// Attempting to log in during an unauthorized time of day for this account.
        /// </summary>
        LOGIN_TIME_RESTRICTION = 0x4d7,

        /// <summary>
        /// The account is not authorized to log in from this station.
        /// </summary>
        LOGIN_WKSTA_RESTRICTION = 0x4d8,

        /// <summary>
        /// The network address could not be used for the operation requested.
        /// </summary>
        INCORRECT_ADDRESS = 0x4d9,

        /// <summary>
        /// The service is already registered.
        /// </summary>
        ALREADY_REGISTERED = 0x4da,

        /// <summary>
        /// The specified service does not exist.
        /// </summary>
        SERVICE_NOT_FOUND = 0x4db,

        /// <summary>
        /// The operation being requested was not performed because the user has not been authenticated.
        /// </summary>
        NOT_AUTHENTICATED = 0x4dc,

        /// <summary>
        /// The operation being requested was not performed because the user has not been authenticated.
        /// </summary>
        NOT_LOGGED_ON = 0x4dd,

        /// <summary>
        /// Continue with work in progress.
        /// </summary>
        CONTINUE = 0x4de,

        /// <summary>
        /// Continue with work in progress.
        /// </summary>
        ALREADY_INITIALIZED = 0x4df,

        /// <summary>
        /// No more local devices.
        /// </summary>
        NO_MORE_DEVICES = 0x4e0,

        /// <summary>
        /// The specified site does not exist.
        /// </summary>
        NO_SUCH_SITE = 0x4e1,

        /// <summary>
        /// A domain controller with the specified name already exists.
        /// </summary>
        DOMAIN_CONTROLLER_EXISTS = 0x4e2,

        /// <summary>
        /// This operation is supported only when you are connected to the server.
        /// </summary>
        ONLY_IF_CONNECTED = 0x4e3,

        /// <summary>
        /// The group policy framework should call the extension even if there are no changes.
        /// </summary>
        OVERRIDE_NOCHANGES = 0x4e4,

        /// <summary>
        /// The specified user does not have a valid profile.
        /// </summary>
        BAD_USER_PROFILE = 0x4e5,

        /// <summary>
        /// This operation is not supported on a computer running Windows Server 2003 for Small Business Server.
        /// </summary>
        NOT_SUPPORTED_ON_SBS = 0x4e6,

        /// <summary>
        /// The server machine is shutting down.
        /// </summary>
        SERVER_SHUTDOWN_IN_PROGRESS = 0x4e7,

        /// <summary>
        /// The remote system is not available. For information about network troubleshooting, see Windows Help.
        /// </summary>
        HOST_DOWN = 0x4e8,

        /// <summary>
        /// The security identifier provided is not from an account domain.
        /// </summary>
        NON_ACCOUNT_SID = 0x4e9,

        /// <summary>
        /// The security identifier provided does not have a domain component.
        /// </summary>
        NON_DOMAIN_SID = 0x4ea,

        /// <summary>
        /// AppHelp dialog canceled thus preventing the application from starting.
        /// </summary>
        APPHELP_BLOCK = 0x4eb,

        /// <summary>
        /// This program is blocked by group policy. For more information, contact your system administrator.
        /// </summary>
        ACCESS_DISABLED_BY_POLICY = 0x4ec,

        /// <summary>
        /// This program is blocked by group policy. For more information, contact your system administrator.
        /// </summary>
        REG_NAT_CONSUMPTION = 0x4ed,

        /// <summary>
        /// The share is currently offline or does not exist.
        /// </summary>
        CSCSHARE_OFFLINE = 0x4ee,

        /// <summary>
        /// The share is currently offline or does not exist.
        /// </summary>
        PKINIT_FAILURE = 0x4ef,

        /// <summary>
        /// The Kerberos protocol encountered an error while attempting to utilize the smartcard subsystem.
        /// </summary>
        SMARTCARD_SUBSYSTEM_FAILURE = 0x4f0,

        /// <summary>
        /// The Kerberos protocol encountered an error while attempting to utilize the smartcard subsystem.
        /// </summary>
        DOWNGRADE_DETECTED = 0x4f1,

        /// <summary>
        /// The machine is locked and cannot be shut down without the force option.
        /// </summary>
        MACHINE_LOCKED = 0x4f7,

        /// <summary>
        /// An application-defined callback gave invalid data when called.
        /// </summary>
        CALLBACK_SUPPLIED_INVALID_DATA = 0x4f9,

        /// <summary>
        /// The group policy framework should call the extension in the synchronous foreground policy refresh.
        /// </summary>
        SYNC_FOREGROUND_REFRESH_REQUIRED = 0x4fa,

        /// <summary>
        /// This driver has been blocked from loading.
        /// </summary>
        DRIVER_BLOCKED = 0x4fb,

        /// <summary>
        /// This driver has been blocked from loading.
        /// </summary>
        INVALID_IMPORT_OF_NON_DLL = 0x4fc,

        /// <summary>
        /// Windows cannot open this program since it has been disabled.
        /// </summary>
        ACCESS_DISABLED_WEBBLADE = 0x4fd,

        /// <summary>
        /// Windows cannot open this program since it has been disabled.
        /// </summary>
        ACCESS_DISABLED_WEBBLADE_TAMPER = 0x4fe,

        /// <summary>
        /// A transaction recover failed.
        /// </summary>
        RECOVERY_FAILURE = 0x4ff,

        /// <summary>
        /// The current thread has already been converted to a fiber.
        /// </summary>
        ALREADY_FIBER = 0x500,

        /// <summary>
        /// The current thread has already been converted from a fiber.
        /// </summary>
        ALREADY_THREAD = 0x501,

        /// <summary>
        /// The current thread has already been converted from a fiber.
        /// </summary>
        STACK_BUFFER_OVERRUN = 0x502,

        /// <summary>
        /// Data present in one of the parameters is more than the function can operate on.
        /// </summary>
        PARAMETER_QUOTA_EXCEEDED = 0x503,

        /// <summary>
        /// Data present in one of the parameters is more than the function can operate on.
        /// </summary>
        DEBUGGER_INACTIVE = 0x504,

        /// <summary>
        /// An attempt to delay-load a .dll or get a function address in a delay-loaded .dll failed.
        /// </summary>
        DELAY_LOAD_FAILED = 0x505,

        /// <summary>
        /// An attempt to delay-load a .dll or get a function address in a delay-loaded .dll failed.
        /// </summary>
        VDM_DISALLOWED = 0x506,

        /// <summary>
        /// Insufficient information exists to identify the cause of failure.
        /// </summary>
        UNIDENTIFIED_ERROR = 0x507,

        /// <summary>
        /// The parameter passed to a C runtime function is incorrect.
        /// </summary>
        INVALID_CRUNTIME_PARAMETER = 0x508,

        /// <summary>
        /// The operation occurred beyond the valid data length of the file.
        /// </summary>
        BEYOND_VDL = 0x509,

        /// <summary>
        /// The operation occurred beyond the valid data length of the file.
        /// </summary>
        INCOMPATIBLE_SERVICE_SID_TYPE = 0x50a,

        /// <summary>
        /// The process hosting the driver for this device has been terminated.
        /// </summary>
        DRIVER_PROCESS_TERMINATED = 0x50b,

        /// <summary>
        /// An operation attempted to exceed an implementation-defined limit.
        /// </summary>
        IMPLEMENTATION_LIMIT = 0x50c,

        /// <summary>
        /// Either the target process, or the target thread's containing process, is a protected process.
        /// </summary>
        PROCESS_IS_PROTECTED = 0x50d,

        /// <summary>
        /// Either the target process, or the target thread's containing process, is a protected process.
        /// </summary>
        SERVICE_NOTIFY_CLIENT_LAGGING = 0x50e,

        /// <summary>
        /// Either the target process, or the target thread's containing process, is a protected process.
        /// </summary>
        DISK_QUOTA_EXCEEDED = 0x50f,

        /// <summary>
        /// Either the target process, or the target thread's containing process, is a protected process.
        /// </summary>
        CONTENT_BLOCKED = 0x510,

        /// <summary>
        /// Either the target process, or the target thread's containing process, is a protected process.
        /// </summary>
        INCOMPATIBLE_SERVICE_PRIVILEGE = 0x511,

        /// <summary>
        /// A thread involved in this operation appears to be unresponsive.
        /// </summary>
        APP_HANG = 0x512,

        /// <summary>
        /// Not all privileges or groups referenced are assigned to the caller.
        /// </summary>
        NOT_ALaSSIGNED = 0x514,

        /// <summary>
        /// Some mapping between account names and security IDs was not done.
        /// </summary>
        SOME_NOT_MAPPED = 0x515,

        /// <summary>
        /// No system quota limits are specifically set for this account.
        /// </summary>
        NO_QUOTAS_FOR_ACCOUNT = 0x516,

        /// <summary>
        /// No encryption key is available. A well-known encryption key was returned.
        /// </summary>
        LOCAL_USER_SESSION_KEY = 0x517,

        /// <summary>
        /// No encryption key is available. A well-known encryption key was returned.
        /// </summary>
        NULL_LM_PASSWORD = 0x518,

        /// <summary>
        /// The revision level is unknown.
        /// </summary>
        UNKNOWN_REVISION = 0x519,

        /// <summary>
        /// Indicates two revision levels are incompatible.
        /// </summary>
        REVISION_MISMATCH = 0x51a,

        /// <summary>
        /// This security ID may not be assigned as the owner of this object.
        /// </summary>
        INVALID_OWNER = 0x51b,

        /// <summary>
        /// This security ID may not be assigned as the primary group of an object.
        /// </summary>
        INVALID_PRIMARY_GROUP = 0x51c,

        /// <summary>
        /// This security ID may not be assigned as the primary group of an object.
        /// </summary>
        NO_IMPERSONATION_TOKEN = 0x51d,

        /// <summary>
        /// The group may not be disabled.
        /// </summary>
        CANT_DISABLE_MANDATORY = 0x51e,

        /// <summary>
        /// There are currently no logon servers available to service the logon request.
        /// </summary>
        NO_LOGON_SERVERS = 0x51f,

        /// <summary>
        /// A specified logon session does not exist. It may already have been terminated.
        /// </summary>
        NO_SUCH_LOGON_SESSION = 0x520,

        /// <summary>
        /// A specified privilege does not exist.
        /// </summary>
        NO_SUCH_PRIVILEGE = 0x521,

        /// <summary>
        /// A required privilege is not held by the client.
        /// </summary>
        PRIVILEGE_NOT_HELD = 0x522,

        /// <summary>
        /// The name provided is not a properly formed account name.
        /// </summary>
        INVALID_ACCOUNT_NAME = 0x523,

        /// <summary>
        /// The specified account already exists.
        /// </summary>
        USER_EXISTS = 0x524,

        /// <summary>
        /// The specified account does not exist.
        /// </summary>
        NO_SUCH_USER = 0x525,

        /// <summary>
        /// The specified group already exists.
        /// </summary>
        GROUP_EXISTS = 0x526,

        /// <summary>
        /// The specified group does not exist.
        /// </summary>
        NO_SUCH_GROUP = 0x527,

        /// <summary>
        /// The specified group does not exist.
        /// </summary>
        MEMBER_IN_GROUP = 0x528,

        /// <summary>
        /// The specified user account is not a member of the specified group account.
        /// </summary>
        MEMBER_NOT_IN_GROUP = 0x529,

        /// <summary>
        /// This operation is disallowed as it could result in an administration account being disabled, deleted or unable to log on.
        /// </summary>
        LAST_ADMIN = 0x52a,

        /// <summary>
        /// Unable to update the password. The value provided as the current password is incorrect.
        /// </summary>
        WRONG_PASSWORD = 0x52b,

        /// <summary>
        /// Unable to update the password. The value provided as the current password is incorrect.
        /// </summary>
        ILL_FORMED_PASSWORD = 0x52c,

        /// <summary>
        /// Unable to update the password. The value provided as the current password is incorrect.
        /// </summary>
        PASSWORD_RESTRICTION = 0x52d,

        /// <summary>
        /// The user name or password is incorrect.
        /// </summary>
        LOGON_FAILURE = 0x52e,

        /// <summary>
        /// The user name or password is incorrect.
        /// </summary>
        ACCOUNT_RESTRICTION = 0x52f,

        /// <summary>
        /// Your account has time restrictions that keep you from signing in right now.
        /// </summary>
        INVALID_LOGON_HOURS = 0x530,

        /// <summary>
        /// This user isn't allowed to sign in to this computer.
        /// </summary>
        INVALID_WORKSTATION = 0x531,

        /// <summary>
        /// The password for this account has expired.
        /// </summary>
        PASSWORD_EXPIRED = 0x532,

        /// <summary>
        /// This user can't sign in because this account is currently disabled.
        /// </summary>
        ACCOUNT_DISABLED = 0x533,

        /// <summary>
        /// No mapping between account names and security IDs was done.
        /// </summary>
        NONE_MAPPED = 0x534,

        /// <summary>
        /// Too many local user identifiers (LUIDs) were requested at one time.
        /// </summary>
        TOO_MANY_LUIDS_REQUESTED = 0x535,

        /// <summary>
        /// No more local user identifiers (LUIDs) are available.
        /// </summary>
        LUIDS_EXHAUSTED = 0x536,

        /// <summary>
        /// The subauthority part of a security ID is invalid for this particular use.
        /// </summary>
        INVALID_SUB_AUTHORITY = 0x537,

        /// <summary>
        /// The access control list (ACL) structure is invalid.
        /// </summary>
        INVALID_ACL = 0x538,

        /// <summary>
        /// The security ID structure is invalid.
        /// </summary>
        INVALID_SID = 0x539,

        /// <summary>
        /// The security descriptor structure is invalid.
        /// </summary>
        INVALID_SECURITY_DESCR = 0x53a,

        /// <summary>
        /// The inherited access control list (ACL) or access control entry (ACE) could not be built.
        /// </summary>
        BAD_INHERITANCE_ACL = 0x53c,

        /// <summary>
        /// The server is currently disabled.
        /// </summary>
        SERVER_DISABLED = 0x53d,

        /// <summary>
        /// The server is currently enabled.
        /// </summary>
        SERVER_NOT_DISABLED = 0x53e,

        /// <summary>
        /// The value provided was an invalid value for an identifier authority.
        /// </summary>
        INVALID_ID_AUTHORITY = 0x53f,

        /// <summary>
        /// No more memory is available for security information updates.
        /// </summary>
        ALLOTTED_SPACE_EXCEEDED = 0x540,

        /// <summary>
        /// The specified attributes are invalid, or incompatible with the attributes for the group as a whole.
        /// </summary>
        INVALID_GROUP_ATTRIBUTES = 0x541,

        /// <summary>
        /// Either a required impersonation level was not provided, or the provided impersonation level is invalid.
        /// </summary>
        BAD_IMPERSONATION_LEVEL = 0x542,

        /// <summary>
        /// Cannot open an anonymous level security token.
        /// </summary>
        CANT_OPEN_ANONYMOUS = 0x543,

        /// <summary>
        /// The validation information class requested was invalid.
        /// </summary>
        BAD_VALIDATION_CLASS = 0x544,

        /// <summary>
        /// The type of the token is inappropriate for its attempted use.
        /// </summary>
        BAD_TOKEN_TYPE = 0x545,

        /// <summary>
        /// Unable to perform a security operation on an object that has no associated security.
        /// </summary>
        NO_SECURITY_ON_OBJECT = 0x546,

        /// <summary>
        /// Unable to perform a security operation on an object that has no associated security.
        /// </summary>
        CANT_ACCESS_DOMAIN_INFO = 0x547,

        /// <summary>
        /// Unable to perform a security operation on an object that has no associated security.
        /// </summary>
        INVALID_SERVER_STATE = 0x548,

        /// <summary>
        /// The domain was in the wrong state to perform the security operation.
        /// </summary>
        INVALID_DOMAIN_STATE = 0x549,

        /// <summary>
        /// This operation is only allowed for the Primary Domain Controller of the domain.
        /// </summary>
        INVALID_DOMAIN_ROLE = 0x54a,

        /// <summary>
        /// The specified domain either does not exist or could not be contacted.
        /// </summary>
        NO_SUCH_DOMAIN = 0x54b,

        /// <summary>
        /// The specified domain already exists.
        /// </summary>
        DOMAIN_EXISTS = 0x54c,

        /// <summary>
        /// An attempt was made to exceed the limit on the number of domains per server.
        /// </summary>
        DOMAIN_LIMIT_EXCEEDED = 0x54d,

        /// <summary>
        /// An attempt was made to exceed the limit on the number of domains per server.
        /// </summary>
        INTERNAL_DB_CORRUPTION = 0x54e,

        /// <summary>
        /// An internal error occurred.
        /// </summary>
        INTERNAerror = 0x54f,

        /// <summary>
        /// An internal error occurred.
        /// </summary>
        GENERIC_NOT_MAPPED = 0x550,

        /// <summary>
        /// A security descriptor is not in the right format (absolute or self-relative).
        /// </summary>
        BAD_DESCRIPTOR_FORMAT = 0x551,

        /// <summary>
        /// A security descriptor is not in the right format (absolute or self-relative).
        /// </summary>
        NOT_LOGON_PROCESS = 0x552,

        /// <summary>
        /// Cannot start a new logon session with an ID that is already in use.
        /// </summary>
        LOGON_SESSION_EXISTS = 0x553,

        /// <summary>
        /// A specified authentication package is unknown.
        /// </summary>
        NO_SUCH_PACKAGE = 0x554,

        /// <summary>
        /// The logon session is not in a state that is consistent with the requested operation.
        /// </summary>
        BAD_LOGON_SESSION_STATE = 0x555,

        /// <summary>
        /// The logon session ID is already in use.
        /// </summary>
        LOGON_SESSION_COLLISION = 0x556,

        /// <summary>
        /// A logon request contained an invalid logon type value.
        /// </summary>
        INVALID_LOGON_TYPE = 0x557,

        /// <summary>
        /// Unable to impersonate using a named pipe until data has been read from that pipe.
        /// </summary>
        CANNOT_IMPERSONATE = 0x558,

        /// <summary>
        /// The transaction state of a registry subtree is incompatible with the requested operation.
        /// </summary>
        RXACT_INVALID_STATE = 0x559,

        /// <summary>
        /// An internal security database corruption has been encountered.
        /// </summary>
        RXACT_COMMIT_FAILURE = 0x55a,

        /// <summary>
        /// Cannot perform this operation on built-in accounts.
        /// </summary>
        SPECIAaCCOUNT = 0x55b,

        /// <summary>
        /// Cannot perform this operation on this built-in special group.
        /// </summary>
        SPECIAL_GROUP = 0x55c,

        /// <summary>
        /// Cannot perform this operation on this built-in special user.
        /// </summary>
        SPECIAL_USER = 0x55d,

        /// <summary>
        /// The user cannot be removed from a group because the group is currently the user's primary group.
        /// </summary>
        MEMBERS_PRIMARY_GROUP = 0x55e,

        /// <summary>
        /// The token is already in use as a primary token.
        /// </summary>
        TOKEN_ALREADY_IN_USE = 0x55f,

        /// <summary>
        /// The specified local group does not exist.
        /// </summary>
        NO_SUCH_ALIAS = 0x560,

        /// <summary>
        /// The specified account name is not a member of the group.
        /// </summary>
        MEMBER_NOT_IN_ALIAS = 0x561,

        /// <summary>
        /// The specified account name is already a member of the group.
        /// </summary>
        MEMBER_IN_ALIAS = 0x562,

        /// <summary>
        /// The specified local group already exists.
        /// </summary>
        ALIAS_EXISTS = 0x563,

        /// <summary>
        /// Logon failure: the user has not been granted the requested logon type at this computer.
        /// </summary>
        LOGON_NOT_GRANTED = 0x564,

        /// <summary>
        /// The maximum number of secrets that may be stored in a single system has been exceeded.
        /// </summary>
        TOO_MANY_SECRETS = 0x565,

        /// <summary>
        /// The length of a secret exceeds the maximum length allowed.
        /// </summary>
        SECRET_TOO_LONG = 0x566,

        /// <summary>
        /// The local security authority database contains an internal inconsistency.
        /// </summary>
        INTERNAL_DB_ERROR = 0x567,

        /// <summary>
        /// During a logon attempt, the user's security context accumulated too many security IDs.
        /// </summary>
        TOO_MANY_CONTEXT_IDS = 0x568,

        /// <summary>
        /// Logon failure: the user has not been granted the requested logon type at this computer.
        /// </summary>
        LOGON_TYPE_NOT_GRANTED = 0x569,

        /// <summary>
        /// A cross-encrypted password is necessary to change a user password.
        /// </summary>
        NT_CROSS_ENCRYPTION_REQUIRED = 0x56a,

        /// <summary>
        /// A member could not be added to or removed from the local group because the member does not exist.
        /// </summary>
        NO_SUCH_MEMBER = 0x56b,

        /// <summary>
        /// A new member could not be added to a local group because the member has the wrong account type.
        /// </summary>
        INVALID_MEMBER = 0x56c,

        /// <summary>
        /// Too many security IDs have been  specified .
        /// </summary>
        TOO_MANY_SIDS = 0x56d,

        /// <summary>
        /// A cross-encrypted password is necessary to change this user password.
        /// </summary>
        LM_CROSS_ENCRYPTION_REQUIRED = 0x56e,

        /// <summary>
        /// Indicates an ACL contains no inheritable components.
        /// </summary>
        NO_INHERITANCE = 0x56f,

        /// <summary>
        /// The file or directory is corrupted and unreadable.
        /// </summary>
        FILE_CORRUPT = 0x570,

        /// <summary>
        /// The disk structure is corrupted and unreadable.
        /// </summary>
        DISK_CORRUPT = 0x571,

        /// <summary>
        /// There is no user session key for the specified logon session.
        /// </summary>
        NO_USER_SESSION_KEY = 0x572,

        /// <summary>
        /// There is no user session key for the specified logon session.
        /// </summary>
        LICENSE_QUOTA_EXCEEDED = 0x573,

        /// <summary>
        /// The target account name is incorrect.
        /// </summary>
        WRONG_TARGET_NAME = 0x574,

        /// <summary>
        /// Mutual Authentication failed. The server's password is out of date at the domain controller.
        /// </summary>
        MUTUAaUTH_FAILED = 0x575,

        /// <summary>
        /// There is a time and/or date difference between the client and server.
        /// </summary>
        TIME_SKEW = 0x576,

        /// <summary>
        /// This operation cannot be performed on the current domain.
        /// </summary>
        CURRENT_DOMAIN_NOT_ALLOWED = 0x577,

        /// <summary>
        /// Invalid window handle.
        /// </summary>
        INVALID_WINDOW_HANDLE = 0x578,

        /// <summary>
        /// Invalid menu handle.
        /// </summary>
        INVALID_MENU_HANDLE = 0x579,

        /// <summary>
        /// Invalid cursor handle.
        /// </summary>
        INVALID_CURSOR_HANDLE = 0x57a,

        /// <summary>
        /// Invalid accelerator table handle.
        /// </summary>
        INVALID_ACCEL_HANDLE = 0x57b,

        /// <summary>
        /// Invalid hook handle.
        /// </summary>
        INVALID_HOOK_HANDLE = 0x57c,

        /// <summary>
        /// Invalid handle to a multiple-window position structure.
        /// </summary>
        INVALID_DWP_HANDLE = 0x57d,

        /// <summary>
        /// Cannot create a top-level child window.
        /// </summary>
        TLW_WITH_WSCHILD = 0x57e,

        /// <summary>
        /// Cannot find window class.
        /// </summary>
        CANNOT_FIND_WND_CLASS = 0x57f,

        /// <summary>
        /// Invalid window; it belongs to other thread.
        /// </summary>
        WINDOW_OF_OTHER_THREAD = 0x580,

        /// <summary>
        /// Hot key is already registered.
        /// </summary>
        HOTKEY_ALREADY_REGISTERED = 0x581,

        /// <summary>
        /// Class already exists.
        /// </summary>
        CLASS_ALREADY_EXISTS = 0x582,

        /// <summary>
        /// Class does not exist.
        /// </summary>
        CLASS_DOES_NOT_EXIST = 0x583,

        /// <summary>
        /// Class still has open windows.
        /// </summary>
        CLASS_HAS_WINDOWS = 0x584,

        /// <summary>
        /// Invalid index.
        /// </summary>
        INVALID_INDEX = 0x585,

        /// <summary>
        /// Invalid icon handle.
        /// </summary>
        INVALID_ICON_HANDLE = 0x586,

        /// <summary>
        /// Using private DIALOG window words.
        /// </summary>
        PRIVATE_DIALOG_INDEX = 0x587,

        /// <summary>
        /// The list box identifier was not found.
        /// </summary>
        LISTBOX_ID_NOT_FOUND = 0x588,

        /// <summary>
        /// No wildcards were found.
        /// </summary>
        NO_WILDCARD_CHARACTERS = 0x589,

        /// <summary>
        /// Thread does not have a clipboard open.
        /// </summary>
        CLIPBOARD_NOT_OPEN = 0x58a,

        /// <summary>
        /// Hot key is not registered.
        /// </summary>
        HOTKEY_NOT_REGISTERED = 0x58b,

        /// <summary>
        /// The window is not a valid dialog window.
        /// </summary>
        WINDOW_NOT_DIALOG = 0x58c,

        /// <summary>
        /// Control ID not found.
        /// </summary>
        CONTROL_ID_NOT_FOUND = 0x58d,

        /// <summary>
        /// Invalid message for a combo box because it does not have an edit control.
        /// </summary>
        INVALID_COMBOBOX_MESSAGE = 0x58e,

        /// <summary>
        /// The window is not a combo box.
        /// </summary>
        WINDOW_NOT_COMBOBOX = 0x58f,

        /// <summary>
        /// Height must be less than 256.
        /// </summary>
        INVALID_EDIT_HEIGHT = 0x590,

        /// <summary>
        /// Invalid device context (DC) handle.
        /// </summary>
        DC_NOT_FOUND = 0x591,

        /// <summary>
        /// Invalid hook procedure type.
        /// </summary>
        INVALID_HOOK_FILTER = 0x592,

        /// <summary>
        /// Invalid hook procedure.
        /// </summary>
        INVALID_FILTER_PROC = 0x593,

        /// <summary>
        /// Cannot set nonlocal hook without a module handle.
        /// </summary>
        HOOK_NEEDS_HMOD = 0x594,

        /// <summary>
        /// This hook procedure can only be set globally.
        /// </summary>
        GLOBAL_ONLY_HOOK = 0x595,

        /// <summary>
        /// The journal hook procedure is already installed.
        /// </summary>
        JOURNAL_HOOK_SET = 0x596,

        /// <summary>
        /// The hook procedure is not installed.
        /// </summary>
        HOOK_NOT_INSTALLED = 0x597,

        /// <summary>
        /// Invalid message for single-selection list box.
        /// </summary>
        INVALID_LB_MESSAGE = 0x598,

        /// <summary>
        /// LB_SETCOUNT sent to non-lazy list box.
        /// </summary>
        SETCOUNT_ON_BAD_LB = 0x599,

        /// <summary>
        /// This list box does not support tab stops.
        /// </summary>
        LB_WITHOUT_TABSTOPS = 0x59a,

        /// <summary>
        /// Cannot destroy object created by another thread.
        /// </summary>
        DESTROY_OBJECT_OF_OTHER_THREAD = 0x59b,

        /// <summary>
        /// Child windows cannot have menus.
        /// </summary>
        CHILD_WINDOW_MENU = 0x59c,

        /// <summary>
        /// The window does not have a system menu.
        /// </summary>
        NO_SYSTEM_MENU = 0x59d,

        /// <summary>
        /// Invalid message box style.
        /// </summary>
        INVALID_MSGBOX_STYLE = 0x59e,

        /// <summary>
        /// Invalid system-wide (SPI_*) parameter.
        /// </summary>
        INVALID_SPI_VALUE = 0x59f,

        /// <summary>
        /// Screen already locked.
        /// </summary>
        SCREEN_ALREADY_LOCKED = 0x5a0,

        /// <summary>
        /// All handles to windows in a multiple-window position structure must have the same parent.
        /// </summary>
        HWNDS_HAVE_DIFF_PARENT = 0x5a1,

        /// <summary>
        /// The window is not a child window.
        /// </summary>
        NOT_CHILD_WINDOW = 0x5a2,

        /// <summary>
        /// Invalid GW_* command.
        /// </summary>
        INVALID_GW_COMMAND = 0x5a3,

        /// <summary>
        /// Invalid thread identifier.
        /// </summary>
        INVALID_THREAD_ID = 0x5a4,

        /// <summary>
        /// Cannot process a message from a window that is not a multiple document interface (MDI) window.
        /// </summary>
        NON_MDICHILD_WINDOW = 0x5a5,

        /// <summary>
        /// Popup menu already active.
        /// </summary>
        POPUP_ALREADY_ACTIVE = 0x5a6,

        /// <summary>
        /// The window does not have scroll bars.
        /// </summary>
        NO_SCROLLBARS = 0x5a7,

        /// <summary>
        /// Scroll bar range cannot be greater than MAXLONG.
        /// </summary>
        INVALID_SCROLLBAR_RANGE = 0x5a8,

        /// <summary>
        /// Cannot show or remove the window in the way  specified .
        /// </summary>
        INVALID_SHOWWIN_COMMAND = 0x5a9,

        /// <summary>
        /// Insufficient system resources exist to complete the requested service.
        /// </summary>
        NO_SYSTEM_RESOURCES = 0x5aa,

        /// <summary>
        /// Insufficient system resources exist to complete the requested service.
        /// </summary>
        NONPAGED_SYSTEM_RESOURCES = 0x5ab,

        /// <summary>
        /// Insufficient system resources exist to complete the requested service.
        /// </summary>
        PAGED_SYSTEM_RESOURCES = 0x5ac,

        /// <summary>
        /// Insufficient quota to complete the requested service.
        /// </summary>
        WORKING_SET_QUOTA = 0x5ad,

        /// <summary>
        /// Insufficient quota to complete the requested service.
        /// </summary>
        PAGEFILE_QUOTA = 0x5ae,

        /// <summary>
        /// The paging file is too small for this operation to complete.
        /// </summary>
        COMMITMENT_LIMIT = 0x5af,

        /// <summary>
        /// A menu item was not found.
        /// </summary>
        MENU_ITEM_NOT_FOUND = 0x5b0,

        /// <summary>
        /// Invalid keyboard layout handle.
        /// </summary>
        INVALID_KEYBOARD_HANDLE = 0x5b1,

        /// <summary>
        /// Hook type not allowed.
        /// </summary>
        HOOK_TYPE_NOT_ALLOWED = 0x5b2,

        /// <summary>
        /// This operation requires an interactive window station.
        /// </summary>
        REQUIRES_INTERACTIVE_WINDOWSTATION = 0x5b3,

        /// <summary>
        /// This operation returned because the timeout period expired.
        /// </summary>
        TIMEOUT = 0x5b4,

        /// <summary>
        /// Invalid monitor handle.
        /// </summary>
        INVALID_MONITOR_HANDLE = 0x5b5,

        /// <summary>
        /// Incorrect size argument.
        /// </summary>
        INCORRECT_SIZE = 0x5b6,

        /// <summary>
        /// The symbolic link cannot be followed because its type is disabled.
        /// </summary>
        SYMLINK_CLASS_DISABLED = 0x5b7,

        /// <summary>
        /// This application does not support the current operation on symbolic links.
        /// </summary>
        SYMLINK_NOT_SUPPORTED = 0x5b8,

        /// <summary>
        /// Windows was unable to parse the requested XML data.
        /// </summary>
        XML_PARSE_ERROR = 0x5b9,

        /// <summary>
        /// An error was encountered while processing an XML digital signature.
        /// </summary>
        XMLDSIG_ERROR = 0x5ba,

        /// <summary>
        /// This application must be restarted.
        /// </summary>
        RESTART_APPLICATION = 0x5bb,

        /// <summary>
        /// The caller made the connection request in the wrong routing compartment.
        /// </summary>
        WRONG_COMPARTMENT = 0x5bc,

        /// <summary>
        /// There was an AuthIP failure when attempting to connect to the remote host.
        /// </summary>
        AUTHIP_FAILURE = 0x5bd,

        /// <summary>
        /// Insufficient NVRAM resources exist to complete the requested service. A reboot might be required.
        /// </summary>
        NO_NVRAM_RESOURCES = 0x5be,

        /// <summary>
        /// Unable to finish the requested operation because the specified process is not a GUI process.
        /// </summary>
        NOT_GUI_PROCESS = 0x5bf,

        /// <summary>
        /// The event log file is corrupted.
        /// </summary>
        EVENTLOG_FILE_CORRUPT = 0x5dc,

        /// <summary>
        /// No event log file could be opened, so the event logging service did not start.
        /// </summary>
        EVENTLOG_CANT_START = 0x5dd,

        /// <summary>
        /// The event log file is full.
        /// </summary>
        LOG_FILE_FULL = 0x5de,

        /// <summary>
        /// The event log file has changed between read operations.
        /// </summary>
        EVENTLOG_FILE_CHANGED = 0x5df,

        /// <summary>
        /// The specified task name is invalid.
        /// </summary>
        INVALID_TASK_NAME = 0x60e,

        /// <summary>
        /// The specified task index is invalid.
        /// </summary>
        INVALID_TASK_INDEX = 0x60f,

        /// <summary>
        /// The specified thread is already joining a task.
        /// </summary>
        THREAD_ALREADY_IN_TASK = 0x610,

        /// <summary>
        /// The specified thread is already joining a task.
        /// </summary>
        INSTALL_SERVICE_FAILURE = 0x641,

        /// <summary>
        /// User cancelled installation.
        /// </summary>
        INSTALL_USEREXIT = 0x642,

        /// <summary>
        /// Fatal error during installation.
        /// </summary>
        INSTALL_FAILURE = 0x643,

        /// <summary>
        /// Installation suspended, incomplete.
        /// </summary>
        INSTALL_SUSPEND = 0x644,

        /// <summary>
        /// This action is only valid for products that are currently installed.
        /// </summary>
        UNKNOWN_PRODUCT = 0x645,

        /// <summary>
        /// Feature ID not registered.
        /// </summary>
        UNKNOWN_FEATURE = 0x646,

        /// <summary>
        /// Component ID not registered.
        /// </summary>
        UNKNOWN_COMPONENT = 0x647,

        /// <summary>
        /// Unknown property.
        /// </summary>
        UNKNOWN_PROPERTY = 0x648,

        /// <summary>
        /// Handle is in an invalid state.
        /// </summary>
        INVALID_HANDLE_STATE = 0x649,

        /// <summary>
        /// The configuration data for this product is corrupt. Contact your support personnel.
        /// </summary>
        BAD_CONFIGURATION = 0x64a,

        /// <summary>
        /// Component qualifier not present.
        /// </summary>
        INDEX_ABSENT = 0x64b,

        /// <summary>
        /// Component qualifier not present.
        /// </summary>
        INSTALsource_ABSENT = 0x64c,

        /// <summary>
        /// Component qualifier not present.
        /// </summary>
        INSTALL_PACKAGE_VERSION = 0x64d,

        /// <summary>
        /// Product is uninstalled.
        /// </summary>
        PRODUCT_UNINSTALLED = 0x64e,

        /// <summary>
        /// SQL query syntax invalid or unsupported.
        /// </summary>
        BAD_QUERY_SYNTAX = 0x64f,

        /// <summary>
        /// Record field does not exist.
        /// </summary>
        INVALID_FIELD = 0x650,

        /// <summary>
        /// The device has been removed.
        /// </summary>
        DEVICE_REMOVED = 0x651,

        /// <summary>
        /// The device has been removed.
        /// </summary>
        INSTALaLREADY_RUNNING = 0x652,

        /// <summary>
        /// The device has been removed.
        /// </summary>
        INSTALL_PACKAGE_OPEN_FAILED = 0x653,

        /// <summary>
        /// The device has been removed.
        /// </summary>
        INSTALL_PACKAGE_INVALID = 0x654,

        /// <summary>
        /// The device has been removed.
        /// </summary>
        INSTALL_UI_FAILURE = 0x655,

        /// <summary>
        /// The device has been removed.
        /// </summary>
        INSTALL_LOG_FAILURE = 0x656,

        /// <summary>
        /// The language of this installation package is not supported by your system.
        /// </summary>
        INSTALL_LANGUAGE_UNSUPPORTED = 0x657,

        /// <summary>
        /// Error applying transforms. Verify that the specified transform paths are valid.
        /// </summary>
        INSTALL_TRANSFORM_FAILURE = 0x658,

        /// <summary>
        /// This installation is forbidden by system policy. Contact your system administrator.
        /// </summary>
        INSTALL_PACKAGE_REJECTED = 0x659,

        /// <summary>
        /// Function could not be executed.
        /// </summary>
        FUNCTION_NOT_CALLED = 0x65a,

        /// <summary>
        /// Function failed during execution.
        /// </summary>
        FUNCTION_FAILED = 0x65b,

        /// <summary>
        /// Invalid or unknown table  specified .
        /// </summary>
        INVALID_TABLE = 0x65c,

        /// <summary>
        /// Data supplied is of wrong type.
        /// </summary>
        DATATYPE_MISMATCH = 0x65d,

        /// <summary>
        /// Data of this type is not supported.
        /// </summary>
        UNSUPPORTED_TYPE = 0x65e,

        /// <summary>
        /// The Windows Installer service failed to start. Contact your support personnel.
        /// </summary>
        CREATE_FAILED = 0x65f,

        /// <summary>
        /// The Windows Installer service failed to start. Contact your support personnel.
        /// </summary>
        INSTALL_TEMP_UNWRITABLE = 0x660,

        /// <summary>
        /// This installation package is not supported by this processor type. Contact your product vendor.
        /// </summary>
        INSTALL_PLATFORM_UNSUPPORTED = 0x661,

        /// <summary>
        /// Component not used on this computer.
        /// </summary>
        INSTALnotUSED = 0x662,

        /// <summary>
        /// Component not used on this computer.
        /// </summary>
        PATCH_PACKAGE_OPEN_FAILED = 0x663,

        /// <summary>
        /// Component not used on this computer.
        /// </summary>
        PATCH_PACKAGE_INVALID = 0x664,

        /// <summary>
        /// Component not used on this computer.
        /// </summary>
        PATCH_PACKAGE_UNSUPPORTED = 0x665,

        /// <summary>
        /// Component not used on this computer.
        /// </summary>
        PRODUCT_VERSION = 0x666,

        /// <summary>
        /// Invalid command line argument. Consult the Windows Installer SDK for detailed command line help.
        /// </summary>
        INVALID_COMMAND_LINE = 0x667,

        /// <summary>
        /// Invalid command line argument. Consult the Windows Installer SDK for detailed command line help.
        /// </summary>
        INSTALL_REMOTE_DISALLOWED = 0x668,

        /// <summary>
        /// Invalid command line argument. Consult the Windows Installer SDK for detailed command line help.
        /// </summary>
        SUCCESS_REBOOT_INITIATED = 0x669,

        /// <summary>
        /// Invalid command line argument. Consult the Windows Installer SDK for detailed command line help.
        /// </summary>
        PATCH_TARGET_NOT_FOUND = 0x66a,

        /// <summary>
        /// The update package is not permitted by software restriction policy.
        /// </summary>
        PATCH_PACKAGE_REJECTED = 0x66b,

        /// <summary>
        /// One or more customizations are not permitted by software restriction policy.
        /// </summary>
        INSTALL_TRANSFORM_REJECTED = 0x66c,

        /// <summary>
        /// The Windows Installer does not permit installation from a Remote Desktop Connection.
        /// </summary>
        INSTALL_REMOTE_PROHIBITED = 0x66d,

        /// <summary>
        /// Uninstallation of the update package is not supported.
        /// </summary>
        PATCH_REMOVAL_UNSUPPORTED = 0x66e,

        /// <summary>
        /// The update is not applied to this product.
        /// </summary>
        UNKNOWN_PATCH = 0x66f,

        /// <summary>
        /// No valid sequence could be found for the set of updates.
        /// </summary>
        PATCH_NO_SEQUENCE = 0x670,

        /// <summary>
        /// Update removal was disallowed by policy.
        /// </summary>
        PATCH_REMOVAL_DISALLOWED = 0x671,

        /// <summary>
        /// The XML update data is invalid.
        /// </summary>
        INVALID_PATCH_XML = 0x672,

        /// <summary>
        /// The XML update data is invalid.
        /// </summary>
        PATCH_MANAGED_ADVERTISED_PRODUCT = 0x673,

        /// <summary>
        /// The XML update data is invalid.
        /// </summary>
        INSTALL_SERVICE_SAFEBOOT = 0x674,

        /// <summary>
        /// The XML update data is invalid.
        /// </summary>
        FAIL_FAST_EXCEPTION = 0x675,

        /// <summary>
        /// The string binding is invalid.
        /// </summary>
        RPC_S_INVALID_STRING_BINDING = 0x6a4,

        /// <summary>
        /// The binding handle is not the correct type.
        /// </summary>
        RPC_S_WRONG_KIND_OF_BINDING = 0x6a5,

        /// <summary>
        /// The binding handle is invalid.
        /// </summary>
        RPC_S_INVALID_BINDING = 0x6a6,

        /// <summary>
        /// The RPC protocol sequence is not supported.
        /// </summary>
        RPC_S_PROTSEQ_NOT_SUPPORTED = 0x6a7,

        /// <summary>
        /// The RPC protocol sequence is invalid.
        /// </summary>
        RPC_S_INVALID_RPC_PROTSEQ = 0x6a8,

        /// <summary>
        /// The string universal unique identifier (UUID) is invalid.
        /// </summary>
        RPC_S_INVALID_STRING_UUID = 0x6a9,

        /// <summary>
        /// The endpoint format is invalid.
        /// </summary>
        RPC_S_INVALID_ENDPOINT_FORMAT = 0x6aa,

        /// <summary>
        /// The network address is invalid.
        /// </summary>
        RPC_S_INVALID_NET_ADDR = 0x6ab,

        /// <summary>
        /// No endpoint was found.
        /// </summary>
        RPC_S_NO_ENDPOINT_FOUND = 0x6ac,

        /// <summary>
        /// The timeout value is invalid.
        /// </summary>
        RPC_S_INVALID_TIMEOUT = 0x6ad,

        /// <summary>
        /// The object universal unique identifier (UUID) was not found.
        /// </summary>
        RPC_S_OBJECT_NOT_FOUND = 0x6ae,

        /// <summary>
        /// The object universal unique identifier (UUID) has already been registered.
        /// </summary>
        RPC_S_ALREADY_REGISTERED = 0x6af,

        /// <summary>
        /// The type universal unique identifier (UUID) has already been registered.
        /// </summary>
        RPC_S_TYPE_ALREADY_REGISTERED = 0x6b0,

        /// <summary>
        /// The RPC server is already listening.
        /// </summary>
        RPC_S_ALREADY_LISTENING = 0x6b1,

        /// <summary>
        /// No protocol sequences have been registered.
        /// </summary>
        RPC_S_NO_PROTSEQS_REGISTERED = 0x6b2,

        /// <summary>
        /// The RPC server is not listening.
        /// </summary>
        RPC_S_NOT_LISTENING = 0x6b3,

        /// <summary>
        /// The manager type is unknown.
        /// </summary>
        RPC_S_UNKNOWN_MGR_TYPE = 0x6b4,

        /// <summary>
        /// The interface is unknown.
        /// </summary>
        RPC_S_UNKNOWN_IF = 0x6b5,

        /// <summary>
        /// There are no bindings.
        /// </summary>
        RPC_S_NO_BINDINGS = 0x6b6,

        /// <summary>
        /// There are no protocol sequences.
        /// </summary>
        RPC_S_NO_PROTSEQS = 0x6b7,

        /// <summary>
        /// The endpoint cannot be created.
        /// </summary>
        RPC_S_CANT_CREATE_ENDPOINT = 0x6b8,

        /// <summary>
        /// Not enough resources are available to complete this operation.
        /// </summary>
        RPC_S_OUT_OF_RESOURCES = 0x6b9,

        /// <summary>
        /// The RPC server is unavailable.
        /// </summary>
        RPC_S_SERVER_UNAVAILABLE = 0x6ba,

        /// <summary>
        /// The RPC server is too busy to complete this operation.
        /// </summary>
        RPC_S_SERVER_TOO_BUSY = 0x6bb,

        /// <summary>
        /// The network options are invalid.
        /// </summary>
        RPC_S_INVALID_NETWORK_OPTIONS = 0x6bc,

        /// <summary>
        /// There are no remote procedure calls active on this thread.
        /// </summary>
        RPC_S_NO_CALaCTIVE = 0x6bd,

        /// <summary>
        /// The remote procedure call failed.
        /// </summary>
        RPC_S_CALL_FAILED = 0x6be,

        /// <summary>
        /// The remote procedure call failed and did not execute.
        /// </summary>
        RPC_S_CALL_FAILED_DNE = 0x6bf,

        /// <summary>
        /// A remote procedure call (RPC) protocol error occurred.
        /// </summary>
        RPC_S_PROTOCOerror = 0x6c0,

        /// <summary>
        /// Access to the HTTP proxy is denied.
        /// </summary>
        RPC_S_PROXY_ACCESS_DENIED = 0x6c1,

        /// <summary>
        /// The transfer syntax is not supported by the RPC server.
        /// </summary>
        RPC_S_UNSUPPORTED_TRANS_SYN = 0x6c2,

        /// <summary>
        /// The universal unique identifier (UUID) type is not supported.
        /// </summary>
        RPC_S_UNSUPPORTED_TYPE = 0x6c4,

        /// <summary>
        /// The tag is invalid.
        /// </summary>
        RPC_S_INVALID_TAG = 0x6c5,

        /// <summary>
        /// The array bounds are invalid.
        /// </summary>
        RPC_S_INVALID_BOUND = 0x6c6,

        /// <summary>
        /// The binding does not contain an entry name.
        /// </summary>
        RPC_S_NO_ENTRY_NAME = 0x6c7,

        /// <summary>
        /// The name syntax is invalid.
        /// </summary>
        RPC_S_INVALID_NAME_SYNTAX = 0x6c8,

        /// <summary>
        /// The name syntax is not supported.
        /// </summary>
        RPC_S_UNSUPPORTED_NAME_SYNTAX = 0x6c9,

        /// <summary>
        /// No network address is available to use to construct a universal unique identifier (UUID).
        /// </summary>
        RPC_S_UUID_NO_ADDRESS = 0x6cb,

        /// <summary>
        /// The endpoint is a duplicate.
        /// </summary>
        RPC_S_DUPLICATE_ENDPOINT = 0x6cc,

        /// <summary>
        /// The authentication type is unknown.
        /// </summary>
        RPC_S_UNKNOWN_AUTHN_TYPE = 0x6cd,

        /// <summary>
        /// The maximum number of calls is too small.
        /// </summary>
        RPC_S_MAX_CALLS_TOO_SMALL = 0x6ce,

        /// <summary>
        /// The string is too long.
        /// </summary>
        RPC_S_STRING_TOO_LONG = 0x6cf,

        /// <summary>
        /// The RPC protocol sequence was not found.
        /// </summary>
        RPC_S_PROTSEQ_NOT_FOUND = 0x6d0,

        /// <summary>
        /// The procedure number is out of range.
        /// </summary>
        RPC_S_PROCNUM_OUT_OF_RANGE = 0x6d1,

        /// <summary>
        /// The binding does not contain any authentication information.
        /// </summary>
        RPC_S_BINDING_HAS_NO_AUTH = 0x6d2,

        /// <summary>
        /// The authentication service is unknown.
        /// </summary>
        RPC_S_UNKNOWN_AUTHN_SERVICE = 0x6d3,

        /// <summary>
        /// The authentication level is unknown.
        /// </summary>
        RPC_S_UNKNOWN_AUTHN_LEVEL = 0x6d4,

        /// <summary>
        /// The security context is invalid.
        /// </summary>
        RPC_S_INVALID_AUTH_IDENTITY = 0x6d5,

        /// <summary>
        /// The authorization service is unknown.
        /// </summary>
        RPC_S_UNKNOWN_AUTHZ_SERVICE = 0x6d6,

        /// <summary>
        /// The entry is invalid.
        /// </summary>
        EPT_S_INVALID_ENTRY = 0x6d7,

        /// <summary>
        /// The server endpoint cannot perform the operation.
        /// </summary>
        EPT_S_CANT_PERFORM_OP = 0x6d8,

        /// <summary>
        /// There are no more endpoints available from the endpoint mapper.
        /// </summary>
        EPT_S_NOT_REGISTERED = 0x6d9,

        /// <summary>
        /// No interfaces have been exported.
        /// </summary>
        RPC_S_NOTHING_TO_EXPORT = 0x6da,

        /// <summary>
        /// The entry name is incomplete.
        /// </summary>
        RPC_S_INCOMPLETE_NAME = 0x6db,

        /// <summary>
        /// The version option is invalid.
        /// </summary>
        RPC_S_INVALID_VERS_OPTION = 0x6dc,

        /// <summary>
        /// There are no more members.
        /// </summary>
        RPC_S_NO_MORE_MEMBERS = 0x6dd,

        /// <summary>
        /// There is nothing to unexport.
        /// </summary>
        RPC_S_NOT_ALL_OBJS_UNEXPORTED = 0x6de,

        /// <summary>
        /// The interface was not found.
        /// </summary>
        RPC_S_INTERFACE_NOT_FOUND = 0x6df,

        /// <summary>
        /// The entry already exists.
        /// </summary>
        RPC_S_ENTRY_ALREADY_EXISTS = 0x6e0,

        /// <summary>
        /// The entry is not found.
        /// </summary>
        RPC_S_ENTRY_NOT_FOUND = 0x6e1,

        /// <summary>
        /// The name service is unavailable.
        /// </summary>
        RPC_S_NAME_SERVICE_UNAVAILABLE = 0x6e2,

        /// <summary>
        /// The network address family is invalid.
        /// </summary>
        RPC_S_INVALID_NAF_ID = 0x6e3,

        /// <summary>
        /// The requested operation is not supported.
        /// </summary>
        RPC_S_CANNOT_SUPPORT = 0x6e4,

        /// <summary>
        /// No security context is available to allow impersonation.
        /// </summary>
        RPC_S_NO_CONTEXT_AVAILABLE = 0x6e5,

        /// <summary>
        /// An internal error occurred in a remote procedure call (RPC).
        /// </summary>
        RPC_S_INTERNAerror = 0x6e6,

        /// <summary>
        /// The RPC server attempted an integer division by zero.
        /// </summary>
        RPC_S_ZERO_DIVIDE = 0x6e7,

        /// <summary>
        /// An addressing error occurred in the RPC server.
        /// </summary>
        RPC_S_ADDRESS_ERROR = 0x6e8,

        /// <summary>
        /// A floating-point operation at the RPC server caused a division by zero.
        /// </summary>
        RPC_S_FP_DIV_ZERO = 0x6e9,

        /// <summary>
        /// A floating-point underflow occurred at the RPC server.
        /// </summary>
        RPC_S_FP_UNDERFLOW = 0x6ea,

        /// <summary>
        /// A floating-point overflow occurred at the RPC server.
        /// </summary>
        RPC_S_FP_OVERFLOW = 0x6eb,

        /// <summary>
        /// The list of RPC servers available for the binding of auto handles has been exhausted.
        /// </summary>
        RPC_X_NO_MORE_ENTRIES = 0x6ec,

        /// <summary>
        /// Unable to open the character translation table file.
        /// </summary>
        RPC_X_SS_CHAR_TRANS_OPEN_FAIL = 0x6ed,

        /// <summary>
        /// The file containing the character translation table has fewer than 512 bytes.
        /// </summary>
        RPC_X_SS_CHAR_TRANS_SHORT_FILE = 0x6ee,

        /// <summary>
        /// A null context handle was passed from the client to the host during a remote procedure call.
        /// </summary>
        RPC_X_SS_IN_NULcONTEXT = 0x6ef,

        /// <summary>
        /// The context handle changed during a remote procedure call.
        /// </summary>
        RPC_X_SS_CONTEXT_DAMAGED = 0x6f1,

        /// <summary>
        /// The binding handles passed to a remote procedure call do not match.
        /// </summary>
        RPC_X_SS_HANDLES_MISMATCH = 0x6f2,

        /// <summary>
        /// The stub is unable to get the remote procedure call handle.
        /// </summary>
        RPC_X_SS_CANNOT_GET_CALL_HANDLE = 0x6f3,

        /// <summary>
        /// A null reference pointer was passed to the stub.
        /// </summary>
        RPC_X_NULL_REF_POINTER = 0x6f4,

        /// <summary>
        /// The enumeration value is out of range.
        /// </summary>
        RPC_X_ENUM_VALUE_OUT_OF_RANGE = 0x6f5,

        /// <summary>
        /// The byte count is too small.
        /// </summary>
        RPC_X_BYTE_COUNT_TOO_SMALL = 0x6f6,

        /// <summary>
        /// The stub received bad data.
        /// </summary>
        RPC_X_BAD_STUB_DATA = 0x6f7,

        /// <summary>
        /// The supplied user buffer is not valid for the requested operation.
        /// </summary>
        INVALID_USER_BUFFER = 0x6f8,

        /// <summary>
        /// The disk media is not recognized. It may not be formatted.
        /// </summary>
        UNRECOGNIZED_MEDIA = 0x6f9,

        /// <summary>
        /// The workstation does not have a trust secret.
        /// </summary>
        NO_TRUST_LSA_SECRET = 0x6fa,

        /// <summary>
        /// The workstation does not have a trust secret.
        /// </summary>
        NO_TRUST_SAM_ACCOUNT = 0x6fb,

        /// <summary>
        /// The trust relationship between the primary domain and the trusted domain failed.
        /// </summary>
        TRUSTED_DOMAIN_FAILURE = 0x6fc,

        /// <summary>
        /// The trust relationship between this workstation and the primary domain failed.
        /// </summary>
        TRUSTED_RELATIONSHIP_FAILURE = 0x6fd,

        /// <summary>
        /// The network logon failed.
        /// </summary>
        TRUST_FAILURE = 0x6fe,

        /// <summary>
        /// A remote procedure call is already in progress for this thread.
        /// </summary>
        RPC_S_CALL_IN_PROGRESS = 0x6ff,

        /// <summary>
        /// An attempt was made to logon, but the network logon service was not started.
        /// </summary>
        NETLOGON_NOT_STARTED = 0x700,

        /// <summary>
        /// The user's account has expired.
        /// </summary>
        ACCOUNT_EXPIRED = 0x701,

        /// <summary>
        /// The redirector is in use and cannot be unloaded.
        /// </summary>
        REDIRECTOR_HAS_OPEN_HANDLES = 0x702,

        /// <summary>
        /// The specified printer driver is already installed.
        /// </summary>
        PRINTER_DRIVER_ALREADY_INSTALLED = 0x703,

        /// <summary>
        /// The specified port is unknown.
        /// </summary>
        UNKNOWN_PORT = 0x704,

        /// <summary>
        /// The printer driver is unknown.
        /// </summary>
        UNKNOWN_PRINTER_DRIVER = 0x705,

        /// <summary>
        /// The print processor is unknown.
        /// </summary>
        UNKNOWN_PRINTPROCESSOR = 0x706,

        /// <summary>
        /// The specified separator file is invalid.
        /// </summary>
        INVALID_SEPARATOR_FILE = 0x707,

        /// <summary>
        /// The specified priority is invalid.
        /// </summary>
        INVALID_PRIORITY = 0x708,

        /// <summary>
        /// The printer name is invalid.
        /// </summary>
        INVALID_PRINTER_NAME = 0x709,

        /// <summary>
        /// The printer already exists.
        /// </summary>
        PRINTER_ALREADY_EXISTS = 0x70a,

        /// <summary>
        /// The printer command is invalid.
        /// </summary>
        INVALID_PRINTER_COMMAND = 0x70b,

        /// <summary>
        /// The specified datatype is invalid.
        /// </summary>
        INVALID_DATATYPE = 0x70c,

        /// <summary>
        /// The environment specified is invalid.
        /// </summary>
        INVALID_ENVIRONMENT = 0x70d,

        /// <summary>
        /// There are no more bindings.
        /// </summary>
        RPC_S_NO_MORE_BINDINGS = 0x70e,

        /// <summary>
        /// There are no more bindings.
        /// </summary>
        NOLOGON_INTERDOMAIN_TRUST_ACCOUNT = 0x70f,

        /// <summary>
        /// There are no more bindings.
        /// </summary>
        NOLOGON_WORKSTATION_TRUST_ACCOUNT = 0x710,

        /// <summary>
        /// There are no more bindings.
        /// </summary>
        NOLOGON_SERVER_TRUST_ACCOUNT = 0x711,

        /// <summary>
        /// There are no more bindings.
        /// </summary>
        DOMAIN_TRUST_INCONSISTENT = 0x712,

        /// <summary>
        /// The server is in use and cannot be unloaded.
        /// </summary>
        SERVER_HAS_OPEN_HANDLES = 0x713,

        /// <summary>
        /// The specified image file did not contain a resource section.
        /// </summary>
        RESOURCE_DATA_NOT_FOUND = 0x714,

        /// <summary>
        /// The specified resource type cannot be found in the image file.
        /// </summary>
        RESOURCE_TYPE_NOT_FOUND = 0x715,

        /// <summary>
        /// The specified resource name cannot be found in the image file.
        /// </summary>
        RESOURCE_NAME_NOT_FOUND = 0x716,

        /// <summary>
        /// The specified resource language ID cannot be found in the image file.
        /// </summary>
        RESOURCE_LANG_NOT_FOUND = 0x717,

        /// <summary>
        /// Not enough quota is available to process this command.
        /// </summary>
        NOT_ENOUGH_QUOTA = 0x718,

        /// <summary>
        /// No interfaces have been registered.
        /// </summary>
        RPC_S_NO_INTERFACES = 0x719,

        /// <summary>
        /// The remote procedure call was cancelled.
        /// </summary>
        RPC_S_CALcANCELLED = 0x71a,

        /// <summary>
        /// The binding handle does not contain all required information.
        /// </summary>
        RPC_S_BINDING_INCOMPLETE = 0x71b,

        /// <summary>
        /// A communications failure occurred during a remote procedure call.
        /// </summary>
        RPC_S_COMM_FAILURE = 0x71c,

        /// <summary>
        /// The requested authentication level is not supported.
        /// </summary>
        RPC_S_UNSUPPORTED_AUTHN_LEVEL = 0x71d,

        /// <summary>
        /// No principal name registered.
        /// </summary>
        RPC_S_NO_PRINC_NAME = 0x71e,

        /// <summary>
        /// The error specified is not a valid Windows RPC error code.
        /// </summary>
        RPC_S_NOT_RPC_ERROR = 0x71f,

        /// <summary>
        /// A UUID that is valid only on this computer has been allocated.
        /// </summary>
        RPC_S_UUID_LOCAL_ONLY = 0x720,

        /// <summary>
        /// A security package specific error occurred.
        /// </summary>
        RPC_S_SEC_PKG_ERROR = 0x721,

        /// <summary>
        /// Thread is not canceled.
        /// </summary>
        RPC_S_NOT_CANCELLED = 0x722,

        /// <summary>
        /// Invalid operation on the encoding/decoding handle.
        /// </summary>
        RPC_X_INVALID_ES_ACTION = 0x723,

        /// <summary>
        /// Incompatible version of the serializing package.
        /// </summary>
        RPC_X_WRONG_ES_VERSION = 0x724,

        /// <summary>
        /// Incompatible version of the RPC stub.
        /// </summary>
        RPC_X_WRONG_STUB_VERSION = 0x725,

        /// <summary>
        /// The RPC pipe object is invalid or corrupted.
        /// </summary>
        RPC_X_INVALID_PIPE_OBJECT = 0x726,

        /// <summary>
        /// An invalid operation was attempted on an RPC pipe object.
        /// </summary>
        RPC_X_WRONG_PIPE_ORDER = 0x727,

        /// <summary>
        /// Unsupported RPC pipe version.
        /// </summary>
        RPC_X_WRONG_PIPE_VERSION = 0x728,

        /// <summary>
        /// HTTP proxy server rejected the connection because the cookie authentication failed.
        /// </summary>
        RPC_S_COOKIE_AUTH_FAILED = 0x729,

        /// <summary>
        /// The group member was not found.
        /// </summary>
        RPC_S_GROUP_MEMBER_NOT_FOUND = 0x76a,

        /// <summary>
        /// The endpoint mapper database entry could not be created.
        /// </summary>
        EPT_S_CANT_CREATE = 0x76b,

        /// <summary>
        /// The object universal unique identifier (UUID) is the nil UUID.
        /// </summary>
        RPC_S_INVALID_OBJECT = 0x76c,

        /// <summary>
        /// The specified time is invalid.
        /// </summary>
        INVALID_TIME = 0x76d,

        /// <summary>
        /// The specified form name is invalid.
        /// </summary>
        INVALID_FORM_NAME = 0x76e,

        /// <summary>
        /// The specified form size is invalid.
        /// </summary>
        INVALID_FORM_SIZE = 0x76f,

        /// <summary>
        /// The specified printer handle is already being waited on.
        /// </summary>
        ALREADY_WAITING = 0x770,

        /// <summary>
        /// The specified printer has been deleted.
        /// </summary>
        PRINTER_DELETED = 0x771,

        /// <summary>
        /// The state of the printer is invalid.
        /// </summary>
        INVALID_PRINTER_STATE = 0x772,

        /// <summary>
        /// The user's password must be changed before signing in.
        /// </summary>
        PASSWORD_MUST_CHANGE = 0x773,

        /// <summary>
        /// Could not find the domain controller for this domain.
        /// </summary>
        DOMAIN_CONTROLLER_NOT_FOUND = 0x774,

        /// <summary>
        /// The referenced account is currently locked out and may not be logged on to.
        /// </summary>
        ACCOUNT_LOCKED_OUT = 0x775,

        /// <summary>
        /// The object exporter specified was not found.
        /// </summary>
        OR_INVALID_OXID = 0x776,

        /// <summary>
        /// The object specified was not found.
        /// </summary>
        OR_INVALID_OID = 0x777,

        /// <summary>
        /// The object resolver set specified was not found.
        /// </summary>
        OR_INVALID_SET = 0x778,

        /// <summary>
        /// Some data remains to be sent in the request buffer.
        /// </summary>
        RPC_S_SEND_INCOMPLETE = 0x779,

        /// <summary>
        /// Invalid asynchronous remote procedure call handle.
        /// </summary>
        RPC_S_INVALID_ASYNC_HANDLE = 0x77a,

        /// <summary>
        /// Invalid asynchronous RPC call handle for this operation.
        /// </summary>
        RPC_S_INVALID_ASYNC_CALL = 0x77b,

        /// <summary>
        /// The RPC pipe object has already been closed.
        /// </summary>
        RPC_X_PIPE_CLOSED = 0x77c,

        /// <summary>
        /// The RPC call completed before all pipes were processed.
        /// </summary>
        RPC_X_PIPE_DISCIPLINE_ERROR = 0x77d,

        /// <summary>
        /// No more data is available from the RPC pipe.
        /// </summary>
        RPC_X_PIPE_EMPTY = 0x77e,

        /// <summary>
        /// No site name is available for this machine.
        /// </summary>
        NO_SITENAME = 0x77f,

        /// <summary>
        /// The file cannot be accessed by the system.
        /// </summary>
        CANT_ACCESS_FILE = 0x780,

        /// <summary>
        /// The name of the file cannot be resolved by the system.
        /// </summary>
        CANT_RESOLVE_FILENAME = 0x781,

        /// <summary>
        /// The entry is not of the expected type.
        /// </summary>
        RPC_S_ENTRY_TYPE_MISMATCH = 0x782,

        /// <summary>
        /// Not all object UUIDs could be exported to the specified entry.
        /// </summary>
        RPC_S_NOT_ALL_OBJS_EXPORTED = 0x783,

        /// <summary>
        /// Interface could not be exported to the specified entry.
        /// </summary>
        RPC_S_INTERFACE_NOT_EXPORTED = 0x784,

        /// <summary>
        /// The specified profile entry could not be added.
        /// </summary>
        RPC_S_PROFILE_NOT_ADDED = 0x785,

        /// <summary>
        /// The specified profile element could not be added.
        /// </summary>
        RPC_S_PRF_ELT_NOT_ADDED = 0x786,

        /// <summary>
        /// The specified profile element could not be removed.
        /// </summary>
        RPC_S_PRF_ELT_NOT_REMOVED = 0x787,

        /// <summary>
        /// The group element could not be added.
        /// </summary>
        RPC_S_GRP_ELT_NOT_ADDED = 0x788,

        /// <summary>
        /// The group element could not be removed.
        /// </summary>
        RPC_S_GRP_ELT_NOT_REMOVED = 0x789,

        /// <summary>
        /// The group element could not be removed.
        /// </summary>
        KM_DRIVER_BLOCKED = 0x78a,

        /// <summary>
        /// The context has expired and can no longer be used.
        /// </summary>
        CONTEXT_EXPIRED = 0x78b,

        /// <summary>
        /// The current user's delegated trust creation quota has been exceeded.
        /// </summary>
        PER_USER_TRUST_QUOTA_EXCEEDED = 0x78c,

        /// <summary>
        /// The total delegated trust creation quota has been exceeded.
        /// </summary>
        ALL_USER_TRUST_QUOTA_EXCEEDED = 0x78d,

        /// <summary>
        /// The current user's delegated trust deletion quota has been exceeded.
        /// </summary>
        USER_DELETE_TRUST_QUOTA_EXCEEDED = 0x78e,

        /// <summary>
        /// The current user's delegated trust deletion quota has been exceeded.
        /// </summary>
        AUTHENTICATION_FIREWALL_FAILED = 0x78f,

        /// <summary>
        /// Remote connections to the Print Spooler are blocked by a policy set on your machine.
        /// </summary>
        REMOTE_PRINT_CONNECTIONS_BLOCKED = 0x790,

        /// <summary>
        /// Authentication failed because NTLM authentication has been disabled.
        /// </summary>
        NTLM_BLOCKED = 0x791,

        /// <summary>
        /// Authentication failed because NTLM authentication has been disabled.
        /// </summary>
        PASSWORD_CHANGE_REQUIRED = 0x792,

        /// <summary>
        /// The pixel format is invalid.
        /// </summary>
        INVALID_PIXEL_FORMAT = 0x7d0,

        /// <summary>
        /// The specified driver is invalid.
        /// </summary>
        BAD_DRIVER = 0x7d1,

        /// <summary>
        /// The window style or class attribute is invalid for this operation.
        /// </summary>
        INVALID_WINDOW_STYLE = 0x7d2,

        /// <summary>
        /// The requested metafile operation is not supported.
        /// </summary>
        METAFILE_NOT_SUPPORTED = 0x7d3,

        /// <summary>
        /// The requested transformation operation is not supported.
        /// </summary>
        TRANSFORM_NOT_SUPPORTED = 0x7d4,

        /// <summary>
        /// The requested clipping operation is not supported.
        /// </summary>
        CLIPPING_NOT_SUPPORTED = 0x7d5,

        /// <summary>
        /// The specified color management module is invalid.
        /// </summary>
        INVALID_CMM = 0x7da,

        /// <summary>
        /// The specified color profile is invalid.
        /// </summary>
        INVALID_PROFILE = 0x7db,

        /// <summary>
        /// The specified tag was not found.
        /// </summary>
        TAG_NOT_FOUND = 0x7dc,

        /// <summary>
        /// A required tag is not present.
        /// </summary>
        TAG_NOT_PRESENT = 0x7dd,

        /// <summary>
        /// The specified tag is already present.
        /// </summary>
        DUPLICATE_TAG = 0x7de,

        /// <summary>
        /// The specified color profile is not associated with the specified device.
        /// </summary>
        PROFILE_NOT_ASSOCIATED_WITH_DEVICE = 0x7df,

        /// <summary>
        /// The specified color profile was not found.
        /// </summary>
        PROFILE_NOT_FOUND = 0x7e0,

        /// <summary>
        /// The specified color space is invalid.
        /// </summary>
        INVALID_COLORSPACE = 0x7e1,

        /// <summary>
        /// Image Color Management is not enabled.
        /// </summary>
        ICM_NOT_ENABLED = 0x7e2,

        /// <summary>
        /// There was an error while deleting the color transform.
        /// </summary>
        DELETING_ICM_XFORM = 0x7e3,

        /// <summary>
        /// The specified color transform is invalid.
        /// </summary>
        INVALID_TRANSFORM = 0x7e4,

        /// <summary>
        /// The specified transform does not match the bitmap's color space.
        /// </summary>
        COLORSPACE_MISMATCH = 0x7e5,

        /// <summary>
        /// The specified named color index is not present in the profile.
        /// </summary>
        INVALID_COLORINDEX = 0x7e6,

        /// <summary>
        /// The specified profile is intended for a device of a different type than the specified device.
        /// </summary>
        PROFILE_DOES_NOT_MATCH_DEVICE = 0x7e7,

        /// <summary>
        /// The specified profile is intended for a device of a different type than the specified device.
        /// </summary>
        CONNECTED_OTHER_PASSWORD = 0x83c,

        /// <summary>
        /// The network connection was made successfully using default credentials.
        /// </summary>
        CONNECTED_OTHER_PASSWORD_DEFAULT = 0x83d,

        /// <summary>
        /// The specified username is invalid.
        /// </summary>
        BAD_USERNAME = 0x89a,

        /// <summary>
        /// This network connection does not exist.
        /// </summary>
        NOT_CONNECTED = 0x8ca,

        /// <summary>
        /// This network connection has files open or requests pending.
        /// </summary>
        OPEN_FILES = 0x961,

        /// <summary>
        /// Active connections still exist.
        /// </summary>
        ACTIVE_CONNECTIONS = 0x962,

        /// <summary>
        /// The device is in use by an active process and cannot be disconnected.
        /// </summary>
        DEVICE_IN_USE = 0x964,

        /// <summary>
        /// The specified print monitor is unknown.
        /// </summary>
        UNKNOWN_PRINT_MONITOR = 0xbb8,

        /// <summary>
        /// The specified printer driver is currently in use.
        /// </summary>
        PRINTER_DRIVER_IN_USE = 0xbb9,

        /// <summary>
        /// The spool file was not found.
        /// </summary>
        SPOOfile_NOT_FOUND = 0xbba,

        /// <summary>
        /// A StartDocPrinter call was not issued.
        /// </summary>
        SPL_NO_STARTDOC = 0xbbb,

        /// <summary>
        /// An AddJob call was not issued.
        /// </summary>
        SPL_NO_ADDJOB = 0xbbc,

        /// <summary>
        /// The specified print processor has already been installed.
        /// </summary>
        PRINT_PROCESSOR_ALREADY_INSTALLED = 0xbbd,

        /// <summary>
        /// The specified print monitor has already been installed.
        /// </summary>
        PRINT_MONITOR_ALREADY_INSTALLED = 0xbbe,

        /// <summary>
        /// The specified print monitor does not have the required functions.
        /// </summary>
        INVALID_PRINT_MONITOR = 0xbbf,

        /// <summary>
        /// The specified print monitor is currently in use.
        /// </summary>
        PRINT_MONITOR_IN_USE = 0xbc0,

        /// <summary>
        /// The requested operation is not allowed when there are jobs queued to the printer.
        /// </summary>
        PRINTER_HAS_JOBS_QUEUED = 0xbc1,

        /// <summary>
        /// The requested operation is successful. Changes will not be effective until the system is rebooted.
        /// </summary>
        SUCCESS_REBOOT_REQUIRED = 0xbc2,

        /// <summary>
        /// The requested operation is successful. Changes will not be effective until the service is restarted.
        /// </summary>
        SUCCESS_RESTART_REQUIRED = 0xbc3,

        /// <summary>
        /// No printers were found.
        /// </summary>
        PRINTER_NOT_FOUND = 0xbc4,

        /// <summary>
        /// The printer driver is known to be unreliable.
        /// </summary>
        PRINTER_DRIVER_WARNED = 0xbc5,

        /// <summary>
        /// The printer driver is known to harm the system.
        /// </summary>
        PRINTER_DRIVER_BLOCKED = 0xbc6,

        /// <summary>
        /// The specified printer driver package is currently in use.
        /// </summary>
        PRINTER_DRIVER_PACKAGE_IN_USE = 0xbc7,

        /// <summary>
        /// Unable to find a core driver package that is required by the printer driver package.
        /// </summary>
        CORE_DRIVER_PACKAGE_NOT_FOUND = 0xbc8,

        /// <summary>
        /// The requested operation failed. A system reboot is required to roll back changes made.
        /// </summary>
        FAIL_REBOOT_REQUIRED = 0xbc9,

        /// <summary>
        /// The requested operation failed. A system reboot has been initiated to roll back changes made.
        /// </summary>
        FAIL_REBOOT_INITIATED = 0xbca,

        /// <summary>
        /// The specified printer driver was not found on the system and needs to be downloaded.
        /// </summary>
        PRINTER_DRIVER_DOWNLOAD_NEEDED = 0xbcb,

        /// <summary>
        /// The requested print job has failed to print. A print system update requires the job to be resubmitted.
        /// </summary>
        PRINT_JOB_RESTART_REQUIRED = 0xbcc,

        /// <summary>
        /// The printer driver does not contain a valid manifest, or contains too many manifests.
        /// </summary>
        INVALID_PRINTER_DRIVER_MANIFEST = 0xbcd,

        /// <summary>
        /// The specified printer cannot be shared.
        /// </summary>
        PRINTER_NOT_SHAREABLE = 0xbce,

        /// <summary>
        /// The operation was paused.
        /// </summary>
        REQUEST_PAUSED = 0xbea,

        /// <summary>
        /// WINS encountered an error while processing the command.
        /// </summary>
        WINS_INTERNAL = 0xfa0,

        /// <summary>
        /// The local WINS cannot be deleted.
        /// </summary>
        CAN_NOT_DEL_LOCAL_WINS = 0xfa1,

        /// <summary>
        /// The importation from the file failed.
        /// </summary>
        STATIC_INIT = 0xfa2,

        /// <summary>
        /// The backup failed. Was a full backup done before?
        /// </summary>
        INC_BACKUP = 0xfa3,

        /// <summary>
        /// The backup failed. Check the directory to which you are backing the database.
        /// </summary>
        FULbACKUP = 0xfa4,

        /// <summary>
        /// The name does not exist in the WINS database.
        /// </summary>
        REC_NON_EXISTENT = 0xfa5,

        /// <summary>
        /// Replication with a nonconfigured partner is not allowed.
        /// </summary>
        RPnot_ALLOWED = 0xfa6,

        /// <summary>
        /// The version of the supplied content information is not supported.
        /// </summary>
        PEERDIST_CONTENTINFO_VERSION_UNSUPPORTED = 0xfd2,

        /// <summary>
        /// The supplied content information is malformed.
        /// </summary>
        PEERDIST_CANNOT_PARSE_CONTENTINFO = 0xfd3,

        /// <summary>
        /// The requested data cannot be found in local or peer caches.
        /// </summary>
        PEERDIST_MISSING_DATA = 0xfd4,

        /// <summary>
        /// No more data is available or required.
        /// </summary>
        PEERDIST_NO_MORE = 0xfd5,

        /// <summary>
        /// The supplied object has not been initialized.
        /// </summary>
        PEERDIST_NOT_INITIALIZED = 0xfd6,

        /// <summary>
        /// The supplied object has already been initialized.
        /// </summary>
        PEERDIST_ALREADY_INITIALIZED = 0xfd7,

        /// <summary>
        /// A shutdown operation is already in progress.
        /// </summary>
        PEERDIST_SHUTDOWN_IN_PROGRESS = 0xfd8,

        /// <summary>
        /// The supplied object has already been invalidated.
        /// </summary>
        PEERDIST_INVALIDATED = 0xfd9,

        /// <summary>
        /// An element already exists and was not replaced.
        /// </summary>
        PEERDIST_ALREADY_EXISTS = 0xfda,

        /// <summary>
        /// Can not cancel the requested operation as it has already been completed.
        /// </summary>
        PEERDIST_OPERATION_NOTFOUND = 0xfdb,

        /// <summary>
        /// Can not perform the reqested operation because it has already been carried out.
        /// </summary>
        PEERDIST_ALREADY_COMPLETED = 0xfdc,

        /// <summary>
        /// An operation accessed data beyond the bounds of valid data.
        /// </summary>
        PEERDIST_OUT_OF_BOUNDS = 0xfdd,

        /// <summary>
        /// The requested version is not supported.
        /// </summary>
        PEERDIST_VERSION_UNSUPPORTED = 0xfde,

        /// <summary>
        /// A configuration value is invalid.
        /// </summary>
        PEERDIST_INVALID_CONFIGURATION = 0xfdf,

        /// <summary>
        /// The SKU is not licensed.
        /// </summary>
        PEERDIST_NOT_LICENSED = 0xfe0,

        /// <summary>
        /// PeerDist Service is still initializing and will be available shortly.
        /// </summary>
        PEERDIST_SERVICE_UNAVAILABLE = 0xfe1,

        /// <summary>
        /// Communication with one or more computers will be temporarily blocked due to recent errors.
        /// </summary>
        PEERDIST_TRUST_FAILURE = 0xfe2,

        /// <summary>
        /// Communication with one or more computers will be temporarily blocked due to recent errors.
        /// </summary>
        DHCaddress_CONFLICT = 0x1004,

        /// <summary>
        /// The GUID passed was not recognized as valid by a WMI data provider.
        /// </summary>
        WMI_GUID_NOT_FOUND = 0x1068,

        /// <summary>
        /// The instance name passed was not recognized as valid by a WMI data provider.
        /// </summary>
        WMI_INSTANCE_NOT_FOUND = 0x1069,

        /// <summary>
        /// The data item ID passed was not recognized as valid by a WMI data provider.
        /// </summary>
        WMI_ITEMID_NOT_FOUND = 0x106a,

        /// <summary>
        /// The WMI request could not be completed and should be retried.
        /// </summary>
        WMI_TRY_AGAIN = 0x106b,

        /// <summary>
        /// The WMI data provider could not be located.
        /// </summary>
        WMI_DP_NOT_FOUND = 0x106c,

        /// <summary>
        /// The WMI data provider references an instance set that has not been registered.
        /// </summary>
        WMI_UNRESOLVED_INSTANCE_REF = 0x106d,

        /// <summary>
        /// The WMI data block or event notification has already been enabled.
        /// </summary>
        WMI_ALREADY_ENABLED = 0x106e,

        /// <summary>
        /// The WMI data block is no longer available.
        /// </summary>
        WMI_GUID_DISCONNECTED = 0x106f,

        /// <summary>
        /// The WMI data service is not available.
        /// </summary>
        WMI_SERVER_UNAVAILABLE = 0x1070,

        /// <summary>
        /// The WMI data provider failed to carry out the request.
        /// </summary>
        WMI_DP_FAILED = 0x1071,

        /// <summary>
        /// The WMI MOF information is not valid.
        /// </summary>
        WMI_INVALID_MOF = 0x1072,

        /// <summary>
        /// The WMI registration information is not valid.
        /// </summary>
        WMI_INVALID_REGINFO = 0x1073,

        /// <summary>
        /// The WMI data block or event notification has already been disabled.
        /// </summary>
        WMI_ALREADY_DISABLED = 0x1074,

        /// <summary>
        /// The WMI data item or data block is read only.
        /// </summary>
        WMI_READ_ONLY = 0x1075,

        /// <summary>
        /// The WMI data item or data block could not be changed.
        /// </summary>
        WMI_SET_FAILURE = 0x1076,

        /// <summary>
        /// This operation is only valid in the context of an app container.
        /// </summary>
        NOT_APPCONTAINER = 0x109a,

        /// <summary>
        /// This application can only run in the context of an app container.
        /// </summary>
        APPCONTAINER_REQUIRED = 0x109b,

        /// <summary>
        /// This functionality is not supported in the context of an app container.
        /// </summary>
        NOT_SUPPORTED_IN_APPCONTAINER = 0x109c,

        /// <summary>
        /// The length of the SID supplied is not a valid length for app container SIDs.
        /// </summary>
        INVALID_PACKAGE_SID_LENGTH = 0x109d,

        /// <summary>
        /// The media identifier does not represent a valid medium.
        /// </summary>
        INVALID_MEDIA = 0x10cc,

        /// <summary>
        /// The library identifier does not represent a valid library.
        /// </summary>
        INVALID_LIBRARY = 0x10cd,

        /// <summary>
        /// The media pool identifier does not represent a valid media pool.
        /// </summary>
        INVALID_MEDIA_POOL = 0x10ce,

        /// <summary>
        /// The drive and medium are not compatible or exist in different libraries.
        /// </summary>
        DRIVE_MEDIA_MISMATCH = 0x10cf,

        /// <summary>
        /// The medium currently exists in an offline library and must be online to perform this operation.
        /// </summary>
        MEDIA_OFFLINE = 0x10d0,

        /// <summary>
        /// The operation cannot be performed on an offline library.
        /// </summary>
        LIBRARY_OFFLINE = 0x10d1,

        /// <summary>
        /// The library, drive, or media pool is empty.
        /// </summary>
        EMPTY = 0x10d2,

        /// <summary>
        /// The library, drive, or media pool must be empty to perform this operation.
        /// </summary>
        NOT_EMPTY = 0x10d3,

        /// <summary>
        /// No media is currently available in this media pool or library.
        /// </summary>
        MEDIA_UNAVAILABLE = 0x10d4,

        /// <summary>
        /// A resource required for this operation is disabled.
        /// </summary>
        RESOURCE_DISABLED = 0x10d5,

        /// <summary>
        /// The media identifier does not represent a valid cleaner.
        /// </summary>
        INVALID_CLEANER = 0x10d6,

        /// <summary>
        /// The drive cannot be cleaned or does not support cleaning.
        /// </summary>
        UNABLE_TO_CLEAN = 0x10d7,

        /// <summary>
        /// The object identifier does not represent a valid object.
        /// </summary>
        OBJECT_NOT_FOUND = 0x10d8,

        /// <summary>
        /// Unable to read from or write to the database.
        /// </summary>
        DATABASE_FAILURE = 0x10d9,

        /// <summary>
        /// The database is full.
        /// </summary>
        DATABASE_FULL = 0x10da,

        /// <summary>
        /// The medium is not compatible with the device or media pool.
        /// </summary>
        MEDIA_INCOMPATIBLE = 0x10db,

        /// <summary>
        /// The resource required for this operation does not exist.
        /// </summary>
        RESOURCE_NOT_PRESENT = 0x10dc,

        /// <summary>
        /// The operation identifier is not valid.
        /// </summary>
        INVALID_OPERATION = 0x10dd,

        /// <summary>
        /// The media is not mounted or ready for use.
        /// </summary>
        MEDIA_NOT_AVAILABLE = 0x10de,

        /// <summary>
        /// The device is not ready for use.
        /// </summary>
        DEVICE_NOT_AVAILABLE = 0x10df,

        /// <summary>
        /// The operator or administrator has refused the request.
        /// </summary>
        REQUEST_REFUSED = 0x10e0,

        /// <summary>
        /// The drive identifier does not represent a valid drive.
        /// </summary>
        INVALID_DRIVE_OBJECT = 0x10e1,

        /// <summary>
        /// Library is full. No slot is available for use.
        /// </summary>
        LIBRARY_FULL = 0x10e2,

        /// <summary>
        /// The transport cannot access the medium.
        /// </summary>
        MEDIUM_NOT_ACCESSIBLE = 0x10e3,

        /// <summary>
        /// Unable to load the medium into the drive.
        /// </summary>
        UNABLE_TO_LOAD_MEDIUM = 0x10e4,

        /// <summary>
        /// Unable to retrieve the drive status.
        /// </summary>
        UNABLE_TO_INVENTORY_DRIVE = 0x10e5,

        /// <summary>
        /// Unable to retrieve the slot status.
        /// </summary>
        UNABLE_TO_INVENTORY_SLOT = 0x10e6,

        /// <summary>
        /// Unable to retrieve status about the transport.
        /// </summary>
        UNABLE_TO_INVENTORY_TRANSPORT = 0x10e7,

        /// <summary>
        /// Cannot use the transport because it is already in use.
        /// </summary>
        TRANSPORT_FULL = 0x10e8,

        /// <summary>
        /// Unable to open or close the inject/eject port.
        /// </summary>
        CONTROLLING_IEPORT = 0x10e9,

        /// <summary>
        /// Unable to eject the medium because it is in a drive.
        /// </summary>
        UNABLE_TO_EJECT_MOUNTED_MEDIA = 0x10ea,

        /// <summary>
        /// A cleaner slot is already reserved.
        /// </summary>
        CLEANER_SLOT_SET = 0x10eb,

        /// <summary>
        /// A cleaner slot is not reserved.
        /// </summary>
        CLEANER_SLOT_NOT_SET = 0x10ec,

        /// <summary>
        /// The cleaner cartridge has performed the maximum number of drive cleanings.
        /// </summary>
        CLEANER_CARTRIDGE_SPENT = 0x10ed,

        /// <summary>
        /// Unexpected on-medium identifier.
        /// </summary>
        UNEXPECTED_OMID = 0x10ee,

        /// <summary>
        /// The last remaining item in this group or resource cannot be deleted.
        /// </summary>
        CANT_DELETE_LAST_ITEM = 0x10ef,

        /// <summary>
        /// The message provided exceeds the maximum size allowed for this parameter.
        /// </summary>
        MESSAGE_EXCEEDS_MAX_SIZE = 0x10f0,

        /// <summary>
        /// The volume contains system or paging files.
        /// </summary>
        VOLUME_CONTAINS_SYS_FILES = 0x10f1,

        /// <summary>
        /// The volume contains system or paging files.
        /// </summary>
        INDIGENOUS_TYPE = 0x10f2,

        /// <summary>
        /// The volume contains system or paging files.
        /// </summary>
        NO_SUPPORTING_DRIVES = 0x10f3,

        /// <summary>
        /// A cleaner cartridge is present in the tape library.
        /// </summary>
        CLEANER_CARTRIDGE_INSTALLED = 0x10f4,

        /// <summary>
        /// Cannot use the inject/eject port because it is not empty.
        /// </summary>
        IEPORT_FULL = 0x10f5,

        /// <summary>
        /// This file is currently not available for use on this computer.
        /// </summary>
        FILE_OFFLINE = 0x10fe,

        /// <summary>
        /// The remote storage service is not operational at this time.
        /// </summary>
        REMOTE_STORAGE_NOT_ACTIVE = 0x10ff,

        /// <summary>
        /// The remote storage service encountered a media error.
        /// </summary>
        REMOTE_STORAGE_MEDIA_ERROR = 0x1100,

        /// <summary>
        /// The file or directory is not a reparse point.
        /// </summary>
        NOT_A_REPARSE_POINT = 0x1126,

        /// <summary>
        /// The reparse point attribute cannot be set because it conflicts with an existing attribute.
        /// </summary>
        REPARSE_ATTRIBUTE_CONFLICT = 0x1127,

        /// <summary>
        /// The data present in the reparse point buffer is invalid.
        /// </summary>
        INVALID_REPARSE_DATA = 0x1128,

        /// <summary>
        /// The tag present in the reparse point buffer is invalid.
        /// </summary>
        REPARSE_TAG_INVALID = 0x1129,

        /// <summary>
        /// There is a mismatch between the tag specified in the request and the tag present in the reparse point.
        /// </summary>
        REPARSE_TAG_MISMATCH = 0x112a,

        /// <summary>
        /// Fast Cache data not found.
        /// </summary>
        APdata_NOT_FOUND = 0x1130,

        /// <summary>
        /// Fast Cache data expired.
        /// </summary>
        APdata_EXPIRED = 0x1131,

        /// <summary>
        /// Fast Cache data corrupt.
        /// </summary>
        APdata_CORRUPT = 0x1132,

        /// <summary>
        /// Fast Cache data has exceeded its max size and cannot be updated.
        /// </summary>
        APdata_LIMIT_EXCEEDED = 0x1133,

        /// <summary>
        /// Fast Cache has been ReArmed and requires a reboot until it can be updated.
        /// </summary>
        APdata_REBOOT_REQUIRED = 0x1134,

        /// <summary>
        /// Secure Boot detected that rollback of protected data has been attempted.
        /// </summary>
        SECUREBOOT_ROLLBACK_DETECTED = 0x1144,

        /// <summary>
        /// The value is protected by Secure Boot policy and cannot be modified or deleted.
        /// </summary>
        SECUREBOOT_POLICY_VIOLATION = 0x1145,

        /// <summary>
        /// The Secure Boot policy is invalid.
        /// </summary>
        SECUREBOOT_INVALID_POLICY = 0x1146,

        /// <summary>
        /// A new Secure Boot policy did not contain the current publisher on its update list.
        /// </summary>
        SECUREBOOT_POLICY_PUBLISHER_NOT_FOUND = 0x1147,

        /// <summary>
        /// The Secure Boot policy is either not signed or is signed by a non-trusted signer.
        /// </summary>
        SECUREBOOT_POLICY_NOT_SIGNED = 0x1148,

        /// <summary>
        /// Secure Boot is not enabled on this machine.
        /// </summary>
        SECUREBOOT_NOT_ENABLED = 0x1149,

        /// <summary>
        /// Secure Boot requires that certain files and drivers are not replaced by other files or drivers.
        /// </summary>
        SECUREBOOT_FILE_REPLACED = 0x114a,

        /// <summary>
        /// The copy offload read operation is not supported by a filter.
        /// </summary>
        OFFLOAD_READ_FLT_NOT_SUPPORTED = 0x1158,

        /// <summary>
        /// The copy offload write operation is not supported by a filter.
        /// </summary>
        OFFLOAD_WRITE_FLT_NOT_SUPPORTED = 0x1159,

        /// <summary>
        /// The copy offload read operation is not supported for the file.
        /// </summary>
        OFFLOAD_READ_FILE_NOT_SUPPORTED = 0x115a,

        /// <summary>
        /// The copy offload write operation is not supported for the file.
        /// </summary>
        OFFLOAD_WRITE_FILE_NOT_SUPPORTED = 0x115b,

        /// <summary>
        /// Single Instance Storage is not available on this volume.
        /// </summary>
        VOLUME_NOT_SIS_ENABLED = 0x1194,

        /// <summary>
        /// The operation cannot be completed because other resources are dependent on this resource.
        /// </summary>
        DEPENDENT_RESOURCE_EXISTS = 0x1389,

        /// <summary>
        /// The cluster resource dependency cannot be found.
        /// </summary>
        DEPENDENCY_NOT_FOUND = 0x138a,

        /// <summary>
        /// The cluster resource dependency cannot be found.
        /// </summary>
        DEPENDENCY_ALREADY_EXISTS = 0x138b,

        /// <summary>
        /// The cluster resource is not online.
        /// </summary>
        RESOURCE_NOT_ONLINE = 0x138c,

        /// <summary>
        /// A cluster node is not available for this operation.
        /// </summary>
        HOST_NODE_NOT_AVAILABLE = 0x138d,

        /// <summary>
        /// The cluster resource is not available.
        /// </summary>
        RESOURCE_NOT_AVAILABLE = 0x138e,

        /// <summary>
        /// The cluster resource could not be found.
        /// </summary>
        RESOURCE_NOT_FOUND = 0x138f,

        /// <summary>
        /// The cluster is being shut down.
        /// </summary>
        SHUTDOWN_CLUSTER = 0x1390,

        /// <summary>
        /// A cluster node cannot be evicted from the cluster unless the node is down or it is the last node.
        /// </summary>
        CANT_EVICT_ACTIVE_NODE = 0x1391,

        /// <summary>
        /// The object already exists.
        /// </summary>
        OBJECT_ALREADY_EXISTS = 0x1392,

        /// <summary>
        /// The object is already in the list.
        /// </summary>
        OBJECT_IN_LIST = 0x1393,

        /// <summary>
        /// The cluster group is not available for any new requests.
        /// </summary>
        GROUP_NOT_AVAILABLE = 0x1394,

        /// <summary>
        /// The cluster group could not be found.
        /// </summary>
        GROUP_NOT_FOUND = 0x1395,

        /// <summary>
        /// The operation could not be completed because the cluster group is not online.
        /// </summary>
        GROUP_NOT_ONLINE = 0x1396,

        /// <summary>
        /// The operation could not be completed because the cluster group is not online.
        /// </summary>
        HOST_NODE_NOT_RESOURCE_OWNER = 0x1397,

        /// <summary>
        /// The operation could not be completed because the cluster group is not online.
        /// </summary>
        HOST_NODE_NOT_GROUP_OWNER = 0x1398,

        /// <summary>
        /// The cluster resource could not be created in the specified resource monitor.
        /// </summary>
        RESMON_CREATE_FAILED = 0x1399,

        /// <summary>
        /// The cluster resource could not be brought online by the resource monitor.
        /// </summary>
        RESMON_ONLINE_FAILED = 0x139a,

        /// <summary>
        /// The operation could not be completed because the cluster resource is online.
        /// </summary>
        RESOURCE_ONLINE = 0x139b,

        /// <summary>
        /// The cluster resource could not be deleted or brought offline because it is the quorum resource.
        /// </summary>
        QUORUM_RESOURCE = 0x139c,

        /// <summary>
        /// The cluster resource could not be deleted or brought offline because it is the quorum resource.
        /// </summary>
        NOT_QUORUM_CAPABLE = 0x139d,

        /// <summary>
        /// The cluster software is shutting down.
        /// </summary>
        CLUSTER_SHUTTING_DOWN = 0x139e,

        /// <summary>
        /// The group or resource is not in the correct state to perform the requested operation.
        /// </summary>
        INVALID_STATE = 0x139f,

        /// <summary>
        /// The group or resource is not in the correct state to perform the requested operation.
        /// </summary>
        RESOURCE_PROPERTIES_STORED = 0x13a0,

        /// <summary>
        /// The group or resource is not in the correct state to perform the requested operation.
        /// </summary>
        NOT_QUORUM_CLASS = 0x13a1,

        /// <summary>
        /// The cluster resource could not be deleted since it is a core resource.
        /// </summary>
        CORE_RESOURCE = 0x13a2,

        /// <summary>
        /// The quorum resource failed to come online.
        /// </summary>
        QUORUM_RESOURCE_ONLINE_FAILED = 0x13a3,

        /// <summary>
        /// The quorum log could not be created or mounted successfully.
        /// </summary>
        QUORUMLOG_OPEN_FAILED = 0x13a4,

        /// <summary>
        /// The cluster log is corrupt.
        /// </summary>
        CLUSTERLOG_CORRUPT = 0x13a5,

        /// <summary>
        /// The record could not be written to the cluster log since it exceeds the maximum size.
        /// </summary>
        CLUSTERLOG_RECORD_EXCEEDS_MAXSIZE = 0x13a6,

        /// <summary>
        /// The cluster log exceeds its maximum size.
        /// </summary>
        CLUSTERLOG_EXCEEDS_MAXSIZE = 0x13a7,

        /// <summary>
        /// No checkpoint record was found in the cluster log.
        /// </summary>
        CLUSTERLOG_CHKPOINT_NOT_FOUND = 0x13a8,

        /// <summary>
        /// The minimum required disk space needed for logging is not available.
        /// </summary>
        CLUSTERLOG_NOT_ENOUGH_SPACE = 0x13a9,

        /// <summary>
        /// The minimum required disk space needed for logging is not available.
        /// </summary>
        QUORUM_OWNER_ALIVE = 0x13aa,

        /// <summary>
        /// A cluster network is not available for this operation.
        /// </summary>
        NETWORK_NOT_AVAILABLE = 0x13ab,

        /// <summary>
        /// A cluster node is not available for this operation.
        /// </summary>
        NODE_NOT_AVAILABLE = 0x13ac,

        /// <summary>
        /// All cluster nodes must be running to perform this operation.
        /// </summary>
        ALnodeS_NOT_AVAILABLE = 0x13ad,

        /// <summary>
        /// A cluster resource failed.
        /// </summary>
        RESOURCE_FAILED = 0x13ae,

        /// <summary>
        /// The cluster node is not valid.
        /// </summary>
        CLUSTER_INVALID_NODE = 0x13af,

        /// <summary>
        /// The cluster node already exists.
        /// </summary>
        CLUSTER_NODE_EXISTS = 0x13b0,

        /// <summary>
        /// A node is in the process of joining the cluster.
        /// </summary>
        CLUSTER_JOIN_IN_PROGRESS = 0x13b1,

        /// <summary>
        /// The cluster node was not found.
        /// </summary>
        CLUSTER_NODE_NOT_FOUND = 0x13b2,

        /// <summary>
        /// The cluster local node information was not found.
        /// </summary>
        CLUSTER_LOCAnode_NOT_FOUND = 0x13b3,

        /// <summary>
        /// The cluster network already exists.
        /// </summary>
        CLUSTER_NETWORK_EXISTS = 0x13b4,

        /// <summary>
        /// The cluster network was not found.
        /// </summary>
        CLUSTER_NETWORK_NOT_FOUND = 0x13b5,

        /// <summary>
        /// The cluster network interface already exists.
        /// </summary>
        CLUSTER_NETINTERFACE_EXISTS = 0x13b6,

        /// <summary>
        /// The cluster network interface was not found.
        /// </summary>
        CLUSTER_NETINTERFACE_NOT_FOUND = 0x13b7,

        /// <summary>
        /// The cluster request is not valid for this object.
        /// </summary>
        CLUSTER_INVALID_REQUEST = 0x13b8,

        /// <summary>
        /// The cluster network provider is not valid.
        /// </summary>
        CLUSTER_INVALID_NETWORK_PROVIDER = 0x13b9,

        /// <summary>
        /// The cluster node is down.
        /// </summary>
        CLUSTER_NODE_DOWN = 0x13ba,

        /// <summary>
        /// The cluster node is not reachable.
        /// </summary>
        CLUSTER_NODE_UNREACHABLE = 0x13bb,

        /// <summary>
        /// The cluster node is not a member of the cluster.
        /// </summary>
        CLUSTER_NODE_NOT_MEMBER = 0x13bc,

        /// <summary>
        /// A cluster join operation is not in progress.
        /// </summary>
        CLUSTER_JOIN_NOT_IN_PROGRESS = 0x13bd,

        /// <summary>
        /// The cluster network is not valid.
        /// </summary>
        CLUSTER_INVALID_NETWORK = 0x13be,

        /// <summary>
        /// The cluster node is up.
        /// </summary>
        CLUSTER_NODE_UP = 0x13c0,

        /// <summary>
        /// The cluster IP address is already in use.
        /// </summary>
        CLUSTER_IPADDR_IN_USE = 0x13c1,

        /// <summary>
        /// The cluster node is not paused.
        /// </summary>
        CLUSTER_NODE_NOT_PAUSED = 0x13c2,

        /// <summary>
        /// No cluster security context is available.
        /// </summary>
        CLUSTER_NO_SECURITY_CONTEXT = 0x13c3,

        /// <summary>
        /// The cluster network is not configured for internal cluster communication.
        /// </summary>
        CLUSTER_NETWORK_NOT_INTERNAL = 0x13c4,

        /// <summary>
        /// The cluster node is already up.
        /// </summary>
        CLUSTER_NODE_ALREADY_UP = 0x13c5,

        /// <summary>
        /// The cluster node is already down.
        /// </summary>
        CLUSTER_NODE_ALREADY_DOWN = 0x13c6,

        /// <summary>
        /// The cluster network is already online.
        /// </summary>
        CLUSTER_NETWORK_ALREADY_ONLINE = 0x13c7,

        /// <summary>
        /// The cluster network is already offline.
        /// </summary>
        CLUSTER_NETWORK_ALREADY_OFFLINE = 0x13c8,

        /// <summary>
        /// The cluster node is already a member of the cluster.
        /// </summary>
        CLUSTER_NODE_ALREADY_MEMBER = 0x13c9,

        /// <summary>
        /// The cluster node is already a member of the cluster.
        /// </summary>
        CLUSTER_LAST_INTERNAL_NETWORK = 0x13ca,

        /// <summary>
        /// The cluster node is already a member of the cluster.
        /// </summary>
        CLUSTER_NETWORK_HAS_DEPENDENTS = 0x13cb,

        /// <summary>
        /// The cluster node is already a member of the cluster.
        /// </summary>
        INVALID_OPERATION_ON_QUORUM = 0x13cc,

        /// <summary>
        /// The cluster quorum resource is not allowed to have any dependencies.
        /// </summary>
        DEPENDENCY_NOT_ALLOWED = 0x13cd,

        /// <summary>
        /// The cluster node is paused.
        /// </summary>
        CLUSTER_NODE_PAUSED = 0x13ce,

        /// <summary>
        /// The cluster resource cannot be brought online. The owner node cannot run this resource.
        /// </summary>
        NODE_CANT_HOST_RESOURCE = 0x13cf,

        /// <summary>
        /// The cluster node is not ready to perform the requested operation.
        /// </summary>
        CLUSTER_NODE_NOT_READY = 0x13d0,

        /// <summary>
        /// The cluster node is shutting down.
        /// </summary>
        CLUSTER_NODE_SHUTTING_DOWN = 0x13d1,

        /// <summary>
        /// The cluster join operation was aborted.
        /// </summary>
        CLUSTER_JOIN_ABORTED = 0x13d2,

        /// <summary>
        /// The cluster join operation was aborted.
        /// </summary>
        CLUSTER_INCOMPATIBLE_VERSIONS = 0x13d3,

        /// <summary>
        /// The cluster join operation was aborted.
        /// </summary>
        CLUSTER_MAXNUM_OF_RESOURCES_EXCEEDED = 0x13d4,

        /// <summary>
        /// The cluster join operation was aborted.
        /// </summary>
        CLUSTER_SYSTEM_CONFIG_CHANGED = 0x13d5,

        /// <summary>
        /// The specified resource type was not found.
        /// </summary>
        CLUSTER_RESOURCE_TYPE_NOT_FOUND = 0x13d6,

        /// <summary>
        /// The specified resource type was not found.
        /// </summary>
        CLUSTER_RESTYPE_NOT_SUPPORTED = 0x13d7,

        /// <summary>
        /// The specified resource type was not found.
        /// </summary>
        CLUSTER_RESNAME_NOT_FOUND = 0x13d8,

        /// <summary>
        /// No authentication package could be registered with the RPC server.
        /// </summary>
        CLUSTER_NO_RPC_PACKAGES_REGISTERED = 0x13d9,

        /// <summary>
        /// No authentication package could be registered with the RPC server.
        /// </summary>
        CLUSTER_OWNER_NOT_IN_PREFLIST = 0x13da,

        /// <summary>
        /// No authentication package could be registered with the RPC server.
        /// </summary>
        CLUSTER_DATABASE_SEQMISMATCH = 0x13db,

        /// <summary>
        /// No authentication package could be registered with the RPC server.
        /// </summary>
        RESMON_INVALID_STATE = 0x13dc,

        /// <summary>
        /// A non locker code got a request to reserve the lock for making global updates.
        /// </summary>
        CLUSTER_GUM_NOT_LOCKER = 0x13dd,

        /// <summary>
        /// The quorum disk could not be located by the cluster service.
        /// </summary>
        QUORUM_DISK_NOT_FOUND = 0x13de,

        /// <summary>
        /// The backed up cluster database is possibly corrupt.
        /// </summary>
        DATABASE_BACKUP_CORRUPT = 0x13df,

        /// <summary>
        /// A DFS root already exists in this cluster node.
        /// </summary>
        CLUSTER_NODE_ALREADY_HAS_DFS_ROOT = 0x13e0,

        /// <summary>
        /// An attempt to modify a resource property failed because it conflicts with another existing property.
        /// </summary>
        RESOURCE_PROPERTY_UNCHANGEABLE = 0x13e1,

        /// <summary>
        /// An operation was attempted that is incompatible with the current membership state of the node.
        /// </summary>
        CLUSTER_MEMBERSHIP_INVALID_STATE = 0x1702,

        /// <summary>
        /// The quorum resource does not contain the quorum log.
        /// </summary>
        CLUSTER_QUORUMLOG_NOT_FOUND = 0x1703,

        /// <summary>
        /// The membership engine requested shutdown of the cluster service on this node.
        /// </summary>
        CLUSTER_MEMBERSHIP_HALT = 0x1704,

        /// <summary>
        /// The membership engine requested shutdown of the cluster service on this node.
        /// </summary>
        CLUSTER_INSTANCE_ID_MISMATCH = 0x1705,

        /// <summary>
        /// A matching cluster network for the specified IP address could not be found.
        /// </summary>
        CLUSTER_NETWORK_NOT_FOUND_FOR_IP = 0x1706,

        /// <summary>
        /// The actual data type of the property did not match the expected data type of the property.
        /// </summary>
        CLUSTER_PROPERTY_DATA_TYPE_MISMATCH = 0x1707,

        /// <summary>
        /// The actual data type of the property did not match the expected data type of the property.
        /// </summary>
        CLUSTER_EVICT_WITHOUT_CLEANUP = 0x1708,

        /// <summary>
        /// Two or more parameter values specified for a resource's properties are in conflict.
        /// </summary>
        CLUSTER_PARAMETER_MISMATCH = 0x1709,

        /// <summary>
        /// This computer cannot be made a member of a cluster.
        /// </summary>
        NODE_CANNOT_BE_CLUSTERED = 0x170a,

        /// <summary>
        /// This computer cannot be made a member of a cluster.
        /// </summary>
        CLUSTER_WRONG_OS_VERSION = 0x170b,

        /// <summary>
        /// This computer cannot be made a member of a cluster.
        /// </summary>
        CLUSTER_CANT_CREATE_DUP_CLUSTER_NAME = 0x170c,

        /// <summary>
        /// The cluster configuration action has already been committed.
        /// </summary>
        CLUSCFG_ALREADY_COMMITTED = 0x170d,

        /// <summary>
        /// The cluster configuration action could not be rolled back.
        /// </summary>
        CLUSCFG_ROLLBACK_FAILED = 0x170e,

        /// <summary>
        /// The cluster configuration action could not be rolled back.
        /// </summary>
        CLUSCFG_SYSTEM_DISK_DRIVE_LETTER_CONFLICT = 0x170f,

        /// <summary>
        /// One or more nodes in the cluster are running a version of Windows that does not support this operation.
        /// </summary>
        CLUSTER_OLD_VERSION = 0x1710,

        /// <summary>
        /// The name of the corresponding computer account doesn't match the Network Name for this resource.
        /// </summary>
        CLUSTER_MISMATCHED_COMPUTER_ACCT_NAME = 0x1711,

        /// <summary>
        /// No network adapters are available.
        /// </summary>
        CLUSTER_NO_NET_ADAPTERS = 0x1712,

        /// <summary>
        /// The cluster node has been poisoned.
        /// </summary>
        CLUSTER_POISONED = 0x1713,

        /// <summary>
        /// The group is unable to accept the request since it is moving to another node.
        /// </summary>
        CLUSTER_GROUP_MOVING = 0x1714,

        /// <summary>
        /// The resource type cannot accept the request since is too busy performing another operation.
        /// </summary>
        CLUSTER_RESOURCE_TYPE_BUSY = 0x1715,

        /// <summary>
        /// The call to the cluster resource DLL timed out.
        /// </summary>
        RESOURCE_CALL_TIMED_OUT = 0x1716,

        /// <summary>
        /// The call to the cluster resource DLL timed out.
        /// </summary>
        INVALID_CLUSTER_IPV6_ADDRESS = 0x1717,

        /// <summary>
        /// An internal cluster error occurred. A call to an invalid function was attempted.
        /// </summary>
        CLUSTER_INTERNAL_INVALID_FUNCTION = 0x1718,

        /// <summary>
        /// A parameter value is out of acceptable range.
        /// </summary>
        CLUSTER_PARAMETER_OUT_OF_BOUNDS = 0x1719,

        /// <summary>
        /// A parameter value is out of acceptable range.
        /// </summary>
        CLUSTER_PARTIAL_SEND = 0x171a,

        /// <summary>
        /// An invalid cluster registry operation was attempted.
        /// </summary>
        CLUSTER_REGISTRY_INVALID_FUNCTION = 0x171b,

        /// <summary>
        /// An input string of characters is not properly terminated.
        /// </summary>
        CLUSTER_INVALID_STRING_TERMINATION = 0x171c,

        /// <summary>
        /// An input string of characters is not in a valid format for the data it represents.
        /// </summary>
        CLUSTER_INVALID_STRING_FORMAT = 0x171d,

        /// <summary>
        /// An input string of characters is not in a valid format for the data it represents.
        /// </summary>
        CLUSTER_DATABASE_TRANSACTION_IN_PROGRESS = 0x171e,

        /// <summary>
        /// An input string of characters is not in a valid format for the data it represents.
        /// </summary>
        CLUSTER_DATABASE_TRANSACTION_NOT_IN_PROGRESS = 0x171f,

        /// <summary>
        /// An internal cluster error occurred. Data was not properly initialized.
        /// </summary>
        CLUSTER_NULdata = 0x1720,

        /// <summary>
        /// An error occurred while reading from a stream of data. An unexpected number of bytes was returned.
        /// </summary>
        CLUSTER_PARTIAL_READ = 0x1721,

        /// <summary>
        /// An error occurred while writing to a stream of data. The required number of bytes could not be written.
        /// </summary>
        CLUSTER_PARTIAL_WRITE = 0x1722,

        /// <summary>
        /// An error occurred while deserializing a stream of cluster data.
        /// </summary>
        CLUSTER_CANT_DESERIALIZE_DATA = 0x1723,

        /// <summary>
        /// An error occurred while deserializing a stream of cluster data.
        /// </summary>
        DEPENDENT_RESOURCE_PROPERTY_CONFLICT = 0x1724,

        /// <summary>
        /// A quorum of cluster nodes was not present to form a cluster.
        /// </summary>
        CLUSTER_NO_QUORUM = 0x1725,

        /// <summary>
        /// A quorum of cluster nodes was not present to form a cluster.
        /// </summary>
        CLUSTER_INVALID_IPV6_NETWORK = 0x1726,

        /// <summary>
        /// A quorum of cluster nodes was not present to form a cluster.
        /// </summary>
        CLUSTER_INVALID_IPV6_TUNNEL_NETWORK = 0x1727,

        /// <summary>
        /// Quorum resource cannot reside in the Available Storage group.
        /// </summary>
        QUORUM_NOT_ALLOWED_IN_THIS_GROUP = 0x1728,

        /// <summary>
        /// The dependencies for this resource are nested too deeply.
        /// </summary>
        DEPENDENCY_TREE_TOO_COMPLEX = 0x1729,

        /// <summary>
        /// The call into the resource DLL raised an unhandled exception.
        /// </summary>
        EXCEPTION_IN_RESOURCE_CALL = 0x172a,

        /// <summary>
        /// The RHS process failed to initialize.
        /// </summary>
        CLUSTER_RHS_FAILED_INITIALIZATION = 0x172b,

        /// <summary>
        /// The Failover Clustering feature is not installed on this node.
        /// </summary>
        CLUSTER_NOT_INSTALLED = 0x172c,

        /// <summary>
        /// The resources must be online on the same node for this operation.
        /// </summary>
        CLUSTER_RESOURCES_MUST_BE_ONLINE_ON_THE_SAME_NODE = 0x172d,

        /// <summary>
        /// A new node can not be added since this cluster is already at its maximum number of nodes.
        /// </summary>
        CLUSTER_MAX_NODES_IN_CLUSTER = 0x172e,

        /// <summary>
        /// This cluster can not be created since the specified number of nodes exceeds the maximum allowed limit.
        /// </summary>
        CLUSTER_TOO_MANY_NODES = 0x172f,

        /// <summary>
        /// This cluster can not be created since the specified number of nodes exceeds the maximum allowed limit.
        /// </summary>
        CLUSTER_OBJECT_ALREADY_USED = 0x1730,

        /// <summary>
        /// This cluster can not be created since the specified number of nodes exceeds the maximum allowed limit.
        /// </summary>
        NONCORE_GROUPS_FOUND = 0x1731,

        /// <summary>
        /// This cluster can not be created since the specified number of nodes exceeds the maximum allowed limit.
        /// </summary>
        FILE_SHARE_RESOURCE_CONFLICT = 0x1732,

        /// <summary>
        /// This cluster can not be created since the specified number of nodes exceeds the maximum allowed limit.
        /// </summary>
        CLUSTER_EVICT_INVALID_REQUEST = 0x1733,

        /// <summary>
        /// Only one instance of this resource type is allowed in the cluster.
        /// </summary>
        CLUSTER_SINGLETON_RESOURCE = 0x1734,

        /// <summary>
        /// Only one instance of this resource type is allowed per resource group.
        /// </summary>
        CLUSTER_GROUP_SINGLETON_RESOURCE = 0x1735,

        /// <summary>
        /// The resource failed to come online due to the failure of one or more provider resources.
        /// </summary>
        CLUSTER_RESOURCE_PROVIDER_FAILED = 0x1736,

        /// <summary>
        /// The resource has indicated that it cannot come online on any node.
        /// </summary>
        CLUSTER_RESOURCE_CONFIGURATION_ERROR = 0x1737,

        /// <summary>
        /// The current operation cannot be performed on this group at this time.
        /// </summary>
        CLUSTER_GROUP_BUSY = 0x1738,

        /// <summary>
        /// The directory or file is not located on a cluster shared volume.
        /// </summary>
        CLUSTER_NOT_SHARED_VOLUME = 0x1739,

        /// <summary>
        /// The Security Descriptor does not meet the requirements for a cluster.
        /// </summary>
        CLUSTER_INVALID_SECURITY_DESCRIPTOR = 0x173a,

        /// <summary>
        /// The Security Descriptor does not meet the requirements for a cluster.
        /// </summary>
        CLUSTER_SHARED_VOLUMES_IN_USE = 0x173b,

        /// <summary>
        /// The Security Descriptor does not meet the requirements for a cluster.
        /// </summary>
        CLUSTER_USE_SHARED_VOLUMES_API = 0x173c,

        /// <summary>
        /// Back up is in progress. Please wait for backup completion before trying this operation again.
        /// </summary>
        CLUSTER_BACKUP_IN_PROGRESS = 0x173d,

        /// <summary>
        /// The path does not belong to a cluster shared volume.
        /// </summary>
        NON_CSV_PATH = 0x173e,

        /// <summary>
        /// The cluster shared volume is not locally mounted on this node.
        /// </summary>
        CSV_VOLUME_NOT_LOCAL = 0x173f,

        /// <summary>
        /// The cluster watchdog is terminating.
        /// </summary>
        CLUSTER_WATCHDOG_TERMINATING = 0x1740,

        /// <summary>
        /// A resource vetoed a move between two nodes because they are incompatible.
        /// </summary>
        CLUSTER_RESOURCE_VETOED_MOVE_INCOMPATIBLE_NODES = 0x1741,

        /// <summary>
        /// A resource vetoed a move between two nodes because they are incompatible.
        /// </summary>
        CLUSTER_INVALID_NODE_WEIGHT = 0x1742,

        /// <summary>
        /// The resource vetoed the call.
        /// </summary>
        CLUSTER_RESOURCE_VETOED_CALL = 0x1743,

        /// <summary>
        /// Resource could not start or run because it could not reserve sufficient system resources.
        /// </summary>
        RESMON_SYSTEM_RESOURCES_LACKING = 0x1744,

        /// <summary>
        /// Resource could not start or run because it could not reserve sufficient system resources.
        /// </summary>
        CLUSTER_RESOURCE_VETOED_MOVE_NOT_ENOUGH_RESOURCES_ON_DESTINATION = 0x1745,

        /// <summary>
        /// Resource could not start or run because it could not reserve sufficient system resources.
        /// </summary>
        CLUSTER_RESOURCE_VETOED_MOVE_NOT_ENOUGH_RESOURCES_ON_SOURCE = 0x1746,

        /// <summary>
        /// The requested operation can not be completed because the group is queued for an operation.
        /// </summary>
        CLUSTER_GROUP_QUEUED = 0x1747,

        /// <summary>
        /// The requested operation can not be completed because a resource has locked status.
        /// </summary>
        CLUSTER_RESOURCE_LOCKED_STATUS = 0x1748,

        /// <summary>
        /// The resource cannot move to another node because a cluster shared volume vetoed the operation.
        /// </summary>
        CLUSTER_SHARED_VOLUME_FAILOVER_NOT_ALLOWED = 0x1749,

        /// <summary>
        /// This value was also named <strong>ERROR_CLUSTER_NODE_EVACUATION_IN_PROGRESS</strong>
        /// </summary>
        CLUSTER_NODE_DRAIN_IN_PROGRESS = 0x174a,

        /// <summary>
        /// Clustered storage is not connected to the node.
        /// </summary>
        CLUSTER_DISK_NOT_CONNECTED = 0x174b,

        /// <summary>
        /// Clustered storage is not connected to the node.
        /// </summary>
        DISK_NOT_CSV_CAPABLE = 0x174c,

        /// <summary>
        /// The resource must be part of the Available Storage group to complete this action.
        /// </summary>
        RESOURCE_NOT_IN_AVAILABLE_STORAGE = 0x174d,

        /// <summary>
        /// CSVFS failed operation as volume is in redirected mode.
        /// </summary>
        CLUSTER_SHARED_VOLUME_REDIRECTED = 0x174e,

        /// <summary>
        /// CSVFS failed operation as volume is not in redirected mode.
        /// </summary>
        CLUSTER_SHARED_VOLUME_NOT_REDIRECTED = 0x174f,

        /// <summary>
        /// Cluster properties cannot be returned at this time.
        /// </summary>
        CLUSTER_CANNOT_RETURN_PROPERTIES = 0x1750,

        /// <summary>
        /// Cluster properties cannot be returned at this time.
        /// </summary>
        CLUSTER_RESOURCE_CONTAINS_UNSUPPORTED_DIFF_AREA_FOR_SHARED_VOLUMES = 0x1751,

        /// <summary>
        /// The operation cannot be completed because the resource is in maintenance mode.
        /// </summary>
        CLUSTER_RESOURCE_IS_IN_MAINTENANCE_MODE = 0x1752,

        /// <summary>
        /// The operation cannot be completed because of cluster affinity conflicts.
        /// </summary>
        CLUSTER_AFFINITY_CONFLICT = 0x1753,

        /// <summary>
        /// The specified file could not be encrypted.
        /// </summary>
        ENCRYPTION_FAILED = 0x1770,

        /// <summary>
        /// The specified file could not be decrypted.
        /// </summary>
        DECRYPTION_FAILED = 0x1771,

        /// <summary>
        /// The specified file is encrypted and the user does not have the ability to decrypt it.
        /// </summary>
        FILE_ENCRYPTED = 0x1772,

        /// <summary>
        /// There is no valid encryption recovery policy configured for this system.
        /// </summary>
        NO_RECOVERY_POLICY = 0x1773,

        /// <summary>
        /// The required encryption driver is not loaded for this system.
        /// </summary>
        NO_EFS = 0x1774,

        /// <summary>
        /// The file was encrypted with a different encryption driver than is currently loaded.
        /// </summary>
        WRONG_EFS = 0x1775,

        /// <summary>
        /// There are no EFS keys defined for the user.
        /// </summary>
        NO_USER_KEYS = 0x1776,

        /// <summary>
        /// The specified file is not encrypted.
        /// </summary>
        FILE_NOT_ENCRYPTED = 0x1777,

        /// <summary>
        /// The specified file is not in the defined EFS export format.
        /// </summary>
        NOT_EXPORT_FORMAT = 0x1778,

        /// <summary>
        /// The specified file is read only.
        /// </summary>
        FILE_READ_ONLY = 0x1779,

        /// <summary>
        /// The directory has been disabled for encryption.
        /// </summary>
        DIR_EFS_DISALLOWED = 0x177a,

        /// <summary>
        /// The server is not trusted for remote encryption operation.
        /// </summary>
        EFS_SERVER_NOT_TRUSTED = 0x177b,

        /// <summary>
        /// Recovery policy configured for this system contains invalid recovery certificate.
        /// </summary>
        BAD_RECOVERY_POLICY = 0x177c,

        /// <summary>
        /// Recovery policy configured for this system contains invalid recovery certificate.
        /// </summary>
        EFS_ALG_BLOB_TOO_BIG = 0x177d,

        /// <summary>
        /// The disk partition does not support file encryption.
        /// </summary>
        VOLUME_NOT_SUPPORT_EFS = 0x177e,

        /// <summary>
        /// This machine is disabled for file encryption.
        /// </summary>
        EFS_DISABLED = 0x177f,

        /// <summary>
        /// A newer system is required to decrypt this encrypted file.
        /// </summary>
        EFS_VERSION_NOT_SUPPORT = 0x1780,

        /// <summary>
        /// The remote server sent an invalid response for a file being opened with Client Side Encryption.
        /// </summary>
        CS_ENCRYPTION_INVALID_SERVER_RESPONSE = 0x1781,

        /// <summary>
        /// Client Side Encryption is not supported by the remote server even though it claims to support it.
        /// </summary>
        CS_ENCRYPTION_UNSUPPORTED_SERVER = 0x1782,

        /// <summary>
        /// File is encrypted and should be opened in Client Side Encryption mode.
        /// </summary>
        CS_ENCRYPTION_EXISTING_ENCRYPTED_FILE = 0x1783,

        /// <summary>
        /// A new encrypted file is being created and a $EFS needs to be provided.
        /// </summary>
        CS_ENCRYPTION_NEW_ENCRYPTED_FILE = 0x1784,

        /// <summary>
        /// The SMB client requested a CSE FSCTL on a non-CSE file.
        /// </summary>
        CS_ENCRYPTION_FILE_NOT_CSE = 0x1785,

        /// <summary>
        /// The SMB client requested a CSE FSCTL on a non-CSE file.
        /// </summary>
        ENCRYPTION_POLICY_DENIES_OPERATION = 0x1786,

        /// <summary>
        /// The list of servers for this workgroup is not currently available.
        /// </summary>
        NO_BROWSER_SERVERS_FOUND = 0x17e6,

        /// <summary>
        /// The list of servers for this workgroup is not currently available.
        /// </summary>
        SCHED_E_SERVICE_NOT_LOCALSYSTEM = 0x1838,

        /// <summary>
        /// Log service encountered an invalid log sector.
        /// </summary>
        LOG_SECTOR_INVALID = 0x19c8,

        /// <summary>
        /// Log service encountered a log sector with invalid block parity.
        /// </summary>
        LOG_SECTOR_PARITY_INVALID = 0x19c9,

        /// <summary>
        /// Log service encountered a remapped log sector.
        /// </summary>
        LOG_SECTOR_REMAPPED = 0x19ca,

        /// <summary>
        /// Log service encountered a partial or incomplete log block.
        /// </summary>
        LOG_BLOCK_INCOMPLETE = 0x19cb,

        /// <summary>
        /// Log service encountered an attempt access data outside the active log range.
        /// </summary>
        LOG_INVALID_RANGE = 0x19cc,

        /// <summary>
        /// Log service user marshalling buffers are exhausted.
        /// </summary>
        LOG_BLOCKS_EXHAUSTED = 0x19cd,

        /// <summary>
        /// Log service encountered an attempt read from a marshalling area with an invalid read context.
        /// </summary>
        LOG_READ_CONTEXT_INVALID = 0x19ce,

        /// <summary>
        /// Log service encountered an invalid log restart area.
        /// </summary>
        LOG_RESTART_INVALID = 0x19cf,

        /// <summary>
        /// Log service encountered an invalid log block version.
        /// </summary>
        LOG_BLOCK_VERSION = 0x19d0,

        /// <summary>
        /// Log service encountered an invalid log block.
        /// </summary>
        LOG_BLOCK_INVALID = 0x19d1,

        /// <summary>
        /// Log service encountered an attempt to read the log with an invalid read mode.
        /// </summary>
        LOG_READ_MODE_INVALID = 0x19d2,

        /// <summary>
        /// Log service encountered a log stream with no restart area.
        /// </summary>
        LOG_NO_RESTART = 0x19d3,

        /// <summary>
        /// Log service encountered a corrupted metadata file.
        /// </summary>
        LOG_METADATA_CORRUPT = 0x19d4,

        /// <summary>
        /// Log service encountered a metadata file that could not be created by the log file system.
        /// </summary>
        LOG_METADATA_INVALID = 0x19d5,

        /// <summary>
        /// Log service encountered a metadata file with inconsistent data.
        /// </summary>
        LOG_METADATA_INCONSISTENT = 0x19d6,

        /// <summary>
        /// Log service encountered an attempt to erroneous allocate or dispose reservation space.
        /// </summary>
        LOG_RESERVATION_INVALID = 0x19d7,

        /// <summary>
        /// Log service cannot delete log file or file system container.
        /// </summary>
        LOG_CANT_DELETE = 0x19d8,

        /// <summary>
        /// Log service has reached the maximum allowable containers allocated to a log file.
        /// </summary>
        LOG_CONTAINER_LIMIT_EXCEEDED = 0x19d9,

        /// <summary>
        /// Log service has attempted to read or write backward past the start of the log.
        /// </summary>
        LOG_START_OF_LOG = 0x19da,

        /// <summary>
        /// Log policy could not be installed because a policy of the same type is already present.
        /// </summary>
        LOG_POLICY_ALREADY_INSTALLED = 0x19db,

        /// <summary>
        /// Log policy in question was not installed at the time of the request.
        /// </summary>
        LOG_POLICY_NOT_INSTALLED = 0x19dc,

        /// <summary>
        /// The installed set of policies on the log is invalid.
        /// </summary>
        LOG_POLICY_INVALID = 0x19dd,

        /// <summary>
        /// A policy on the log in question prevented the operation from completing.
        /// </summary>
        LOG_POLICY_CONFLICT = 0x19de,

        /// <summary>
        /// Log space cannot be reclaimed because the log is pinned by the archive tail.
        /// </summary>
        LOG_PINNED_ARCHIVE_TAIL = 0x19df,

        /// <summary>
        /// Log record is not a record in the log file.
        /// </summary>
        LOG_RECORD_NONEXISTENT = 0x19e0,

        /// <summary>
        /// Number of reserved log records or the adjustment of the number of reserved log records is invalid.
        /// </summary>
        LOG_RECORDS_RESERVED_INVALID = 0x19e1,

        /// <summary>
        /// Reserved log space or the adjustment of the log space is invalid.
        /// </summary>
        LOG_SPACE_RESERVED_INVALID = 0x19e2,

        /// <summary>
        /// An new or existing archive tail or base of the active log is invalid.
        /// </summary>
        LOG_TAIL_INVALID = 0x19e3,

        /// <summary>
        /// Log space is exhausted.
        /// </summary>
        LOG_FULL = 0x19e4,

        /// <summary>
        /// The log could not be set to the requested size.
        /// </summary>
        COULD_NOT_RESIZE_LOG = 0x19e5,

        /// <summary>
        /// Log is multiplexed, no direct writes to the physical log is allowed.
        /// </summary>
        LOG_MULTIPLEXED = 0x19e6,

        /// <summary>
        /// The operation failed because the log is a dedicated log.
        /// </summary>
        LOG_DEDICATED = 0x19e7,

        /// <summary>
        /// The operation requires an archive context.
        /// </summary>
        LOG_ARCHIVE_NOT_IN_PROGRESS = 0x19e8,

        /// <summary>
        /// Log archival is in progress.
        /// </summary>
        LOG_ARCHIVE_IN_PROGRESS = 0x19e9,

        /// <summary>
        /// The operation requires a non-ephemeral log, but the log is ephemeral.
        /// </summary>
        LOG_EPHEMERAL = 0x19ea,

        /// <summary>
        /// The log must have at least two containers before it can be read from or written to.
        /// </summary>
        LOG_NOT_ENOUGH_CONTAINERS = 0x19eb,

        /// <summary>
        /// A log client has already registered on the stream.
        /// </summary>
        LOG_CLIENT_ALREADY_REGISTERED = 0x19ec,

        /// <summary>
        /// A log client has not been registered on the stream.
        /// </summary>
        LOG_CLIENT_NOT_REGISTERED = 0x19ed,

        /// <summary>
        /// A request has already been made to handle the log full condition.
        /// </summary>
        LOG_FULL_HANDLER_IN_PROGRESS = 0x19ee,

        /// <summary>
        /// Log service encountered an error when attempting to read from a log container.
        /// </summary>
        LOG_CONTAINER_READ_FAILED = 0x19ef,

        /// <summary>
        /// Log service encountered an error when attempting to write to a log container.
        /// </summary>
        LOG_CONTAINER_WRITE_FAILED = 0x19f0,

        /// <summary>
        /// Log service encountered an error when attempting open a log container.
        /// </summary>
        LOG_CONTAINER_OPEN_FAILED = 0x19f1,

        /// <summary>
        /// Log service encountered an invalid container state when attempting a requested action.
        /// </summary>
        LOG_CONTAINER_STATE_INVALID = 0x19f2,

        /// <summary>
        /// Log service is not in the correct state to perform a requested action.
        /// </summary>
        LOG_STATE_INVALID = 0x19f3,

        /// <summary>
        /// Log space cannot be reclaimed because the log is pinned.
        /// </summary>
        LOG_PINNED = 0x19f4,

        /// <summary>
        /// Log metadata flush failed.
        /// </summary>
        LOG_METADATA_FLUSH_FAILED = 0x19f5,

        /// <summary>
        /// Security on the log and its containers is inconsistent.
        /// </summary>
        LOG_INCONSISTENT_SECURITY = 0x19f6,

        /// <summary>
        /// Records were appended to the log or reservation changes were made, but the log could not be flushed.
        /// </summary>
        LOG_APPENDED_FLUSH_FAILED = 0x19f7,

        /// <summary>
        /// Records were appended to the log or reservation changes were made, but the log could not be flushed.
        /// </summary>
        LOG_PINNED_RESERVATION = 0x19f8,

        /// <summary>
        /// The transaction handle associated with this operation is not valid.
        /// </summary>
        INVALID_TRANSACTION = 0x1a2c,

        /// <summary>
        /// The requested operation was made in the context of a transaction that is no longer active.
        /// </summary>
        TRANSACTION_NOT_ACTIVE = 0x1a2d,

        /// <summary>
        /// The requested operation is not valid on the Transaction object in its current state.
        /// </summary>
        TRANSACTION_REQUEST_NOT_VALID = 0x1a2e,

        /// <summary>
        /// The requested operation is not valid on the Transaction object in its current state.
        /// </summary>
        TRANSACTION_NOT_REQUESTED = 0x1a2f,

        /// <summary>
        /// It is too late to perform the requested operation, since the Transaction has already been aborted.
        /// </summary>
        TRANSACTION_ALREADY_ABORTED = 0x1a30,

        /// <summary>
        /// It is too late to perform the requested operation, since the Transaction has already been committed.
        /// </summary>
        TRANSACTION_ALREADY_COMMITTED = 0x1a31,

        /// <summary>
        /// It is too late to perform the requested operation, since the Transaction has already been committed.
        /// </summary>
        TM_INITIALIZATION_FAILED = 0x1a32,

        /// <summary>
        /// The specified ResourceManager made no changes or updates to the resource under this transaction.
        /// </summary>
        RESOURCEMANAGER_READ_ONLY = 0x1a33,

        /// <summary>
        /// The resource manager has attempted to prepare a transaction that it has not successfully joined.
        /// </summary>
        TRANSACTION_NOT_JOINED = 0x1a34,

        /// <summary>
        /// The resource manager has attempted to prepare a transaction that it has not successfully joined.
        /// </summary>
        TRANSACTION_SUPERIOR_EXISTS = 0x1a35,

        /// <summary>
        /// The RM tried to register a protocol that already exists.
        /// </summary>
        CRM_PROTOCOaLREADY_EXISTS = 0x1a36,

        /// <summary>
        /// The attempt to propagate the Transaction failed.
        /// </summary>
        TRANSACTION_PROPAGATION_FAILED = 0x1a37,

        /// <summary>
        /// The requested propagation protocol was not registered as a CRM.
        /// </summary>
        CRM_PROTOCOnot_FOUND = 0x1a38,

        /// <summary>
        /// The buffer passed in to PushTransaction or PullTransaction is not in a valid format.
        /// </summary>
        TRANSACTION_INVALID_MARSHALbUFFER = 0x1a39,

        /// <summary>
        /// The buffer passed in to PushTransaction or PullTransaction is not in a valid format.
        /// </summary>
        CURRENT_TRANSACTION_NOT_VALID = 0x1a3a,

        /// <summary>
        /// The specified Transaction object could not be opened, because it was not found.
        /// </summary>
        TRANSACTION_NOT_FOUND = 0x1a3b,

        /// <summary>
        /// The specified ResourceManager object could not be opened, because it was not found.
        /// </summary>
        RESOURCEMANAGER_NOT_FOUND = 0x1a3c,

        /// <summary>
        /// The specified Enlistment object could not be opened, because it was not found.
        /// </summary>
        ENLISTMENT_NOT_FOUND = 0x1a3d,

        /// <summary>
        /// The specified TransactionManager object could not be opened, because it was not found.
        /// </summary>
        TRANSACTIONMANAGER_NOT_FOUND = 0x1a3e,

        /// <summary>
        /// The specified TransactionManager object could not be opened, because it was not found.
        /// </summary>
        TRANSACTIONMANAGER_NOT_ONLINE = 0x1a3f,

        /// <summary>
        /// The specified TransactionManager object could not be opened, because it was not found.
        /// </summary>
        TRANSACTIONMANAGER_RECOVERY_NAME_COLLISION = 0x1a40,

        /// <summary>
        /// The specified TransactionManager object could not be opened, because it was not found.
        /// </summary>
        TRANSACTION_NOT_ROOT = 0x1a41,

        /// <summary>
        /// The specified TransactionManager object could not be opened, because it was not found.
        /// </summary>
        TRANSACTION_OBJECT_EXPIRED = 0x1a42,

        /// <summary>
        /// The specified TransactionManager object could not be opened, because it was not found.
        /// </summary>
        TRANSACTION_RESPONSE_NOT_ENLISTED = 0x1a43,

        /// <summary>
        /// The specified TransactionManager object could not be opened, because it was not found.
        /// </summary>
        TRANSACTION_RECORD_TOO_LONG = 0x1a44,

        /// <summary>
        /// Implicit transaction are not supported.
        /// </summary>
        IMPLICIT_TRANSACTION_NOT_SUPPORTED = 0x1a45,

        /// <summary>
        /// Implicit transaction are not supported.
        /// </summary>
        TRANSACTION_INTEGRITY_VIOLATED = 0x1a46,

        /// <summary>
        /// Implicit transaction are not supported.
        /// </summary>
        TRANSACTIONMANAGER_IDENTITY_MISMATCH = 0x1a47,

        /// <summary>
        /// Implicit transaction are not supported.
        /// </summary>
        RM_CANNOT_BE_FROZEN_FOR_SNAPSHOT = 0x1a48,

        /// <summary>
        /// Implicit transaction are not supported.
        /// </summary>
        TRANSACTION_MUST_WRITETHROUGH = 0x1a49,

        /// <summary>
        /// The transaction does not have a superior enlistment.
        /// </summary>
        TRANSACTION_NO_SUPERIOR = 0x1a4a,

        /// <summary>
        /// The transaction does not have a superior enlistment.
        /// </summary>
        HEURISTIC_DAMAGE_POSSIBLE = 0x1a4b,

        /// <summary>
        /// The function attempted to use a name that is reserved for use by another transaction.
        /// </summary>
        TRANSACTIONAcONFLICT = 0x1a90,

        /// <summary>
        /// The function attempted to use a name that is reserved for use by another transaction.
        /// </summary>
        RM_NOT_ACTIVE = 0x1a91,

        /// <summary>
        /// The metadata of the RM has been corrupted. The RM will not function.
        /// </summary>
        RM_METADATA_CORRUPT = 0x1a92,

        /// <summary>
        /// The specified directory does not contain a resource manager.
        /// </summary>
        DIRECTORY_NOT_RM = 0x1a93,

        /// <summary>
        /// The remote server or share does not support transacted file operations.
        /// </summary>
        TRANSACTIONS_UNSUPPORTED_REMOTE = 0x1a95,

        /// <summary>
        /// The requested log size is invalid.
        /// </summary>
        LOG_RESIZE_INVALID_SIZE = 0x1a96,

        /// <summary>
        /// The requested log size is invalid.
        /// </summary>
        OBJECT_NO_LONGER_EXISTS = 0x1a97,

        /// <summary>
        /// The specified file miniversion was not found for this transacted file open.
        /// </summary>
        STREAM_MINIVERSION_NOT_FOUND = 0x1a98,

        /// <summary>
        /// The specified file miniversion was not found for this transacted file open.
        /// </summary>
        STREAM_MINIVERSION_NOT_VALID = 0x1a99,

        /// <summary>
        /// A miniversion may only be opened in the context of the transaction that created it.
        /// </summary>
        MINIVERSION_INACCESSIBLE_FROM_SPECIFIED_TRANSACTION = 0x1a9a,

        /// <summary>
        /// It is not possible to open a miniversion with modify access.
        /// </summary>
        CANT_OPEN_MINIVERSION_WITH_MODIFY_INTENT = 0x1a9b,

        /// <summary>
        /// It is not possible to create any more miniversions for this stream.
        /// </summary>
        CANT_CREATE_MORE_STREAM_MINIVERSIONS = 0x1a9c,

        /// <summary>
        /// The remote server sent mismatching version number or Fid for a file opened with transactions.
        /// </summary>
        REMOTE_FILE_VERSION_MISMATCH = 0x1a9e,

        /// <summary>
        /// The remote server sent mismatching version number or Fid for a file opened with transactions.
        /// </summary>
        HANDLE_NO_LONGER_VALID = 0x1a9f,

        /// <summary>
        /// There is no transaction metadata on the file.
        /// </summary>
        NO_TXF_METADATA = 0x1aa0,

        /// <summary>
        /// The log data is corrupt.
        /// </summary>
        LOG_CORRUPTION_DETECTED = 0x1aa1,

        /// <summary>
        /// The file can't be recovered because there is a handle still open on it.
        /// </summary>
        CANT_RECOVER_WITH_HANDLE_OPEN = 0x1aa2,

        /// <summary>
        /// The file can't be recovered because there is a handle still open on it.
        /// </summary>
        RM_DISCONNECTED = 0x1aa3,

        /// <summary>
        /// The request was rejected because the enlistment in question is not a superior enlistment.
        /// </summary>
        ENLISTMENT_NOT_SUPERIOR = 0x1aa4,

        /// <summary>
        /// The transactional resource manager is already consistent. Recovery is not needed.
        /// </summary>
        RECOVERY_NOT_NEEDED = 0x1aa5,

        /// <summary>
        /// The transactional resource manager has already been started.
        /// </summary>
        RM_ALREADY_STARTED = 0x1aa6,

        /// <summary>
        /// The transactional resource manager has already been started.
        /// </summary>
        FILE_IDENTITY_NOT_PERSISTENT = 0x1aa7,

        /// <summary>
        /// The transactional resource manager has already been started.
        /// </summary>
        CANT_BREAK_TRANSACTIONAL_DEPENDENCY = 0x1aa8,

        /// <summary>
        /// The transactional resource manager has already been started.
        /// </summary>
        CANT_CROSS_RM_BOUNDARY = 0x1aa9,

        /// <summary>
        /// The $Txf directory must be empty for this operation to succeed.
        /// </summary>
        TXF_DIR_NOT_EMPTY = 0x1aaa,

        /// <summary>
        /// The $Txf directory must be empty for this operation to succeed.
        /// </summary>
        INDOUBT_TRANSACTIONS_EXIST = 0x1aab,

        /// <summary>
        /// The operation could not be completed because the transaction manager does not have a log.
        /// </summary>
        TM_VOLATILE = 0x1aac,

        /// <summary>
        /// The operation could not be completed because the transaction manager does not have a log.
        /// </summary>
        ROLLBACK_TIMER_EXPIRED = 0x1aad,

        /// <summary>
        /// The transactional metadata attribute on the file or directory is corrupt and unreadable.
        /// </summary>
        TXF_ATTRIBUTE_CORRUPT = 0x1aae,

        /// <summary>
        /// The encryption operation could not be completed because a transaction is active.
        /// </summary>
        EFS_NOT_ALLOWED_IN_TRANSACTION = 0x1aaf,

        /// <summary>
        /// This object is not allowed to be opened in a transaction.
        /// </summary>
        TRANSACTIONAL_OPEN_NOT_ALLOWED = 0x1ab0,

        /// <summary>
        /// This object is not allowed to be opened in a transaction.
        /// </summary>
        LOG_GROWTH_FAILED = 0x1ab1,

        /// <summary>
        /// Memory mapping (creating a mapped section) a remote file under a transaction is not supported.
        /// </summary>
        TRANSACTED_MAPPING_UNSUPPORTED_REMOTE = 0x1ab2,

        /// <summary>
        /// Transaction metadata is already present on this file and cannot be superseded.
        /// </summary>
        TXF_METADATA_ALREADY_PRESENT = 0x1ab3,

        /// <summary>
        /// A transaction scope could not be entered because the scope handler has not been initialized.
        /// </summary>
        TRANSACTION_SCOPE_CALLBACKS_NOT_SET = 0x1ab4,

        /// <summary>
        /// A transaction scope could not be entered because the scope handler has not been initialized.
        /// </summary>
        TRANSACTION_REQUIRED_PROMOTION = 0x1ab5,

        /// <summary>
        /// A transaction scope could not be entered because the scope handler has not been initialized.
        /// </summary>
        CANNOT_EXECUTE_FILE_IN_TRANSACTION = 0x1ab6,

        /// <summary>
        /// A transaction scope could not be entered because the scope handler has not been initialized.
        /// </summary>
        TRANSACTIONS_NOT_FROZEN = 0x1ab7,

        /// <summary>
        /// Transactions cannot be frozen because a freeze is already in progress.
        /// </summary>
        TRANSACTION_FREEZE_IN_PROGRESS = 0x1ab8,

        /// <summary>
        /// Transactions cannot be frozen because a freeze is already in progress.
        /// </summary>
        NOT_SNAPSHOT_VOLUME = 0x1ab9,

        /// <summary>
        /// The savepoint operation failed because files are open on the transaction. This is not permitted.
        /// </summary>
        NO_SAVEPOINT_WITH_OPEN_FILES = 0x1aba,

        /// <summary>
        /// The savepoint operation failed because files are open on the transaction. This is not permitted.
        /// </summary>
        DATA_LOST_REPAIR = 0x1abb,

        /// <summary>
        /// The sparse operation could not be completed because a transaction is active on the file.
        /// </summary>
        SPARSE_NOT_ALLOWED_IN_TRANSACTION = 0x1abc,

        /// <summary>
        /// The sparse operation could not be completed because a transaction is active on the file.
        /// </summary>
        TM_IDENTITY_MISMATCH = 0x1abd,

        /// <summary>
        /// The sparse operation could not be completed because a transaction is active on the file.
        /// </summary>
        FLOATED_SECTION = 0x1abe,

        /// <summary>
        /// The sparse operation could not be completed because a transaction is active on the file.
        /// </summary>
        CANNOT_ACCEPT_TRANSACTED_WORK = 0x1abf,

        /// <summary>
        /// The sparse operation could not be completed because a transaction is active on the file.
        /// </summary>
        CANNOT_ABORT_TRANSACTIONS = 0x1ac0,

        /// <summary>
        /// The operation could not be completed due to bad clusters on disk.
        /// </summary>
        BAD_CLUSTERS = 0x1ac1,

        /// <summary>
        /// The compression operation could not be completed because a transaction is active on the file.
        /// </summary>
        COMPRESSION_NOT_ALLOWED_IN_TRANSACTION = 0x1ac2,

        /// <summary>
        /// The operation could not be completed because the volume is dirty. Please run chkdsk and try again.
        /// </summary>
        VOLUME_DIRTY = 0x1ac3,

        /// <summary>
        /// The link tracking operation could not be completed because a transaction is active.
        /// </summary>
        NO_LINK_TRACKING_IN_TRANSACTION = 0x1ac4,

        /// <summary>
        /// This operation cannot be performed in a transaction.
        /// </summary>
        OPERATION_NOT_SUPPORTED_IN_TRANSACTION = 0x1ac5,

        /// <summary>
        /// This operation cannot be performed in a transaction.
        /// </summary>
        EXPIRED_HANDLE = 0x1ac6,

        /// <summary>
        /// This operation cannot be performed in a transaction.
        /// </summary>
        TRANSACTION_NOT_ENLISTED = 0x1ac7,

        /// <summary>
        /// The specified session name is invalid.
        /// </summary>
        CTX_WINSTATION_NAME_INVALID = 0x1b59,

        /// <summary>
        /// The specified protocol driver is invalid.
        /// </summary>
        CTX_INVALID_PD = 0x1b5a,

        /// <summary>
        /// The specified protocol driver was not found in the system path.
        /// </summary>
        CTX_PD_NOT_FOUND = 0x1b5b,

        /// <summary>
        /// The specified terminal connection driver was not found in the system path.
        /// </summary>
        CTX_WD_NOT_FOUND = 0x1b5c,

        /// <summary>
        /// A registry key for event logging could not be created for this session.
        /// </summary>
        CTX_CANNOT_MAKE_EVENTLOG_ENTRY = 0x1b5d,

        /// <summary>
        /// A service with the same name already exists on the system.
        /// </summary>
        CTX_SERVICE_NAME_COLLISION = 0x1b5e,

        /// <summary>
        /// A close operation is pending on the session.
        /// </summary>
        CTX_CLOSE_PENDING = 0x1b5f,

        /// <summary>
        /// There are no free output buffers available.
        /// </summary>
        CTX_NO_OUTBUF = 0x1b60,

        /// <summary>
        /// The MODEM.INF file was not found.
        /// </summary>
        CTX_MODEM_INF_NOT_FOUND = 0x1b61,

        /// <summary>
        /// The modem name was not found in MODEM.INF.
        /// </summary>
        CTX_INVALID_MODEMNAME = 0x1b62,

        /// <summary>
        /// The modem name was not found in MODEM.INF.
        /// </summary>
        CTX_MODEM_RESPONSE_ERROR = 0x1b63,

        /// <summary>
        /// The modem name was not found in MODEM.INF.
        /// </summary>
        CTX_MODEM_RESPONSE_TIMEOUT = 0x1b64,

        /// <summary>
        /// Carrier detect has failed or carrier has been dropped due to disconnect.
        /// </summary>
        CTX_MODEM_RESPONSE_NO_CARRIER = 0x1b65,

        /// <summary>
        /// Carrier detect has failed or carrier has been dropped due to disconnect.
        /// </summary>
        CTX_MODEM_RESPONSE_NO_DIALTONE = 0x1b66,

        /// <summary>
        /// Busy signal detected at remote site on callback.
        /// </summary>
        CTX_MODEM_RESPONSE_BUSY = 0x1b67,

        /// <summary>
        /// Voice detected at remote site on callback.
        /// </summary>
        CTX_MODEM_RESPONSE_VOICE = 0x1b68,

        /// <summary>
        /// Transport driver error.
        /// </summary>
        CTX_TD_ERROR = 0x1b69,

        /// <summary>
        /// The specified session cannot be found.
        /// </summary>
        CTX_WINSTATION_NOT_FOUND = 0x1b6e,

        /// <summary>
        /// The specified session name is already in use.
        /// </summary>
        CTX_WINSTATION_ALREADY_EXISTS = 0x1b6f,

        /// <summary>
        /// The specified session name is already in use.
        /// </summary>
        CTX_WINSTATION_BUSY = 0x1b70,

        /// <summary>
        /// The specified session name is already in use.
        /// </summary>
        CTX_BAD_VIDEO_MODE = 0x1b71,

        /// <summary>
        /// The application attempted to enable DOS graphics mode. DOS graphics mode is not supported.
        /// </summary>
        CTX_GRAPHICS_INVALID = 0x1b7b,

        /// <summary>
        /// Your interactive logon privilege has been disabled. Please contact your administrator.
        /// </summary>
        CTX_LOGON_DISABLED = 0x1b7d,

        /// <summary>
        /// Your interactive logon privilege has been disabled. Please contact your administrator.
        /// </summary>
        CTX_NOT_CONSOLE = 0x1b7e,

        /// <summary>
        /// The client failed to respond to the server connect message.
        /// </summary>
        CTX_CLIENT_QUERY_TIMEOUT = 0x1b80,

        /// <summary>
        /// Disconnecting the console session is not supported.
        /// </summary>
        CTX_CONSOLE_DISCONNECT = 0x1b81,

        /// <summary>
        /// Reconnecting a disconnected session to the console is not supported.
        /// </summary>
        CTX_CONSOLE_CONNECT = 0x1b82,

        /// <summary>
        /// The request to control another session remotely was denied.
        /// </summary>
        CTX_SHADOW_DENIED = 0x1b84,

        /// <summary>
        /// The requested session access is denied.
        /// </summary>
        CTX_WINSTATION_ACCESS_DENIED = 0x1b85,

        /// <summary>
        /// The specified terminal connection driver is invalid.
        /// </summary>
        CTX_INVALID_WD = 0x1b89,

        /// <summary>
        /// The specified terminal connection driver is invalid.
        /// </summary>
        CTX_SHADOW_INVALID = 0x1b8a,

        /// <summary>
        /// The requested session is not configured to allow remote control.
        /// </summary>
        CTX_SHADOW_DISABLED = 0x1b8b,

        /// <summary>
        /// The requested session is not configured to allow remote control.
        /// </summary>
        CTX_CLIENT_LICENSE_IN_USE = 0x1b8c,

        /// <summary>
        /// The requested session is not configured to allow remote control.
        /// </summary>
        CTX_CLIENT_LICENSE_NOT_SET = 0x1b8d,

        /// <summary>
        /// The requested session is not configured to allow remote control.
        /// </summary>
        CTX_LICENSE_NOT_AVAILABLE = 0x1b8e,

        /// <summary>
        /// The client you are using is not licensed to use this system. Your logon request is denied.
        /// </summary>
        CTX_LICENSE_CLIENT_INVALID = 0x1b8f,

        /// <summary>
        /// The system license has expired. Your logon request is denied.
        /// </summary>
        CTX_LICENSE_EXPIRED = 0x1b90,

        /// <summary>
        /// The system license has expired. Your logon request is denied.
        /// </summary>
        CTX_SHADOW_NOT_RUNNING = 0x1b91,

        /// <summary>
        /// The system license has expired. Your logon request is denied.
        /// </summary>
        CTX_SHADOW_ENDED_BY_MODE_CHANGE = 0x1b92,

        /// <summary>
        /// The system license has expired. Your logon request is denied.
        /// </summary>
        ACTIVATION_COUNT_EXCEEDED = 0x1b93,

        /// <summary>
        /// Remote logins are currently disabled.
        /// </summary>
        CTX_WINSTATIONS_DISABLED = 0x1b94,

        /// <summary>
        /// You do not have the proper encryption level to access this Session.
        /// </summary>
        CTX_ENCRYPTION_LEVEL_REQUIRED = 0x1b95,

        /// <summary>
        /// You do not have the proper encryption level to access this Session.
        /// </summary>
        CTX_SESSION_IN_USE = 0x1b96,

        /// <summary>
        /// You do not have the proper encryption level to access this Session.
        /// </summary>
        CTX_NO_FORCE_LOGOFF = 0x1b97,

        /// <summary>
        /// Unable to log you on because of an account restriction.
        /// </summary>
        CTX_ACCOUNT_RESTRICTION = 0x1b98,

        /// <summary>
        /// Unable to log you on because of an account restriction.
        /// </summary>
        RDprotocoerror = 0x1b99,

        /// <summary>
        /// The Client Drive Mapping Service Has Connected on Terminal Connection.
        /// </summary>
        CTX_CDM_CONNECT = 0x1b9a,

        /// <summary>
        /// The Client Drive Mapping Service Has Disconnected on Terminal Connection.
        /// </summary>
        CTX_CDM_DISCONNECT = 0x1b9b,

        /// <summary>
        /// The Client Drive Mapping Service Has Disconnected on Terminal Connection.
        /// </summary>
        CTX_SECURITY_LAYER_ERROR = 0x1b9c,

        /// <summary>
        /// The target session is incompatible with the current session.
        /// </summary>
        TS_INCOMPATIBLE_SESSIONS = 0x1b9d,

        /// <summary>
        /// The target session is incompatible with the current session.
        /// </summary>
        TS_VIDEO_SUBSYSTEM_ERROR = 0x1b9e,

        /// <summary>
        /// The file replication service API was called incorrectly.
        /// </summary>
        FRS_ERR_INVALID_API_SEQUENCE = 0x1f41,

        /// <summary>
        /// The file replication service cannot be started.
        /// </summary>
        FRS_ERR_STARTING_SERVICE = 0x1f42,

        /// <summary>
        /// The file replication service cannot be stopped.
        /// </summary>
        FRS_ERR_STOPPING_SERVICE = 0x1f43,

        /// <summary>
        /// The file replication service API terminated the request. The event log may have more information.
        /// </summary>
        FRS_ERR_INTERNAaPI = 0x1f44,

        /// <summary>
        /// The file replication service terminated the request. The event log may have more information.
        /// </summary>
        FRS_ERR_INTERNAL = 0x1f45,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_SERVICE_COMM = 0x1f46,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_INSUFFICIENT_PRIV = 0x1f47,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_AUTHENTICATION = 0x1f48,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_PARENT_INSUFFICIENT_PRIV = 0x1f49,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_PARENT_AUTHENTICATION = 0x1f4a,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_CHILD_TO_PARENT_COMM = 0x1f4b,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_PARENT_TO_CHILD_COMM = 0x1f4c,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_SYSVOL_POPULATE = 0x1f4d,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_SYSVOL_POPULATE_TIMEOUT = 0x1f4e,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_SYSVOL_IS_BUSY = 0x1f4f,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FRS_ERR_SYSVOL_DEMOTE = 0x1f50,

        /// <summary>
        /// An error occurred while installing the directory service. For more information, see the event log.
        /// </summary>
        DS_NOT_INSTALLED = 0x2008,

        /// <summary>
        /// The directory service evaluated group memberships locally.
        /// </summary>
        DS_MEMBERSHIP_EVALUATED_LOCALLY = 0x2009,

        /// <summary>
        /// The specified directory service attribute or value does not exist.
        /// </summary>
        DS_NO_ATTRIBUTE_OR_VALUE = 0x200a,

        /// <summary>
        /// The attribute syntax specified to the directory service is invalid.
        /// </summary>
        DS_INVALID_ATTRIBUTE_SYNTAX = 0x200b,

        /// <summary>
        /// The attribute type specified to the directory service is not defined.
        /// </summary>
        DS_ATTRIBUTE_TYPE_UNDEFINED = 0x200c,

        /// <summary>
        /// The specified directory service attribute or value already exists.
        /// </summary>
        DS_ATTRIBUTE_OR_VALUE_EXISTS = 0x200d,

        /// <summary>
        /// The directory service is busy.
        /// </summary>
        DS_BUSY = 0x200e,

        /// <summary>
        /// The directory service is unavailable.
        /// </summary>
        DS_UNAVAILABLE = 0x200f,

        /// <summary>
        /// The directory service was unable to allocate a relative identifier.
        /// </summary>
        DS_NO_RIDS_ALLOCATED = 0x2010,

        /// <summary>
        /// The directory service has exhausted the pool of relative identifiers.
        /// </summary>
        DS_NO_MORE_RIDS = 0x2011,

        /// <summary>
        /// The directory service has exhausted the pool of relative identifiers.
        /// </summary>
        DS_INCORRECT_ROLE_OWNER = 0x2012,

        /// <summary>
        /// The directory service was unable to initialize the subsystem that allocates relative identifiers.
        /// </summary>
        DS_RIDMGR_INIT_ERROR = 0x2013,

        /// <summary>
        /// The directory service was unable to initialize the subsystem that allocates relative identifiers.
        /// </summary>
        DS_OBJ_CLASS_VIOLATION = 0x2014,

        /// <summary>
        /// The directory service can perform the requested operation only on a leaf object.
        /// </summary>
        DS_CANT_ON_NON_LEAF = 0x2015,

        /// <summary>
        /// The directory service cannot perform the requested operation on the RDN attribute of an object.
        /// </summary>
        DS_CANT_ON_RDN = 0x2016,

        /// <summary>
        /// The directory service detected an attempt to modify the object class of an object.
        /// </summary>
        DS_CANT_MOD_OBJ_CLASS = 0x2017,

        /// <summary>
        /// The requested cross-domain move operation could not be performed.
        /// </summary>
        DS_CROSS_DOM_MOVE_ERROR = 0x2018,

        /// <summary>
        /// Unable to contact the global catalog server.
        /// </summary>
        DS_GC_NOT_AVAILABLE = 0x2019,

        /// <summary>
        /// The policy object is shared and can only be modified at the root.
        /// </summary>
        SHARED_POLICY = 0x201a,

        /// <summary>
        /// The policy object does not exist.
        /// </summary>
        POLICY_OBJECT_NOT_FOUND = 0x201b,

        /// <summary>
        /// The requested policy information is only in the directory service.
        /// </summary>
        POLICY_ONLY_IN_DS = 0x201c,

        /// <summary>
        /// A domain controller promotion is currently active.
        /// </summary>
        PROMOTION_ACTIVE = 0x201d,

        /// <summary>
        /// A domain controller promotion is not currently active.
        /// </summary>
        NO_PROMOTION_ACTIVE = 0x201e,

        /// <summary>
        /// An operations error occurred.
        /// </summary>
        DS_OPERATIONS_ERROR = 0x2020,

        /// <summary>
        /// A protocol error occurred.
        /// </summary>
        DS_PROTOCOerror = 0x2021,

        /// <summary>
        /// The time limit for this request was exceeded.
        /// </summary>
        DS_TIMELIMIT_EXCEEDED = 0x2022,

        /// <summary>
        /// The size limit for this request was exceeded.
        /// </summary>
        DS_SIZELIMIT_EXCEEDED = 0x2023,

        /// <summary>
        /// The administrative limit for this request was exceeded.
        /// </summary>
        DS_ADMIN_LIMIT_EXCEEDED = 0x2024,

        /// <summary>
        /// The compare response was false.
        /// </summary>
        DS_COMPARE_FALSE = 0x2025,

        /// <summary>
        /// The compare response was true.
        /// </summary>
        DS_COMPARE_TRUE = 0x2026,

        /// <summary>
        /// The requested authentication method is not supported by the server.
        /// </summary>
        DS_AUTH_METHOD_NOT_SUPPORTED = 0x2027,

        /// <summary>
        /// A more secure authentication method is required for this server.
        /// </summary>
        DS_STRONG_AUTH_REQUIRED = 0x2028,

        /// <summary>
        /// Inappropriate authentication.
        /// </summary>
        DS_INAPPROPRIATE_AUTH = 0x2029,

        /// <summary>
        /// The authentication mechanism is unknown.
        /// </summary>
        DS_AUTH_UNKNOWN = 0x202a,

        /// <summary>
        /// A referral was returned from the server.
        /// </summary>
        DS_REFERRAL = 0x202b,

        /// <summary>
        /// The server does not support the requested critical extension.
        /// </summary>
        DS_UNAVAILABLE_CRIT_EXTENSION = 0x202c,

        /// <summary>
        /// This request requires a secure connection.
        /// </summary>
        DS_CONFIDENTIALITY_REQUIRED = 0x202d,

        /// <summary>
        /// Inappropriate matching.
        /// </summary>
        DS_INAPPROPRIATE_MATCHING = 0x202e,

        /// <summary>
        /// A constraint violation occurred.
        /// </summary>
        DS_CONSTRAINT_VIOLATION = 0x202f,

        /// <summary>
        /// There is no such object on the server.
        /// </summary>
        DS_NO_SUCH_OBJECT = 0x2030,

        /// <summary>
        /// There is an alias problem.
        /// </summary>
        DS_ALIAS_PROBLEM = 0x2031,

        /// <summary>
        /// An invalid dn syntax has been  specified .
        /// </summary>
        DS_INVALID_DN_SYNTAX = 0x2032,

        /// <summary>
        /// The object is a leaf object.
        /// </summary>
        DS_IS_LEAF = 0x2033,

        /// <summary>
        /// There is an alias dereferencing problem.
        /// </summary>
        DS_ALIAS_DEREF_PROBLEM = 0x2034,

        /// <summary>
        /// The server is unwilling to process the request.
        /// </summary>
        DS_UNWILLING_TO_PERFORM = 0x2035,

        /// <summary>
        /// A loop has been detected.
        /// </summary>
        DS_LOOP_DETECT = 0x2036,

        /// <summary>
        /// There is a naming violation.
        /// </summary>
        DS_NAMING_VIOLATION = 0x2037,

        /// <summary>
        /// The result set is too large.
        /// </summary>
        DS_OBJECT_RESULTS_TOO_LARGE = 0x2038,

        /// <summary>
        /// The operation affects multiple DSAs.
        /// </summary>
        DS_AFFECTS_MULTIPLE_DSAS = 0x2039,

        /// <summary>
        /// The server is not operational.
        /// </summary>
        DS_SERVER_DOWN = 0x203a,

        /// <summary>
        /// A local error has occurred.
        /// </summary>
        DS_LOCAerror = 0x203b,

        /// <summary>
        /// An encoding error has occurred.
        /// </summary>
        DS_ENCODING_ERROR = 0x203c,

        /// <summary>
        /// A decoding error has occurred.
        /// </summary>
        DS_DECODING_ERROR = 0x203d,

        /// <summary>
        /// The search filter cannot be recognized.
        /// </summary>
        DS_FILTER_UNKNOWN = 0x203e,

        /// <summary>
        /// One or more parameters are illegal.
        /// </summary>
        DS_PARAM_ERROR = 0x203f,

        /// <summary>
        /// The specified method is not supported.
        /// </summary>
        DS_NOT_SUPPORTED = 0x2040,

        /// <summary>
        /// No results were returned.
        /// </summary>
        DS_NO_RESULTS_RETURNED = 0x2041,

        /// <summary>
        /// The specified control is not supported by the server.
        /// </summary>
        DS_CONTROnot_FOUND = 0x2042,

        /// <summary>
        /// A referral loop was detected by the client.
        /// </summary>
        DS_CLIENT_LOOP = 0x2043,

        /// <summary>
        /// The preset referral limit was exceeded.
        /// </summary>
        DS_REFERRAL_LIMIT_EXCEEDED = 0x2044,

        /// <summary>
        /// The search requires a SORT control.
        /// </summary>
        DS_SORT_CONTROL_MISSING = 0x2045,

        /// <summary>
        /// The search results exceed the offset range  specified .
        /// </summary>
        DS_OFFSET_RANGE_ERROR = 0x2046,

        /// <summary>
        /// The search results exceed the offset range  specified .
        /// </summary>
        DS_RIDMGR_DISABLED = 0x2047,

        /// <summary>
        /// The search results exceed the offset range  specified .
        /// </summary>
        DS_ROOT_MUST_BE_NC = 0x206d,

        /// <summary>
        /// The search results exceed the offset range  specified .
        /// </summary>
        DS_ADD_REPLICA_INHIBITED = 0x206e,

        /// <summary>
        /// A reference to an attribute that is not defined in the schema occurred.
        /// </summary>
        DS_ATT_NOT_DEF_IN_SCHEMA = 0x206f,

        /// <summary>
        /// The maximum size of an object has been exceeded.
        /// </summary>
        DS_MAX_OBJ_SIZE_EXCEEDED = 0x2070,

        /// <summary>
        /// An attempt was made to add an object to the directory with a name that is already in use.
        /// </summary>
        DS_OBJ_STRING_NAME_EXISTS = 0x2071,

        /// <summary>
        /// An attempt was made to add an object of a class that does not have an RDN defined in the schema.
        /// </summary>
        DS_NO_RDN_DEFINED_IN_SCHEMA = 0x2072,

        /// <summary>
        /// An attempt was made to add an object using an RDN that is not the RDN defined in the schema.
        /// </summary>
        DS_RDN_DOESNT_MATCH_SCHEMA = 0x2073,

        /// <summary>
        /// None of the requested attributes were found on the objects.
        /// </summary>
        DS_NO_REQUESTED_ATTS_FOUND = 0x2074,

        /// <summary>
        /// The user buffer is too small.
        /// </summary>
        DS_USER_BUFFER_TO_SMALL = 0x2075,

        /// <summary>
        /// The attribute specified in the operation is not present on the object.
        /// </summary>
        DS_ATT_IS_NOT_ON_OBJ = 0x2076,

        /// <summary>
        /// Illegal modify operation. Some aspect of the modification is not permitted.
        /// </summary>
        DS_ILLEGAL_MOD_OPERATION = 0x2077,

        /// <summary>
        /// The specified object is too large.
        /// </summary>
        DS_OBJ_TOO_LARGE = 0x2078,

        /// <summary>
        /// The specified instance type is not valid.
        /// </summary>
        DS_BAD_INSTANCE_TYPE = 0x2079,

        /// <summary>
        /// The operation must be performed at a master DSA.
        /// </summary>
        DS_MASTERDSA_REQUIRED = 0x207a,

        /// <summary>
        /// The object class attribute must be  specified .
        /// </summary>
        DS_OBJECT_CLASS_REQUIRED = 0x207b,

        /// <summary>
        /// A required attribute is missing.
        /// </summary>
        DS_MISSING_REQUIRED_ATT = 0x207c,

        /// <summary>
        /// An attempt was made to modify an object to include an attribute that is not legal for its class.
        /// </summary>
        DS_ATT_NOT_DEF_FOR_CLASS = 0x207d,

        /// <summary>
        /// The specified attribute is already present on the object.
        /// </summary>
        DS_ATT_ALREADY_EXISTS = 0x207e,

        /// <summary>
        /// The specified attribute is not present, or has no values.
        /// </summary>
        DS_CANT_ADD_ATT_VALUES = 0x2080,

        /// <summary>
        /// Multiple values were specified for an attribute that can have only one value.
        /// </summary>
        DS_SINGLE_VALUE_CONSTRAINT = 0x2081,

        /// <summary>
        /// A value for the attribute was not in the acceptable range of values.
        /// </summary>
        DS_RANGE_CONSTRAINT = 0x2082,

        /// <summary>
        /// The specified value already exists.
        /// </summary>
        DS_ATT_VAaLREADY_EXISTS = 0x2083,

        /// <summary>
        /// The attribute cannot be removed because it is not present on the object.
        /// </summary>
        DS_CANT_REM_MISSING_ATT = 0x2084,

        /// <summary>
        /// The attribute value cannot be removed because it is not present on the object.
        /// </summary>
        DS_CANT_REM_MISSING_ATT_VAL = 0x2085,

        /// <summary>
        /// The specified root object cannot be a subref.
        /// </summary>
        DS_ROOT_CANT_BE_SUBREF = 0x2086,

        /// <summary>
        /// Chaining is not permitted.
        /// </summary>
        DS_NO_CHAINING = 0x2087,

        /// <summary>
        /// Chained evaluation is not permitted.
        /// </summary>
        DS_NO_CHAINED_EVAL = 0x2088,

        /// <summary>
        /// The operation could not be performed because the object's parent is either uninstantiated or deleted.
        /// </summary>
        DS_NO_PARENT_OBJECT = 0x2089,

        /// <summary>
        /// Having a parent that is an alias is not permitted. Aliases are leaf objects.
        /// </summary>
        DS_PARENT_IS_AN_ALIAS = 0x208a,

        /// <summary>
        /// The object and parent must be of the same type, either both masters or both replicas.
        /// </summary>
        DS_CANT_MIX_MASTER_AND_REPS = 0x208b,

        /// <summary>
        /// The object and parent must be of the same type, either both masters or both replicas.
        /// </summary>
        DS_CHILDREN_EXIST = 0x208c,

        /// <summary>
        /// Directory object not found.
        /// </summary>
        DS_OBJ_NOT_FOUND = 0x208d,

        /// <summary>
        /// The aliased object is missing.
        /// </summary>
        DS_ALIASED_OBJ_MISSING = 0x208e,

        /// <summary>
        /// The object name has bad syntax.
        /// </summary>
        DS_BAD_NAME_SYNTAX = 0x208f,

        /// <summary>
        /// It is not permitted for an alias to refer to another alias.
        /// </summary>
        DS_ALIAS_POINTS_TO_ALIAS = 0x2090,

        /// <summary>
        /// The alias cannot be dereferenced.
        /// </summary>
        DS_CANT_DEREF_ALIAS = 0x2091,

        /// <summary>
        /// The operation is out of scope.
        /// </summary>
        DS_OUT_OF_SCOPE = 0x2092,

        /// <summary>
        /// The operation cannot continue because the object is in the process of being removed.
        /// </summary>
        DS_OBJECT_BEING_REMOVED = 0x2093,

        /// <summary>
        /// The DSA object cannot be deleted.
        /// </summary>
        DS_CANT_DELETE_DSA_OBJ = 0x2094,

        /// <summary>
        /// A directory service error has occurred.
        /// </summary>
        DS_GENERIC_ERROR = 0x2095,

        /// <summary>
        /// The operation can only be performed on an internal master DSA object.
        /// </summary>
        DS_DSA_MUST_BE_INT_MASTER = 0x2096,

        /// <summary>
        /// The object must be of class DSA.
        /// </summary>
        DS_CLASS_NOT_DSA = 0x2097,

        /// <summary>
        /// Insufficient access rights to perform the operation.
        /// </summary>
        DS_INSUFF_ACCESS_RIGHTS = 0x2098,

        /// <summary>
        /// The object cannot be added because the parent is not on the list of possible superiors.
        /// </summary>
        DS_ILLEGAL_SUPERIOR = 0x2099,

        /// <summary>
        /// The object cannot be added because the parent is not on the list of possible superiors.
        /// </summary>
        DS_ATTRIBUTE_OWNED_BY_SAM = 0x209a,

        /// <summary>
        /// The name has too many parts.
        /// </summary>
        DS_NAME_TOO_MANY_PARTS = 0x209b,

        /// <summary>
        /// The name is too long.
        /// </summary>
        DS_NAME_TOO_LONG = 0x209c,

        /// <summary>
        /// The name value is too long.
        /// </summary>
        DS_NAME_VALUE_TOO_LONG = 0x209d,

        /// <summary>
        /// The directory service encountered an error parsing a name.
        /// </summary>
        DS_NAME_UNPARSEABLE = 0x209e,

        /// <summary>
        /// The directory service cannot get the attribute type for a name.
        /// </summary>
        DS_NAME_TYPE_UNKNOWN = 0x209f,

        /// <summary>
        /// The name does not identify an object; the name identifies a phantom.
        /// </summary>
        DS_NOT_AN_OBJECT = 0x20a0,

        /// <summary>
        /// The security descriptor is too short.
        /// </summary>
        DS_SEC_DESC_TOO_SHORT = 0x20a1,

        /// <summary>
        /// The security descriptor is invalid.
        /// </summary>
        DS_SEC_DESC_INVALID = 0x20a2,

        /// <summary>
        /// Failed to create name for deleted object.
        /// </summary>
        DS_NO_DELETED_NAME = 0x20a3,

        /// <summary>
        /// The parent of a new subref must exist.
        /// </summary>
        DS_SUBREF_MUST_HAVE_PARENT = 0x20a4,

        /// <summary>
        /// The object must be a naming context.
        /// </summary>
        DS_NCNAME_MUST_BE_NC = 0x20a5,

        /// <summary>
        /// It is not permitted to add an attribute which is owned by the system.
        /// </summary>
        DS_CANT_ADD_SYSTEM_ONLY = 0x20a6,

        /// <summary>
        /// The class of the object must be structural; you cannot instantiate an abstract class.
        /// </summary>
        DS_CLASS_MUST_BE_CONCRETE = 0x20a7,

        /// <summary>
        /// The schema object could not be found.
        /// </summary>
        DS_INVALID_DMD = 0x20a8,

        /// <summary>
        /// A local object with this GUID (dead or alive) already exists.
        /// </summary>
        DS_OBJ_GUID_EXISTS = 0x20a9,

        /// <summary>
        /// The operation cannot be performed on a back link.
        /// </summary>
        DS_NOT_ON_BACKLINK = 0x20aa,

        /// <summary>
        /// The cross reference for the specified naming context could not be found.
        /// </summary>
        DS_NO_CROSSREF_FOR_NC = 0x20ab,

        /// <summary>
        /// The operation could not be performed because the directory service is shutting down.
        /// </summary>
        DS_SHUTTING_DOWN = 0x20ac,

        /// <summary>
        /// The directory service request is invalid.
        /// </summary>
        DS_UNKNOWN_OPERATION = 0x20ad,

        /// <summary>
        /// The role owner attribute could not be read.
        /// </summary>
        DS_INVALID_ROLE_OWNER = 0x20ae,

        /// <summary>
        /// The requested FSMO operation failed. The current FSMO holder could not be contacted.
        /// </summary>
        DS_COULDNT_CONTACT_FSMO = 0x20af,

        /// <summary>
        /// Modification of a DN across a naming context is not permitted.
        /// </summary>
        DS_CROSS_NC_DN_RENAME = 0x20b0,

        /// <summary>
        /// The attribute cannot be modified because it is owned by the system.
        /// </summary>
        DS_CANT_MOD_SYSTEM_ONLY = 0x20b1,

        /// <summary>
        /// Only the replicator can perform this function.
        /// </summary>
        DS_REPLICATOR_ONLY = 0x20b2,

        /// <summary>
        /// The specified class is not defined.
        /// </summary>
        DS_OBJ_CLASS_NOT_DEFINED = 0x20b3,

        /// <summary>
        /// The specified class is not a subclass.
        /// </summary>
        DS_OBJ_CLASS_NOT_SUBCLASS = 0x20b4,

        /// <summary>
        /// The name reference is invalid.
        /// </summary>
        DS_NAME_REFERENCE_INVALID = 0x20b5,

        /// <summary>
        /// A cross reference already exists.
        /// </summary>
        DS_CROSS_REF_EXISTS = 0x20b6,

        /// <summary>
        /// It is not permitted to delete a master cross reference.
        /// </summary>
        DS_CANT_DEL_MASTER_CROSSREF = 0x20b7,

        /// <summary>
        /// Subtree notifications are only supported on NC heads.
        /// </summary>
        DS_SUBTREE_NOTIFY_NOT_NC_HEAD = 0x20b8,

        /// <summary>
        /// Notification filter is too complex.
        /// </summary>
        DS_NOTIFY_FILTER_TOO_COMPLEX = 0x20b9,

        /// <summary>
        /// Schema update failed: duplicate RDN.
        /// </summary>
        DS_DUP_RDN = 0x20ba,

        /// <summary>
        /// Schema update failed: duplicate OID.
        /// </summary>
        DS_DUP_OID = 0x20bb,

        /// <summary>
        /// Schema update failed: duplicate MAPI identifier.
        /// </summary>
        DS_DUP_MAPI_ID = 0x20bc,

        /// <summary>
        /// Schema update failed: duplicate schema-id GUID.
        /// </summary>
        DS_DUP_SCHEMA_ID_GUID = 0x20bd,

        /// <summary>
        /// Schema update failed: duplicate LDAP display name.
        /// </summary>
        DS_DUP_LDAP_DISPLAY_NAME = 0x20be,

        /// <summary>
        /// Schema update failed: range-lower less than range upper.
        /// </summary>
        DS_SEMANTIC_ATT_TEST = 0x20bf,

        /// <summary>
        /// Schema update failed: syntax mismatch.
        /// </summary>
        DS_SYNTAX_MISMATCH = 0x20c0,

        /// <summary>
        /// Schema deletion failed: attribute is used in must-contain.
        /// </summary>
        DS_EXISTS_IN_MUST_HAVE = 0x20c1,

        /// <summary>
        /// Schema deletion failed: attribute is used in may-contain.
        /// </summary>
        DS_EXISTS_IN_MAY_HAVE = 0x20c2,

        /// <summary>
        /// Schema update failed: attribute in may-contain does not exist.
        /// </summary>
        DS_NONEXISTENT_MAY_HAVE = 0x20c3,

        /// <summary>
        /// Schema update failed: attribute in must-contain does not exist.
        /// </summary>
        DS_NONEXISTENT_MUST_HAVE = 0x20c4,

        /// <summary>
        /// Schema update failed: class in aux-class list does not exist or is not an auxiliary class.
        /// </summary>
        DS_AUX_CLS_TEST_FAIL = 0x20c5,

        /// <summary>
        /// Schema update failed: class in poss-superiors does not exist.
        /// </summary>
        DS_NONEXISTENT_POSS_SUP = 0x20c6,

        /// <summary>
        /// Schema update failed: class in subclassof list does not exist or does not satisfy hierarchy rules.
        /// </summary>
        DS_SUB_CLS_TEST_FAIL = 0x20c7,

        /// <summary>
        /// Schema update failed: Rdn-Att-Id has wrong syntax.
        /// </summary>
        DS_BAD_RDN_ATT_ID_SYNTAX = 0x20c8,

        /// <summary>
        /// Schema deletion failed: class is used as auxiliary class.
        /// </summary>
        DS_EXISTS_IN_AUX_CLS = 0x20c9,

        /// <summary>
        /// Schema deletion failed: class is used as sub class.
        /// </summary>
        DS_EXISTS_IN_SUB_CLS = 0x20ca,

        /// <summary>
        /// Schema deletion failed: class is used as poss superior.
        /// </summary>
        DS_EXISTS_IN_POSS_SUP = 0x20cb,

        /// <summary>
        /// Schema update failed in recalculating validation cache.
        /// </summary>
        DS_RECALCSCHEMA_FAILED = 0x20cc,

        /// <summary>
        /// The tree deletion is not finished. The request must be made again to continue deleting the tree.
        /// </summary>
        DS_TREE_DELETE_NOT_FINISHED = 0x20cd,

        /// <summary>
        /// The requested delete operation could not be performed.
        /// </summary>
        DS_CANT_DELETE = 0x20ce,

        /// <summary>
        /// Cannot read the governs class identifier for the schema record.
        /// </summary>
        DS_ATT_SCHEMA_REQ_ID = 0x20cf,

        /// <summary>
        /// The attribute schema has bad syntax.
        /// </summary>
        DS_BAD_ATT_SCHEMA_SYNTAX = 0x20d0,

        /// <summary>
        /// The attribute could not be cached.
        /// </summary>
        DS_CANT_CACHE_ATT = 0x20d1,

        /// <summary>
        /// The class could not be cached.
        /// </summary>
        DS_CANT_CACHE_CLASS = 0x20d2,

        /// <summary>
        /// The attribute could not be removed from the cache.
        /// </summary>
        DS_CANT_REMOVE_ATT_CACHE = 0x20d3,

        /// <summary>
        /// The class could not be removed from the cache.
        /// </summary>
        DS_CANT_REMOVE_CLASS_CACHE = 0x20d4,

        /// <summary>
        /// The distinguished name attribute could not be read.
        /// </summary>
        DS_CANT_RETRIEVE_DN = 0x20d5,

        /// <summary>
        /// The distinguished name attribute could not be read.
        /// </summary>
        DS_MISSING_SUPREF = 0x20d6,

        /// <summary>
        /// The instance type attribute could not be retrieved.
        /// </summary>
        DS_CANT_RETRIEVE_INSTANCE = 0x20d7,

        /// <summary>
        /// An internal error has occurred.
        /// </summary>
        DS_CODE_INCONSISTENCY = 0x20d8,

        /// <summary>
        /// A database error has occurred.
        /// </summary>
        DS_DATABASE_ERROR = 0x20d9,

        /// <summary>
        /// The attribute GOVERNSID is missing.
        /// </summary>
        DS_GOVERNSID_MISSING = 0x20da,

        /// <summary>
        /// An expected attribute is missing.
        /// </summary>
        DS_MISSING_EXPECTED_ATT = 0x20db,

        /// <summary>
        /// The specified naming context is missing a cross reference.
        /// </summary>
        DS_NCNAME_MISSING_CR_REF = 0x20dc,

        /// <summary>
        /// A security checking error has occurred.
        /// </summary>
        DS_SECURITY_CHECKING_ERROR = 0x20dd,

        /// <summary>
        /// The schema is not loaded.
        /// </summary>
        DS_SCHEMA_NOT_LOADED = 0x20de,

        /// <summary>
        /// Schema allocation failed. Please check if the machine is running low on memory.
        /// </summary>
        DS_SCHEMA_ALLOC_FAILED = 0x20df,

        /// <summary>
        /// Failed to obtain the required syntax for the attribute schema.
        /// </summary>
        DS_ATT_SCHEMA_REQ_SYNTAX = 0x20e0,

        /// <summary>
        /// Failed to obtain the required syntax for the attribute schema.
        /// </summary>
        DS_GCVERIFY_ERROR = 0x20e1,

        /// <summary>
        /// The replication operation failed because of a schema mismatch between the servers involved.
        /// </summary>
        DS_DRA_SCHEMA_MISMATCH = 0x20e2,

        /// <summary>
        /// The DSA object could not be found.
        /// </summary>
        DS_CANT_FIND_DSA_OBJ = 0x20e3,

        /// <summary>
        /// The naming context could not be found.
        /// </summary>
        DS_CANT_FIND_EXPECTED_NC = 0x20e4,

        /// <summary>
        /// The naming context could not be found in the cache.
        /// </summary>
        DS_CANT_FIND_NC_IN_CACHE = 0x20e5,

        /// <summary>
        /// The child object could not be retrieved.
        /// </summary>
        DS_CANT_RETRIEVE_CHILD = 0x20e6,

        /// <summary>
        /// The modification was not permitted for security reasons.
        /// </summary>
        DS_SECURITY_ILLEGAL_MODIFY = 0x20e7,

        /// <summary>
        /// The operation cannot replace the hidden record.
        /// </summary>
        DS_CANT_REPLACE_HIDDEN_REC = 0x20e8,

        /// <summary>
        /// The hierarchy file is invalid.
        /// </summary>
        DS_BAD_HIERARCHY_FILE = 0x20e9,

        /// <summary>
        /// The attempt to build the hierarchy table failed.
        /// </summary>
        DS_BUILD_HIERARCHY_TABLE_FAILED = 0x20ea,

        /// <summary>
        /// The directory configuration parameter is missing from the registry.
        /// </summary>
        DS_CONFIG_PARAM_MISSING = 0x20eb,

        /// <summary>
        /// The attempt to count the address book indices failed.
        /// </summary>
        DS_COUNTING_AB_INDICES_FAILED = 0x20ec,

        /// <summary>
        /// The allocation of the hierarchy table failed.
        /// </summary>
        DS_HIERARCHY_TABLE_MALLOC_FAILED = 0x20ed,

        /// <summary>
        /// The directory service encountered an internal failure.
        /// </summary>
        DS_INTERNAL_FAILURE = 0x20ee,

        /// <summary>
        /// The directory service encountered an unknown failure.
        /// </summary>
        DS_UNKNOWN_ERROR = 0x20ef,

        /// <summary>
        /// A root object requires a class of 'top'.
        /// </summary>
        DS_ROOT_REQUIRES_CLASS_TOP = 0x20f0,

        /// <summary>
        /// A root object requires a class of 'top'.
        /// </summary>
        DS_REFUSING_FSMO_ROLES = 0x20f1,

        /// <summary>
        /// A root object requires a class of 'top'.
        /// </summary>
        DS_MISSING_FSMO_SETTINGS = 0x20f2,

        /// <summary>
        /// A root object requires a class of 'top'.
        /// </summary>
        DS_UNABLE_TO_SURRENDER_ROLES = 0x20f3,

        /// <summary>
        /// The replication operation failed.
        /// </summary>
        DS_DRA_GENERIC = 0x20f4,

        /// <summary>
        /// An invalid parameter was specified for this replication operation.
        /// </summary>
        DS_DRA_INVALID_PARAMETER = 0x20f5,

        /// <summary>
        /// The directory service is too busy to complete the replication operation at this time.
        /// </summary>
        DS_DRA_BUSY = 0x20f6,

        /// <summary>
        /// The distinguished name specified for this replication operation is invalid.
        /// </summary>
        DS_DRA_BAD_DN = 0x20f7,

        /// <summary>
        /// The naming context specified for this replication operation is invalid.
        /// </summary>
        DS_DRA_BAD_NC = 0x20f8,

        /// <summary>
        /// The distinguished name specified for this replication operation already exists.
        /// </summary>
        DS_DRA_DN_EXISTS = 0x20f9,

        /// <summary>
        /// The replication system encountered an internal error.
        /// </summary>
        DS_DRA_INTERNAerror = 0x20fa,

        /// <summary>
        /// The replication operation encountered a database inconsistency.
        /// </summary>
        DS_DRA_INCONSISTENT_DIT = 0x20fb,

        /// <summary>
        /// The server specified for this replication operation could not be contacted.
        /// </summary>
        DS_DRA_CONNECTION_FAILED = 0x20fc,

        /// <summary>
        /// The replication operation encountered an object with an invalid instance type.
        /// </summary>
        DS_DRA_BAD_INSTANCE_TYPE = 0x20fd,

        /// <summary>
        /// The replication operation failed to allocate memory.
        /// </summary>
        DS_DRA_OUT_OF_MEM = 0x20fe,

        /// <summary>
        /// The replication operation encountered an error with the mail system.
        /// </summary>
        DS_DRA_MAIL_PROBLEM = 0x20ff,

        /// <summary>
        /// The replication reference information for the target server already exists.
        /// </summary>
        DS_DRA_REF_ALREADY_EXISTS = 0x2100,

        /// <summary>
        /// The replication reference information for the target server does not exist.
        /// </summary>
        DS_DRA_REF_NOT_FOUND = 0x2101,

        /// <summary>
        /// The naming context cannot be removed because it is replicated to another server.
        /// </summary>
        DS_DRA_OBJ_IS_REsource = 0x2102,

        /// <summary>
        /// The replication operation encountered a database error.
        /// </summary>
        DS_DRA_DB_ERROR = 0x2103,

        /// <summary>
        /// The naming context is in the process of being removed or is not replicated from the specified server.
        /// </summary>
        DS_DRA_NO_REPLICA = 0x2104,

        /// <summary>
        /// Replication access was denied.
        /// </summary>
        DS_DRA_ACCESS_DENIED = 0x2105,

        /// <summary>
        /// The requested operation is not supported by this version of the directory service.
        /// </summary>
        DS_DRA_NOT_SUPPORTED = 0x2106,

        /// <summary>
        /// The replication remote procedure call was cancelled.
        /// </summary>
        DS_DRA_RPC_CANCELLED = 0x2107,

        /// <summary>
        /// The source server is currently rejecting replication requests.
        /// </summary>
        DS_DRA_SOURCE_DISABLED = 0x2108,

        /// <summary>
        /// The destination server is currently rejecting replication requests.
        /// </summary>
        DS_DRA_SINK_DISABLED = 0x2109,

        /// <summary>
        /// The replication operation failed due to a collision of object names.
        /// </summary>
        DS_DRA_NAME_COLLISION = 0x210a,

        /// <summary>
        /// The replication source has been reinstalled.
        /// </summary>
        DS_DRA_SOURCE_REINSTALLED = 0x210b,

        /// <summary>
        /// The replication operation failed because a required parent object is missing.
        /// </summary>
        DS_DRA_MISSING_PARENT = 0x210c,

        /// <summary>
        /// The replication operation was preempted.
        /// </summary>
        DS_DRA_PREEMPTED = 0x210d,

        /// <summary>
        /// The replication synchronization attempt was abandoned because of a lack of updates.
        /// </summary>
        DS_DRA_ABANDON_SYNC = 0x210e,

        /// <summary>
        /// The replication operation was terminated because the system is shutting down.
        /// </summary>
        DS_DRA_SHUTDOWN = 0x210f,

        /// <summary>
        /// The replication operation was terminated because the system is shutting down.
        /// </summary>
        DS_DRA_INCOMPATIBLE_PARTIAL_SET = 0x2110,

        /// <summary>
        /// The replication operation was terminated because the system is shutting down.
        /// </summary>
        DS_DRA_SOURCE_IS_PARTIAL_REPLICA = 0x2111,

        /// <summary>
        /// The replication operation was terminated because the system is shutting down.
        /// </summary>
        DS_DRA_EXTN_CONNECTION_FAILED = 0x2112,

        /// <summary>
        /// The replication operation was terminated because the system is shutting down.
        /// </summary>
        DS_INSTALL_SCHEMA_MISMATCH = 0x2113,

        /// <summary>
        /// Schema update failed: An attribute with the same link identifier already exists.
        /// </summary>
        DS_DUP_LINK_ID = 0x2114,

        /// <summary>
        /// Name translation: Generic processing error.
        /// </summary>
        DS_NAME_RESOLVING = 0x2115,

        /// <summary>
        /// Name translation: Could not find the name or insufficient right to see name.
        /// </summary>
        DS_NAME_NOT_FOUND = 0x2116,

        /// <summary>
        /// Name translation: Input name mapped to more than one output name.
        /// </summary>
        DS_NAME_NOT_UNIQUE = 0x2117,

        /// <summary>
        /// Name translation: Input name found, but not the associated output format.
        /// </summary>
        DS_NAME_NO_MAPPING = 0x2118,

        /// <summary>
        /// Name translation: Unable to resolve completely, only the domain was found.
        /// </summary>
        DS_NAME_DOMAIN_ONLY = 0x2119,

        /// <summary>
        /// Name translation: Unable to resolve completely, only the domain was found.
        /// </summary>
        DS_NAME_NO_SYNTACTICAL_MAPPING = 0x211a,

        /// <summary>
        /// Modification of a constructed attribute is not allowed.
        /// </summary>
        DS_CONSTRUCTED_ATT_MOD = 0x211b,

        /// <summary>
        /// The OM-Object-Class specified is incorrect for an attribute with the specified syntax.
        /// </summary>
        DS_WRONG_OM_OBJ_CLASS = 0x211c,

        /// <summary>
        /// The replication request has been posted; waiting for reply.
        /// </summary>
        DS_DRA_REPL_PENDING = 0x211d,

        /// <summary>
        /// The requested operation requires a directory service, and none was available.
        /// </summary>
        DS_DS_REQUIRED = 0x211e,

        /// <summary>
        /// The LDAP display name of the class or attribute contains non-ASCII characters.
        /// </summary>
        DS_INVALID_LDAP_DISPLAY_NAME = 0x211f,

        /// <summary>
        /// The requested search operation is only supported for base searches.
        /// </summary>
        DS_NON_BASE_SEARCH = 0x2120,

        /// <summary>
        /// The search failed to retrieve attributes from the database.
        /// </summary>
        DS_CANT_RETRIEVE_ATTS = 0x2121,

        /// <summary>
        /// The search failed to retrieve attributes from the database.
        /// </summary>
        DS_BACKLINK_WITHOUT_LINK = 0x2122,

        /// <summary>
        /// The search failed to retrieve attributes from the database.
        /// </summary>
        DS_EPOCH_MISMATCH = 0x2123,

        /// <summary>
        /// The search failed to retrieve attributes from the database.
        /// </summary>
        DS_SRC_NAME_MISMATCH = 0x2124,

        /// <summary>
        /// The search failed to retrieve attributes from the database.
        /// </summary>
        DS_SRC_AND_DST_NC_IDENTICAL = 0x2125,

        /// <summary>
        /// The search failed to retrieve attributes from the database.
        /// </summary>
        DS_DST_NC_MISMATCH = 0x2126,

        /// <summary>
        /// Destination of a cross-domain move is not authoritative for the destination naming context.
        /// </summary>
        DS_NOT_AUTHORITIVE_FOR_DST_NC = 0x2127,

        /// <summary>
        /// Destination of a cross-domain move is not authoritative for the destination naming context.
        /// </summary>
        DS_SRC_GUID_MISMATCH = 0x2128,

        /// <summary>
        /// Destination of a cross-domain move is not authoritative for the destination naming context.
        /// </summary>
        DS_CANT_MOVE_DELETED_OBJECT = 0x2129,

        /// <summary>
        /// Another operation which requires exclusive access to the PDC FSMO is already in progress.
        /// </summary>
        DS_PDC_OPERATION_IN_PROGRESS = 0x212a,

        /// <summary>
        /// Another operation which requires exclusive access to the PDC FSMO is already in progress.
        /// </summary>
        DS_CROSS_DOMAIN_CLEANUP_REQD = 0x212b,

        /// <summary>
        /// Another operation which requires exclusive access to the PDC FSMO is already in progress.
        /// </summary>
        DS_ILLEGAL_XDOM_MOVE_OPERATION = 0x212c,

        /// <summary>
        /// Another operation which requires exclusive access to the PDC FSMO is already in progress.
        /// </summary>
        DS_CANT_WITH_ACCT_GROUP_MEMBERSHPS = 0x212d,

        /// <summary>
        /// Another operation which requires exclusive access to the PDC FSMO is already in progress.
        /// </summary>
        DS_NC_MUST_HAVE_NC_PARENT = 0x212e,

        /// <summary>
        /// Another operation which requires exclusive access to the PDC FSMO is already in progress.
        /// </summary>
        DS_CR_IMPOSSIBLE_TO_VALIDATE = 0x212f,

        /// <summary>
        /// Destination domain must be in native mode.
        /// </summary>
        DS_DST_DOMAIN_NOT_NATIVE = 0x2130,

        /// <summary>
        /// Destination domain must be in native mode.
        /// </summary>
        DS_MISSING_INFRASTRUCTURE_CONTAINER = 0x2131,

        /// <summary>
        /// Cross-domain move of non-empty account groups is not allowed.
        /// </summary>
        DS_CANT_MOVE_ACCOUNT_GROUP = 0x2132,

        /// <summary>
        /// Cross-domain move of non-empty resource groups is not allowed.
        /// </summary>
        DS_CANT_MOVE_RESOURCE_GROUP = 0x2133,

        /// <summary>
        /// Cross-domain move of non-empty resource groups is not allowed.
        /// </summary>
        DS_INVALID_SEARCH_FLAG = 0x2134,

        /// <summary>
        /// Tree deletions starting at an object which has an NC head as a descendant are not allowed.
        /// </summary>
        DS_NO_TREE_DELETE_ABOVE_NC = 0x2135,

        /// <summary>
        /// Tree deletions starting at an object which has an NC head as a descendant are not allowed.
        /// </summary>
        DS_COULDNT_LOCK_TREE_FOR_DELETE = 0x2136,

        /// <summary>
        /// Tree deletions starting at an object which has an NC head as a descendant are not allowed.
        /// </summary>
        DS_COULDNT_IDENTIFY_OBJECTS_FOR_TREE_DELETE = 0x2137,

        /// <summary>
        /// Tree deletions starting at an object which has an NC head as a descendant are not allowed.
        /// </summary>
        DS_SAM_INIT_FAILURE = 0x2138,

        /// <summary>
        /// Only an administrator can modify the membership list of an administrative group.
        /// </summary>
        DS_SENSITIVE_GROUP_VIOLATION = 0x2139,

        /// <summary>
        /// Cannot change the primary group ID of a domain controller account.
        /// </summary>
        DS_CANT_MOD_PRIMARYGROUPID = 0x213a,

        /// <summary>
        /// An attempt is made to modify the base schema.
        /// </summary>
        DS_ILLEGAbASE_SCHEMA_MOD = 0x213b,

        /// <summary>
        /// An attempt is made to modify the base schema.
        /// </summary>
        DS_NONSAFE_SCHEMA_CHANGE = 0x213c,

        /// <summary>
        /// Schema update is not allowed on this DC because the DC is not the schema FSMO Role Owner.
        /// </summary>
        DS_SCHEMA_UPDATE_DISALLOWED = 0x213d,

        /// <summary>
        /// Schema update is not allowed on this DC because the DC is not the schema FSMO Role Owner.
        /// </summary>
        DS_CANT_CREATE_UNDER_SCHEMA = 0x213e,

        /// <summary>
        /// Schema update is not allowed on this DC because the DC is not the schema FSMO Role Owner.
        /// </summary>
        DS_INSTALL_NO_SRC_SCH_VERSION = 0x213f,

        /// <summary>
        /// Schema update is not allowed on this DC because the DC is not the schema FSMO Role Owner.
        /// </summary>
        DS_INSTALL_NO_SCH_VERSION_IN_INIFILE = 0x2140,

        /// <summary>
        /// The specified group type is invalid.
        /// </summary>
        DS_INVALID_GROUtype = 0x2141,

        /// <summary>
        /// You cannot nest global groups in a mixed domain if the group is security-enabled.
        /// </summary>
        DS_NO_NEST_GLOBALGROUP_IN_MIXEDDOMAIN = 0x2142,

        /// <summary>
        /// You cannot nest local groups in a mixed domain if the group is security-enabled.
        /// </summary>
        DS_NO_NEST_LOCALGROUP_IN_MIXEDDOMAIN = 0x2143,

        /// <summary>
        /// A global group cannot have a local group as a member.
        /// </summary>
        DS_GLOBAcANT_HAVE_LOCAL_MEMBER = 0x2144,

        /// <summary>
        /// A global group cannot have a universal group as a member.
        /// </summary>
        DS_GLOBAcANT_HAVE_UNIVERSAL_MEMBER = 0x2145,

        /// <summary>
        /// A universal group cannot have a local group as a member.
        /// </summary>
        DS_UNIVERSAcANT_HAVE_LOCAL_MEMBER = 0x2146,

        /// <summary>
        /// A global group cannot have a cross-domain member.
        /// </summary>
        DS_GLOBAcANT_HAVE_CROSSDOMAIN_MEMBER = 0x2147,

        /// <summary>
        /// A local group cannot have another cross domain local group as a member.
        /// </summary>
        DS_LOCAcANT_HAVE_CROSSDOMAIN_LOCAL_MEMBER = 0x2148,

        /// <summary>
        /// A group with primary members cannot change to a security-disabled group.
        /// </summary>
        DS_HAVE_PRIMARY_MEMBERS = 0x2149,

        /// <summary>
        /// The schema cache load failed to convert the string default SD on a class-schema object.
        /// </summary>
        DS_STRING_SD_CONVERSION_FAILED = 0x214a,

        /// <summary>
        /// The schema cache load failed to convert the string default SD on a class-schema object.
        /// </summary>
        DS_NAMING_MASTER_GC = 0x214b,

        /// <summary>
        /// The DSA operation is unable to proceed because of a DNS lookup failure.
        /// </summary>
        DS_DNS_LOOKUP_FAILURE = 0x214c,

        /// <summary>
        /// The DSA operation is unable to proceed because of a DNS lookup failure.
        /// </summary>
        DS_COULDNT_UPDATE_SPNS = 0x214d,

        /// <summary>
        /// The Security Descriptor attribute could not be read.
        /// </summary>
        DS_CANT_RETRIEVE_SD = 0x214e,

        /// <summary>
        /// The object requested was not found, but an object with that key was found.
        /// </summary>
        DS_KEY_NOT_UNIQUE = 0x214f,

        /// <summary>
        /// The object requested was not found, but an object with that key was found.
        /// </summary>
        DS_WRONG_LINKED_ATT_SYNTAX = 0x2150,

        /// <summary>
        /// Security Account Manager needs to get the boot password.
        /// </summary>
        DS_SAM_NEED_BOOTKEY_PASSWORD = 0x2151,

        /// <summary>
        /// Security Account Manager needs to get the boot key from floppy disk.
        /// </summary>
        DS_SAM_NEED_BOOTKEY_FLOPPY = 0x2152,

        /// <summary>
        /// Directory Service cannot start.
        /// </summary>
        DS_CANT_START = 0x2153,

        /// <summary>
        /// Directory Services could not start.
        /// </summary>
        DS_INIT_FAILURE = 0x2154,

        /// <summary>
        /// The connection between client and server requires packet privacy or better.
        /// </summary>
        DS_NO_PKT_PRIVACY_ON_CONNECTION = 0x2155,

        /// <summary>
        /// The source domain may not be in the same forest as destination.
        /// </summary>
        DS_SOURCE_DOMAIN_IN_FOREST = 0x2156,

        /// <summary>
        /// The destination domain must be in the forest.
        /// </summary>
        DS_DESTINATION_DOMAIN_NOT_IN_FOREST = 0x2157,

        /// <summary>
        /// The operation requires that destination domain auditing be enabled.
        /// </summary>
        DS_DESTINATION_AUDITING_NOT_ENABLED = 0x2158,

        /// <summary>
        /// The operation couldn't locate a DC for the source domain.
        /// </summary>
        DS_CANT_FIND_DC_FOR_SRC_DOMAIN = 0x2159,

        /// <summary>
        /// The source object must be a group or user.
        /// </summary>
        DS_SRC_OBJ_NOT_GROUP_OR_USER = 0x215a,

        /// <summary>
        /// The source object's SID already exists in destination forest.
        /// </summary>
        DS_SRC_SID_EXISTS_IN_FOREST = 0x215b,

        /// <summary>
        /// The source and destination object must be of the same type.
        /// </summary>
        DS_SRC_AND_DST_OBJECT_CLASS_MISMATCH = 0x215c,

        /// <summary>
        /// The source and destination object must be of the same type.
        /// </summary>
        SAM_INIT_FAILURE = 0x215d,

        /// <summary>
        /// Schema information could not be included in the replication request.
        /// </summary>
        DS_DRA_SCHEMA_INFO_SHIP = 0x215e,

        /// <summary>
        /// The replication operation could not be completed due to a schema incompatibility.
        /// </summary>
        DS_DRA_SCHEMA_CONFLICT = 0x215f,

        /// <summary>
        /// The replication operation could not be completed due to a previous schema incompatibility.
        /// </summary>
        DS_DRA_EARLIER_SCHEMA_CONFLICT = 0x2160,

        /// <summary>
        /// The replication operation could not be completed due to a previous schema incompatibility.
        /// </summary>
        DS_DRA_OBJ_NC_MISMATCH = 0x2161,

        /// <summary>
        /// The replication operation could not be completed due to a previous schema incompatibility.
        /// </summary>
        DS_NC_STILL_HAS_DSAS = 0x2162,

        /// <summary>
        /// The requested operation can be performed only on a global catalog server.
        /// </summary>
        DS_GC_REQUIRED = 0x2163,

        /// <summary>
        /// A local group can only be a member of other local groups in the same domain.
        /// </summary>
        DS_LOCAL_MEMBER_OF_LOCAL_ONLY = 0x2164,

        /// <summary>
        /// Foreign security principals cannot be members of universal groups.
        /// </summary>
        DS_NO_FPO_IN_UNIVERSAL_GROUPS = 0x2165,

        /// <summary>
        /// The attribute is not allowed to be replicated to the GC because of security reasons.
        /// </summary>
        DS_CANT_ADD_TO_GC = 0x2166,

        /// <summary>
        /// The attribute is not allowed to be replicated to the GC because of security reasons.
        /// </summary>
        DS_NO_CHECKPOINT_WITH_PDC = 0x2167,

        /// <summary>
        /// The operation requires that source domain auditing be enabled.
        /// </summary>
        DS_SOURCE_AUDITING_NOT_ENABLED = 0x2168,

        /// <summary>
        /// Security principal objects can only be created inside domain naming contexts.
        /// </summary>
        DS_CANT_CREATE_IN_NONDOMAIN_NC = 0x2169,

        /// <summary>
        /// Security principal objects can only be created inside domain naming contexts.
        /// </summary>
        DS_INVALID_NAME_FOR_SPN = 0x216a,

        /// <summary>
        /// A Filter was passed that uses constructed attributes.
        /// </summary>
        DS_FILTER_USES_CONTRUCTED_ATTRS = 0x216b,

        /// <summary>
        /// The unicodePwd attribute value must be enclosed in double quotes.
        /// </summary>
        DS_UNICODEPWD_NOT_IN_QUOTES = 0x216c,

        /// <summary>
        /// The unicodePwd attribute value must be enclosed in double quotes.
        /// </summary>
        DS_MACHINE_ACCOUNT_QUOTA_EXCEEDED = 0x216d,

        /// <summary>
        /// For security reasons, the operation must be run on the destination DC.
        /// </summary>
        DS_MUST_BE_RUN_ON_DST_DC = 0x216e,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_SRC_DC_MUST_BE_SP4_OR_GREATER = 0x216f,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_CANT_TREE_DELETE_CRITICAL_OBJ = 0x2170,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_INIT_FAILURE_CONSOLE = 0x2171,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_SAM_INIT_FAILURE_CONSOLE = 0x2172,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_FOREST_VERSION_TOO_HIGH = 0x2173,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_DOMAIN_VERSION_TOO_HIGH = 0x2174,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_FOREST_VERSION_TOO_LOW = 0x2175,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_DOMAIN_VERSION_TOO_LOW = 0x2176,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_INCOMPATIBLE_VERSION = 0x2177,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_LOW_DSA_VERSION = 0x2178,

        /// <summary>
        /// For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        DS_NO_BEHAVIOR_VERSION_IN_MIXEDDOMAIN = 0x2179,

        /// <summary>
        /// The sort order requested is not supported.
        /// </summary>
        DS_NOT_SUPPORTED_SORT_ORDER = 0x217a,

        /// <summary>
        /// The requested name already exists as a unique identifier.
        /// </summary>
        DS_NAME_NOT_UNIQUE_2 = 0x217b,

        /// <summary>
        /// The machine account was created pre-NT4. The account needs to be recreated.
        /// </summary>
        DS_MACHINE_ACCOUNT_CREATED_PRENT4 = 0x217c,

        /// <summary>
        /// The database is out of version store.
        /// </summary>
        DS_OUT_OF_VERSION_STORE = 0x217d,

        /// <summary>
        /// Unable to continue operation because multiple conflicting controls were used.
        /// </summary>
        DS_INCOMPATIBLE_CONTROLS_USED = 0x217e,

        /// <summary>
        /// Unable to find a valid security descriptor reference domain for this partition.
        /// </summary>
        DS_NO_REF_DOMAIN = 0x217f,

        /// <summary>
        /// Schema update failed: The link identifier is reserved.
        /// </summary>
        DS_RESERVED_LINK_ID = 0x2180,

        /// <summary>
        /// Schema update failed: There are no link identifiers available.
        /// </summary>
        DS_LINK_ID_NOT_AVAILABLE = 0x2181,

        /// <summary>
        /// An account group cannot have a universal group as a member.
        /// </summary>
        DS_AG_CANT_HAVE_UNIVERSAL_MEMBER = 0x2182,

        /// <summary>
        /// Rename or move operations on naming context heads or read-only objects are not allowed.
        /// </summary>
        DS_MODIFYDN_DISALLOWED_BY_INSTANCE_TYPE = 0x2183,

        /// <summary>
        /// Move operations on objects in the schema naming context are not allowed.
        /// </summary>
        DS_NO_OBJECT_MOVE_IN_SCHEMA_NC = 0x2184,

        /// <summary>
        /// A system flag has been set on the object and does not allow the object to be moved or renamed.
        /// </summary>
        DS_MODIFYDN_DISALLOWED_BY_FLAG = 0x2185,

        /// <summary>
        /// A system flag has been set on the object and does not allow the object to be moved or renamed.
        /// </summary>
        DS_MODIFYDN_WRONG_GRANDPARENT = 0x2186,

        /// <summary>
        /// Unable to resolve completely, a referral to another forest is generated.
        /// </summary>
        DS_NAME_TRUST_REFERRAL = 0x2187,

        /// <summary>
        /// The requested action is not supported on standard server.
        /// </summary>
        NOT_SUPPORTED_ON_STANDARD_SERVER = 0x2188,

        /// <summary>
        /// The requested action is not supported on standard server.
        /// </summary>
        DS_CANT_ACCESS_REMOTE_PART_OF_AD = 0x2189,

        /// <summary>
        /// The requested action is not supported on standard server.
        /// </summary>
        DS_CR_IMPOSSIBLE_TO_VALIDATE_V2 = 0x218a,

        /// <summary>
        /// The thread limit for this request was exceeded.
        /// </summary>
        DS_THREAD_LIMIT_EXCEEDED = 0x218b,

        /// <summary>
        /// The Global catalog server is not in the closest site.
        /// </summary>
        DS_NOT_CLOSEST = 0x218c,

        /// <summary>
        /// The Global catalog server is not in the closest site.
        /// </summary>
        DS_CANT_DERIVE_SPN_WITHOUT_SERVER_REF = 0x218d,

        /// <summary>
        /// The Directory Service failed to enter single user mode.
        /// </summary>
        DS_SINGLE_USER_MODE_FAILED = 0x218e,

        /// <summary>
        /// The Directory Service cannot parse the script because of a syntax error.
        /// </summary>
        DS_NTDSCRIPT_SYNTAX_ERROR = 0x218f,

        /// <summary>
        /// The Directory Service cannot process the script because of an error.
        /// </summary>
        DS_NTDSCRIPT_PROCESS_ERROR = 0x2190,

        /// <summary>
        /// The Directory Service cannot process the script because of an error.
        /// </summary>
        DS_DIFFERENT_REPL_EPOCHS = 0x2191,

        /// <summary>
        /// The Directory Service cannot process the script because of an error.
        /// </summary>
        DS_DRS_EXTENSIONS_CHANGED = 0x2192,

        /// <summary>
        /// Operation not allowed on a disabled cross ref.
        /// </summary>
        DS_REPLICA_SET_CHANGE_NOT_ALLOWED_ON_DISABLED_CR = 0x2193,

        /// <summary>
        /// Schema update failed: No values for msDS-IntId are available.
        /// </summary>
        DS_NO_MSDS_INTID = 0x2194,

        /// <summary>
        /// Schema update failed: Duplicate msDS-INtId. Retry the operation.
        /// </summary>
        DS_DUP_MSDS_INTID = 0x2195,

        /// <summary>
        /// Schema deletion failed: attribute is used in rDNAttID.
        /// </summary>
        DS_EXISTS_IN_RDNATTID = 0x2196,

        /// <summary>
        /// The directory service failed to authorize the request.
        /// </summary>
        DS_AUTHORIZATION_FAILED = 0x2197,

        /// <summary>
        /// The Directory Service cannot process the script because it is invalid.
        /// </summary>
        DS_INVALID_SCRIPT = 0x2198,

        /// <summary>
        /// The Directory Service cannot process the script because it is invalid.
        /// </summary>
        DS_REMOTE_CROSSREF_OP_FAILED = 0x2199,

        /// <summary>
        /// A cross reference is in use locally with the same name.
        /// </summary>
        DS_CROSS_REF_BUSY = 0x219a,

        /// <summary>
        /// A cross reference is in use locally with the same name.
        /// </summary>
        DS_CANT_DERIVE_SPN_FOR_DELETED_DOMAIN = 0x219b,

        /// <summary>
        /// Writeable NCs prevent this DC from demoting.
        /// </summary>
        DS_CANT_DEMOTE_WITH_WRITEABLE_NC = 0x219c,

        /// <summary>
        /// The requested object has a non-unique identifier and cannot be retrieved.
        /// </summary>
        DS_DUPLICATE_ID_FOUND = 0x219d,

        /// <summary>
        /// The requested object has a non-unique identifier and cannot be retrieved.
        /// </summary>
        DS_INSUFFICIENT_ATTR_TO_CREATE_OBJECT = 0x219e,

        /// <summary>
        /// The group cannot be converted due to attribute restrictions on the requested group type.
        /// </summary>
        DS_GROUP_CONVERSION_ERROR = 0x219f,

        /// <summary>
        /// Cross-domain move of non-empty basic application groups is not allowed.
        /// </summary>
        DS_CANT_MOVE_APP_BASIC_GROUP = 0x21a0,

        /// <summary>
        /// Cross-domain move of non-empty query based application groups is not allowed.
        /// </summary>
        DS_CANT_MOVE_APP_QUERY_GROUP = 0x21a1,

        /// <summary>
        /// Cross-domain move of non-empty query based application groups is not allowed.
        /// </summary>
        DS_ROLE_NOT_VERIFIED = 0x21a2,

        /// <summary>
        /// Cross-domain move of non-empty query based application groups is not allowed.
        /// </summary>
        DS_WKO_CONTAINER_CANNOT_BE_SPECIAL = 0x21a3,

        /// <summary>
        /// Cross-domain move of non-empty query based application groups is not allowed.
        /// </summary>
        DS_DOMAIN_RENAME_IN_PROGRESS = 0x21a4,

        /// <summary>
        /// Cross-domain move of non-empty query based application groups is not allowed.
        /// </summary>
        DS_EXISTING_AD_CHILD_NC = 0x21a5,

        /// <summary>
        /// Cross-domain move of non-empty query based application groups is not allowed.
        /// </summary>
        DS_REPL_LIFETIME_EXCEEDED = 0x21a6,

        /// <summary>
        /// The requested operation is not allowed on an object under the system container.
        /// </summary>
        DS_DISALLOWED_IN_SYSTEM_CONTAINER = 0x21a7,

        /// <summary>
        /// The requested operation is not allowed on an object under the system container.
        /// </summary>
        DS_LDAP_SEND_QUEUE_FULL = 0x21a8,

        /// <summary>
        /// The requested operation is not allowed on an object under the system container.
        /// </summary>
        DS_DRA_OUT_SCHEDULE_WINDOW = 0x21a9,

        /// <summary>
        /// The requested operation is not allowed on an object under the system container.
        /// </summary>
        DS_POLICY_NOT_KNOWN = 0x21aa,

        /// <summary>
        /// The site settings object for the specified site does not exist.
        /// </summary>
        NO_SITE_SETTINGS_OBJECT = 0x21ab,

        /// <summary>
        /// The local account store does not contain secret material for the specified account.
        /// </summary>
        NO_SECRETS = 0x21ac,

        /// <summary>
        /// Could not find a writable domain controller in the domain.
        /// </summary>
        NO_WRITABLE_DC_FOUND = 0x21ad,

        /// <summary>
        /// The server object for the domain controller does not exist.
        /// </summary>
        DS_NO_SERVER_OBJECT = 0x21ae,

        /// <summary>
        /// The NTDS Settings object for the domain controller does not exist.
        /// </summary>
        DS_NO_NTDSA_OBJECT = 0x21af,

        /// <summary>
        /// The requested search operation is not supported for ASQ searches.
        /// </summary>
        DS_NON_ASQ_SEARCH = 0x21b0,

        /// <summary>
        /// A required audit event could not be generated for the operation.
        /// </summary>
        DS_AUDIT_FAILURE = 0x21b1,

        /// <summary>
        /// A required audit event could not be generated for the operation.
        /// </summary>
        DS_INVALID_SEARCH_FLAG_SUBTREE = 0x21b2,

        /// <summary>
        /// A required audit event could not be generated for the operation.
        /// </summary>
        DS_INVALID_SEARCH_FLAG_TUPLE = 0x21b3,

        /// <summary>
        /// The address books are nested too deeply. Failed to build the hierarchy table.
        /// </summary>
        DS_HIERARCHY_TABLE_TOO_DEEP = 0x21b4,

        /// <summary>
        /// The specified up-to-date-ness vector is corrupt.
        /// </summary>
        DS_DRA_CORRUPT_UTD_VECTOR = 0x21b5,

        /// <summary>
        /// The request to replicate secrets is denied.
        /// </summary>
        DS_DRA_SECRETS_DENIED = 0x21b6,

        /// <summary>
        /// Schema update failed: The MAPI identifier is reserved.
        /// </summary>
        DS_RESERVED_MAPI_ID = 0x21b7,

        /// <summary>
        /// Schema update failed: There are no MAPI identifiers available.
        /// </summary>
        DS_MAPI_ID_NOT_AVAILABLE = 0x21b8,

        /// <summary>
        /// Schema update failed: There are no MAPI identifiers available.
        /// </summary>
        DS_DRA_MISSING_KRBTGT_SECRET = 0x21b9,

        /// <summary>
        /// The domain name of the trusted domain already exists in the forest.
        /// </summary>
        DS_DOMAIN_NAME_EXISTS_IN_FOREST = 0x21ba,

        /// <summary>
        /// The flat name of the trusted domain already exists in the forest.
        /// </summary>
        DS_FLAT_NAME_EXISTS_IN_FOREST = 0x21bb,

        /// <summary>
        /// The User Principal Name (UPN) is invalid.
        /// </summary>
        INVALID_USER_PRINCIPAname = 0x21bc,

        /// <summary>
        /// OID mapped groups cannot have members.
        /// </summary>
        DS_OID_MAPPED_GROUP_CANT_HAVE_MEMBERS = 0x21bd,

        /// <summary>
        /// The specified OID cannot be found.
        /// </summary>
        DS_OID_NOT_FOUND = 0x21be,

        /// <summary>
        /// The replication operation failed because the target object referred by a link value is recycled.
        /// </summary>
        DS_DRA_RECYCLED_TARGET = 0x21bf,

        /// <summary>
        /// The replication operation failed because the target object referred by a link value is recycled.
        /// </summary>
        DS_DISALLOWED_NC_REDIRECT = 0x21c0,

        /// <summary>
        /// The functional level of the AD LDS configuration set cannot be lowered to the requested value.
        /// </summary>
        DS_HIGH_ADLDS_FFL = 0x21c1,

        /// <summary>
        /// The functional level of the domain (or forest) cannot be lowered to the requested value.
        /// </summary>
        DS_HIGH_DSA_VERSION = 0x21c2,

        /// <summary>
        /// The functional level of the domain (or forest) cannot be lowered to the requested value.
        /// </summary>
        DS_LOW_ADLDS_FFL = 0x21c3,

        /// <summary>
        /// The functional level of the domain (or forest) cannot be lowered to the requested value.
        /// </summary>
        DOMAIN_SID_SAME_AS_LOCAL_WORKSTATION = 0x21c4,

        /// <summary>
        /// The functional level of the domain (or forest) cannot be lowered to the requested value.
        /// </summary>
        DS_UNDELETE_SAM_VALIDATION_FAILED = 0x21c5,

        /// <summary>
        /// DNS server unable to interpret format.
        /// </summary>
        DNS_RCODE_FORMAT_ERROR = 0x2329,

        /// <summary>
        /// DNS server failure.
        /// </summary>
        DNS_RCODE_SERVER_FAILURE = 0x232a,

        /// <summary>
        /// DNS name does not exist.
        /// </summary>
        DNS_RCODE_NAME_ERROR = 0x232b,

        /// <summary>
        /// DNS request not supported by name server.
        /// </summary>
        DNS_RCODE_NOT_IMPLEMENTED = 0x232c,

        /// <summary>
        /// DNS operation refused.
        /// </summary>
        DNS_RCODE_REFUSED = 0x232d,

        /// <summary>
        /// DNS name that ought not exist, does exist.
        /// </summary>
        DNS_RCODE_YXDOMAIN = 0x232e,

        /// <summary>
        /// DNS RR set that ought not exist, does exist.
        /// </summary>
        DNS_RCODE_YXRRSET = 0x232f,

        /// <summary>
        /// DNS RR set that ought to exist, does not exist.
        /// </summary>
        DNS_RCODE_NXRRSET = 0x2330,

        /// <summary>
        /// DNS server not authoritative for zone.
        /// </summary>
        DNS_RCODE_NOTAUTH = 0x2331,

        /// <summary>
        /// DNS name in update or prereq is not in zone.
        /// </summary>
        DNS_RCODE_NOTZONE = 0x2332,

        /// <summary>
        /// DNS signature failed to verify.
        /// </summary>
        DNS_RCODE_BADSIG = 0x2338,

        /// <summary>
        /// DNS bad key.
        /// </summary>
        DNS_RCODE_BADKEY = 0x2339,

        /// <summary>
        /// DNS signature validity expired.
        /// </summary>
        DNS_RCODE_BADTIME = 0x233a,

        /// <summary>
        /// Only the DNS server acting as the key master for the zone may perform this operation.
        /// </summary>
        DNS_KEYMASTER_REQUIRED = 0x238d,

        /// <summary>
        /// This operation is not allowed on a zone that is signed or has signing keys.
        /// </summary>
        DNS_NOT_ALLOWED_ON_SIGNED_ZONE = 0x238e,

        /// <summary>
        /// This value was also named <strong>DNS_ERROR_INVALID_NSEC3_PARAMETERS</strong>
        /// </summary>
        DNS_NSEC3_INCOMPATIBLE_WITH_RSA_SHA1 = 0x238f,

        /// <summary>
        /// This value was also named <strong>DNS_ERROR_INVALID_NSEC3_PARAMETERS</strong>
        /// </summary>
        DNS_NOT_ENOUGH_SIGNING_KEY_DESCRIPTORS = 0x2390,

        /// <summary>
        /// The specified algorithm is not supported.
        /// </summary>
        DNS_UNSUPPORTED_ALGORITHM = 0x2391,

        /// <summary>
        /// The specified key size is not supported.
        /// </summary>
        DNS_INVALID_KEY_SIZE = 0x2392,

        /// <summary>
        /// The specified key size is not supported.
        /// </summary>
        DNS_SIGNING_KEY_NOT_ACCESSIBLE = 0x2393,

        /// <summary>
        /// The specified key size is not supported.
        /// </summary>
        DNS_KSP_DOES_NOT_SUPPORT_PROTECTION = 0x2394,

        /// <summary>
        /// The specified key size is not supported.
        /// </summary>
        DNS_UNEXPECTED_DATA_PROTECTION_ERROR = 0x2395,

        /// <summary>
        /// The specified key size is not supported.
        /// </summary>
        DNS_UNEXPECTED_CNG_ERROR = 0x2396,

        /// <summary>
        /// The specified key size is not supported.
        /// </summary>
        DNS_UNKNOWN_SIGNING_PARAMETER_VERSION = 0x2397,

        /// <summary>
        /// The specified key service provider cannot be opened by the DNS server.
        /// </summary>
        DNS_KSP_NOT_ACCESSIBLE = 0x2398,

        /// <summary>
        /// The specified key service provider cannot be opened by the DNS server.
        /// </summary>
        DNS_TOO_MANY_SKDS = 0x2399,

        /// <summary>
        /// The specified rollover period is invalid.
        /// </summary>
        DNS_INVALID_ROLLOVER_PERIOD = 0x239a,

        /// <summary>
        /// The specified initial rollover offset is invalid.
        /// </summary>
        DNS_INVALID_INITIAL_ROLLOVER_OFFSET = 0x239b,

        /// <summary>
        /// The specified signing key is already in process of rolling over keys.
        /// </summary>
        DNS_ROLLOVER_IN_PROGRESS = 0x239c,

        /// <summary>
        /// The specified signing key does not have a standby key to revoke.
        /// </summary>
        DNS_STANDBY_KEY_NOT_PRESENT = 0x239d,

        /// <summary>
        /// This operation is not allowed on a zone signing key (ZSK).
        /// </summary>
        DNS_NOT_ALLOWED_ON_ZSK = 0x239e,

        /// <summary>
        /// This operation is not allowed on an active signing key.
        /// </summary>
        DNS_NOT_ALLOWED_ON_ACTIVE_SKD = 0x239f,

        /// <summary>
        /// The specified signing key is already queued for rollover.
        /// </summary>
        DNS_ROLLOVER_ALREADY_QUEUED = 0x23a0,

        /// <summary>
        /// This operation is not allowed on an unsigned zone.
        /// </summary>
        DNS_NOT_ALLOWED_ON_UNSIGNED_ZONE = 0x23a1,

        /// <summary>
        /// This operation is not allowed on an unsigned zone.
        /// </summary>
        DNS_BAD_KEYMASTER = 0x23a2,

        /// <summary>
        /// The specified signature validity period is invalid.
        /// </summary>
        DNS_INVALID_SIGNATURE_VALIDITY_PERIOD = 0x23a3,

        /// <summary>
        /// The specified NSEC3 iteration count is higher than allowed by the minimum key length used in the zone.
        /// </summary>
        DNS_INVALID_NSEC3_ITERATION_COUNT = 0x23a4,

        /// <summary>
        /// The specified NSEC3 iteration count is higher than allowed by the minimum key length used in the zone.
        /// </summary>
        DNS_DNSSEC_IS_DISABLED = 0x23a5,

        /// <summary>
        /// The specified NSEC3 iteration count is higher than allowed by the minimum key length used in the zone.
        /// </summary>
        DNS_INVALID_XML = 0x23a6,

        /// <summary>
        /// The specified NSEC3 iteration count is higher than allowed by the minimum key length used in the zone.
        /// </summary>
        DNS_NO_VALID_TRUST_ANCHORS = 0x23a7,

        /// <summary>
        /// The specified signing key is not waiting for parental DS update.
        /// </summary>
        DNS_ROLLOVER_NOT_POKEABLE = 0x23a8,

        /// <summary>
        /// The specified signing key is not waiting for parental DS update.
        /// </summary>
        DNS_NSEC3_NAME_COLLISION = 0x23a9,

        /// <summary>
        /// NSEC is not compatible with the NSEC3-RSA-SHA-1 algorithm. Choose a different algorithm or use NSEC3.
        /// </summary>
        DNS_NSEC_INCOMPATIBLE_WITH_NSEC3_RSA_SHA1 = 0x23aa,

        /// <summary>
        /// No records found for the specified DNS query.
        /// </summary>
        DNS_INFO_NO_RECORDS = 0x251d,

        /// <summary>
        /// Bad DNS packet.
        /// </summary>
        DNS_BAD_PACKET = 0x251e,

        /// <summary>
        /// No DNS packet.
        /// </summary>
        DNS_NO_PACKET = 0x251f,

        /// <summary>
        /// DNS error, check rcode.
        /// </summary>
        DNS_RCODE = 0x2520,

        /// <summary>
        /// Unsecured DNS packet.
        /// </summary>
        DNS_UNSECURE_PACKET = 0x2521,

        /// <summary>
        /// DNS query request is pending.
        /// </summary>
        DNS_REQUEST_PENDING = 0x2522,

        /// <summary>
        /// Invalid DNS type.
        /// </summary>
        DNS_INVALID_TYPE = 0x254f,

        /// <summary>
        /// Invalid IP address.
        /// </summary>
        DNS_INVALID_Iaddress = 0x2550,

        /// <summary>
        /// Invalid property.
        /// </summary>
        DNS_INVALID_PROPERTY = 0x2551,

        /// <summary>
        /// Try DNS operation again later.
        /// </summary>
        DNS_TRY_AGAIN_LATER = 0x2552,

        /// <summary>
        /// Record for the specified name and type is not unique.
        /// </summary>
        DNS_NOT_UNIQUE = 0x2553,

        /// <summary>
        /// DNS name does not comply with RFC specifications.
        /// </summary>
        DNS_NON_RFC_NAME = 0x2554,

        /// <summary>
        /// DNS name is a fully-qualified DNS name.
        /// </summary>
        DNS_STATUS_FQDN = 0x2555,

        /// <summary>
        /// DNS name is dotted (multi-label).
        /// </summary>
        DNS_STATUS_DOTTED_NAME = 0x2556,

        /// <summary>
        /// DNS name is a single-part name.
        /// </summary>
        DNS_STATUS_SINGLE_PART_NAME = 0x2557,

        /// <summary>
        /// DNS name contains an invalid character.
        /// </summary>
        DNS_INVALID_NAME_CHAR = 0x2558,

        /// <summary>
        /// DNS name is entirely numeric.
        /// </summary>
        DNS_NUMERIC_NAME = 0x2559,

        /// <summary>
        /// The operation requested is not permitted on a DNS root server.
        /// </summary>
        DNS_NOT_ALLOWED_ON_ROOT_SERVER = 0x255a,

        /// <summary>
        /// The operation requested is not permitted on a DNS root server.
        /// </summary>
        DNS_NOT_ALLOWED_UNDER_DELEGATION = 0x255b,

        /// <summary>
        /// The DNS server could not find a set of root hints.
        /// </summary>
        DNS_CANNOT_FIND_ROOT_HINTS = 0x255c,

        /// <summary>
        /// The DNS server found root hints but they were not consistent across all adapters.
        /// </summary>
        DNS_INCONSISTENT_ROOT_HINTS = 0x255d,

        /// <summary>
        /// The specified value is too small for this parameter.
        /// </summary>
        DNS_DWORD_VALUE_TOO_SMALL = 0x255e,

        /// <summary>
        /// The specified value is too large for this parameter.
        /// </summary>
        DNS_DWORD_VALUE_TOO_LARGE = 0x255f,

        /// <summary>
        /// The specified value is too large for this parameter.
        /// </summary>
        DNS_BACKGROUND_LOADING = 0x2560,

        /// <summary>
        /// The operation requested is not permitted on against a DNS server running on a read-only DC.
        /// </summary>
        DNS_NOT_ALLOWED_ON_RODC = 0x2561,

        /// <summary>
        /// No data is allowed to exist underneath a DNAME record.
        /// </summary>
        DNS_NOT_ALLOWED_UNDER_DNAME = 0x2562,

        /// <summary>
        /// This operation requires credentials delegation.
        /// </summary>
        DNS_DELEGATION_REQUIRED = 0x2563,

        /// <summary>
        /// This operation requires credentials delegation.
        /// </summary>
        DNS_INVALID_POLICY_TABLE = 0x2564,

        /// <summary>
        /// DNS zone does not exist.
        /// </summary>
        DNS_ZONE_DOES_NOT_EXIST = 0x2581,

        /// <summary>
        /// DNS zone information not available.
        /// </summary>
        DNS_NO_ZONE_INFO = 0x2582,

        /// <summary>
        /// Invalid operation for DNS zone.
        /// </summary>
        DNS_INVALID_ZONE_OPERATION = 0x2583,

        /// <summary>
        /// Invalid DNS zone configuration.
        /// </summary>
        DNS_ZONE_CONFIGURATION_ERROR = 0x2584,

        /// <summary>
        /// DNS zone has no start of authority (SOA) record.
        /// </summary>
        DNS_ZONE_HAS_NO_SOA_RECORD = 0x2585,

        /// <summary>
        /// DNS zone has no Name Server (NS) record.
        /// </summary>
        DNS_ZONE_HAS_NO_NS_RECORDS = 0x2586,

        /// <summary>
        /// DNS zone is locked.
        /// </summary>
        DNS_ZONE_LOCKED = 0x2587,

        /// <summary>
        /// DNS zone creation failed.
        /// </summary>
        DNS_ZONE_CREATION_FAILED = 0x2588,

        /// <summary>
        /// DNS zone already exists.
        /// </summary>
        DNS_ZONE_ALREADY_EXISTS = 0x2589,

        /// <summary>
        /// DNS automatic zone already exists.
        /// </summary>
        DNS_AUTOZONE_ALREADY_EXISTS = 0x258a,

        /// <summary>
        /// Invalid DNS zone type.
        /// </summary>
        DNS_INVALID_ZONE_TYPE = 0x258b,

        /// <summary>
        /// Secondary DNS zone requires master IP address.
        /// </summary>
        DNS_SECONDARY_REQUIRES_MASTER_IP = 0x258c,

        /// <summary>
        /// DNS zone not secondary.
        /// </summary>
        DNS_ZONE_NOT_SECONDARY = 0x258d,

        /// <summary>
        /// Need secondary IP address.
        /// </summary>
        DNS_NEED_SECONDARY_ADDRESSES = 0x258e,

        /// <summary>
        /// WINS initialization failed.
        /// </summary>
        DNS_WINS_INIT_FAILED = 0x258f,

        /// <summary>
        /// Need WINS servers.
        /// </summary>
        DNS_NEED_WINS_SERVERS = 0x2590,

        /// <summary>
        /// NBTSTAT initialization call failed.
        /// </summary>
        DNS_NBSTAT_INIT_FAILED = 0x2591,

        /// <summary>
        /// Invalid delete of start of authority (SOA).
        /// </summary>
        DNS_SOA_DELETE_INVALID = 0x2592,

        /// <summary>
        /// A conditional forwarding zone already exists for that name.
        /// </summary>
        DNS_FORWARDER_ALREADY_EXISTS = 0x2593,

        /// <summary>
        /// This zone must be configured with one or more master DNS server IP addresses.
        /// </summary>
        DNS_ZONE_REQUIRES_MASTER_IP = 0x2594,

        /// <summary>
        /// The operation cannot be performed because this zone is shut down.
        /// </summary>
        DNS_ZONE_IS_SHUTDOWN = 0x2595,

        /// <summary>
        /// This operation cannot be performed because the zone is currently being signed. Please try again later.
        /// </summary>
        DNS_ZONE_LOCKED_FOR_SIGNING = 0x2596,

        /// <summary>
        /// Primary DNS zone requires datafile.
        /// </summary>
        DNS_PRIMARY_REQUIRES_DATAFILE = 0x25b3,

        /// <summary>
        /// Invalid datafile name for DNS zone.
        /// </summary>
        DNS_INVALID_DATAFILE_NAME = 0x25b4,

        /// <summary>
        /// Failed to open datafile for DNS zone.
        /// </summary>
        DNS_DATAFILE_OPEN_FAILURE = 0x25b5,

        /// <summary>
        /// Failed to write datafile for DNS zone.
        /// </summary>
        DNS_FILE_WRITEBACK_FAILED = 0x25b6,

        /// <summary>
        /// Failure while reading datafile for DNS zone.
        /// </summary>
        DNS_DATAFILE_PARSING = 0x25b7,

        /// <summary>
        /// DNS record does not exist.
        /// </summary>
        DNS_RECORD_DOES_NOT_EXIST = 0x25e5,

        /// <summary>
        /// DNS record format error.
        /// </summary>
        DNS_RECORD_FORMAT = 0x25e6,

        /// <summary>
        /// Node creation failure in DNS.
        /// </summary>
        DNS_NODE_CREATION_FAILED = 0x25e7,

        /// <summary>
        /// Unknown DNS record type.
        /// </summary>
        DNS_UNKNOWN_RECORD_TYPE = 0x25e8,

        /// <summary>
        /// DNS record timed out.
        /// </summary>
        DNS_RECORD_TIMED_OUT = 0x25e9,

        /// <summary>
        /// Name not in DNS zone.
        /// </summary>
        DNS_NAME_NOT_IN_ZONE = 0x25ea,

        /// <summary>
        /// CNAME loop detected.
        /// </summary>
        DNS_CNAME_LOOP = 0x25eb,

        /// <summary>
        /// Node is a CNAME DNS record.
        /// </summary>
        DNS_NODE_IS_CNAME = 0x25ec,

        /// <summary>
        /// A CNAME record already exists for the specified name.
        /// </summary>
        DNS_CNAME_COLLISION = 0x25ed,

        /// <summary>
        /// Record only at DNS zone root.
        /// </summary>
        DNS_RECORD_ONLY_AT_ZONE_ROOT = 0x25ee,

        /// <summary>
        /// DNS record already exists.
        /// </summary>
        DNS_RECORD_ALREADY_EXISTS = 0x25ef,

        /// <summary>
        /// Secondary DNS zone data error.
        /// </summary>
        DNS_SECONDARY_DATA = 0x25f0,

        /// <summary>
        /// Could not create DNS cache data.
        /// </summary>
        DNS_NO_CREATE_CACHE_DATA = 0x25f1,

        /// <summary>
        /// DNS name does not exist.
        /// </summary>
        DNS_NAME_DOES_NOT_EXIST = 0x25f2,

        /// <summary>
        /// Could not create pointer (PTR) record.
        /// </summary>
        DNS_WARNING_PTR_CREATE_FAILED = 0x25f3,

        /// <summary>
        /// DNS domain was undeleted.
        /// </summary>
        DNS_WARNING_DOMAIN_UNDELETED = 0x25f4,

        /// <summary>
        /// The directory service is unavailable.
        /// </summary>
        DNS_DS_UNAVAILABLE = 0x25f5,

        /// <summary>
        /// DNS zone already exists in the directory service.
        /// </summary>
        DNS_DS_ZONE_ALREADY_EXISTS = 0x25f6,

        /// <summary>
        /// DNS server not creating or reading the boot file for the directory service integrated DNS zone.
        /// </summary>
        DNS_NO_BOOTFILE_IF_DS_ZONE = 0x25f7,

        /// <summary>
        /// Node is a DNAME DNS record.
        /// </summary>
        DNS_NODE_IS_DNAME = 0x25f8,

        /// <summary>
        /// A DNAME record already exists for the specified name.
        /// </summary>
        DNS_DNAME_COLLISION = 0x25f9,

        /// <summary>
        /// An alias loop has been detected with either CNAME or DNAME records.
        /// </summary>
        DNS_ALIAS_LOOP = 0x25fa,

        /// <summary>
        /// DNS AXFR (zone transfer) complete.
        /// </summary>
        DNS_INFO_AXFR_COMPLETE = 0x2617,

        /// <summary>
        /// DNS zone transfer failed.
        /// </summary>
        DNS_AXFR = 0x2618,

        /// <summary>
        /// Added local WINS server.
        /// </summary>
        DNS_INFO_ADDED_LOCAL_WINS = 0x2619,

        /// <summary>
        /// Secure update call needs to continue update request.
        /// </summary>
        DNS_STATUS_CONTINUE_NEEDED = 0x2649,

        /// <summary>
        /// TCP/IP network protocol not installed.
        /// </summary>
        DNS_NO_TCPIP = 0x267b,

        /// <summary>
        /// No DNS servers configured for local system.
        /// </summary>
        DNS_NO_DNS_SERVERS = 0x267c,

        /// <summary>
        /// The specified directory partition does not exist.
        /// </summary>
        DNS_DP_DOES_NOT_EXIST = 0x26ad,

        /// <summary>
        /// The specified directory partition already exists.
        /// </summary>
        DNS_DP_ALREADY_EXISTS = 0x26ae,

        /// <summary>
        /// This DNS server is not enlisted in the specified directory partition.
        /// </summary>
        DNS_DP_NOT_ENLISTED = 0x26af,

        /// <summary>
        /// This DNS server is already enlisted in the specified directory partition.
        /// </summary>
        DNS_DP_ALREADY_ENLISTED = 0x26b0,

        /// <summary>
        /// The directory partition is not available at this time. Please wait a few minutes and try again.
        /// </summary>
        DNS_DP_NOT_AVAILABLE = 0x26b1,

        /// <summary>
        /// The directory partition is not available at this time. Please wait a few minutes and try again.
        /// </summary>
        DNS_DP_FSMO_ERROR = 0x26b2,

        /// <summary>
        /// A blocking operation was interrupted by a call to WSACancelBlockingCall.
        /// </summary>
        WSAEINTR = 0x2714,

        /// <summary>
        /// The file handle supplied is not valid.
        /// </summary>
        WSAEBADF = 0x2719,

        /// <summary>
        /// An attempt was made to access a socket in a way forbidden by its access permissions.
        /// </summary>
        WSAEACCES = 0x271d,

        /// <summary>
        /// The system detected an invalid pointer address in attempting to use a pointer argument in a call.
        /// </summary>
        WSAEFAULT = 0x271e,

        /// <summary>
        /// An invalid argument was supplied.
        /// </summary>
        WSAEINVAL = 0x2726,

        /// <summary>
        /// Too many open sockets.
        /// </summary>
        WSAEMFILE = 0x2728,

        /// <summary>
        /// A non-blocking socket operation could not be completed immediately.
        /// </summary>
        WSAEWOULDBLOCK = 0x2733,

        /// <summary>
        /// A blocking operation is currently executing.
        /// </summary>
        WSAEINPROGRESS = 0x2734,

        /// <summary>
        /// An operation was attempted on a non-blocking socket that already had an operation in progress.
        /// </summary>
        WSAEALREADY = 0x2735,

        /// <summary>
        /// An operation was attempted on something that is not a socket.
        /// </summary>
        WSAENOTSOCK = 0x2736,

        /// <summary>
        /// A required address was omitted from an operation on a socket.
        /// </summary>
        WSAEDESTADDRREQ = 0x2737,

        /// <summary>
        /// A required address was omitted from an operation on a socket.
        /// </summary>
        WSAEMSGSIZE = 0x2738,

        /// <summary>
        /// A required address was omitted from an operation on a socket.
        /// </summary>
        WSAEPROTOTYPE = 0x2739,

        /// <summary>
        /// An unknown, invalid, or unsupported option or level was specified in a getsockopt or setsockopt call.
        /// </summary>
        WSAENOPROTOOPT = 0x273a,

        /// <summary>
        /// The requested protocol has not been configured into the system, or no implementation for it exists.
        /// </summary>
        WSAEPROTONOSUPPORT = 0x273b,

        /// <summary>
        /// The support for the specified socket type does not exist in this address family.
        /// </summary>
        WSAESOCKTNOSUPPORT = 0x273c,

        /// <summary>
        /// The attempted operation is not supported for the type of object referenced.
        /// </summary>
        WSAEOPNOTSUPP = 0x273d,

        /// <summary>
        /// The protocol family has not been configured into the system or no implementation for it exists.
        /// </summary>
        WSAEPFNOSUPPORT = 0x273e,

        /// <summary>
        /// An address incompatible with the requested protocol was used.
        /// </summary>
        WSAEAFNOSUPPORT = 0x273f,

        /// <summary>
        /// Only one usage of each socket address (protocol/network address/port) is normally permitted.
        /// </summary>
        WSAEADDRINUSE = 0x2740,

        /// <summary>
        /// The requested address is not valid in its context.
        /// </summary>
        WSAEADDRNOTAVAIL = 0x2741,

        /// <summary>
        /// A socket operation encountered a dead network.
        /// </summary>
        WSAENETDOWN = 0x2742,

        /// <summary>
        /// A socket operation was attempted to an unreachable network.
        /// </summary>
        WSAENETUNREACH = 0x2743,

        /// <summary>
        /// A socket operation was attempted to an unreachable network.
        /// </summary>
        WSAENETRESET = 0x2744,

        /// <summary>
        /// An established connection was aborted by the software in your host machine.
        /// </summary>
        WSAECONNABORTED = 0x2745,

        /// <summary>
        /// An existing connection was forcibly closed by the remote host.
        /// </summary>
        WSAECONNRESET = 0x2746,

        /// <summary>
        /// An existing connection was forcibly closed by the remote host.
        /// </summary>
        WSAENOBUFS = 0x2747,

        /// <summary>
        /// A connect request was made on an already connected socket.
        /// </summary>
        WSAEISCONN = 0x2748,

        /// <summary>
        /// A connect request was made on an already connected socket.
        /// </summary>
        WSAENOTCONN = 0x2749,

        /// <summary>
        /// A connect request was made on an already connected socket.
        /// </summary>
        WSAESHUTDOWN = 0x274a,

        /// <summary>
        /// Too many references to some kernel object.
        /// </summary>
        WSAETOOMANYREFS = 0x274b,

        /// <summary>
        /// Too many references to some kernel object.
        /// </summary>
        WSAETIMEDOUT = 0x274c,

        /// <summary>
        /// No connection could be made because the target machine actively refused it.
        /// </summary>
        WSAECONNREFUSED = 0x274d,

        /// <summary>
        /// Cannot translate name.
        /// </summary>
        WSAELOOP = 0x274e,

        /// <summary>
        /// Name component or name was too long.
        /// </summary>
        WSAENAMETOOLONG = 0x274f,

        /// <summary>
        /// A socket operation failed because the destination host was down.
        /// </summary>
        WSAEHOSTDOWN = 0x2750,

        /// <summary>
        /// A socket operation was attempted to an unreachable host.
        /// </summary>
        WSAEHOSTUNREACH = 0x2751,

        /// <summary>
        /// Cannot remove a directory that is not empty.
        /// </summary>
        WSAENOTEMPTY = 0x2752,

        /// <summary>
        /// Cannot remove a directory that is not empty.
        /// </summary>
        WSAEPROCLIM = 0x2753,

        /// <summary>
        /// Ran out of quota.
        /// </summary>
        WSAEUSERS = 0x2754,

        /// <summary>
        /// Ran out of disk quota.
        /// </summary>
        WSAEDQUOT = 0x2755,

        /// <summary>
        /// File handle reference is no longer available.
        /// </summary>
        WSAESTALE = 0x2756,

        /// <summary>
        /// Item is not available locally.
        /// </summary>
        WSAEREMOTE = 0x2757,

        /// <summary>
        /// Item is not available locally.
        /// </summary>
        WSASYSNOTREADY = 0x276b,

        /// <summary>
        /// The Windows Sockets version requested is not supported.
        /// </summary>
        WSAVERNOTSUPPORTED = 0x276c,

        /// <summary>
        /// Either the application has not called WSAStartup, or WSAStartup failed.
        /// </summary>
        WSANOTINITIALISED = 0x276d,

        /// <summary>
        /// Either the application has not called WSAStartup, or WSAStartup failed.
        /// </summary>
        WSAEDISCON = 0x2775,

        /// <summary>
        /// No more results can be returned by WSALookupServiceNext.
        /// </summary>
        WSAENOMORE = 0x2776,

        /// <summary>
        /// No more results can be returned by WSALookupServiceNext.
        /// </summary>
        WSAECANCELLED = 0x2777,

        /// <summary>
        /// The procedure call table is invalid.
        /// </summary>
        WSAEINVALIDPROCTABLE = 0x2778,

        /// <summary>
        /// The requested service provider is invalid.
        /// </summary>
        WSAEINVALIDPROVIDER = 0x2779,

        /// <summary>
        /// The requested service provider could not be loaded or initialized.
        /// </summary>
        WSAEPROVIDERFAILEDINIT = 0x277a,

        /// <summary>
        /// A system call has failed.
        /// </summary>
        WSASYSCALLFAILURE = 0x277b,

        /// <summary>
        /// No such service is known. The service cannot be found in the specified name space.
        /// </summary>
        WSASERVICE_NOT_FOUND = 0x277c,

        /// <summary>
        /// The specified class was not found.
        /// </summary>
        WSATYPE_NOT_FOUND = 0x277d,

        /// <summary>
        /// No more results can be returned by WSALookupServiceNext.
        /// </summary>
        WSA_E_NO_MORE = 0x277e,

        /// <summary>
        /// No more results can be returned by WSALookupServiceNext.
        /// </summary>
        WSA_E_CANCELLED = 0x277f,

        /// <summary>
        /// A database query failed because it was actively refused.
        /// </summary>
        WSAEREFUSED = 0x2780,

        /// <summary>
        /// No such host is known.
        /// </summary>
        WSAHOST_NOT_FOUND = 0x2af9,

        /// <summary>
        /// No such host is known.
        /// </summary>
        WSATRY_AGAIN = 0x2afa,

        /// <summary>
        /// A non-recoverable error occurred during a database lookup.
        /// </summary>
        WSANO_RECOVERY = 0x2afb,

        /// <summary>
        /// The requested name is valid, but no data of the requested type was found.
        /// </summary>
        WSANO_DATA = 0x2afc,

        /// <summary>
        /// At least one reserve has arrived.
        /// </summary>
        WSA_QOS_RECEIVERS = 0x2afd,

        /// <summary>
        /// At least one path has arrived.
        /// </summary>
        WSA_QOS_SENDERS = 0x2afe,

        /// <summary>
        /// There are no senders.
        /// </summary>
        WSA_QOS_NO_SENDERS = 0x2aff,

        /// <summary>
        /// There are no receivers.
        /// </summary>
        WSA_QOS_NO_RECEIVERS = 0x2b00,

        /// <summary>
        /// Reserve has been confirmed.
        /// </summary>
        WSA_QOS_REQUEST_CONFIRMED = 0x2b01,

        /// <summary>
        /// Error due to lack of resources.
        /// </summary>
        WSA_QOS_ADMISSION_FAILURE = 0x2b02,

        /// <summary>
        /// Rejected for administrative reasons - bad credentials.
        /// </summary>
        WSA_QOS_POLICY_FAILURE = 0x2b03,

        /// <summary>
        /// Unknown or conflicting style.
        /// </summary>
        WSA_QOS_BAD_STYLE = 0x2b04,

        /// <summary>
        /// Problem with some part of the filterspec or providerspecific buffer in general.
        /// </summary>
        WSA_QOS_BAD_OBJECT = 0x2b05,

        /// <summary>
        /// Problem with some part of the flowspec.
        /// </summary>
        WSA_QOS_TRAFFIC_CTRerror = 0x2b06,

        /// <summary>
        /// General QOS error.
        /// </summary>
        WSA_QOS_GENERIC_ERROR = 0x2b07,

        /// <summary>
        /// An invalid or unrecognized service type was found in the flowspec.
        /// </summary>
        WSA_QOS_ESERVICETYPE = 0x2b08,

        /// <summary>
        /// An invalid or inconsistent flowspec was found in the QOS structure.
        /// </summary>
        WSA_QOS_EFLOWSPEC = 0x2b09,

        /// <summary>
        /// Invalid QOS provider-specific buffer.
        /// </summary>
        WSA_QOS_EPROVSPECBUF = 0x2b0a,

        /// <summary>
        /// An invalid QOS filter style was used.
        /// </summary>
        WSA_QOS_EFILTERSTYLE = 0x2b0b,

        /// <summary>
        /// An invalid QOS filter type was used.
        /// </summary>
        WSA_QOS_EFILTERTYPE = 0x2b0c,

        /// <summary>
        /// An incorrect number of QOS FILTERSPECs were specified in the FLOWDESCRIPTOR.
        /// </summary>
        WSA_QOS_EFILTERCOUNT = 0x2b0d,

        /// <summary>
        /// An object with an invalid ObjectLength field was specified in the QOS provider-specific buffer.
        /// </summary>
        WSA_QOS_EOBJLENGTH = 0x2b0e,

        /// <summary>
        /// An incorrect number of flow descriptors was specified in the QOS structure.
        /// </summary>
        WSA_QOS_EFLOWCOUNT = 0x2b0f,

        /// <summary>
        /// An unrecognized object was found in the QOS provider-specific buffer.
        /// </summary>
        WSA_QOS_EUNKOWNPSOBJ = 0x2b10,

        /// <summary>
        /// An invalid policy object was found in the QOS provider-specific buffer.
        /// </summary>
        WSA_QOS_EPOLICYOBJ = 0x2b11,

        /// <summary>
        /// An invalid QOS flow descriptor was found in the flow descriptor list.
        /// </summary>
        WSA_QOS_EFLOWDESC = 0x2b12,

        /// <summary>
        /// An invalid or inconsistent flowspec was found in the QOS provider specific buffer.
        /// </summary>
        WSA_QOS_EPSFLOWSPEC = 0x2b13,

        /// <summary>
        /// An invalid FILTERSPEC was found in the QOS provider-specific buffer.
        /// </summary>
        WSA_QOS_EPSFILTERSPEC = 0x2b14,

        /// <summary>
        /// An invalid shape discard mode object was found in the QOS provider specific buffer.
        /// </summary>
        WSA_QOS_ESDMODEOBJ = 0x2b15,

        /// <summary>
        /// An invalid shaping rate object was found in the QOS provider-specific buffer.
        /// </summary>
        WSA_QOS_ESHAPERATEOBJ = 0x2b16,

        /// <summary>
        /// A reserved policy element was found in the QOS provider-specific buffer.
        /// </summary>
        WSA_QOS_RESERVED_PETYPE = 0x2b17,

        /// <summary>
        /// No such host is known securely.
        /// </summary>
        WSA_SECURE_HOST_NOT_FOUND = 0x2b18,

        /// <summary>
        ///
        /// </summary>
        INTERNET__ = 0x2ee0,

        /// <summary>
        /// The specified quick mode policy already exists.
        /// </summary>
        IPSEC_QM_POLICY_EXISTS = 0x32c8,

        /// <summary>
        /// The specified quick mode policy was not found.
        /// </summary>
        IPSEC_QM_POLICY_NOT_FOUND = 0x32c9,

        /// <summary>
        /// The specified quick mode policy is being used.
        /// </summary>
        IPSEC_QM_POLICY_IN_USE = 0x32ca,

        /// <summary>
        /// The specified main mode policy already exists.
        /// </summary>
        IPSEC_MM_POLICY_EXISTS = 0x32cb,

        /// <summary>
        /// The specified main mode policy was not found.
        /// </summary>
        IPSEC_MM_POLICY_NOT_FOUND = 0x32cc,

        /// <summary>
        /// The specified main mode policy is being used.
        /// </summary>
        IPSEC_MM_POLICY_IN_USE = 0x32cd,

        /// <summary>
        /// The specified main mode filter already exists.
        /// </summary>
        IPSEC_MM_FILTER_EXISTS = 0x32ce,

        /// <summary>
        /// The specified main mode filter was not found.
        /// </summary>
        IPSEC_MM_FILTER_NOT_FOUND = 0x32cf,

        /// <summary>
        /// The specified transport mode filter already exists.
        /// </summary>
        IPSEC_TRANSPORT_FILTER_EXISTS = 0x32d0,

        /// <summary>
        /// The specified transport mode filter does not exist.
        /// </summary>
        IPSEC_TRANSPORT_FILTER_NOT_FOUND = 0x32d1,

        /// <summary>
        /// The specified main mode authentication list exists.
        /// </summary>
        IPSEC_MM_AUTH_EXISTS = 0x32d2,

        /// <summary>
        /// The specified main mode authentication list was not found.
        /// </summary>
        IPSEC_MM_AUTH_NOT_FOUND = 0x32d3,

        /// <summary>
        /// The specified main mode authentication list is being used.
        /// </summary>
        IPSEC_MM_AUTH_IN_USE = 0x32d4,

        /// <summary>
        /// The specified default main mode policy was not found.
        /// </summary>
        IPSEC_DEFAULT_MM_POLICY_NOT_FOUND = 0x32d5,

        /// <summary>
        /// The specified default main mode authentication list was not found.
        /// </summary>
        IPSEC_DEFAULT_MM_AUTH_NOT_FOUND = 0x32d6,

        /// <summary>
        /// The specified default quick mode policy was not found.
        /// </summary>
        IPSEC_DEFAULT_QM_POLICY_NOT_FOUND = 0x32d7,

        /// <summary>
        /// The specified tunnel mode filter exists.
        /// </summary>
        IPSEC_TUNNEL_FILTER_EXISTS = 0x32d8,

        /// <summary>
        /// The specified tunnel mode filter was not found.
        /// </summary>
        IPSEC_TUNNEL_FILTER_NOT_FOUND = 0x32d9,

        /// <summary>
        /// The Main Mode filter is pending deletion.
        /// </summary>
        IPSEC_MM_FILTER_PENDING_DELETION = 0x32da,

        /// <summary>
        /// The transport filter is pending deletion.
        /// </summary>
        IPSEC_TRANSPORT_FILTER_PENDING_DELETION = 0x32db,

        /// <summary>
        /// The tunnel filter is pending deletion.
        /// </summary>
        IPSEC_TUNNEL_FILTER_PENDING_DELETION = 0x32dc,

        /// <summary>
        /// The Main Mode policy is pending deletion.
        /// </summary>
        IPSEC_MM_POLICY_PENDING_DELETION = 0x32dd,

        /// <summary>
        /// The Main Mode authentication bundle is pending deletion.
        /// </summary>
        IPSEC_MM_AUTH_PENDING_DELETION = 0x32de,

        /// <summary>
        /// The Quick Mode policy is pending deletion.
        /// </summary>
        IPSEC_QM_POLICY_PENDING_DELETION = 0x32df,

        /// <summary>
        /// The Main Mode policy was successfully added, but some of the requested offers are not supported.
        /// </summary>
        WARNING_IPSEC_MM_POLICY_PRUNED = 0x32e0,

        /// <summary>
        /// The Quick Mode policy was successfully added, but some of the requested offers are not supported.
        /// </summary>
        WARNING_IPSEC_QM_POLICY_PRUNED = 0x32e1,

        /// <summary>
        /// ERROR_IPSEC_IKE_NEG_STATUS_BEGIN
        /// </summary>
        IPSEC_IKE_NEG_STATUS_BEGIN = 0x35e8,

        /// <summary>
        /// IKE authentication credentials are unacceptable.
        /// </summary>
        IPSEC_IKE_AUTH_FAIL = 0x35e9,

        /// <summary>
        /// IKE security attributes are unacceptable.
        /// </summary>
        IPSEC_IKE_ATTRIB_FAIL = 0x35ea,

        /// <summary>
        /// IKE Negotiation in progress.
        /// </summary>
        IPSEC_IKE_NEGOTIATION_PENDING = 0x35eb,

        /// <summary>
        /// General processing error.
        /// </summary>
        IPSEC_IKE_GENERAL_PROCESSING_ERROR = 0x35ec,

        /// <summary>
        /// Negotiation timed out.
        /// </summary>
        IPSEC_IKE_TIMED_OUT = 0x35ed,

        /// <summary>
        /// Negotiation timed out.
        /// </summary>
        IPSEC_IKE_NO_CERT = 0x35ee,

        /// <summary>
        /// IKE SA deleted by peer before establishment completed.
        /// </summary>
        IPSEC_IKE_SA_DELETED = 0x35ef,

        /// <summary>
        /// IKE SA deleted before establishment completed.
        /// </summary>
        IPSEC_IKE_SA_REAPED = 0x35f0,

        /// <summary>
        /// Negotiation request sat in Queue too long.
        /// </summary>
        IPSEC_IKE_MM_ACQUIRE_DROP = 0x35f1,

        /// <summary>
        /// Negotiation request sat in Queue too long.
        /// </summary>
        IPSEC_IKE_QM_ACQUIRE_DROP = 0x35f2,

        /// <summary>
        /// Negotiation request sat in Queue too long.
        /// </summary>
        IPSEC_IKE_QUEUE_DROP_MM = 0x35f3,

        /// <summary>
        /// Negotiation request sat in Queue too long.
        /// </summary>
        IPSEC_IKE_QUEUE_DROP_NO_MM = 0x35f4,

        /// <summary>
        /// No response from peer.
        /// </summary>
        IPSEC_IKE_DROP_NO_RESPONSE = 0x35f5,

        /// <summary>
        /// Negotiation took too long.
        /// </summary>
        IPSEC_IKE_MM_DELAY_DROP = 0x35f6,

        /// <summary>
        /// Negotiation took too long.
        /// </summary>
        IPSEC_IKE_QM_DELAY_DROP = 0x35f7,

        /// <summary>
        /// Unknown error occurred.
        /// </summary>
        IPSEC_IKE_ERROR = 0x35f8,

        /// <summary>
        /// Certificate Revocation Check failed.
        /// </summary>
        IPSEC_IKE_CRL_FAILED = 0x35f9,

        /// <summary>
        /// Invalid certificate key usage.
        /// </summary>
        IPSEC_IKE_INVALID_KEY_USAGE = 0x35fa,

        /// <summary>
        /// Invalid certificate type.
        /// </summary>
        IPSEC_IKE_INVALID_CERT_TYPE = 0x35fb,

        /// <summary>
        /// Invalid certificate type.
        /// </summary>
        IPSEC_IKE_NO_PRIVATE_KEY = 0x35fc,

        /// <summary>
        /// Simultaneous rekeys were detected.
        /// </summary>
        IPSEC_IKE_SIMULTANEOUS_REKEY = 0x35fd,

        /// <summary>
        /// Failure in Diffie-Hellman computation.
        /// </summary>
        IPSEC_IKE_DH_FAIL = 0x35fe,

        /// <summary>
        /// Don't know how to process critical payload.
        /// </summary>
        IPSEC_IKE_CRITICAL_PAYLOAD_NOT_RECOGNIZED = 0x35ff,

        /// <summary>
        /// Invalid header.
        /// </summary>
        IPSEC_IKE_INVALID_HEADER = 0x3600,

        /// <summary>
        /// No policy configured.
        /// </summary>
        IPSEC_IKE_NO_POLICY = 0x3601,

        /// <summary>
        /// Failed to verify signature.
        /// </summary>
        IPSEC_IKE_INVALID_SIGNATURE = 0x3602,

        /// <summary>
        /// Failed to authenticate using Kerberos.
        /// </summary>
        IPSEC_IKE_KERBEROS_ERROR = 0x3603,

        /// <summary>
        /// Peer's certificate did not have a public key.
        /// </summary>
        IPSEC_IKE_NO_PUBLIC_KEY = 0x3604,

        /// <summary>
        /// Error processing error payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR = 0x3605,

        /// <summary>
        /// Error processing SA payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_SA = 0x3606,

        /// <summary>
        /// Error processing Proposal payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_PROP = 0x3607,

        /// <summary>
        /// Error processing Transform payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_TRANS = 0x3608,

        /// <summary>
        /// Error processing KE payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_KE = 0x3609,

        /// <summary>
        /// Error processing ID payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_ID = 0x360a,

        /// <summary>
        /// Error processing Cert payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_CERT = 0x360b,

        /// <summary>
        /// Error processing Certificate Request payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_CERT_REQ = 0x360c,

        /// <summary>
        /// Error processing Hash payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_HASH = 0x360d,

        /// <summary>
        /// Error processing Signature payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_SIG = 0x360e,

        /// <summary>
        /// Error processing Nonce payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_NONCE = 0x360f,

        /// <summary>
        /// Error processing Notify payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_NOTIFY = 0x3610,

        /// <summary>
        /// Error processing Delete Payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_DELETE = 0x3611,

        /// <summary>
        /// Error processing VendorId payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_VENDOR = 0x3612,

        /// <summary>
        /// Invalid payload received.
        /// </summary>
        IPSEC_IKE_INVALID_PAYLOAD = 0x3613,

        /// <summary>
        /// Soft SA loaded.
        /// </summary>
        IPSEC_IKE_LOAD_SOFT_SA = 0x3614,

        /// <summary>
        /// Soft SA torn down.
        /// </summary>
        IPSEC_IKE_SOFT_SA_TORN_DOWN = 0x3615,

        /// <summary>
        /// Invalid cookie received.
        /// </summary>
        IPSEC_IKE_INVALID_COOKIE = 0x3616,

        /// <summary>
        /// Peer failed to send valid machine certificate.
        /// </summary>
        IPSEC_IKE_NO_PEER_CERT = 0x3617,

        /// <summary>
        /// Certification Revocation check of peer's certificate failed.
        /// </summary>
        IPSEC_IKE_PEER_CRL_FAILED = 0x3618,

        /// <summary>
        /// New policy invalidated SAs formed with old policy.
        /// </summary>
        IPSEC_IKE_POLICY_CHANGE = 0x3619,

        /// <summary>
        /// There is no available Main Mode IKE policy.
        /// </summary>
        IPSEC_IKE_NO_MM_POLICY = 0x361a,

        /// <summary>
        /// Failed to enabled TCB privilege.
        /// </summary>
        IPSEC_IKE_NOTCBPRIV = 0x361b,

        /// <summary>
        /// Failed to load SECURITY.DLL.
        /// </summary>
        IPSEC_IKE_SECLOADFAIL = 0x361c,

        /// <summary>
        /// Failed to obtain security function table dispatch address from SSPI.
        /// </summary>
        IPSEC_IKE_FAILSSPINIT = 0x361d,

        /// <summary>
        /// Failed to query Kerberos package to obtain max token size.
        /// </summary>
        IPSEC_IKE_FAILQUERYSSP = 0x361e,

        /// <summary>
        /// Failed to query Kerberos package to obtain max token size.
        /// </summary>
        IPSEC_IKE_SRVACQFAIL = 0x361f,

        /// <summary>
        /// Failed to query Kerberos package to obtain max token size.
        /// </summary>
        IPSEC_IKE_SRVQUERYCRED = 0x3620,

        /// <summary>
        /// Failed to query Kerberos package to obtain max token size.
        /// </summary>
        IPSEC_IKE_GETSPIFAIL = 0x3621,

        /// <summary>
        /// Given filter is invalid.
        /// </summary>
        IPSEC_IKE_INVALID_FILTER = 0x3622,

        /// <summary>
        /// Memory allocation failed.
        /// </summary>
        IPSEC_IKE_OUT_OF_MEMORY = 0x3623,

        /// <summary>
        /// Memory allocation failed.
        /// </summary>
        IPSEC_IKE_ADD_UPDATE_KEY_FAILED = 0x3624,

        /// <summary>
        /// Invalid policy.
        /// </summary>
        IPSEC_IKE_INVALID_POLICY = 0x3625,

        /// <summary>
        /// Invalid DOI.
        /// </summary>
        IPSEC_IKE_UNKNOWN_DOI = 0x3626,

        /// <summary>
        /// Invalid situation.
        /// </summary>
        IPSEC_IKE_INVALID_SITUATION = 0x3627,

        /// <summary>
        /// Diffie-Hellman failure.
        /// </summary>
        IPSEC_IKE_DH_FAILURE = 0x3628,

        /// <summary>
        /// Invalid Diffie-Hellman group.
        /// </summary>
        IPSEC_IKE_INVALID_GROUP = 0x3629,

        /// <summary>
        /// Error encrypting payload.
        /// </summary>
        IPSEC_IKE_ENCRYPT = 0x362a,

        /// <summary>
        /// Error decrypting payload.
        /// </summary>
        IPSEC_IKE_DECRYPT = 0x362b,

        /// <summary>
        /// Policy match error.
        /// </summary>
        IPSEC_IKE_POLICY_MATCH = 0x362c,

        /// <summary>
        /// Unsupported ID.
        /// </summary>
        IPSEC_IKE_UNSUPPORTED_ID = 0x362d,

        /// <summary>
        /// Hash verification failed.
        /// </summary>
        IPSEC_IKE_INVALID_HASH = 0x362e,

        /// <summary>
        /// Invalid hash algorithm.
        /// </summary>
        IPSEC_IKE_INVALID_HASH_ALG = 0x362f,

        /// <summary>
        /// Invalid hash size.
        /// </summary>
        IPSEC_IKE_INVALID_HASH_SIZE = 0x3630,

        /// <summary>
        /// Invalid encryption algorithm.
        /// </summary>
        IPSEC_IKE_INVALID_ENCRYPT_ALG = 0x3631,

        /// <summary>
        /// Invalid authentication algorithm.
        /// </summary>
        IPSEC_IKE_INVALID_AUTH_ALG = 0x3632,

        /// <summary>
        /// Invalid certificate signature.
        /// </summary>
        IPSEC_IKE_INVALID_SIG = 0x3633,

        /// <summary>
        /// Load failed.
        /// </summary>
        IPSEC_IKE_LOAD_FAILED = 0x3634,

        /// <summary>
        /// Deleted via RPC call.
        /// </summary>
        IPSEC_IKE_RPC_DELETE = 0x3635,

        /// <summary>
        /// Temporary state created to perform reinitialization. This is not a real failure.
        /// </summary>
        IPSEC_IKE_BENIGN_REINIT = 0x3636,

        /// <summary>
        /// Temporary state created to perform reinitialization. This is not a real failure.
        /// </summary>
        IPSEC_IKE_INVALID_RESPONDER_LIFETIME_NOTIFY = 0x3637,

        /// <summary>
        /// The recipient cannot handle version of IKE specified in the header.
        /// </summary>
        IPSEC_IKE_INVALID_MAJOR_VERSION = 0x3638,

        /// <summary>
        /// Key length in certificate is too small for configured security requirements.
        /// </summary>
        IPSEC_IKE_INVALID_CERT_KEYLEN = 0x3639,

        /// <summary>
        /// Max number of established MM SAs to peer exceeded.
        /// </summary>
        IPSEC_IKE_MM_LIMIT = 0x363a,

        /// <summary>
        /// IKE received a policy that disables negotiation.
        /// </summary>
        IPSEC_IKE_NEGOTIATION_DISABLED = 0x363b,

        /// <summary>
        /// Reached maximum quick mode limit for the main mode. New main mode will be started.
        /// </summary>
        IPSEC_IKE_QM_LIMIT = 0x363c,

        /// <summary>
        /// Main mode SA lifetime expired or peer sent a main mode delete.
        /// </summary>
        IPSEC_IKE_MM_EXPIRED = 0x363d,

        /// <summary>
        /// Main mode SA assumed to be invalid because peer stopped responding.
        /// </summary>
        IPSEC_IKE_PEER_MM_ASSUMED_INVALID = 0x363e,

        /// <summary>
        /// Certificate doesn't chain to a trusted root in IPsec policy.
        /// </summary>
        IPSEC_IKE_CERT_CHAIN_POLICY_MISMATCH = 0x363f,

        /// <summary>
        /// Received unexpected message ID.
        /// </summary>
        IPSEC_IKE_UNEXPECTED_MESSAGE_ID = 0x3640,

        /// <summary>
        /// Received invalid authentication offers.
        /// </summary>
        IPSEC_IKE_INVALID_AUTH_PAYLOAD = 0x3641,

        /// <summary>
        /// Sent DoS cookie notify to initiator.
        /// </summary>
        IPSEC_IKE_DOS_COOKIE_SENT = 0x3642,

        /// <summary>
        /// IKE service is shutting down.
        /// </summary>
        IPSEC_IKE_SHUTTING_DOWN = 0x3643,

        /// <summary>
        /// Could not verify binding between CGA address and certificate.
        /// </summary>
        IPSEC_IKE_CGA_AUTH_FAILED = 0x3644,

        /// <summary>
        /// Error processing NatOA payload.
        /// </summary>
        IPSEC_IKE_PROCESS_ERR_NATOA = 0x3645,

        /// <summary>
        /// Parameters of the main mode are invalid for this quick mode.
        /// </summary>
        IPSEC_IKE_INVALID_MM_FOR_QM = 0x3646,

        /// <summary>
        /// Quick mode SA was expired by IPsec driver.
        /// </summary>
        IPSEC_IKE_QM_EXPIRED = 0x3647,

        /// <summary>
        /// Too many dynamically added IKEEXT filters were detected.
        /// </summary>
        IPSEC_IKE_TOO_MANY_FILTERS = 0x3648,

        /// <summary>
        /// ERROR_IPSEC_IKE_NEG_STATUS_END
        /// </summary>
        IPSEC_IKE_NEG_STATUS_END = 0x3649,

        /// <summary>
        /// NAP reauth succeeded and must delete the dummy NAP IKEv2 tunnel.
        /// </summary>
        IPSEC_IKE_KILL_DUMMY_NAP_TUNNEL = 0x364a,

        /// <summary>
        /// Error in assigning inner IP address to initiator in tunnel mode.
        /// </summary>
        IPSEC_IKE_INNER_IP_ASSIGNMENT_FAILURE = 0x364b,

        /// <summary>
        /// Require configuration payload missing.
        /// </summary>
        IPSEC_IKE_REQUIRE_CP_PAYLOAD_MISSING = 0x364c,

        /// <summary>
        /// A negotiation running as the security principle who issued the connection is in progress.
        /// </summary>
        IPSEC_KEY_MODULE_IMPERSONATION_NEGOTIATION_PENDING = 0x364d,

        /// <summary>
        /// SA was deleted due to IKEv1/AuthIP co-existence suppress check.
        /// </summary>
        IPSEC_IKE_COEXISTENCE_SUPPRESS = 0x364e,

        /// <summary>
        /// Incoming SA request was dropped due to peer IP address rate limiting.
        /// </summary>
        IPSEC_IKE_RATELIMIT_DROP = 0x364f,

        /// <summary>
        /// Peer does not support MOBIKE.
        /// </summary>
        IPSEC_IKE_PEER_DOESNT_SUPPORT_MOBIKE = 0x3650,

        /// <summary>
        /// SA establishment is not authorized.
        /// </summary>
        IPSEC_IKE_AUTHORIZATION_FAILURE = 0x3651,

        /// <summary>
        /// SA establishment is not authorized because there is not a sufficiently strong PKINIT-based credential.
        /// </summary>
        IPSEC_IKE_STRONG_CRED_AUTHORIZATION_FAILURE = 0x3652,

        /// <summary>
        /// SA establishment is not authorized because there is not a sufficiently strong PKINIT-based credential.
        /// </summary>
        IPSEC_IKE_AUTHORIZATION_FAILURE_WITH_OPTIONAL_RETRY = 0x3653,

        /// <summary>
        /// SA establishment is not authorized because there is not a sufficiently strong PKINIT-based credential.
        /// </summary>
        IPSEC_IKE_STRONG_CRED_AUTHORIZATION_AND_CERTMAP_FAILURE = 0x3654,

        /// <summary>
        /// ERROR_IPSEC_IKE_NEG_STATUS_EXTENDED_END
        /// </summary>
        IPSEC_IKE_NEG_STATUS_EXTENDED_END = 0x3655,

        /// <summary>
        /// The SPI in the packet does not match a valid IPsec SA.
        /// </summary>
        IPSEC_BAD_SPI = 0x3656,

        /// <summary>
        /// Packet was received on an IPsec SA whose lifetime has expired.
        /// </summary>
        IPSEC_SA_LIFETIME_EXPIRED = 0x3657,

        /// <summary>
        /// Packet was received on an IPsec SA that does not match the packet characteristics.
        /// </summary>
        IPSEC_WRONG_SA = 0x3658,

        /// <summary>
        /// Packet sequence number replay check failed.
        /// </summary>
        IPSEC_REPLAY_CHECK_FAILED = 0x3659,

        /// <summary>
        /// IPsec header and/or trailer in the packet is invalid.
        /// </summary>
        IPSEC_INVALID_PACKET = 0x365a,

        /// <summary>
        /// IPsec integrity check failed.
        /// </summary>
        IPSEC_INTEGRITY_CHECK_FAILED = 0x365b,

        /// <summary>
        /// IPsec dropped a clear text packet.
        /// </summary>
        IPSEC_CLEAR_TEXT_DROP = 0x365c,

        /// <summary>
        /// IPsec dropped an incoming ESP packet in authenticated firewall mode. This drop is benign.
        /// </summary>
        IPSEC_AUTH_FIREWALL_DROP = 0x365d,

        /// <summary>
        /// IPsec dropped a packet due to DoS throttling.
        /// </summary>
        IPSEC_THROTTLE_DROP = 0x365e,

        /// <summary>
        /// IPsec DoS Protection matched an explicit block rule.
        /// </summary>
        IPSEC_DOSP_BLOCK = 0x3665,

        /// <summary>
        /// IPsec DoS Protection received an IPsec specific multicast packet which is not allowed.
        /// </summary>
        IPSEC_DOSP_RECEIVED_MULTICAST = 0x3666,

        /// <summary>
        /// IPsec DoS Protection received an incorrectly formatted packet.
        /// </summary>
        IPSEC_DOSP_INVALID_PACKET = 0x3667,

        /// <summary>
        /// IPsec DoS Protection failed to look up state.
        /// </summary>
        IPSEC_DOSP_STATE_LOOKUP_FAILED = 0x3668,

        /// <summary>
        /// IPsec DoS Protection failed to look up state.
        /// </summary>
        IPSEC_DOSP_MAX_ENTRIES = 0x3669,

        /// <summary>
        /// IPsec DoS Protection failed to look up state.
        /// </summary>
        IPSEC_DOSkeyMOD_NOT_ALLOWED = 0x366a,

        /// <summary>
        /// IPsec DoS Protection has not been enabled.
        /// </summary>
        IPSEC_DOSP_NOT_INSTALLED = 0x366b,

        /// <summary>
        /// IPsec DoS Protection has not been enabled.
        /// </summary>
        IPSEC_DOSP_MAX_PER_IP_RATELIMIT_QUEUES = 0x366c,

        /// <summary>
        /// The requested section was not present in the activation context.
        /// </summary>
        SXS_SECTION_NOT_FOUND = 0x36b0,

        /// <summary>
        /// The requested section was not present in the activation context.
        /// </summary>
        SXS_CANT_GEN_ACTCTX = 0x36b1,

        /// <summary>
        /// The application binding data format is invalid.
        /// </summary>
        SXS_INVALID_ACTCTXDATA_FORMAT = 0x36b2,

        /// <summary>
        /// The referenced assembly is not installed on your system.
        /// </summary>
        SXS_ASSEMBLY_NOT_FOUND = 0x36b3,

        /// <summary>
        /// The manifest file does not begin with the required tag and format information.
        /// </summary>
        SXS_MANIFEST_FORMAT_ERROR = 0x36b4,

        /// <summary>
        /// The manifest file contains one or more syntax errors.
        /// </summary>
        SXS_MANIFEST_PARSE_ERROR = 0x36b5,

        /// <summary>
        /// The application attempted to activate a disabled activation context.
        /// </summary>
        SXS_ACTIVATION_CONTEXT_DISABLED = 0x36b6,

        /// <summary>
        /// The requested lookup key was not found in any active activation context.
        /// </summary>
        SXS_KEY_NOT_FOUND = 0x36b7,

        /// <summary>
        /// The requested lookup key was not found in any active activation context.
        /// </summary>
        SXS_VERSION_CONFLICT = 0x36b8,

        /// <summary>
        /// The type requested activation context section does not match the query API used.
        /// </summary>
        SXS_WRONG_SECTION_TYPE = 0x36b9,

        /// <summary>
        /// The type requested activation context section does not match the query API used.
        /// </summary>
        SXS_THREAD_QUERIES_DISABLED = 0x36ba,

        /// <summary>
        /// The type requested activation context section does not match the query API used.
        /// </summary>
        SXS_PROCESS_DEFAULT_ALREADY_SET = 0x36bb,

        /// <summary>
        /// The encoding group identifier specified is not recognized.
        /// </summary>
        SXS_UNKNOWN_ENCODING_GROUP = 0x36bc,

        /// <summary>
        /// The encoding requested is not recognized.
        /// </summary>
        SXS_UNKNOWN_ENCODING = 0x36bd,

        /// <summary>
        /// The manifest contains a reference to an invalid URI.
        /// </summary>
        SXS_INVALID_XMnameSPACE_URI = 0x36be,

        /// <summary>
        /// The application manifest contains a reference to a dependent assembly which is not installed.
        /// </summary>
        SXS_ROOT_MANIFEST_DEPENDENCY_NOT_INSTALLED = 0x36bf,

        /// <summary>
        /// The application manifest contains a reference to a dependent assembly which is not installed.
        /// </summary>
        SXS_LEAF_MANIFEST_DEPENDENCY_NOT_INSTALLED = 0x36c0,

        /// <summary>
        /// The manifest contains an attribute for the assembly identity which is not valid.
        /// </summary>
        SXS_INVALID_ASSEMBLY_IDENTITY_ATTRIBUTE = 0x36c1,

        /// <summary>
        /// The manifest is missing the required default namespace specification on the assembly element.
        /// </summary>
        SXS_MANIFEST_MISSING_REQUIRED_DEFAULT_NAMESPACE = 0x36c2,

        /// <summary>
        /// The manifest is missing the required default namespace specification on the assembly element.
        /// </summary>
        SXS_MANIFEST_INVALID_REQUIRED_DEFAULT_NAMESPACE = 0x36c3,

        /// <summary>
        /// The private manifest probed has crossed a path with an unsupported reparse point.
        /// </summary>
        SXS_PRIVATE_MANIFEST_CROSS_PATH_WITH_REPARSE_POINT = 0x36c4,

        /// <summary>
        /// The private manifest probed has crossed a path with an unsupported reparse point.
        /// </summary>
        SXS_DUPLICATE_DLname = 0x36c5,

        /// <summary>
        /// The private manifest probed has crossed a path with an unsupported reparse point.
        /// </summary>
        SXS_DUPLICATE_WINDOWCLASS_NAME = 0x36c6,

        /// <summary>
        /// The private manifest probed has crossed a path with an unsupported reparse point.
        /// </summary>
        SXS_DUPLICATE_CLSID = 0x36c7,

        /// <summary>
        /// The private manifest probed has crossed a path with an unsupported reparse point.
        /// </summary>
        SXS_DUPLICATE_IID = 0x36c8,

        /// <summary>
        /// The private manifest probed has crossed a path with an unsupported reparse point.
        /// </summary>
        SXS_DUPLICATE_TLBID = 0x36c9,

        /// <summary>
        /// The private manifest probed has crossed a path with an unsupported reparse point.
        /// </summary>
        SXS_DUPLICATE_PROGID = 0x36ca,

        /// <summary>
        /// The private manifest probed has crossed a path with an unsupported reparse point.
        /// </summary>
        SXS_DUPLICATE_ASSEMBLY_NAME = 0x36cb,

        /// <summary>
        /// A component's file does not match the verification information present in the component manifest.
        /// </summary>
        SXS_FILE_HASH_MISMATCH = 0x36cc,

        /// <summary>
        /// The policy manifest contains one or more syntax errors.
        /// </summary>
        SXS_POLICY_PARSE_ERROR = 0x36cd,

        /// <summary>
        /// Manifest Parse Error : A string literal was expected, but no opening quote character was found.
        /// </summary>
        SXS_XML_E_MISSINGQUOTE = 0x36ce,

        /// <summary>
        /// Manifest Parse Error : Incorrect syntax was used in a comment.
        /// </summary>
        SXS_XML_E_COMMENTSYNTAX = 0x36cf,

        /// <summary>
        /// Manifest Parse Error : A name was started with an invalid character.
        /// </summary>
        SXS_XML_E_BADSTARTNAMECHAR = 0x36d0,

        /// <summary>
        /// Manifest Parse Error : A name contained an invalid character.
        /// </summary>
        SXS_XML_E_BADNAMECHAR = 0x36d1,

        /// <summary>
        /// Manifest Parse Error : A string literal contained an invalid character.
        /// </summary>
        SXS_XML_E_BADCHARINSTRING = 0x36d2,

        /// <summary>
        /// Manifest Parse Error : Invalid syntax for an xml declaration.
        /// </summary>
        SXS_XML_E_XMLDECLSYNTAX = 0x36d3,

        /// <summary>
        /// Manifest Parse Error : An Invalid character was found in text content.
        /// </summary>
        SXS_XML_E_BADCHARDATA = 0x36d4,

        /// <summary>
        /// Manifest Parse Error : Required white space was missing.
        /// </summary>
        SXS_XML_E_MISSINGWHITESPACE = 0x36d5,

        /// <summary>
        /// Manifest Parse Error : The character '&gt;' was expected.
        /// </summary>
        SXS_XML_E_EXPECTINGTAGEND = 0x36d6,

        /// <summary>
        /// Manifest Parse Error : A semi colon character was expected.
        /// </summary>
        SXS_XML_E_MISSINGSEMICOLON = 0x36d7,

        /// <summary>
        /// Manifest Parse Error : Unbalanced parentheses.
        /// </summary>
        SXS_XML_E_UNBALANCEDPAREN = 0x36d8,

        /// <summary>
        /// Manifest Parse Error : Internal error.
        /// </summary>
        SXS_XML_E_INTERNALERROR = 0x36d9,

        /// <summary>
        /// Manifest Parse Error : Whitespace is not allowed at this location.
        /// </summary>
        SXS_XML_E_UNEXPECTED_WHITESPACE = 0x36da,

        /// <summary>
        /// Manifest Parse Error : End of file reached in invalid state for current encoding.
        /// </summary>
        SXS_XML_E_INCOMPLETE_ENCODING = 0x36db,

        /// <summary>
        /// Manifest Parse Error : Missing parenthesis.
        /// </summary>
        SXS_XML_E_MISSING_PAREN = 0x36dc,

        /// <summary>
        /// Manifest Parse Error : A single or double closing quote character (\' or \") is missing.
        /// </summary>
        SXS_XML_E_EXPECTINGCLOSEQUOTE = 0x36dd,

        /// <summary>
        /// Manifest Parse Error : Multiple colons are not allowed in a name.
        /// </summary>
        SXS_XML_E_MULTIPLE_COLONS = 0x36de,

        /// <summary>
        /// Manifest Parse Error : Invalid character for decimal digit.
        /// </summary>
        SXS_XML_E_INVALID_DECIMAL = 0x36df,

        /// <summary>
        /// Manifest Parse Error : Invalid character for hexadecimal digit.
        /// </summary>
        SXS_XML_E_INVALID_HEXIDECIMAL = 0x36e0,

        /// <summary>
        /// Manifest Parse Error : Invalid unicode character value for this platform.
        /// </summary>
        SXS_XML_E_INVALID_UNICODE = 0x36e1,

        /// <summary>
        /// Manifest Parse Error : Expecting whitespace or '?'.
        /// </summary>
        SXS_XML_E_WHITESPACEORQUESTIONMARK = 0x36e2,

        /// <summary>
        /// Manifest Parse Error : End tag was not expected at this location.
        /// </summary>
        SXS_XML_E_UNEXPECTEDENDTAG = 0x36e3,

        /// <summary>
        /// Manifest Parse Error : The following tags were not closed: %1.
        /// </summary>
        SXS_XML_E_UNCLOSEDTAG = 0x36e4,

        /// <summary>
        /// Manifest Parse Error : Duplicate attribute.
        /// </summary>
        SXS_XML_E_DUPLICATEATTRIBUTE = 0x36e5,

        /// <summary>
        /// Manifest Parse Error : Only one top level element is allowed in an XML document.
        /// </summary>
        SXS_XML_E_MULTIPLEROOTS = 0x36e6,

        /// <summary>
        /// Manifest Parse Error : Invalid at the top level of the document.
        /// </summary>
        SXS_XML_E_INVALIDATROOTLEVEL = 0x36e7,

        /// <summary>
        /// Manifest Parse Error : Invalid xml declaration.
        /// </summary>
        SXS_XML_E_BADXMLDECL = 0x36e8,

        /// <summary>
        /// Manifest Parse Error : XML document must have a top level element.
        /// </summary>
        SXS_XML_E_MISSINGROOT = 0x36e9,

        /// <summary>
        /// Manifest Parse Error : Unexpected end of file.
        /// </summary>
        SXS_XML_E_UNEXPECTEDEOF = 0x36ea,

        /// <summary>
        /// Manifest Parse Error : Unexpected end of file.
        /// </summary>
        SXS_XML_E_BADPEREFINSUBSET = 0x36eb,

        /// <summary>
        /// Manifest Parse Error : Element was not closed.
        /// </summary>
        SXS_XML_E_UNCLOSEDSTARTTAG = 0x36ec,

        /// <summary>
        /// Manifest Parse Error : End element was missing the character '&gt;'.
        /// </summary>
        SXS_XML_E_UNCLOSEDENDTAG = 0x36ed,

        /// <summary>
        /// Manifest Parse Error : A string literal was not closed.
        /// </summary>
        SXS_XML_E_UNCLOSEDSTRING = 0x36ee,

        /// <summary>
        /// Manifest Parse Error : A comment was not closed.
        /// </summary>
        SXS_XML_E_UNCLOSEDCOMMENT = 0x36ef,

        /// <summary>
        /// Manifest Parse Error : A declaration was not closed.
        /// </summary>
        SXS_XML_E_UNCLOSEDDECL = 0x36f0,

        /// <summary>
        /// Manifest Parse Error : A CDATA section was not closed.
        /// </summary>
        SXS_XML_E_UNCLOSEDCDATA = 0x36f1,

        /// <summary>
        /// Manifest Parse Error : The namespace prefix is not allowed to start with the reserved string "xml".
        /// </summary>
        SXS_XML_E_RESERVEDNAMESPACE = 0x36f2,

        /// <summary>
        /// Manifest Parse Error : System does not support the specified encoding.
        /// </summary>
        SXS_XML_E_INVALIDENCODING = 0x36f3,

        /// <summary>
        /// Manifest Parse Error : Switch from current encoding to specified encoding not supported.
        /// </summary>
        SXS_XML_E_INVALIDSWITCH = 0x36f4,

        /// <summary>
        /// Manifest Parse Error : The name 'xml' is reserved and must be lower case.
        /// </summary>
        SXS_XML_E_BADXMLCASE = 0x36f5,

        /// <summary>
        /// Manifest Parse Error : The standalone attribute must have the value 'yes' or 'no'.
        /// </summary>
        SXS_XML_E_INVALID_STANDALONE = 0x36f6,

        /// <summary>
        /// Manifest Parse Error : The standalone attribute cannot be used in external entities.
        /// </summary>
        SXS_XML_E_UNEXPECTED_STANDALONE = 0x36f7,

        /// <summary>
        /// Manifest Parse Error : Invalid version number.
        /// </summary>
        SXS_XML_E_INVALID_VERSION = 0x36f8,

        /// <summary>
        /// Manifest Parse Error : Missing equals sign between attribute and attribute value.
        /// </summary>
        SXS_XML_E_MISSINGEQUALS = 0x36f9,

        /// <summary>
        /// Assembly Protection Error : Unable to recover the specified assembly.
        /// </summary>
        SXS_PROTECTION_RECOVERY_FAILED = 0x36fa,

        /// <summary>
        /// Assembly Protection Error : The public key for an assembly was too short to be allowed.
        /// </summary>
        SXS_PROTECTION_PUBLIC_KEY_TOO_SHORT = 0x36fb,

        /// <summary>
        /// Assembly Protection Error : The public key for an assembly was too short to be allowed.
        /// </summary>
        SXS_PROTECTION_CATALOG_NOT_VALID = 0x36fc,

        /// <summary>
        /// An HRESULT could not be translated to a corresponding Win32 error code.
        /// </summary>
        SXS_UNTRANSLATABLE_HRESULT = 0x36fd,

        /// <summary>
        /// Assembly Protection Error : The catalog for an assembly is missing.
        /// </summary>
        SXS_PROTECTION_CATALOG_FILE_MISSING = 0x36fe,

        /// <summary>
        /// The supplied assembly identity is missing one or more attributes which must be present in this context.
        /// </summary>
        SXS_MISSING_ASSEMBLY_IDENTITY_ATTRIBUTE = 0x36ff,

        /// <summary>
        /// The supplied assembly identity is missing one or more attributes which must be present in this context.
        /// </summary>
        SXS_INVALID_ASSEMBLY_IDENTITY_ATTRIBUTE_NAME = 0x3700,

        /// <summary>
        /// The referenced assembly could not be found.
        /// </summary>
        SXS_ASSEMBLY_MISSING = 0x3701,

        /// <summary>
        /// The activation context activation stack for the running thread of execution is corrupt.
        /// </summary>
        SXS_CORRUPT_ACTIVATION_STACK = 0x3702,

        /// <summary>
        /// The application isolation metadata for this process or thread has become corrupt.
        /// </summary>
        SXS_CORRUPTION = 0x3703,

        /// <summary>
        /// The activation context being deactivated is not the most recently activated one.
        /// </summary>
        SXS_EARLY_DEACTIVATION = 0x3704,

        /// <summary>
        /// The activation context being deactivated is not active for the current thread of execution.
        /// </summary>
        SXS_INVALID_DEACTIVATION = 0x3705,

        /// <summary>
        /// The activation context being deactivated has already been deactivated.
        /// </summary>
        SXS_MULTIPLE_DEACTIVATION = 0x3706,

        /// <summary>
        /// A component used by the isolation facility has requested to terminate the process.
        /// </summary>
        SXS_PROCESS_TERMINATION_REQUESTED = 0x3707,

        /// <summary>
        /// A kernel mode component is releasing a reference on an activation context.
        /// </summary>
        SXS_RELEASE_ACTIVATION_CONTEXT = 0x3708,

        /// <summary>
        /// The activation context of system default assembly could not be generated.
        /// </summary>
        SXS_SYSTEM_DEFAULT_ACTIVATION_CONTEXT_EMPTY = 0x3709,

        /// <summary>
        /// The value of an attribute in an identity is not within the legal range.
        /// </summary>
        SXS_INVALID_IDENTITY_ATTRIBUTE_VALUE = 0x370a,

        /// <summary>
        /// The name of an attribute in an identity is not within the legal range.
        /// </summary>
        SXS_INVALID_IDENTITY_ATTRIBUTE_NAME = 0x370b,

        /// <summary>
        /// An identity contains two definitions for the same attribute.
        /// </summary>
        SXS_IDENTITY_DUPLICATE_ATTRIBUTE = 0x370c,

        /// <summary>
        /// An identity contains two definitions for the same attribute.
        /// </summary>
        SXS_IDENTITY_PARSE_ERROR = 0x370d,

        /// <summary>
        /// An identity contains two definitions for the same attribute.
        /// </summary>
        MALFORMED_SUBSTITUTION_STRING = 0x370e,

        /// <summary>
        /// The public key token does not correspond to the public key  specified .
        /// </summary>
        SXS_INCORRECT_PUBLIC_KEY_TOKEN = 0x370f,

        /// <summary>
        /// A substitution string had no mapping.
        /// </summary>
        UNMAPPED_SUBSTITUTION_STRING = 0x3710,

        /// <summary>
        /// The component must be locked before making the request.
        /// </summary>
        SXS_ASSEMBLY_NOT_LOCKED = 0x3711,

        /// <summary>
        /// The component store has been corrupted.
        /// </summary>
        SXS_COMPONENT_STORE_CORRUPT = 0x3712,

        /// <summary>
        /// An advanced installer failed during setup or servicing.
        /// </summary>
        ADVANCED_INSTALLER_FAILED = 0x3713,

        /// <summary>
        /// The character encoding in the XML declaration did not match the encoding used in the document.
        /// </summary>
        XML_ENCODING_MISMATCH = 0x3714,

        /// <summary>
        /// The identities of the manifests are identical but their contents are different.
        /// </summary>
        SXS_MANIFEST_IDENTITY_SAME_BUT_CONTENTS_DIFFERENT = 0x3715,

        /// <summary>
        /// The component identities are different.
        /// </summary>
        SXS_IDENTITIES_DIFFERENT = 0x3716,

        /// <summary>
        /// The assembly is not a deployment.
        /// </summary>
        SXS_ASSEMBLY_IS_NOT_A_DEPLOYMENT = 0x3717,

        /// <summary>
        /// The file is not a part of the assembly.
        /// </summary>
        SXS_FILE_NOT_PART_OF_ASSEMBLY = 0x3718,

        /// <summary>
        /// The size of the manifest exceeds the maximum allowed.
        /// </summary>
        SXS_MANIFEST_TOO_BIG = 0x3719,

        /// <summary>
        /// The setting is not registered.
        /// </summary>
        SXS_SETTING_NOT_REGISTERED = 0x371a,

        /// <summary>
        /// One or more required members of the transaction are not present.
        /// </summary>
        SXS_TRANSACTION_CLOSURE_INCOMPLETE = 0x371b,

        /// <summary>
        /// The SMI primitive installer failed during setup or servicing.
        /// </summary>
        SMI_PRIMITIVE_INSTALLER_FAILED = 0x371c,

        /// <summary>
        /// A generic command executable returned a result that indicates failure.
        /// </summary>
        GENERIC_COMMAND_FAILED = 0x371d,

        /// <summary>
        /// A component is missing file verification information in its manifest.
        /// </summary>
        SXS_FILE_HASH_MISSING = 0x371e,

        /// <summary>
        /// The specified channel path is invalid.
        /// </summary>
        EVT_INVALID_CHANNEpath = 0x3a98,

        /// <summary>
        /// The specified query is invalid.
        /// </summary>
        EVT_INVALID_QUERY = 0x3a99,

        /// <summary>
        /// The publisher metadata cannot be found in the resource.
        /// </summary>
        EVT_PUBLISHER_METADATA_NOT_FOUND = 0x3a9a,

        /// <summary>
        /// The template for an event definition cannot be found in the resource (error = %1).
        /// </summary>
        EVT_EVENT_TEMPLATE_NOT_FOUND = 0x3a9b,

        /// <summary>
        /// The specified publisher name is invalid.
        /// </summary>
        EVT_INVALID_PUBLISHER_NAME = 0x3a9c,

        /// <summary>
        /// The specified publisher name is invalid.
        /// </summary>
        EVT_INVALID_EVENT_DATA = 0x3a9d,

        /// <summary>
        /// The specified channel could not be found. Check channel configuration.
        /// </summary>
        EVT_CHANNEnot_FOUND = 0x3a9f,

        /// <summary>
        /// The specified xml text was not well-formed. See Extended Error for more details.
        /// </summary>
        EVT_MALFORMED_XMtext = 0x3aa0,

        /// <summary>
        /// The specified xml text was not well-formed. See Extended Error for more details.
        /// </summary>
        EVT_SUBSCRIPTION_TO_DIRECT_CHANNEL = 0x3aa1,

        /// <summary>
        /// Configuration error.
        /// </summary>
        EVT_CONFIGURATION_ERROR = 0x3aa2,

        /// <summary>
        /// Configuration error.
        /// </summary>
        EVT_QUERY_RESULT_STALE = 0x3aa3,

        /// <summary>
        /// Query result is currently at an invalid position.
        /// </summary>
        EVT_QUERY_RESULT_INVALID_POSITION = 0x3aa4,

        /// <summary>
        /// Registered MSXML doesn't support validation.
        /// </summary>
        EVT_NON_VALIDATING_MSXML = 0x3aa5,

        /// <summary>
        /// Registered MSXML doesn't support validation.
        /// </summary>
        EVT_FILTER_ALREADYSCOPED = 0x3aa6,

        /// <summary>
        /// Can't perform a step operation from a term that does not represent an element set.
        /// </summary>
        EVT_FILTER_NOTELTSET = 0x3aa7,

        /// <summary>
        /// Can't perform a step operation from a term that does not represent an element set.
        /// </summary>
        EVT_FILTER_INVARG = 0x3aa8,

        /// <summary>
        /// Can't perform a step operation from a term that does not represent an element set.
        /// </summary>
        EVT_FILTER_INVTEST = 0x3aa9,

        /// <summary>
        /// This data type is currently unsupported.
        /// </summary>
        EVT_FILTER_INVTYPE = 0x3aaa,

        /// <summary>
        /// A syntax error occurred at position %1!d!.
        /// </summary>
        EVT_FILTER_PARSEERR = 0x3aab,

        /// <summary>
        /// This operator is unsupported by this implementation of the filter.
        /// </summary>
        EVT_FILTER_UNSUPPORTEDOP = 0x3aac,

        /// <summary>
        /// The token encountered was unexpected.
        /// </summary>
        EVT_FILTER_UNEXPECTEDTOKEN = 0x3aad,

        /// <summary>
        /// The token encountered was unexpected.
        /// </summary>
        EVT_INVALID_OPERATION_OVER_ENABLED_DIRECT_CHANNEL = 0x3aae,

        /// <summary>
        /// The token encountered was unexpected.
        /// </summary>
        EVT_INVALID_CHANNEL_PROPERTY_VALUE = 0x3aaf,

        /// <summary>
        /// The token encountered was unexpected.
        /// </summary>
        EVT_INVALID_PUBLISHER_PROPERTY_VALUE = 0x3ab0,

        /// <summary>
        /// The channel fails to activate.
        /// </summary>
        EVT_CHANNEcANNOT_ACTIVATE = 0x3ab1,

        /// <summary>
        /// The channel fails to activate.
        /// </summary>
        EVT_FILTER_TOO_COMPLEX = 0x3ab2,

        /// <summary>
        /// the message resource is present but the message is not found in the string/message table.
        /// </summary>
        EVT_MESSAGE_NOT_FOUND = 0x3ab3,

        /// <summary>
        /// The message id for the desired message could not be found.
        /// </summary>
        EVT_MESSAGE_ID_NOT_FOUND = 0x3ab4,

        /// <summary>
        /// The substitution string for insert index (%1) could not be found.
        /// </summary>
        EVT_UNRESOLVED_VALUE_INSERT = 0x3ab5,

        /// <summary>
        /// The description string for parameter reference (%1) could not be found.
        /// </summary>
        EVT_UNRESOLVED_PARAMETER_INSERT = 0x3ab6,

        /// <summary>
        /// The maximum number of replacements has been reached.
        /// </summary>
        EVT_MAX_INSERTS_REACHED = 0x3ab7,

        /// <summary>
        /// The event definition could not be found for event id (%1).
        /// </summary>
        EVT_EVENT_DEFINITION_NOT_FOUND = 0x3ab8,

        /// <summary>
        /// The locale specific resource for the desired message is not present.
        /// </summary>
        EVT_MESSAGE_LOCALE_NOT_FOUND = 0x3ab9,

        /// <summary>
        /// The resource is too old to be compatible.
        /// </summary>
        EVT_VERSION_TOO_OLD = 0x3aba,

        /// <summary>
        /// The resource is too new to be compatible.
        /// </summary>
        EVT_VERSION_TOO_NEW = 0x3abb,

        /// <summary>
        /// The channel at index %1!d! of the query can't be opened.
        /// </summary>
        EVT_CANNOT_OPEN_CHANNEL_OF_QUERY = 0x3abc,

        /// <summary>
        /// The channel at index %1!d! of the query can't be opened.
        /// </summary>
        EVT_PUBLISHER_DISABLED = 0x3abd,

        /// <summary>
        /// Attempted to create a numeric type that is outside of its valid range.
        /// </summary>
        EVT_FILTER_OUT_OF_RANGE = 0x3abe,

        /// <summary>
        /// The subscription fails to activate.
        /// </summary>
        EC_SUBSCRIPTION_CANNOT_ACTIVATE = 0x3ae8,

        /// <summary>
        /// The subscription fails to activate.
        /// </summary>
        EC_LOG_DISABLED = 0x3ae9,

        /// <summary>
        /// The subscription fails to activate.
        /// </summary>
        EC_CIRCULAR_FORWARDING = 0x3aea,

        /// <summary>
        /// The credential store that is used to save credentials is full.
        /// </summary>
        EC_CREDSTORE_FULL = 0x3aeb,

        /// <summary>
        /// The credential used by this subscription can't be found in credential store.
        /// </summary>
        EC_CRED_NOT_FOUND = 0x3aec,

        /// <summary>
        /// No active channel is found for the query.
        /// </summary>
        EC_NO_ACTIVE_CHANNEL = 0x3aed,

        /// <summary>
        /// The resource loader failed to find MUI file.
        /// </summary>
        MUI_FILE_NOT_FOUND = 0x3afc,

        /// <summary>
        /// The resource loader failed to load MUI file because the file fail to pass validation.
        /// </summary>
        MUI_INVALID_FILE = 0x3afd,

        /// <summary>
        /// The RC Manifest is corrupted with garbage data or unsupported version or missing required item.
        /// </summary>
        MUI_INVALID_RC_CONFIG = 0x3afe,

        /// <summary>
        /// The RC Manifest has invalid culture name.
        /// </summary>
        MUI_INVALID_LOCALE_NAME = 0x3aff,

        /// <summary>
        /// The RC Manifest has invalid ultimatefallback name.
        /// </summary>
        MUI_INVALID_ULTIMATEFALLBACK_NAME = 0x3b00,

        /// <summary>
        /// The resource loader cache doesn't have loaded MUI entry.
        /// </summary>
        MUI_FILE_NOT_LOADED = 0x3b01,

        /// <summary>
        /// User stopped resource enumeration.
        /// </summary>
        RESOURCE_ENUM_USER_STOP = 0x3b02,

        /// <summary>
        /// UI language installation failed.
        /// </summary>
        MUI_INTLSETTINGS_UILANG_NOT_INSTALLED = 0x3b03,

        /// <summary>
        /// Locale installation failed.
        /// </summary>
        MUI_INTLSETTINGS_INVALID_LOCALE_NAME = 0x3b04,

        /// <summary>
        /// A resource does not have default or neutral value.
        /// </summary>
        MRM_RUNTIME_NO_DEFAULT_OR_NEUTRAL_RESOURCE = 0x3b06,

        /// <summary>
        /// Invalid PRI config file.
        /// </summary>
        MRM_INVALID_PRICONFIG = 0x3b07,

        /// <summary>
        /// Invalid file type.
        /// </summary>
        MRM_INVALID_FILE_TYPE = 0x3b08,

        /// <summary>
        /// Unknown qualifier.
        /// </summary>
        MRM_UNKNOWN_QUALIFIER = 0x3b09,

        /// <summary>
        /// Invalid qualifier value.
        /// </summary>
        MRM_INVALID_QUALIFIER_VALUE = 0x3b0a,

        /// <summary>
        /// No Candidate found.
        /// </summary>
        MRM_NO_CANDIDATE = 0x3b0b,

        /// <summary>
        /// The ResourceMap or NamedResource has an item that does not have default or neutral resource..
        /// </summary>
        MRM_NO_MATCH_OR_DEFAULT_CANDIDATE = 0x3b0c,

        /// <summary>
        /// Invalid ResourceCandidate type.
        /// </summary>
        MRM_RESOURCE_TYPE_MISMATCH = 0x3b0d,

        /// <summary>
        /// Duplicate Resource Map.
        /// </summary>
        MRM_DUPLICATE_MAname = 0x3b0e,

        /// <summary>
        /// Duplicate Entry.
        /// </summary>
        MRM_DUPLICATE_ENTRY = 0x3b0f,

        /// <summary>
        /// Invalid Resource Identifier.
        /// </summary>
        MRM_INVALID_RESOURCE_IDENTIFIER = 0x3b10,

        /// <summary>
        /// Filepath too long.
        /// </summary>
        MRM_FILEPATH_TOO_LONG = 0x3b11,

        /// <summary>
        /// Unsupported directory type.
        /// </summary>
        MRM_UNSUPPORTED_DIRECTORY_TYPE = 0x3b12,

        /// <summary>
        /// Invalid PRI File.
        /// </summary>
        MRM_INVALID_PRI_FILE = 0x3b16,

        /// <summary>
        /// NamedResource Not Found.
        /// </summary>
        MRM_NAMED_RESOURCE_NOT_FOUND = 0x3b17,

        /// <summary>
        /// ResourceMap Not Found.
        /// </summary>
        MRM_MAP_NOT_FOUND = 0x3b1f,

        /// <summary>
        /// Unsupported MRT profile type.
        /// </summary>
        MRM_UNSUPPORTED_PROFILE_TYPE = 0x3b20,

        /// <summary>
        /// Invalid qualifier operator.
        /// </summary>
        MRM_INVALID_QUALIFIER_OPERATOR = 0x3b21,

        /// <summary>
        /// Unable to determine qualifier value or qualifier value has not been set.
        /// </summary>
        MRM_INDETERMINATE_QUALIFIER_VALUE = 0x3b22,

        /// <summary>
        /// Automerge is enabled in the PRI file.
        /// </summary>
        MRM_AUTOMERGE_ENABLED = 0x3b23,

        /// <summary>
        /// Too many resources defined for package.
        /// </summary>
        MRM_TOO_MANY_RESOURCES = 0x3b24,

        /// <summary>
        /// Too many resources defined for package.
        /// </summary>
        MCA_INVALID_CAPABILITIES_STRING = 0x3b60,

        /// <summary>
        /// The monitor's VCP Version (0xDF) VCP code returned an invalid version value.
        /// </summary>
        MCA_INVALID_VCP_VERSION = 0x3b61,

        /// <summary>
        /// The monitor does not comply with the MCCS specification it claims to support.
        /// </summary>
        MCA_MONITOR_VIOLATES_MCCS_SPECIFICATION = 0x3b62,

        /// <summary>
        /// The monitor does not comply with the MCCS specification it claims to support.
        /// </summary>
        MCA_MCCS_VERSION_MISMATCH = 0x3b63,

        /// <summary>
        /// The monitor does not comply with the MCCS specification it claims to support.
        /// </summary>
        MCA_UNSUPPORTED_MCCS_VERSION = 0x3b64,

        /// <summary>
        /// An internal Monitor Configuration API error occurred.
        /// </summary>
        MCA_INTERNAerror = 0x3b65,

        /// <summary>
        /// An internal Monitor Configuration API error occurred.
        /// </summary>
        MCA_INVALID_TECHNOLOGY_TYPE_RETURNED = 0x3b66,

        /// <summary>
        /// An internal Monitor Configuration API error occurred.
        /// </summary>
        MCA_UNSUPPORTED_COLOR_TEMPERATURE = 0x3b67,

        /// <summary>
        /// An internal Monitor Configuration API error occurred.
        /// </summary>
        AMBIGUOUS_SYSTEM_DEVICE = 0x3b92,

        /// <summary>
        /// The requested system device cannot be found.
        /// </summary>
        SYSTEM_DEVICE_NOT_FOUND = 0x3bc3,

        /// <summary>
        /// Hash generation for the specified hash version and hash type is not enabled on the server.
        /// </summary>
        HASH_NOT_SUPPORTED = 0x3bc4,

        /// <summary>
        /// The hash requested from the server is not available or no longer valid.
        /// </summary>
        HASH_NOT_PRESENT = 0x3bc5,

        /// <summary>
        /// The secondary interrupt controller instance that manages the specified interrupt is not registered.
        /// </summary>
        SECONDARY_IC_PROVIDER_NOT_REGISTERED = 0x3bd9,

        /// <summary>
        /// The information supplied by the GPIO client driver is invalid.
        /// </summary>
        GPIO_CLIENT_INFORMATION_INVALID = 0x3bda,

        /// <summary>
        /// The version specified by the GPIO client driver is not supported.
        /// </summary>
        GPIO_VERSION_NOT_SUPPORTED = 0x3bdb,

        /// <summary>
        /// The registration packet supplied by the GPIO client driver is not valid.
        /// </summary>
        GPIO_INVALID_REGISTRATION_PACKET = 0x3bdc,

        /// <summary>
        /// The requested operation is not suppported for the specified handle.
        /// </summary>
        GPIO_OPERATION_DENIED = 0x3bdd,

        /// <summary>
        /// The requested connect mode conflicts with an existing mode on one or more of the specified pins.
        /// </summary>
        GPIO_INCOMPATIBLE_CONNECT_MODE = 0x3bde,

        /// <summary>
        /// The interrupt requested to be unmasked is not masked.
        /// </summary>
        GPIO_INTERRUPT_ALREADY_UNMASKED = 0x3bdf,

        /// <summary>
        /// The requested run level switch cannot be completed successfully.
        /// </summary>
        CANNOT_SWITCH_RUNLEVEL = 0x3c28,

        /// <summary>
        /// The requested run level switch cannot be completed successfully.
        /// </summary>
        INVALID_RUNLEVEL_SETTING = 0x3c29,

        /// <summary>
        /// The requested run level switch cannot be completed successfully.
        /// </summary>
        RUNLEVEL_SWITCH_TIMEOUT = 0x3c2a,

        /// <summary>
        /// A run level switch agent did not respond within the specified timeout.
        /// </summary>
        RUNLEVEL_SWITCH_AGENT_TIMEOUT = 0x3c2b,

        /// <summary>
        /// A run level switch is currently in progress.
        /// </summary>
        RUNLEVEL_SWITCH_IN_PROGRESS = 0x3c2c,

        /// <summary>
        /// One or more services failed to start during the service startup phase of a run level switch.
        /// </summary>
        SERVICES_FAILED_AUTOSTART = 0x3c2d,

        /// <summary>
        /// The task stop request cannot be completed immediately since task needs more time to shutdown.
        /// </summary>
        COM_TASK_STOP_PENDING = 0x3c8d,

        /// <summary>
        /// Package could not be opened.
        /// </summary>
        INSTALL_OPEN_PACKAGE_FAILED = 0x3cf0,

        /// <summary>
        /// Package was not found.
        /// </summary>
        INSTALL_PACKAGE_NOT_FOUND = 0x3cf1,

        /// <summary>
        /// Package data is invalid.
        /// </summary>
        INSTALL_INVALID_PACKAGE = 0x3cf2,

        /// <summary>
        /// Package failed updates, dependency or conflict validation.
        /// </summary>
        INSTALL_RESOLVE_DEPENDENCY_FAILED = 0x3cf3,

        /// <summary>
        /// There is not enough disk space on your computer. Please free up some space and try again.
        /// </summary>
        INSTALL_OUT_OF_DISK_SPACE = 0x3cf4,

        /// <summary>
        /// There was a problem downloading your product.
        /// </summary>
        INSTALL_NETWORK_FAILURE = 0x3cf5,

        /// <summary>
        /// Package could not be registered.
        /// </summary>
        INSTALL_REGISTRATION_FAILURE = 0x3cf6,

        /// <summary>
        /// Package could not be unregistered.
        /// </summary>
        INSTALL_DEREGISTRATION_FAILURE = 0x3cf7,

        /// <summary>
        /// User cancelled the install request.
        /// </summary>
        INSTALcANCEL = 0x3cf8,

        /// <summary>
        /// Install failed. Please contact your software vendor.
        /// </summary>
        INSTALL_FAILED = 0x3cf9,

        /// <summary>
        /// Removal failed. Please contact your software vendor.
        /// </summary>
        REMOVE_FAILED = 0x3cfa,

        /// <summary>
        /// Removal failed. Please contact your software vendor.
        /// </summary>
        PACKAGE_ALREADY_EXISTS = 0x3cfb,

        /// <summary>
        /// The application cannot be started. Try reinstalling the application to fix the problem.
        /// </summary>
        NEEDS_REMEDIATION = 0x3cfc,

        /// <summary>
        /// A Prerequisite for an install could not be satisfied.
        /// </summary>
        INSTALL_PREREQUISITE_FAILED = 0x3cfd,

        /// <summary>
        /// The package repository is corrupted.
        /// </summary>
        PACKAGE_REPOSITORY_CORRUPTED = 0x3cfe,

        /// <summary>
        /// The package repository is corrupted.
        /// </summary>
        INSTALL_POLICY_FAILURE = 0x3cff,

        /// <summary>
        /// The application cannot be started because it is currently updating.
        /// </summary>
        PACKAGE_UPDATING = 0x3d00,

        /// <summary>
        /// The package deployment operation is blocked by policy. Please contact your system administrator.
        /// </summary>
        DEPLOYMENT_BLOCKED_BY_POLICY = 0x3d01,

        /// <summary>
        /// The package could not be installed because resources it modifies are currently in use.
        /// </summary>
        PACKAGES_IN_USE = 0x3d02,

        /// <summary>
        /// The package could not be recovered because necessary data for recovery have been corrupted.
        /// </summary>
        RECOVERY_FILE_CORRUPT = 0x3d03,

        /// <summary>
        /// The package could not be recovered because necessary data for recovery have been corrupted.
        /// </summary>
        INVALID_STAGED_SIGNATURE = 0x3d04,

        /// <summary>
        /// An error occurred while deleting the package's previously existing application data.
        /// </summary>
        DELETING_EXISTING_APPLICATIONDATA_STORE_FAILED = 0x3d05,

        /// <summary>
        /// The package could not be installed because a higher version of this package is already installed.
        /// </summary>
        INSTALL_PACKAGE_DOWNGRADE = 0x3d06,

        /// <summary>
        /// An error in a system binary was detected. Try refreshing the PC to fix the problem.
        /// </summary>
        SYSTEM_NEEDS_REMEDIATION = 0x3d07,

        /// <summary>
        /// A corrupted CLR NGEN binary was detected on the system.
        /// </summary>
        APPX_INTEGRITY_FAILURE_CLR_NGEN = 0x3d08,

        /// <summary>
        /// The operation could not be resumed because necessary data for recovery have been corrupted.
        /// </summary>
        RESILIENCY_FILE_CORRUPT = 0x3d09,

        /// <summary>
        /// The operation could not be resumed because necessary data for recovery have been corrupted.
        /// </summary>
        INSTALL_FIREWALL_SERVICE_NOT_RUNNING = 0x3d0a,

        /// <summary>
        /// The process has no package identity.
        /// </summary>
        APPMODEL_NO_PACKAGE = 0x3d54,

        /// <summary>
        /// The package runtime information is corrupted.
        /// </summary>
        APPMODEL_PACKAGE_RUNTIME_CORRUPT = 0x3d55,

        /// <summary>
        /// The package identity is corrupted.
        /// </summary>
        APPMODEL_PACKAGE_IDENTITY_CORRUPT = 0x3d56,

        /// <summary>
        /// The process has no application identity.
        /// </summary>
        APPMODEL_NO_APPLICATION = 0x3d57,

        /// <summary>
        /// Loading the state store failed.
        /// </summary>
        STATE_LOAD_STORE_FAILED = 0x3db8,

        /// <summary>
        /// Retrieving the state version for the application failed.
        /// </summary>
        STATE_GET_VERSION_FAILED = 0x3db9,

        /// <summary>
        /// Setting the state version for the application failed.
        /// </summary>
        STATE_SET_VERSION_FAILED = 0x3dba,

        /// <summary>
        /// Resetting the structured state of the application failed.
        /// </summary>
        STATE_STRUCTURED_RESET_FAILED = 0x3dbb,

        /// <summary>
        /// State Manager failed to open the container.
        /// </summary>
        STATE_OPEN_CONTAINER_FAILED = 0x3dbc,

        /// <summary>
        /// State Manager failed to create the container.
        /// </summary>
        STATE_CREATE_CONTAINER_FAILED = 0x3dbd,

        /// <summary>
        /// State Manager failed to delete the container.
        /// </summary>
        STATE_DELETE_CONTAINER_FAILED = 0x3dbe,

        /// <summary>
        /// State Manager failed to read the setting.
        /// </summary>
        STATE_READ_SETTING_FAILED = 0x3dbf,

        /// <summary>
        /// State Manager failed to write the setting.
        /// </summary>
        STATE_WRITE_SETTING_FAILED = 0x3dc0,

        /// <summary>
        /// State Manager failed to delete the setting.
        /// </summary>
        STATE_DELETE_SETTING_FAILED = 0x3dc1,

        /// <summary>
        /// State Manager failed to query the setting.
        /// </summary>
        STATE_QUERY_SETTING_FAILED = 0x3dc2,

        /// <summary>
        /// State Manager failed to read the composite setting.
        /// </summary>
        STATE_READ_COMPOSITE_SETTING_FAILED = 0x3dc3,

        /// <summary>
        /// State Manager failed to write the composite setting.
        /// </summary>
        STATE_WRITE_COMPOSITE_SETTING_FAILED = 0x3dc4,

        /// <summary>
        /// State Manager failed to enumerate the containers.
        /// </summary>
        STATE_ENUMERATE_CONTAINER_FAILED = 0x3dc5,

        /// <summary>
        /// State Manager failed to enumerate the settings.
        /// </summary>
        STATE_ENUMERATE_SETTINGS_FAILED = 0x3dc6,

        /// <summary>
        /// The size of the state manager composite setting value has exceeded the limit.
        /// </summary>
        STATE_COMPOSITE_SETTING_VALUE_SIZE_LIMIT_EXCEEDED = 0x3dc7,

        /// <summary>
        /// The size of the state manager setting value has exceeded the limit.
        /// </summary>
        STATE_SETTING_VALUE_SIZE_LIMIT_EXCEEDED = 0x3dc8,

        /// <summary>
        /// The length of the state manager setting name has exceeded the limit.
        /// </summary>
        STATE_SETTING_NAME_SIZE_LIMIT_EXCEEDED = 0x3dc9,

        /// <summary>
        /// The length of the state manager container name has exceeded the limit.
        /// </summary>
        STATE_CONTAINER_NAME_SIZE_LIMIT_EXCEEDED = 0x3dca,
    }
}
