using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper.Database
{
    public class TestRecordItemLogic
    {
        public int InsertTestRecordItem(TestRecordItem item)
        {
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into TestRecordItem (RecordID,RoundNum,Angle,Inside,Outside,RecordTime,ResultantForce,");
            sb.Append("ForceDifference,EvaluationIndex,Mark) values (");
            sb.Append("@RecordID,@RoundNum,@Angle,@Inside,@Outside,@RecordTime,@ResultantForce,");
            sb.Append("@HardwareNumber,@Seat,@Backrest,@OnePath,@TwoPath,@ReportPath,@Mark)");
            db.ClearParam();
            db.AddParam("@RecordID", item.RecordID);
            db.AddParam("@RoundNum", item.RoundNum);
            db.AddParam("@Angle", item.Angle);
            db.AddParam("@Inside", item.Inside);
            db.AddParam("@Outside", item.Outside);
            db.AddParam("@RecordTime", item.RecordTime);
            db.AddParam("@ResultantForce", item.ResultantForce);
            db.AddParam("@EvaluationIndex", item.EvaluationIndex);
            db.AddParam("@Mark", item.Mark);


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
            sb.Append("delete from TestRecordItem ");
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
            sb.Append("select count(1) as count from TestRecordItem ");
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
                strWhere += " and TestDate >='" + condition.BegainTime.ToString("yyyy-MM-dd") + "'";
            if (condition.EndTime > DateTime.MinValue)
                strWhere += " and TestDate <='" + condition.EndTime.ToString("yyyy-MM-dd") + "'";
            if (condition.HardwareNumber > 0)
                strWhere += " and  HardwareNumber=" + condition.HardwareNumber.ToString();
            return strWhere;
        }
        public DataTable GetListByPage(RecordQueryCondition condition, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.*  from TestRecordItem T ");
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
