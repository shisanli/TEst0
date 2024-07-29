using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper.Database
{
    public class TestRecord
    {
        public int ID { get; set; } //ID
        public string Name { get; set; } = string.Empty;//被试姓名

        public decimal Weight { get; set; }//体重

        public decimal Height { get; set; }//身高

        public int Age { get; set; }//年龄

        public string Sex { get; set; } = string.Empty;

        public string MedicalRecordNum { get; set; } = string.Empty;//病历号

        public DateTime EnterTime { get; set; }//入院时间

        public DateTime OperationDate { get; set; }//手术日期

        public DateTime BegainTime { get; set; }//测试开始时间

        public DateTime EndTime { get; set; }//测试结束时间

        public string OperationPart { get; set; } = string.Empty;//手术部位  左膝 右膝

        public int DoctorID { get; set; }//医生ID

        public string Doctor { get; set; } = string.Empty;//医生

        public string HardwareNumber { get; set; } = string.Empty;//设备编号

        public bool Left { get; set; }//是否测试左膝
        public bool Right { get; set; }//是否测试右膝

        public string OnePath { get; set; } = string.Empty;//手术记录文件路径

        public string TwoPath { get; set; } = string.Empty;//手术快照文件路径

        public string ReportPath { get; set; } = string.Empty;//报告存放路径

        public string Mark { get; set; } = string.Empty;//备注

        public List<TestRecordItem> Items { get; set; } = new List<TestRecordItem>();
    }
}
