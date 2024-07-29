
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using CustomerSkin.Win32.Const;

namespace CustomerSkin.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCHITTESTINFO
    {

        public TCHITTESTINFO(Point location)
        {
            Point = location;
            Flags = TCHT.TCHT_ONITEM;
        }

        public Point Point;
        public int Flags;
    }
}
