using System.Drawing;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// The WINDOWINFO structure contains window information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WINDOWINFO
    {
        /// <summary>
        /// The size of the structure, in bytes. The caller must set this to sizeof(WINDOWINFO).
        /// </summary>
        public int csSize;
        /// <summary>
        /// Pointer to a RECT structure that specifies the coordinates of the window.
        /// </summary>
        public Rectangle rcWindow;
        /// <summary>
        /// Pointer to a RECT structure that specifies the coordinates of the client area.
        /// </summary>
        public Rectangle rcClient;
        /// <summary>
        /// The window styles. For a table of window styles, see CreateWindowEx.
        /// </summary>
        public int dwStyle;
        /// <summary>
        /// The extended window styles. For a table of extended window styles, see CreateWindowEx.
        /// </summary>
        public int dwExStyle;
        /// <summary>
        /// The window status. If this member is WS_ACTIVECAPTION, the window is active. Otherwise, this member is zero.
        /// </summary>
        public int dwWindowStatus;
        /// <summary>
        /// The width of the window border, in pixels.
        /// </summary>
        public uint cxWindowBorders;
        /// <summary>
        /// The height of the window border, in pixels.
        /// </summary>
        public uint cyWindowBorders;
        /// <summary>
        /// The window class atom (see RegisterClass).
        /// </summary>
        public short atomWindowtype;
        /// <summary>
        /// The Microsoft Windows version of the application that created the window.
        /// </summary>
        public short wCreatorVersion;
    }
}
