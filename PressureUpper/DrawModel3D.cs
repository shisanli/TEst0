using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PressureUpper
{
    public class DrawModel3D
    {
        /***********************************
         * 参数区
         ***********************************/
        #region 参数区 
        /// <summary>
        /// 差值数量
        /// </summary>
        public int IntperNumber = 6;

        /// <summary>
        /// 色标最小压力
        /// </summary>
        public const int PressureMin = 0;
        /// <summary>
        /// 色标最大压力 //最小是50
        /// </summary>
        //public const int PressureMax = 5000;
        public const int PressureMax = 10000;

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

        public HeadModel Head = new HeadModel();
        public PressureModel Pressure = new PressureModel();
        public DrawFunctionLib.DrawFunction3D DrawTools = new DrawFunctionLib.DrawFunction3D(800, 800){ TurnMatrix = DrawFunctionLib.DrawFunction3D.ShadowMatrix.FromTurning(0, 0, 180 * DEG2RAD) };
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
                colorMap = ColorMap.FallRdGr();

                if (Head.Data3D != null && Pressure != null)
                {
                    float xMin = -1;
                    float xMax = -1;
                    float yMin = -1;
                    float yMax = -1;
                    float zMin = -1;
                    float zMax = -1;

                    for (int i = 0; i < Head.RowCount; i++)
                    {
                        for (int j = 0; j < Head.ColCount; j++)
                        {
                            float x = Head.Data3D[i, j].X;
                            float y = Head.Data3D[i, j].Y;
                            float z = Head.Data3D[i, j].Z;

                            if (x < 0 || y < 0 || z < 0) continue;

                            if (x < xMin || xMin == -1) xMin = x;
                            if (x > xMax || xMax == -1) xMax = x;
                            if (y < yMin || yMin == -1) yMin = y;
                            if (y > yMax || yMax == -1) yMax = y;
                            if (z < zMin || zMin == -1) zMin = z;
                            if (z > zMax || zMax == -1) zMax = z;
                        }
                    }

                    DrawTools.DrawRangeX.SetRange(xMin - 10, xMax + 10);
                    DrawTools.DrawRangeY.SetRange(yMin - 10, yMax + 10);
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
                DrawTools.DrawPartListFunction.Clear();
                if (Head.RowCount != Pressure.RowCount ||
                     Head.ColCount != Pressure.ColCount)
                {
                    //错误
                }
                else
                { 
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
                    for (int i = 0; i < Head.RowCount - 1; i++)
                    {
                        for (int j = 0; j < Head.ColCount - 1; j++)
                        {
                            DrawFunctionLib.DrawFunction3D.PointF3D[] points = new DrawFunctionLib.DrawFunction3D.PointF3D[4];
                            points[0] = Head.Data3D[i, j];
                            points[1] = Head.Data3D[i, j + 1];
                            points[2] = Head.Data3D[i + 1, j + 1];
                            points[3] = Head.Data3D[i + 1, j];

                            float[] pressures = new float[4];
                            pressures[0] = Pressure.Pressure[i, j];
                            pressures[1] = Pressure.Pressure[i, j + 1];
                            pressures[2] = Pressure.Pressure[i + 1, j + 1];
                            pressures[3] = Pressure.Pressure[i + 1, j];

                            Interp(points, pressures, PressureMin, PressureMax);
                        }
                    }
                    //Pen pen1 = new Pen(Color.Black, 5);
                    //DrawFunctionLib.DrawFunction3D.PointF3D[] pointList = new DrawFunctionLib.DrawFunction3D.PointF3D[360];
                    //for (int i = 0; i < 360; i++)
                    //{
                    //    pointList[i] = new DrawFunctionLib.DrawFunction3D.PointF3D((float)(97 + 10 * Math.Cos(i / 180f * Math.PI)), (float)(90 + 10 * Math.Sin(i / 180f * Math.PI)), 1f);
                    //}
                    //DrawFunctionLib.DrawFunction3DPart.DrawClosedCurve cur = new DrawFunctionLib.DrawFunction3DPart.DrawClosedCurve(DrawTools, pen1, Head.xiedian);
                    //DrawTools.DrawPartListFunction.Add(cur);
                }
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
            bool result = false; ;

            try
            {
                DrawTools.DrawPartListFunction.Clear();
                if (Head.RowCount != Pressure.RowCount ||
                     Head.ColCount != Pressure.ColCount)
                {
                    //错误
                }
                else
                {
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

                    //Pen pen = new Pen(Color.DarkBlue);
                    //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    //pen.Width = 2;
                    //DrawFunctionLib.DrawFunction3DPart.DrawLine line = new DrawFunctionLib.DrawFunction3DPart.DrawLine(DrawTools,
                    //    pen,
                    //    Centre,
                    //    new DrawFunctionLib.DrawFunction3D.PointF3D(Centre.X, Centre.Y, (float)DrawTools.DrawRangeZ.Min));
                    //DrawTools.DrawPartListFunction.Add(line);
                   

                    //差值==========================================================================
                    for (int i = 0; i < Head.RowCount - 1; i++)
                    {
                        for (int j = 0; j < Head.ColCount - 1; j++)
                        {
                            DrawFunctionLib.DrawFunction3D.PointF3D[] points = new DrawFunctionLib.DrawFunction3D.PointF3D[4];
                            points[0] = Head.Data3D[i, j];
                            points[1] = Head.Data3D[i, j + 1];
                            points[2] = Head.Data3D[i + 1, j + 1];
                            points[3] = Head.Data3D[i + 1, j];

                            float[] pressures = new float[4];
                            pressures[0] = Pressure.Pressure[i, j];
                            pressures[1] = Pressure.Pressure[i, j + 1];
                            pressures[2] = Pressure.Pressure[i + 1, j + 1];
                            pressures[3] = Pressure.Pressure[i + 1, j];

                            Interp(points, pressures, PressureMin, PressureMax);
                        }
                    }
                   


                   
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
            DrawFunctionLib.DrawFunction3D.PointF3D[,] pts = new DrawFunctionLib.DrawFunction3D.PointF3D[IntperNumber + 1, IntperNumber + 1];
            float[,] ps = new float[IntperNumber + 1, IntperNumber + 1];

            //bool outOfXiedian = false;

            int errorPoint = 0;
            int errorIndex = -1;
            for (int k = 0; k < points.Length; k++)
            {
                if (points[k].X < 0 || points[k].Y < 0 || points[k].Z < 0)
                {
                    errorPoint++;
                    errorIndex = k;
                    if (errorPoint > 1) break;
                }
            }

            //for (int k = 0; k < points.Length; k++)
            //{
            //    if (!Head.xiedianContains(points[k]))
            //    {
            //        outOfXiedian = true;
            //        break;
            //    }
            //}


            if (errorPoint == 0)
            {
                float x0 = points[0].X;
                float y0 = points[0].Y;
                float x1 = points[2].X;
                float y1 = points[2].Y;
                float dx = (x1 - x0) / IntperNumber;
                float dy = (y1 - y0) / IntperNumber;
                float[] Cs = new float[] { points[0].Z, points[1].Z, points[2].Z, points[3].Z };
                float[] Ps = new float[] { pressures[0], pressures[1], pressures[2], pressures[3] };
                float x, y, C, P;
                Color color;
                for (int i = 0; i <= IntperNumber; i++)
                {
                    x = x0 + i * dx;
                    for (int j = 0; j <= IntperNumber; j++)
                    {
                        y = y0 + j * dy;

                        C = (y1 - y) * ((x1 - x) * Cs[0] + (x - x0) * Cs[1]) / (x1 - x0) / (y1 - y0) + (y - y0) * ((x1 - x) * Cs[3] + (x - x0) * Cs[2]) / (x1 - x0) / (y1 - y0);
                        P = (y1 - y) * ((x1 - x) * Ps[0] + (x - x0) * Ps[1]) / (x1 - x0) / (y1 - y0)
                            + (y - y0) * ((x1 - x) * Ps[3] + (x - x0) * Ps[2]) / (x1 - x0) / (y1 - y0);

                        pts[i, j] = new DrawFunctionLib.DrawFunction3D.PointF3D(x, y, C);
                        ps[i, j] = P;
                    }
                }
                
                for (int i = 0; i < IntperNumber; i++)
                {
                    for (int j = 0; j < IntperNumber; j++)
                    {
                        float p = (ps[i, j] + ps[i, j + 1] + ps[i + 1, j + 1] + ps[i + 1, j]) / 4;
                        color = GetColor(p, pMin, pMax);
                        if (color.Equals(Color.FromArgb(229, 0, 15, 255))) color = Color.Transparent;//如果为蓝色 修改成透明 新增
                        SolidBrush brush = new SolidBrush(color);

                       

                        DrawFunctionLib.DrawFunction3DPart.FillPolygon part =
                            new DrawFunctionLib.DrawFunction3DPart.FillPolygon(DrawTools, brush,
                                new DrawFunctionLib.DrawFunction3D.PointF3D[] { pts[i, j], pts[i, j + 1], pts[i + 1, j + 1], pts[i + 1, j] });
                        DrawTools.DrawPartListFunction.Add(part);

                        if (!Draw3DPlot)
                        {
                            pts[i, j].Z = (float)DrawTools.DrawRangeZ.Min;
                            pts[i, j + 1].Z = (float)DrawTools.DrawRangeZ.Min;
                            pts[i + 1, j + 1].Z = (float)DrawTools.DrawRangeZ.Min;
                            pts[i + 1, j].Z = (float)DrawTools.DrawRangeZ.Min;
                        }

                    }
                }
            }
            else if (errorPoint == 1)
            {
                //errorIndex 无效点
                DrawFunctionLib.DrawFunction3D.PointF3D[] triPoints = new DrawFunctionLib.DrawFunction3D.PointF3D[3];
                float[] triPressure = new float[3];
                {
                    int tempi = 0;
                    for (int k = 0; k < points.Length; k++)
                    {
                        if (k != errorIndex)
                        {
                            triPoints[tempi] = points[k];
                            triPressure[tempi] = pressures[k];
                            tempi++;
                        }
                    }
                }

                float x0 = Math.Min(Math.Min(triPoints[0].X, triPoints[1].X), triPoints[2].X);
                float y0 = Math.Min(Math.Min(triPoints[0].Y, triPoints[1].Y), triPoints[2].Y);
                float x1 = Math.Max(Math.Max(triPoints[0].X, triPoints[1].X), triPoints[2].X);
                float y1 = Math.Max(Math.Max(triPoints[0].Y, triPoints[1].Y), triPoints[2].Y);
                float dx = (x1 - x0) / IntperNumber;
                float dy = (y1 - y0) / IntperNumber;
                float x, y, C, P;

                DrawFunctionLib.DrawFunction3D.PointF3D v0 =
                    new DrawFunctionLib.DrawFunction3D.PointF3D(
                        triPoints[2].X - triPoints[0].X,
                        triPoints[2].Y - triPoints[0].Y,
                        triPoints[2].Z - triPoints[0].Z);
                DrawFunctionLib.DrawFunction3D.PointF3D v0p =
                    new DrawFunctionLib.DrawFunction3D.PointF3D(
                        triPoints[2].X - triPoints[0].X,
                        triPoints[2].Y - triPoints[0].Y,
                        triPressure[2] - triPressure[0]);

                DrawFunctionLib.DrawFunction3D.PointF3D v1 =
                    new DrawFunctionLib.DrawFunction3D.PointF3D(
                        triPoints[1].X - triPoints[0].X,
                        triPoints[1].Y - triPoints[0].Y,
                        triPoints[1].Z - triPoints[0].Z);
                DrawFunctionLib.DrawFunction3D.PointF3D v1p =
                    new DrawFunctionLib.DrawFunction3D.PointF3D(
                        triPoints[1].X - triPoints[0].X,
                        triPoints[1].Y - triPoints[0].Y,
                        triPressure[1] - triPressure[0]);

                DrawFunctionLib.DrawFunction3D.PointF3D n =
                    new DrawFunctionLib.DrawFunction3D.PointF3D(
                        v0.Y * v1.Z - v0.Z * v1.Y,
                        v0.Z * v1.X - v0.X * v1.Z,
                        v0.X * v1.Y - v0.Y * v1.X);
                DrawFunctionLib.DrawFunction3D.PointF3D np =
                    new DrawFunctionLib.DrawFunction3D.PointF3D(
                        v0p.Y * v1p.Z - v0p.Z * v1p.Y,
                        v0p.Z * v1.X - v0p.X * v1p.Z,
                        v0p.X * v1.Y - v0p.Y * v1p.X);

                if (n.Z != 0 && np.Z != 0)
                {
                    for (int i = 0; i <= IntperNumber; i++)
                    {
                        x = x0 + i * dx;
                        for (int j = 0; j <= IntperNumber; j++)
                        {
                            y = y0 + j * dy;

                            C = triPoints[0].Z - (n.X * (x - triPoints[0].X) + n.Y * (y - triPoints[0].Y)) / n.Z;
                            P = triPressure[0] - (np.X * (x - triPoints[0].X) + np.Y * (y - triPoints[0].Y)) / np.Z;

                            pts[i, j] = new DrawFunctionLib.DrawFunction3D.PointF3D(x, y, C);
                            ps[i, j] = P;
                        }
                    }

                    for (int i = 0; i < IntperNumber; i++)
                    {
                        for (int j = 0; j < IntperNumber; j++)
                        {
                            List<DrawFunctionLib.DrawFunction3D.PointF3D> list = new List<DrawFunctionLib.DrawFunction3D.PointF3D>(5);
                            float p = 0;
                            if (pts[i, j].Z >= -0.0001)
                            {
                                list.Add(pts[i, j]);
                                p += ps[i, j];
                            }
                            if (pts[i, j + 1].Z >= -0.0001)
                            {
                                list.Add(pts[i, j + 1]);
                                p += ps[i, j + 1];
                            }
                            if (pts[i + 1, j + 1].Z >= -0.0001)
                            {
                                list.Add(pts[i + 1, j + 1]);
                                p += ps[i + 1, j + 1];
                            }
                            if (pts[i + 1, j].Z >= -0.0001)
                            {
                                list.Add(pts[i + 1, j]);
                                p += ps[i + 1, j];
                            }

                            if (list.Count >= 3)
                            {
                                p = p / list.Count;
                                SolidBrush brush = new SolidBrush(GetColor(p, pMin, pMax));

                                DrawFunctionLib.DrawFunction3D.PointF3D[] array = list.ToArray();

                                //if (outOfXiedian)
                                //{
                                //    bool tempOut = true;
                                //    for (int temp = 0; temp < array.Length; temp++)
                                //    {
                                //        if (Head.xiedianContains(array[temp]))
                                //        {
                                //            tempOut = false;
                                //            break;
                                //        }
                                //    }
                                //    if (tempOut) brush = new SolidBrush(Color.Gray);

                                  
                                //}

                                if (!Draw3DPlot)
                                {
                                    for (int temp = 0; temp < array.Length; temp++)
                                    {
                                        array[temp] = new DrawFunctionLib.DrawFunction3D.PointF3D(array[temp].X, array[temp].Y, (float)DrawTools.DrawRangeZ.Min);
                                    }
                                }

                                DrawFunctionLib.DrawFunction3DPart.FillPolygon part =
                                    new DrawFunctionLib.DrawFunction3DPart.FillPolygon(DrawTools, brush,
                                        array);
                                DrawTools.DrawPartListFunction.Add(part);

                                array = null;

                            }

                            list.Clear();
                            list = null;
                        }
                    }
                }
            }

        }

        #endregion

    }
}
