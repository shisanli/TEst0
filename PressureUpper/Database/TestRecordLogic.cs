using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper.Database
{
    public class TestRecordLogic
    {
        public int InsertTestRecord(TestRecord TR)
        {
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into TestRecord (Name,Weight,Height,Age,Sex,MedicalRecordNum,EnterTime,OperationDate,BegainTime,EndTime,");
            sb.Append("OperationPart,DoctorID,Doctor,HardwareNumber,Left,Right,OnePath,TwoPath,ReportPath,Mark) values (");
            sb.Append("@Name,@Weight,@Height,@Age,@Sex,@MedicalRecordNum,@EnterTime,@OperationDate,@BegainTime,@EndTime,");
            sb.Append("@OperationPart,@DoctorID,@Doctor,@HardwareNumber,@Left,@Right,@OnePath,@TwoPath,@ReportPath,@Mark)");
            db.ClearParam();
            db.AddParam("@Name", TR.Name);
            db.AddParam("@Weight", TR.Weight);
            db.AddParam("@Height", TR.Height);
            db.AddParam("@Age", TR.Age);
            db.AddParam("@Sex", TR.Sex);
            db.AddParam("@MedicalRecordNum", TR.MedicalRecordNum);
            db.AddParam("@EnterTime", TR.EnterTime);
            db.AddParam("@OperationDate", TR.OperationDate);
            db.AddParam("@BegainTime", TR.BegainTime);
            db.AddParam("@EndTime", TR.EndTime);
            db.AddParam("@OperationPart", TR.OperationPart);
            db.AddParam("@DoctorID", TR.DoctorID);
            db.AddParam("@Doctor", TR.Doctor);
            db.AddParam("@HardwareNumber", TR.HardwareNumber);
            db.AddParam("@Left", TR.Left);
            db.AddParam("@Right", TR.Right);
            db.AddParam("@OnePath", TR.OnePath);
            db.AddParam("@TwoPath", TR.TwoPath);
            db.AddParam("@ReportPath",TR.ReportPath);
            db.AddParam("@Mark", TR.Mark);


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

            //return db.ExecuteNonQuery(sb.ToString());
        }

        public bool DeleteRecord(int ID)
        {
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from TestRecord ");
            sb.Append(" where ID=@ID");
            db.ClearParam();
            db.AddParam("@ID", ID);
            return db.ExecuteNonQuery(sb.ToString()) == 0;
        }

        public int GetRecordCount(RecordQueryCondition condition)
        {
            string strWhere = GetStrWhere(condition);
            int count = 0;
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) as count from TestRecord ");
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
        private string GetStrWhere(RecordQueryCondition condition)
        {
            string strWhere = " 1=1 ";
            if (!condition.Name.Equals(string.Empty))
                strWhere += " and Name like %" + condition.Name + "% ";
            if (condition.BegainTime > DateTime.MinValue)
                strWhere += " and TestDate >='" + condition.BegainTime.ToString("yyyy-MM-dd") +"'";
            if (condition.EndTime > DateTime.MinValue)
                strWhere += " and TestDate <='" + condition.EndTime.ToString("yyyy-MM-dd") +"'";
            if (condition.HardwareNumber > 0)
                strWhere += " and  HardwareNumber=" + condition.HardwareNumber.ToString();
            return strWhere;
        }
        public DataTable GetListByPage(RecordQueryCondition condition ,int startIndex, int endIndex)
        {
            string orderby ="";
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
            strSql.Append(")AS Row, T.*  from TestRecord T ");
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
