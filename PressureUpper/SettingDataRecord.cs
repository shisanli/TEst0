using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper
{
    public class SettingDataRecord
    {
        public bool IsMessageStart = false;
        public string MessagePortName = "";
        public string MessageBaudRate = "";
        public int MessageFrequancy = 10;
        public float regWeight1 = 1;
        public float regWeight2 = 0;
        public string leftCode = "";
        public string rightCode="";
        public int MessageCaiyangpinlv = 50;
        public SettingDataRecord() {
            
                IsMessageStart = false;
        }
    }
}
