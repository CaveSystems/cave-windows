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

#if !NETSTANDARD20

using Cave.Media.Structs;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Desktop Window Manager (DWM) interface class
    /// </summary>
    public class DWMAPI
    {
        internal static class SafeNativeMethods
        {
            /// <summary>
            /// Extends the window frame behind the client area
            /// </summary>
            /// <param name="handle">The handle to the window for which the frame is extended into the client area.</param>
            /// <param name="margins">A pointer to a MARGINS structure that describes the margins to use when extending the frame into the client area.</param>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmExtendFrameIntoClientArea(IntPtr handle, ref MARGINS margins);

            /// <summary>
            /// Obtains a value that indicates whether Desktop Window Manager (DWM) composition is enabled
            /// </summary>
            /// <returns></returns>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern bool DwmIsCompositionEnabled();

            /// <summary>
            /// Enables the blur effect on a specified window.
            /// </summary>
            /// <param name="handle">The handle to the window on which the blur behind data is applied.</param>
            /// <param name="blurBehind">A pointer to a DWM_BLURBEHIND structure that provides blur behind data.</param>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmEnableBlurBehindWindow(IntPtr handle, DWM_BLURBEHIND blurBehind);

            /// <summary>
            /// Enables or disables Desktop Window Manager (DWM) composition.
            /// </summary>
            /// <param name="enable"></param>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmEnableComposition(bool enable);

            /// <summary>
            /// Retrieves the current color used for Desktop Window Manager (DWM) glass composition. This value is based on the current color scheme and is modifiable by the user. Applications can listen for color changes by handling the WM_DWMCOLORIZATIONCOLORCHANGED notification.
            /// </summary>
            /// <param name="colorization">A pointer to a value that, when this function returns successfully, receives the current color used for glass composition. The color format of the value is 0xAARRGGBB.</param>
            /// <param name="opaqueBlend">A pointer to a value that, when this function returns successfully, indicates whether the color is an opaque blend. TRUE if the color is an opaque blend; otherwise, FALSE.</param>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmGetColorizationColor(out int colorization, [MarshalAs(UnmanagedType.Bool)]out bool opaqueBlend);

            /// <summary>
            /// Creates a Desktop Window Manager (DWM) thumbnail relationship between the destination and source windows.
            /// </summary>
            /// <param name="destinationHandle">The handle to the window that will use the DWM thumbnail. Setting the destination window handle to anything other than a top-level window type will result in E_INVALIDARG.</param>
            /// <param name="sourceHandle">The handle to the window to use as the thumbnail source. Setting the source window handle to anything other than a top-level window type will result in E_INVALIDARG.</param>
            /// <returns></returns>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern IntPtr DwmRegisterThumbnail(IntPtr destinationHandle, IntPtr sourceHandle);

            /// <summary>
            /// Removes a Desktop Window Manager (DWM) thumbnail relationship created by DwmRegisterThumbnail.
            /// </summary>
            /// <param name="thumbnailHandle">The handle to the thumbnail relationship to be removed. Null or non-existent handles will result in E_INVALIDARG.</param>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmUnregisterThumbnail(IntPtr thumbnailHandle);

            /// <summary>
            /// Updates the properties for a given Desktop Window Manager (DWM) thumbnail.
            /// </summary>
            /// <param name="thumbnailHandle">The handle to the DWM thumbnail to be updated. Null or invalid thumbnails, as well as thumbnails owned by other processes will result in E_INVALIDARG.</param>
            /// <param name="properties">A pointer to a DWM_THUMBNAIL_PROPERTIES structure that contains the new thumbnail properties.</param>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmUpdateThumbnailProperties(IntPtr thumbnailHandle, DWM_THUMBNAIL_PROPERTIES properties);

            /// <summary>
            /// Returns the source size of the Desktop Window Manager (DWM) thumbnail.
            /// </summary>
            /// <param name="thumbnailHandle">A handle of the thumbnail to retrieve the source window size from.</param>
            /// <param name="size">A pointer to a SIZE structure that, when this function returns successfully, receives the size of the source thumbnail.</param>
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmQueryThumbnailSourceSize(IntPtr thumbnailHandle, out Size size);
        }
    }
}

#endif