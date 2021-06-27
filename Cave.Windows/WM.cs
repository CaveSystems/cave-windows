using System.Diagnostics.CodeAnalysis;

namespace Cave.Windows
{
    /// <summary>
    /// Windows Messages
    /// </summary>
    [SuppressMessage("Design", "CA1069")]
    public enum WM : uint
    {
        /// <summary>
        /// The NULL message performs no operation. An application sends the NULL message if it wants to post a message that the recipient window will ignore.
        /// </summary>
        NULL = 0x0000,

        /// <summary>
        /// The CREATE message is sent when an application requests that a window be created by calling the CreateWindowEx or CreateWindow function. (The message is sent before the function returns.) The window procedure of the new window receives this message after the window is created, but before the window becomes visible.
        /// </summary>
        CREATE = 0x0001,

        /// <summary>
        /// The DESTROY message is sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window is removed from the screen.
        /// </summary>
        DESTROY = 0x0002,

        /// <summary>
        /// The MOVE message is sent after a window has been moved.
        /// </summary>
        MOVE = 0x0003,

        /// <summary>
        /// The SIZE message is sent to a window after its size has changed.
        /// </summary>
        SIZE = 0x0005,

        /// <summary>
        /// The ACTIVATE message is sent to both the window being activated and the window being deactivated. If the windows use the same input queue, the message is sent synchronously, first to the window procedure of the top-level window being deactivated, then to the window procedure of the top-level window being activated. If the windows use different input queues, the message is sent asynchronously, so the window is activated immediately.
        /// </summary>
        ACTIVATE = 0x0006,

        /// <summary>
        /// The SETFOCUS message is sent to a window after it has gained the keyboard focus.
        /// </summary>
        SETFOCUS = 0x0007,

        /// <summary>
        /// The KILLFOCUS message is sent to a window immediately before it loses the keyboard focus.
        /// </summary>
        KILLFOCUS = 0x0008,

        /// <summary>
        /// The ENABLE message is sent when an application changes the enabled state of a window. It is sent to the window whose enabled state is changing. This message is sent before the EnableWindow function returns, but after the enabled state (WS_DISABLED style bit) of the window has changed.
        /// </summary>
        ENABLE = 0x000A,

        /// <summary>
        /// This message is sent by an application to a window to enable changes in that window to be redrawn or to prevent changes in that window from being redrawn.
        /// </summary>
        SETREDRAW = 0x000B,

        /// <summary>
        /// An application sends a SETTEXT message to set the text of a window.
        /// </summary>
        SETTEXT = 0x000C,

        /// <summary>
        /// An application sends a GETTEXT message to copy the text that corresponds to a window into a buffer provided by the caller.
        /// </summary>
        GETTEXT = 0x000D,

        /// <summary>
        /// An application sends a GETTEXTLENGTH message to determine the length, in characters, of the text associated with a window.
        /// </summary>
        GETTEXTLENGTH = 0x000E,

        /// <summary>
        /// The PAINT message is sent when the system or another application makes a request to paint a portion of an application's window. The message is sent when the UpdateWindow or RedrawWindow function is called, or by the DispatchMessage function when the application obtains a PAINT message by using the GetMessage or PeekMessage function.
        /// </summary>
        PAINT = 0x000F,

        /// <summary>
        /// The CLOSE message is sent as a signal that a window or an application should terminate.
        /// </summary>
        CLOSE = 0x0010,

        /// <summary>
        /// The QUERYENDSESSION message is sent when the user chooses to end the session or when an application calls one of the system shutdown functions. If any application returns zero, the session is not ended. The system stops sending QUERYENDSESSION messages as soon as one application returns zero.
        /// After processing this message, the system sends the ENDSESSION message with the wParam parameter set to the results of the QUERYENDSESSION message.
        /// </summary>
        QUERYENDSESSION = 0x0011,

        /// <summary>
        ///
        /// </summary>
        QUIT = 0x0012,

        /// <summary>
        /// The QUERYOPEN message is sent to an icon when the user requests that the window be restored to its previous size and position.
        /// </summary>
        QUERYOPEN = 0x0013,

        /// <summary>
        ///
        /// </summary>
        ERASEBKGND = 0x0014,

        /// <summary>
        ///
        /// </summary>
        SYSCOLORCHANGE = 0x0015,

        /// <summary>
        /// The ENDSESSION message is sent to an application after the system processes the results of the QUERYENDSESSION message. The ENDSESSION message informs the application whether the session is ending.
        /// </summary>
        ENDSESSION = 0x0016,

        /// <summary>
        ///
        /// </summary>
        SHOWWINDOW = 0x0018,

        /// <summary>
        ///
        /// </summary>
        CTLCOLOR = 0x0019,

        /// <summary>
        ///
        /// </summary>
        WININICHANGE = 0x001A,

        /// <summary>
        ///
        /// </summary>
        SETTINGCHANGE = WININICHANGE,

        /// <summary>
        ///
        /// </summary>
        DEVMODECHANGE = 0x001B,

        /// <summary>
        ///
        /// </summary>
        ACTIVATEAPP = 0x001C,

        /// <summary>
        ///
        /// </summary>
        FONTCHANGE = 0x001D,

        /// <summary>
        ///
        /// </summary>
        TIMECHANGE = 0x001E,

        /// <summary>
        ///
        /// </summary>
        CANCELMODE = 0x001F,

        /// <summary>
        ///
        /// </summary>
        SETCURSOR = 0x0020,

        /// <summary>
        ///
        /// </summary>
        MOUSEACTIVATE = 0x0021,

        /// <summary>
        ///
        /// </summary>
        CHILDACTIVATE = 0x0022,

        /// <summary>
        ///
        /// </summary>
        QUEUESYNC = 0x0023,

        /// <summary>
        ///
        /// </summary>
        GETMINMAXINFO = 0x0024,

        /// <summary>
        ///
        /// </summary>
        PAINTICON = 0x0026,

        /// <summary>
        ///
        /// </summary>
        ICONERASEBKGND = 0x0027,

        /// <summary>
        ///
        /// </summary>
        NEXTDLGCTL = 0x0028,

        /// <summary>
        ///
        /// </summary>
        SPOOLERSTATUS = 0x002A,

        /// <summary>
        ///
        /// </summary>
        DRAWITEM = 0x002B,

        /// <summary>
        ///
        /// </summary>
        MEASUREITEM = 0x002C,

        /// <summary>
        ///
        /// </summary>
        DELETEITEM = 0x002D,

        /// <summary>
        ///
        /// </summary>
        VKEYTOITEM = 0x002E,

        /// <summary>
        ///
        /// </summary>
        CHARTOITEM = 0x002F,

        /// <summary>
        ///
        /// </summary>
        SETFONT = 0x0030,

        /// <summary>
        ///
        /// </summary>
        GETFONT = 0x0031,

        /// <summary>
        ///
        /// </summary>
        SETHOTKEY = 0x0032,

        /// <summary>
        ///
        /// </summary>
        GETHOTKEY = 0x0033,

        /// <summary>
        ///
        /// </summary>
        QUERYDRAGICON = 0x0037,

        /// <summary>
        ///
        /// </summary>
        COMPAREITEM = 0x0039,

        /// <summary>
        ///
        /// </summary>
        GETOBJECT = 0x003D,

        /// <summary>
        ///
        /// </summary>
        COMPACTING = 0x0041,

        /// <summary>
        ///
        /// </summary>
        COMMNOTIFY = 0x0044,

        /// <summary>
        ///
        /// </summary>
        WINDOWPOSCHANGING = 0x0046,

        /// <summary>
        ///
        /// </summary>
        WINDOWPOSCHANGED = 0x0047,

        /// <summary>
        ///
        /// </summary>
        POWER = 0x0048,

        /// <summary>
        ///
        /// </summary>
        COPYDATA = 0x004A,

        /// <summary>
        ///
        /// </summary>
        CANCELJOURNAL = 0x004B,

        /// <summary>
        ///
        /// </summary>
        NOTIFY = 0x004E,

        /// <summary>
        ///
        /// </summary>
        INPUTLANGCHANGEREQUEST = 0x0050,

        /// <summary>
        ///
        /// </summary>
        INPUTLANGCHANGE = 0x0051,

        /// <summary>
        ///
        /// </summary>
        TCARD = 0x0052,

        /// <summary>
        ///
        /// </summary>
        HELP = 0x0053,

        /// <summary>
        ///
        /// </summary>
        USERCHANGED = 0x0054,

        /// <summary>
        ///
        /// </summary>
        NOTIFYFORMAT = 0x0055,

        /// <summary>
        ///
        /// </summary>
        CONTEXTMENU = 0x007B,

        /// <summary>
        ///
        /// </summary>
        STYLECHANGING = 0x007C,

        /// <summary>
        ///
        /// </summary>
        STYLECHANGED = 0x007D,

        /// <summary>
        ///
        /// </summary>
        DISPLAYCHANGE = 0x007E,

        /// <summary>
        ///
        /// </summary>
        GETICON = 0x007F,

        /// <summary>
        ///
        /// </summary>
        SETICON = 0x0080,

        /// <summary>
        ///
        /// </summary>
        NCCREATE = 0x0081,

        /// <summary>
        ///
        /// </summary>
        NCDESTROY = 0x0082,

        /// <summary>
        ///
        /// </summary>
        NCCALCSIZE = 0x0083,

        /// <summary>
        ///
        /// </summary>
        NCHITTEST = 0x0084,

        /// <summary>
        ///
        /// </summary>
        NCPAINT = 0x0085,

        /// <summary>
        ///
        /// </summary>
        NCACTIVATE = 0x0086,

        /// <summary>
        ///
        /// </summary>
        GETDLGCODE = 0x0087,

        /// <summary>
        ///
        /// </summary>
        SYNCPAINT = 0x0088,

        /// <summary>
        ///
        /// </summary>
        NCMOUSEMOVE = 0x00A0,

        /// <summary>
        ///
        /// </summary>
        NCLBUTTONDOWN = 0x00A1,

        /// <summary>
        ///
        /// </summary>
        NCLBUTTONUP = 0x00A2,

        /// <summary>
        ///
        /// </summary>
        NCLBUTTONDBLCLK = 0x00A3,

        /// <summary>
        ///
        /// </summary>
        NCRBUTTONDOWN = 0x00A4,

        /// <summary>
        ///
        /// </summary>
        NCRBUTTONUP = 0x00A5,

        /// <summary>
        ///
        /// </summary>
        NCRBUTTONDBLCLK = 0x00A6,

        /// <summary>
        ///
        /// </summary>
        NCMBUTTONDOWN = 0x00A7,

        /// <summary>
        ///
        /// </summary>
        NCMBUTTONUP = 0x00A8,

        /// <summary>
        ///
        /// </summary>
        NCMBUTTONDBLCLK = 0x00A9,

        /// <summary>
        ///
        /// </summary>
        NCXBUTTONDOWN = 0x00AB,

        /// <summary>
        ///
        /// </summary>
        NCXBUTTONUP = 0x00AC,

        /// <summary>
        ///
        /// </summary>
        NCXBUTTONDBLCLK = 0x00AD,

        /// <summary>
        ///
        /// </summary>
        INPUT = 0x00FF,

        /// <summary>
        ///
        /// </summary>
        KEYFIRST = 0x0100,

        /// <summary>
        ///
        /// </summary>
        KEYDOWN = 0x0100,

        /// <summary>
        ///
        /// </summary>
        KEYUP = 0x0101,

        /// <summary>
        ///
        /// </summary>
        CHAR = 0x0102,

        /// <summary>
        ///
        /// </summary>
        DEADCHAR = 0x0103,

        /// <summary>
        ///
        /// </summary>
        SYSKEYDOWN = 0x0104,

        /// <summary>
        ///
        /// </summary>
        SYSKEYUP = 0x0105,

        /// <summary>
        ///
        /// </summary>
        SYSCHAR = 0x0106,

        /// <summary>
        ///
        /// </summary>
        SYSDEADCHAR = 0x0107,

        /// <summary>
        /// The UNICHAR message is posted to the window with the keyboard focus when a KEYDOWN message is translated by the TranslateMessage function. The UNICHAR message contains the character code of the key that was pressed.
        /// The UNICHAR message is equivalent to CHAR, but it uses Unicode Transformation Format (UTF)-32, whereas CHAR uses UTF-16. It is designed to send or post Unicode characters to ANSI windows and it can can handle Unicode Supplementary Plane characters.
        /// </summary>
        UNICHAR = 0x0109,

        /// <summary>
        ///
        /// </summary>
        KEYLAST = 0x0108,

        /// <summary>
        ///
        /// </summary>
        IME_STARTCOMPOSITION = 0x010D,

        /// <summary>
        ///
        /// </summary>
        IME_ENDCOMPOSITION = 0x010E,

        /// <summary>
        ///
        /// </summary>
        IME_COMPOSITION = 0x010F,

        /// <summary>
        ///
        /// </summary>
        IME_KEYLAST = 0x010F,

        /// <summary>
        ///
        /// </summary>
        INITDIALOG = 0x0110,

        /// <summary>
        ///
        /// </summary>
        COMMAND = 0x0111,

        /// <summary>
        ///
        /// </summary>
        SYSCOMMAND = 0x0112,

        /// <summary>
        ///
        /// </summary>
        TIMER = 0x0113,

        /// <summary>
        ///
        /// </summary>
        HSCROLL = 0x0114,

        /// <summary>
        ///
        /// </summary>
        VSCROLL = 0x0115,

        /// <summary>
        ///
        /// </summary>
        INITMENU = 0x0116,

        /// <summary>
        ///
        /// </summary>
        INITMENUPOPUP = 0x0117,

        /// <summary>
        ///
        /// </summary>
        MENUSELECT = 0x011F,

        /// <summary>
        ///
        /// </summary>
        MENUCHAR = 0x0120,

        /// <summary>
        ///
        /// </summary>
        ENTERIDLE = 0x0121,

        /// <summary>
        ///
        /// </summary>
        MENURBUTTONUP = 0x0122,

        /// <summary>
        ///
        /// </summary>
        MENUDRAG = 0x0123,

        /// <summary>
        ///
        /// </summary>
        MENUGETOBJECT = 0x0124,

        /// <summary>
        ///
        /// </summary>
        UNINITMENUPOPUP = 0x0125,

        /// <summary>
        ///
        /// </summary>
        MENUCOMMAND = 0x0126,

        /// <summary>
        ///
        /// </summary>
        CHANGEUISTATE = 0x0127,

        /// <summary>
        ///
        /// </summary>
        UPDATEUISTATE = 0x0128,

        /// <summary>
        ///
        /// </summary>
        QUERYUISTATE = 0x0129,

        /// <summary>
        ///
        /// </summary>
        CTLCOLORMSGBOX = 0x0132,

        /// <summary>
        ///
        /// </summary>
        CTLCOLOREDIT = 0x0133,

        /// <summary>
        ///
        /// </summary>
        CTLCOLORLISTBOX = 0x0134,

        /// <summary>
        ///
        /// </summary>
        CTLCOLORBTN = 0x0135,

        /// <summary>
        ///
        /// </summary>
        CTLCOLORDLG = 0x0136,

        /// <summary>
        ///
        /// </summary>
        CTLCOLORSCROLLBAR = 0x0137,

        /// <summary>
        ///
        /// </summary>
        CTLCOLORSTATIC = 0x0138,

        /// <summary>
        ///
        /// </summary>
        MOUSEFIRST = 0x0200,

        /// <summary>
        ///
        /// </summary>
        MOUSEMOVE = 0x0200,

        /// <summary>
        ///
        /// </summary>
        LBUTTONDOWN = 0x0201,

        /// <summary>
        ///
        /// </summary>
        LBUTTONUP = 0x0202,

        /// <summary>
        ///
        /// </summary>
        LBUTTONDBLCLK = 0x0203,

        /// <summary>
        ///
        /// </summary>
        RBUTTONDOWN = 0x0204,

        /// <summary>
        ///
        /// </summary>
        RBUTTONUP = 0x0205,

        /// <summary>
        ///
        /// </summary>
        RBUTTONDBLCLK = 0x0206,

        /// <summary>
        ///
        /// </summary>
        MBUTTONDOWN = 0x0207,

        /// <summary>
        ///
        /// </summary>
        MBUTTONUP = 0x0208,

        /// <summary>
        ///
        /// </summary>
        MBUTTONDBLCLK = 0x0209,

        /// <summary>
        ///
        /// </summary>
        MOUSEWHEEL = 0x020A,

        /// <summary>
        ///
        /// </summary>
        XBUTTONDOWN = 0x020B,

        /// <summary>
        ///
        /// </summary>
        XBUTTONUP = 0x020C,

        /// <summary>
        ///
        /// </summary>
        XBUTTONDBLCLK = 0x020D,

        /// <summary>
        ///
        /// </summary>
        MOUSELAST = 0x020D,

        /// <summary>
        ///
        /// </summary>
        PARENTNOTIFY = 0x0210,

        /// <summary>
        ///
        /// </summary>
        ENTERMENULOOP = 0x0211,

        /// <summary>
        ///
        /// </summary>
        EXITMENULOOP = 0x0212,

        /// <summary>
        ///
        /// </summary>
        NEXTMENU = 0x0213,

        /// <summary>
        ///
        /// </summary>
        SIZING = 0x0214,

        /// <summary>
        ///
        /// </summary>
        CAPTURECHANGED = 0x0215,

        /// <summary>
        ///
        /// </summary>
        MOVING = 0x0216,

        /// <summary>
        ///
        /// </summary>
        POWERBROADCAST = 0x0218,

        /// <summary>
        ///
        /// </summary>
        DEVICECHANGE = 0x0219,

        /// <summary>
        ///
        /// </summary>
        MDICREATE = 0x0220,

        /// <summary>
        ///
        /// </summary>
        MDIDESTROY = 0x0221,

        /// <summary>
        ///
        /// </summary>
        MDIACTIVATE = 0x0222,

        /// <summary>
        ///
        /// </summary>
        MDIRESTORE = 0x0223,

        /// <summary>
        ///
        /// </summary>
        MDINEXT = 0x0224,

        /// <summary>
        ///
        /// </summary>
        MDIMAXIMIZE = 0x0225,

        /// <summary>
        ///
        /// </summary>
        MDITILE = 0x0226,

        /// <summary>
        ///
        /// </summary>
        MDICASCADE = 0x0227,

        /// <summary>
        ///
        /// </summary>
        MDIICONARRANGE = 0x0228,

        /// <summary>
        ///
        /// </summary>
        MDIGETACTIVE = 0x0229,

        /// <summary>
        ///
        /// </summary>
        MDISETMENU = 0x0230,

        /// <summary>
        ///
        /// </summary>
        ENTERSIZEMOVE = 0x0231,

        /// <summary>
        ///
        /// </summary>
        EXITSIZEMOVE = 0x0232,

        /// <summary>
        ///
        /// </summary>
        DROPFILES = 0x0233,

        /// <summary>
        ///
        /// </summary>
        MDIREFRESHMENU = 0x0234,

        /// <summary>
        ///
        /// </summary>
        IME_SETCONTEXT = 0x0281,

        /// <summary>
        ///
        /// </summary>
        IME_NOTIFY = 0x0282,

        /// <summary>
        ///
        /// </summary>
        IME_CONTROL = 0x0283,

        /// <summary>
        ///
        /// </summary>
        IME_COMPOSITIONFULL = 0x0284,

        /// <summary>
        ///
        /// </summary>
        IME_SELECT = 0x0285,

        /// <summary>
        ///
        /// </summary>
        IME_CHAR = 0x0286,

        /// <summary>
        ///
        /// </summary>
        IME_REQUEST = 0x0288,

        /// <summary>
        ///
        /// </summary>
        IME_KEYDOWN = 0x0290,

        /// <summary>
        ///
        /// </summary>
        IME_KEYUP = 0x0291,

        /// <summary>
        ///
        /// </summary>
        MOUSEHOVER = 0x02A1,

        /// <summary>
        ///
        /// </summary>
        MOUSELEAVE = 0x02A3,

        /// <summary>
        ///
        /// </summary>
        NCMOUSELEAVE = 0x02A2,

        /// <summary>
        ///
        /// </summary>
        WTSSESSION_CHANGE = 0x02B1,

        /// <summary>
        ///
        /// </summary>
        TABLET_FIRST = 0x02c0,

        /// <summary>
        ///
        /// </summary>
        TABLET_LAST = 0x02df,

        /// <summary>
        ///
        /// </summary>
        CUT = 0x0300,

        /// <summary>
        ///
        /// </summary>
        COPY = 0x0301,

        /// <summary>
        ///
        /// </summary>
        PASTE = 0x0302,

        /// <summary>
        ///
        /// </summary>
        CLEAR = 0x0303,

        /// <summary>
        ///
        /// </summary>
        UNDO = 0x0304,

        /// <summary>
        ///
        /// </summary>
        RENDERFORMAT = 0x0305,

        /// <summary>
        ///
        /// </summary>
        RENDERALLFORMATS = 0x0306,

        /// <summary>
        ///
        /// </summary>
        DESTROYCLIPBOARD = 0x0307,

        /// <summary>
        ///
        /// </summary>
        DRAWCLIPBOARD = 0x0308,

        /// <summary>
        ///
        /// </summary>
        PAINTCLIPBOARD = 0x0309,

        /// <summary>
        ///
        /// </summary>
        VSCROLLCLIPBOARD = 0x030A,

        /// <summary>
        ///
        /// </summary>
        SIZECLIPBOARD = 0x030B,

        /// <summary>
        ///
        /// </summary>
        ASKCBFORMATNAME = 0x030C,

        /// <summary>
        ///
        /// </summary>
        CHANGECBCHAIN = 0x030D,

        /// <summary>
        ///
        /// </summary>
        HSCROLLCLIPBOARD = 0x030E,

        /// <summary>
        ///
        /// </summary>
        QUERYNEWPALETTE = 0x030F,

        /// <summary>
        ///
        /// </summary>
        PALETTEISCHANGING = 0x0310,

        /// <summary>
        ///
        /// </summary>
        PALETTECHANGED = 0x0311,

        /// <summary>
        ///
        /// </summary>
        HOTKEY = 0x0312,

        /// <summary>
        ///
        /// </summary>
        PRINT = 0x0317,

        /// <summary>
        ///
        /// </summary>
        PRINTCLIENT = 0x0318,

        /// <summary>
        ///
        /// </summary>
        APPCOMMAND = 0x0319,

        /// <summary>
        ///
        /// </summary>
        THEMECHANGED = 0x031A,

        /// <summary>
        ///
        /// </summary>
        HANDHELDFIRST = 0x0358,

        /// <summary>
        ///
        /// </summary>
        HANDHELDLAST = 0x035F,

        /// <summary>
        ///
        /// </summary>
        AFXFIRST = 0x0360,

        /// <summary>
        ///
        /// </summary>
        AFXLAST = 0x037F,

        /// <summary>
        ///
        /// </summary>
        PENWINFIRST = 0x0380,

        /// <summary>
        ///
        /// </summary>
        PENWINLAST = 0x038F,

        /// <summary>
        ///
        /// </summary>
        USER = 0x0400,

        /// <summary>
        ///
        /// </summary>
        REFLECT = 0x2000,

        /// <summary>
        ///
        /// </summary>
        APP = 0x8000,
    }
}
