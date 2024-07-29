using DrawFunctionLib.DrawFunction3DPart;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;


namespace DrawFunctionLib.DrawFunction3DModel
{
    public class DrawColumn : DrawBase
    {
        protected DrawColumn.ColumnSettings uColumnSettings;

        public virtual DrawColumn.ColumnSettings DrawColumnSettings
        {
            get
            {
                return this.uColumnSettings;
            }
            set
            {
                this.uColumnSettings = value;
            }
        }

        public override DrawBase.ModelType ModelStyle
        {
            get
            {
                return DrawBase.ModelType.Changed;
            }
        }

        public DrawColumn(DrawFunction3D IndexDrawFunction)
        {
            this.uColumnSettings = new DrawColumn.ColumnSettings();
            this.IndexDrawFunction = IndexDrawFunction;
        }

        protected virtual DrawFunction3D.PointF3D CalColumn(float dxy, float z)
        {
            DrawColumn.ColumnSettings drawColumnSettings = this.DrawColumnSettings;
            return new DrawFunction3D.PointF3D(drawColumnSettings.DrawRadiusX * (float)Math.Cos((double)dxy), drawColumnSettings.DrawRadiusY * (float)Math.Sin((double)dxy), z);
        }

        protected virtual DrawFunction3D.PointF3D CalColumn(float dxy, float rx, float ry, float z)
        {
            DrawColumn.ColumnSettings drawColumnSettings = this.DrawColumnSettings;
            return new DrawFunction3D.PointF3D(rx * (float)Math.Cos((double)dxy), ry * (float)Math.Sin((double)dxy), z);
        }

        public override bool CalcualteModel()
        {
            bool flag = false;
            this.PartList.Clear();
            if (this.IndexDrawFunction != null)
            {
                flag = true;
                DrawColumn.ColumnSettings drawColumnSettings = this.DrawColumnSettings;
                float num1 = (float)drawColumnSettings.RrawRangeDegreeXY.Length / (float)drawColumnSettings.DrawCountDegreeXY;
                float num2 = drawColumnSettings.DrawOffsetZ / (float)drawColumnSettings.DrawCountOffsetZ;
                if (drawColumnSettings.RrawRangeDegreeXY.Length > (double)num1 / 10.0 & drawColumnSettings.DrawCountOffsetZ != 0)
                {
                    if (drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.PointsEllipse)
                    {
                        DrawFunction3D.PointF3D[] PointList1 = new DrawFunction3D.PointF3D[checked(drawColumnSettings.DrawCountDegreeXY * (drawColumnSettings.DrawCountOffsetZ + 1) - 1 + 1)];
                        int index1 = 0;
                        double min1 = drawColumnSettings.RrawRangeDegreeXY.Min;
                        double num3 = drawColumnSettings.RrawRangeDegreeXY.Max - (double)num1 / 10.0;
                        float StepValue1 = num1;
                        float limit1 = (float)num3;
                        float num4 = (float)min1;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num4, limit1, StepValue1))
                        {
                            double num5 = -(double)drawColumnSettings.DrawOffsetZ / 2.0;
                            double num6 = (double)drawColumnSettings.DrawOffsetZ / 2.0 + (double)num2 / 10.0;
                            float StepValue2 = num2;
                            float limit2 = (float)num6;
                            float num7 = (float)num5;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num7, limit2, StepValue2))
                            {
                                PointList1[index1] = this.CalColumn(num4, num7) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint;
                                checked { ++index1; }
                                if (index1 < PointList1.Length)
                                    num7 += StepValue2;
                                else
                                    break;
                            }
                            if (index1 < PointList1.Length)
                                num4 += StepValue1;
                            else
                                break;
                        }
                        if (index1 < PointList1.Length)
                            PointList1 = (DrawFunction3D.PointF3D[])Utils.CopyArray((Array)PointList1, (Array)new DrawFunction3D.PointF3D[checked(index1 - 1 + 1)]);
                        this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillEllipses(this.IndexDrawFunction, drawColumnSettings.DrawBrush, drawColumnSettings.PointsWidth, drawColumnSettings.PointsHeight, PointList1));
                        if (drawColumnSettings.DrawTopCap | drawColumnSettings.DrawBottomCap)
                        {
                            float num5 = drawColumnSettings.DrawRadiusX / (float)drawColumnSettings.DrawCountOffsetZ;
                            DrawFunction3D.PointF3D[] PointList2 = new DrawFunction3D.PointF3D[checked(drawColumnSettings.DrawCountDegreeXY * (drawColumnSettings.DrawCountOffsetZ + 1) - 1 + 1)];
                            DrawFunction3D.PointF3D[] PointList3 = new DrawFunction3D.PointF3D[checked(drawColumnSettings.DrawCountDegreeXY * (drawColumnSettings.DrawCountOffsetZ + 1) - 1 + 1)];
                            int index2 = 0;
                            double min2 = drawColumnSettings.RrawRangeDegreeXY.Min;
                            double num6 = drawColumnSettings.RrawRangeDegreeXY.Max - (double)num1 / 10.0;
                            float StepValue2 = num1;
                            float limit2 = (float)num6;
                            float num7 = (float)min2;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num7, limit2, StepValue2))
                            {
                                double num8 = 0.0;
                                double num9 = (double)drawColumnSettings.DrawRadiusX + (double)num5 / 10.0;
                                float StepValue3 = num5;
                                float limit3 = (float)num9;
                                float num10 = (float)num8;
                                while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num10, limit3, StepValue3))
                                {
                                    PointList2[index2] = this.CalColumn(num7, num10, num10 / drawColumnSettings.DrawRadiusX * drawColumnSettings.DrawRadiusY, drawColumnSettings.DrawOffsetZ / 2f) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint;
                                    PointList3[index2] = this.CalColumn(num7, num10, num10 / drawColumnSettings.DrawRadiusX * drawColumnSettings.DrawRadiusY, (float)(-(double)drawColumnSettings.DrawOffsetZ / 2.0)) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint;
                                    checked { ++index2; }
                                    if (index2 < PointList2.Length)
                                        num10 += StepValue3;
                                    else
                                        break;
                                }
                                if (index2 < PointList2.Length)
                                    num7 += StepValue2;
                                else
                                    break;
                            }
                            if (index2 < PointList2.Length)
                            {
                                PointList2 = (DrawFunction3D.PointF3D[])Utils.CopyArray((Array)PointList2, (Array)new DrawFunction3D.PointF3D[checked(index2 - 1 + 1)]);
                                PointList3 = (DrawFunction3D.PointF3D[])Utils.CopyArray((Array)PointList3, (Array)new DrawFunction3D.PointF3D[checked(index2 - 1 + 1)]);
                            }
                            if (drawColumnSettings.DrawTopCap)
                                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillEllipses(this.IndexDrawFunction, drawColumnSettings.DrawBrush, drawColumnSettings.PointsWidth, drawColumnSettings.PointsHeight, PointList2));
                            if (drawColumnSettings.DrawBottomCap)
                                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillEllipses(this.IndexDrawFunction, drawColumnSettings.DrawBrush, drawColumnSettings.PointsWidth, drawColumnSettings.PointsHeight, PointList3));
                        }
                    }
                    else if (drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.PointsRectangle)
                    {
                        DrawFunction3D.PointF3D[] PointList1 = new DrawFunction3D.PointF3D[checked(drawColumnSettings.DrawCountDegreeXY * (drawColumnSettings.DrawCountOffsetZ + 1) - 1 + 1)];
                        int index1 = 0;
                        double min1 = drawColumnSettings.RrawRangeDegreeXY.Min;
                        double num3 = drawColumnSettings.RrawRangeDegreeXY.Max - (double)num1 / 10.0;
                        float StepValue1 = num1;
                        float limit1 = (float)num3;
                        float num4 = (float)min1;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num4, limit1, StepValue1))
                        {
                            double num5 = -(double)drawColumnSettings.DrawOffsetZ / 2.0;
                            double num6 = (double)drawColumnSettings.DrawOffsetZ / 2.0 + (double)num2 / 10.0;
                            float StepValue2 = num2;
                            float limit2 = (float)num6;
                            float num7 = (float)num5;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num7, limit2, StepValue2))
                            {
                                PointList1[index1] = this.CalColumn(num4, num7) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint;
                                checked { ++index1; }
                                if (index1 < PointList1.Length)
                                    num7 += StepValue2;
                                else
                                    break;
                            }
                            if (index1 < PointList1.Length)
                                num4 += StepValue1;
                            else
                                break;
                        }
                        if (index1 < PointList1.Length)
                            PointList1 = (DrawFunction3D.PointF3D[])Utils.CopyArray((Array)PointList1, (Array)new DrawFunction3D.PointF3D[checked(index1 - 1 + 1)]);
                        this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillRectangles(this.IndexDrawFunction, drawColumnSettings.DrawBrush, drawColumnSettings.PointsWidth, drawColumnSettings.PointsHeight, PointList1));
                        if (drawColumnSettings.DrawTopCap | drawColumnSettings.DrawBottomCap)
                        {
                            float num5 = drawColumnSettings.DrawRadiusX / (float)drawColumnSettings.DrawCountOffsetZ;
                            DrawFunction3D.PointF3D[] PointList2 = new DrawFunction3D.PointF3D[checked(drawColumnSettings.DrawCountDegreeXY * (drawColumnSettings.DrawCountOffsetZ + 1) - 1 + 1)];
                            DrawFunction3D.PointF3D[] PointList3 = new DrawFunction3D.PointF3D[checked(drawColumnSettings.DrawCountDegreeXY * (drawColumnSettings.DrawCountOffsetZ + 1) - 1 + 1)];
                            int index2 = 0;
                            double min2 = drawColumnSettings.RrawRangeDegreeXY.Min;
                            double num6 = drawColumnSettings.RrawRangeDegreeXY.Max - (double)num1 / 10.0;
                            float StepValue2 = num1;
                            float limit2 = (float)num6;
                            float num7 = (float)min2;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num7, limit2, StepValue2))
                            {
                                double num8 = 0.0;
                                double num9 = (double)drawColumnSettings.DrawRadiusX + (double)num5 / 10.0;
                                float StepValue3 = num5;
                                float limit3 = (float)num9;
                                float num10 = (float)num8;
                                while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num10, limit3, StepValue3))
                                {
                                    PointList2[index2] = this.CalColumn(num7, num10, num10 / drawColumnSettings.DrawRadiusX * drawColumnSettings.DrawRadiusY, drawColumnSettings.DrawOffsetZ / 2f) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint;
                                    PointList3[index2] = this.CalColumn(num7, num10, num10 / drawColumnSettings.DrawRadiusX * drawColumnSettings.DrawRadiusY, (float)(-(double)drawColumnSettings.DrawOffsetZ / 2.0)) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint;
                                    checked { ++index2; }
                                    if (index2 < PointList2.Length)
                                        num10 += StepValue3;
                                    else
                                        break;
                                }
                                if (index2 < PointList2.Length)
                                    num7 += StepValue2;
                                else
                                    break;
                            }
                            if (index2 < PointList2.Length)
                            {
                                PointList2 = (DrawFunction3D.PointF3D[])Utils.CopyArray((Array)PointList2, (Array)new DrawFunction3D.PointF3D[checked(index2 - 1 + 1)]);
                                PointList3 = (DrawFunction3D.PointF3D[])Utils.CopyArray((Array)PointList3, (Array)new DrawFunction3D.PointF3D[checked(index2 - 1 + 1)]);
                            }
                            if (drawColumnSettings.DrawTopCap)
                                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillRectangles(this.IndexDrawFunction, drawColumnSettings.DrawBrush, drawColumnSettings.PointsWidth, drawColumnSettings.PointsHeight, PointList2));
                            if (drawColumnSettings.DrawBottomCap)
                                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillRectangles(this.IndexDrawFunction, drawColumnSettings.DrawBrush, drawColumnSettings.PointsWidth, drawColumnSettings.PointsHeight, PointList3));
                        }
                    }
                    else
                    {
                        DrawFunction3D.PointF3D[] PointList1 = new DrawFunction3D.PointF3D[checked(drawColumnSettings.DrawCountDegreeXY + 1)];
                        DrawFunction3D.PointF3D[] PointList2 = new DrawFunction3D.PointF3D[checked(drawColumnSettings.DrawCountDegreeXY + 1)];
                        int index = 0;
                        double min = drawColumnSettings.RrawRangeDegreeXY.Min;
                        double num3 = drawColumnSettings.RrawRangeDegreeXY.Max - (double)num1 / 10.0;
                        float StepValue1 = num1;
                        float limit1 = (float)num3;
                        float num4 = (float)min;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num4, limit1, StepValue1))
                        {
                            if (index < PointList1.Length)
                            {
                                PointList1[index] = this.CalColumn(num4, drawColumnSettings.DrawOffsetZ / 2f) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint;
                                PointList2[index] = this.CalColumn(num4, (float)(-(double)drawColumnSettings.DrawOffsetZ / 2.0)) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint;
                            }
                            checked { ++index; }
                            double num5 = -(double)drawColumnSettings.DrawOffsetZ / 2.0;
                            double num6 = (double)drawColumnSettings.DrawOffsetZ / 2.0 - (double)num2 / 10.0;
                            float StepValue2 = num2;
                            float limit2 = (float)num6;
                            float num7 = (float)num5;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num7, limit2, StepValue2))
                            {
                                if (drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.Fill | drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.FillAndLines)
                                    this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillPolygon(this.IndexDrawFunction, drawColumnSettings.DrawBrush, new DrawFunction3D.PointF3D[4]
                                    {
                    this.CalColumn(num4, num7) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint,
                    this.CalColumn(num4, num7 + num2) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint,
                    this.CalColumn(num4 + num1, num7 + num2) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint,
                    this.CalColumn(num4 + num1, num7) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint
                                    }));
                                if (drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.Lines | drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.FillAndLines)
                                    this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new DrawPolygon(this.IndexDrawFunction, drawColumnSettings.DrawPen, new DrawFunction3D.PointF3D[4]
                                    {
                    this.CalColumn(num4, num7) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint,
                    this.CalColumn(num4, num7 + num2) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint,
                    this.CalColumn(num4 + num1, num7 + num2) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint,
                    this.CalColumn(num4 + num1, num7) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint
                                    }));
                                num7 += StepValue2;
                            }
                            num4 += StepValue1;
                        }
                        PointList1[index] = this.CalColumn((float)drawColumnSettings.RrawRangeDegreeXY.Max, drawColumnSettings.DrawOffsetZ / 2f) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint;
                        PointList2[index] = this.CalColumn((float)drawColumnSettings.RrawRangeDegreeXY.Max, (float)(-(double)drawColumnSettings.DrawOffsetZ / 2.0)) * drawColumnSettings.TurnMatrix + drawColumnSettings.BasePoint;
                        int num8 = checked(index + 1);
                        if (num8 < PointList1.Length)
                        {
                            PointList1 = (DrawFunction3D.PointF3D[])Utils.CopyArray((Array)PointList1, (Array)new DrawFunction3D.PointF3D[checked(num8 - 1 + 1)]);
                            PointList2 = (DrawFunction3D.PointF3D[])Utils.CopyArray((Array)PointList2, (Array)new DrawFunction3D.PointF3D[checked(num8 - 1 + 1)]);
                        }
                        if (drawColumnSettings.DrawTopCap)
                        {
                            if (drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.Fill | drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.FillAndLines)
                                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillPolygon(this.IndexDrawFunction, drawColumnSettings.DrawBrush, PointList1));
                            if (drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.Lines | drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.FillAndLines)
                                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new DrawPolygon(this.IndexDrawFunction, drawColumnSettings.DrawPen, PointList1));
                        }
                        if (drawColumnSettings.DrawBottomCap)
                        {
                            if (drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.Fill | drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.FillAndLines)
                                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillPolygon(this.IndexDrawFunction, drawColumnSettings.DrawBrush, PointList2));
                            if (drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.Lines | drawColumnSettings.FillStyle == DrawColumn.ColumnSettings.FillType.FillAndLines)
                                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new DrawPolygon(this.IndexDrawFunction, drawColumnSettings.DrawPen, PointList2));
                        }
                    }
                }
            }
            return flag;
        }

        public class ColumnSettings
        {
            protected DrawColumn.ColumnSettings.FillType enum_FillStyle;
            protected DrawFunction3D.PointF3D p_BasePoint;
            protected DrawFunction3D.ShadowMatrix matrix_TurnMatrix;
            protected bool b_DrawTopCap;
            protected bool b_DrawBottomCap;
            protected int i_DrawCountDegreeXY;
            protected int i_DrawCountOffsetZ;
            protected DrawFunction3D.DrawRange range_RrawRangeDegreeXY;
            protected float f_DrawRadiusX;
            protected float f_DrawRadiusY;
            protected float f_DrawOffsetZ;
            protected Pen pen_DrawPen;
            protected Brush brush_DrawBrush;
            protected float f_PointsWidth;
            protected float f_PointsHeight;

            public virtual DrawColumn.ColumnSettings.FillType FillStyle
            {
                get
                {
                    return this.enum_FillStyle;
                }
                set
                {
                    this.enum_FillStyle = value;
                }
            }

            public virtual DrawFunction3D.PointF3D BasePoint
            {
                get
                {
                    return this.p_BasePoint;
                }
                set
                {
                    this.p_BasePoint = value;
                }
            }

            public virtual DrawFunction3D.ShadowMatrix TurnMatrix
            {
                get
                {
                    return this.matrix_TurnMatrix;
                }
                set
                {
                    this.matrix_TurnMatrix = value;
                }
            }

            public virtual bool DrawTopCap
            {
                get
                {
                    return this.b_DrawTopCap;
                }
                set
                {
                    this.b_DrawTopCap = value;
                }
            }

            public virtual bool DrawBottomCap
            {
                get
                {
                    return this.b_DrawBottomCap;
                }
                set
                {
                    this.b_DrawBottomCap = value;
                }
            }

            public virtual int DrawCountDegreeXY
            {
                get
                {
                    return this.i_DrawCountDegreeXY;
                }
                set
                {
                    if (value < 1)
                        value = 1;
                    this.i_DrawCountDegreeXY = value;
                }
            }

            public virtual int DrawCountOffsetZ
            {
                get
                {
                    return this.i_DrawCountOffsetZ;
                }
                set
                {
                    if (value < 1)
                        value = 1;
                    this.i_DrawCountOffsetZ = value;
                }
            }

            public virtual DrawFunction3D.DrawRange RrawRangeDegreeXY
            {
                get
                {
                    return this.range_RrawRangeDegreeXY;
                }
                set
                {
                    this.range_RrawRangeDegreeXY = value;
                }
            }

            public virtual float DrawRadiusX
            {
                get
                {
                    return this.f_DrawRadiusX;
                }
                set
                {
                    this.f_DrawRadiusX = value;
                }
            }

            public virtual float DrawRadiusY
            {
                get
                {
                    return this.f_DrawRadiusY;
                }
                set
                {
                    this.f_DrawRadiusY = value;
                }
            }

            public virtual float DrawOffsetZ
            {
                get
                {
                    return this.f_DrawOffsetZ;
                }
                set
                {
                    this.f_DrawOffsetZ = value;
                }
            }

            public virtual Pen DrawPen
            {
                get
                {
                    return this.pen_DrawPen;
                }
                set
                {
                    this.pen_DrawPen = value;
                }
            }

            public virtual Brush DrawBrush
            {
                get
                {
                    return this.brush_DrawBrush;
                }
                set
                {
                    this.brush_DrawBrush = value;
                }
            }

            public virtual float PointsWidth
            {
                get
                {
                    return this.f_PointsWidth;
                }
                set
                {
                    this.f_PointsWidth = value;
                }
            }

            public virtual float PointsHeight
            {
                get
                {
                    return this.f_PointsHeight;
                }
                set
                {
                    this.f_PointsHeight = value;
                }
            }

            public ColumnSettings()
            {
                this.enum_FillStyle = DrawColumn.ColumnSettings.FillType.FillAndLines;
                this.p_BasePoint = new DrawFunction3D.PointF3D();
                this.matrix_TurnMatrix = new DrawFunction3D.ShadowMatrix();
                this.b_DrawTopCap = true;
                this.b_DrawBottomCap = true;
                this.i_DrawCountDegreeXY = 20;
                this.i_DrawCountOffsetZ = 10;
                this.range_RrawRangeDegreeXY = new DrawFunction3D.DrawRange(0.0, 2.0 * Math.PI);
                this.f_DrawRadiusX = 0.5f;
                this.f_DrawRadiusY = 0.5f;
                this.f_DrawOffsetZ = 0.5f;
                this.pen_DrawPen = Pens.Black;
                this.brush_DrawBrush = (Brush)new SolidBrush(Color.FromArgb(100, Color.Blue));
                this.f_PointsWidth = 5f;
                this.f_PointsHeight = 5f;
            }

            public enum FillType
            {
                Lines,
                Fill,
                FillAndLines,
                PointsRectangle,
                PointsEllipse,
            }
        }
    }
}
