using System;
using System.Runtime.InteropServices;

namespace CustomerSkin.Win32.Com
{
    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    public struct tagPOINT
    {
        [MarshalAs(UnmanagedType.I4)]
        public int X;
        [MarshalAs(UnmanagedType.I4)]
        public int Y;
    }
}
