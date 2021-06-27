namespace Cave.Windows
{
    /// <summary>
    /// The TOKEN_TYPE enumeration contains values that differentiate between a primary token and an impersonation token. 
    /// </summary>
    public enum TOKEN_TYPE
    {
        /// <summary>
        /// Indicates a primary token.
        /// </summary>
        TokenPrimary = 1,

        /// <summary>
        /// Indicates an impersonation token.
        /// </summary>
        TokenImpersonation = 2,
    }
}
