namespace Cave.Windows
{
    /// <summary>
    /// By default, a 32-bit application running on WOW64 accesses the 32-bit registry view and a 64-bit application accesses the 64-bit registry view. The following flags enable 32-bit applications to access redirected keys in the 64-bit registry view and 64-bit applications to access redirected keys in the 32-bit registry view. These flags have no effect on shared registry keys. 
    /// </summary>
    public enum RegWow64Options
    {
        /// <summary>
        /// Access a 64-bit key from either a 32-bit or 64-bit application.
        /// </summary>
        KEY_WOW64_64KEY = 0x0100,

        /// <summary>
        /// Access a 32-bit key from either a 32-bit or 64-bit application.
        /// </summary>
        KEY_WOW64_32KEY = 0x0200
    }
}
