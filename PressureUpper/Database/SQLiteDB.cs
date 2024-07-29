using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper.Database
{
    /// <summary>
    /// SQLite封装
    /// </summary>
    public class SQLiteDB : IDisposable
    {
        #region 私有字段

        private readonly string DB_PATH = Directory.GetCurrentDirectory() + @"\Database\Pressure.db";
        private readonly string DB_SCRIPT_PATH = Directory.GetCurrentDirectory() + @"\Database\db.sql";
        /// <summary>
        /// 连接实例
        /// </summary>
        private SQLiteConnection conn;

        /// <summary>
        /// 事务实例
        /// </summary>
        private SQLiteTransaction tran;

        /// <summary>
        /// 命令对象实例
        /// </summary>
        private SQLiteCommand? com;

        /// <summary>
        /// 参数
        /// </summary>
        private Dictionary<string, object> param;

        /// <summary>
        /// 事务是否打开
        /// </summary>
        private bool isTran = false;

        #endregion

        #region 公共方法

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">链接字符串</param>
        public SQLiteDB(string connectionString)
        {
            if (this.conn == null)
            {
                this.conn = this.GetConnection(connectionString);
                this.conn.Open();
            }
            this.tran = this.conn.BeginTransaction();
            this.isTran = true;

            this.param = new Dictionary<string, object>();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="server">Server实例</param>
        /// <remarks>利用默认设定</remarks>
        public SQLiteDB()
        {
            this.Init();
            if (this.conn == null)
            {
                this.conn = this.GetConnection("Data Source=" + DB_PATH);
                this.conn.Open();
            }
            this.tran = this.conn.BeginTransaction();
            this.isTran = true;

            this.param = new Dictionary<string, object>();
        }

        private void Init(bool overwrite = false)
        {
            /* 创建数据库文件 */
            if (!File.Exists(DB_PATH))
            {
                SQLiteConnection.CreateFile(DB_PATH);
                overwrite = true;
            }

            if (overwrite)
            {
                this.conn = this.GetConnection("Data Source=" + DB_PATH+ ";Version=3;foreign keys=true;");
                this.conn.Open();
                com = this.conn.CreateCommand();
                /* 读取 sql script 文件 */
                com.CommandText = File.ReadAllText(DB_SCRIPT_PATH);

                /* 执行 sql script */
                try { com.ExecuteNonQuery(); }
                catch (SQLiteException e) { Console.WriteLine(e.StackTrace); }
                //初始化默认管理员
                string sql = @" insert into Doctor(AccountNum,Password,Name,Sex,Department,CreateTime,OperationNum,IsAdmin,IsDeleted,Mark) values (
                               'admin','" + ValidateHelper.SHA1Encrypt("1129")+"','管理员','男','管理','"+DateTime.Now.ToString()+"',0,1,0,'')";
                com.CommandText = sql;
                com.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 追加参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">値</param>
        public void AddParam(string key, object value)
        {
            this.param.Add(key, value);
        }

        /// <summary>
        /// 清除参数
        /// </summary>
        public void ClearParam()
        {
            this.param.Clear();
        }

        /// <summary>
        /// SQL执行(注册、更新、删除)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>処理数</returns>
        public int ExecuteNonQuery(string sql)
        {
            int s = 0;
            using SQLiteCommand command = conn.CreateCommand();
            try
            {
                command.CommandText = sql;

                foreach (var key in this.param.Keys)
                {
                    command.Parameters.AddWithValue(key, this.param[key]);
                }

                s = command.ExecuteNonQuery();
            }catch(SQLiteException e)
            {
                string r = e.Message;   
            }
            return s;
        }

        


        /// <summary>
        /// 检索SQL执行 返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>检索结果</returns>
        public DataTable Fill(string sql)
        {
            using SQLiteCommand command = conn.CreateCommand();
            command.CommandText = sql;

            foreach (var key in this.param.Keys)
            {
                command.Parameters.AddWithValue(key, this.param[key]);
            }

            using SQLiteDataReader reader = command.ExecuteReader();
            //获取模式
            var result = this.GetSchema(reader);

            while (reader.Read())
            {
                var addRow = result.NewRow();

                foreach (DataColumn col in result.Columns)
                {
                    addRow[col.ColumnName] = reader[col.ColumnName];
                }

                result.Rows.Add(addRow);
            }

            return result;
        }

        
       

        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            this.tran.Commit();
            this.isTran = false;
        }

        /// <summary>
        /// 回滚
        /// </summary>
        public void Rollback()
        {
            this.tran.Rollback();
            this.isTran = false;
        }

        /// <summary>
        /// 解放処理
        /// </summary>
        public void Dispose()
        {
            if (this.isTran)
            {
                this.tran.Rollback();
            }
            this.com?.Dispose();
            this.tran.Dispose();
            this.conn.Close();
            this.conn.Dispose();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 生成连接
        /// </summary>
        /// <param name="connectionString">链接字符串</param>
        /// <returns>连接实例</returns>
        private SQLiteConnection GetConnection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }

        /// <summary>
        /// 取得数据模式Schema
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private DataTable GetSchema(SQLiteDataReader reader)
        {
            var result = new DataTable();

            for (var i = 0; i < reader.FieldCount; i++)
            {
                result.Columns.Add(new DataColumn(reader.GetName(i)));
            }

            return result;
        }
        #endregion
    }
}