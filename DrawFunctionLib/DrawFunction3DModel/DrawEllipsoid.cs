using DrawFunctionLib.DrawFunction3DPart;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace DrawFunctionLib.DrawFunction3DModel
{
    public class DrawEllipsoid : DrawBase
    {
        protected DrawEllipsoid.EllipsoidSettings uEllipsoidSettings;

        public virtual DrawEllipsoid.EllipsoidSettings DrawEllipsoidSettings
        {
            get
            {
                return this.uEllipsoidSettings;
            }
            set
            {
                this.uEllipsoidSettings = value;
            }
        }

        public override DrawBase.ModelType ModelStyle
        {
            get
            {
                return DrawBase.ModelType.Changed;
            }
        }

        public DrawEllipsoid(DrawFunction3D IndexDrawFunction)
        {
            this.uEllipsoidSettings = new DrawEllipsoid.EllipsoidSettings();
            this.IndexDrawFunction = IndexDrawFunction;
        }

        protected virtual DrawFunction3D.PointF3D CalEllipsoid(float dxy, float dz)
        {
            DrawEllipsoid.EllipsoidSettings ellipsoidSettings = this.DrawEllipsoidSettings;
            return new DrawFunction3D.PointF3D((float)((double)ellipsoidSettings.DrawRadiusX * Math.Cos((double)dxy) * Math.Sin((double)dz)), (float)((double)ellipsoidSettings.DrawRadiusY * Math.Sin((double)dxy) * Math.Sin((double)dz)), ellipsoidSettings.DrawRadiusZ * (float)Math.Cos((double)dz));
        }

        public override bool CalcualteModel()
        {
            bool flag = false;
            this.PartList.Clear();
            if (this.IndexDrawFunction != null)
            {
                flag = true;
                DrawEllipsoid.EllipsoidSettings ellipsoidSettings = this.DrawEllipsoidSettings;
                float num1 = (float)ellipsoidSettings.RrawRangeDegreeXY.Length / (float)ellipsoidSettings.DrawCountDegreeXY;
                float num2 = (float)ellipsoidSettings.RrawRangeDegreeZ.Length / (float)ellipsoidSettings.DrawCountDegreeZ;
                if (ellipsoidSettings.RrawRangeDegreeXY.Length > (double)num1 / 10.0 & ellipsoidSettings.RrawRangeDegreeZ.Length > (double)num2 / 10.0)
                {
                    if (ellipsoidSettings.FillStyle == DrawEllipsoid.EllipsoidSettings.FillType.PointsEllipse)
                    {
                        DrawFunction3D.PointF3D[] PointList = new DrawFunction3D.PointF3D[checked(ellipsoidSettings.DrawCountDegreeXY * ellipsoidSettings.DrawCountDegreeZ - 1 + 1)];
                        int index = 0;
                        double min1 = ellipsoidSettings.RrawRangeDegreeXY.Min;
                        double num3 = ellipsoidSettings.RrawRangeDegreeXY.Max - (double)num1 / 10.0;
                        float StepValue1 = num1;
                        float limit1 = (float)num3;
                        float num4 = (float)min1;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num4, limit1, StepValue1))
                        {
                            double min2 = ellipsoidSettings.RrawRangeDegreeZ.Min;
                            double num5 = ellipsoidSettings.RrawRangeDegreeZ.Max - (double)num2 / 10.0;
                            float StepValue2 = num2;
                            float limit2 = (float)num5;
                            float num6 = (float)min2;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num6, limit2, StepValue2))
                            {
                                PointList[index] = this.CalEllipsoid(num4, num6) * ellipsoidSettings.TurnMatrix + ellipsoidSettings.BasePoint;
                                checked { ++index; }
                                if (index < PointList.Length)
                                    num6 += StepValue2;
                                else
                                    break;
                            }
                            if (index < PointList.Length)
                                num4 += StepValue1;
                            else
                                break;
                        }
                        if (index < PointList.Length)
                            PointList = (DrawFunction3D.PointF3D[])Utils.CopyArray((Array)PointList, (Array)new DrawFunction3D.PointF3D[checked(index - 1 + 1)]);
                        this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillEllipses(this.IndexDrawFunction, ellipsoidSettings.DrawBrush, ellipsoidSettings.PointsWidth, ellipsoidSettings.PointsHeight, PointList));
                    }
                    else if (ellipsoidSettings.FillStyle == DrawEllipsoid.EllipsoidSettings.FillType.PointsRectangle)
                    {
                        DrawFunction3D.PointF3D[] PointList = new DrawFunction3D.PointF3D[checked(ellipsoidSettings.DrawCountDegreeXY * ellipsoidSettings.DrawCountDegreeZ - 1 + 1)];
                        int index = 0;
                        double min1 = ellipsoidSettings.RrawRangeDegreeXY.Min;
                        double num3 = ellipsoidSettings.RrawRangeDegreeXY.Max - (double)num1 / 10.0;
                        float StepValue1 = num1;
                        float limit1 = (float)num3;
                        float num4 = (float)min1;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num4, limit1, StepValue1))
                        {
                            double min2 = ellipsoidSettings.RrawRangeDegreeZ.Min;
                            double num5 = ellipsoidSettings.RrawRangeDegreeZ.Max - (double)num2 / 10.0;
                            float StepValue2 = num2;
                            float limit2 = (float)num5;
                            float num6 = (float)min2;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num6, limit2, StepValue2))
                            {
                                PointList[index] = this.CalEllipsoid(num4, num6) * ellipsoidSettings.TurnMatrix + ellipsoidSettings.BasePoint;
                                checked { ++index; }
                                if (index < PointList.Length)
                                    num6 += StepValue2;
                                else
                                    break;
                            }
                            if (index < PointList.Length)
                                num4 += StepValue1;
                            else
                                break;
                        }
                        if (index < PointList.Length)
                            PointList = (DrawFunction3D.PointF3D[])Utils.CopyArray((Array)PointList, (Array)new DrawFunction3D.PointF3D[checked(index - 1 + 1)]);
                        this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillRectangles(this.IndexDrawFunction, ellipsoidSettings.DrawBrush, ellipsoidSettings.PointsWidth, ellipsoidSettings.PointsHeight, PointList));
                    }
                    else
                    {
                        double min1 = ellipsoidSettings.RrawRangeDegreeXY.Min;
                        double num3 = ellipsoidSettings.RrawRangeDegreeXY.Max - (double)num1 / 10.0;
                        float StepValue1 = num1;
                        float limit1 = (float)num3;
                        float num4 = (float)min1;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num4, limit1, StepValue1))
                        {
                            double min2 = ellipsoidSettings.RrawRangeDegreeZ.Min;
                            double num5 = ellipsoidSettings.RrawRangeDegreeZ.Max - (double)num2 / 10.0;
                            float StepValue2 = num2;
                            float limit2 = (float)num5;
                            float num6 = (float)min2;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num6, limit2, StepValue2))
                            {
                                if (ellipsoidSettings.FillStyle == DrawEllipsoid.EllipsoidSettings.FillType.Fill | ellipsoidSettings.FillStyle == DrawEllipsoid.EllipsoidSettings.FillType.FillAndLines)
                                    this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillPolygon(this.IndexDrawFunction, ellipsoidSettings.DrawBrush, new DrawFunction3D.PointF3D[4]
                                    {
                    this.CalEllipsoid(num4, num6) * ellipsoidSettings.TurnMatrix + ellipsoidSettings.BasePoint,
                    this.CalEllipsoid(num4, num6 + num2) * ellipsoidSettings.TurnMatrix + ellipsoidSettings.BasePoint,
                    this.CalEllipsoid(num4 + num1, num6 + num2) * ellipsoidSettings.TurnMatrix + ellipsoidSettings.BasePoint,
                    this.CalEllipsoid(num4 + num1, num6) * ellipsoidSettings.TurnMatrix + ellipsoidSettings.BasePoint
                                    }));
                                if (ellipsoidSettings.FillStyle == DrawEllipsoid.EllipsoidSettings.FillType.Lines | ellipsoidSettings.FillStyle == DrawEllipsoid.EllipsoidSettings.FillType.FillAndLines)
                                    this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new DrawPolygon(this.IndexDrawFunction, ellipsoidSettings.DrawPen, new DrawFunction3D.PointF3D[4]
                                    {
                    this.CalEllipsoid(num4, num6) * ellipsoidSettings.TurnMatrix + ellipsoidSettings.BasePoint,
                    this.CalEllipsoid(num4, num6 + num2) * ellipsoidSettings.TurnMatrix + ellipsoidSettings.BasePoint,
                    this.CalEllipsoid(num4 + num1, num6 + num2) * ellipsoidSettings.TurnMatrix + ellipsoidSettings.BasePoint,
                    this.CalEllipsoid(num4 + num1, num6) * ellipsoidSettings.TurnMatrix + ellipsoidSettings.BasePoint
                                    }));
                                num6 += StepValue2;
                            }
                            num4 += StepValue1;
                        }
                    }
                }
            }
            return flag;
        }

        public class EllipsoidSettings
        {
            protected DrawEllipsoid.EllipsoidSettings.FillType enum_FillStyle;
            protected DrawFunction3D.PointF3D p_BasePoint;
            protected DrawFunction3D.ShadowMatrix matrix_TurnMatrix;
            protected int i_DrawCountDegreeXY;
            protected int i_DrawCountDegreeZ;
            protected DrawFunction3D.DrawRange range_RrawRangeDegreeXY;
            protected DrawFunction3D.DrawRange range_RrawRangeDegreeZ;
            protected float f_DrawRadiusX;
            protected float f_DrawRadiusY;
            protected float f_DrawRadiusZ;
            protected Pen pen_DrawPen;
            protected Brush brush_DrawBrush;
            protected float f_PointsWidth;
            protected float f_PointsHeight;

            public virtual DrawEllipsoid.EllipsoidSettings.FillType FillStyle
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

            public virtual int DrawCountDegreeZ
            {
                get
                {
                    return this.i_DrawCountDegreeZ;
                }
                set
                {
                    if (value < 1)
                        value = 1;
                    this.i_DrawCountDegreeZ = value;
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

            public virtual DrawFunction3D.DrawRange RrawRangeDegreeZ
            {
                get
                {
                    return this.range_RrawRangeDegreeZ;
                }
                set
                {
                    this.range_RrawRangeDegreeZ = value;
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

            public virtual float DrawRadiusZ
            {
                get
                {
                    return this.f_DrawRadiusZ;
                }
                set
                {
                    this.f_DrawRadiusZ = value;
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

            public EllipsoidSettings()
            {
                this.enum_FillStyle = DrawEllipsoid.EllipsoidSettings.FillType.FillAndLines;
                this.p_BasePoint = new DrawFunction3D.PointF3D();
                this.matrix_TurnMatrix = new DrawFunction3D.ShadowMatrix();
                this.i_DrawCountDegreeXY = 20;
                this.i_DrawCountDegreeZ = 10;
                this.range_RrawRangeDegreeXY = new DrawFunction3D.DrawRange(0.0, 2.0 * Math.PI);
                this.range_RrawRangeDegreeZ = new DrawFunction3D.DrawRange(0.0, Math.PI);
                this.f_DrawRadiusX = 0.5f;
                this.f_DrawRadiusY = 0.5f;
                this.f_DrawRadiusZ = 0.5f;
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
