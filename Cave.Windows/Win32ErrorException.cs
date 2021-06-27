using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// Provides Win32 exceptions retrieved by KERNEL32.GetLastError()
    /// </summary>
    public class Win32ErrorException : Exception
    {
        /// <summary>
        /// Obtains a message for the specified Win32 error code by calling <see cref="KERNEL32.SafeNativeMethods.FormatMessage"/>
        /// </summary>
        /// <param name="errorCode">Win32 <see cref="ErrorCode"/></param>
        /// <returns>Returns a message</returns>
        public static string GetMessage(ErrorCode errorCode)
        {
            var result = new StringBuilder(KERNEL32.DefaultStructBufferSize);
            var count = KERNEL32.SafeNativeMethods.FormatMessage(FORMAT_MESSAGE.IGNORE_INSERTS | FORMAT_MESSAGE.FROM_SYSTEM | FORMAT_MESSAGE.ARGUMENT_ARRAY, IntPtr.Zero, errorCode, 0, result, (uint)result.Capacity, IntPtr.Zero);
            if (count != 0)
            {
                return result.ToString();
            }
            else
            {
                return string.Format("Unknown Win32 error code {0}", errorCode);
            }
        }

        /// <summary>
        /// Obtains the errorcode used to generate this exception
        /// </summary>
        public ErrorCode ErrorCode { get; }

        /// <summary>
        /// Creates a new exception with a message retrieved by using the last win32 error code retrieved by <see cref="Marshal.GetLastWin32Error()"/>
        /// </summary>
        public Win32ErrorException() : this((ErrorCode)Marshal.GetLastWin32Error()) { }

        /// <summary>
        /// Creates a new exception with a message retrieved by using the specified error code
        /// </summary>
        /// <param name="errorCode">The Win32 error code</param>
        public Win32ErrorException(ErrorCode errorCode) : base(GetMessage(errorCode)) => ErrorCode = errorCode;

        /// <summary>
        /// Creates a new exception with a message retrieved by using the specified error code
        /// </summary>
        /// <param name="errorCode">The Win32 error code</param>
        public Win32ErrorException(int errorCode) : this((ErrorCode)errorCode) { }
    }
}
