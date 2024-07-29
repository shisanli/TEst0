using NPOI.Util.ArrayExtensions;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper.Generator
{
    public class MeshGenerater
    {

        public static void GenerateMesh()
        {
            Dictionary<string, float[]> pointMap = new Dictionary<string, float[]>();
            StreamReader reader = new StreamReader("C:\\膝关节2023-07-15\\膝关节压力上位机 - 07-15最新\\副本膝关节压力56#压力点坐标2.csv");
            while (!reader.EndOfStream)//如果没有到文件尾,那么继续循环
            {
                String line = reader.ReadLine();//读入一行
                String[] datas = line.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string name = datas[0];

                float x = Convert.ToSingle(datas[2].Substring(0, datas[2].IndexOf("m")));
                float y = Convert.ToSingle(datas[3].Substring(0, datas[3].IndexOf("m")));
                x = (35 - x) * 10;
                y = (21 - y) * 12.25f;
                pointMap.Add(name, new float[] { x, y, 0 });
            }
            reader.Close();
            string[][] leftPointNames = new string[][] {
                new string[]{"C_L3","C_L5","C_L12","C_L10"},
                new string[]{"C_L1","C_L4","C_L7","C_L13","C_L8"},
                new string[]{"C_L0","C_L2","C_L6","C_L14","C_L11","C_L9"},
            };
            Mesh leftMesh = generateOneSide(pointMap, leftPointNames);

            string[][] rightPointNames = new string[][] {
                new string[]{"C_R4","C_R1","C_R9","C_R10"},
                new string[]{"C_R5","C_R3","C_R0","C_R11","C_R13"},
                new string[]{"C_R7","C_R6","C_R2","C_R8","C_R12","C_R14"},
            };
            Mesh rightMesh = generateOneSide(pointMap, rightPointNames,
                leftMesh.points.Length, leftMesh.triangles.Length);

            StreamWriter writer = new StreamWriter("C:\\膝关节2023-07-15\\膝关节压力上位机 - 07-15最新\\副本膝关节压力56#压力点坐标mesh.txt");
            writer.WriteLine(String.Format("point count:{0}", leftMesh.points.Length + rightMesh.points.Length));
            writer.WriteLine(String.Format("triangle count:{0}", leftMesh.triangles.Length + rightMesh.triangles.Length));

            for (int i = 0; i < leftMesh.points.Length; i++)
            {
                writer.WriteLine(String.Format("{0},{1},{2},{3}", leftMesh.points[i].id, leftMesh.points[i].x, leftMesh.points[i].y, leftMesh.points[i].z));
            }
            for (int i = 0; i < rightMesh.points.Length; i++)
            {
                writer.WriteLine(String.Format("{0},{1},{2},{3}", rightMesh.points[i].id, rightMesh.points[i].x, rightMesh.points[i].y, rightMesh.points[i].z));
            }
            for (int i = 0; i < leftMesh.triangles.Length; i++)
            {
                writer.WriteLine(String.Format("{0},{1},{2},{3}", leftMesh.triangles[i][0], leftMesh.triangles[i][1], leftMesh.triangles[i][2], leftMesh.triangles[i][3]));
            }
            for (int i = 0; i < rightMesh.triangles.Length; i++)
            {
                writer.WriteLine(String.Format("{0},{1},{2},{3}", rightMesh.triangles[i][0], rightMesh.triangles[i][1], rightMesh.triangles[i][2], rightMesh.triangles[i][3]));
            }
            writer.Flush();
            writer.Close();
        }

        private static Mesh generateOneSide(Dictionary<string, float[]> pointMap, string[][] pointNames, int basePointId = 0, int baseTriangleId = 0)
        {
            float[][][] points = new float[pointNames.Length + 2][][];
            {
                float x = pointMap[pointNames[0][0]][0] * 2 - pointMap[pointNames[1][0]][0];
                points[0] = new float[pointNames[0].Length + 1][];

                for (int i = 1; i < pointNames[0].Length; i++)
                {
                    points[0][i] = new float[] { x, (pointMap[pointNames[0][i - 1]][1] + pointMap[pointNames[0][i]][1]) / 2, 0 };
                }

                points[0][0] = new float[] { x, points[0][1][1] * 2 - points[0][2][1], 0 };
                points[0][pointNames[0].Length] = new float[] { x, points[0][pointNames[0].Length - 1][1] * 2 - points[0][pointNames[0].Length - 2][1], 0 };

            }

            for (int j = 0; j < pointNames.Length; j++)
            {
                int row = j + 1;
                float x = pointMap[pointNames[j][0]][0];
                points[row] = new float[pointNames[j].Length + 2][];
                for (int i = 0; i < pointNames[j].Length; i++)
                {
                    points[row][i + 1] = new float[] { x, pointMap[pointNames[j][i]][1], 0 };
                }

                points[row][0] = new float[] { x, points[row][1][1] * 2 - points[row][2][1], 0 };
                points[row][pointNames[j].Length + 1] = new float[] { x, points[row][pointNames[j].Length][1] * 2 - points[row][pointNames[j].Length - 1][1], 0 };
            }

            {
                int last = pointNames.Length - 1;
                int row = last + 2;
                float x = pointMap[pointNames[last][0]][0] * 2 - pointMap[pointNames[last - 1][0]][0];
                points[row] = new float[pointNames[last].Length + 1][];

                for (int i = 1; i < pointNames[last].Length; i++)
                {
                    points[row][i] = new float[] { x, (pointMap[pointNames[last][i - 1]][1] + pointMap[pointNames[last][i]][1]) / 2, 0 };
                }

                points[row][0] = new float[] { x, points[row][1][1] * 2 - points[row][2][1], 0 };
                points[row][pointNames[last].Length] = new float[] { x, points[row][pointNames[last].Length - 1][1] * 2 - points[row][pointNames[last].Length - 2][1], 0 };
            }

            Mesh m = new Mesh();
            int id = 0;
            int[][] ids = new int[points.Length][];
            for (int i = 0; i < points.Length; i++)
            {
                ids[i] = new int[points[i].Length];
                for (int j = 0; j < points[i].Length; j++)
                {
                    ids[i][j] = basePointId + id;
                    id++;
                }
            }
            m.points = new Point[id];
            id = 0;
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points[i].Length; j++)
                {
                    Point p = new Point();
                    p.id = basePointId + id;
                    p.x = points[i][j][0];
                    p.y = points[i][j][1];
                    p.z = points[i][j][2];
                    m.points[id] = p;
                    id++;
                }
            }
            LinkedList<int[]> meshIds = new LinkedList<int[]>();
            id = 0;
            for (int i = 0; i < ids.Length - 1; i++)
            {
                int upper = i, lower = i + 1;
                if (ids[upper].Length > ids[lower].Length)
                {
                    int tmp = upper;
                    upper = lower;
                    lower = tmp;
                }
                for (int j = 0; j < ids[upper].Length; j++)
                {
                    meshIds.AddLast(new int[] { baseTriangleId + id, ids[upper][j], ids[lower][j], ids[lower][j + 1] });
                    id++;
                    if (j < ids[upper].Length - 1)
                    {
                        meshIds.AddLast(new int[] { baseTriangleId + id, ids[upper][j], ids[upper][j + 1], ids[lower][j + 1] });
                        id++;
                    }
                }
            }
            m.triangles = new int[meshIds.Count][];
            id = 0;
            LinkedList<int[]>.Enumerator enumerator = meshIds.GetEnumerator();
            while (enumerator.MoveNext())
            {
                m.triangles[id] = enumerator.Current;
                id++;
            }
            return m;
        }

        internal class Point
        {
            public int id;
            public float x, y, z;
        }
        internal class Mesh
        {
            public Point[] points;
            public int[][] triangles;
        }
    }
}
