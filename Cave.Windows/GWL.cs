namespace Cave.Windows
{
    /// <summary>
    /// Enums for the GetWindowLong and SetWindowLong function
    /// </summary>
    public enum GWL
    {
        /// <summary>
        /// Sets a new extended window style. 
        /// </summary>
        EXSTYLE = -20,

        /// <summary>
        /// Sets a new application instance handle.
        /// </summary>
        HINSTANCE = -6,

        /// <summary>
        /// Sets a new identifier of the child window. The window cannot be a top-level window.
        /// </summary>
        ID = -12,

        /// <summary>
        /// Sets a new window style.
        /// </summary>
        STYLE = -16,

        /// <summary>
        /// Sets the user data associated with the window. This data is intended for use by the application that created the window. Its value is initially zero.
        /// </summary>
        USERDATA = -21,

        /// <summary>
        /// Sets a new address for the window procedure. You cannot change this attribute if the window does not belong to the same process as the calling thread.
        /// </summary>
        WNDPROC = -4,
    }
}
