
using System;

namespace CustomerSkin.SkinControl
{
    internal static class ClientUtils
    {
        public static bool IsEnumValid(
            Enum enumValue,
            int value,
            int minValue,
            int maxValue)
        {
            return ((value >= minValue) && (value <= maxValue));
        }
    }
}
