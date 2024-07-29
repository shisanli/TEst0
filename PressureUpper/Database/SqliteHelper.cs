using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace PressureUpper.Database
{
    public class SqliteHelper
    {
        private static SqliteHelper _instance;

        public static SqliteHelper GetInstance()
        {
            if (null == _instance)
            {
                _instance = new SqliteHelper();
            }

            return _instance;
        }
        /// <summary>
        /// 数据库连接定义
        /// </summary>
        private SQLiteConnection dbConnection;

        /// <summary>
        /// SQL命令定义
        /// </summary>
        private SQLiteCommand dbCommand;

        /// <summary>
        /// 数据读取定义
        /// </summary>
        private SQLiteDataReader dataReader;

        private SqliteHelper() { }
        public bool CreateDb(string dbPath)
        {
            try
            {
                if (!File.Exists(dbPath))
                {
                    //如果数据库文件不存在,则创建
                    SQLiteConnection.CreateFile(dbPath);
                }
                string conDbPath = "Data Source=" + dbPath;
                dbConnection = new SQLiteConnection(conDbPath);
                if (null == dbConnection)
                {
                    return false;
                }
                dbConnection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public SQLiteDataReader ExecuteQuery(string queryString)
        {
            try
            {
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = queryString;
                dataReader = dbCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }

            return dataReader;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseConncetion()
        {
            //销毁Command
            if (dbCommand != null)
            {
                dbCommand.Cancel();
            }
            dbCommand = null;

            //销毁Reader
            if (dataReader != null)
            {
                dataReader.Close();
            }
            dataReader = null;

            //销毁Connection
            if (dbConnection != null)
            {
                dbConnection.Clone();
            }
            dbConnection = null;
        }

        /// <summary>
        /// 读取整张数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private SQLiteDataReader ReadFullTable(string tableName)
        {
            string queryString = "SELECT * FROM" + " " + tableName;

            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 向指定数据表中插入数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="valus"></param>
        /// <returns></returns>
        public SQLiteDataReader InsertValue(string tableName, string[] valus)
        {
            //获取数据表中字段数目
            int fieldCount = ReadFullTable(tableName).FieldCount;
            //当插入的数据长度不等于字段数据时引异常
            if (valus.Length != fieldCount)
            {
                throw new SQLiteException("values.Length != fileCount");
            }
            string queryString = "INSERT INTO" + " " + tableName + " " + "VALUES(" + "'" + valus[0] + "'";
            for (int i = 1; i < valus.Length; i++)
            {
                queryString += "," + "'" + valus[i] + "'";
            }
            queryString += ")";

            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 更新指定数据表内的数据
        /// </summary>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        /// <param name="key">关键字</param>
        /// <param name="value">关键字对应的值</param>
        /// <param name="operation">运算符:=,<,></param>
        /// <returns></returns>
        public SQLiteDataReader UpdateValues(string tableName, string[] colNames, string[] colValues, string key, string value, string operation)
        {
            //operation="=";//默认
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length != colValues.Length");
            }
            string queryString = "UPDATE" + " " + tableName + " " + "SET" + " " + colNames[0] + "=" + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += "," + colNames[i] + "=" + "'" + colValues[i] + "'";
            }
            queryString += "WHERE" + " " + key + operation + "'" + value + "'";

            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 更新指定数据表中的数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colNames"></param>
        /// <param name="colValues"></param>
        /// <param name="key1"></param>
        /// <param name="value1"></param>
        /// <param name="operation"></param>
        /// <param name="key2"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public SQLiteDataReader UpdateValues(string tableName, string[] colNames, string[] colValues, string key1, string value1, string operation, string key2, string value2)
        {
            //operation="=";默认
            //当字段名称和字段数值不对应时发生异常
            if (colNames.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length != colValues.Length");
            }
            string queryString = "UPDATE" + " " + tableName + " " + "SET" + colNames[0] + "=" + "'" + colValues[0] + "'";
            for (int i =1 ; i < colValues.Length; i++)
            {
                queryString += "," + colNames[i] + "=" + "'" + colValues[i] + "'";
            }
            //表中已经设置成int类型的不需要再次添加单引号,而字符串类型的数据需要进行添加单引号
            queryString += "WHERE" + key1 + operation + "'" + value1 + "'" + "OR" + key2 + operation + "'" + value2 + "'";

            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public SQLiteDataReader DeleteValues(string tableName, string[] colNames, string[] colValues, string[] operations)
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length");
            }
            string queryString = "DELETE FROM" + " " + tableName + " " + "WHERE" + " " + colNames[0] + operations[0] + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += "AND" + " " + colNames[i] + operations[i] + "'" + colValues[i] + "'";
            }

            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colNames"></param>
        /// <param name="colTypes"></param>
        /// <returns></returns>
        public SQLiteDataReader CreateTable(string tableName, string[] colNames, string[] colTypes)
        {
            string queryString = "CREATE TABLE IF NOT EXISTS" + " " + tableName + "(" + colNames[0] + " " + colTypes[0];
            for (int i = 1; i < colNames.Length; i++)
            {
                queryString += "," + colNames[i] + " " + colTypes[i];
            }
            queryString += ")";

            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 根据查询条件查询
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="items"></param>
        /// <param name="colNames"></param>
        /// <param name="operations"></param>
        /// <param name="colValues"></param>
        /// <returns></returns>
        public List<string[]> QueryTable(string tableName, string[] items, string[] colNames, string[] operations, string[] colValues)
        {
            string queryString = "SELECT" + " ";
            for (int i = 0; i < items.Length; i++)
            {
                queryString += "," + items[i];
            }
            queryString += "FROM" + " " + tableName + " " + "WHERE" + " 1=1 " ;
            for (int i = 0; i < colNames.Length; i++)
            {
                queryString += "AND" + colNames[i] + " " + operations[i] + " " + "'" + colValues[i] + "'" + " ";
            }

            SQLiteDataReader dr = ExecuteQuery(queryString);
            List<string[]> QueryResult = new List<string[]>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string[] queryData = new string[dr.FieldCount];
                    for (int i =0; i < dr.FieldCount; i++)
                    {
                        queryData[i] = dr.GetString(i);
                    }
                    QueryResult.Add(queryData);
                }
            }

            return QueryResult;
        }

        /// <summary>
        /// 查询整张数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<string[]> QueryTable(string tableName)
        {
            string queryString = "SELECT" + " " + "* FROM" + " " + tableName;
            List<string[]> QueryResult = new List<string[]>();
            if (null == QueryResult)
            {
                return null;
            }
            SQLiteDataReader dr = ExecuteQuery(queryString);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string[] queryData = new string[dr.FieldCount];
                    for (int i =0; i < dr.FieldCount; i++)
                    {
                        queryData[i] = dr[i].ToString();
                    }
                    QueryResult.Add(queryData);
                }
            }

            return QueryResult;
        }
    }
}
