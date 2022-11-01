#if NET20_OR_GREATER

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cave.Windows
{
    /// <summary>
    /// This class allows you to tap keyboard and mouse and / or to detect their activity even when an
    /// application runs in background or does not have any user interface at all. This class raises
    /// common .NET events with KeyEventArgs and MouseEventArgs so you can easily retrieve any information you need.
    /// </summary>
    public sealed class INPUTACTIVITYHOOK : IDisposable
    {
        /// <summary>
        /// Creates an instance of UserActivityHook object and sets mouse and keyboard hooks.
        /// </summary>
        /// <exception cref="Win32ErrorException">Any windows problem.</exception>
        public INPUTACTIVITYHOOK() => Start();

        /// <summary>
        /// Uninstall hooks and do not throw exceptions
        /// </summary>
        ~INPUTACTIVITYHOOK() => Stop(false);

        /// <summary>
        /// Occurs when the user moves the mouse, presses any mouse button or scrolls the wheel
        /// </summary>
        public event MouseEventHandler MouseActivity;

        /// <summary>
        /// Occurs when the user presses a key
        /// </summary>
        public event KeyEventHandler KeyDown;

        /// <summary>
        /// Occurs when the user presses and releases
        /// </summary>
        public event KeyPressEventHandler KeyPress;

        /// <summary>
        /// Occurs when the user releases a key
        /// </summary>
        public event KeyEventHandler KeyUp;

        /// <summary>
        /// Stores the handle to the mouse hook procedure.
        /// </summary>
        private IntPtr hMouseHook;

        /// <summary>
        /// Stores the handle to the keyboard hook procedure.
        /// </summary>
        private IntPtr hKeyboardHook;

        /// <summary>
        /// Declare MouseHookProcedure as HookProc type.
        /// </summary>
        private static USER32.HookProc mouseHookProcedure;

        /// <summary>
        /// Declare KeyboardHookProcedure as HookProc type.
        /// </summary>
        private static USER32.HookProc keyboardHookProcedure;

        /// <summary>
        /// Installs both or one of mouse and/or keyboard hooks and starts rasing events
        /// </summary>
        /// <exception cref="Win32ErrorException">Any windows problem.</exception>
        public void Start()
        {
            // install Mouse hook only if it is not installed and must be installed
            if (hMouseHook == IntPtr.Zero)
            {
                // Create an instance of HookProc.
                mouseHookProcedure = new USER32.HookProc(MouseHookProc);
                //install hook
                hMouseHook = USER32.SetWindowsHookEx(WH.MOUSE_LL, mouseHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                //If SetWindowsHookEx fails.
                KERNEL32.CheckLastError();
                if (hMouseHook == IntPtr.Zero)
                {
                    //do cleanup
                    Stop(false);
                    throw new Win32ErrorException();
                }
            }

            // install Keyboard hook only if it is not installed and must be installed
            if (hKeyboardHook == IntPtr.Zero)
            {
                // Create an instance of HookProc.
                keyboardHookProcedure = new USER32.HookProc(KeyboardHookProc);
                //install hook
                hKeyboardHook = USER32.SetWindowsHookEx(WH.KEYBOARD_LL, keyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                //If SetWindowsHookEx fails.
                KERNEL32.CheckLastError();
                if (hKeyboardHook == IntPtr.Zero)
                {
                    //do cleanup
                    Stop(false);
                    throw new Win32ErrorException();
                }
            }
        }

        /// <summary>
        /// Stops monitoring both mouse and keyboard events and rasing events.
        /// </summary>
        /// <exception cref="Win32ErrorException">Any windows problem.</exception>
        public void Stop() => Stop(true);

        /// <summary>
        /// Stops monitoring both or one of mouse and/or keyboard events and rasing events.
        /// </summary>
        /// <param name="throwExceptions"><b>true</b> if exceptions which occured during uninstalling must be thrown</param>
        /// <exception cref="Win32ErrorException">Any windows problem.</exception>
        public void Stop(bool throwExceptions)
        {
            Exception resultMouse = null;
            Exception resultKeyboard = null;

            //if mouse hook set and must be uninstalled
            if (hMouseHook != IntPtr.Zero)
            {
                //uninstall hook
                resultMouse = USER32.UnhookWindowsHookEx(hMouseHook) ? null : new Exception("Could not uninstall mouse hook!");
                //reset invalid handle
                hMouseHook = IntPtr.Zero;
            }

            //if keyboard hook set and must be uninstalled
            if (hKeyboardHook != IntPtr.Zero)
            {
                //uninstall hook
                resultKeyboard = USER32.UnhookWindowsHookEx(hKeyboardHook) ? null : new Exception("Could not uninstall keyboard hook!");
                //reset invalid handle
                hKeyboardHook = IntPtr.Zero;
                //if failed and exception must be thrown
            }

            //if failed and exception must be thrown
            if (throwExceptions && (resultKeyboard != null || resultMouse != null))
            {
                if (resultKeyboard is null) throw resultMouse;
                if (resultMouse is null) throw resultKeyboard;
                throw new AggregateException(resultMouse, resultKeyboard);
            }
        }

        /// <summary>
        /// A callback function which will be called every time a mouse activity detected.
        /// </summary>
        /// <param name="nCode">
        /// [in] Specifies whether the hook procedure must process the message.
        /// If nCode is HC_ACTION, the hook procedure must process the message.
        /// If nCode is less than zero, the hook procedure must pass the message to the
        /// CallNextHookEx function without further processing and must return the
        /// value returned by CallNextHookEx.
        /// </param>
        /// <param name="wParam">
        /// [in] Specifies whether the message was sent by the current thread.
        /// If the message was sent by the current thread, it is nonzero; otherwise, it is zero.
        /// </param>
        /// <param name="lParam">
        /// [in] Pointer to a CWPSTRUCT structure that contains details about the message.
        /// </param>
        /// <returns>
        /// If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
        /// If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx
        /// and return the value it returns; otherwise, other applications that have installed WH_CALLWNDPROC
        /// hooks will not receive hook notifications and may behave incorrectly as a result. If the hook
        /// procedure does not call CallNextHookEx, the return value should be zero.
        /// </returns>
        private int MouseHookProc(int nCode, UIntPtr wParam, IntPtr lParam)
        {
            // if ok and someone listens to our events
            if ((nCode >= 0) && (MouseActivity != null))
            {
                //Marshall the data from callback.
                var mouseHookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                //detect button clicked
                var button = MouseButtons.None;
                short mouseDelta = 0;
                switch ((WM)wParam)
                {
                    case WM.LBUTTONDOWN:
                        //case WM_LBUTTONUP:
                        //case WM_LBUTTONDBLCLK:
                        button = MouseButtons.Left;
                        break;
                    case WM.RBUTTONDOWN:
                        //case WM_RBUTTONUP:
                        //case WM_RBUTTONDBLCLK:
                        button = MouseButtons.Right;
                        break;
                    case WM.MOUSEWHEEL:
                        //If the message is WM_MOUSEWHEEL, the high-order word of mouseData member is the wheel delta.
                        //One wheel click is defined as WHEEL_DELTA, which is 120.
                        //(value >> 16) & 0xffff; retrieves the high-order word from the specified 32-bit value
                        mouseDelta = (short)((mouseHookStruct.mouseData >> 16) & 0xffff);
                        //TODO: X BUTTONS
                        //If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP,
                        //or WM_NCXBUTTONDBLCLK, the high-order word specifies which X button was pressed or released,
                        //and the low-order word is reserved. This value can be one or more of the following values.
                        //Otherwise, mouseData is not used.
                        break;
                }

                //double clicks
                var clickCount = 0;
                if (button != MouseButtons.None)
                {
                    if ((WM)wParam == WM.LBUTTONDBLCLK || (WM)wParam == WM.RBUTTONDBLCLK)
                    {
                        clickCount = 2;
                    }
                    else
                    {
                        clickCount = 1;
                    }
                }

                //generate event
                var e = new MouseEventArgs(button, clickCount, mouseHookStruct.pt.x, mouseHookStruct.pt.y, mouseDelta);
                //raise it
                MouseActivity(this, e);
            }
            //call next hook
            return USER32.CallNextHookEx(hMouseHook, nCode, wParam, lParam);
        }

        /// <summary>
        /// A callback function which will be called every time a keyboard activity detected.
        /// </summary>
        /// <param name="nCode">
        /// [in] Specifies whether the hook procedure must process the message.
        /// If nCode is HC_ACTION, the hook procedure must process the message.
        /// If nCode is less than zero, the hook procedure must pass the message to the
        /// CallNextHookEx function without further processing and must return the
        /// value returned by CallNextHookEx.
        /// </param>
        /// <param name="wParam">
        /// [in] Specifies whether the message was sent by the current thread.
        /// If the message was sent by the current thread, it is nonzero; otherwise, it is zero.
        /// </param>
        /// <param name="lParam">
        /// [in] Pointer to a CWPSTRUCT structure that contains details about the message.
        /// </param>
        /// <returns>
        /// If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
        /// If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx
        /// and return the value it returns; otherwise, other applications that have installed WH_CALLWNDPROC
        /// hooks will not receive hook notifications and may behave incorrectly as a result. If the hook
        /// procedure does not call CallNextHookEx, the return value should be zero.
        /// </returns>
        private int KeyboardHookProc(int nCode, UIntPtr wParam, IntPtr lParam)
        {
            //indicates if any of underlaing events set e.Handled flag
            var handled = false;
            //it was ok and someone listens to events
            if ((nCode >= 0) && (KeyDown != null || KeyUp != null || KeyPress != null))
            {
                //read structure KeyboardHookStruct at lParam
                var keyboardHookStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure((IntPtr)lParam, typeof(KBDLLHOOKSTRUCT));
                //raise KeyDown
                if (KeyDown != null && ((WM)wParam == WM.KEYDOWN || (WM)wParam == WM.SYSKEYDOWN))
                {
                    var keyData = (Keys)keyboardHookStruct.vkCode;
                    var e = new KeyEventArgs(keyData);
                    KeyDown(this, e);
                    handled |= e.Handled;
                }

                // raise KeyPress
                if (KeyPress != null && (WM)wParam == WM.KEYDOWN)
                {
                    var isDownShift = ((USER32.GetKeyState((int)VK.SHIFT) & 0x80) == 0x80);
                    var isDownCapslock = (USER32.GetKeyState((int)VK.CAPITAL) != 0);

                    var keyState = new byte[256];
                    USER32.GetKeyboardState(keyState).ThrowOnError();
                    var inBuffer = new byte[2];
                    if (USER32.ToAscii(keyboardHookStruct.vkCode, keyboardHookStruct.scanCode, keyState, inBuffer, keyboardHookStruct.flags) == 1)
                    {
                        var key = (char)inBuffer[0];
                        if ((isDownCapslock ^ isDownShift) && char.IsLetter(key)) key = char.ToUpper(key);
                        var e = new KeyPressEventArgs(key);
                        KeyPress(this, e);
                        handled |= e.Handled;
                    }
                }

                // raise KeyUp
                if (KeyUp != null && ((WM)wParam == WM.KEYUP || (WM)wParam == WM.SYSKEYUP))
                {
                    var keyData = (Keys)keyboardHookStruct.vkCode;
                    var e = new KeyEventArgs(keyData);
                    KeyUp(this, e);
                    handled |= e.Handled;
                }

            }

            //if event handled in application do not handoff to other listeners
            if (handled)
            {
                return 1;
            }
            else
            {
                return USER32.CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
            }
        }

        #region IDisposable Support
        bool disposed = false;

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        void Dispose(bool disposing)
        {
            if (disposing) Trace.WriteLine($"Dispose {this}");
            if (!disposed)
            {
                Stop(false);
                disposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged and managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

#endif
