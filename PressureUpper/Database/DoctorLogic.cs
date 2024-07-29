using System.Data;
using System.Text;

namespace PressureUpper.Database
{
    public class DoctorLogic
    {
        public int InsertDoctor(Doctor doctor)
        {
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Doctor (AccountNum,Password,Name,Sex,Department,CreateTime,OperationNum,");
            sb.Append("IsAdmin,IsDeleted,Mark) values (");
            sb.Append("@AccountNum,@Password,@Name,@Sex,@Department,@CreateTime,@OperationNum,");
            sb.Append("@IsAdmin,@IsDeleted,@Mark)");
            db.ClearParam();
            db.AddParam("@AccountNum", doctor.AccountNum);
            db.AddParam("@Password", doctor.Password);
            db.AddParam("@Name", doctor.Name);
            db.AddParam("@Sex", doctor.Sex);
            db.AddParam("@Department", doctor.Department);
            db.AddParam("@CreateTime", doctor.CreateTime);
            db.AddParam("@OperationNum", doctor.OperationNum);
            db.AddParam("@IsAdmin", doctor.IsAdmin);
            db.AddParam("@IsDeleted", doctor.IsDeleted);
            db.AddParam("@Mark", doctor.Mark);


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

        public int UpdateDoctor(Doctor doctor)
        {
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("update Doctor set AccountNum=@AccountNum,Password=@Password,Name=@Name,Sex=@Sex,Department=@Department,CreateTime=@CreateTime,OperationNum=@OperationNum,");
            sb.Append("IsAdmin=@IsAdmin,IsDeleted=@IsDeleted,Mark=@Mark where ID=@ID");
            db.ClearParam();
            db.AddParam("@AccountNum", doctor.AccountNum);
            db.AddParam("@Password", doctor.Password);
            db.AddParam("@Name", doctor.Name);
            db.AddParam("@Sex", doctor.Sex);
            db.AddParam("@Department", doctor.Department);
            db.AddParam("@CreateTime", doctor.CreateTime);
            db.AddParam("@OperationNum", doctor.OperationNum);
            db.AddParam("@IsAdmin", doctor.IsAdmin);
            db.AddParam("@IsDeleted", doctor.IsDeleted);
            db.AddParam("@Mark", doctor.Mark);
            db.AddParam("@ID",doctor.ID);

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

        public bool DeleteDoctor(int ID)
        {
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Doctor ");
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
            sb.Append("update Doctor set  IsDeleted=1");
            sb.Append(" where ID=@ID");
            db.ClearParam();
            db.AddParam("@ID", ID);
            return db.ExecuteNonQuery(sb.ToString()) == 0;
        }

        //根据账号获取医生
        public Doctor? GetDoctorByAccountNum(string AccountNum)
        {
            Doctor? doctor = null;
            string strSql = @"select * from Doctor where  AccountNum='"+ AccountNum + "'";
            using var db = new SQLiteDB();
            DataTable temp = db.Fill(strSql);
            if (temp.Rows.Count>0)
            {
                doctor = new Doctor
                {
                    ID = int.Parse(temp.Rows[0]["ID"].ToString()),
                    Password = temp.Rows[0]["Password"].ToString(),
                    AccountNum = temp.Rows[0]["AccountNum"].ToString(),
                    Name = temp.Rows[0]["Name"].ToString(),
                    Sex = temp.Rows[0]["Sex"].ToString(),
                    Department = temp.Rows[0]["Department"].ToString(),
                    CreateTime = DateTime.Parse(temp.Rows[0]["CreateTime"].ToString()),
                    OperationNum = int.Parse(temp.Rows[0]["OperationNum"].ToString()),
                    IsAdmin = temp.Rows[0]["IsAdmin"].ToString().Equals("1") ? true : false,
                    IsDeleted = temp.Rows[0]["IsDeleted"].ToString().Equals("1") ? true : false,
                    Mark = temp.Rows[0]["Mark"].ToString()
                };
            }
            return doctor;
        }

        //账号是否存在
        public bool AccountNumIsExist(string AccountNum)
        {
            bool result = false;
            string strSql = @"select * from Doctor where  AccountNum='" + AccountNum + "'";
            using var db = new SQLiteDB();
            DataTable temp = db.Fill(strSql);
            if (temp.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        public int GetRecordCount(DoctorQueryCondition condition)
        {
            string strWhere = GetStrWhere(condition);
            int count = 0;
            using var db = new SQLiteDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) as count from Doctor ");
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
        private string GetStrWhere(DoctorQueryCondition condition)
        {
            string strWhere = " 1=1 ";
            if (!condition.Name.Equals(string.Empty))
                strWhere += " and Name like '%" + condition.Name + "%' ";
            if (condition.AccountNum.Equals(string.Empty)==false)
                strWhere += " and AccountNum ='" + condition.AccountNum +"'";
            if (condition.CreateTime > DateTime.MinValue)
                strWhere += " and TestDate >='" + condition.CreateTime.ToString("yyyy-MM-dd") + "'";
            if (condition.Department.Equals(string.Empty)==false)
                strWhere += " and  Department='" + condition.Department+"'";
            return strWhere;
        }
        public DataTable GetListByPage(DoctorQueryCondition condition, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.*  from Doctor T ");
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

