using System;

namespace Cave.Windows
{
    /// <summary>
    /// Extended Windows Exit Flags
    /// </summary>
    [Flags]
    public enum EWX : int
    {
        /// <summary>
        /// Beginning with Windows 8:  You can prepare the system for a faster startup by combining the EWX_HYBRID_SHUTDOWN flag with the EWX_SHUTDOWN flag.
        /// </summary>
        HYBRID_SHUTDOWN = 0x00400000,

        /// <summary>
        /// Shuts down all processes running in the logon session of the process that called the ExitWindowsEx function. Then it logs the user off.
        /// This flag can be used only by processes running in an interactive user's logon session.
        /// </summary>
        LOGOFF = 0,

        /// <summary>
        /// Shuts down the system and turns off the power. The system must support the power-off feature.
        /// The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.
        /// </summary>
        POWEROFF = 0x00000008,

        /// <summary>
        /// Shuts down the system and then restarts the system.
        /// The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.
        /// </summary>
        REBOOT = 0x00000002,

        /// <summary>
        /// Shuts down the system and then restarts it, as well as any applications that have been registered for restart using the RegisterApplicationRestart function. These application receive the WM_QUERYENDSESSION message with lParam set to the ENDSESSION_CLOSEAPP value. For more information, see Guidelines for Applications.
        /// </summary>
        RESTARTAPPS = 0x00000040,

        /// <summary>
        /// Shuts down the system to a point at which it is safe to turn off the power. All file buffers have been flushed to disk, and all running processes have stopped.
        /// The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.
        /// Specifying this flag will not turn off the power even if the system supports the power-off feature. You must specify EWX_POWEROFF to do this.
        /// Windows XP with SP1:  If the system supports the power-off feature, specifying this flag turns off the power.
        /// </summary>
        SHUTDOWN = 0x00000001,

        /// <summary>
        /// This flag has no effect if terminal services is enabled. Otherwise, the system does not send the WM_QUERYENDSESSION message. This can cause applications to lose data. Therefore, you should only use this flag in an emergency.
        /// </summary>
        FORCE = 0x00000004,

        /// <summary>
        /// Forces processes to terminate if they do not respond to the WM_QUERYENDSESSION or WM_ENDSESSION message within the timeout interval. For more information, see the Remarks.
        /// </summary>
        FORCEIFHUNG = 0x00000010,
    }
}