using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// This structure that holds the network resource data. It is returned during enumeration of resources on the network and during enumeration of currently connected resources.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NETRESOURCE
    {
        /// <summary>
        /// The scope of the enumeration.
        /// </summary>
        public SCOPE Scope;
        /// <summary>
        /// The type of resource.
        /// </summary>
        public RESOURCETYPE Type;
        /// <summary>
        /// The display options for the network object in a network browsing user interface
        /// </summary>
        public RESOURCEDISPLAYTYPE DisplayType;
        /// <summary>
        /// A set of bit flags describing how the resource can be used.
        /// </summary>
        public RESOURCEUSAGE Usage;
        /// <summary>
        /// If the dwScope member is equal to RESOURCE_CONNECTED or RESOURCE_REMEMBERED, this member is a pointer to a null-terminated character string that specifies the name of a local device
        /// </summary>
        public string LocalName;
        /// <summary>
        /// If the entry is a network resource, this member is a pointer to a null-terminated character string that specifies the remote network name.
        /// </summary>
        public string RemoteName;
        /// <summary>
        /// A pointer to a NULL-terminated string that contains a comment supplied by the network provider.
        /// </summary>
        public string Comment;
        /// <summary>
        /// A pointer to a NULL-terminated string that contains the name of the provider that owns the resource. This member can be NULL if the provider name is unknown. To retrieve the provider name, you can call the  WNetGetProviderName function.
        /// </summary>
        public string Provider;
    }
}
