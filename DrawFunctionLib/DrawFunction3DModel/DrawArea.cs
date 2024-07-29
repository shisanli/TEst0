using DrawFunctionLib.DrawFunction3DPart;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace DrawFunctionLib.DrawFunction3DModel
{
    public class DrawArea : DrawBase
    {
        protected DrawArea.AreaSettings uAreaSettings;
        protected DrawArea.Fun f_AreaFun;

        public virtual DrawArea.AreaSettings DrawAreaSettings
        {
            get
            {
                return this.uAreaSettings;
            }
            set
            {
                this.uAreaSettings = value;
            }
        }

        public virtual DrawArea.Fun AreaFun
        {
            get
            {
                return this.f_AreaFun;
            }
            set
            {
                this.f_AreaFun = value;
            }
        }

        public override DrawBase.ModelType ModelStyle
        {
            get
            {
                return DrawBase.ModelType.Changed;
            }
        }

        public DrawArea(DrawFunction3D IndexDrawFunction, DrawArea.Fun AreaFun)
        {
            this.uAreaSettings = new DrawArea.AreaSettings();
            this.f_AreaFun = (DrawArea.Fun)null;
            this.IndexDrawFunction = IndexDrawFunction;
            this.AreaFun = AreaFun;
        }

        public override bool CalcualteModel()
        {
            bool flag = false;
            this.PartList.Clear();
            if (this.IndexDrawFunction != null & this.AreaFun != null)
            {
                flag = true;
                DrawArea.AreaSettings drawAreaSettings = this.DrawAreaSettings;
                float num1 = (float)drawAreaSettings.DrawRangeArg1.Length / (float)drawAreaSettings.DrawCountArg1;
                float num2 = (float)drawAreaSettings.DrawRangeArg2.Length / (float)drawAreaSettings.DrawCountArg2;
                if (drawAreaSettings.DrawRangeArg1.Length > (double)num1 / 10.0 & drawAreaSettings.DrawRangeArg2.Length > (double)num2 / 10.0)
                {
                    if (drawAreaSettings.FillStyle == DrawArea.AreaSettings.FillType.PointsEllipse)
                    {
                        DrawFunction3D.PointF3D[] PointList = new DrawFunction3D.PointF3D[checked((drawAreaSettings.DrawCountArg1 + 1) * (drawAreaSettings.DrawCountArg2 + 1) - 1 + 1)];
                        int index = 0;
                        double min1 = drawAreaSettings.DrawRangeArg1.Min;
                        double num3 = drawAreaSettings.DrawRangeArg1.Max + (double)num1 / 10.0;
                        float StepValue1 = num1;
                        float limit1 = (float)num3;
                        float num4 = (float)min1;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num4, limit1, StepValue1))
                        {
                            double min2 = drawAreaSettings.DrawRangeArg2.Min;
                            double num5 = drawAreaSettings.DrawRangeArg2.Max + (double)num2 / 10.0;
                            float StepValue2 = num2;
                            float limit2 = (float)num5;
                            float num6 = (float)min2;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num6, limit2, StepValue2))
                            {
                                switch (drawAreaSettings.ArgumentStyle)
                                {
                                    case DrawArea.AreaSettings.ArgumentType.Arg1XArg2Y:
                                        PointList[index] = new DrawFunction3D.PointF3D(num4, num6, this.AreaFun(num4, num6));
                                        break;
                                    case DrawArea.AreaSettings.ArgumentType.Arg1YArg2Z:
                                        PointList[index] = new DrawFunction3D.PointF3D(this.AreaFun(num4, num6), num4, num6);
                                        break;
                                    case DrawArea.AreaSettings.ArgumentType.Arg1XArg2Z:
                                        PointList[index] = new DrawFunction3D.PointF3D(num4, this.AreaFun(num4, num6), num6);
                                        break;
                                    default:
                                        PointList[index] = new DrawFunction3D.PointF3D(num4, num6, this.AreaFun(num4, num6));
                                        break;
                                }
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
                        this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillEllipses(this.IndexDrawFunction, drawAreaSettings.DrawBrush, drawAreaSettings.PointsWidth, drawAreaSettings.PointsHeight, PointList));
                    }
                    else if (drawAreaSettings.FillStyle == DrawArea.AreaSettings.FillType.PointsRectangle)
                    {
                        DrawFunction3D.PointF3D[] PointList = new DrawFunction3D.PointF3D[checked((drawAreaSettings.DrawCountArg1 + 1) * (drawAreaSettings.DrawCountArg2 + 1) - 1 + 1)];
                        int index = 0;
                        double min1 = drawAreaSettings.DrawRangeArg1.Min;
                        double num3 = drawAreaSettings.DrawRangeArg1.Max + (double)num1 / 10.0;
                        float StepValue1 = num1;
                        float limit1 = (float)num3;
                        float num4 = (float)min1;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num4, limit1, StepValue1))
                        {
                            double min2 = drawAreaSettings.DrawRangeArg2.Min;
                            double num5 = drawAreaSettings.DrawRangeArg2.Max + (double)num2 / 10.0;
                            float StepValue2 = num2;
                            float limit2 = (float)num5;
                            float num6 = (float)min2;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num6, limit2, StepValue2))
                            {
                                switch (drawAreaSettings.ArgumentStyle)
                                {
                                    case DrawArea.AreaSettings.ArgumentType.Arg1XArg2Y:
                                        PointList[index] = new DrawFunction3D.PointF3D(num4, num6, this.AreaFun(num4, num6));
                                        break;
                                    case DrawArea.AreaSettings.ArgumentType.Arg1YArg2Z:
                                        PointList[index] = new DrawFunction3D.PointF3D(this.AreaFun(num4, num6), num4, num6);
                                        break;
                                    case DrawArea.AreaSettings.ArgumentType.Arg1XArg2Z:
                                        PointList[index] = new DrawFunction3D.PointF3D(num4, this.AreaFun(num4, num6), num6);
                                        break;
                                    default:
                                        PointList[index] = new DrawFunction3D.PointF3D(num4, num6, this.AreaFun(num4, num6));
                                        break;
                                }
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
                        this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillRectangles(this.IndexDrawFunction, drawAreaSettings.DrawBrush, drawAreaSettings.PointsWidth, drawAreaSettings.PointsHeight, PointList));
                    }
                    else
                    {
                        double min1 = drawAreaSettings.DrawRangeArg1.Min;
                        double num3 = drawAreaSettings.DrawRangeArg1.Max - (double)num1 / 10.0;
                        float StepValue1 = num1;
                        float limit1 = (float)num3;
                        float num4 = (float)min1;
                        while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num4, limit1, StepValue1))
                        {
                            double min2 = drawAreaSettings.DrawRangeArg2.Min;
                            double num5 = drawAreaSettings.DrawRangeArg2.Max - (double)num2 / 10.0;
                            float StepValue2 = num2;
                            float limit2 = (float)num5;
                            float num6 = (float)min2;
                            while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num6, limit2, StepValue2))
                            {
                                if (drawAreaSettings.FillStyle == DrawArea.AreaSettings.FillType.Fill | drawAreaSettings.FillStyle == DrawArea.AreaSettings.FillType.FillAndLines)
                                {
                                    switch (drawAreaSettings.ArgumentStyle)
                                    {
                                        case DrawArea.AreaSettings.ArgumentType.Arg1YArg2Z:
                                            this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillPolygon(this.IndexDrawFunction, drawAreaSettings.DrawBrush, new DrawFunction3D.PointF3D[4]
                                            {
                        new DrawFunction3D.PointF3D(this.AreaFun(num4, num6), num4, num6),
                        new DrawFunction3D.PointF3D(this.AreaFun(num4, num6 + num2), num4, num6 + num2),
                        new DrawFunction3D.PointF3D(this.AreaFun(num4 + num1, num6 + num2), num4 + num1, num6 + num2),
                        new DrawFunction3D.PointF3D(this.AreaFun(num4 + num1, num6), num4 + num1, num6)
                                            }));
                                            break;
                                        case DrawArea.AreaSettings.ArgumentType.Arg1XArg2Z:
                                            this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillPolygon(this.IndexDrawFunction, drawAreaSettings.DrawBrush, new DrawFunction3D.PointF3D[4]
                                            {
                        new DrawFunction3D.PointF3D(num4, this.AreaFun(num4, num6), num6),
                        new DrawFunction3D.PointF3D(num4, this.AreaFun(num4, num6 + num2), num6 + num2),
                        new DrawFunction3D.PointF3D(num4 + num1, this.AreaFun(num4 + num1, num6 + num2), num6 + num2),
                        new DrawFunction3D.PointF3D(num4 + num1, this.AreaFun(num4 + num1, num6), num6)
                                            }));
                                            break;
                                        default:
                                            this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new FillPolygon(this.IndexDrawFunction, drawAreaSettings.DrawBrush, new DrawFunction3D.PointF3D[4]
                                            {
                        new DrawFunction3D.PointF3D(num4, num6, this.AreaFun(num4, num6)),
                        new DrawFunction3D.PointF3D(num4, num6 + num2, this.AreaFun(num4, num6 + num2)),
                        new DrawFunction3D.PointF3D(num4 + num1, num6 + num2, this.AreaFun(num4 + num1, num6 + num2)),
                        new DrawFunction3D.PointF3D(num4 + num1, num6, this.AreaFun(num4 + num1, num6))
                                            }));
                                            break;
                                    }
                                }
                                if (drawAreaSettings.FillStyle == DrawArea.AreaSettings.FillType.Lines | drawAreaSettings.FillStyle == DrawArea.AreaSettings.FillType.FillAndLines)
                                {
                                    switch (drawAreaSettings.ArgumentStyle)
                                    {
                                        case DrawArea.AreaSettings.ArgumentType.Arg1YArg2Z:
                                            this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new DrawPolygon(this.IndexDrawFunction, drawAreaSettings.DrawPen, new DrawFunction3D.PointF3D[4]
                                            {
                        new DrawFunction3D.PointF3D(this.AreaFun(num4, num6), num4, num6),
                        new DrawFunction3D.PointF3D(this.AreaFun(num4, num6 + num2), num4, num6 + num2),
                        new DrawFunction3D.PointF3D(this.AreaFun(num4 + num1, num6 + num2), num4 + num1, num6 + num2),
                        new DrawFunction3D.PointF3D(this.AreaFun(num4 + num1, num6), num4 + num1, num6)
                                            }));
                                            break;
                                        case DrawArea.AreaSettings.ArgumentType.Arg1XArg2Z:
                                            this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new DrawPolygon(this.IndexDrawFunction, drawAreaSettings.DrawPen, new DrawFunction3D.PointF3D[4]
                                            {
                        new DrawFunction3D.PointF3D(num4, this.AreaFun(num4, num6), num6),
                        new DrawFunction3D.PointF3D(num4, this.AreaFun(num4, num6 + num2), num6 + num2),
                        new DrawFunction3D.PointF3D(num4 + num1, this.AreaFun(num4 + num1, num6 + num2), num6 + num2),
                        new DrawFunction3D.PointF3D(num4 + num1, this.AreaFun(num4 + num1, num6), num6)
                                            }));
                                            break;
                                        default:
                                            this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)new DrawPolygon(this.IndexDrawFunction, drawAreaSettings.DrawPen, new DrawFunction3D.PointF3D[4]
                                            {
                        new DrawFunction3D.PointF3D(num4, num6, this.AreaFun(num4, num6)),
                        new DrawFunction3D.PointF3D(num4, num6 + num2, this.AreaFun(num4, num6 + num2)),
                        new DrawFunction3D.PointF3D(num4 + num1, num6 + num2, this.AreaFun(num4 + num1, num6 + num2)),
                        new DrawFunction3D.PointF3D(num4 + num1, num6, this.AreaFun(num4 + num1, num6))
                                            }));
                                            break;
                                    }
                                }
                                num6 += StepValue2;
                            }
                            num4 += StepValue1;
                        }
                    }
                }
            }
            return flag;
        }

        public delegate float Fun(float arg1, float arg2);

        public class AreaSettings
        {
            protected DrawArea.AreaSettings.FillType enum_FillStyle;
            protected DrawArea.AreaSettings.ArgumentType enum_ArgumentStyle;
            protected int i_DrawCountArg1;
            protected int i_DrawCountArg2;
            protected DrawFunction3D.DrawRange range_RrawRangeArg1;
            protected DrawFunction3D.DrawRange range_RrawRangeArg2;
            protected Pen pen_DrawPen;
            protected Brush brush_DrawBrush;
            protected float f_PointsWidth;
            protected float f_PointsHeight;

            public virtual DrawArea.AreaSettings.FillType FillStyle
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

            public virtual DrawArea.AreaSettings.ArgumentType ArgumentStyle
            {
                get
                {
                    return this.enum_ArgumentStyle;
                }
                set
                {
                    this.enum_ArgumentStyle = value;
                }
            }

            public virtual int DrawCountArg1
            {
                get
                {
                    return this.i_DrawCountArg1;
                }
                set
                {
                    if (value < 1)
                        value = 1;
                    this.i_DrawCountArg1 = value;
                }
            }

            public virtual int DrawCountArg2
            {
                get
                {
                    return this.i_DrawCountArg2;
                }
                set
                {
                    if (value < 1)
                        value = 1;
                    this.i_DrawCountArg2 = value;
                }
            }

            public virtual DrawFunction3D.DrawRange DrawRangeArg1
            {
                get
                {
                    return this.range_RrawRangeArg1;
                }
                set
                {
                    this.range_RrawRangeArg1 = value;
                }
            }

            public virtual DrawFunction3D.DrawRange DrawRangeArg2
            {
                get
                {
                    return this.range_RrawRangeArg2;
                }
                set
                {
                    this.range_RrawRangeArg2 = value;
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

            public AreaSettings()
            {
                this.enum_FillStyle = DrawArea.AreaSettings.FillType.FillAndLines;
                this.enum_ArgumentStyle = DrawArea.AreaSettings.ArgumentType.Arg1XArg2Y;
                this.i_DrawCountArg1 = 10;
                this.i_DrawCountArg2 = 10;
                this.range_RrawRangeArg1 = new DrawFunction3D.DrawRange(0.0, 1.0);
                this.range_RrawRangeArg2 = new DrawFunction3D.DrawRange(0.0, 1.0);
                this.pen_DrawPen = Pens.Black;
                this.brush_DrawBrush = (Brush)new SolidBrush(Color.FromArgb(100, Color.Blue));
                this.f_PointsWidth = 5f;
                this.f_PointsHeight = 5f;
            }

            public enum ArgumentType
            {
                Arg1XArg2Y,
                Arg1YArg2Z,
                Arg1XArg2Z,
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
