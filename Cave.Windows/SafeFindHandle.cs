using Microsoft.Win32.SafeHandles;

namespace Cave.Windows
{
    /// <summary>
    /// Handle for windows find (file) operations
    /// </summary>
    public sealed class SafeFindHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal SafeFindHandle()
            : base(true)
        {
        }

        /// <summary>
        /// Releases the handle
        /// </summary>
        /// <returns></returns>
        protected override bool ReleaseHandle()
        {
            if (IsInvalid) return true;
            if (IsClosed) return true;
            var result = KERNEL32.SafeNativeMethods.FindClose(this);
            SetHandleAsInvalid();
            return result;
        }
    }
}
