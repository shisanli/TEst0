using DrawFunctionLib;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper
{
    public class HeadModelV2

    {
        /// <summary>
        /// 数据分隔符
        /// </summary>
        public const String DataDivide = ",";
        /// <summary>
        /// 元素分隔符
        /// </summary>
        public const String EleDivide = " ";

        /// <summary>
        /// 二维数组 三维坐标
        /// </summary>
        public DrawFunction3D.PointF3D[] Data3D = null;
        public int[][] Triangles = null;


        public DrawFunction3D.PointF3D xiedianCenter;

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
                int pointCount = -1;//点数量
                int triangleCount = -1; //三角形数量
                reader = new StreamReader(FilePath);
                if (reader != null)
                {
                    {
                        String line = reader.ReadLine();
                        String countStr = line.Substring(line.IndexOf(':') + 1);
                        pointCount = int.Parse(countStr);

                        line = reader.ReadLine();
                        countStr = line.Substring(line.IndexOf(':') + 1);
                        triangleCount = int.Parse(countStr);
                    }
                    Data3D = new DrawFunction3D.PointF3D[pointCount];
                    for (int i = 0; i < pointCount ; i++)
                    {
                        String line = reader.ReadLine();
                        String[] words = line.Split(DataDivide.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        int id = int.Parse(words[0]);
                        float x = float.Parse(words[1]);
                        float y = float.Parse(words[2]);
                        float z = float.Parse(words[3]);
                        Data3D[id] = new DrawFunction3D.PointF3D(x, y, z);
                    }

                    float maxx = -9e9f, maxy = -9e9f, maxz = -9e9f, minx = 9e9f, miny = 9e9f, minz = 9e9f;
                    for (int i = 0; i < Data3D.Length; ++i)
                    {
                        if (maxx < Data3D[i].X) maxx = Data3D[i].X;
                        if (minx > Data3D[i].X) minx = Data3D[i].X;

                        if (maxy < Data3D[i].Y) maxy = Data3D[i].Y;
                        if (miny > Data3D[i].Y) miny = Data3D[i].Y;

                        if (maxz < Data3D[i].Z) maxz = Data3D[i].Z;
                        if (minz > Data3D[i].Z) minz = Data3D[i].Z;
                    }
                    xiedianCenter = new DrawFunction3D.PointF3D((maxx + minx) / 2, (maxy + miny) / 2, (maxz + minz) / 2);

                    Triangles = new int[triangleCount][];
                    for (int i = 0;i < triangleCount ; i++)
                    {
                        String line = reader.ReadLine();
                        String[] words = line.Split(DataDivide.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        int id = int.Parse(words[0]);
                        int a = int.Parse(words[1]);
                        int b = int.Parse(words[2]);
                        int c = int.Parse(words[3]);
                        Triangles[id] = new int[] { a, b, c };
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


        public double[] GetAngleAndDistance(double x, double y)
        {
            double dis = Math.Sqrt(x * x + y * y);
            double angle = Math.Acos(x / dis);
            if (y < 0) angle = 2 * Math.PI - angle;
            return new double[] { angle, dis };
        }
    }
}
