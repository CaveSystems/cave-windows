namespace Cave.Windows
{
    /// <summary>
    /// State of a logical device. This property is present at CIM_LogicalDevice and children
    /// </summary>
    public enum Win32_StatusInfo : ushort
    {
        /// <summary>
        /// Other
        /// </summary>
        Other = 1,

        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 2,

        /// <summary>
        /// Enabled
        /// </summary>
        Enabled = 3,

        /// <summary>
        /// Disabled
        /// </summary>
        Disabled = 4,

        /// <summary>
        /// NotApplicable
        /// </summary>
        NotApplicable = 5,
    }
}
