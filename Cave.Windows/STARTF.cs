using System;

namespace Cave.Windows
{
    /// <summary>
    /// Bitfield that determines whether certain STARTUPINFO members are used when the process creates a window. 
    /// </summary>
    [Flags]
    public enum STARTF
    {
        /// <summary>
        /// The wShowWindow member contains additional information.
        /// </summary>
        USESHOWWINDOW=0x00000001,

        /// <summary>
        /// The dwXSize and dwYSize members contain additional information.
        /// </summary>
        USESIZE=0x00000002,

        /// <summary>
        /// The dwX and dwY members contain additional information.
        /// </summary>
        USEPOSITION=0x00000004,

        /// <summary>
        /// The dwXCountChars and dwYCountChars members contain additional information.
        /// </summary>
        USECOUNTCHARS=0x00000008,

        /// <summary>
        /// The dwFillAttribute member contains additional information.
        /// </summary>
        USEFILLATTRIBUTE=0x00000010,

        /// <summary>
        /// Indicates that the process should be run in full-screen mode, rather than in windowed mode.
        /// </summary>
        RUNFULLSCREEN=0x00000020,

        /// <summary>
        /// Indicates that the cursor is in feedback mode for two seconds after CreateProcess is called. The Working in Background cursor is displayed (see the Pointers tab in the Mouse control panel utility).
        /// </summary>
        FORCEONFEEDBACK = 0x00000040,
        
        /// <summary>
        /// Indicates that the feedback cursor is forced off while the process is starting. The Normal Select cursor is displayed.
        /// </summary>
        FORCEOFFFEEDBACK=0x00000080,

        /// <summary>
        /// The hStdInput, hStdOutput, and hStdError members contain additional information.
        /// If this flag is specified when calling one of the process creation functions, the handles must be inheritable and the function's bInheritHandles parameter must be set to TRUE. For more information, see Handle Inheritance.
        /// </summary>
        USESTDHANDLES=0x00000100,

        /// <summary>
        /// The hStdInput member contains additional information.
        /// </summary>
        USEHOTKEY=0x00000200,

        /// <summary>
        /// The lpTitle member contains the path of the shortcut file (.lnk) that the user invoked to start this process. This is typically set by the shell when a .lnk file pointing to the launched application is invoked. Most applications will not need to set this value.
        /// </summary>
        TITLEISLINKNAME=0x00000800,

        /// <summary>
        /// The lpTitle member contains an AppUserModelID. This identifier controls how the taskbar and Start menu present the application, and enables it to be associated with the correct shortcuts and Jump Lists. Generally, applications will use the SetCurrentProcessExplicitAppUserModelID and GetCurrentProcessExplicitAppUserModelID functions instead of setting this flag. For more information, see Application User Model IDs.
        /// </summary>
        TITLEISAPPID=0x00001000,

        /// <summary>
        /// Indicates that any windows created by the process cannot be pinned on the taskbar.
        /// </summary>
        PREVENTPINNING = 0x00002000,

    }
}
