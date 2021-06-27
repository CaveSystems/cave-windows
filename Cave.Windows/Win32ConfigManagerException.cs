using System;

namespace Cave.Windows
{
    /// <summary>
    /// Provides an exception for <see cref="CM_ERROR"/> values.
    /// </summary>
    public class Win32ConfigManagerException : Exception
    {
        /// <summary>
        /// Obtains the message for a given error code
        /// </summary>
        /// <param name="errorCode">Any valid <see cref="CM_ERROR"/> value</param>
        /// <returns>Returns a message</returns>
        public static string GetMessage(uint errorCode)
        {
            switch (errorCode)
            {
                case 0: return string.Format("Device is working properly.");
                case 1: return string.Format("Device is not configured correctly.");
                case 2: return string.Format("Windows cannot load the driver for this device.");
                case 3: return string.Format("Driver for this device might be corrupted or the system may be low on memory or other resources.");
                case 4: return string.Format("Device is not working properly. One of its drivers or the registry might be corrupted.");
                case 5: return string.Format("Driver for the device requires a resource that Windows cannot manage.");
                case 6: return string.Format("Boot configuration for the device conflicts with other devices.");
                case 7: return string.Format("Cannot filter.");
                case 8: return string.Format("Driver loader for the device is missing.");
                case 9: return string.Format("Device is not working properly. The controlling firmware is incorrectly reporting the resources for the device.");
                case 10: return string.Format("Device cannot start.");
                case 11: return string.Format("Device failed.");
                case 12: return string.Format("Device cannot find enough free resources to use.");
                case 13: return string.Format("Windows cannot verify the device's resources.");
                case 14: return string.Format("Device cannot work properly until the computer is restarted.");
                case 15: return string.Format("Device is not working properly due to a possible re-enumeration problem.");
                case 16: return string.Format("Windows cannot identify all of the resources that the device uses.");
                case 17: return string.Format("Device is requesting an unknown resource type.");
                case 18: return string.Format("Device drivers must be reinstalled.");
                case 19: return string.Format("Failure using the VxD loader.");
                case 20: return string.Format("Registry might be corrupted.");
                case 21: return string.Format("System failure. If changing the device driver is ineffective see the hardware documentation. Windows is removing the device.");
                case 22: return string.Format("Device is disabled.");
                case 23: return string.Format("System failure. If changing the device driver is ineffective see the hardware documentation.");
                case 24: return string.Format("Device is not present not working properly or does not have all of its drivers installed.");
                case 25: return string.Format("Windows is still setting up the device.");
                case 26: return string.Format("Windows is still setting up the device.");
                case 27: return string.Format("Device does not have valid log configuration.");
                case 28: return string.Format("Device drivers are not installed.");
                case 29: return string.Format("Device is disabled. The device firmware did not provide the required resources.");
                case 30: return string.Format("Device is using an IRQ resource that another device is using.");
                case 31: return string.Format("Device is not working properly. Windows cannot load the required device drivers.");
            }
            return string.Format("Unknown ConfigManagerErrorCode {0} / 0x{1}", errorCode, errorCode.ToString("X"));
        }

        /// <summary>
        /// Obtains the message for a given error code
        /// </summary>
        /// <param name="errorCode">Any valid <see cref="CM_ERROR"/> value</param>
        /// <returns>Returns a message</returns>
        public static string GetMessage(CM_ERROR errorCode) => GetMessage((uint)errorCode);

        /// <summary>
        /// Creates a new exception for the given <see cref="CM_ERROR"/> code
        /// </summary>
        /// <param name="errorCode">Any valid <see cref="CM_ERROR"/> value</param>
        public Win32ConfigManagerException(CM_ERROR errorCode) : base(GetMessage(errorCode)) { }

        /// <summary>
        /// Creates a new exception for the given <see cref="CM_ERROR"/> code
        /// </summary>
        /// <param name="errorCode">Any valid <see cref="CM_ERROR"/> value</param>
        /// <param name="innerException">The inner exception</param>
        public Win32ConfigManagerException(CM_ERROR errorCode, Exception innerException) : base(GetMessage(errorCode), innerException) { }
    }
}
