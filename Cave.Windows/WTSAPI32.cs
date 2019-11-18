#region CopyRight 2018
/*
    Copyright (c) 2003-2018 Andreas Rohleder (andreas@rohleder.cc)
    All rights reserved
*/
#endregion
#region License MSPL
/*
    This file contains some sourcecode that uses Microsoft Windows API calls
    to provide functionality that is part of the underlying operating system.
    The API calls and their documentation are copyrighted work of Microsoft
    and/or its suppliers. Use of the Software is governed by the terms of the
    MICROSOFT LIMITED PUBLIC LICENSE.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE.MSPL file
    found at the installation directory or the distribution package.
*/
#endregion
#region License LGPL-3
/*
    This program/library/sourcecode is free software; you can redistribute it
    and/or modify it under the terms of the GNU Lesser General Public License
    version 3 as published by the Free Software Foundation subsequent called
    the License.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE file
    found at the installation directory or the distribution package.

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the
    "Software"), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be included
    in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion License
#region Authors & Contributors
/*
   Information source:
     Microsoft Corporation

   Implementation:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:
 */
#endregion

using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Remote Desktop Services API Functions
    /// https://msdn.microsoft.com/en-us/library/aa383464%28v=vs.85%29.aspx
    /// </summary>
    public class WTSAPI32
    {
        /// <summary>
        /// Contains pointers to the functions called by a client-side DLL to access virtual channels.Remote Desktop Services calls your VirtualChannelEntry function to pass this structure.
        /// </summary>
        public struct CHANNEL_ENTRY_POINTS
        {
            /// <summary>
            /// Size, in bytes, of this structure.
            /// </summary>
            public int Size;

            /// <summary>
            /// Protocol version. Remote Desktop Services sets this member to VIRTUAcHANNEL_VERSION_WIN2000.
            /// </summary>
            public int ProtocolVersion;

            /// <summary>
            /// Pointer to a VirtualChannelInit function.
            /// </summary>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public VirtualChannelInit VirtualChannelInit;

            /// <summary>
            /// Pointer to a VirtualChannelOpen function.
            /// </summary>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public VirtualChannelOpen VirtualChannelOpen;

            /// <summary>
            /// Pointer to a VirtualChannelClose function.
            /// </summary>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public VirtualChannelClose VirtualChannelClose;

            /// <summary>
            /// Pointer to a VirtualChannelWrite function.
            /// </summary>
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public VirtualChannelWrite VirtualChannelWrite;
        }

        /// <summary>
        /// Contains the name and options of a Remote Desktop Services virtual channel. A client DLL uses this structure when it calls the VirtualChannelInit function to register a virtual channel name.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct CHANNEL_DEF
        {
            /// <summary>
            /// A null-terminated string containing the name of a virtual channel. Virtual channel names can contain from 1 to CHANNEname_LEN (7) characters.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
            public string name;

            /// <summary>
            /// Specifies the options for this virtual channel.
            /// </summary>
            public CHANNEL_OPTION options;
        }

        /// <summary>
        /// Channel Events
        /// </summary>
        public enum CHANNEL_EVENT
        {
            /// <summary>
            /// The Remote Desktop Connection (RDC) client initialization has been completed. The pDataparameter is NULL. 
            /// </summary>
            Initialized = 0,

            /// <summary>
            /// A connection has been established with an RD Session Host server that supports virtual channels. The pData parameter is a pointer to a null-terminated string with the name of the server.
            /// </summary>
            Connected = 1,

            /// <summary>
            /// A connection has been established with an RD Session Host server that does not support virtual channels. The pData parameter is NULL.
            /// </summary>
            V1Connected = 2,
            
            /// <summary>
            /// The connection to the RD Session Host server has been disconnected. The pData parameter is NULL.
            /// </summary>
            Disconnected = 3,

            /// <summary>
            /// The client has been terminated. The pData parameter is NULL.
            /// </summary>
            Terminated = 4,

            /// <summary>
            /// Something was received at a channel.
            /// </summary>
            DataRecieved = 10,

            /// <summary>
            /// Something was written into a channel.
            /// </summary>
            WriteComplete = 11,

            /// <summary>
            /// The last write has been cancelled
            /// </summary>
            WriteCanceled = 12,

            /// <summary>
            /// User defined event
            /// </summary>
            User = 1000,
        }

        /// <summary>
        /// Provides information about the chunk of data being received in a CHANNEL_EVENT_DATA_RECEIVED event.
        /// </summary>
        [Flags]
        public enum CHANNEL_FLAG
        {
            /// <summary>
            /// The chunk is the beginning of the data written by a single write operation. 
            /// </summary>
            First = 0x01,

            /// <summary>
            /// The chunk is the end of the data written by a single write operation. 
            /// </summary>
            Last = 0x02,

            /// <summary>
            /// The chunk contains all the data from a single write operation.  (First and Last)
            /// </summary>
            Only = First | Last,

            /// <summary>
            /// This is the default. The chunk is in the middle of a block of data written by a single write operation. 
            /// </summary>
            Middle = 0,

            /// <summary>
            /// PChannel.h : internal use only
            /// </summary>
            ShowProtocol = 0x10,

            /// <summary>
            /// PChannel.h : internal use only
            /// </summary>
            Suspend = 0x20,

            /// <summary>
            /// PChannel.h : internal use only
            /// </summary>
            Resume = 0x40,

            /// <summary>
            /// Channel failing
            /// </summary>
            Fail = 0x100,

        }

        /// <summary>
        /// Virtual Channel Options
        /// </summary>
        [Flags]
        public enum CHANNEL_OPTION : uint
        {
            /// <summary>
            /// The channel is initialized. This value is set by the VirtualChannelInit function.
            /// </summary>
            Initialized = 0x80000000,
            
            /// <summary>
            /// Encrypt according to Remote Desktop Protocol (RDP) data encryption (that is, if RDP data is encrypted, do so for this channel, too).
            /// </summary>
            EncryptRDP = 0x40000000,
            
            /// <summary>
            /// Encrypt server-to-client data.
            /// </summary>
            EncryptSC = 0x20000000,

            /// <summary>
            /// Encrypt client-to-server data.
            /// </summary>
            EncryptCS = 0x10000000,

            /// <summary>
            /// Channel data should be sent with high Multipoint Communications Services (MCS) priority.
            /// </summary>
            PriorityHigh = 0x08000000,

            /// <summary>
            /// Channel data should be sent with medium MCS priority.
            /// </summary>
            PriorityMedium = 0x04000000,

            /// <summary>
            /// Channel data should be sent with low MCS priority.
            /// </summary>
            PriorityLow = 0x02000000,

            /// <summary>
            /// Virtual channel data should be compressed if RDP data is being compressed.
            /// </summary>
            CompressRDP = 0x00800000,

            /// <summary>
            /// Virtual channel data should be compressed, regardless of Remote Desktop Protocol (RDP) compression.
            /// </summary>
            Compress = 0x00400000,

            /// <summary>
            /// Affects how data sent by the VirtualChannelWrite function is received at the server end. If this value is set, each data block is preceded by a CHANNEL_PDU_HEADER structure. If this value is not set, the data block includes only the data specified to VirtualChannelWrite.
            /// </summary>
            ShowProtocol = 0x00200000,

            /// <summary>
            /// The channel is declared as remote control persistent. This means that the channel will not be closed when a remote control connects to or disconnects from the session connected to the client. For more information, see Remote Control Persistent Virtual Channels. 
            /// </summary>
            RemoteControlPersistent = 0x00100000,
        }

        /// <summary>
        /// Channel Return Codes
        /// </summary>
        public enum CHANNEL_RC
        {
            /// <summary>
            /// All good
            /// </summary>
            Ok = 0,

            /// <summary>
            /// The client-side DLL's access is already initialized to Terminal Services virtual channels.
            /// </summary>
            AlreadyInitialized = 1,

            /// <summary>
            /// VirtualChannelInit has not been initialized.
            /// </summary>
            NotInitialized = 2,

            /// <summary>
            /// The client is already connected to a Terminal Server.
            /// </summary>
            AlreadyConnected = 3,

            /// <summary>
            /// Client is not connected to a terminal server.
            /// </summary>
            NotConnected = 4,

            /// <summary>
            /// The pChannel parameter has more channels than can be registered. Therefore, none of the channels were registered. The maximum number of channels allowed per client is CHANNEL_MAX_COUNT.
            /// </summary>
            TooManyChanels = 5,

            /// <summary>
            /// The pChannel parameter is incorrect or the syntax for one of the channel names is incorrect.
            /// </summary>
            BadChannel = 6,

            /// <summary>
            /// The pOpenHandle parameter is not valid.
            /// </summary>
            BadChannelHandle = 7,

            /// <summary>
            /// No buffer available
            /// </summary>
            NoBuffer = 8,

            /// <summary>
            /// The pInitHandle parameter is not valid
            /// </summary>
            BadInitHandle = 9,

            /// <summary>
            /// The channel is not open.
            /// </summary>
            NotOpen = 10,

            /// <summary>
            /// The pChannelOpenEventProc parameter is not valid.
            /// </summary>
            BadProc = 11,

            /// <summary>
            /// Out-of-memory condition. 
            /// </summary>
            NoMemory = 12,

            /// <summary>
            /// The channel name specified by the pChannelName parameter is not registered by the client DLL or is otherwise not valid.
            /// </summary>
            UnknownChannelName = 13,

            /// <summary>
            /// The channel is already open.
            /// </summary>
            AlreadyOpen = 14,

            /// <summary>
            /// VirtualChannelInit was not called from within your VirtualChannelEntry function.
            /// </summary>
            NotInVirtualchannelEntry = 15,

            /// <summary>
            /// The pData parameter not valid.
            /// </summary>
            NullData = 16,

            /// <summary>
            /// The dataLength parameter is zero.
            /// </summary>
            ZeroLength = 17
        }

        /// <summary>
        /// Initializes a client DLL's access to Remote Desktop Services virtual channels. The client calls VirtualChannelInit to register the names of its virtual channels.
        /// </summary>
        /// <param name="initHandle">Pointer to a variable that receives a handle that identifies the client connection. Use this handle to identify the client in subsequent calls to the VirtualChannelOpen function.</param>
        /// <param name="channels">Pointer to an array of CHANNEL_DEF structures. Each structure contains the name and initialization options of a virtual channel that the client DLL will open. Note that the VirtualChannelInit call does not open these virtual channels; it only reserves the names for use by this application.</param>
        /// <param name="channelCount">Specifies the number of entries in the pChannel array.</param>
        /// <param name="versionRequested">Specifies the level of virtual channel support. Set this parameter to VIRTUAcHANNEL_VERSION_WIN2000.</param>
        /// <param name="channelInitEventProc">Pointer to an application-defined VirtualChannelInitEvent function that Remote Desktop Services calls to notify the client DLL of virtual channel events.</param>
        /// <returns></returns>
        public delegate CHANNEL_RC VirtualChannelInit(ref IntPtr initHandle, CHANNEL_OPTION[] channels, int channelCount, int versionRequested, [MarshalAs(UnmanagedType.FunctionPtr)] VirtualChannelInitEvent channelInitEventProc);

        /// <summary>
        /// Opens the client end of a virtual channel.
        /// Remote Desktop Services provides a pointer to a VirtualChannelOpen function in the CHANNEL_ENTRY_POINTS structure passed to your VirtualChannelEntry entry point.
        /// </summary>
        /// <param name="pInitHandle">Handle to the client connection. This is the handle returned in the ppInitHandle parameter of the VirtualChannelInit function.</param>
        /// <param name="pOpenHandle">Pointer to a variable that receives a handle that identifies the open virtual channel in subsequent calls to the VirtualChannelWrite and VirtualChannelClose functions.</param>
        /// <param name="pChannelName">Pointer to a null-terminated ANSI character string containing the name of the virtual channel to open. The name must have been registered when the client called the VirtualChannelInit function.</param>
        /// <param name="pChannelOpenEventProc">Pointer to an application-defined VirtualChannelOpenEvent function that Remote Desktop Services calls to notify the client DLL of events for this virtual channel.</param>
        /// <returns>If the function succeeds, the return value is CHANNEL_RC_OK.</returns>
        public delegate CHANNEL_RC VirtualChannelOpen(IntPtr pInitHandle, ref int pOpenHandle, [MarshalAs(UnmanagedType.LPStr)] string pChannelName, [MarshalAs(UnmanagedType.FunctionPtr)] VirtualChannelOpenEvent pChannelOpenEventProc);
        
        /// <summary>
        /// Closes the client end of a virtual channel.
        /// Remote Desktop Services provides a pointer to a VirtualChannelClose function in the CHANNEL_ENTRY_POINTS structure passed to your VirtualChannelEntry entry point.
        /// </summary>
        /// <param name="openHandle">Handle to the virtual channel. This is the handle returned in the pOpenHandle parameter of the VirtualChannelOpen function.</param>
        /// <returns></returns>
        public delegate CHANNEL_RC VirtualChannelClose(int openHandle);

        /// <summary>
        /// Sends data from the client end of a virtual channel to a partner application on the server end.
        /// Remote Desktop Services provides a pointer to a VirtualChannelWrite function in the CHANNEL_ENTRY_POINTS structure passed to your VirtualChannelEntry entry point.
        /// </summary>
        /// <param name="openHandle">Handle to the virtual channel. This is the handle returned in the pOpenHandle parameter of the VirtualChannelOpen function.</param>
        /// <param name="pData ">Pointer to a buffer containing the data to write.</param>
        /// <param name="dataLength">Specifies the number of bytes of the data in the pData buffer to write.</param>
        /// <param name="pUserData">An application-defined value. This value is passed to your VirtualChannelOpenEvent function when the write operation is completed or canceled.</param>
        /// <returns>If the function succeeds, the return value is CHANNEL_RC_OK.</returns>
        public delegate CHANNEL_RC VirtualChannelWrite(int openHandle, byte[] pData, uint dataLength, IntPtr pUserData);

        /// <summary>
        /// An application-defined callback function that Remote Desktop Services calls to notify the client DLL of virtual channel events.
        /// </summary>
        /// <param name="pInitHandle">Handle to the client connection. This is the handle returned in the ppInitHandle parameter of the VirtualChannelInit function.</param>
        /// <param name="e">Indicates the event that caused the notification. </param>
        /// <param name="data">Pointer to additional data for the event. The type of data depends on the event, as described previously in the event descriptions.</param>
        /// <param name="dataLength">Specifies the size, in bytes, of the data in the pData buffer.</param>
        public delegate void VirtualChannelInitEvent(IntPtr pInitHandle, CHANNEL_EVENT e, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] data, int dataLength);

        /// <summary>
        /// An application-defined callback function that Remote Desktop Services calls to notify the client DLL of events for a specific virtual channel.
        /// </summary>
        /// <param name="openHandle">Handle to the virtual channel. This is the handle returned in the pOpenHandle parameter of the VirtualChannelOpen function.</param>
        /// <param name="e">Indicates the event that caused the notification.</param>
        /// <param name="data">Pointer to additional data for the event. The type of data depends on the event, as described previously in the event descriptions. </param>
        /// <param name="dataLength">Specifies the size, in bytes, of the data in the pData buffer.</param>
        /// <param name="totalLength">Specifies the total size, in bytes, of the data written by a single write operation to the server end of the virtual channel.</param>
        /// <param name="dataFlags">Provides information about the chunk of data being received in a CHANNEL_EVENT_DATA_RECEIVED event.</param>
        public delegate void VirtualChannelOpenEvent(int openHandle, CHANNEL_EVENT e, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] data, int dataLength, uint totalLength, CHANNEL_FLAG dataFlags);

        /// <summary>
        /// Opens a handle to the server end of a specified virtual channel.
        /// This function is obsolete. Instead, use the WTSVirtualChannelOpenEx function.
        /// </summary>
        /// <param name="hServer ">This parameter must be WTS_CURRENT_SERVER_HANDLE.</param>
        /// <param name="SessionId">A Remote Desktop Services session identifier. To indicate the current session, specify WTS_CURRENT_SESSION. You can use the WTSEnumerateSessions function to retrieve the identifiers of all sessions on a specified RD Session Host server.</param>
        /// <param name="pVirtualName">A pointer to a null-terminated string containing the virtual channel name. Note that this is an ANSI string even when UNICODE is defined. The virtual channel name consists of one to CHANNEname_LEN characters, not including the terminating null.</param>
        /// <returns>If the function succeeds, the return value is a handle to the specified virtual channel.</returns>
        [DllImport("Wtsapi32.dll")]
        public static extern IntPtr WTSVirtualChannelOpen(IntPtr hServer, int SessionId, [MarshalAs(UnmanagedType.LPStr)] string pVirtualName);

        /// <summary>
        /// Writes data to the server end of a virtual channel.
        /// </summary>
        /// <param name="hChannelHandle"></param>
        /// <param name="Buffer"></param>
        /// <param name="Length"></param>
        /// <param name="pBytesWritten"></param>
        /// <returns></returns>
        [DllImport("Wtsapi32.dll", SetLastError = true)]
        public static extern bool WTSVirtualChannelWrite(IntPtr hChannelHandle, byte[] Buffer, int Length, out int pBytesWritten);

        /// <summary>
        /// Writes data to the server end of a virtual channel.
        /// </summary>
        /// <param name="hChannelHandle">Handle to a virtual channel opened by the WTSVirtualChannelOpen function. </param>
        /// <param name="Buffer">Pointer to a buffer containing the data to write to the virtual channel.</param>
        /// <param name="Length">Specifies the size, in bytes, of the data to write.</param>
        /// <param name="pBytesRead">Pointer to a variable that receives the number of bytes written.</param>
        /// <returns></returns>
        [DllImport("Wtsapi32.dll", SetLastError = true)]
        public static extern bool WTSVirtualChannelRead(IntPtr hChannelHandle, byte[] Buffer, int Length, out int pBytesRead);

        /// <summary>
        /// Closes an open virtual channel handle.
        /// </summary>
        /// <param name="hChannelHandle">Handle to a virtual channel opened by the WTSVirtualChannelOpen function.</param>
        /// <returns></returns>
        [DllImport("Wtsapi32.dll")]
        public static extern bool WTSVirtualChannelClose(IntPtr hChannelHandle);

        /// <summary>
        /// Obtains the primary access token of the logged-on user specified by the session ID. To call this function successfully, the calling application must be running within the context of the LocalSystem account and have the SE_TCB_NAME privilege.
        /// </summary>
        /// <param name="SessionId">A Remote Desktop Services session identifier. Any program running in the context of a service will have a session identifier of zero (0). You can use the WTSEnumerateSessions function to retrieve the identifiers of all sessions on a specified RD Session Host server. </param>
        /// <param name="phToken">If the function succeeds, receives a pointer to the token handle for the logged-on user. Note that you must call the CloseHandle function to close this handle.</param>
        /// <returns>If the function succeeds, the return value is a nonzero value, and the phToken parameter points to the primary token of the user. If the function fails, the return value is zero. To get extended error information, call GetLastError</returns>
        [DllImport("Wtsapi32.dll", SetLastError = true)]
        public static extern bool WTSQueryUserToken(int SessionId, out IntPtr phToken);
    }
}
