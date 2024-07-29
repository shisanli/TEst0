using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PressureUpper
{
    public class DrawModel3D_V2

    {
        /***********************************
         * 参数区
         ***********************************/
        #region 参数区 
        /// <summary>
        /// 差值数量
        /// </summary>
        public int IntperNumber = 8;

        /// <summary>
        /// 色标最小压力
        /// </summary>
        public const int PressureMin = 0;
        /// <summary>
        /// 色标最大压力 //最小是50
        /// </summary>
        //public const int PressureMax = 5000;
        //public const int PressureMax = 10000;
        public const int PressureMax = 150;

        /// <summary>
        /// 3D还是平面图
        /// </summary>
        public bool Draw3DPlot = true;


        public const double DEG2RAD = Math.PI / 180;
        public const double RAD2DEG = 180 / Math.PI;

        public const double footSizeRatio = 40.0 / 180;

        public float sump = 0f;
        #endregion

        /***********************************
         * 变量区
         ***********************************/
        #region 变量区

        public HeadModelV2 Head = new HeadModelV2();
        public PressureModelV2 Pressure = new PressureModelV2();
        public DrawFunctionLib.DrawFunction3D DrawTools = new DrawFunctionLib.DrawFunction3D(800, 800) { TurnMatrix = DrawFunctionLib.DrawFunction3D.ShadowMatrix.FromTurning(0, 0, 180 * DEG2RAD) };
        public DrawFunctionLib.DrawFunction3D DrawTools3D = new DrawFunctionLib.DrawFunction3D(800, 800);// { TurnMatrix = DrawFunctionLib.DrawFunction3D.ShadowMatrix.FromTurning(0, 0, 180 * DEG2RAD) };
        public PointTrack CenterTrack = new PointTrack(5);

        #endregion



        /***********************************
         * 代码区
         ***********************************/
        #region 代码区
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>是否成功</returns>
        public bool InitialSet()
        {
            bool result = false;

            try
            {
                Pressure.ConvertV2();
                if (colorMap == null)
                {
                    colorMap = ColorMap.FallRdGrV2();
                }

                if (Head.Data3D != null && Pressure != null)
                {
                    float xMin = -1;
                    float xMax = -1;
                    float yMin = -1;
                    float yMax = -1;
                    float zMin = -1;
                    float zMax = -1;

                    for (int i = 0; i < Head.Data3D.Length; i++)
                    {
                        float x = Head.Data3D[i].X;
                        float y = Head.Data3D[i].Y;
                        float z = Head.Data3D[i].Z;

                        if (x < 0 || y < 0 || z < 0) continue;

                        if (x < xMin || xMin == -1) xMin = x;
                        if (x > xMax || xMax == -1) xMax = x;
                        if (y < yMin || yMin == -1) yMin = y;
                        if (y > yMax || yMax == -1) yMax = y;
                        if (z < zMin || zMin == -1) zMin = z;
                        if (z > zMax || zMax == -1) zMax = z;

                    }


                    DrawTools.DrawRangeX.SetRange(xMin - 1, xMax + 1);
                    DrawTools.DrawRangeY.SetRange(yMin - 10, yMax + 1);
                    DrawTools.DrawRangeZ.SetRange(-zMax * 0.4, zMax * 1.2);
                    DrawTools.DrawLockZoom = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }



        /// <summary>
        /// 画图像 3D
        /// </summary>
        /// <returns>是否成功</returns>
        public bool Draw3D()
        {
            bool result = false;

            try
            {
                Pressure.ConvertV2();
                DrawTools.DrawPartListFunction.Clear();

                //压力中心点===================================================================
                DrawFunctionLib.DrawFunction3D.PointF3D Centre = Pressure.PressureCentre;

                if (!Draw3DPlot) Centre.Z = (float)DrawTools.DrawRangeZ.Min;

                DrawFunctionLib.DrawFunction3DPart.FillEllipse ell = new DrawFunctionLib.DrawFunction3DPart.FillEllipse(DrawTools,
                    Brushes.Red, Centre, 10, 10);
                DrawTools.DrawPartListFunction.Add(ell);

                Pen pen = new Pen(Color.DarkBlue);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                pen.Width = 0;
                DrawFunctionLib.DrawFunction3DPart.DrawLine line = new DrawFunctionLib.DrawFunction3DPart.DrawLine(DrawTools,
                    pen,
                    Centre,
                    new DrawFunctionLib.DrawFunction3D.PointF3D(Centre.X, Centre.Y, (float)DrawTools.DrawRangeZ.Min));
                DrawTools.DrawPartListFunction.Add(line);
                line = new DrawFunctionLib.DrawFunction3DPart.DrawLine(DrawTools,
                    pen,
                    Centre,
                    new DrawFunctionLib.DrawFunction3D.PointF3D(Centre.X, (float)DrawTools.DrawRangeY.Min, Centre.Z));
                DrawTools.DrawPartListFunction.Add(line);
                line = new DrawFunctionLib.DrawFunction3DPart.DrawLine(DrawTools,
                    pen,
                    Centre,
                    new DrawFunctionLib.DrawFunction3D.PointF3D((float)DrawTools.DrawRangeX.Min, Centre.Y, Centre.Z));
                DrawTools.DrawPartListFunction.Add(line);

                //差值==========================================================================
                for (int i = 0; i < Head.Triangles.Length; i++)
                {
                    int[] triangle = Head.Triangles[i];
                    DrawFunctionLib.DrawFunction3D.PointF3D[] points = new DrawFunctionLib.DrawFunction3D.PointF3D[3];
                    points[0] = Head.Data3D[triangle[0]];
                    points[1] = Head.Data3D[triangle[1]];
                    points[2] = Head.Data3D[triangle[2]];

                    float[] pressures = new float[3];
                    pressures[0] = Pressure.PressureV2[triangle[0]];
                    pressures[1] = Pressure.PressureV2[triangle[1]];
                    pressures[2] = Pressure.PressureV2[triangle[2]];

                    Interp(points, pressures, PressureMin, PressureMax);

                }
                //Pen pen1 = new Pen(Color.Black, 5);
                //DrawFunctionLib.DrawFunction3D.PointF3D[] pointList = new DrawFunctionLib.DrawFunction3D.PointF3D[360];
                //for (int i = 0; i < 360; i++)
                //{
                //    pointList[i] = new DrawFunctionLib.DrawFunction3D.PointF3D((float)(97 + 10 * Math.Cos(i / 180f * Math.PI)), (float)(90 + 10 * Math.Sin(i / 180f * Math.PI)), 1f);
                //}
                //DrawFunctionLib.DrawFunction3DPart.DrawClosedCurve cur = new DrawFunctionLib.DrawFunction3DPart.DrawClosedCurve(DrawTools, pen1, Head.xiedian);
                //DrawTools.DrawPartListFunction.Add(cur);

                DrawTools.DrawFunction(true);
            }
            catch
            {
                result = false;
            }

            return result;
        }
        public bool Draw3D(int max_row = 0, int max_col = 0, int min_row = 0, int min_col = 0, DrawFunctionLib.DrawFunction3D.PointF3D PreCenter = null)
        {
            bool result = false;

            try
            {
                Pressure.ConvertV2();
                DrawTools.DrawPartListFunction.Clear();

                #region 坐标轴
                //坐标轴===================================================================
                //DrawFunctionLib.DrawFunction3DModel.DrawCoordinate DrawCoordinate = new DrawFunctionLib.DrawFunction3DModel.DrawCoordinate(DrawTools);
                //DrawCoordinate.DrawCoordinateSettings.CoordinateNumberX = 16;
                //DrawCoordinate.DrawCoordinateSettings.CoordinateNumberY = 16;
                //DrawCoordinate.DrawCoordinateSettings.CoordinateNumberZ = 16;
                //DrawCoordinate.DrawCoordinateSettings.CoordinateNameX = "";
                //DrawCoordinate.DrawCoordinateSettings.CoordinateNameY = "";
                //DrawCoordinate.DrawCoordinateSettings.CoordinateNameZ = "";
                //DrawCoordinate.DrawCoordinateSettings.DrawFont = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                //DrawCoordinate.DrawCoordinateSettings.PenCoordinate.Width = 1;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawCoordinateAreaXY = true;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawCoordinateAreaXZ = true;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawCoordinateAreaYZ = true;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawSubCoordinateXY = true;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawSubCoordinateXZ = true;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawSubCoordinateYZ = true;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawCoordinateValue = false;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawTopCoordinateXYZ = false;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawCoordinateAreaXY = false;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawCoordinateAreaXZ = false;
                //DrawCoordinate.DrawCoordinateSettings.EnableDrawCoordinateAreaYZ = false;
                //DrawCoordinate.DrawCoordinateSettings.PenCoordinate.Color = Color.LightGray;
                //DrawCoordinate.DrawCoordinateSettings.PenSubCoordinate.Color = Color.LightGray;
                //DrawCoordinate.CalcualteModel();
                //DrawTools.DrawPartListFunction.AddRange(DrawCoordinate.PartList);
                #endregion




                //压力中心点 ===================================================================
                DrawFunctionLib.DrawFunction3D.PointF3D Centre = Pressure.PressureCentre;

                if (!Draw3DPlot) Centre.Z = (float)DrawTools.DrawRangeZ.Min;

                DrawFunctionLib.DrawFunction3DPart.FillEllipse ell = new DrawFunctionLib.DrawFunction3DPart.FillEllipse(DrawTools,
                    Brushes.Red, Centre, 10, 10);
                DrawTools.DrawPartListFunction.Add(ell);

                /*{
                    DrawFunctionLib.DrawFunction3D.PointF3D Centre2 =
                        new DrawFunctionLib.DrawFunction3D.PointF3D(Centre.X + 20, Centre.Y, Centre.Z);
                    DrawFunctionLib.DrawFunction3DPart.FillEllipse ell2 = new DrawFunctionLib.DrawFunction3DPart.FillEllipse(DrawTools,
                        Brushes.Yellow, Centre2, 10, 10);
                    DrawTools.DrawPartListFunction.Add(ell2);
                }

                {
                    DrawFunctionLib.DrawFunction3D.PointF3D Centre2 =
                        new DrawFunctionLib.DrawFunction3D.PointF3D(Centre.X, Centre.Y + 20, Centre.Z);
                    DrawFunctionLib.DrawFunction3DPart.FillEllipse ell2 = new DrawFunctionLib.DrawFunction3DPart.FillEllipse(DrawTools,
                        Brushes.Green, Centre2, 10, 10);
                    DrawTools.DrawPartListFunction.Add(ell2);
                }*/

                //Pen pen = new Pen(Color.DarkBlue);
                //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                //pen.Width = 2;
                //DrawFunctionLib.DrawFunction3DPart.DrawLine line = new DrawFunctionLib.DrawFunction3DPart.DrawLine(DrawTools,
                //    pen,
                //    Centre,
                //    new DrawFunctionLib.DrawFunction3D.PointF3D(Centre.X, Centre.Y, (float)DrawTools.DrawRangeZ.Min));
                //DrawTools.DrawPartListFunction.Add(line);


                //差值==========================================================================
                for (int i = 0; i < Head.Triangles.Length; i++)
                {
                    int[] triangle = Head.Triangles[i];

                    DrawFunctionLib.DrawFunction3D.PointF3D[] points = new DrawFunctionLib.DrawFunction3D.PointF3D[3];
                    points[0] = Head.Data3D[triangle[0]];
                    points[1] = Head.Data3D[triangle[1]];
                    points[2] = Head.Data3D[triangle[2]];

                    float[] pressures = new float[3];
                    pressures[0] = Pressure.PressureV2[triangle[0]];
                    pressures[1] = Pressure.PressureV2[triangle[1]];
                    pressures[2] = Pressure.PressureV2[triangle[2]];

                    Interp(points, pressures, PressureMin, PressureMax);

                }

                DrawTools.DrawFunction(true);

            }
            catch
            {
                result = false;
            }

            return result;
        }

        protected int[,] colorMap = null;
        /// <summary>
        /// 获得颜色, 根据压力
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pMin"></param>
        /// <param name="pMax"></param>
        /// <returns></returns>
        public Color GetColor(float p, float pMin, float pMax)
        {
            p = p >= pMin ? p : pMin;
            p = p <= pMax ? p : pMax;
            int colorLength = colorMap.GetLength(0);
            int cindex = (int)Math.Round((colorLength * (p - pMin) +
                        (pMax - p)) / (pMax - pMin));
            if (cindex < 1)
                cindex = 1;
            if (cindex > colorLength)
                cindex = colorLength;
            Color color = Color.FromArgb((int)(colorMap[cindex - 1, 0] * 0.9),
                colorMap[cindex - 1, 1], colorMap[cindex - 1, 2],
                colorMap[cindex - 1, 3]);
            return color;
        }

        /// <summary>
        /// 差值
        /// </summary>
        /// <param name="points"></param>
        /// <param name="pressures"></param>
        /// <param name="pMin"></param>
        /// <param name="pMax"></param>
        protected void Interp(DrawFunctionLib.DrawFunction3D.PointF3D[] points, float[] pressures, float pMin, float pMax)
        {
            sump = 0f;
            DrawFunctionLib.DrawFunction3D.PointF3D[][] pts = new DrawFunctionLib.DrawFunction3D.PointF3D[IntperNumber + 1][];
            float[][] ps = new float[IntperNumber + 1][];
            for (int i = 0; i < pressures.Length; i++)
            {
                pressures[i] = pressures[i] <40 ? 0 : pressures[i];
            }



            float x0 = points[0].X;
            float y0 = points[0].Y;
            float z0 = points[0].Z;
            float dx1 = (points[1].X - x0) / IntperNumber;
            float dy1 = (points[1].Y - y0) / IntperNumber;
            float dz1 = (points[1].Z - z0) / IntperNumber;

            float dx2 = (points[2].X - x0) / IntperNumber;
            float dy2 = (points[2].Y - y0) / IntperNumber;
            float dz2 = (points[2].Z - z0) / IntperNumber;

            float p0 = interpEncode(pressures[0]);
            float dp1 = (interpEncode(pressures[1]) - p0);
            float dp2 = (interpEncode(pressures[2]) - p0);
            Color color;
            for (int i = 0; i <= IntperNumber; i++)
            {
                pts[i] = new DrawFunctionLib.DrawFunction3D.PointF3D[i + 1];
                ps[i] = new float[i + 1];

                float x1 = x0 + dx1 * i;
                float y1 = y0 + dy1 * i;
                float z1 = z0 + dz1 * i;

                float x2 = x0 + dx2 * i;
                float y2 = y0 + dy2 * i;
                float z2 = z0 + dz2 * i;

                float p1 = floatInterp2(pressures[0],pressures[1],IntperNumber,i);
                float p2 = floatInterp2(pressures[0], pressures[2], IntperNumber, i);

                for (int j = 0; j <= i; j++)
                {
                    pts[i][j] = new DrawFunctionLib.DrawFunction3D.PointF3D(
                        floatInterp(x1, x2, i, j),
                        floatInterp(y1, y2, i, j),
                        floatInterp(z1, z2, i, j));
                    ps[i][j] = floatInterp2(p1, p2, i, j);
                }
            }

            for (int i = 0; i < IntperNumber; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    {

                        float pMa = MathF.Max(ps[i][j], MathF.Max(ps[i + 1][j], ps[i + 1][j + 1]));
                        float pMi = MathF.Min(ps[i][j], MathF.Min(ps[i + 1][j], ps[i + 1][j + 1]));
                        float p = (pMa + pMi) / 2;
                        color = GetColor(interpDecode(p), pMin, pMax);
                        if (color.Equals(Color.FromArgb(229, 0, 15, 255))) color = Color.Transparent;//如果为蓝色 修改成透明 新增
                        SolidBrush brush = new SolidBrush(color);
                        DrawFunctionLib.DrawFunction3DPart.FillPolygon part =
                            new DrawFunctionLib.DrawFunction3DPart.FillPolygon(DrawTools, brush,
                                new DrawFunctionLib.DrawFunction3D.PointF3D[] { pts[i][j], pts[i + 1][j], pts[i + 1][j + 1] });
                        DrawTools.DrawPartListFunction.Add(part);
                    }

                    if (j < i)
                    {
                        float pMa = MathF.Max(ps[i][j], MathF.Max(ps[i][j + 1], ps[i + 1][j + 1]));
                        float pMi = MathF.Min(ps[i][j], MathF.Min(ps[i][j + 1], ps[i + 1][j + 1]));
                        float p = (pMa+pMi) / 2;
                        color = GetColor(interpDecode(p), pMin, pMax);
                        if (color.Equals(Color.FromArgb(229, 0, 15, 255))) color = Color.Transparent;//如果为蓝色 修改成透明 新增
                        SolidBrush brush = new SolidBrush(color);
                        DrawFunctionLib.DrawFunction3DPart.FillPolygon part =
                            new DrawFunctionLib.DrawFunction3DPart.FillPolygon(DrawTools, brush,
                                new DrawFunctionLib.DrawFunction3D.PointF3D[] { pts[i][j], pts[i][j + 1], pts[i + 1][j + 1] });
                        DrawTools.DrawPartListFunction.Add(part);
                    }


                    if (!Draw3DPlot)
                    {
                        pts[i][j].Z = (float)DrawTools.DrawRangeZ.Min;
                        pts[i + 1][j].Z = (float)DrawTools.DrawRangeZ.Min;
                        pts[i + 1][j + 1].Z = (float)DrawTools.DrawRangeZ.Min;
                        if (j < i)
                        {
                            pts[i][j + 1].Z = (float)DrawTools.DrawRangeZ.Min;
                        }
                    }

                }
            }
        }

        private float interpEncode(float v)
        {
            return v;
        }
        private float interpDecode(float v)
        {
            return v;
        }

        private float floatInterp(float start, float end, float count, float id)
        {
            if (count < 0.5)
            {
                return start;
            }
            return start + (end - start) * id / count;
        }

        private float floatInterp2(float start, float end, float count, float id)
        {
            if (count < 0.5)
            {
                return start;
            }
            float id2 = id * id;
            float remain = count - id;
            return floatInterp(start, end, id2 + remain * remain, id2);
        }

        #endregion

    }
}
 