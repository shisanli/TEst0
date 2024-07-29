using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawFunctionLib
{
    public class DrawFunction2D
    {
        private const int ImageDefaultWidth = 1200;
        private const int ImageDefaultHeight = 1000;
        protected Bitmap uImageFunction;
        protected Bitmap uImagePoint;
        protected DrawFunction2D.DrawRange uRangeX;
        protected DrawFunction2D.DrawRange uRangeY;
        protected Collection<Pen> uDrawPenList;
        protected Font uDrawFont;
        protected string uDrawFormat;
        protected SolidBrush uDrawBrushString;
        protected float d_DrawEdgePercent;
        protected DrawFunction2D.CoordinateSettings uDrawCoordinateSettings;
        protected DrawFunction2D.PointsSettings uDrawPointsSettings;

        public virtual Bitmap ImageFunction
        {
            get
            {
                return this.uImageFunction;
            }
        }

        public virtual Graphics GraphicsFunction
        {
            get
            {
                return Graphics.FromImage((Image)this.uImageFunction);
            }
        }

        public virtual Bitmap ImagePoint
        {
            get
            {
                return this.uImagePoint;
            }
        }

        public virtual Graphics GraphicsPoint
        {
            get
            {
                return Graphics.FromImage((Image)this.uImagePoint);
            }
        }

        public virtual int ImageWidth
        {
            get
            {
                return this.ImageFunction.Width;
            }
        }

        public virtual int ImageHeight
        {
            get
            {
                return this.ImageFunction.Height;
            }
        }

        public virtual DrawFunction2D.DrawRange DrawRangeX
        {
            get
            {
                return this.uRangeX;
            }
            set
            {
                if (value == null)
                    return;
                this.uRangeX = value;
            }
        }

        public virtual DrawFunction2D.DrawRange DrawRangeY
        {
            get
            {
                return this.uRangeY;
            }
            set
            {
                if (value == null)
                    return;
                this.uRangeY = value;
            }
        }

        public virtual float DrawEdgePercent
        {
            get
            {
                return this.d_DrawEdgePercent;
            }
            set
            {
                if ((double)value < 0.0)
                    value = 0.0f;
                else if ((double)value > 0.5)
                    value = 0.5f;
                this.d_DrawEdgePercent = value;
            }
        }

        public virtual Collection<Pen> DrawPenList
        {
            get
            {
                return this.uDrawPenList;
            }
            set
            {
                if (value == null)
                    return;
                this.uDrawPenList = value;
            }
        }

        public virtual Font DrawFont
        {
            get
            {
                return this.uDrawFont;
            }
            set
            {
                if (value == null)
                    return;
                this.uDrawFont = value;
            }
        }

        public virtual Color DrawFontColor
        {
            get
            {
                return this.uDrawBrushString.Color;
            }
            set
            {
                this.uDrawBrushString.Color = value;
            }
        }

        public virtual string DrawFormat
        {
            get
            {
                return this.uDrawFormat;
            }
            set
            {
                if (value == null)
                    return;
                this.uDrawFormat = value;
            }
        }

        public virtual DrawFunction2D.CoordinateSettings DrawCoordinateSettings
        {
            get
            {
                return this.uDrawCoordinateSettings;
            }
            set
            {
                if (value == null)
                    return;
                this.uDrawCoordinateSettings = value;
            }
        }

        public virtual DrawFunction2D.PointsSettings DrawPointsSettings
        {
            get
            {
                return this.uDrawPointsSettings;
            }
            set
            {
                if (value == null)
                    return;
                this.uDrawPointsSettings = value;
            }
        }

        public DrawFunction2D()
        {
            this.uImageFunction = new Bitmap(1200, 1000);
            this.uImagePoint = new Bitmap(1200, 1000);
            this.uRangeX = new DrawFunction2D.DrawRange(0.0, 1.0);
            this.uRangeY = new DrawFunction2D.DrawRange(0.0, 1.0);
            this.uDrawPenList = new Collection<Pen>();
            this.uDrawFont = new Font("Comic Sans MS", 13.5f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.uDrawFormat = "0.###";
            this.uDrawBrushString = new SolidBrush(Color.Black);
            this.d_DrawEdgePercent = 0.03f;
            this.uDrawCoordinateSettings = new DrawFunction2D.CoordinateSettings();
            this.uDrawPointsSettings = new DrawFunction2D.PointsSettings();
            this.Clear();
        }

        public DrawFunction2D(int Width, int Height)
        {
            this.uImageFunction = new Bitmap(1200, 1000);
            this.uImagePoint = new Bitmap(1200, 1000);
            this.uRangeX = new DrawFunction2D.DrawRange(0.0, 1.0);
            this.uRangeY = new DrawFunction2D.DrawRange(0.0, 1.0);
            this.uDrawPenList = new Collection<Pen>();
            this.uDrawFont = new Font("Comic Sans MS", 13.5f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.uDrawFormat = "0.###";
            this.uDrawBrushString = new SolidBrush(Color.Black);
            this.d_DrawEdgePercent = 0.03f;
            this.uDrawCoordinateSettings = new DrawFunction2D.CoordinateSettings();
            this.uDrawPointsSettings = new DrawFunction2D.PointsSettings();
            this.Clear(Width, Height);
        }

        public virtual void Clear()
        {
            this.ClearFunction();
            this.ClearPoint();
        }

        public virtual Graphics ClearFunction()
        {
            Graphics graphics = Graphics.FromImage((Image)this.uImageFunction);
            graphics.Clear(Color.Transparent);
            return graphics;
        }

        public virtual Graphics ClearPoint()
        {
            Graphics graphics = Graphics.FromImage((Image)this.uImagePoint);
            graphics.Clear(Color.Transparent);
            return graphics;
        }

        public virtual void Clear(int Width, int Height)
        {
            this.uImageFunction = new Bitmap(Width, Height);
            this.uImagePoint = new Bitmap(Width, Height);
            this.Clear();
        }

        public virtual void DrawPoint(bool ClearBck = true)
        {
            Graphics graphics1 = !ClearBck ? this.GraphicsPoint : this.ClearPoint();
            DrawFunction2D.PointsSettings drawPointsSettings = this.DrawPointsSettings;
            if (drawPointsSettings.PointsList.Count > 0)
            {
                int num1 = 0;
                int num2 = checked(drawPointsSettings.PointsList.Count - 1);
                int index = num1;
                while (index <= num2)
                {
                    PointF ValuePoint1 = drawPointsSettings.PointsList[index];
                    double x = (double)ValuePoint1.X;
                    ValuePoint1 = drawPointsSettings.PointsList[index];
                    double y = (double)ValuePoint1.Y;
                    if (this.uRangeX.IsIn(x) & this.uRangeY.IsIn(y))
                    {
                        graphics1.DrawRectangle(drawPointsSettings.PenPoint, this.PositionValueToDrawX((float)x) - drawPointsSettings.DrawPointWidth / 2f, this.PositionValueToDrawY((float)y) - drawPointsSettings.DrawPointWidth / 2f, drawPointsSettings.DrawPointWidth, drawPointsSettings.DrawPointWidth);
                        if (drawPointsSettings.EnableDrawLine)
                        {
                            Graphics graphics2 = graphics1;
                            Pen penLine1 = drawPointsSettings.PenLine;
                            ValuePoint1 = new PointF((float)x, (float)this.uRangeY.Min);
                            PointF draw1 = this.PositionValueToDraw(ValuePoint1);
                            PointF ValuePoint2 = new PointF((float)x, (float)this.uRangeY.Max);
                            PointF draw2 = this.PositionValueToDraw(ValuePoint2);
                            graphics2.DrawLine(penLine1, draw1, draw2);
                            Graphics graphics3 = graphics1;
                            Pen penLine2 = drawPointsSettings.PenLine;
                            ValuePoint2 = new PointF((float)this.uRangeX.Min, (float)y);
                            PointF draw3 = this.PositionValueToDraw(ValuePoint2);
                            ValuePoint1 = new PointF((float)this.uRangeX.Max, (float)y);
                            PointF draw4 = this.PositionValueToDraw(ValuePoint1);
                            graphics3.DrawLine(penLine2, draw3, draw4);
                        }
                        if (drawPointsSettings.EnableDrawPointValue)
                            graphics1.DrawString("(" + x.ToString(this.DrawFormat) + "," + y.ToString(this.DrawFormat) + ")", this.DrawFont, (Brush)this.uDrawBrushString, this.PositionValueToDrawX((float)x), this.PositionValueToDrawY((float)y));
                    }
                    checked { ++index; }
                }
            }
        }

        public virtual void DrawCoordinate(bool ClearBck = true)
        {
            Graphics graphics1 = !ClearBck ? this.GraphicsFunction : this.ClearFunction();
            DrawFunction2D.CoordinateSettings coordinateSettings = this.DrawCoordinateSettings;
            Graphics graphics2 = graphics1;
            Pen penCoordinate1 = coordinateSettings.PenCoordinate;
            PointF ValuePoint1 = new PointF((float)this.uRangeX.Min, (float)this.uRangeY.Min);
            PointF draw1 = this.PositionValueToDraw(ValuePoint1);
            PointF ValuePoint2 = new PointF((float)this.uRangeX.Max, (float)this.uRangeY.Min);
            PointF draw2 = this.PositionValueToDraw(ValuePoint2);
            graphics2.DrawLine(penCoordinate1, draw1, draw2);
            Graphics graphics3 = graphics1;
            Pen penCoordinate2 = coordinateSettings.PenCoordinate;
            ValuePoint2 = new PointF((float)this.uRangeX.Min, (float)this.uRangeY.Min);
            PointF draw3 = this.PositionValueToDraw(ValuePoint2);
            ValuePoint1 = new PointF((float)this.uRangeX.Min, (float)this.uRangeY.Max);
            PointF draw4 = this.PositionValueToDraw(ValuePoint1);
            graphics3.DrawLine(penCoordinate2, draw3, draw4);
            Graphics graphics4 = graphics1;
            string coordinateNameX = coordinateSettings.CoordinateNameX;
            Font drawFont1 = this.DrawFont;
            SolidBrush uDrawBrushString1 = this.uDrawBrushString;
            ValuePoint2 = new PointF((float)this.uRangeX.Max, (float)this.uRangeY.Min);
            PointF draw5 = this.PositionValueToDraw(ValuePoint2);
            graphics4.DrawString(coordinateNameX, drawFont1, (Brush)uDrawBrushString1, draw5);
            Graphics graphics5 = graphics1;
            string coordinateNameY = coordinateSettings.CoordinateNameY;
            Font drawFont2 = this.DrawFont;
            SolidBrush uDrawBrushString2 = this.uDrawBrushString;
            ValuePoint2 = new PointF((float)this.uRangeX.Min, (float)this.uRangeY.Max);
            PointF draw6 = this.PositionValueToDraw(ValuePoint2);
            graphics5.DrawString(coordinateNameY, drawFont2, (Brush)uDrawBrushString2, draw6);
            if (coordinateSettings.EnableDrawTopCoordinate)
            {
                Graphics graphics6 = graphics1;
                Pen penSubCoordinate1 = coordinateSettings.PenSubCoordinate;
                ValuePoint2 = new PointF((float)this.uRangeX.Min, (float)this.uRangeY.Max);
                PointF draw7 = this.PositionValueToDraw(ValuePoint2);
                ValuePoint1 = new PointF((float)this.uRangeX.Max, (float)this.uRangeY.Max);
                PointF draw8 = this.PositionValueToDraw(ValuePoint1);
                graphics6.DrawLine(penSubCoordinate1, draw7, draw8);
                Graphics graphics7 = graphics1;
                Pen penSubCoordinate2 = coordinateSettings.PenSubCoordinate;
                ValuePoint2 = new PointF((float)this.uRangeX.Max, (float)this.uRangeY.Min);
                PointF draw9 = this.PositionValueToDraw(ValuePoint2);
                ValuePoint1 = new PointF((float)this.uRangeX.Max, (float)this.uRangeY.Max);
                PointF draw10 = this.PositionValueToDraw(ValuePoint1);
                graphics7.DrawLine(penSubCoordinate2, draw9, draw10);
            }
            if (coordinateSettings.EnableDrawCoordinateValue)
            {
                graphics1.DrawString(this.uRangeX.Min.ToString(this.DrawFormat), this.DrawFont, (Brush)this.uDrawBrushString, this.PositionValueToDrawX((float)this.uRangeX.Min), this.PositionValueToDrawY((float)this.uRangeY.Min));
                graphics1.DrawString(this.uRangeY.Min.ToString(this.DrawFormat), this.DrawFont, (Brush)this.uDrawBrushString, this.PositionValueToDrawX((float)this.uRangeX.Min), this.PositionValueToDrawY((float)this.uRangeY.Min) - (float)this.DrawFont.Height - coordinateSettings.PenCoordinate.Width);
            }
            if (coordinateSettings.EnableDrawSubCoordinate | coordinateSettings.EnableDrawCoordinateValue)
            {
                double num1 = this.uRangeX.Length / (double)coordinateSettings.CoordinateNumberX;
                double num2 = this.uRangeY.Length / (double)coordinateSettings.CoordinateNumberY;
                if (num1 > 0.0)
                {
                    double num3 = this.uRangeX.Min + num1;
                    double num4 = this.uRangeX.Max - num1 / 2.0;
                    double StepValue = num1;
                    double limit = num4;
                    double count = num3;
                    while (ObjectFlowControl.ForLoopControl.ForNextCheckR8(count, limit, StepValue))
                    {
                        if (coordinateSettings.EnableDrawSubCoordinate)
                        {
                            Graphics graphics6 = graphics1;
                            Pen penSubCoordinate = coordinateSettings.PenSubCoordinate;
                            ValuePoint2 = new PointF((float)count, (float)this.uRangeY.Min);
                            PointF draw7 = this.PositionValueToDraw(ValuePoint2);
                            ValuePoint1 = new PointF((float)count, (float)this.uRangeY.Max);
                            PointF draw8 = this.PositionValueToDraw(ValuePoint1);
                            graphics6.DrawLine(penSubCoordinate, draw7, draw8);
                        }
                        if (coordinateSettings.EnableDrawCoordinateValue)
                        {
                            if (!coordinateSettings.EnableDrawSubCoordinate)
                                graphics1.DrawLine(coordinateSettings.PenSubCoordinate, this.PositionValueToDrawX((float)count), this.PositionValueToDrawY((float)this.uRangeY.Min), this.PositionValueToDrawX((float)count), this.PositionValueToDrawY((float)this.uRangeY.Min) - coordinateSettings.PenCoordinate.Width * 2f);
                            graphics1.DrawString(count.ToString(this.DrawFormat), this.DrawFont, (Brush)this.uDrawBrushString, this.PositionValueToDrawX((float)count), this.PositionValueToDrawY((float)this.uRangeY.Min));
                        }
                        count += StepValue;
                    }
                }
                if (num2 > 0.0)
                {
                    double num3 = this.uRangeY.Min + num2;
                    double num4 = this.uRangeY.Max - num2 / 2.0;
                    double StepValue = num2;
                    double limit = num4;
                    double count = num3;
                    while (ObjectFlowControl.ForLoopControl.ForNextCheckR8(count, limit, StepValue))
                    {
                        if (coordinateSettings.EnableDrawSubCoordinate)
                        {
                            Graphics graphics6 = graphics1;
                            Pen penSubCoordinate = coordinateSettings.PenSubCoordinate;
                            ValuePoint2 = new PointF((float)this.uRangeX.Min, (float)count);
                            PointF draw7 = this.PositionValueToDraw(ValuePoint2);
                            ValuePoint1 = new PointF((float)this.uRangeX.Max, (float)count);
                            PointF draw8 = this.PositionValueToDraw(ValuePoint1);
                            graphics6.DrawLine(penSubCoordinate, draw7, draw8);
                        }
                        if (coordinateSettings.EnableDrawCoordinateValue)
                        {
                            if (!coordinateSettings.EnableDrawSubCoordinate)
                                graphics1.DrawLine(coordinateSettings.PenSubCoordinate, this.PositionValueToDrawX((float)this.uRangeX.Min), this.PositionValueToDrawY((float)count), this.PositionValueToDrawX((float)this.uRangeX.Min) + coordinateSettings.PenCoordinate.Width * 2f, this.PositionValueToDrawY((float)count));
                            graphics1.DrawString(count.ToString(this.DrawFormat), this.DrawFont, (Brush)this.uDrawBrushString, this.PositionValueToDrawX((float)this.uRangeX.Min), this.PositionValueToDrawY((float)count));
                        }
                        count += StepValue;
                    }
                }
            }
        }

        public virtual float PositionValueToDrawX(float ValueX)
        {
            float num1 = (float)this.DrawRangeX.Length;
            if ((double)num1 <= 0.0)
                num1 = 1f;
            float num2 = (float)this.ImageWidth * (this.DrawEdgePercent + (float)((1.0 - 2.0 * (double)this.DrawEdgePercent) * ((double)ValueX - this.DrawRangeX.Min)) / num1);
            if ((double)num2 < 0.0)
                num2 = 0.0f;
            else if ((double)num2 > (double)checked(this.ImageWidth - 1))
                num2 = (float)checked(this.ImageWidth - 1);
            return num2;
        }

        public virtual float PositionValueToDrawY(float ValueY)
        {
            float num1 = (float)this.DrawRangeY.Length;
            if ((double)num1 <= 0.0)
                num1 = 1f;
            float num2 = (float)this.ImageHeight * (this.DrawEdgePercent + (float)((1.0 - 2.0 * (double)this.DrawEdgePercent) * (this.DrawRangeY.Max - (double)ValueY)) / num1);
            if ((double)num2 < 0.0)
                num2 = 0.0f;
            else if ((double)num2 > (double)checked(this.ImageHeight - 1))
                num2 = (float)checked(this.ImageHeight - 1);
            return num2;
        }

        public virtual PointF PositionValueToDraw(PointF ValuePoint)
        {
            return new PointF(this.PositionValueToDrawX(ValuePoint.X), this.PositionValueToDrawY(ValuePoint.Y));
        }

        public virtual float PositionDrawToValueX(float DrawX)
        {
            float num1 = (float)(1.0 - 2.0 * (double)this.DrawEdgePercent);
            if ((double)num1 <= 0.0)
                num1 = 1f;
            DrawFunction2D.DrawRange drawRangeX = this.DrawRangeX;
            float num2 = (float)(((double)DrawX / (double)this.ImageWidth - (double)this.DrawEdgePercent) / (double)num1 * drawRangeX.Length + drawRangeX.Min);
            if ((double)num2 < drawRangeX.Min)
                num2 = (float)drawRangeX.Min;
            else if ((double)num2 > drawRangeX.Max)
                num2 = (float)drawRangeX.Max;
            return num2;
        }

        public virtual float PositionDrawToValueY(float DrawY)
        {
            float num1 = (float)(1.0 - 2.0 * (double)this.DrawEdgePercent);
            if ((double)num1 <= 0.0)
                num1 = 1f;
            DrawFunction2D.DrawRange drawRangeY = this.DrawRangeY;
            float num2 = (float)(drawRangeY.Max - ((double)DrawY / (double)this.ImageHeight - (double)this.DrawEdgePercent) / (double)num1 * drawRangeY.Length);
            if ((double)num2 < drawRangeY.Min)
                num2 = (float)drawRangeY.Min;
            else if ((double)num2 > drawRangeY.Max)
                num2 = (float)drawRangeY.Max;
            return num2;
        }

        public virtual PointF PositionDrawToValue(PointF DrawPoint)
        {
            return new PointF(this.PositionDrawToValueX(DrawPoint.X), this.PositionDrawToValueY(DrawPoint.Y));
        }

        public virtual float LengthValueToDrawX(float LengthX)
        {
            float num = (float)this.DrawRangeX.Length;
            if ((double)num <= 0.0)
                num = 1f;
            return (float)((double)LengthX * (double)this.ImageWidth / (double)num * (1.0 - 2.0 * (double)this.DrawEdgePercent));
        }

        public virtual float LengthValueToDrawY(float LengthY)
        {
            float num = (float)this.DrawRangeY.Length;
            if ((double)num <= 0.0)
                num = 1f;
            return (float)((double)LengthY * (double)this.ImageHeight / (double)num * (1.0 - 2.0 * (double)this.DrawEdgePercent));
        }

        public class DrawRange : ICloneable
        {
            protected double d_Max;
            protected double d_Min;

            public virtual double Max
            {
                get
                {
                    return this.d_Max;
                }
                set
                {
                    this.d_Max = value;
                    if (this.d_Min <= this.d_Max)
                        return;
                    this.d_Min = this.d_Max;
                }
            }

            public virtual double Min
            {
                get
                {
                    return this.d_Min;
                }
                set
                {
                    this.d_Min = value;
                    if (this.d_Max >= this.d_Min)
                        return;
                    this.d_Max = this.d_Min;
                }
            }

            public virtual double Length
            {
                get
                {
                    return Math.Abs(this.Max - this.Min);
                }
            }

            public string ToString
            {
                get
                {
                    return "[" + Conversions.ToString(this.Min) + "," + Conversions.ToString(this.Max) + "]";
                }
            }

            public DrawRange()
            {
                this.d_Max = 0.0;
                this.d_Min = 0.0;
                this.d_Max = 1.0;
                this.d_Min = 0.0;
            }

            public DrawRange(double Min, double Max)
            {
                this.d_Max = 0.0;
                this.d_Min = 0.0;
                this.SetRange(Min, Max);
            }

            public DrawRange(DrawFunction2D.DrawRange Range)
            {
                this.d_Max = 0.0;
                this.d_Min = 0.0;
                this.SetRange(Range);
            }

            public virtual bool IsIn(double Mid)
            {
                return Mid >= this.Min & Mid <= this.Max;
            }

            public virtual bool IsIn(DrawFunction2D.DrawRange Mid)
            {
                return Mid.Min >= this.Min & Mid.Max <= this.Max;
            }

            public virtual void SetRange(double Min, double Max)
            {
                this.Max = Max;
                this.Min = Min;
            }

            public virtual void SetRange(DrawFunction2D.DrawRange Range)
            {
                this.SetRange(Range.Min, Range.Max);
            }

            public virtual void SetInRange(DrawFunction2D.DrawRange OutRange)
            {
                if (this.Min < OutRange.Min)
                    this.Min = OutRange.Min;
                if (this.Max <= OutRange.Max)
                    return;
                this.Max = OutRange.Max;
            }

            public virtual void SetOutRange(DrawFunction2D.DrawRange InRange)
            {
                if (this.Min > InRange.Min)
                    this.Min = InRange.Min;
                if (this.Max >= InRange.Max)
                    return;
                this.Max = InRange.Max;
            }

            public object Clone()
            {
                return (object)new DrawFunction2D.DrawRange(this);
            }
        }

        public class CoordinateSettings
        {
            protected Pen uDrawPenCoordinate;
            protected Pen uDrawPenSubCoordinate;
            protected bool b_EnableDrawSubCoordinate;
            protected bool b_EnableDrawTopCoordinate;
            protected bool b_EnableDrawCoordinateValue;
            protected int i_DrawCoordinateNumberX;
            protected int i_DrawCoordinateNumberY;
            protected string str_DrawCoordinateNameX;
            protected string str_DrawCoordinateNameY;

            public virtual Pen PenCoordinate
            {
                get
                {
                    return this.uDrawPenCoordinate;
                }
                set
                {
                    if (value == null)
                        return;
                    this.uDrawPenCoordinate = value;
                }
            }

            public virtual Pen PenSubCoordinate
            {
                get
                {
                    return this.uDrawPenSubCoordinate;
                }
                set
                {
                    if (value == null)
                        return;
                    this.uDrawPenSubCoordinate = value;
                }
            }

            public virtual bool EnableDrawSubCoordinate
            {
                get
                {
                    return this.b_EnableDrawSubCoordinate;
                }
                set
                {
                    this.b_EnableDrawSubCoordinate = value;
                }
            }

            public virtual bool EnableDrawCoordinateValue
            {
                get
                {
                    return this.b_EnableDrawCoordinateValue;
                }
                set
                {
                    this.b_EnableDrawCoordinateValue = value;
                }
            }

            public virtual bool EnableDrawTopCoordinate
            {
                get
                {
                    return this.b_EnableDrawTopCoordinate;
                }
                set
                {
                    this.b_EnableDrawTopCoordinate = value;
                }
            }

            public virtual int CoordinateNumberX
            {
                get
                {
                    return this.i_DrawCoordinateNumberX;
                }
                set
                {
                    if (value < 1)
                        value = 1;
                    this.i_DrawCoordinateNumberX = value;
                }
            }

            public virtual int CoordinateNumberY
            {
                get
                {
                    return this.i_DrawCoordinateNumberY;
                }
                set
                {
                    if (value < 1)
                        value = 1;
                    this.i_DrawCoordinateNumberY = value;
                }
            }

            public virtual string CoordinateNameX
            {
                get
                {
                    return this.str_DrawCoordinateNameX;
                }
                set
                {
                    if (value == null)
                        return;
                    this.str_DrawCoordinateNameX = value;
                }
            }

            public virtual string CoordinateNameY
            {
                get
                {
                    return this.str_DrawCoordinateNameY;
                }
                set
                {
                    if (value == null)
                        return;
                    this.str_DrawCoordinateNameY = value;
                }
            }

            public CoordinateSettings()
            {
                this.uDrawPenCoordinate = new Pen(Color.Black, 4f);
                this.uDrawPenSubCoordinate = new Pen(Color.Black, 1f);
                this.b_EnableDrawSubCoordinate = true;
                this.b_EnableDrawTopCoordinate = true;
                this.b_EnableDrawCoordinateValue = true;
                this.i_DrawCoordinateNumberX = 20;
                this.i_DrawCoordinateNumberY = 10;
                this.str_DrawCoordinateNameX = "x";
                this.str_DrawCoordinateNameY = "y";
                this.PenCoordinate.DashStyle = DashStyle.Solid;
                this.PenCoordinate.StartCap = LineCap.NoAnchor;
                this.PenCoordinate.EndCap = LineCap.ArrowAnchor;
            }
        }

        public class PointsSettings
        {
            protected Collection<PointF> uDrawPoints;
            protected Pen uDrawPenPoint;
            protected float uDrawPointWidth;
            protected Pen uDrawPenPointLine;
            protected bool b_EnableDrawPointValue;
            protected bool b_EnableDrawLine;

            public virtual Collection<PointF> PointsList
            {
                get
                {
                    return this.uDrawPoints;
                }
                set
                {
                    if (value == null)
                        return;
                    this.uDrawPoints = value;
                }
            }

            public virtual Pen PenPoint
            {
                get
                {
                    return this.uDrawPenPoint;
                }
                set
                {
                    if (value == null)
                        return;
                    this.uDrawPenPoint = value;
                }
            }

            public virtual Pen PenLine
            {
                get
                {
                    return this.uDrawPenPointLine;
                }
                set
                {
                    if (value == null)
                        return;
                    this.uDrawPenPointLine = value;
                }
            }

            public virtual bool EnableDrawPointValue
            {
                get
                {
                    return this.b_EnableDrawPointValue;
                }
                set
                {
                    this.b_EnableDrawPointValue = value;
                }
            }

            public virtual bool EnableDrawLine
            {
                get
                {
                    return this.b_EnableDrawLine;
                }
                set
                {
                    this.b_EnableDrawLine = value;
                }
            }

            public virtual float DrawPointWidth
            {
                get
                {
                    return this.uDrawPointWidth;
                }
                set
                {
                    if ((double)value < 0.0)
                        value = 0.0f;
                    this.uDrawPointWidth = value;
                }
            }

            public PointsSettings()
            {
                this.uDrawPoints = new Collection<PointF>();
                this.uDrawPenPoint = new Pen(Color.Red, 2f);
                this.uDrawPointWidth = 6f;
                this.uDrawPenPointLine = new Pen(Color.Purple, 1f);
                this.b_EnableDrawPointValue = true;
                this.b_EnableDrawLine = true;
                this.PenPoint.DashStyle = DashStyle.Dot;
                this.PenLine.DashStyle = DashStyle.DashDotDot;
            }

            public virtual bool AddPoint(ref PointF Point)
            {
                bool flag = true;
                if (this.PointsList.Count > 0)
                {
                    int index = checked(this.PointsList.Count - 1);
                    while (index >= 0)
                    {
                        if (this.PointsList[index] == Point)
                        {
                            this.PointsList.RemoveAt(index);
                            flag = false;
                        }
                        checked { index += -1; }
                    }
                }
                this.PointsList.Add(Point);
                return flag;
            }

            public virtual bool Remove(PointF Point)
            {
                bool flag = false;
                if (this.PointsList.Count > 0)
                {
                    int index = checked(this.PointsList.Count - 1);
                    while (index >= 0)
                    {
                        if (this.PointsList[index] == Point)
                        {
                            this.PointsList.RemoveAt(index);
                            flag = true;
                        }
                        checked { index += -1; }
                    }
                }
                return flag;
            }

            public virtual object RemoveAt(int Index)
            {
                if (!(Index >= 0 & Index <= checked(this.PointsList.Count - 1)))
                    return (object)false;
                this.PointsList.RemoveAt(Index);
                return (object)true;
            }

            public virtual bool Clear()
            {
                if (this.PointsList.Count <= 0)
                    return false;
                this.PointsList.Clear();
                return true;
            }
        }
    }
}
