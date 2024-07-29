namespace PressureUpper.Database
{
    
    public class PatientQueryCondition
    {
        public string Name { get; set; } = string.Empty;

        public string MedicalRecordNum { get; set; } = string.Empty;//病历号

        public string Doctor { get; set; } = string.Empty;//主管医生

        public DateTime BegainTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsSetCondition { get; set; }

    }
}
