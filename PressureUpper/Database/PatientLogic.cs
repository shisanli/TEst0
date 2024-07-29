using System.Data;
using System.Text;

namespace PressureUpper.Database
{
    public class PatientLogic
    {
        public int InsertPatient(Patient? patient)
        {
            if (patient == null) return 0;
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Patient (Name,MedicalRecordNum,Sex,Weight,Height,Age,DoctorID,");
            sb.Append("Doctor,AnesthesiologistID,Anesthesiologist,EnterTime,Score,MedicalHistory,DrugAllergy,");
            sb.Append(" DiagnosticResult,OtherInformation,IsDeleted,Mark) values (");
            sb.Append("@Name,@MedicalRecordNum,@Sex,@Weight,@Height,@Age,@DoctorID,@Doctor,@AnesthesiologistID,@Anesthesiologist,");
            sb.Append("@EnterTime,@Score,@MedicalHistory,@DrugAllergy,@DiagnosticResult,@OtherInformation,@IsDeleted,@Mark)");
            db.ClearParam();
            db.AddParam("@Name", patient.Name);
            db.AddParam("@MedicalRecordNum", patient.MedicalRecordNum);
            db.AddParam("@Sex", patient.Sex);
            db.AddParam("@Weight", patient.Weight);
            db.AddParam("@Height", patient.Height);
            db.AddParam("@Age", patient.Age);
            db.AddParam("@DoctorID", patient.DoctorID);
            db.AddParam("@Doctor", patient.Doctor);
            db.AddParam("@AnesthesiologistID", patient.AnesthesiologistID);
            db.AddParam("@Anesthesiologist", patient.Anesthesiologist);
            db.AddParam("@EnterTime", patient.EnterTime);
            db.AddParam("@Score", patient.Score);
            db.AddParam("@MedicalHistory", patient.MedicalHistory);
            db.AddParam("@DrugAllergy", patient.DrugAllergy);
            db.AddParam("@DiagnosticResult", patient.DiagnosticResult);
            db.AddParam("@OtherInformation", patient.OtherInformation);
            db.AddParam("@IsDeleted", patient.IsDeleted);
            db.AddParam("@Mark", patient.Mark);


            object obj = db.ExecuteNonQuery(sb.ToString());
            db.Commit();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
          
        }

        public int UpdatePatient(Patient patient)
        {
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("update Patient set Name=@Name,MedicalRecordNum=@MedicalRecordNum,Sex=@Sex,Weight=@Weight,Height=@Height,Age=@Age,DoctorID=@DoctorID,");
            sb.Append("Doctor=@Doctor,AnesthesiologistID=@AnesthesiologistID,Anesthesiologist=@Anesthesiologist,EnterTime=@EnterTime,Score=@Score,MedicalHistory=@MedicalHistory,DrugAllergy=@DrugAllergy,");
            sb.Append(" DiagnosticResult=@DiagnosticResult,OtherInformation=@OtherInformation,IsDeleted=@IsDeleted,Mark=@Mark where ID=@ID");
            db.ClearParam();
            db.AddParam("@Name", patient.Name);
            db.AddParam("@MedicalRecordNum", patient.MedicalRecordNum);
            db.AddParam("@Sex", patient.Sex);
            db.AddParam("@Weight", patient.Weight);
            db.AddParam("@Height", patient.Height);
            db.AddParam("@Age", patient.Age);
            db.AddParam("@DoctorID", patient.DoctorID);
            db.AddParam("@Doctor", patient.Doctor);
            db.AddParam("@AnesthesiologistID", patient.AnesthesiologistID);
            db.AddParam("@Anesthesiologist", patient.Anesthesiologist);
            db.AddParam("@EnterTime", patient.EnterTime);
            db.AddParam("@Score", patient.Score);
            db.AddParam("@MedicalHistory", patient.MedicalHistory);
            db.AddParam("@DrugAllergy", patient.DrugAllergy);
            db.AddParam("@DiagnosticResult", patient.DiagnosticResult);
            db.AddParam("@OtherInformation", patient.OtherInformation);
            db.AddParam("@IsDeleted", patient.IsDeleted);
            db.AddParam("@Mark", patient.Mark);
            db.AddParam("@ID",patient.ID);


            object obj = db.ExecuteNonQuery(sb.ToString());
            db.Commit();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }

        public bool DeleteRecord(int ID)
        {
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Patient ");
            sb.Append(" where ID=@ID");
            db.ClearParam();
            db.AddParam("@ID", ID);
            return db.ExecuteNonQuery(sb.ToString()) == 0;
        }

        //软删除
        public bool SetDeleteMark(int ID)
        {
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("update Patient set  IsDeleted=1");
            sb.Append(" where ID=@ID");
            db.ClearParam();
            db.AddParam("@ID", ID);
            return db.ExecuteNonQuery(sb.ToString()) == 0;
        }

        public int GetRecordCount(PatientQueryCondition condition)
        {
            string strWhere = GetStrWhere(condition);
            int count = 0;
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) as count from Patient ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sb.Append(" WHERE " + strWhere);
            }
            DataTable temp = db.Fill(sb.ToString());
            if (temp.Rows.Count > 0)
            {
                return int.Parse(temp.Rows[0][0].ToString());
            }
            return count;
        }
        private string GetStrWhere(PatientQueryCondition condition)
        {
            string strWhere = " 1=1 ";
            if (!condition.Name.Equals(string.Empty))
                strWhere += " and Name like '%" + condition.Name + "%' ";
            if (condition.MedicalRecordNum.Equals(string.Empty)==false)
                strWhere += " and MedicalRecordNum like '%" + condition.MedicalRecordNum + "%'";
            if (condition.MedicalRecordNum.Equals(string.Empty) == false)
                strWhere += " and Doctor like '%" + condition.Doctor + "%'";
            if (condition.BegainTime > DateTime.MinValue)
                strWhere += " and TestDate >='" + condition.BegainTime.ToString("yyyy-MM-dd") + "'";
            if (condition.EndTime > DateTime.MinValue)
                strWhere += " and TestDate <='" + condition.EndTime.ToString("yyyy-MM-dd") + "'";
            return strWhere;
        }
        public DataTable GetListByPage(PatientQueryCondition condition, int startIndex, int endIndex)
        {
            string orderby = "";
            string strWhere = GetStrWhere(condition);

            using var db = new SQLiteDB();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Patient T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return db.Fill(strSql.ToString());
        }
    }
}
