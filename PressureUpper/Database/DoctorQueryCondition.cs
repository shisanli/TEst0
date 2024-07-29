using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper.Database
{
    public class DoctorQueryCondition
    {
        public string AccountNum { get; set; } = string.Empty;//账号

        public string Name { get; set; } = string.Empty;

        public DateTime CreateTime { get; set; }//创建时间

        public string Department { get; set; } = string.Empty;//科室

        public bool IsSetCondition { get; set; }
    }
}
