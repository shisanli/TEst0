using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper.Database
{
    public class Doctor
    {
        public int ID { get; set; } //ID

        public string AccountNum { get; set; } = string.Empty;//账号

        public string Password { get; set; } = string.Empty;//密码

        public string Name { get; set; } = string.Empty;//姓名

        public string Sex { get; set; } = string.Empty;//性别

        public string Department { get; set; } = string.Empty;//科室

        public DateTime CreateTime { get; set; }//创建时间

        public int OperationNum { get; set; }//手术次数

        public bool IsAdmin { get; set; }//是否管理员

        public bool IsDeleted { get; set; }//是否删除

        public string Mark { get; set; } = string.Empty;//备注


        public bool IsSetContent { get; set; }//是否设置信息

        
    }
}
