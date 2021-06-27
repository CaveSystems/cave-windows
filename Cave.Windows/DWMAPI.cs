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
