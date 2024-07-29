using DrawFunctionLib;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PressureUpper
{
    public class PressureModel
    {
        public  float[,] PressureBuffer = new float[18,18]; //临时新加
        /// <summary>
        /// 数据分隔符
        /// </summary>
        public const String DataDivide = ";";

        /// <summary>
        /// 二维数组 三维坐标
        /// </summary>
        public float[,] Pressure = null;
        public static float[] temp = new float[120];
        public static float[] tempLeft = new float[120];
        /// <summary>
        /// 行数
        /// </summary>
        public int RowCount { get; protected set; }
        /// <summary>
        /// 列数
        /// </summary>
        public int ColCount { get; protected set; }

        public float PressureMax
        {
            get
            {
                float pMax = 0;
                if (Pressure != null)
                {
                    foreach (float p in Pressure)
                    {
                        if (p > pMax) pMax = p;
                    }
                }
                return pMax;
            }
        }

        public DrawFunction3D.PointF3D PressureCentre
        {
            get
            {
               
                DrawFunction3D.PointF3D centre = new DrawFunction3D.PointF3D(140, 100, 50);
                return centre;
            }
        }

        /// <summary>
        /// 从文件中读取
        /// </summary>
        /// <param name="FilePath">文件位置</param>
        /// <returns>是否成功</returns>
        public bool Readfile(String FilePath)
        {
            bool result = false;
            System.IO.StreamReader reader = null;
            try
            {
                int ColumnCount = -1;//列数量
                int RowCount = -1; //航数量
                reader = new System.IO.StreamReader(FilePath);
                if (reader != null)
                {
                    RowCount = 0;
                    while (!reader.EndOfStream)//如果没有到文件尾,那么继续循环
                    {
                        String line = reader.ReadLine();//读入一行
                        if (ColumnCount < 0)
                        {
                            String[] datas = line.Split(DataDivide.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            if (datas == null) break;
                            if (datas.Length <= 0) break;
                            ColumnCount = datas.Length;
                        }
                        RowCount++;
                    }

                    if (RowCount > 0 && ColumnCount > 0)
                    {

                        if (Pressure != null) Pressure = null;
                        //GC.Collect();
                        Pressure = new float[RowCount, ColumnCount];
                        this.RowCount = RowCount;
                        this.ColCount = ColumnCount;

                        int RowIndex = 0;
                        reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                        while (!reader.EndOfStream)//如果没有到文件尾,那么继续循环
                        {
                            String line = reader.ReadLine();//读入一行
                            String[] datas = line.Split(DataDivide.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            if (datas == null) break;
                            if (datas.Length != ColumnCount) break;

                            int ColIndex = 0;
                            foreach (String data in datas)
                            {
                                Pressure[RowIndex, ColIndex] = Convert.ToSingle(data.Trim());
                                result = true;

                                ColIndex++;
                            }

                            RowIndex++;
                        }
                    }
                }
                // MessageBox.Show(RowCount.ToString() + "  " + ColumnCount.ToString());
            }
            catch
            {
                result = false;
            }
            if (reader != null)
            {
                reader.Close();
                reader = null;
            }
            return result;
        }

        public void SetSize(int r, int c)
        {
            this.RowCount = r;
            this.ColCount = c;
        }

        public bool Readdb1616()
        {
            bool result = false;
            Pressure = new float[16, 16];
            try
            {

                ////sh7juku
                //string connectionString = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\16w.accdb";
                //OleDbConnection myConnection = new OleDbConnection(connectionString);
                //myConnection.Open();
                ////sql
                //OleDbCommand myCommand = myConnection.CreateCommand();
                //myCommand.CommandText = "select top 1 * from cz order by id*(-1)";
                //OleDbDataReader myDataReader = myCommand.ExecuteReader();
                //if (myDataReader != null)
                //{

                //    while (myDataReader.Read())
                //    {

                //        for (int j = 1; j <= 8; j++)
                //        {
                //            temp[j - 1] = float.Parse(myDataReader[j].ToString());
                //            temp[j - 1] = 0;
                //        }
                //    }

                //}

                //else
                //{
                //    MessageBox.Show("列表为空");
                //}
                //for (int i = 0; i < 120; i++)
                //{
                //    //temp[i] += NewRecong.Form1.zero[i];
                //}
                //MyConvert();
                //myDataReader.Close();
                //myConnection.Close();
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
        public bool Readdb1616Left()
        {
            bool result = false;
            Pressure = new float[16, 16];
            try
            {

                //sh7juku
                //string connectionString = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\16w.accdb";
                //OleDbConnection myConnection = new OleDbConnection(connectionString);
                //myConnection.Open();
                ////sql
                //OleDbCommand myCommand = myConnection.CreateCommand();
                //myCommand.CommandText = "select top 1 * from cz order by id*(-1)";
                //OleDbDataReader myDataReader = myCommand.ExecuteReader();
                //if (myDataReader != null)
                //{

                //    while (myDataReader.Read())
                //    {

                        
                //        for (int j = 1; j <= 8; j++)
                //        {
                //            temp[j - 1] = float.Parse(myDataReader[j].ToString());
                //            temp[j - 1] = 0;
                //        }
                //        //if (Form1.index >= 0 && Form1.index < 8) temp[Form1.index] = 0;
                        
                //        // data.Rows.Add(myDataReader["ljn"] + "//" + myDataReader["i"], myDataReader["bei"]);
                //    }

                //}

                //else
                //{
                //    MessageBox.Show("列表为空");
                //}
                //for (int i = 0; i < 120; i++)
                //{
                //    //temp[i] += NewRecong.Form1.zero[i];
                //}
                //MyConvertLeft();
                //myDataReader.Close();
                //myConnection.Close();
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
        public bool ReadCsv1616(CsvData data, int index)
        {
            bool result = false;
            Pressure = new float[16, 16];
            try
            {
                float[] frameDatas = data.GetFrameSensorValues(index);
                frameDatas[2] = 0;
                frameDatas.CopyTo(temp, 0);

                for (int i = 0; i < 120; i++)
                {
                    //temp[i] += NewRecong.Form2.zero[i];
                }
                MyConvert();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        private void MyConvert()
        {
            Pressure[0, 0] = 0;
            Pressure[0, 1] = 0;
            Pressure[0, 2] = 0;
            Pressure[0, 3] = 0;
            Pressure[0, 4] = 0;
            Pressure[0, 5] = 0;
            Pressure[0, 6] = 0;
            Pressure[0, 7] = 0;
            Pressure[0, 8] = 0;
            Pressure[0, 9] = 0;
            Pressure[1, 0] = 0;
            Pressure[1, 1] = 0;
            Pressure[1, 2] = 0;
            Pressure[1, 3] = 0;
            Pressure[1, 4] = 0;
            Pressure[1, 5] = 0;
            Pressure[1, 6] = 0;
            Pressure[1, 7] = 0;
            Pressure[1, 8] = 0;
            Pressure[1, 9] = 0;
            Pressure[2, 0] = 0;
            Pressure[2, 1] = 0;
            Pressure[2, 2] = 0;
            Pressure[2, 3] = 0;
            Pressure[2, 4] = 0;
            Pressure[2, 5] = 0;
            Pressure[2, 6] = 0;
            Pressure[2, 7] = 0;
            Pressure[2, 8] = 0;
            Pressure[2, 9] = 0;
            Pressure[3, 0] = 0;
            Pressure[3, 1] = 0;
            Pressure[3, 2] = 0;
            Pressure[3, 3] = 0;
            Pressure[3, 4] = 0;
            Pressure[3, 5] = 0;
            Pressure[3, 6] = 0;
            Pressure[3, 7] = 0;
            Pressure[3, 8] = 0;
            Pressure[3, 9] = 0;
            Pressure[4, 0] = 0;
            Pressure[4, 1] = 0;
            Pressure[4, 2] = 0;
            Pressure[4, 3] = 0;
            Pressure[4, 4] = 0;
            Pressure[4, 5] = 0;
            Pressure[4, 6] = 0;
            Pressure[4, 7] = 0;
            Pressure[4, 8] = 0;
            Pressure[4, 9] = 0;
            Pressure[5, 0] = 0;
            Pressure[5, 1] = 0;
            Pressure[5, 2] = 0;
            Pressure[5, 3] = 0;
            Pressure[5, 4] = 0;
            Pressure[5, 5] = 0;
            Pressure[5, 6] = 0;
            Pressure[5, 7] = 0;
            Pressure[5, 8] = 0;
            Pressure[5, 9] = 0;
            Pressure[6, 0] = 0;
            Pressure[6, 1] = 0;
            Pressure[6, 2] = 0;
            Pressure[6, 3] = 0;
            Pressure[6, 4] = 0;
            Pressure[6, 5] = 0;
            Pressure[6, 6] = 0;
            Pressure[6, 7] = 0;
            Pressure[6, 8] = 0;
            Pressure[6, 9] = 0;
            Pressure[7, 0] = 0;
            Pressure[7, 1] = 0;
            Pressure[7, 2] = 0;
            Pressure[7, 3] = 0;
            Pressure[7, 4] = 0;
            Pressure[7, 5] = 0;
            Pressure[7, 6] = 0;
            Pressure[7, 7] = 0;
            Pressure[7, 8] = 0;
            Pressure[7, 9] = 0;
            Pressure[8, 0] = 0;
            Pressure[8, 1] = 0;
            Pressure[8, 2] = 0;
            Pressure[8, 3] = 0;
            Pressure[8, 4] = 0;
            Pressure[8, 5] = 0;
            Pressure[8, 6] = 0;
            Pressure[8, 7] = 0;
            Pressure[8, 8] = 0;
            Pressure[8, 9] = 0;
            Pressure[9, 0] = 0;
            Pressure[9, 1] = 0;
            Pressure[9, 2] = 0;
            Pressure[9, 3] = 0;
            Pressure[9, 4] = 0;
            Pressure[9, 5] = 0;
            Pressure[9, 6] = 0;
            Pressure[9, 7] = 0;
            Pressure[9, 8] = 0;
            Pressure[9, 9] = 0;
            Pressure[10, 0] = 0;
            Pressure[10, 1] = 0;
            Pressure[10, 2] = 0;
            Pressure[10, 3] = 0;
            Pressure[10, 4] = 0;
            Pressure[10, 5] = 0;
            Pressure[10, 6] = 0;
            Pressure[10, 7] = 0;
            Pressure[10, 8] = 0;
            Pressure[10, 9] = 0;
            Pressure[11, 0] = 0;
            Pressure[11, 1] = 0;
            Pressure[11, 2] = 0;
            Pressure[11, 3] = 0;
            Pressure[11, 4] = 0;
            Pressure[11, 5] = 0;
            Pressure[11, 6] = 0;
            Pressure[11, 7] = 0;
            Pressure[11, 8] = 0;
            Pressure[11, 9] = 0;
            Pressure[12, 0] = 0;
            Pressure[12, 1] = 0;
            Pressure[12, 2] = 0;
            Pressure[12, 3] = 0;
            Pressure[12, 4] = 0;
            Pressure[12, 5] = 0;
            Pressure[12, 6] = 0;
            Pressure[12, 7] = 0;
            Pressure[12, 8] = 0;
            Pressure[12, 9] = 0;
            Pressure[13, 0] = 0;
            Pressure[13, 1] = 0;
            Pressure[13, 2] = 0;
            Pressure[13, 3] = 0;
            Pressure[13, 4] = 0;
            Pressure[13, 5] = 0;
            Pressure[13, 6] = 0;
            Pressure[13, 7] = 0;
            Pressure[13, 8] = 0;
            Pressure[13, 9] = 0;
            Pressure[14, 8] = 0;

            //for (int i = 0; i < 10; i++)
            //{
            //右脚
            Pressure[11, 8] = temp[0];
            Pressure[13, 7] = temp[1] / 2;
            Pressure[13, 8] = temp[1] / 2;
            Pressure[11, 7] = temp[2];
            Pressure[5, 6] = temp[3];
            Pressure[3, 7] = temp[4];
            Pressure[5, 8] = temp[5];
            Pressure[6, 9] = temp[6];
            Pressure[8, 8] = temp[7];
            //}
        }

        private void MyConvertLeft()
        {
            Pressure[0, 0] = 0;
            Pressure[0, 1] = 0;
            Pressure[0, 2] = 0;
            Pressure[0, 3] = 0;
            Pressure[0, 4] = 0;
            Pressure[0, 5] = 0;
            Pressure[0, 6] = 0;
            Pressure[0, 7] = 0;
            Pressure[0, 8] = 0;
            Pressure[0, 9] = 0;
            Pressure[1, 0] = 0;
            Pressure[1, 1] = 0;
            Pressure[1, 2] = 0;
            Pressure[1, 3] = 0;
            Pressure[1, 4] = 0;
            Pressure[1, 5] = 0;
            Pressure[1, 6] = 0;
            Pressure[1, 7] = 0;
            Pressure[1, 8] = 0;
            Pressure[1, 9] = 0;
            Pressure[2, 0] = 0;
            Pressure[2, 1] = 0;
            Pressure[2, 2] = 0;
            Pressure[2, 3] = 0;
            Pressure[2, 4] = 0;
            Pressure[2, 5] = 0;
            Pressure[2, 6] = 0;
            Pressure[2, 7] = 0;
            Pressure[2, 8] = 0;
            Pressure[2, 9] = 0;
            Pressure[3, 0] = 0;
            Pressure[3, 1] = 0;
            Pressure[3, 2] = 0;
            Pressure[3, 3] = 0;
            Pressure[3, 4] = 0;
            Pressure[3, 5] = 0;
            Pressure[3, 6] = 0;
            Pressure[3, 7] = 0;
            Pressure[3, 8] = 0;
            Pressure[3, 9] = 0;
            Pressure[4, 0] = 0;
            Pressure[4, 1] = 0;
            Pressure[4, 2] = 0;
            Pressure[4, 3] = 0;
            Pressure[4, 4] = 0;
            Pressure[4, 5] = 0;
            Pressure[4, 6] = 0;
            Pressure[4, 7] = 0;
            Pressure[4, 8] = 0;
            Pressure[4, 9] = 0;
            Pressure[5, 0] = 0;
            Pressure[5, 1] = 0;
            Pressure[5, 2] = 0;
            Pressure[5, 3] = 0;
            Pressure[5, 4] = 0;
            Pressure[5, 5] = 0;
            Pressure[5, 6] = 0;
            Pressure[5, 7] = 0;
            Pressure[5, 8] = 0;
            Pressure[5, 9] = 0;
            Pressure[6, 0] = 0;
            Pressure[6, 1] = 0;
            Pressure[6, 2] = 0;
            Pressure[6, 3] = 0;
            Pressure[6, 4] = 0;
            Pressure[6, 5] = 0;
            Pressure[6, 6] = 0;
            Pressure[6, 7] = 0;
            Pressure[6, 8] = 0;
            Pressure[6, 9] = 0;
            Pressure[7, 0] = 0;
            Pressure[7, 1] = 0;
            Pressure[7, 2] = 0;
            Pressure[7, 3] = 0;
            Pressure[7, 4] = 0;
            Pressure[7, 5] = 0;
            Pressure[7, 6] = 0;
            Pressure[7, 7] = 0;
            Pressure[7, 8] = 0;
            Pressure[7, 9] = 0;
            Pressure[8, 0] = 0;
            Pressure[8, 1] = 0;
            Pressure[8, 2] = 0;
            Pressure[8, 3] = 0;
            Pressure[8, 4] = 0;
            Pressure[8, 5] = 0;
            Pressure[8, 6] = 0;
            Pressure[8, 7] = 0;
            Pressure[8, 8] = 0;
            Pressure[8, 9] = 0;
            Pressure[9, 0] = 0;
            Pressure[9, 1] = 0;
            Pressure[9, 2] = 0;
            Pressure[9, 3] = 0;
            Pressure[9, 4] = 0;
            Pressure[9, 5] = 0;
            Pressure[9, 6] = 0;
            Pressure[9, 7] = 0;
            Pressure[9, 8] = 0;
            Pressure[9, 9] = 0;
            Pressure[10, 0] = 0;
            Pressure[10, 1] = 0;
            Pressure[10, 2] = 0;
            Pressure[10, 3] = 0;
            Pressure[10, 4] = 0;
            Pressure[10, 5] = 0;
            Pressure[10, 6] = 0;
            Pressure[10, 7] = 0;
            Pressure[10, 8] = 0;
            Pressure[10, 9] = 0;
            Pressure[11, 0] = 0;
            Pressure[11, 1] = 0;
            Pressure[11, 2] = 0;
            Pressure[11, 3] = 0;
            Pressure[11, 4] = 0;
            Pressure[11, 5] = 0;
            Pressure[11, 6] = 0;
            Pressure[11, 7] = 0;
            Pressure[11, 8] = 0;
            Pressure[11, 9] = 0;
            Pressure[12, 0] = 0;
            Pressure[12, 1] = 0;
            Pressure[12, 2] = 0;
            Pressure[12, 3] = 0;
            Pressure[12, 4] = 0;
            Pressure[12, 5] = 0;
            Pressure[12, 6] = 0;
            Pressure[12, 7] = 0;
            Pressure[12, 8] = 0;
            Pressure[12, 9] = 0;
            Pressure[13, 0] = 0;
            Pressure[13, 1] = 0;
            Pressure[13, 2] = 0;
            Pressure[13, 3] = 0;
            Pressure[13, 4] = 0;
            Pressure[13, 5] = 0;
            Pressure[13, 6] = 0;
            Pressure[13, 7] = 0;
            Pressure[13, 8] = 0;
            Pressure[13, 9] = 0;
            Pressure[14, 8] = 0;

            //for (int i = 0; i < 10; i++)
            //{
            //左脚
            Pressure[11, 7] = tempLeft[0];
            Pressure[13, 7] = tempLeft[1] / 2;
            Pressure[13, 8] = tempLeft[1] / 2;
            Pressure[11, 8] = tempLeft[2];
            Pressure[5, 9] = tempLeft[3];
            Pressure[3, 8] = tempLeft[4];
            Pressure[5, 7] = tempLeft[5];
            Pressure[6, 6] = tempLeft[6];
            Pressure[8, 7] = tempLeft[7];
            //}
        }
        internal void ReadCOM1616(int[,] pres)
        {
            Pressure = new float[16, 16];
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    Pressure[i+1, j+1] = pres[i, j];
                    Pressure[i, 0] = 0;
                    Pressure[i, 14] = 0;
                    Pressure[i, 15] = 0;
                }
            }
            //for(int i = 14; i < 16; i++)
            //{
            //    for(int j = 0; j < 16; j++)
            //    {
            //        Pressure[i, j] = 0;
            //    }
            //}
                    
        }

        public void ReadCOM1616(string ss1, string ss2, string ss3, string ss4, string ss5, string ss6, string ss7, string ss8)
        {
            Pressure = new float[16, 16];
            float[] frameDatas = new float[8];

            frameDatas[0] = float.Parse(ss1);
            frameDatas[1] = float.Parse(ss2);
            frameDatas[2] = float.Parse(ss3);
            frameDatas[3] = float.Parse(ss4);
            frameDatas[4] = float.Parse(ss5);
            frameDatas[5] = float.Parse(ss6);
            frameDatas[6] = float.Parse(ss7);
            frameDatas[7] = float.Parse(ss8);

            Console.WriteLine("1传感器：" + ss1 + "N");
            Console.WriteLine("2传感器：" + ss2 + "N");
            Console.WriteLine("3传感器：" + ss3 + "N");
            Console.WriteLine("4传感器：" + ss4 + "N");
            Console.WriteLine("5传感器：" + ss5 + "N");
            Console.WriteLine("6传感器：" + ss6 + "N");
            Console.WriteLine("7传感器：" + ss7 + "N");
            Console.WriteLine("8传感器：" + ss8 + "N");
            //frameDatas[2] = 0;
            frameDatas.CopyTo(temp, 0);

            for (int i = 0; i < 120; i++)
            {
                //temp[i] += NewRecong.Form1.zero[i];
            }
            MyConvert();
        }

        public void ReadCOM1616Left(string ss1, string ss2, string ss3, string ss4, string ss5, string ss6, string ss7, string ss8)
        {
            Pressure = new float[16, 16];
            float[] frameDatas = new float[8];

            frameDatas[0] = float.Parse(ss1);
            frameDatas[1] = float.Parse(ss2);
            frameDatas[2] = float.Parse(ss3);
            frameDatas[3] = float.Parse(ss4);
            frameDatas[4] = float.Parse(ss5);
            frameDatas[5] = float.Parse(ss6);
            frameDatas[6] = float.Parse(ss7);
            frameDatas[7] = float.Parse(ss8);

            Console.WriteLine("1传感器：" + ss1 + "N");
            Console.WriteLine("2传感器：" + ss2 + "N");
            Console.WriteLine("3传感器：" + ss3 + "N");
            Console.WriteLine("4传感器：" + ss4 + "N");
            Console.WriteLine("5传感器：" + ss5 + "N");
            Console.WriteLine("6传感器：" + ss6 + "N");
            Console.WriteLine("7传感器：" + ss7 + "N");
            Console.WriteLine("8传感器：" + ss8 + "N");
            frameDatas.CopyTo(tempLeft, 0);

            for (int i = 0; i < 120; i++)
            {
                //tempLeft[i] += NewRecong.Form1.zero[i];
            }
            MyConvertLeft();
        }

        public void ReadFromBuffer(int v)
        {
            Pressure = new float[18, 18];
            Pressure = (float[,])PressureBuffer.Clone();

        }
    }
}
