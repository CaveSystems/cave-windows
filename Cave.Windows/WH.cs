namespace Cave.Windows
{
    /// <summary>
    /// Defines the various types of hooks that are available in Windows
    /// Hooks tend to slow down the system because they increase the amount of processing the system must perform for each message. You should install a hook only when necessary, and remove it as soon as possible.
    /// </summary>
    public enum WH : int
    {
        /// <summary>
        /// The JOURNALRECORD hook enables you to monitor and record input events. Typically, you use this hook to record a sequence of mouse and keyboard events to play back later by using the JOURNALPLAYBACK Hook. The JOURNALRECORD hook is a global hook � it cannot be used as a thread-specific hook.
        /// </summary>
        JOURNALRECORD = 0,
        /// <summary>
        /// The KEYBOARD_LL hook enables you to monitor keyboard input events about to be posted in a thread input queue.
        /// For more information, see the LowLevelKeyboardProc function.
        /// </summary>
        JOURNALPLAYBACK = 1,
        /// <summary>
        /// The KEYBOARD hook enables an application to monitor message traffic for WM_KEYDOWN and WM_KEYUP messages about to be returned by the GetMessage or PeekMessage function. You can use the KEYBOARD hook to monitor keyboard input posted to a message queue.
        /// </summary>
        KEYBOARD = 2,
        /// <summary>
        /// The GETMESSAGE hook enables an application to monitor messages about to be returned by the GetMessage or PeekMessage function. You can use the GETMESSAGE hook to monitor mouse and keyboard input and other messages posted to the message queue.
        /// </summary>
        GETMESSAGE = 3,
        /// <summary>
        /// The CALLWNDPROC and CALLWNDPROCRET hooks enable you to monitor messages sent to window procedures. The system calls a CALLWNDPROC hook procedure before passing the message to the receiving window procedure, and calls the CALLWNDPROCRET hook procedure after the window procedure has processed the message.
        /// </summary>
        CALLWNDPROC = 4,
        /// <summary>
        /// The system calls a CBT hook procedure before activating, creating, destroying, minimizing, maximizing, moving, or sizing a window; before completing a system command; before removing a mouse or keyboard event from the system message queue; before setting the input focus; or before synchronizing with the system message queue. The value the hook procedure returns determines whether the system allows or prevents one of these operations. The CBT hook is intended primarily for computer-based training (CBT) applications.
        /// </summary>
        CBT = 5,
        /// <summary>
        /// The MSGFILTER and SYSMSGFILTER hooks enable you to monitor messages about to be processed by a menu, scroll bar, message box, or dialog box, and to detect when a different window is about to be activated as a result of the user's pressing the ALT+TAB or ALT+ESC key combination. The MSGFILTER hook can only monitor messages passed to a menu, scroll bar, message box, or dialog box created by the application that installed the hook procedure. The SYSMSGFILTER hook monitors such messages for all applications.
        /// </summary>
        SYSMSGFILTER = 6,
        /// <summary>
        /// The MOUSE hook enables you to monitor mouse messages about to be returned by the GetMessage or PeekMessage function. You can use the MOUSE hook to monitor mouse input posted to a message queue.
        /// </summary>
        MOUSE = 7,
        /// <summary>
        ///
        /// </summary>
        HARDWARE = 8,
        /// <summary>
        /// The system calls a DEBUG hook procedure before calling hook procedures associated with any other hook in the system. You can use this hook to determine whether to allow the system to call hook procedures associated with other types of hooks.
        /// </summary>
        DEBUG = 9,
        /// <summary>
        /// A shell application can use the SHELL hook to receive important notifications. The system calls a SHELL hook procedure when the shell application is about to be activated and when a top-level window is created or destroyed.
        /// </summary>
        SHELL = 10,
        /// <summary>
        /// The FOREGROUNDIDLE hook enables you to perform low priority tasks during times when its foreground thread is idle. The system calls a FOREGROUNDIDLE hook procedure when the application's foreground thread is about to become idle.
        /// </summary>
        FOREGROUNDIDLE = 11,
        /// <summary>
        /// The CALLWNDPROC and CALLWNDPROCRET hooks enable you to monitor messages sent to window procedures. The system calls a CALLWNDPROC hook procedure before passing the message to the receiving window procedure, and calls the CALLWNDPROCRET hook procedure after the window procedure has processed the message.
        /// </summary>
        CALLWNDPROCRET = 12,
        /// <summary>
        /// Installs a hook procedure that monitors low-level keyboard  input events.
        /// </summary>
        KEYBOARD_LL = 13,
        /// <summary>
        /// The MOUSE_LL hook enables you to monitor mouse input events about to be posted in a thread input queue.
        /// For more information, see the LowLevelMouseProc function.
        /// </summary>
        MOUSE_LL = 14
    }
}
