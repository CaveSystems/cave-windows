namespace Cave.Windows
{
    /// <summary>
    /// WM_ACTIVATE parameters
    /// </summary>
    public enum WA : int
    {
        /// <summary>
        /// set inactive
        /// </summary>
        INACTIVE = 0,

        /// <summary>
        /// set active
        /// </summary>
        ACTIVE = 1,

        /// <summary>
        /// activated by a mouse click
        /// </summary>
        CLICKACTIVE = 2,
    }
}
