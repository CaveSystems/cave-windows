using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// An SP_DEVINSTALL_PARAMS structure contains device installation parameters associated with a particular device information element or associated globally with a device information set.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SP_DEVINSTALL_PARAMS
    {
        /// <summary>
        /// The size, in bytes, of the SP_DEVINSTALL_PARAMS structure.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// Flags that control installation and user interface operations. Some flags can be set before sending the device installation request while other flags are set automatically during the processing of some requests. Flags can be a combination of the following values.
        /// </summary>
        //TODO DI_* FLAGS ENUM http://msdn.microsoft.com/en-us/library/windows/hardware/ff552346%28v=vs.85%29.aspx
        public uint Flags;

        /// <summary>
        /// Additional flags that provide control over installation and user interface operations. Some flags can be set before calling the device installer functions while other flags are set automatically during the processing of some functions.
        /// </summary>
        //TODO DI_FLAGSEX_* FLAGS ENUM
        public uint FlagsEx;

        /// <summary>
        /// Window handle that will own the user interface dialogs related to this device.
        /// </summary>
        public IntPtr hwndParent;

        /// <summary>
        /// Callback used to handle events during file copying. An installer can use a callback, for example, to perform special processing when committing a file queue.
        /// </summary>
        public IntPtr InstallMsgHandler;

        /// <summary>
        /// Private data that is used by the InstallMsgHandler callback.
        /// </summary>
        public IntPtr InstallMsgHandlerContext;

        /// <summary>
        /// A handle to a caller-supplied file queue where file operations should be queued but not committed.
        /// </summary>
        public IntPtr FileQueue;

        /// <summary>
        /// A pointer for class-installer data. Co-installers must not use this field.
        /// </summary>
        public IntPtr ClassInstallReserved;

        /// <summary>
        /// Reserved. For internal use only.
        /// </summary>
        public uint Reserved;

        /// <summary>
        /// This path is used by the SetupDiBuildDriverInfoList function.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = KERNEL32.MAX_PATH)]
        public string DriverPath;
    }
}
