using System.Drawing;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// The WINDOWPLACEMENT structure contains information about the placement of a window on the screen.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WINDOWPLACEMENT
    {
        /// <summary>
        /// Specifies the length, in bytes, of the structure. Before calling the GetWindowPlacement or SetWindowPlacement functions, set this member to sizeof(WINDOWPLACEMENT).
        /// GetWindowPlacement and SetWindowPlacement fail if this member is not set correctly.
        /// </summary>
        public int length;
        /// <summary>
        /// Specifies flags that control the position of the minimized window and the method by which the window is restored. This member can be one or more of the following values.
        /// WPF_ASYNCWINDOWPLACEMENT, WPF_RESTORETOMAXIMIZED, WPF_SETMINPOSITION
        /// </summary>
        public int flags;
        /// <summary>
        /// Specifies the current show state of the window. This member can be one of the following values.
        /// </summary>
        public int showCmd;
        /// <summary>
        /// Specifies the coordinates of the window's upper-left corner when the window is minimized.
        /// </summary>
        public Point ptMinPosition;
        /// <summary>
        /// Specifies the coordinates of the window's upper-left corner when the window is maximized.
        /// </summary>
        public Point ptMaxPosition;
        /// <summary>
        /// Specifies the window's coordinates when the window is in the restored position.
        /// </summary>
        public Rectangle normalPosition;
    }
}
