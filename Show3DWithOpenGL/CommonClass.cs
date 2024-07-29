using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show3DWithOpenGL
{
    public class CommonClass
    {
        public CommonClass()
        {

        }
        public static List<Collision> SortHitResult(List<Collision> collisionList)
        {
            List<Collision> CL = new List<Collision>();
            foreach (Collision c in collisionList) CL.Add(c);
            if (CL.Count >= 2)
            {
                int low = 0, j;
                int high = CL.Count - 1; //设置变量的初始值  
                Collision tmp;
                while (low < high)
                {
                    for (j = low; j < high; ++j) //正向冒泡,找到最大者  
                        if (CL[j].distance > CL[j + 1].distance)
                        {
                            tmp = CL[j]; CL[j] = CL[j + 1]; CL[j + 1] = tmp;
                        }
                    --high;                 //修改high值, 前移一位  
                    for (j = high; j > low; --j) //反向冒泡,找到最小者  
                        if (CL[j].distance < CL[j - 1].distance)
                        {
                            tmp = CL[j]; CL[j] = CL[j - 1]; CL[j - 1] = tmp;
                        }
                    ++low;                  //修改low值,后移一位  
                }
            }
            return CL;
        }
        public static List<Collision> SortHitResultDESC(List<Collision> collisionList)
        {
            List<Collision> CL = new List<Collision>();
            foreach (Collision c in collisionList) CL.Add(c);
            if (CL.Count >= 2)
            {
                int low = 0, j;
                int high = CL.Count - 1; //设置变量的初始值  
                Collision tmp;
                while (low < high)
                {
                    for (j = low; j < high; ++j) //正向冒泡,找到最大者  
                        if (CL[j].distance < CL[j + 1].distance)
                        {
                            tmp = CL[j]; CL[j] = CL[j + 1]; CL[j + 1] = tmp;
                        }
                    --high;                 //修改high值, 前移一位  
                    for (j = high; j > low; --j) //反向冒泡,找到最小者  
                        if (CL[j].distance > CL[j - 1].distance)
                        {
                            tmp = CL[j]; CL[j] = CL[j - 1]; CL[j - 1] = tmp;
                        }
                    ++low;                  //修改low值,后移一位  
                }
            }
            return CL;
        }
    }
    public class Ray
    {
        public Vector3D RaySource;
        public Vector3D RayTarget;
        public Ray()
        {
            RaySource = new Vector3D();
            RayTarget = new Vector3D(1f, 1f, 1f);
        }
        public Ray(Vector3D source, Vector3D target)
        {
            RaySource = new Vector3D(source);
            RayTarget = new Vector3D(target);
        }
        public Ray(Ray ray)
        {
            RaySource = new Vector3D(ray.RaySource);
            RayTarget = new Vector3D(ray.RayTarget);
        }
        public static float Distance(Vector3D v, Ray ray)
        {
            return Vector3D.RayDistance(v, ray.RaySource, ray.RayTarget);
        }
        public Vector3D Direction()
        {
            return (RayTarget - RaySource).Normalize();
        }
        public float Distance(Vector3D v)
        {
            return Distance(v, this);
        }
        public static bool HitTriangle(Ray ray, Vector3D v1, Vector3D v2, Vector3D v3, bool IncludeSide = false)
        {
            return Vector3D.PointInTriangle(v1.GetComponet(ray).Vertical, v2.GetComponet(ray).Vertical, v3.GetComponet(ray).Vertical, IncludeSide);
        }
        public bool HitTriangle(Vector3D v1, Vector3D v2, Vector3D v3, bool IncludeSide = false)
        {
            return HitTriangle(this, v1, v2, v3, IncludeSide);
        }
        public bool HitSTL_Triangle(Triangle triangle, bool IncludeSide)
        {
            return this.HitTriangle(triangle.point[0].vertex, triangle.point[1].vertex, triangle.point[2].vertex, IncludeSide);
        }
        public bool HitCUSTOM_Triangle(Triangle triangle, List<Point> pointList, bool IncludeSide)
        {
            return this.HitTriangle(pointList[triangle.vertex_index[0]].vertex, pointList[triangle.vertex_index[1]].vertex, pointList[triangle.vertex_index[2]].vertex, IncludeSide);
        }
        public Collision GetCollisionTriangle(Vector3D v1, Vector3D v2, Vector3D v3, bool IncludeSide = false)
        {
            Collision c = new Collision();
            if (this.HitTriangle(v1, v2, v3, IncludeSide))
            {
                Vector3D[] v = new Vector3D[] { v1, v2, v3 };
                c.ray = new Ray(this);
                c.triangle = new Triangle(0);
                c.triangle.point[0].vertex = v[0];
                c.triangle.point[1].vertex = v[1];
                c.triangle.point[2].vertex = v[2];
                Vector3D CrossVector = (v[1] - v[0]) * (v[2] - v[0]);
                c.triangle.NormalVector = CrossVector.Normalize();
                c.point.color = new Vector3D(1f, 0f, 0f);
                c.IsValid = true;
                for (int i = 0; i < 3; i++)
                {
                    if (v[i].RayDistance(this) != 0f)
                    {
                        if ((float)Math.Abs((this.RayTarget - this.RaySource).Normalize().DotProduct(c.triangle.NormalVector)) <= 3.1415926535898f / (180f * 1f))
                        {
                            c.point.vertex = (v[i].RayDistance(this) * v[(i + 1) % 3].GetComponet(this).Parallel + v[(i + 1) % 3].RayDistance(this) * v[i].GetComponet(this).Parallel) / (v[i].RayDistance(this) + v[(i + 1) % 3].RayDistance(this)) + this.RaySource;
                            c.distance = c.point.vertex.Distance(this.RaySource);
                        }
                        else
                        {
                            float temp = (v[i] - this.RaySource).DotProduct(CrossVector) / (this.RayTarget - this.RaySource).DotProduct(CrossVector);
                            c.point.vertex = this.RaySource + temp * (this.RayTarget - this.RaySource);
                            c.distance = c.point.vertex.Distance(this.RaySource);
                        }
                        if (this.Direction().DotProduct(c.point.vertex - this.RaySource) < 0f) c.IsValid = false;
                        return c;
                    }
                }
            }
            else c.IsValid = false;
            return c;
        }
        public Collision GetCollisionSTL_Triangle(Triangle triangle, bool IncludeSide)
        {
            Collision c = this.GetCollisionTriangle(triangle.point[0].vertex, triangle.point[1].vertex, triangle.point[2].vertex, IncludeSide);
            if (c.IsValid) c.triangle = triangle;
            return c;
        }
        public Collision GetCollisionCUSTOM_Triangle(Triangle triangle, List<Point> pointList, bool IncludeSide)
        {
            Collision c = this.GetCollisionTriangle(pointList[triangle.vertex_index[0]].vertex, pointList[triangle.vertex_index[1]].vertex, pointList[triangle.vertex_index[2]].vertex, IncludeSide);
            if (c.IsValid)
            {
                c.triangle = triangle;
                for (int i = 0; i < 3; i++) c.triangle.point[i].vertex = pointList[triangle.vertex_index[i]].vertex;
            }
            return c;
        }
    }
    /// <summary>
    /// 三维向量
    /// </summary>
    public class Vector3D
    {
        public enum Axis
        {
            X,
            Y,
            Z
        }
        public struct Componet
        {
            public Vector3D Vertical;
            public Vector3D Parallel;
        }
        public float x, y, z;
        private bool _isBack = false;
        /// <summary>
        /// X轴方向
        /// </summary>
        public static Vector3D XAxis
        {
            get { return new Vector3D(1, 0, 0); }
        }
        /// <summary>
        /// Y轴方向
        /// </summary>
        public static Vector3D YAxis
        {
            get { return new Vector3D(0, 1, 0); }
        }
        /// <summary>
        /// Z轴方向
        /// </summary>
        public static Vector3D ZAxis
        {
            get { return new Vector3D(0, 0, 1); }
        }
        public Vector3D()
        {
            x = y = z = 0;
        }
        public Vector3D(float value_X, float value_Y, float value_Z)
        {
            x = value_X;
            y = value_Y;
            z = value_Z;
        }
        public Vector3D(Vector3D v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
        public static Vector3D ColerVector3D(Color color)
        {
            return new Vector3D(color.R / 255f, color.G / 255f, color.B / 255f);
        }
        public static Color VectorToColor(Vector3D v, float alpha)
        {
            return Color.FromArgb((int)(alpha * 255), (int)(v.x * 255), (int)(v.y * 255), (int)(v.z * 255));
        }
        public Color ToColor(float alpha)
        {
            return VectorToColor(this, alpha);
        }
        public void ReCalculateBack(Vector3D eye, List<Model_Triangle> model_list)
        {
            Ray ray = new Ray(this, eye);
            List<Collision> collisionlist = new List<Collision>();
            foreach (Model_Triangle m in model_list)
            {
                foreach (Collision c in m.HitResult(ray, true)) collisionlist.Add(c);
            }
            if (collisionlist.Count > 0) _isBack = true;
            else _isBack = false;
        }
        public bool CanSee()
        {
            return !_isBack;
        }
        public string ToString(string format = "(#,#,#)")
        {
            if (format == "#,#,#") return x.ToString() + "," + y.ToString() + "," + z.ToString();
            if (format == "# # #") return x.ToString() + " " + y.ToString() + " " + z.ToString();
            if (format == "(# # #)") return "(" + x.ToString() + " " + y.ToString() + " " + z.ToString() + ")";
            format = "(#,#,#)";
            return "(" + x.ToString() + "," + y.ToString() + "," + z.ToString() + ")";
        }
        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z); ;
        }
        public static Vector3D operator *(Vector3D v, float times)
        {
            return new Vector3D(v.x * times, v.y * times, v.z * times);
        }
        public static Vector3D operator *(float times, Vector3D v)
        {
            return v * times;
        }
        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return v1 + (-1) * v2;
        }
        public static Vector3D operator -(Vector3D v)
        {
            return -1 * v;
        }
        public static Vector3D operator /(Vector3D v, float times)
        {
            if (times != 0f)
                return (1 / times) * v;
            else
                return new Vector3D();
        }
        public static bool operator ==(Vector3D v1, Vector3D v2)
        {
            if ((v1 as object) == null) return (v2 as object) == null;
            if ((v2 as object) == null) return (v1 as object) == null;
            return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            return this.x == (obj as Vector3D).x && this.y == (obj as Vector3D).y && this.z == (obj as Vector3D).z;
        }
        public override int GetHashCode()
        {
            return this.ToString("#,#,#").GetHashCode();
        }
        public static bool operator !=(Vector3D v1, Vector3D v2)
        {
            return !(v1 == v2);
        }
        /// <summary>
        /// 向量叉乘
        /// </summary>
        /// <param name="v1">第一个向量</param>
        /// <param name="v2">第二个向量</param>
        /// <returns>两个向量的外积</returns>
        public static Vector3D operator *(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
        }
        /// <summary>
        /// 获取向量的模
        /// </summary>
        /// <returns></returns>
        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        /// <summary>
        /// 向量单位化
        /// </summary>
        /// <returns></returns>
        public Vector3D Normalize()
        {
            if (this.Length() != 0f)
                return this / this.Length();
            else
                return new Vector3D(1, 0, 0);
        }
        /// <summary>
        /// 向量点乘
        /// </summary>
        /// <param name="v1">第一个向量</param>
        /// <param name="v2">第二个向量</param>
        /// <returns>两个向量的内积</returns>
        public static float DotProduct(Vector3D v1, Vector3D v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }
        public float DotProduct(Vector3D v)
        {
            return DotProduct(this, v);
        }
        /// <summary>
        /// 向量叉乘
        /// </summary>
        /// <param name="v1">第一个向量</param>
        /// <param name="v2">第二个向量</param>
        /// <returns>两个向量的外积</returns>
        public static Vector3D CrossProduct(Vector3D v1, Vector3D v2)
        {
            return v1 * v2;
        }
        public Vector3D CrossProduct(Vector3D v)
        {
            return CrossProduct(this, v);
        }
        /// <summary>
        /// 获取该向量在给定方向及其垂直方向的分向量
        /// </summary>
        /// <param name="axis">给定方向</param>
        /// <returns></returns>
        public Componet GetComponet(Vector3D axis)
        {
            Componet c = new Componet();
            c.Parallel = this.DotProduct(axis) / axis.DotProduct(axis) * axis;
            c.Vertical = this - c.Parallel;
            return c;
        }
        /// <summary>
        /// 获取该点在射线方向及其垂直方向的分量
        /// </summary>
        /// <param name="ray">射线</param>
        /// <returns></returns>
        public Componet GetComponet(Ray ray)
        {
            return (this - ray.RaySource).GetComponet(ray.RayTarget - ray.RaySource);
        }
        /// <summary>
        /// 求出该向量绕给定轴旋转给定角度后的向量
        /// </summary>
        /// <param name="angle">给定角度，以弧度计量的角度</param>
        /// <param name="axis">给定轴</param>
        /// <returns>旋转后的向量</returns>
        public Vector3D Rotate(float angle, Axis axis)
        {

            float[] array1 = new float[4] { x, y, z, 1f };
            float[] array2 = new float[4];
            float[,] matrix44 = new float[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                        matrix44[i, j] = 1;
                    else
                        matrix44[i, j] = 0;
                }
            }
            switch (axis)
            {
                case (Axis.X):
                    matrix44[1, 1] = (float)Math.Cos(angle);
                    matrix44[1, 2] = (float)-Math.Sin(angle);
                    matrix44[2, 1] = (float)Math.Sin(angle);
                    matrix44[2, 2] = (float)Math.Cos(angle);
                    break;
                case (Axis.Y):
                    matrix44[0, 0] = (float)Math.Cos(angle);
                    matrix44[2, 0] = (float)-Math.Sin(angle);
                    matrix44[0, 2] = (float)Math.Sin(angle);
                    matrix44[2, 2] = (float)Math.Cos(angle);
                    break;
                case (Axis.Z):
                    matrix44[0, 0] = (float)Math.Cos(angle);
                    matrix44[0, 1] = (float)-Math.Sin(angle);
                    matrix44[1, 0] = (float)Math.Sin(angle);
                    matrix44[1, 1] = (float)Math.Cos(angle);
                    break;
            }
            for (int i = 0; i < 4; i++)
            {
                array2[i] = 0f;
                for (int j = 0; j < 4; j++)
                {
                    array2[i] += matrix44[i, j] * array1[j];
                }
            }
            return new Vector3D(array2[0], array2[1], array2[2]);
        }
        /// <summary>
        /// 将该向量绕给定轴旋转给定角度，并返回旋转后的值
        /// </summary>
        /// <param name="angle">给定角度，以弧度计量的角度</param>
        /// <param name="axis">给定轴</param>
        /// <returns>旋转后的向量</returns>
        public Vector3D SelfRotate(float angle, Axis axis)
        {
            Vector3D v = this.Rotate(angle, axis);
            x = v.x;
            y = v.y;
            z = v.z;
            return v;
        }
        /// <summary>
        /// 求出该向量绕给定方向旋转给定角度后的向量
        /// </summary>
        /// <param name="angle">给定角度，以弧度计量的角度</param>
        /// <param name="axis">给定方向</param>
        /// <returns>旋转后的向量</returns>
        public Vector3D Rotate(float angle, Vector3D axis)
        {
            Componet c = this.GetComponet(axis);
            Vector3D vc = (axis * c.Vertical).Normalize() * c.Vertical.Length();
            return c.Parallel + c.Vertical * (float)Math.Cos(angle) + vc * (float)Math.Sin(angle);
        }
        /// <summary>
        /// 获得该向量绕指定点的指定方向上旋转指定角度后的向量
        /// </summary>
        /// <param name="angle">给定角度，以弧度计量的角度</param>
        /// <param name="baseVertex">指定点</param>
        /// <param name="axis">指定方向</param>
        /// <returns></returns>
        public Vector3D Rotate(float angle, Vector3D baseVertex, Vector3D axis)
        {
            return baseVertex + (this - baseVertex).Rotate(angle, axis);
        }
        /// <summary>
        /// 将该向量绕给顶点的给定方向旋转给定角度，并返回旋转后的值
        /// </summary>
        /// <param name="angle">给定角度，以弧度计量的角度</param>
        /// <param name="baseVertex">指定点</param>
        /// <param name="axis">指定方向</param>
        /// <returns></returns>
        public Vector3D SelfRotate(float angle, Vector3D baseVertex, Vector3D axis)
        {
            Vector3D v = this.Rotate(angle, baseVertex, axis);
            x = v.x;
            y = v.y;
            z = v.z;
            return v;
        }
        /// <summary>
        /// 将该向量绕给定方向旋转给定角度，并返回旋转后的值
        /// </summary>
        /// <param name="angle">给定角度，以弧度计量的角度</param>
        /// <param name="axis">给定方向</param>
        /// <returns>旋转后的向量</returns>
        public Vector3D SelfRotate(float angle, Vector3D axis)
        {
            Vector3D v = this.Rotate(angle, axis);
            x = v.x;
            y = v.y;
            z = v.z;
            return v;
        }
        /// <summary>
        /// 求出该向量沿给定轴移动给定距离后的向量
        /// </summary>
        /// <param name="angle">给定距离</param>
        /// <param name="axis">给定轴</param>
        /// <returns>移动后的向量</returns>
        public Vector3D Move(float distance, Axis axis)
        {
            Vector3D v = new Vector3D();
            switch (axis)
            {
                case (Axis.X):
                    v = new Vector3D(distance, 0, 0);
                    break;
                case (Axis.Y):
                    v = new Vector3D(0, distance, 0);
                    break;
                case (Axis.Z):
                    v = new Vector3D(0, 0, distance);
                    break;
            }
            return this + v;
        }
        /// <summary>
        /// 将该向量沿给定轴移动给定距离，并返回移动后的值
        /// </summary>
        /// <param name="angle">给定距离</param>
        /// <param name="axis">给定轴</param>
        /// <returns>移动后的向量</returns>
        public Vector3D SelfMove(float distance, Axis axis)
        {
            Vector3D v = this.Move(distance, axis);
            x = v.x;
            y = v.y;
            z = v.z;
            return v;
        }
        /// <summary>
        /// 获取两点之间的距离
        /// </summary>
        /// <param name="v1">第一个点</param>
        /// <param name="v2">第二个点</param>
        /// <returns></returns>
        public static float Distance(Vector3D v1, Vector3D v2)
        {
            return (v1 - v2).Length();
        }
        /// <summary>
        /// 获取该点到目标点的距离
        /// </summary>
        /// <param name="v">目标点</param>
        /// <returns></returns>
        public float Distance(Vector3D v)
        {
            return (this - v).Length();
        }
        /// <summary>
        /// 获取给定点到目标射线的距离
        /// </summary>
        /// <param name="v">给定点</param>
        /// <param name="RaySource">目标射线起点</param>
        /// <param name="RayTarget">目标射线终点</param>
        /// <returns></returns>
        public static float RayDistance(Vector3D v, Vector3D RaySource, Vector3D RayTarget)
        {
            return (v - RaySource).GetComponet(RayTarget - RaySource).Vertical.Length();
        }
        /// <summary>
        /// 获取该点到目标射线的距离
        /// </summary>
        /// <param name="RaySource">目标射线的起点</param>
        /// <param name="RayTarget">目标射线的终点</param>
        /// <returns></returns>
        public float RayDistance(Vector3D RaySource, Vector3D RayTarget)
        {
            return RayDistance(this, RaySource, RayTarget);
        }
        /// <summary>
        /// 获取该点到目标射线的距离
        /// </summary>
        /// <param name="ray">目标射线</param>
        /// <returns></returns>
        public float RayDistance(Ray ray)
        {
            return this.RayDistance(ray.RaySource, ray.RayTarget);
        }
        /// <summary>
        /// 获取两个向量之间的夹角
        /// </summary>
        /// <param name="v1">第一个向量</param>
        /// <param name="v2">第二个向量</param>
        /// <returns>以弧度计量的角度</returns>
        public static float GetAngle(Vector3D v1, Vector3D v2)
        {
            return (float)Math.Acos(DotProduct(v1, v2) / (v1.Length() * v2.Length()));
        }
        /// <summary>
        /// 获取该向量与目标向量的夹角
        /// </summary>
        /// <param name="v">目标向量</param>
        /// <returns>以弧度计量的角度</returns>
        public float GetAngle(Vector3D v)
        {
            return GetAngle(this, v);
        }
        /// <summary>
        /// 判断一个点是否在三角形内
        /// </summary>
        /// <param name="v1">该点到第一个顶点的向量</param>
        /// <param name="v2">该点到第二个顶点的向量</param>
        /// <param name="v3">该点到第三个顶点的向量</param>
        /// <param name="IncludeSide">是否把边上的点算作内部点</param>
        /// <returns></returns>
        public static bool PointInTriangle(Vector3D v1, Vector3D v2, Vector3D v3, bool IncludeSide = false)
        {
            bool b = true;
            float[] angle = new float[6];
            angle[0] = Vector3D.GetAngle(v1, v1 - v2);
            angle[1] = Vector3D.GetAngle(v1, v1 - v3);
            angle[2] = Vector3D.GetAngle(v2, v2 - v1);
            angle[3] = Vector3D.GetAngle(v2, v2 - v3);
            angle[4] = Vector3D.GetAngle(v3, v3 - v1);
            angle[5] = Vector3D.GetAngle(v3, v3 - v2);
            float[] bigangle = new float[3];
            bigangle[0] = Vector3D.GetAngle(v1 - v2, v1 - v3);
            bigangle[1] = Vector3D.GetAngle(v2 - v3, v2 - v1);
            bigangle[2] = Vector3D.GetAngle(v3 - v1, v3 - v2);
            for (int i = 0; i < 3; i++)
            {
                if (bigangle[i] + 0.00029f / 3f < angle[2 * i + 0] + angle[2 * i + 1]) b = false;
                if (bigangle[i] == 0f) b = false;
            }
            if (!IncludeSide)
            {
                for (int i = 0; i < 6; i++)
                    if (angle[i] == 0f) b = false;
            }
            return b;
        }
        /// <summary>
        /// 判断一个点是否在三角形内
        /// </summary>
        /// <param name="v1">第一个点</param>
        /// <param name="v2">第二个点</param>
        /// <param name="v3">第三个点</param>
        /// <param name="IncludeSide">是否把边上的点算作内部点</param>
        /// <returns></returns>
        public bool InTriangle(Vector3D v1, Vector3D v2, Vector3D v3, bool IncludeSide = false)
        {
            return PointInTriangle(v1 - this, v2 - this, v3 - this, IncludeSide);
        }

    }
    public struct TextLabel
    {
        public enum TextLabelType
        {
            TextLabel3D,
            TextLabel2D,
            AlwaysDisplay
        }
        public string FontName;
        public string Text;
        public TextLabelType LabelType;
        public float Size;
        public Vector3D TextColor;
        public Triangle triangle;
        public Vector3D Vertex3D;
        public Vector2D Vertex2D;
        public Vector2D DeltaVertex2D;
        private bool _canSee;
        private bool _DrawPoint;
        /// <summary>
        /// 设置文字
        /// </summary>
        /// <param name="fontname">字体名</param>
        /// <param name="type">文字空间类型：3D/2D</param>
        /// <param name="text">文字内容</param>
        /// <param name="size">文字大小</param>
        /// <param name="color">文字颜色</param>
        /// <param name="vertex3D">文字三维坐标</param>
        /// <param name="vertex2D">文字屏幕坐标</param>
        /// <param name="delta">文字在屏幕上偏移坐标</param>
        /// <param name="tri">文字所在三角面片</param>
        public TextLabel(string fontname = "", TextLabelType type = TextLabelType.TextLabel3D, string text = "", float size = 10, Vector3D color = null, Vector3D vertex3D = null, Vector2D vertex2D = new Vector2D(), Vector2D delta = new Vector2D(), Triangle tri = new Triangle())
        {
            FontName = fontname;
            LabelType = type;
            Text = text;
            //TextFont = font;
            Size = size;
            if (color == null) TextColor = new Vector3D(1, 0, 0);
            else TextColor = color;
            if (vertex3D == null) Vertex3D = new Vector3D();
            else Vertex3D = vertex3D;
            Vertex2D = vertex2D;
            DeltaVertex2D = delta;
            triangle = tri;
            _canSee = false;
            _DrawPoint = false;
        }
        public void SetCanSee(bool b)
        {
            _canSee = b;
        }
        public void SetDrawPoint(bool b = false)
        {
            _DrawPoint = b;
        }
        public bool DrawPoint()
        {
            if (LabelType == TextLabelType.TextLabel2D) return false;
            return _DrawPoint;
        }
        public void ReCalculateBack(Vector3D eye, float angle)
        {
            _canSee = ((eye - Vertex3D).Normalize().DotProduct(triangle.NormalVector) > (float)Math.Sin(3.1415926535898f / 180f * angle));
        }
        public bool CanSee()
        {
            return _canSee;
        }
    }
    public struct Arrow3D
    {
        public Vector3D StartPosition;
        public Vector3D EndPosition;
        public Model_Triangle ArrowHead;
        public Vector3D Color;
        private float width;
        public float Width
        {
            get { return width; }
        }
        public Arrow3D(Vector3D start, Vector3D end, Vector3D color = null)
        {
            StartPosition = start;
            EndPosition = end;
            ArrowHead = Model_Triangle.CreateArrowHead(start, end);
            width = (end - start).Length() / 140f < 0.5f ? (end - start).Length() / 140f : 0.5f;
            Color = color;
        }
    }
    public struct Vector2D
    {
        public float X;
        public float Y;
        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
    /// <summary>
    /// 三角面片
    /// </summary>
    public struct Triangle
    {
        public int[] vertex_index;
        public Point[] point;
        public Vector3D NormalVector;

        public Triangle(List<Point> pointlist = null, int v1 = 0, int v2 = 1, int v3 = 2)
        {
            vertex_index = new int[3];
            vertex_index[0] = v1;
            vertex_index[1] = v2;
            vertex_index[2] = v3;
            NormalVector = new Vector3D();
            point = new Point[3];
            if (pointlist != null && pointlist.Count >= Math.Max(Math.Max(v1, v2), v3))
            {
                point[0] = pointlist[v1];
                point[1] = pointlist[v2];
                point[2] = pointlist[v3];
                NormalVector = (point[1].vertex - point[0].vertex) * (point[2].vertex - point[0].vertex);
            }
        }
        public Triangle(int v1 = 0, int v2 = 1, int v3 = 2, Vector3D normalVector = null)
        {
            vertex_index = new int[3];
            vertex_index[0] = v1;
            vertex_index[1] = v2;
            vertex_index[2] = v3;
            NormalVector = new Vector3D();
            point = new Point[3];
            if (normalVector != null) NormalVector = normalVector;
        }
        public Triangle(Point p1, Point p2, Point p3, Vector3D normalVector = null)
        {
            vertex_index = new int[3];
            vertex_index[0] = 0;
            vertex_index[1] = 1;
            vertex_index[2] = 2;
            point = new Point[3];
            point[0] = p1;
            point[1] = p2;
            point[2] = p3;
            if (normalVector == null) NormalVector = (p2.vertex - p1.vertex) * (p3.vertex - p1.vertex);
            else NormalVector = normalVector;
        }
        public bool PointIncluded(int point_index)
        {
            bool b = false;
            foreach (int i in vertex_index)
            {
                if (i == point_index) b = true;
            }
            return b;
        }
        public override string ToString()
        {
            return this.vertex_index[0].ToString() + " " + this.vertex_index[1].ToString() + " " + this.vertex_index[2].ToString() + " " + this.NormalVector.x.ToString() + " " + this.NormalVector.y.ToString() + " " + this.NormalVector.z.ToString();
        }
        public static Vector3D AverageNormalVector(Triangle[] tlist)
        {
            Vector3D v = new Vector3D();
            foreach (Triangle t in tlist) v += t.NormalVector;
            return v / tlist.Length;
        }
        public static Vector3D AverageNormalVector(List<Triangle> tlist)
        {
            Vector3D v = new Vector3D();
            foreach (Triangle t in tlist) v += t.NormalVector;
            return v / tlist.Count;
        }
    }
    /// <summary>
    /// 多边形面片
    /// </summary>
    public struct Polygon
    {
        public int SideNum;
        public int[] vertices;
        public Polygon(int[] vertices_index)
        {
            if (vertices_index.Length >= 3)
                SideNum = vertices_index.Length;
            else
                SideNum = 3;
            vertices = new int[SideNum];
            for (int i = 0; i < vertices_index.Length; i++)
                vertices[i] = vertices_index[i];
        }
    }
    public struct Model3D_Polygon
    {
        public string ModelName;
        public List<int> SideNum;
        public List<Polygon> PolygonList;
        public List<Vector3D> VertixList;
        public List<Vector3D> ColorList;
        public Model3D_Polygon(string name, int[] Side_Num)
        {
            ModelName = name;
            SideNum = Side_Num.ToList<int>();
            PolygonList = new List<Polygon>();
            VertixList = new List<Vector3D>();
            ColorList = new List<Vector3D>();
        }
    }
    public struct Point
    {
        public Vector3D vertex;
        public Vector3D color;
        public override string ToString()
        {
            return vertex.ToString("# # #") + " " + color.ToString("# # #");
        }
    }
    public struct Interval
    {
        public float Max;
        public float Min;
        public float Length
        {
            get
            {
                return Max - Min;
            }
        }
    }
    public struct Boundary
    {
        public Interval X;
        public Interval Y;
        public Interval Z;
    }
    public struct Collision
    {
        public Ray ray;
        public Triangle triangle;
        public Point point;
        public float distance;
        public bool IsValid;
    }
    public class Model_Triangle
    {
        public enum ModelType
        {
            STL,
            OBJ,
            CUSTOM
        }
        public Boundary ModelBoundary
        {
            get
            {
                Boundary b = new Boundary();
                b.X.Max = -9.9e9f;
                b.X.Min = 9.9e9f;
                b.Y.Max = -9.9e9f;
                b.Y.Min = 9.9e9f;
                b.Z.Max = -9.9e9f;
                b.Z.Min = 9.9e9f;
                foreach (Vector3D v in PointCloud)
                {
                    if (b.X.Max <= v.x) b.X.Max = v.x;
                    if (b.X.Min >= v.x) b.X.Min = v.x;
                    if (b.Y.Max <= v.y) b.Y.Max = v.y;
                    if (b.Y.Min >= v.y) b.Y.Min = v.y;
                    if (b.Z.Max <= v.z) b.Z.Max = v.z;
                    if (b.Z.Min >= v.z) b.Z.Min = v.z;
                }
                return b;
            }
        }
        public ModelType TypeOfModel;
        public string ModelName;
        public List<Triangle> TriangleList;
        public List<Point> PointList;
        public List<Vector3D> VertexList;
        public List<Vector3D> ColorList;
        public float Alpha = 0f;
        public int PointsRowCount = -1, PointsColumnCount = -1;
        private bool _CanBeSelected = true;

        public static Model_Triangle BALL
        {
            get
            {
                Model_Triangle m = new Model_Triangle("BALL", ModelType.CUSTOM);
                m.VertexList.Add(new Vector3D(-1, 0, 0));
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Vector3D v = new Vector3D(0.4f * (i + 1) - 1f, (float)(Math.Sqrt(1.0 - (0.4 * (i + 1) - 1f) * (0.4 * (i + 1) - 1f)) * Math.Cos(3.1415926535898f * 2f * j / 10f)), (float)(Math.Sqrt(1.0 - (0.4 * (i + 1) - 1f) * (0.4 * (i + 1) - 1f)) * Math.Sin(3.1415926535898f * 2f * j / 10f)));
                        m.VertexList.Add(v);
                    }
                }
                m.VertexList.Add(new Vector3D(1, 0, 0));
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Triangle t = new Triangle(0);
                        t.vertex_index[0] = 1 + i * 10 + j;
                        t.vertex_index[1] = 1 + (i + 1) * 10 + j;
                        t.vertex_index[2] = 1 + (i + 1) * 10 + (j + 1) % 10;
                        m.TriangleList.Add(t);
                        t = new Triangle(0);
                        t.vertex_index[0] = 1 + i * 10 + j;
                        t.vertex_index[1] = 1 + (i + 1) * 10 + (j + 1) % 10;
                        t.vertex_index[2] = 1 + i * 10 + (j + 1) % 10;
                        m.TriangleList.Add(t);
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    Triangle t = new Triangle(0);
                    t.vertex_index[0] = 0;
                    t.vertex_index[1] = 1 + i;
                    t.vertex_index[2] = 1 + (i + 1) % 10;
                    m.TriangleList.Add(t);
                    t = new Triangle(0);
                    t.vertex_index[0] = 31 + i;
                    t.vertex_index[1] = 41;
                    t.vertex_index[2] = 31 + (i + 1) % 10;
                    m.TriangleList.Add(t);
                }
                return m;
            }
        }
        public static Model_Triangle SiMianTi
        {
            get
            {
                Model_Triangle m = new Model_Triangle("四面体", ModelType.CUSTOM);
                m.VertexList.Add(new Vector3D(-0.288675f, -0.5f, -0.204124f));
                m.VertexList.Add(new Vector3D(-0.288675f, 0.5f, -0.204124f));
                m.VertexList.Add(new Vector3D(0.577350f, 0, -0.204124f));
                m.VertexList.Add(new Vector3D(0, 0, 0.612372f));

                Triangle t = new Triangle(0);
                t.vertex_index[0] = 0;
                t.vertex_index[1] = 1;
                t.vertex_index[2] = 2;
                m.TriangleList.Add(t);
                t = new Triangle(0);
                t.vertex_index[0] = 1;
                t.vertex_index[1] = 2;
                t.vertex_index[2] = 3;
                m.TriangleList.Add(t);
                t = new Triangle(0);
                t.vertex_index[0] = 0;
                t.vertex_index[1] = 1;
                t.vertex_index[2] = 3;
                m.TriangleList.Add(t);
                t = new Triangle(0);
                t.vertex_index[0] = 0;
                t.vertex_index[1] = 2;
                t.vertex_index[2] = 3;
                m.TriangleList.Add(t);

                return m;
            }
        }
        public static Model_Triangle CreateArrowHead(Vector3D start, Vector3D end)
        {
            Vector3D linedirection = end - start;
            float length = linedirection.Length() / 7f < 5f ? linedirection.Length() / 7f : 5f;
            Model_Triangle m = new Model_Triangle("Cone", ModelType.CUSTOM);
            Vector3D parallelaxis = linedirection.Normalize();
            Vector3D verticalaxis = new Vector3D();
            if (parallelaxis.x == 0f && parallelaxis.y == 0f) verticalaxis = new Vector3D(0, 1, 0);
            else verticalaxis = new Vector3D(-parallelaxis.y, parallelaxis.x, 0f).Normalize();
            m.VertexList.Add(end);
            for (int i = 0; i < 12; i++)
            {
                Vector3D v = 0.25f * length * verticalaxis.Rotate(3.1415926535898f * 2f * i / 12f, parallelaxis) - length * parallelaxis + end;
                m.VertexList.Add(v);
            }
            m.VertexList.Add(end - length * parallelaxis);
            for (int i = 0; i < 12; i++)
            {
                Triangle t = new Triangle(0);
                t.vertex_index[0] = 0;
                t.vertex_index[1] = 1 + i;
                t.vertex_index[2] = 1 + (i + 1) % 12;
                m.TriangleList.Add(t);
                t = new Triangle(0);
                t.vertex_index[0] = 1 + i;
                t.vertex_index[1] = 13;
                t.vertex_index[2] = 1 + (i + 1) % 12;
                m.TriangleList.Add(t);
            }
            return m;
        }
        /// <summary>
        /// 三维模型构造函数
        /// </summary>
        /// <param name="name">三维模型名字</param>
        /// <param name="m">三维模型类型</param>
        /// <param name="filepath">三维模型路径</param>
        /// <param name="canBeSelected">可否被选中</param>
        public Model_Triangle(string name, ModelType m, string filepath = "", bool canBeSelected = true)
        {
            ModelName = name;
            TypeOfModel = m;
            TriangleList = new List<Triangle>();
            PointList = new List<Point>();
            VertexList = new List<Vector3D>();
            ColorList = new List<Vector3D>();
            _CanBeSelected = canBeSelected;
            if (filepath != "")
            {
                if (m == ModelType.STL) ReadSTLModel(filepath);
                if (m == ModelType.CUSTOM) ReadCUSTOMModel(filepath);
            }
        }
        ~Model_Triangle()
        {
            ClearModel();
        }
        public bool ReadSTLModel(string path)
        {
            try
            {
                BinaryReader reader = new BinaryReader(File.OpenRead(path));

                byte[] data;

                data = reader.ReadBytes(80);
                int _triangleCount = (int)reader.ReadUInt32();
                //_triangle = new Triangle[_triangleCount];

                if (reader.BaseStream.Length != _triangleCount * 50 + 84)
                    throw new InvalidDataException("STL文件长度无效");
                ClearModel();
                for (int i = 0; i < _triangleCount; i++)
                {
                    Triangle tempTriangle = new Triangle(0);
                    tempTriangle.NormalVector.x = reader.ReadSingle();
                    tempTriangle.NormalVector.y = reader.ReadSingle();
                    tempTriangle.NormalVector.z = reader.ReadSingle();
                    tempTriangle.point = new Point[3];
                    tempTriangle.vertex_index = new int[3];
                    for (int m = 0; m < 3; m++)
                    {
                        Vector3D tempVertex = new Vector3D();
                        tempVertex.x = reader.ReadSingle();
                        tempVertex.y = reader.ReadSingle();
                        tempVertex.z = reader.ReadSingle();
                        tempTriangle.point[m].vertex = tempVertex;
                        tempTriangle.point[m].color = new Vector3D(0, 0, 0.7f) + tempTriangle.NormalVector / 6.4f;
                        tempTriangle.vertex_index[m] = 3 * i + m;
                        //tempTriangle.point[m].color = tempVertex.Normalize();
                    }
                    reader.ReadBytes(2);
                    PointList.Add(tempTriangle.point[0]);
                    PointList.Add(tempTriangle.point[1]);
                    PointList.Add(tempTriangle.point[2]);
                    TriangleList.Add(tempTriangle);
                }
                foreach (Point p in PointList)
                {
                    VertexList.Add(p.vertex);
                    ColorList.Add(p.color);
                }
                return true;
            }
            catch
            {
                ClearModel();
                return false;
            }
        }
        public bool ReadCUSTOMModel(String FilePath)
        {
            ClearModel();
            bool result = false;
            System.IO.StreamReader reader = null;
            String line = "";
            try
            {
                reader = new System.IO.StreamReader(FilePath);
                if (reader != null)
                {
                    if (!reader.EndOfStream)//如果没有到文件尾,那么继续循环
                    {
                        line = reader.ReadLine();//读入一行
                        line = reader.ReadLine();
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
            String[] datas = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (datas[0] == "P")
                result = ReadCUSTOMModelOLD(FilePath);
            else
                result = ReadCUSTOMModelNEW(FilePath);
            return result;
        }
        public bool ReadCUSTOMModelNEW(String FilePath)
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
                            String[] datas = line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            if (datas == null) break;
                            if (datas.Length <= 0) break;
                            ColumnCount = datas.Length;
                        }
                        RowCount++;
                    }

                    if (RowCount > 0 && ColumnCount > 0)
                    {
                        ClearModel();
                        PointList = new List<Point>();
                        List<Point> plist = new List<Point>();
                        this.PointsRowCount = RowCount;
                        this.PointsColumnCount = ColumnCount;
                        reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                        while (!reader.EndOfStream)//如果没有到文件尾,那么继续循环
                        {
                            String line = reader.ReadLine();//读入一行
                            String[] datas = line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            if (datas == null) break;
                            if (datas.Length != ColumnCount) break;
                            foreach (String data in datas)
                            {
                                float x = -1, y = -1, z = -1;
                                String[] Ele = data.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                if (Ele != null)
                                {
                                    if (Ele.Length >= 3)
                                    {
                                        x = Convert.ToSingle(Ele[0].Trim());
                                        y = Convert.ToSingle(Ele[1].Trim());
                                        z = Convert.ToSingle(Ele[2].Trim());
                                    }
                                }
                                Point p = new Point();
                                p.vertex = new Vector3D(x, y, z) * 1.1f;
                                plist.Add(p);
                                result = true;
                            }
                        }
                        TriangleList = new List<Triangle>();
                        for (int i = 0; i < this.PointsRowCount - 1; i++)
                        {
                            for (int j = 0; j < this.PointsColumnCount - 1; j++)
                            {
                                Triangle t = new Triangle(i * this.PointsColumnCount + j, (i + 1) * this.PointsColumnCount + j, (i + 1) * this.PointsColumnCount + j + 1);
                                t.NormalVector = ((plist[t.vertex_index[1]].vertex - plist[t.vertex_index[0]].vertex) * (plist[t.vertex_index[2]].vertex - plist[t.vertex_index[0]].vertex)).Normalize();
                                TriangleList.Add(t);
                                t = new Triangle(i * this.PointsColumnCount + j, (i + 1) * this.PointsColumnCount + j + 1, i * this.PointsColumnCount + j + 1);
                                t.NormalVector = ((plist[t.vertex_index[1]].vertex - plist[t.vertex_index[0]].vertex) * (plist[t.vertex_index[2]].vertex - plist[t.vertex_index[0]].vertex)).Normalize();
                                TriangleList.Add(t);
                            }
                        }
                        List<Triangle> tlist = new List<Triangle>();
                        for (int i = 0; i < plist.Count; i++)
                        {
                            tlist = new List<Triangle>();
                            foreach (Triangle t in TriangleList)
                            {
                                if (t.PointIncluded(i)) tlist.Add(t);
                            }
                            Point p = new Point();
                            p.vertex = new Vector3D(plist[i].vertex);
                            p.color = new Vector3D(0.0f, 0.35f, 0.7f) + Triangle.AverageNormalVector(tlist) / 6.4f;
                            PointList.Add(p);
                        }
                        foreach (Point p in PointList)
                        {
                            VertexList.Add(p.vertex);
                            ColorList.Add(p.color);
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
        public bool ReadCUSTOMModelOLD(String FilePath)
        {
            ClearModel();
            bool result = false;
            System.IO.StreamReader reader = null;
            try
            {
                int ColumnCount = -1;//列数量
                int RowCount = -1; //航数量
                reader = new System.IO.StreamReader(FilePath);
                if (reader != null)
                {
                    while (!reader.EndOfStream)//如果没有到文件尾,那么继续循环
                    {
                        String line = reader.ReadLine();//读入一行
                        String[] datas = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (RowCount == -1)
                        {
                            RowCount = int.Parse(datas[0]);
                            ColumnCount = int.Parse(datas[1]);
                            this.PointsRowCount = RowCount;
                            this.PointsColumnCount = ColumnCount;
                        }
                        else
                        {
                            if (datas[0] == "P")
                            {
                                Point p = new Point();
                                p.vertex = new Vector3D(float.Parse(datas[1]), float.Parse(datas[2]), float.Parse(datas[3]));
                                p.color = new Vector3D(float.Parse(datas[4]), float.Parse(datas[5]), float.Parse(datas[6]));
                                PointList.Add(p);
                                VertexList.Add(p.vertex);
                                ColorList.Add(p.color);
                            }
                            if (datas[0] == "T")
                            {
                                Triangle t = new Triangle(int.Parse(datas[1]), int.Parse(datas[2]), int.Parse(datas[3]));
                                t.NormalVector = new Vector3D(float.Parse(datas[4]), float.Parse(datas[5]), float.Parse(datas[6]));
                                TriangleList.Add(t);
                            }
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
        public void SaveCUSTOMModel(string filepath)
        {
            List<string> slist = new List<string>();
            slist.Add(PointsRowCount.ToString() + " " + PointsColumnCount.ToString());
            foreach (Point p in PointList) slist.Add("P " + p.ToString());
            foreach (Triangle t in TriangleList) slist.Add("T " + t.ToString());
            if (File.Exists(filepath))
                File.Delete(filepath);
            if (!File.Exists(filepath))
            {
                FileStream fs1 = new FileStream(filepath, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                foreach (string s in slist)
                {
                    sw.WriteLine(s);
                }
                sw.Close();
                fs1.Close();
            }
        }
        public void ClearModel()
        {
            TriangleList = new List<Triangle>();
            PointList = new List<Point>();
            VertexList = new List<Vector3D>();
            ColorList = new List<Vector3D>();
        }
        public List<Vector3D> PointCloud
        {
            get
            {
                List<Vector3D> VectorList = new List<Vector3D>();
                foreach (string strdata in StringPointCloud)
                {
                    string[] str = strdata.Split(',');
                    Vector3D v = new Vector3D();
                    v.x = float.Parse(str[0]);
                    v.y = float.Parse(str[1]);
                    v.z = float.Parse(str[2]);
                    VectorList.Add(v);
                }
                return VectorList;
            }
        }
        private List<string> StringPointCloud
        {
            get
            {
                List<string> list = new List<string>();
                Hashtable hash = new Hashtable();
                foreach (Point v in PointList)
                {
                    string str = v.vertex.x.ToString() + "," + v.vertex.y.ToString() + "," + v.vertex.z.ToString();
                    if (!hash.ContainsKey(str))
                    {
                        hash.Add(str, str);
                        list.Add(str);
                    }
                }
                hash.Clear();
                hash = null;
                return list;
            }
        }

        /// <summary>
        /// 设置该模型是否可被选中
        /// </summary>
        /// <param name="b"></param>
        public void SetCanBeSelected(bool b)
        {
            _CanBeSelected = b;
        }
        /// <summary>
        /// 该模型是否可被选中
        /// </summary>
        /// <returns></returns>
        public bool CanBeSelected()
        {
            return _CanBeSelected;
        }
        /// <summary>
        /// 获取射线碰撞检测结果
        /// </summary>
        /// <param name="ray">射线</param>
        /// <param name="IncludeSide">是否包含三角面片边上的点</param>
        /// <param name="Radius">三角面片外圆半径范围</param>
        /// <returns></returns>
        public List<Collision> HitResult(Ray ray, bool IncludeSide = false, float Radius = 10f)
        {
            List<Collision> collisionList = new List<Collision>();
            if (TypeOfModel == ModelType.STL)
            {
                foreach (Triangle t in TriangleList)
                {
                    bool b = true;
                    for (int i = 0; i < 3; i++)
                    {
                        if (t.point[0].vertex.RayDistance(ray) >= Radius) b = false;
                    }
                    //if (t.point[0].vertex.RayDistance(ray) <= Radius)
                    if (b)
                    {
                        Collision c = ray.GetCollisionSTL_Triangle(t, IncludeSide);
                        if (c.IsValid) collisionList.Add(c);
                    }
                }
            }
            if (TypeOfModel == ModelType.CUSTOM)
            {
                foreach (Triangle t in TriangleList)
                {
                    bool b = true;
                    for (int i = 0; i < 3; i++)
                    {
                        if (PointList[t.vertex_index[0]].vertex.RayDistance(ray) >= Radius) b = false;
                    }
                    //if (PointList[t.vertex_index[0]].vertex.RayDistance(ray) <= Radius)
                    if (b)
                    {
                        Collision c = ray.GetCollisionCUSTOM_Triangle(t, PointList, IncludeSide);
                        if (c.IsValid) collisionList.Add(c);
                    }
                }
            }
            return CommonClass.SortHitResult(collisionList);
        }
    }
}
