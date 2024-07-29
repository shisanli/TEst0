using DrawFunctionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper
{
    public class TimePosition
    {
        public DateTime time;
        public DrawFunction3D.PointF3D position=null;

        public DateTime Time
        {
            get;
            set;
        }

        public DrawFunction3D.PointF3D Position
        {
            get;
            set;
        }
    }
}
