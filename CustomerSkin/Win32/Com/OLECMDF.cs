using System;

namespace CustomerSkin.Win32.Com
{
    public enum OLECMDF
    {
        OLECMDF_SUPPORTED = 1,
        OLECMDF_ENABLED = 2,
        OLECMDF_LATCHED = 4,
        OLECMDF_NINCHED = 8,
        OLECMDF_INVISIBLE = 0x10,
        OLECMDF_DEFHIDEONCTXTMENU = 0x20
    }
}
