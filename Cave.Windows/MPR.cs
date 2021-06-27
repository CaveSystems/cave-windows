using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// This class provides Windows Networking Functions on windows 16, 32 and 64 bit
    /// </summary>    
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("Interoperability", "CA1401")]
    public static class MPR
    {
        #region Windows function imports
        /// <summary>
        /// The WNetGetConnection function retrieves the name of the network resource associated with a local device.
        /// </summary>
        /// <param name="localName">Pointer to a constant null-terminated string that specifies the name of the local device to get the network name for.</param>
        /// <param name="remoteName">Pointer to a null-terminated string that receives the remote name used to make the connection.</param>
        /// <param name="count">Pointer to a variable that specifies the size of the buffer pointed to by the lpRemoteName parameter, in characters. If the function fails because the buffer is not large enough, this parameter returns the required buffer size.</param>
        /// <returns></returns>
        [DllImport("mpr.dll", CharSet = CharSet.Unicode)]
        public static extern int WNetGetConnection(string localName, StringBuilder remoteName, ref int count);

        /// <summary>
        /// The WNetAddConnection2 function makes a connection to a network resource. The function can redirect a local device to the network resource.
        /// </summary>
        /// <param name="netResource"></param>
        /// <param name="password"></param>
        /// <param name="userName"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport("mpr.dll", CharSet = CharSet.Unicode)]
        public static extern int WNetAddConnection2A(ref NETRESOURCE netResource, string password, string userName, int flags);

        /// <summary>
        /// The WNetCancelConnection2 function cancels an existing network connection. You can also call the function to remove remembered network connections that are not currently connected.
        /// The WNetCancelConnection2 function supersedes the WNetCancelConnection function.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="flags"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        [DllImport("mpr.dll", CharSet = CharSet.Unicode)]
        public static extern int WNetCancelConnection2A(string name, int flags, bool force);

        /// <summary>
        /// The WNetConnectionDialog function starts a general browsing dialog box for connecting to network resources. The function requires a handle to the owner window for the dialog box.
        /// </summary>
        /// <param name="hWnd">Handle to the owner window for the dialog box.</param>
        /// <param name="type">
        /// Resource type to allow connections to. This parameter can be the following value.
        /// <para>RESOURCETYPE_DISK: Connections to disk resources.</para>
        /// </param>
        /// <returns></returns>
        [DllImport("mpr.dll")]
        public static extern int WNetConnectionDialog(int hWnd, int type);

        /// <summary>
        /// The WNetDisconnectDialog function starts a general browsing dialog box for disconnecting from network resources. The function requires a handle to the owner window for the dialog box.
        /// </summary>
        /// <param name="wnd"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [DllImport("mpr.dll")]
        public static extern int WNetDisconnectDialog(int wnd, int type);

        /// <summary>
        /// [WNetRestoreConnectionW is not available for use as of Windows Vista.]
        /// The WNetRestoreConnectionW function restores the connection to a network resource. The function prompts the user, if necessary, for a name and password.
        /// </summary>
        /// <param name="wnd">Handle to the parent window that the function uses to display the user interface (UI) that prompts the user for a name and password when making the network connection. If this parameter is NULL, there is no owner window.</param>
        /// <param name="localDrive">Pointer to a null-terminated Unicode string that specifies the local name of the drive to connect to, such as "Z:". If this parameter is NULL, the function reconnects all persistent drives stored in the registry for the current user.</param>
        /// <param name="useUI">If true, display a username/password prompt to the caller; otherwise, do not display it. The default value is true. </param>
        /// <returns></returns>
        [DllImport("mpr.dll", CharSet = CharSet.Unicode)]
        public static extern int WNetRestoreConnectionW(int wnd, string localDrive, bool useUI);
        #endregion

        #region wrappers
        /// <summary>
        /// Obtains the current remote connection string of the specified drive
        /// </summary>
        /// <param name="drive"></param>
        /// <returns></returns>
        public static string NetworkDriveGet(char drive)
        {
            var stringBuilder = new StringBuilder();
            //get length first
            var len = 0;
            var result = WNetGetConnection(drive + ":", stringBuilder, ref len);
            //not connected -> return
            if (result == 2250) return null;
            //error ?
            if (result != 234) throw new Win32ErrorException(result);
            //create buffer
            stringBuilder.Capacity = len;
            //get data
            result = WNetGetConnection(drive + ":", stringBuilder, ref len);
            //error ?
            if (result != 0) throw new Win32ErrorException(result);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Unmaps a netword drive
        /// </summary>
        /// <param name="localDrive"></param>
        /// <param name="force"></param>
        public static void NetworkDriveUnmap(char localDrive, bool force)
        {
            var result = WNetCancelConnection2A(localDrive + ":", (int)CONNECT_FLAGS.CONNECT_UPDATE_PROFILE, force);
            if (result != 0) throw new Win32ErrorException(result);
        }

        /// <summary>
        /// Maps a network drive
        /// </summary>
        /// <param name="localDrive"></param>
        /// <param name="networkPath"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="flags"></param>
        public static void NetworkDriveMap(char localDrive, string networkPath, string userName, string password, CONNECT_FLAGS flags)
        {
            var netResource = new NETRESOURCE
            {
                Type = RESOURCETYPE.RESOURCETYPE_DISK,
                LocalName = localDrive + ":",
                RemoteName = networkPath,
                Provider = null
            };
            var result = WNetAddConnection2A(ref netResource, password, userName, (int)flags);
            if (result != 0) throw new Win32ErrorException(result);
        }

        /// <summary>
        /// Obtains the current remote connection string of the specified drive
        /// </summary>
        /// <param name="printer"></param>
        /// <returns></returns>
        public static string NetworkPrinterGet(int printer)
        {
            var stringBuilder = new StringBuilder();
            //get length first
            var len = 0;
            var result = WNetGetConnection("LPT" + printer, stringBuilder, ref len);
            //not connected -> return
            if (result == 2250) return null;
            //error ?
            if (result != 234) throw new Win32ErrorException(result);
            //create buffer
            stringBuilder.Capacity = len;
            //get data
            result = WNetGetConnection("LPT" + printer, stringBuilder, ref len);
            //error ?
            if (result != 0) throw new Win32ErrorException(result);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Unmaps a network printer
        /// </summary>
        /// <param name="localPrinterPort"></param>
        /// <param name="force"></param>
        public static void NetworkPrinterUnmap(int localPrinterPort, bool force)
        {
            var result = WNetCancelConnection2A("LPT" + localPrinterPort, (int)CONNECT_FLAGS.CONNECT_UPDATE_PROFILE, force);
            if (result != 0) throw new Win32ErrorException(result);
        }

        /// <summary>
        /// Maps a network printer
        /// </summary>
        /// <param name="localPrinterPort"></param>
        /// <param name="networkPath"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="flags"></param>
        public static void NetworkPrinterMap(int localPrinterPort, string networkPath, string userName, string password, CONNECT_FLAGS flags)
        {
            var netResource = new NETRESOURCE
            {
                Type = RESOURCETYPE.RESOURCETYPE_PRINT,
                LocalName = "LPT" + localPrinterPort,
                RemoteName = networkPath,
                Provider = null
            };
            var result = WNetAddConnection2A(ref netResource, password, userName, (int)flags);
            if (result != 0) throw new Win32ErrorException(result);
        }
        #endregion
    }
}
