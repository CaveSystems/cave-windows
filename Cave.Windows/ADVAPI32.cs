using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Cave.Windows
{
    /// <summary>
    /// RegistryMonitor provides monitoring of a RegistyKey
    /// </summary>
    public sealed class ADVAPI32 : IDisposable
    {
        internal static class UnsafeNativeMethods
        {
            #region function imports

            /// <summary>
            /// Opens the specified registry key. Note that key names are not case sensitive.
            /// </summary>
            /// <param name="hKey">A handle to an open registry key. </param>
            /// <param name="lpSubKey">The name of the registry subkey to be opened. </param>
            /// <param name="ulOptions">This parameter is reserved and must be zero.</param>
            /// <param name="samDesired">A mask that specifies the desired access rights to the key to be opened. </param>
            /// <param name="phkResult">A pointer to a variable that receives a handle to the opened key.</param>
            /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
            internal static extern ErrorCode RegOpenKeyEx(IntPtr hKey, string lpSubKey, uint ulOptions, int samDesired, out IntPtr phkResult);

            /// <summary>
            /// Notifies the caller about changes to the attributes or contents of a specified registry key.
            /// </summary>
            /// <param name="hKey">A handle to an open registry key.</param>
            /// <param name="bWatchSubtree">If this parameter is TRUE, the function reports changes in the specified key and its subkeys. If the parameter is FALSE, the function reports changes only in the specified key.</param>
            /// <param name="dwNotifyFilter">A value that indicates the changes that should be reported. </param>
            /// <param name="hEvent">A handle to an event.</param>
            /// <param name="fAsynchronous">If this parameter is TRUE, the function returns immediately and reports changes by signaling the specified event.</param>
            /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern ErrorCode RegNotifyChangeKeyValue(IntPtr hKey, bool bWatchSubtree, REG_NOTIFY dwNotifyFilter, IntPtr hEvent, bool fAsynchronous);

            /// <summary>
            /// Closes a handle to the specified registry key.
            /// </summary>
            /// <param name="hKey">A handle to the open key to be closed.</param>
            /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern ErrorCode RegCloseKey(IntPtr hKey);

            /// <summary>
            /// Creates a new process and its primary thread. The new process runs in the security context of the user represented by the specified token.
            /// </summary>
            /// <param name="hToken">A handle to the primary token that represents a user. The handle must have the TOKEN_QUERY, TOKEN_DUPLICATE, and TOKEN_ASSIGN_PRIMARY access rights. For more information, see Access Rights for Access-Token Objects. The user represented by the token must have read and execute access to the application specified by the lpApplicationName or the lpCommandLine parameter.</param>
            /// <param name="lpApplicationName">The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.</param>
            /// <param name="lpCommandLine">The command line to be executed. The maximum length of this string is 32K characters. If lpApplicationName is NULL, the module name portion of lpCommandLine is limited to MAX_PATH characters.</param>
            /// <param name="lpProcessAttributes">A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new process object and determines whether child processes can inherit the returned handle to the process. If lpProcessAttributes is NULL or lpSecurityDescriptor is NULL, the process gets a default security descriptor and the handle cannot be inherited. The default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow access for the caller, in which case the process may not be opened again after it is run. The process handle is valid and will continue to have full access rights.</param>
            /// <param name="lpThreadAttributes">A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new thread object and determines whether child processes can inherit the returned handle to the thread. If lpThreadAttributes is NULL or lpSecurityDescriptor is NULL, the thread gets a default security descriptor and the handle cannot be inherited. The default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow access for the caller.</param>
            /// <param name="bInheritHandles">If this parameter is TRUE, each inheritable handle in the calling process is inherited by the new process. If the parameter is FALSE, the handles are not inherited. Note that inherited handles have the same value and access rights as the original handles.</param>
            /// <param name="dwCreationFlags">The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.</param>
            /// <param name="lpEnvironment">A pointer to an environment block for the new process. If this parameter is NULL, the new process uses the environment of the calling process.</param>
            /// <param name="lpCurrentDirectory">The full path to the current directory for the process. The string can also specify a UNC path.</param>
            /// <param name="lpStartupInfo">A pointer to a STARTUPINFO or STARTUPINFOEX structure.</param>
            /// <param name="lpProcessInformation">A pointer to a PROCESS_INFORMATION structure that receives identification information about the new process.</param>
            /// <returns>If the function succeeds, the return value is nonzero.
            /// If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
            internal static extern bool CreateProcessAsUser(IntPtr hToken, string lpApplicationName, string lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

            /// <summary>
            /// The DuplicateTokenEx function creates a new access token that duplicates an existing token. This function can create either a primary token or an impersonation token.
            /// </summary>
            /// <param name="hExistingToken">A handle to an access token opened with TOKEN_DUPLICATE access.</param>
            /// <param name="dwDesiredAccess">Specifies the requested access rights for the new token. The DuplicateTokenEx function compares the requested access rights with the existing token's discretionary access control list (DACL) to determine which rights are granted or denied. To request the same access rights as the existing token, specify zero. To request all access rights that are valid for the caller, specify MAXIMUM_ALLOWED.</param>
            /// <param name="lpThreadAttributes">A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new token and determines whether child processes can inherit the token. If lpTokenAttributes is NULL, the token gets a default security descriptor and the handle cannot be inherited. If the security descriptor contains a system access control list (SACL), the token gets ACCESS_SYSTEM_SECURITY access right, even if it was not requested in dwDesiredAccess.</param>
            /// <param name="impersonationLevel">Specifies a value from the SECURITY_IMPERSONATION_LEVEL enumeration that indicates the impersonation level of the new token.</param>
            /// <param name="dwTokenType">Specifies one of the following values from the TOKEN_TYPE enumeration.</param>
            /// <param name="phNewToken"></param>
            /// <returns></returns>
            [DllImport("advapi32.dll", EntryPoint = "DuplicateTokenEx", SetLastError = true)]
            internal static extern bool DuplicateTokenEx(IntPtr hExistingToken, ACCESS dwDesiredAccess, ref SECURITY_ATTRIBUTES lpThreadAttributes, SECURITY_IMPERSONATION_LEVEL impersonationLevel, TOKEN_TYPE dwTokenType, out IntPtr phNewToken);

            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern bool OpenProcessToken(IntPtr processHandle, uint desiredAccess, out IntPtr tokenHandle);
            #endregion
        }

        #region events

        /// <summary>
        /// Occurs when the specified registry key has changed.
        /// </summary>
        public event EventHandler<RegKeyChangedEventArgs> RegKeyChanged;

        /// <summary>
        /// Occurs when the specified registry key cannot be monitored
        /// </summary>
        public event EventHandler<ErrorEventArgs> ErrorOccured;

        /// <summary>
        /// Raises the <see cref="RegKeyChanged"/> event.
        /// </summary>
        void OnRegKeyChanged()
        {
            var handler = RegKeyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new RegKeyChangedEventArgs(Key.CreateSubKey("")));
            }
        }

        /// <summary>
        /// Raises the <see cref="ErrorOccured"/> event.
        /// </summary>
        /// <param name="ex"></param>
        void OnError(Exception ex)
        {
            var handler = ErrorOccured;
            if (handler != null) handler.Invoke(this, new ErrorEventArgs(ex));
        }

        #endregion

        #region private member variables

        readonly RegistryKey Key;
        readonly IntPtr Hive;
        readonly string Path;
        volatile bool monitoring = false;
        bool disposed = false;
        REG_NOTIFY filter = REG_NOTIFY.CHANGE_NAME | REG_NOTIFY.CHANGE_ATTRIBUTES | REG_NOTIFY.CHANGE_LAST_SET | REG_NOTIFY.CHANGE_SECURITY;
        ManualResetEvent terminateEvent = new(false);

        #endregion

        #region public functionality
        /// <summary>
        /// Launches the given application as user.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="args"></param>
        /// <param name="sessionID"></param>
        public static PROCESS_INFORMATION LaunchProcessAsUser(string fileName, string args, int sessionID)
        {
            var mySessionID = Process.GetCurrentProcess().SessionId;
            sessionID = (sessionID > 0) ? sessionID : KERNEL32.SafeNativeMethods.WTSGetActiveConsoleSessionId();

            if (mySessionID == sessionID)
            {
                var result = new PROCESS_INFORMATION();
                var process = Process.Start(fileName, args);
                result.dwProcessId = process.Id;
                result.hProcess = process.Handle;
                return result;
            }
            if (sessionID <= 0) throw new Exception("Invalid session!");
            //get users token
            if (!WTSAPI32.WTSQueryUserToken(sessionID, out var userToken))
            {
                throw new Win32ErrorException();
            }

            var security = new SECURITY_ATTRIBUTES();
            IntPtr newToken;
            {
                security.nLength = Marshal.SizeOf(security);
                security.bInheritHandle = false;
                security.lpSecurityDescriptor = IntPtr.Zero;
                //copy token and
                var result = UnsafeNativeMethods.DuplicateTokenEx(userToken, ACCESS.TOKEN_ASSIGN_PRIMARY | ACCESS.TOKEN_DUPLICATE | ACCESS.TOKEN_QUERY, ref security, SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, TOKEN_TYPE.TokenPrimary, out newToken);
                KERNEL32.SafeNativeMethods.CloseHandle(userToken).ThrowOnError();
                if (!result) throw new Win32ErrorException();
            }

            {
                var startInfo = new STARTUPINFO();
                var command = '"' + fileName + '"' + ' ' + args;
                var result = UnsafeNativeMethods.CreateProcessAsUser(newToken, null, command, ref security, ref security, false, 0, IntPtr.Zero, null, ref startInfo, out var process);
                KERNEL32.SafeNativeMethods.CloseHandle(newToken);
                if (!result) throw new Win32ErrorException();
                return process;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ADVAPI32"/> class.
        /// </summary>
        /// <param name="key">The registry key to monitor.</param>
        public ADVAPI32(RegistryKey key)
            : this(key.Name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ADVAPI32"/> class.
        /// </summary>
        /// <param name="path">The path to monitor</param>
        public ADVAPI32(string path)
        {
            if ((path == null) || (path.Length == 0)) throw new ArgumentNullException(nameof(path));
            var root = System.IO.Path.GetPathRoot(path);
            Hive = new IntPtr((int)REGISTRY.GetHiveHandle(root));
            Path = path.Substring(root.Length);
            Key = REGISTRY.GetKey(path, false);
       }

        /// <summary>
        /// Disposes this object.
        /// </summary>
        public void Dispose()
        {
            if (disposed) return;
            if (terminateEvent != null)
            {
                Stop();
                Key.Close();
                (terminateEvent as IDisposable)?.Dispose();
                terminateEvent = null;
            }
            disposed = true;
        }

        /// <summary>
        /// Gets or sets the <see cref="REG_NOTIFY"/>
        /// </summary>
        public REG_NOTIFY NotifyFilter
        {
            get => filter;
            set
            {
                lock (this)
                {
                    if (IsMonitoring) throw new InvalidOperationException(string.Format("Monitorthread is already running!"));
                    filter = value;
                }
            }
        }

        /// <summary>
        /// <b>true</b> if this <see cref="ADVAPI32"/> object is currently monitoring;
        /// otherwise, <b>false</b>.
        /// </summary>
        public bool IsMonitoring => monitoring;

        /// <summary>
        /// Start monitoring.
        /// </summary>
        public void Start()
        {
            if (disposed) throw new ObjectDisposedException(null, string.Format("This instance is already disposed"));
            lock (this)
            {
                if (monitoring) throw new InvalidOperationException(string.Format("Monitorthread is already running!"));
                terminateEvent.Reset();
                monitoring = true;
                Task.Factory.StartNew(Worker);
            }
        }

        /// <summary>
        /// Stops the monitoring thread.
        /// </summary>
        public void Stop()
        {
            if (disposed) throw new ObjectDisposedException(null, string.Format("This instance is already disposed"));
            lock (this)
            {
                if (!monitoring) throw new InvalidOperationException(string.Format("Monitorthread is not running!"));
                terminateEvent.Set();
                monitoring = false;
            }
        }
        #endregion

        #region monitor thread
        void Worker()
        {
            try
            {
                var access = unchecked((int)ACCESS.STANDARD_RIGHTS_READ | (int)ACCESS_REGISTRY.KEY_QUERY_VALUE | (int)ACCESS_REGISTRY.KEY_NOTIFY);
                var result = UnsafeNativeMethods.RegOpenKeyEx(Hive, Path, 0, access, out var keyHandle);
                if (result != ErrorCode.SUCCESS) throw new Win32ErrorException(result);

                try
                {
                    var notifyEvent = new AutoResetEvent(false);
                    var waitHandles = new WaitHandle[] { notifyEvent, terminateEvent };
                    while (!terminateEvent.WaitOne(0, true))
                    {
#pragma warning disable 618
                        result = UnsafeNativeMethods.RegNotifyChangeKeyValue(keyHandle, true, filter, notifyEvent.Handle, true);
#pragma warning restore 618
                        if (result != 0) throw new Win32ErrorException(result);
                        if (WaitHandle.WaitAny(waitHandles) == 0)
                        {
                            OnRegKeyChanged();
                        }
                    }
                }
                finally
                {
                    if (keyHandle != IntPtr.Zero)
                    {
                        UnsafeNativeMethods.RegCloseKey(keyHandle);
                        keyHandle = IntPtr.Zero;
                    }
                    monitoring = false;
                }
            }
            catch (Exception e)
            {
                OnError(e);
            }
        }
        #endregion
    }
}
