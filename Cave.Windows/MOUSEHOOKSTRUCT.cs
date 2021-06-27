using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// The MOUSEHOOKSTRUCT structure contains information about a mouse event passed to a WH_MOUSE hook procedure, MouseProc.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class MOUSEHOOKSTRUCT
    {
        /// <summary>
        /// Specifies a POINT structure that contains the x- and y-coordinates of the cursor, in screen coordinates.
        /// </summary>
        public POINT pt;
        /// <summary>
        /// Handle to the window that will receive the mouse message corresponding to the mouse event.
        /// </summary>
        public IntPtr hwnd;
        /// <summary>
        /// Specifies the hit-test value. For a list of hit-test values, see the description of the WM_NCHITTEST message.
        /// </summary>
        public int wHitTestCode;
        /// <summary>
        /// Specifies extra information associated with the message.
        /// </summary>
        public int dwExtraInfo;
    }
}
