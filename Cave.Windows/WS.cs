using System;
using System.Diagnostics.CodeAnalysis;

namespace Cave.Windows
{
    /// <summary>
    /// The following styles can be specified wherever a window style is required. After the control has been created, these styles cannot be modified, except as noted.
    /// </summary>
    [Flags]
    [SuppressMessage("Design", "CA1069")]
    public enum WS : uint
    {
        /// <summary>
        /// Creates a window that has a thin-line border.
        /// </summary>
        BORDER = 0x800000,
        /// <summary>
        /// Creates a window that has a title bar (includes the BORDER style).
        /// </summary>
        CAPTION = (BORDER | DLGFRAME),
        /// <summary>
        /// Creates a child window. A window with this style cannot have a menu bar. This style cannot be used with the POPUP style.
        /// </summary>
        CHILD = 0x40000000,
        /// <summary>
        /// Same as the CHILD style.
        /// </summary>
        CHILDWINDOW = (CHILD),
        /// <summary>
        /// Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.
        /// </summary>
        CLIPCHILDREN = 0x2000000,
        /// <summary>
        /// Clips child windows relative to each other; that is, when a particular child window receives a WM_PAINT message, the CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated. If CLIPSIBLINGS is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
        /// </summary>
        CLIPSIBLINGS = 0x4000000,
        /// <summary>
        /// Creates a window that is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created, use EnableWindow.
        /// </summary>
        DISABLED = 0x8000000,
        /// <summary>
        /// Creates a window that has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.
        /// </summary>
        DLGFRAME = 0x400000,
        /// <summary>
        /// Specifies the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the GROUP style. The first control in each group usually has the TABSTOP style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys.
        /// You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use SetWindowLong.
        /// </summary>
        GROUP = 0x20000,
        /// <summary>
        /// Creates a window that has a horizontal scroll bar.
        /// </summary>
        HSCROLL = 0x100000,
        /// <summary>
        /// Creates a window that is initially minimized. Same as the MINIMIZE style.
        /// </summary>
        ICONIC = MINIMIZE,
        /// <summary>
        /// Creates a window that is initially maximized.
        /// </summary>
        MAXIMIZE = 0x1000000,
        /// <summary>
        /// Creates a window that has a maximize button. Cannot be combined with the EX_CONTEXTHELP style. The SYSMENU style must also be specified.
        /// </summary>
        MAXIMIZEBOX = 0x10000,
        /// <summary>
        /// Creates a window that is initially minimized. Same as the ICONIC style.
        /// </summary>
        MINIMIZE = 0x20000000,
        /// <summary>
        /// Creates a window that has a minimize button. Cannot be combined with the EX_CONTEXTHELP style. The SYSMENU style must also be specified.
        /// </summary>
        MINIMIZEBOX = 0x20000,
        /// <summary>
        /// Creates an overlapped window. An overlapped window has a title bar and a border. Same as the TILED style.
        /// </summary>
        OVERLAPPED = 0x0,
        /// <summary>
        /// Creates an overlapped window with the OVERLAPPED, CAPTION, SYSMENU, THICKFRAME, MINIMIZEBOX, and MAXIMIZEBOX styles. Same as the TILEDWINDOW style.
        /// </summary>
        OVERLAPPEDWINDOW = (OVERLAPPED | CAPTION | SYSMENU | THICKFRAME | MINIMIZEBOX | MAXIMIZEBOX),
        /// <summary>
        /// Creates a pop-up window. This style cannot be used with the CHILD style.
        /// </summary>
        POPUP = 0x80000000,
        /// <summary>
        /// Creates a pop-up window with BORDER, POPUP, and SYSMENU styles. The CAPTION and POPUPWINDOW styles must be combined to make the window menu visible.
        /// </summary>
        POPUPWINDOW = (POPUP | BORDER | SYSMENU),
        /// <summary>
        /// Creates a window that has a sizing border. Same as the THICKFRAME style.
        /// </summary>
        SIZEBOX = THICKFRAME,
        /// <summary>
        /// Creates a window that has a window menu on its title bar. The CAPTION style must also be specified.
        /// </summary>
        SYSMENU = 0x80000,
        /// <summary>
        /// Specifies a control that can receive the keyboard focus when the user presses the TAB key. Pressing the TAB key changes the keyboard focus to the next control with the TABSTOP style.
        /// You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use SetWindowLong.
        /// </summary>
        TABSTOP = 0x10000,
        /// <summary>
        /// Creates a window that has a sizing border. Same as the SIZEBOX style.
        /// </summary>
        THICKFRAME = 0x40000,
        /// <summary>
        /// Creates an overlapped window. An overlapped window has a title bar and a border. Same as the OVERLAPPED style.
        /// </summary>
        TILED = OVERLAPPED,
        /// <summary>
        /// Creates an overlapped window with the OVERLAPPED, CAPTION, SYSMENU, THICKFRAME, MINIMIZEBOX, and MAXIMIZEBOX styles. Same as the OVERLAPPEDWINDOW style.
        /// </summary>
        TILEDWINDOW = (OVERLAPPED | CAPTION | SYSMENU | THICKFRAME | MINIMIZEBOX | MAXIMIZEBOX),
        /// <summary>
        /// Creates a window that is initially visible.
        /// This style can be turned on and off by using ShowWindow or SetWindowPos.
        /// </summary>
        VISIBLE = 0x10000000,
        /// <summary>
        /// Creates a window that has a vertical scroll bar.
        /// </summary>
        VSCROLL = 0x200000,
        /// <summary>
        /// The window accepts drag-drop files.
        /// </summary>
        EX_ACCEPTFILES = 0x10,

        /// <summary>
        ///
        /// </summary>
        EX_NOPARENTNOTIFY = 0x4,

        /// <summary>
        ///
        /// </summary>
        EX_TOPMOST = 0x8,

        /// <summary>
        ///
        /// </summary>
        EX_TRANSPARENT = 0x20,

        /// <summary>
        ///
        /// </summary>
        EX_TOOLWINDOW = 0x80,

        /// <summary>
        /// Forces a top-level window onto the taskbar when the window is visible.
        /// </summary>
        EX_APPWINDOW = 0x40000,

        /// <summary>
        /// The window has a border with a sunken edge.
        /// </summary>
        EX_CLIENTEDGE = 0x200,

        /// <summary>
        /// Creates a window with a three-dimensional border style intended to be used for items that do not accept user input.
        /// </summary>
        EX_STATICEDGE = 0x00020000,

        /// <summary>
        /// Paints all descendants of a window in bottom-to-top painting order using double-buffering. For more information, see Remarks. This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.
        /// Windows 2000:  This style is not supported.
        /// </summary>
        EX_COMPOSITED = 0x02000000,

        /// <summary>
        /// The title bar of the window includes a question mark. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command. The Help application displays a pop-up window that typically contains help for the child window.
        /// WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
        /// </summary>
        EX_CONTEXTHELP = 0x00000400,

        /// <summary>
        /// The window itself contains child windows that should take part in dialog box navigation. If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
        /// </summary>
        EX_CONTROLPARENT = 0x00010000,

        /// <summary>
        /// 0x00000001L
        /// </summary>
        EX_DLGMODALFRAME = 0x00000001,

        /// <summary>
        /// The window is a layered window. This style cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.
        /// Windows 8:  The WS_EX_LAYERED style is supported for top-level windows and child windows. Previous Windows versions support WS_EX_LAYERED only for top-level windows.
        /// </summary>
        EX_LAYERED = 0x00080000,
    }
}
