using DrawFunctionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper
{
    public class HeadModel
    {
        /// <summary>
        /// 数据分隔符
        /// </summary>
        public const String DataDivide = ";";
        /// <summary>
        /// 元素分隔符
        /// </summary>
        public const String EleDivide = " ";

        /// <summary>
        /// 二维数组 三维坐标
        /// </summary>
        public DrawFunction3D.PointF3D[,] Data3D = null;
        public DrawFunction3D.PointF3D[] xiedian = null;
        public DrawFunction3D.PointF3D xiedianCenter;
        public List<KeyValuePair<double, double>> angleDistanceMap = new List<KeyValuePair<double, double>>();
        /// <summary>
        /// 行数
        /// </summary>
        public int RowCount { get; protected set; }
        /// <summary>
        /// 列数
        /// </summary>
        public int ColCount { get; protected set; }

        /// <summary>
        /// 从文件中读取
        /// </summary>
        /// <param name="FilePath">文件位置</param>
        /// <returns>是否成功</returns>
        public bool Read(String FilePath)
        {
            bool result = false;
            StreamReader reader = null;
            try
            {
                int ColumnCount = -1;//列数量
                int RowCount = -1; //行数量
                reader = new StreamReader(FilePath);
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
                        if (Data3D != null) Data3D = null;
                        Data3D = new DrawFunction3D.PointF3D[RowCount, ColumnCount];
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
                                float x = -1, y = -1, z = -1;
                                String[] Ele = data.Split(EleDivide.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                if (Ele != null)
                                {
                                    if (Ele.Length >= 3)
                                    {
                                        x = Convert.ToSingle(Ele[0].Trim());
                                        y = Convert.ToSingle(Ele[1].Trim());
                                        z = Convert.ToSingle(Ele[2].Trim());
                                    }
                                }
                                Data3D[RowIndex, ColIndex] = new DrawFunction3D.PointF3D(x, y, z);
                                result = true;

                                ColIndex++;
                            }

                            RowIndex++;
                        }
                    }
                }
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

        public bool ReadXiedian(String FilePath)
        {
            bool result = false;
            System.IO.StreamReader reader = null;
            try
            {

                int RowCount = -1; //行数量
                reader = new System.IO.StreamReader(FilePath);
                if (reader != null)
                {
                    RowCount = 0;
                    while (!reader.EndOfStream)//如果没有到文件尾,那么继续循环
                    {
                        String line = reader.ReadLine();//读入一行

                        RowCount++;
                    }

                    if (RowCount > 0)
                    {
                        if (xiedian != null) xiedian = null;
                        xiedian = new DrawFunction3D.PointF3D[RowCount];
                        int RowIndex = 0;
                        reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                        while (!reader.EndOfStream)//如果没有到文件尾,那么继续循环
                        {
                            String line = reader.ReadLine();//读入一行
                            String[] datas = line.Split(',');
                            if (datas == null) break;
                            float x = -1, y = -1, z = -1;
                            x = (Convert.ToSingle(datas[0].Trim()) - 2280.753f) * (0.79f) + 97;
                            y = (Convert.ToSingle(datas[1].Trim()) - 1645.819f) * (-0.69f) + 90;
                            z = Convert.ToSingle(datas[2].Trim());

                            xiedian[RowIndex] = new DrawFunction3D.PointF3D(x, y, z);
                            result = true;

                            RowIndex++;
                        }
                    }
                }
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
            DrawFunction3D.PointF3D center = new DrawFunction3D.PointF3D();
            float maxx = -9e9f, maxy = -9e9f, maxz = -9e9f, minx = 9e9f, miny = 9e9f, minz = 9e9f;
            for (int i = 0; i < xiedian.Length; ++i)
            {
                if (maxx < xiedian[i].X) maxx = xiedian[i].X;
                if (minx > xiedian[i].X) minx = xiedian[i].X;

                if (maxy < xiedian[i].Y) maxy = xiedian[i].Y;
                if (miny > xiedian[i].Y) miny = xiedian[i].Y;

                if (maxz < xiedian[i].Z) maxz = xiedian[i].Z;
                if (minz > xiedian[i].Z) minz = xiedian[i].Z;
            }
            center = new DrawFunction3D.PointF3D((maxx + minx) / 2, (maxy + miny) / 2, (maxz + minz) / 2);
            xiedianCenter = center;
            for (int i = 0; i < xiedian.Length; ++i)
            {
                double x = xiedian[i].X - center.X, y = xiedian[i].Y - center.Y;
                double dis = Math.Sqrt(x * x + y * y);
                double angle = Math.Acos(x / dis);
                Console.WriteLine(angle);
                if (y < 0) angle = 2 * Math.PI - angle; 
                angleDistanceMap.Add(new KeyValuePair<double, double>(angle, dis));
            }
            
            angleDistanceMap.Sort((a, b) => a.Key.CompareTo(b.Key));

            
            return result;
        }

        public double[] GetAngleAndDistance(double x, double y)
        {
            double dis = Math.Sqrt(x * x + y * y);
            double angle = Math.Acos(x / dis);
            if (y < 0) angle = 2 * Math.PI - angle;
            return new double[] { angle, dis };
        }
        public bool xiedianContains(DrawFunction3D.PointF3D p)
        {
            double[] angledis = GetAngleAndDistance(p.X - xiedianCenter.X, p.Y - xiedianCenter.Y);
            bool result = false;
            KeyValuePair<double, double> lastItem = new KeyValuePair<double, double>(-1, -1);
            foreach (var item in angleDistanceMap)
            {
                if (angledis[0] <= item.Key)
                {
                    if (lastItem.Value >= 0)
                    {
                        if (item.Key - angledis[0] < angledis[0] - lastItem.Key)
                        {
                            result = item.Value > angledis[1];
                        }
                        else
                        {
                            result = lastItem.Value > angledis[1];
                        }
                    }
                    else
                    {
                        result = item.Value > angledis[1];
                    }
                    break;
                }
                lastItem = item;
            }
            return result;
        }
    }
}
