namespace Cave.Windows
{
    /// <summary>
    /// Provides values for Windows Z Order positioning
    /// </summary>
    public enum HWND_MODE
    {
        /// <summary>
        /// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is already a non-topmost window.
        /// </summary>
        NOTOPMOST = -2,

        /// <summary>
        /// Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.
        /// </summary>
        TOPMOST = -1,

        /// <summary>
        /// Places the window at the top of the Z order.
        /// </summary>
        TOP = 0,

        /// <summary>
        /// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its topmost status and is placed at the bottom of all other windows.
        /// </summary>
        BOTTOM = 1,
    }
}
