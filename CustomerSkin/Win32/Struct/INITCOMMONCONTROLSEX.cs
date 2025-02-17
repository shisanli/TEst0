
using System;
using System.Runtime.InteropServices;

namespace CustomerSkin.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct INITCOMMONCONTROLSEX
    {
        public INITCOMMONCONTROLSEX(int flags)
        {
            this.dwSize = Marshal.SizeOf(typeof(INITCOMMONCONTROLSEX));
            this.dwICC = flags;
        }

        public int dwSize;
        public int dwICC;
    }
}
