using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper.Database
{
    public class TestRecordItem
    {
        public int ID { get; set; } //ID

        public int RecordID { get; set; }//记录ID

        public int RoundNum { get; set; }//当前轮数

        public int Angle { get; set; }//角度

        public decimal Inside { get; set; }//内侧

        public decimal Outside { get; set; }//外侧

        public DateTime RecordTime { get; set; }//记录时间

        public decimal ResultantForce { get; set; }//两侧合力

        public decimal ForceDifference { get; set; }//两侧力差

        public string EvaluationIndex { get; set; } = string.Empty;//评价指标

        public string Mark { get; set; } = string.Empty;//备注
    }
}
