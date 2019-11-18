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

using System;
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
		public INPUTACTIVITYHOOK()
		{
			Start();
		}

		/// <summary>
		/// Destruction.
		/// </summary>
		~INPUTACTIVITYHOOK()
		{
			//uninstall hooks and do not throw exceptions
			Stop(false);
		}

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
		private static USER32.HookProc MouseHookProcedure;

		/// <summary>
		/// Declare KeyboardHookProcedure as HookProc type.
		/// </summary>
		private static USER32.HookProc KeyboardHookProcedure;

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
				MouseHookProcedure = new USER32.HookProc(MouseHookProc);
				//install hook
				hMouseHook = USER32.SetWindowsHookEx(WH.MOUSE_LL, MouseHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
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
				KeyboardHookProcedure = new USER32.HookProc(KeyboardHookProc);
				//install hook
				hKeyboardHook = USER32.SetWindowsHookEx(WH.KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
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
		public void Stop()
		{
			Stop(true);
		}

		/// <summary>
		/// Stops monitoring both or one of mouse and/or keyboard events and rasing events.
		/// </summary>
		/// <param name="throwExExceptions"><b>true</b> if exceptions which occured during uninstalling must be thrown</param>
		/// <exception cref="Win32ErrorException">Any windows problem.</exception>
		public void Stop(bool throwExExceptions)
		{
			//if mouse hook set and must be uninstalled
			if (hMouseHook != IntPtr.Zero)
			{
				//uninstall hook
				bool resultMouse = USER32.UnhookWindowsHookEx(hMouseHook);
				//reset invalid handle
				hMouseHook = IntPtr.Zero;
				//if failed and exception must be thrown
				if (!resultMouse && throwExExceptions)
				{
					throw new Win32ErrorException();
				}
			}

			//if keyboard hook set and must be uninstalled
			if (hKeyboardHook != IntPtr.Zero)
			{
				//uninstall hook
				bool resultKeyboard = USER32.UnhookWindowsHookEx(hKeyboardHook);
				//reset invalid handle
				hKeyboardHook = IntPtr.Zero;
				//if failed and exception must be thrown
				if (!resultKeyboard && throwExExceptions)
				{
					throw new Win32ErrorException();
				}
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
				MSLLHOOKSTRUCT l_MouseHookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

				//detect button clicked
				MouseButtons button = MouseButtons.None;
				short l_MouseDelta = 0;
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
						l_MouseDelta = (short)((l_MouseHookStruct.mouseData >> 16) & 0xffff);
						//TODO: X BUTTONS
						//If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP,
						//or WM_NCXBUTTONDBLCLK, the high-order word specifies which X button was pressed or released,
						//and the low-order word is reserved. This value can be one or more of the following values.
						//Otherwise, mouseData is not used.
						break;
				}

				//double clicks
				int clickCount = 0;
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
				MouseEventArgs e = new MouseEventArgs(button, clickCount, l_MouseHookStruct.pt.x, l_MouseHookStruct.pt.y, l_MouseDelta);
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
			bool handled = false;
			//it was ok and someone listens to events
			if ((nCode >= 0) && (KeyDown != null || KeyUp != null || KeyPress != null))
			{
				//read structure KeyboardHookStruct at lParam
				KBDLLHOOKSTRUCT MyKeyboardHookStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure((IntPtr)lParam, typeof(KBDLLHOOKSTRUCT));
				//raise KeyDown
				if (KeyDown != null && ((WM)wParam == WM.KEYDOWN || (WM)wParam == WM.SYSKEYDOWN))
				{
					Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
					KeyEventArgs e = new KeyEventArgs(keyData);
					KeyDown(this, e);
					handled |= e.Handled;
				}

				// raise KeyPress
				if (KeyPress != null && (WM)wParam == WM.KEYDOWN)
				{
					bool isDownShift = ((USER32.GetKeyState((int)VK.SHIFT) & 0x80) == 0x80 ? true : false);
					bool isDownCapslock = (USER32.GetKeyState((int)VK.CAPITAL) != 0 ? true : false);

					byte[] keyState = new byte[256];
					USER32.GetKeyboardState(keyState);
					byte[] inBuffer = new byte[2];
					if (USER32.ToAscii(MyKeyboardHookStruct.vkCode,
								MyKeyboardHookStruct.scanCode,
								keyState,
								inBuffer,
								MyKeyboardHookStruct.flags) == 1)
					{
						char key = (char)inBuffer[0];
						if ((isDownCapslock ^ isDownShift) && char.IsLetter(key)) key = char.ToUpper(key);
						KeyPressEventArgs e = new KeyPressEventArgs(key);
						KeyPress(this, e);
						handled |= e.Handled;
					}
				}

				// raise KeyUp
				if (KeyUp != null && ((WM)wParam == WM.KEYUP || (WM)wParam == WM.SYSKEYUP))
				{
					Keys l_KeyData = (Keys)MyKeyboardHookStruct.vkCode;
					KeyEventArgs e = new KeyEventArgs(l_KeyData);
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
		private bool m_DisposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		void Dispose(bool disposing)
		{
			if (!m_DisposedValue)
			{
				Stop(false);
				m_DisposedValue = true;
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