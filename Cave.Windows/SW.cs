using System.Diagnostics.CodeAnalysis;

namespace Cave.Windows
{
    /// <summary>
    /// Commands used by the ShowWindow function that sets the specified window's show state.
    /// </summary>
    [SuppressMessage("Design", "CA1069")]
    public enum SW : int
    {
        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        HIDE = 0,
        /// <summary>
        /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
        /// </summary>
        SHOWNORMAL = 1,
        /// <summary>
        /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
        /// </summary>
        NORMAL = SHOWNORMAL,
        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        SHOWMINIMIZED = 2,
        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>
        SHOWMAXIMIZED = 3,
        /// <summary>
        /// Maximizes the specified window.
        /// </summary>
        MAXIMIZE = 3,
        /// <summary>
        /// Displays a window in its most recent size and position. This value is similar to SHOWNORMAL, except the window is not actived.
        /// </summary>
        SHOWNOACTIVATE = 4,
        /// <summary>
        /// Activates the window and displays it in its current size and position.
        /// </summary>
        SHOW = 5,
        /// <summary>
        /// Minimizes the specified window and activates the next top-level window in the Z order.
        /// </summary>
        MINIMIZE = 6,
        /// <summary>
        /// Displays the window as a minimized window. This value is similar to SHOWMINIMIZED, except the window is not activated.
        /// </summary>
        SHOWMINNOACTIVE = 7,
        /// <summary>
        /// Displays the window in its current size and position. This value is similar to SHOW, except the window is not activated.
        /// </summary>
        SHOWNA = 8,
        /// <summary>
        /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
        /// </summary>
        RESTORE = 9,
        /// <summary>
        /// Sets the show state based on the  value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
        /// </summary>
        SHOWDEFAULT = 10,
        /// <summary>
        /// Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
        /// </summary>
        FORCEMINIMIZE = 11,
    }
}
