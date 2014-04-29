////////////////////////////////////////////////////////////////////////////
////                PicWinUSB by J1M - www.hobbypic.com                 ////
////                                                                    ////
////    This aplication shows how to use Microsoft WinUSB driver with   ////
////    a PIC 18F2550. Information has been extracted from MSDN:        ////
////                                                                    ////
////    - How to Use WinUSB to Communicate with a USB Device:           ////
////    http://www.microsoft.com/whdc/device/connect/WinUsb_HowTo.mspx  ////
////    - WinUSB:                                                       ////
////    http://msdn2.microsoft.com/en-us/library/aa476426.aspx          ////
////    - WinUSB User-Mode Client Support Routines:                     ////
////    http://msdn2.microsoft.com/en-us/library/aa476437.aspx          ////
////                                                                    ////
////    PicWinUSB is offered AS-IS and without warranty of any kind.    ////
////    You cannot copy, distribute or sell this code.                  ////
////                                                                    ////
////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace PicWinUSB
{
    class DeviceInterfaceImports
    {
        public const int DIGCF_PRESENT = 0x00000002;
        public const int DIGCF_DEVICEINTERFACE = 0x00000010;

        public const int FILE_ATTRIBUTE_NORMAL = 0x00000080;
        public const int FILE_FLAG_OVERLAPPED = 0x40000000;

        [StructLayout(LayoutKind.Sequential)]
        public struct SP_DEVICE_INTERFACE_DATA
        {
            public int cbSize;
            public Guid InterfaceClassGuid;
            public int Flags;
            public IntPtr Reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            public int cbSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string DevicePath;
        }

        [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetupDiGetClassDevs(
            ref Guid ClassGuid,
            [MarshalAs(UnmanagedType.LPTStr)] string Enumerator,
            IntPtr hwndParent, 
            UInt32 Flags);

        [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Boolean SetupDiEnumDeviceInterfaces(
            IntPtr hDevInfo,
            IntPtr devInfo, 
            ref Guid interfaceClassGuid, 
            UInt32 memberIndex, 
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        [DllImport(@"setupapi.dll", SetLastError = true)]
        public static extern Boolean SetupDiGetDeviceInterfaceDetail(
            IntPtr hDevInfo,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            IntPtr deviceInterfaceDetailData,
            UInt32 deviceInterfaceDetailDataSize,
            out UInt32 requiredSize,
            IntPtr deviceInfoData);

        [DllImport(@"setupapi.dll", SetLastError = true)]
        public static extern Boolean SetupDiGetDeviceInterfaceDetail(
            IntPtr hDevInfo,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData,
            UInt32 deviceInterfaceDetailDataSize,
            out UInt32 requiredSize,
            IntPtr deviceInfoData);

        [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern UInt16 SetupDiDestroyDeviceInfoList(
            IntPtr hDevInfo);

        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateFile(
            string fileName,
            FileAccess fileAccess,
            FileShare fileShare,
            IntPtr securityAttributes,
            FileMode creationDisposition,
            UInt32 flags,
            IntPtr template);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(
            IntPtr hObject);
    }
}