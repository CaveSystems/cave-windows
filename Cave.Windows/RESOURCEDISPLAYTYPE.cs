using System.Diagnostics.CodeAnalysis;

namespace Cave.Windows
{
    /// <summary>
    /// The display options for the network object in a network browsing user interface
    /// </summary>
    [SuppressMessage("Design", "CA1069")]
    public enum RESOURCEDISPLAYTYPE : int
    {
        /// <summary>
        /// The object should be displayed as a domain.
        /// </summary>
        RESOURCEDISPLAYTYPE_DOMAIN = 0x1,
        /// <summary>
        /// The method used to display the object does not matter.
        /// </summary>
        RESOURCEDISPLAYTYPE_GENERIC = 0x0,
        /// <summary>
        /// The object should be displayed as a server.
        /// </summary>
        RESOURCEDISPLAYTYPE_SERVER = 0x2,
        /// <summary>
        /// The object should be displayed as a share.
        /// </summary>
        RESOURCEDISPLAYTYPE_SHARE = 0x3,
        /// <summary>
        /// The object should be displayed as a file.
        /// </summary>
        RESOURCEDISPLAYTYPE_FILE = 0x4,
        /// <summary>
        /// The object should be displayed as a group.
        /// </summary>
        RESOURCEDISPLAYTYPE_GROUP = 0x5,
        /// <summary>
        /// The object should be displayed as a network.
        /// </summary>
        RESOURCEDISPLAYTYPE_NETWORK = 0x6,
        /// <summary>
        /// The object should be displayed as a logical root for the entire network.
        /// </summary>
        RESOURCEDISPLAYTYPE_ROOT = 0x7,
        /// <summary>
        /// The object should be displayed as a administrative share.
        /// </summary>
        RESOURCEDISPLAYTYPE_SHAREADMIN = 0x8,
        /// <summary>
        /// The object should be displayed as a directory.
        /// </summary>
        RESOURCEDISPLAYTYPE_DIRECTORY = 0x9,
        /// <summary>
        /// The object should be displayed as a tree. This display type was used for a NetWare Directory Service (NDS) tree by the NetWare Workstation service supported on Windows XP and earlier.
        /// </summary>
        RESOURCEDISPLAYTYPE_TREE = 0xA,
        /// <summary>
        /// The object should be displayed as a Netware Directory Service container. This display type was used by the NetWare Workstation service supported on Windows XP and earlier.
        /// </summary>
        RESOURCEDISPLAYTYPE_NDSCONTAINER = 0xA,
    }
}
