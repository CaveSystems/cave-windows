namespace Cave.Windows
{
    /// <summary>
    /// Provides extensions to the <see cref="ErrorCode"/> enum.
    /// </summary>
    public static class ErrorCodeExtension
    {
        /// <summary>
        /// Throws a <see cref="Win32ErrorException"/> if errorCode is not equal to <see cref="ErrorCode.SUCCESS"/>.
        /// </summary>
        /// <param name="errorCode">ErrorCode to check.</param>
        public static void ThrowOnError(this ErrorCode errorCode)
        {
            if (errorCode != ErrorCode.SUCCESS) throw new Win32ErrorException(errorCode);
        }

        /// <summary>
        /// Throws a <see cref="Win32ErrorException"/> if errorCode is not equal to any specified <paramref name="validResults"/>.
        /// </summary>
        /// <param name="errorCode">ErrorCode to check.</param>
        /// <param name="validResults">Valid ErrorCode values.</param>
        public static void ThrowOnError(this ErrorCode errorCode, params ErrorCode[] validResults)
        {
            if (validResults.IndexOf(errorCode) < 0)
            {
                throw new Win32ErrorException(errorCode);
            }
        }
    }
}
