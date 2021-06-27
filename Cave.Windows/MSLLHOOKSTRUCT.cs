using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// The MSLLHOOKSTRUCT structure contains information about a low-level keyboard input event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MSLLHOOKSTRUCT
    {
        /// <summary>
        /// Specifies a POINT structure that contains the x- and y-coordinates of the cursor, in screen coordinates.
        /// </summary>
        public POINT pt;
        /// <summary>
        /// If the message is WM_MOUSEWHEEL, the high-order word of this member is the wheel delta.
        /// The low-order word is reserved. A positive value indicates that the wheel was rotated forward,
        /// away from the user; a negative value indicates that the wheel was rotated backward, toward the user.
        /// One wheel click is defined as WHEEL_DELTA, which is 120.
        ///If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP,
        /// or WM_NCXBUTTONDBLCLK, the high-order word specifies which X button was pressed or released,
        /// and the low-order word is reserved. This value can be one or more of the following values. Otherwise, mouseData is not used.
        ///XBUTTON1
        ///The first X button was pressed or released.
        ///XBUTTON2
        ///The second X button was pressed or released.
        /// </summary>
        public int mouseData;
        /// <summary>
        /// Specifies the event-injected flag. An application can use the following value to test the mouse flags. Value Purpose
        ///LLMHF_INJECTED Test the event-injected flag.
        ///0
        ///Specifies whether the event was injected. The value is 1 if the event was injected; otherwise, it is 0.
        ///1-15
        ///Reserved.
        /// </summary>
        public int flags;
        /// <summary>
        /// Specifies the time stamp for this message.
        /// </summary>
        public int time;
        /// <summary>
        /// Specifies extra information associated with the message.
        /// </summary>
        public int dwExtraInfo;
    }
}
