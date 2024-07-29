
using System;
using System.Runtime.InteropServices;

namespace CustomerSkin.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct STYLESTRUCT
    {
        public int styleOld;
        public int styleNew;
    }
}
