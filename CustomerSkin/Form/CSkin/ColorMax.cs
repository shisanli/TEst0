using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CustomerSkin
{
    public class ColorMax
    {
        private Color color;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private int number = 0;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}
