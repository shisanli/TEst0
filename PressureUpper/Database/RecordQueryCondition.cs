using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper.Database
{
   
    public class RecordQueryCondition
    {
        public string Name { get; set; } = string.Empty;

        public string Doctor { get; set; } = string.Empty;//主管医生

        public string MedicalRecordNum { get; set; } = string.Empty;//病历号

        public DateTime EnterTime { get; set; }//入院时间

        public DateTime BegainTime { get; set; }

        public DateTime EndTime { get; set;}

        public int HardwareNumber { get; set; }//设备编号

        public bool IsSetCondition { get; set; }

    }
}
