#region CopyRight 2018
/*
    Copyright (c) 2003-2018 Andreas Rohleder (andreas@rohleder.cc)
    All rights reserved
*/
#endregion
#region License MSPL
/*
    This file contains some sourcecode that uses Microsoft Windows API calls
    to provide functionality that is part of the underlying operating system.
    The API calls and their documentation are copyrighted work of Microsoft
    and/or its suppliers. Use of the Software is governed by the terms of the
    MICROSOFT LIMITED PUBLIC LICENSE.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE.MSPL file
    found at the installation directory or the distribution package.
*/
#endregion
#region License LGPL-3
/*
    This program/library/sourcecode is free software; you can redistribute it
    and/or modify it under the terms of the GNU Lesser General Public License
    version 3 as published by the Free Software Foundation subsequent called
    the License.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE file
    found at the installation directory or the distribution package.

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the
    "Software"), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be included
    in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion License
#region Authors & Contributors
/*
   Information source:
     Microsoft Corporation

   Implementation:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:
 */
#endregion

#if !NETSTANDARD20

using Cave.Media.Structs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cave.Windows
{
    /// <summary>
    /// Interface to the Windows API User32.dll
    /// </summary>
    public static class USER32
    {
        #region Capture bitmap
        /// <summary>
        /// captures a bitmap of a control with the specified window handle
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static Bitmap CaptureWindow(IntPtr hWnd)
        {
            RECT l_Rect = new RECT();
            if (!GetWindowRect(hWnd, ref l_Rect)) return null;
            // create a bitmap from the visible clipping bounds of
            //the graphics object from the window
            Bitmap bitmap = new Bitmap(l_Rect.Width, l_Rect.Height);
            // create a graphics object from the bitmap
            Graphics l_Graphics = Graphics.FromImage(bitmap);
            // get a device context for the bitmap
            IntPtr l_Target = l_Graphics.GetHdc();
            // get a device context for the window
            IntPtr l_Source = GetWindowDC(hWnd);
            // bitblt the window to the bitmap
            GDI32.SafeNativeMethods.BitBlt(l_Target, 0, 0, l_Rect.Width, l_Rect.Height, l_Source, 0, 0, GDI32.TernaryRasterOperations.SRCCOPY);
            // release the bitmap's device context
            l_Graphics.ReleaseHdc(l_Target);
            ReleaseDC(hWnd, l_Source);
            // dispose of the bitmap's graphics object
            l_Graphics.Dispose();
            // return the bitmap of the window
            return bitmap;
        }

        /// <summary>
        /// captures a bitmap of a control with the specified window handle
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static Bitmap CaptureWindow(IntPtr hWnd, RECT rect)
        {
            // create a bitmap from the visible clipping bounds of
            //the graphics object from the window
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            // create a graphics object from the bitmap
            Graphics l_Graphics = Graphics.FromImage(bitmap);
            // get a device context for the bitmap
            IntPtr l_Target = l_Graphics.GetHdc();
            // get a device context for the window
            IntPtr l_Source = GetWindowDC(hWnd);
            // bitblt the window to the bitmap
            GDI32.SafeNativeMethods.BitBlt(l_Target, 0, 0, rect.Width, rect.Height, l_Source, rect.Left, rect.Top, GDI32.TernaryRasterOperations.SRCCOPY);
            // release the bitmap's device context
            l_Graphics.ReleaseHdc(l_Target);
            ReleaseDC(hWnd, l_Source);
            // dispose of the bitmap's graphics object
            l_Graphics.Dispose();
            // return the bitmap of the window
            return bitmap;
        }

        /// <summary>
        /// captures a bitmap of the currently visible desktop (all screens) within the specified rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static Bitmap CaptureDesktop(Rectangle rectangle)
        {
            Rectangle l_ScreenRectangle = Rectangle.Empty;
            Screen[] l_Screens = Screen.AllScreens;
            // Create a rectangle encompassing all screens...
            foreach (Screen l_Screen in l_Screens) l_ScreenRectangle = Rectangle.Union(l_ScreenRectangle, l_Screen.Bounds);
            //Create target composite bitmap
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            // Get a graphics object for the composite bitmap and initialize it...
            Graphics l_Graphics = Graphics.FromImage(bitmap);
            l_Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            l_Graphics.Clear(SystemColors.Desktop);
            // Get an HDC for the composite area...
            IntPtr l_Target = l_Graphics.GetHdc();
            // Now, loop through screens, BitBlting each to the composite HDC created above...
            bool success = true;
            foreach (Screen l_Screen in l_Screens)
            {
                int x = l_Screen.Bounds.X - rectangle.X;
                int y = l_Screen.Bounds.Y - rectangle.Y;
                // Create DC for each source monitor...
                IntPtr l_Source = GDI32.SafeNativeMethods.CreateDC(IntPtr.Zero, l_Screen.DeviceName, IntPtr.Zero, IntPtr.Zero);
                success &= GDI32.SafeNativeMethods.BitBlt(l_Target, x, y, l_Screen.Bounds.Width, l_Screen.Bounds.Height, l_Source, rectangle.Left, rectangle.Top, GDI32.TernaryRasterOperations.SRCCOPY);
                // Cleanup source HDC...
                GDI32.SafeNativeMethods.DeleteDC(l_Source);
            }
            // Cleanup destination HDC and Graphics...
            l_Graphics.ReleaseHdc(l_Target);
            l_Graphics.Dispose();
            // Return composite bitmap or throw exception
            if (!success) throw new Win32ErrorException();
            return bitmap;
        }

        /// <summary>
        /// captures a bitmap of the currently visible desktop (all screens)
        /// </summary>
        /// <returns></returns>
        public static Bitmap CaptureDesktop()
        {
            Win32ErrorException l_Error = null;
            Rectangle l_ScreenRectangle = Rectangle.Empty;
            Screen[] l_Screens = Screen.AllScreens;
            // Create a rectangle encompassing all screens...
            foreach (Screen l_Screen in l_Screens) l_ScreenRectangle = Rectangle.Union(l_ScreenRectangle, l_Screen.Bounds);
            //Create target composite bitmap
            Bitmap bitmap = new Bitmap(l_ScreenRectangle.Width, l_ScreenRectangle.Height);
            // Get a graphics object for the composite bitmap and initialize it...
            Graphics l_Graphics = Graphics.FromImage(bitmap);
            l_Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            l_Graphics.Clear(SystemColors.Desktop);
            // Get an HDC for the composite area...
            IntPtr l_Target = l_Graphics.GetHdc();
            // Now, loop through screens, BitBlting each to the composite HDC created above...
            foreach (Screen l_Screen in l_Screens)
            {
                // Create DC for each source monitor...
                IntPtr l_Source = GDI32.SafeNativeMethods.CreateDC(IntPtr.Zero, l_Screen.DeviceName, IntPtr.Zero, IntPtr.Zero);
                // Blt the source directly to the composite destination...
                int x = l_Screen.Bounds.X - l_ScreenRectangle.X;
                int y = l_Screen.Bounds.Y - l_ScreenRectangle.Y;
                bool l_ThisOne = GDI32.SafeNativeMethods.StretchBlt(l_Target, x, y, l_Screen.Bounds.Width, l_Screen.Bounds.Height, l_Source, 0, 0, l_Screen.Bounds.Width, l_Screen.Bounds.Height, GDI32.TernaryRasterOperations.SRCCOPY);
                if (!l_ThisOne)
                {
                    l_Error = new Win32ErrorException();
                }
                // Cleanup source HDC...
                GDI32.SafeNativeMethods.DeleteDC(l_Source);
                if (!l_ThisOne) break;
            }
            // Cleanup destination HDC and Graphics...
            l_Graphics.ReleaseHdc(l_Target);
            l_Graphics.Dispose();
            // Return composite bitmap or throw exception
            if (l_Error != null) throw l_Error;
            return bitmap;
        }
        #endregion

        #region function imports

        /// <summary>
        /// Logs off the interactive user, shuts down the system, or shuts down and restarts the system. It sends the WM_QUERYENDSESSION message to all applications to determine if they can be terminated.
        /// </summary>
        /// <param name="uFlags"></param>
        /// <param name="dwReason"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(EWX uFlags, int dwReason);

        /// <summary>
        /// The GetWindowModuleFileName function retrieves the full path and file name of the module associated with the specified window handle.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowModuleFileName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order. This parameter must be a window handle.</param>
        /// <param name="X">The new position of the left side of the window, in client coordinates. </param>
        /// <param name="Y">The new position of the top of the window, in client coordinates. </param>
        /// <param name="Width">The new width of the window, in pixels. </param>
        /// <param name="Height">The new height of the window, in pixels. </param>
        /// <param name="Flags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int Width, int Height, SWP Flags);

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="Mode"></param>
        /// <param name="X">The new position of the left side of the window, in client coordinates. </param>
        /// <param name="Y">The new position of the top of the window, in client coordinates. </param>
        /// <param name="Width">The new width of the window, in pixels. </param>
        /// <param name="Height">The new height of the window, in pixels. </param>
        /// <param name="Flags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowPos(IntPtr hWnd, HWND_MODE Mode, int X, int Y, int Width, int Height, SWP Flags);

        /// <summary>
        /// The GetWindowPlacement function retrieves the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetWindowPlacement(IntPtr window, ref WINDOWPLACEMENT position);

        /// <summary>
        /// The RegisterWindowMessage function defines a new window message that is guaranteed to be unique throughout the system. The message value can be used when sending or posting messages.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int RegisterWindowMessage(string message);

        /// <summary>
        /// The GetWindowText function copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is a control, the text of the control is copied. However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control containing the text.</param>
        /// <param name="lpString">The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.</param>
        /// <param name="nMaxCount">The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// The GetClassName function retrieves the name of the class to which the specified window belongs.
        /// </summary>
        public static string GetWindowText(IntPtr hWnd)
        {
            int size = 1024;
            while (true)
            {
                StringBuilder stringBuilder = new StringBuilder(size);
                int l_Read = GetWindowText(hWnd, stringBuilder, size);
                if (l_Read < size) return stringBuilder.ToString();
                size *= 2;
            }
        }

        /// <summary>
        /// The IsWindowVisible function retrieves the visibility state of the specified window.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// The GetWindow function retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="wCmd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetWindow(IntPtr hWnd, int wCmd);

        /// <summary>
        /// The GetWindowLong function retrieves information about the specified window. The function also retrieves the 32-bit (long) value at the specified offset into the extra window ...
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern WS GetWindowLong(IntPtr hWnd, GWL Index);

        /// <summary>
        /// Changes an attribute of the specified window. The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
        /// Note: This function has been superseded by the SetWindowLongPtr function. To write code that is compatible with both 32-bit and 64-bit versions of Windows, use the SetWindowLongPtr function
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="Index">The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. To set any other value, specify one of the following values. </param>
        /// <param name="dwNewLong">The replacement value. </param>
        /// <returns>If the function succeeds, the return value is the previous value of the specified 32-bit integer.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. </returns>
        [DllImport("user32.dll")]
        public static extern WS SetWindowLong(IntPtr hWnd, GWL Index, WS dwNewLong);

        /// <summary>
        /// Changes an attribute of the specified window. The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
        /// Note: This function has been superseded by the SetWindowLongPtr function. To write code that is compatible with both 32-bit and 64-bit versions of Windows, use the SetWindowLongPtr function
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. To set any other value, specify one of the following values. </param>
        /// <param name="dwNewValue">The replacement value. </param>
        /// <returns>If the function succeeds, the return value is the previous value of the specified 32-bit integer.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewValue);

        /// <summary>
        /// The GetParent function retrieves a handle to the specified window's parent or owner. To retrieve a handle to a specified ancestor, use the GetAncestor function.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        /// <summary>
        /// The GetClassName function retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpClassName"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// The GetClassName function retrieves the name of the class to which the specified window belongs.
        /// </summary>
        public static string GetClassName(IntPtr hWnd)
        {
            int size = 1024;
            while (true)
            {
                StringBuilder stringBuilder = new StringBuilder(size);
                int l_Read = USER32.GetClassName(hWnd, stringBuilder, size);
                if (l_Read < size) return stringBuilder.ToString();
                size *= 2;
            }
        }

        /// <summary>
        /// Sends the specified message to one of more windows.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="fuFlags"></param>
        /// <param name="uTimeout"></param>
        /// <param name="lpdwResult"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessageTimeout(IntPtr hWnd, uint uMsg, int wParam, int lParam, int fuFlags, int uTimeout, out int lpdwResult);

        /// <summary>
        /// The GetClassLong function retrieves the specified 32-bit (long) value from the WNDCLASSEX structure associated with the specified window.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetClassLong(IntPtr hWnd, int index);

        /// <summary>
        /// The GetWindowThreadProcessId function retrieves the identifier of the thread that created the specified window and, optionally, the identifier of the process that created the ...
        /// </summary>
        /// <param name="hWnd">A handle to the window. </param>
        /// <param name="processId">A pointer to a variable that receives the process identifier. If this parameter is not NULL, GetWindowThreadProcessId copies the identifier of the process to the variable; otherwise, it does not. </param>
        /// <returns>The return value is the identifier of the thread that created the window. </returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="hWnd">
        /// [in] Handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
        /// Microsoft Windows Vista and later. Message sending is subject to User Interface Privilege Isolation (UIPI). The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.</param>
        /// <param name="uMsg">[in] Specifies the message to be sent.</param>
        /// <param name="wParam">[in] Specifies additional message-specific information.</param>
        /// <param name="lParam">[in] Specifies additional message-specific information.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Switches focus to the specified window and brings it to the foreground.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="altTabActivated"></param>
        [Obsolete("[This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.]")]
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, int altTabActivated);

        /// <summary>
        /// Sets the show state of a window without waiting for the operation to complete.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ShowWindowAsync(IntPtr hWnd, int command);

        /// <summary>
        /// Brings the specified window to the top of the Z order. If the window is a top-level window, it is activated. If the window is a child window, the top-level parent window associated with the child window is activated.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool BringWindowToTop(IntPtr window);

        /// <summary>
        /// Retrieves information about the specified window.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO info);

        /// <summary>
        /// The GetWindowDC function retrieves the device context (DC) for the entire window, including title bar, menus, and scroll bars. A window device context permits painting anywhere in a window, because the origin of the device context is the upper-left corner of the window instead of the client area.
        /// GetWindowDC assigns default attributes to the window device context each time it retrieves the device context. Previous attributes are lost.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
        /// The GetDCEx function is an extension to GetDC, which gives an application more control over how and whether clipping occurs in the client area.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        /// <summary>
        /// The ReleaseDC function releases a device context (DC), freeing it for use by other applications. The effect of the ReleaseDC function depends on the type of DC. It frees only common and window DCs. It has no effect on class or private DCs.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref RECT rectangle);

        /// <summary>
        /// Retrieves the coordinates of a window's client area. The client coordinates specify the upper-left and lower-right corners of the client area. Because client coordinates are relative to the upper-left corner of a window's client area, the coordinates of the upper-left corner are (0,0).
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hwnd, ref RECT rectangle);

        /// <summary>
        /// The ClientToScreen function converts the client-area coordinates of a specified point to screen coordinates.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hwnd, ref Point point);

        /// <summary>
        /// Retrieves a handle to the window that contains the specified point.
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point pt);

        /// <summary>
        /// Sets the mouse capture to the specified window belonging to the current thread.SetCapture captures mouse input either when the mouse is over the capturing window, or when the mouse button was pressed while the mouse was over the capturing window and the button is still down. Only one window at a time can capture the mouse.
        /// If the mouse cursor is over a window created by another thread, the system will direct mouse input to the specified window only if a mouse button is down.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);

        /// <summary>
        /// Releases the mouse capture from a window in the current thread and restores normal mouse input processing. A window that has captured the mouse receives all mouse input, regardless of the position of the cursor, except when a mouse button is clicked while the cursor hot spot is in the window of another thread.
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ReleaseCapture();

        /// <summary>
        /// The SelectObject function selects an object into the specified device context (DC). The new object replaces the previous object of the same type.
        /// </summary>
        /// <param name="hDc"></param>
        /// <param name="hObject"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDc, IntPtr hObject);

        /// <summary>
        /// The GetStockObject function retrieves a handle to one of the stock pens, brushes, fonts, or palettes.
        /// </summary>
        /// <param name="nObject"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetStockObject(int nObject);

        /// <summary>
        /// The InvalidateRect function adds a rectangle to the specified window's update region. The update region represents the portion of the window's client area that must be redrawn.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <param name="bErase"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int InvalidateRect(IntPtr hWnd, IntPtr lpRect, int bErase);

        /// <summary>
        /// The UpdateWindow function updates the client area of the specified window by sending a WM_PAINT message to the window if the window's update region is not empty. The function sends a WM_PAINT message directly to the window procedure of the specified window, bypassing the application queue. If the update region is empty, no message is sent.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int UpdateWindow(IntPtr hWnd);

        /// <summary>
        /// The RedrawWindow function updates the specified rectangle or region in a window's client area.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lprcUpdate"></param>
        /// <param name="hrgnUpdate"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

        /// <summary>
        /// Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to monitor the system for certain types of events. These events are associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="idHook">The type of hook procedure to be installed. This parameter can be one of the following values. </param>
        /// <param name="lpfn">A pointer to the hook procedure. If the dwThreadId parameter is zero or specifies the identifier of a thread created by a different process, the lpfn parameter must point to a hook procedure in a DLL. Otherwise, lpfn can point to a hook procedure in the code associated with the current process. </param>
        /// <param name="hMod">A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. The hMod parameter must be set to NULL if the dwThreadId parameter specifies a thread created by the current process and if the hook procedure is within the code associated with the current process. </param>
        /// <param name="dwThreadId">The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same desktop as the calling thread. For Windows Store apps, see the Remarks section.</param>
        /// <returns>If the function succeeds, the return value is the handle to the hook procedure. If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(WH idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

        /// <summary>
        /// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        /// </summary>
        /// <param name="hhk">A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to SetWindowsHookEx. </param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        /// <summary>
        /// Passes the hook information to the next hook procedure in the current hook chain. A hook procedure can call this function either before or after processing the hook information.
        /// </summary>
        /// <param name="hhk">This parameter is ignored. </param>
        /// <param name="nCode">The hook code passed to the current hook procedure. The next hook procedure uses this code to determine how to process the hook information.</param>
        /// <param name="wParam">The wParam value passed to the current hook procedure. The meaning of this parameter depends on the type of hook associated with the current hook chain.</param>
        /// <param name="lParam">The lParam value passed to the current hook procedure. The meaning of this parameter depends on the type of hook associated with the current hook chain.</param>
        /// <returns>This value is returned by the next hook procedure in the chain. The current hook procedure must also return this value. The meaning of the return value depends on the hook type. For more information, see the descriptions of the individual hook procedures.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int CallNextHookEx(IntPtr hhk, int nCode, UIntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Method delegate for implementing hooks
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate int HookProc(int nCode, UIntPtr wParam, IntPtr lParam);

        /// <summary>
        /// translates the specified virtual-key code and keyboard state to the corresponding character or characters
        /// </summary>
        /// <param name="uVirtKey"></param>
        /// <param name="uScanCode"></param>
        /// <param name="lpbKeyState"></param>
        /// <param name="lpwTransKey"></param>
        /// <param name="fuState"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        /// <summary>
        /// copies the status of the 256 virtual keys to the specified buffer
        /// </summary>
        /// <param name="pbKeyState"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        /// <summary>
        /// retrieves the status of the specified virtual key
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern short GetKeyState(int vKey);

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings
        /// </summary>
        /// <param name="lpClassName">
        /// [in] Pointer to a null-terminated string that specifies the class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero.
        /// If lpClassName points to a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names.
        /// If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter.
        /// </param>
        /// <param name="lpWindowName">
        /// [in] Pointer to a null-terminated string that specifies the window name (the window's title). If this parameter is NULL, all window names match.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// Retrieves a handle to a window whose class name and window name match the specified strings
        /// </summary>
        /// <param name="hWndParent">
        /// [in] Handle to the parent window whose child windows are to be searched.
        /// If hwndParent is NULL, the function uses the desktop window as the parent window. The function searches among windows that are child windows of the desktop.
        /// Microsoft Windows 2000 and Windows XP: If hwndParent is HWND_MESSAGE, the function searches all message-only windows.
        /// </param>
        /// <param name="hWndChildAfter">
        /// [in] Handle to a child window. The search begins with the next child window in the Z order. The child window must be a direct child window of hwndParent, not just a descendant window.
        /// If hwndChildAfter is NULL, the search begins with the first child window of hwndParent.
        /// Note that if both hwndParent and hwndChildAfter are NULL, the function searches all top-level and message-only windows.
        /// </param>
        /// <param name="lpClassName">
        /// [in] Pointer to a null-terminated string that specifies the class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be placed in the low-order word of lpszClass; the high-order word must be zero.
        /// If lpszClass is a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names, or it can be MAKEINTATOM(0x800). In this latter case, 0x8000 is the atom for a menu class. For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="lpWindowName">
        /// [in] Pointer to a null-terminated string that specifies the window name (the window's title). If this parameter is NULL, all window names match.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpClassName, string lpWindowName);

        /// <summary>
        /// puts the thread that created the specified window into the foreground and activates the window
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        /// <summary>
        /// method delegate used for EnumWindows calls.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate bool EnumWindowsDelegate(IntPtr hwnd, IntPtr lParam);

        /// <summary>
        /// returns a handle to the foreground window (the window with which the user is currently working)
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function
        /// </summary>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr EnumWindows(EnumWindowsDelegate lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// enumerates the child windows that belong to the specified parent window by passing the handle to each child window, in turn, to an application-defined callback function.
        /// </summary>
        /// <param name="hWndParent"></param>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool EnumChildWindows(IntPtr hWndParent, Delegate lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar).
        /// </summary>
        /// <param name="hwnd">[in] Handle to the window or control. </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hwnd);

        /// <summary>
        /// Returns a handle to the desktop window
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Examines the Z order of the child windows associated with the specified parent window and retrieves a handle to the child window at the top of the Z order.
        /// </summary>
        /// <param name="hwnd">[in] Handle to the parent window whose child windows are to be examined. If this parameter is NULL, the function returns a handle to the window at the top of the Z order.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetTopWindow(IntPtr hwnd);

        /// <summary>
        /// sets the specified window's show state.
        /// </summary>
        /// <param name="hWnd">Handle to the window</param>
        /// <param name="nCmdShow">Specifies how the window is to be shown. This parameter is ignored the first time an application calls ShowWindow, if the program that launched the application provides a STARTUPINFO structure. Otherwise, the first time ShowWindow is called, the value should be the value obtained by the WinMain function in its nCmdShow parameter. In subsequent calls, this parameter can be one of the following values. </param>
        /// <returns>If the window was previously visible, the return value is nonzero.If the window was previously hidden, the return value is zero. </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(IntPtr hWnd, SW nCmdShow);

        /// <summary>
        /// changes the parent window of the specified child window.
        /// </summary>
        /// <param name="hWndChild">Handle to the child window. </param>
        /// <param name="hWndNewParent">Handle to the new parent window. If this parameter is NULL, the desktop window becomes the new parent window. Windows 2000/XP: If this parameter is HWND_MESSAGE, the child window becomes a message-only window. </param>
        /// <returns>If the function succeeds, the return value is a handle to the previous parent window. If the function fails, the return value is NULL. To get extended error information, call GetLastError. </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        class FindWindowHelper
        {
            public string ClassName;
            public string Caption;
            public List<CONTROL> Results = new List<CONTROL>();

            public FindWindowHelper(string className, string caption)
            {
                ClassName = className;
                Caption = caption;
            }

            bool m_CheckWindow(IntPtr hWnd, IntPtr lParam)
            {
                if (Caption != null)
                {
                    StringBuilder caption = new StringBuilder(255);
                    GetWindowText(hWnd, caption, 255);
                    if (caption.ToString() != Caption) return true;
                }
                if (ClassName != null)
                {
                    StringBuilder className = new StringBuilder(255);
                    GetClassName(hWnd, className, 255);
                    if (className.ToString() != ClassName) return true;
                }
                Results.Add(new CONTROL(hWnd));
                return true;
            }

            public void FindWindow(IntPtr parent)
            {
                EnumChildWindows(parent, new EnumWindowsDelegate(m_CheckWindow), IntPtr.Zero);
            }
        }

        /// <summary>
        /// Finds child windows with the specified ClassName (exact match) and/or Caption (contain match).
        /// This function walks through the complete tree of children.
        /// </summary>
        /// <param name="hWndParent"></param>
        /// <param name="className"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static CONTROL[] FindWindows(IntPtr hWndParent, string className, string caption)
        {
            FindWindowHelper l_Helper = new FindWindowHelper(className, caption);
            l_Helper.FindWindow(hWndParent);
            return l_Helper.Results.ToArray();
        }

        /// <summary>
        /// Sends a key press to the specified window
        /// </summary>
        /// <param name="hWndTarget">target window</param>
        /// <param name="virtualKey">virtual key code</param>
        /// <param name="scanCode">scan code of the key</param>
        /// <param name="duration">Duration in milli seconds</param>
        public static void SendKeyPress(IntPtr hWndTarget, VK virtualKey, int scanCode, int duration)
        {
            //repeat one time
            int l_LParam = 0;
            //scan code
            l_LParam += (scanCode << 16);
            //post message
            PostMessage(hWndTarget, (uint)WM.KEYDOWN, (IntPtr)virtualKey, new IntPtr(l_LParam));
            //wait
            if (duration > 0) Thread.Sleep(duration);
            //release key that was down before
            l_LParam |= 0x03 << 30;
            //post message
            PostMessage(hWndTarget, (uint)WM.KEYUP, (IntPtr)virtualKey, new IntPtr(l_LParam));
        }
        #endregion
    }
}

#endif