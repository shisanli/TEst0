namespace PressureUpper.Database
{
    public class Patient
    {
        public int ID { get; set; } //ID
        public string Name { get; set; } = string.Empty;

        public string MedicalRecordNum { get; set; } = string.Empty;//病历号

        public string Sex { get; set; } = string.Empty;//性别

        public decimal Weight { get; set; }//体重

        public decimal Height { get; set; }//身高

        public int Age { get; set; }//年龄

        public int DoctorID { get; set; }//医生ID

        public string Doctor { get; set; } = string.Empty;//主管医生

        public int AnesthesiologistID { get; set; }//麻醉医生ID
        public string Anesthesiologist { get; set; } = string.Empty;//麻醉医生

        public DateTime EnterTime { get; set; }//入院时间

        public decimal Score { get; set; }//评分

        public string MedicalHistory { get; set; } = string.Empty;//病史

        public string DrugAllergy { get; set; } = string.Empty;//药物过敏

        public string DiagnosticResult { get; set; } = string.Empty;//诊断结果

        public string OtherInformation { get; set; } = string.Empty;//其他信息

        public string Mark { get; set; } = string.Empty;//备注

        public bool IsDeleted { get; set; }//是否删除

        public bool IsSetContent { get; set; }//是否设置信息
    }
}
