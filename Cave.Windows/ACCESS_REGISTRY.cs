using System;

namespace Cave.Windows
{
    /// <summary>
    /// Provides access flags for the microsoft windows registry
    /// </summary>
    
    [Flags]
    public enum ACCESS_REGISTRY : int
    {
        /// <summary>
        /// query value allowed
        /// </summary>
        KEY_QUERY_VALUE = 0x1,

        /// <summary>
        /// set value allowed
        /// </summary>
        KEY_SET_VALUE = 0x2,

        /// <summary>
        /// create sub key allowed
        /// </summary>
        KEY_CREATE_SUB_KEY = 0x4,

        /// <summary>
        /// enumerate sub keys allowed
        /// </summary>
        KEY_ENUMERATE_SUB_KEYS = 0x8,

        /// <summary>
        /// notifications abount content/subkey changes allowed
        /// </summary>
        KEY_NOTIFY = 0x10,

        /// <summary>
        /// link creation allowed
        /// </summary>
        KEY_CREATE_LINK = 0x20,

        /// <summary>
        /// Indicates that an application on 64-bit Windows should operate on the 64-bit registry view
        /// </summary>
        KEY_WOW64_64KEY = 0x100,

        /// <summary>
        /// Indicates that an application on 64-bit Windows should operate on the 32-bit registry view.
        /// </summary>
        KEY_WOW64_32KEY = 0x200,

        /// <summary>
        /// combines all default read rights
        /// </summary>
        KEY_READ = ACCESS.STANDARD_RIGHTS_READ | KEY_QUERY_VALUE | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY,

        /// <summary>
        /// combines all default write rights
        /// </summary>
        KEY_WRITE = ACCESS.STANDARD_RIGHTS_WRITE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY,

        /// <summary>
        /// same as <see cref="KEY_READ"/>
        /// </summary>
        KEY_EXECUTE = KEY_READ,

        /// <summary>
        /// full access allowed
        /// </summary>
        KEY_ALL_ACCESS = ACCESS.STANDARD_RIGHTS_REQUIRED | KEY_QUERY_VALUE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY | KEY_CREATE_LINK,
    }
}
