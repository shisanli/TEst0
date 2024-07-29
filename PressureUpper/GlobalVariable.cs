using PressureUpper.Database;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2211:非常量字段应当不可见", Justification = "<挂起>")]
    public static class GlobalVariable
    {
        
        public static TestRecord? testRecord;

        public static Doctor? doctor;

        public static SerialPort? serialPortOne;

        public static SerialPort? serialPortTwo;

        public static string Status=string.Empty;//连接状态

        public static string BatteryLevel=string.Empty;//电池电压

        public static string CloudPlaybackOrReportView = string.Empty;//是云图回放还是报告查看

    }
}
