
using System;
using System.Runtime.InteropServices;

namespace CustomerSkin.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public class MOUSEHOOKSTRUCTEX
    {
        public MOUSEHOOKSTRUCT Mouse;
        public int mouseData;
    }
}
