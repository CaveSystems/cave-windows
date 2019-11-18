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
namespace Cave.Windows
{
    /// <summary>
    /// Connection flags
    /// </summary>
    
    [Flags]
    public enum CONNECT_FLAGS : int
    {
        /// <summary>
        /// The network resource connection should be remembered.
        /// If this bit flag is set, the operating system automatically attempts to restore the connection when the user logs on.
        /// The operating system remembers only successful connections that redirect local devices. It does not remember connections that are unsuccessful or deviceless connections. (A deviceless connection occurs when the lpLocalName member is NULL or points to an empty string.)
        /// If this bit flag is clear, the operating system does not try to restore the connection when the user logs on.
        /// </summary>
        CONNECT_UPDATE_PROFILE = 0x00000001,

        /// <summary>
        /// The network resource connection should not be remembered. If this flag is set, the operating system will not attempt to restore the connection when the user logs on again.
        /// </summary>
        CONNECT_UPDATE_RECENT = 0x00000002,

        /// <summary>
        /// The network resource connection should not be remembered. If this flag is set, the operating system will not attempt to restore the connection when the user logs on again.
        /// </summary>
        CONNECT_TEMPORARY = 0x00000004,

        /// <summary>
        /// If this flag is set, the operating system may interact with the user for authentication purposes.
        /// </summary>
        CONNECT_INTERACTIVE = 0x00000008,

        /// <summary>
        /// This flag instructs the system not to use any default settings for user names or passwords without offering the user the opportunity to supply an alternative. This flag is ignored unless CONNECT_INTERACTIVE is also set.
        /// </summary>
        CONNECT_PROMPT = 0x00000010,

        /// <summary>
        /// This flag forces the redirection of a local device when making the connection.
        /// If the lpLocalName member of NETRESOURCE specifies a local device to redirect, this flag has no effect, because the operating system still attempts to redirect the specified device. When the operating system automatically chooses a local device, the dwType member must not be equal to RESOURCETYPE_ANY.
        /// If this flag is not set, a local device is automatically chosen for redirection only if the network requires a local device to be redirected.
        /// Windows Server 2003 and Windows XP:  When the system automatically assigns network drive letters, letters are assigned beginning with Z:, then Y:, and ending with C:. This reduces collision between per-logon drive letters (such as network drive letters) and global drive letters (such as disk drives). Note that earlier versions of Windows assigned drive letters beginning with C: and ending with Z:.
        /// </summary>
        CONNECT_REDIRECT = 0x00000080,

        /// <summary>
        /// If this flag is set, the operating system prompts the user for authentication using the command line instead of a graphical user interface (GUI). This flag is ignored unless CONNECT_INTERACTIVE is also set.
        /// </summary>
        CONNECT_CURRENT_MEDIA = 0x00000200,

        /// <summary>
        /// If this flag is set, the operating system prompts the user for authentication using the command line instead of a graphical user interface (GUI). This flag is ignored unless CONNECT_INTERACTIVE is also set.
        /// </summary>
        CONNECT_COMMANDLINE = 0x00000800,

        /// <summary>
        /// If this flag is set, and the operating system prompts for a credential, the credential should be saved by the credential manager. If the credential manager is disabled for the caller's logon session, or if the network provider does not support saving credentials, this flag is ignored. This flag is ignored unless CONNECT_INTERACTIVE is also set. This flag is also ignored unless you set the CONNECT_COMMANDLINE flag.
        /// Windows 2000:  This value is supported on Windows 2000 and later.
        /// </summary>
        CONNECT_CMD_SAVECRED = 0x00001000,

        /// <summary>
        /// If this flag is set, and the operating system prompts for a credential, the credential is reset by the credential manager. If the credential manager is disabled for the caller's logon session, or if the network provider does not support saving credentials, this flag is ignored. This flag is also ignored unless you set the CONNECT_COMMANDLINE flag.
        /// Windows Vista:  This value is supported on Windows Vista and later.
        /// </summary>
        CONNECT_CRED_RESET = 0x00002000,
    }
}
