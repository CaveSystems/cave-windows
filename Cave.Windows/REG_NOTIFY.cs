using System;

namespace Cave.Windows
{
    /// <summary>
    /// Notifyfilters for RegNotifyChangeKeyValue
    /// </summary>
    [Flags]
    public enum REG_NOTIFY : uint
    {
        /// <summary>
        /// Notify the caller if a subkey is added or deleted.
        /// </summary>
        CHANGE_NAME = 1,
        /// <summary>
        /// Notify the caller of changes to the attributes of the key, such as the security descriptor information.
        /// </summary>
        CHANGE_ATTRIBUTES = 2,
        /// <summary>
        /// Notify the caller of changes to a value of the key. This can include adding or deleting a value, or changing an existing value.
        /// </summary>
        CHANGE_LAST_SET = 4,
        /// <summary>
        /// Notify the caller of changes to the security descriptor of the key.
        /// </summary>
        CHANGE_SECURITY = 8,
    }
}
