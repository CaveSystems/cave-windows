using System;
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// Provides access to a windows control via handle
    /// </summary>
    public class CONTROL
    {
        /// <summary>
        /// Obtains the class name
        /// </summary>
        public string ClassName;

        /// <summary>
        /// Obtains the caption
        /// </summary>
        public string Caption;

        /// <summary>
        /// Obtains the handle
        /// </summary>
        public IntPtr Handle;

        /// <summary>
        /// Creates a new instance by reading the handle
        /// </summary>
        /// <param name="handle"></param>
        public CONTROL(IntPtr handle)
        {
            Handle = handle;
            Caption = GetWindowText(handle);
            ClassName = GetClassName(handle);
        }

        /// <summary>
        /// Reads the class name of the specified control handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static string GetClassName(IntPtr handle)
        {
            var sb = new StringBuilder(64000);
            _ = USER32.GetClassName(handle, sb, sb.Capacity);
            KERNEL32.CheckLastError();
            return sb.ToString();
        }

        /// <summary>
        /// Reads the window text of the specified control handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static string GetWindowText(IntPtr handle)
        {
            var sb = new StringBuilder(64000);
            _ = USER32.GetWindowText(handle, sb, sb.Capacity);
            KERNEL32.CheckLastError();
            return sb.ToString();
        }

        /// <summary>
        /// Internally initializes the instance without checking any values
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="className"></param>
        /// <param name="caption"></param>
        internal CONTROL(IntPtr handle, string className, string caption)
        {
            Handle = handle;
            ClassName = className;
            Caption = caption;
        }

        /// <summary>
        /// Obtains the <see cref="WINDOWINFO"/> for the control
        /// </summary>
        public WINDOWINFO Info
        {
            get
            {
                var result = new WINDOWINFO();
                USER32.GetWindowInfo(Handle, ref result);
                return result;
            }
        }
    }
}
