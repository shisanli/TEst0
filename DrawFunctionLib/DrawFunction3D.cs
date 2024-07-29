using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using DrawFunctionLib.DrawFunction3DPart;
using DrawFunctionLib.Properties;
namespace DrawFunctionLib
{
    public class DrawFunction3D
    {
       
        public virtual bool DrawLockZoom
        {
            get
            {
                var x= Resources.Joint; //无用
                return this.b_DrawLockZoom;
            }
            set
            {
                this.b_DrawLockZoom = value;
            }
        }

       
        public virtual ShadowMatrix TurnMatrix
        {
            get
            {
                return this.mTurnMatrix;
            }
            set
            {
                if (value != null)
                {
                    this.mTurnMatrix = value;
                }
            }
        }

      
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
                return Graphics.FromImage(this.uImageFunction);
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
                return Graphics.FromImage(this.uImagePoint);
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

        
        public virtual DrawRange DrawRangeX
        {
            get
            {
                return this.uRangeX;
            }
            set
            {
                if (value != null)
                {
                    this.uRangeX = value;
                }
            }
        }

        
        public virtual DrawRange DrawRangeY
        {
            get
            {
                return this.uRangeY;
            }
            set
            {
                if (value != null)
                {
                    this.uRangeY = value;
                }
            }
        }

        
        public virtual DrawRange DrawRangeZ
        {
            get
            {
                return this.uRangeZ;
            }
            set
            {
                if (value != null)
                {
                    this.uRangeZ = value;
                }
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
                if (value >= 0f)
                {
                    if ((double)value > 0.5)
                    {
                        value = 0.5f;
                    }
                }
                this.d_DrawEdgePercent = value;
            }
        }

        
        public virtual PointF DrawOffset
        {
            get
            {
                return this.f_DrawOffset;
            }
            set
            {
                this.f_DrawOffset = value;
            }
        }

         
        public virtual List<DrawBase> DrawPartListFunction
        {
            get
            {
                return this.list_DrawFunctionPartList;
            }
            set
            {
                if (value != null)
                {
                    this.list_DrawFunctionPartList = value;
                }
            }
        }

        
        public virtual List<DrawBase> DrawPartListPoint
        {
            get
            {
                return this.list_DrawPointPartList;
            }
            set
            {
                if (value != null)
                {
                    this.list_DrawPointPartList = value;
                }
            }
        }

        
        public virtual void DrawFunction(bool ClearBck = true)
        {
            Graphics drawGraph;
            if (ClearBck)
            {
                drawGraph = this.ClearFunction();
            }
            else
            {
                drawGraph = this.GraphicsFunction;
            }
            checked
            {
                if (this.DrawPartListFunction.Count > 0)
                {
                    this.DrawPartListFunction.Sort();
                    this.SynchronizeDrawRange();
                    int num = this.DrawPartListFunction.Count - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        this.DrawPartListFunction[i].DrawPart(drawGraph);
                    }
                }
            }
        }

        
        public virtual void DrawPoint(bool ClearBck = true)
        {
            Graphics drawGraph;
            if (ClearBck)
            {
                drawGraph = this.ClearPoint();
            }
            else
            {
                drawGraph = this.GraphicsPoint;
            }
            checked
            {
                if (this.DrawPartListPoint.Count > 0)
                {
                    this.DrawPartListPoint.Sort();
                    this.SynchronizeDrawRange();
                    int num = 0;
                    int num2 = this.DrawPartListPoint.Count - 1;
                    for (int i = num; i <= num2; i++)
                    {
                        this.DrawPartListPoint[i].DrawPart(drawGraph);
                    }
                }
            }
        }

        
        public virtual void Clear()
        {
            this.ClearFunction();
            this.ClearPoint();
        }

        
        public virtual Graphics ClearFunction()
        {
            Graphics graphics = Graphics.FromImage(this.uImageFunction);
            graphics.Clear(Color.Transparent);
            return graphics;
        }

        
        public virtual Graphics ClearPoint()
        {
            Graphics graphics = Graphics.FromImage(this.uImagePoint);
            graphics.Clear(Color.Transparent);
            return graphics;
        }

        
        public virtual void Clear(int Width, int Height)
        {
            this.uImageFunction = new Bitmap(Width, Height);
            this.uImagePoint = new Bitmap(Width, Height);
            this.Clear();
        }

        
        public DrawFunction3D()
        {
            this.uImageFunction = new Bitmap(1200, 1000);
            this.uImagePoint = new Bitmap(1200, 1000);
            this.uRangeX = new DrawRange(0.0, 1.0);
            this.uRangeY = new DrawRange(0.0, 1.0);
            this.uRangeZ = new DrawRange(0.0, 1.0);
            this.mTurnMatrix = new ShadowMatrix();
            this.u2DRangeX = new DrawRange(0.0, 1.0);
            this.u2DRangeY = new DrawRange(0.0, 1.0);
            this.b_DrawLockZoom = true;
            this.d_DrawEdgePercent = 0.03f;
            this.f_DrawOffset = new PointF(0f, 0f);
            this.list_DrawFunctionPartList = new List<DrawBase>();
            this.list_DrawPointPartList = new List<DrawBase>();
            this.Clear();
            this.TurnMatrix = ShadowMatrix.FromTurning(2.0, -2.0, -0.394);
        }

        
        public DrawFunction3D(int Width, int Height)
        {
            this.uImageFunction = new Bitmap(1200, 1000);
            this.uImagePoint = new Bitmap(1200, 1000);
            this.uRangeX = new DrawRange(0.0, 1.0);
            this.uRangeY = new DrawRange(0.0, 1.0);
            this.uRangeZ = new DrawRange(0.0, 1.0);
            this.mTurnMatrix = new ShadowMatrix();
            this.u2DRangeX = new DrawRange(0.0, 1.0);
            this.u2DRangeY = new DrawRange(0.0, 1.0);
            this.b_DrawLockZoom = true;
            this.d_DrawEdgePercent = 0.03f;
            this.f_DrawOffset = new PointF(0f, 0f);
            this.list_DrawFunctionPartList = new List<DrawBase>();
            this.list_DrawPointPartList = new List<DrawBase>();
            this.Clear(Width, Height);
            this.TurnMatrix = ShadowMatrix.FromTurning(2.0, -2.0, -0.394);
        }

        
        public void SynchronizeDrawRange()
        {
            PointF3D pointF3D = new PointF3D();
            PointF pointF = default(PointF);
            pointF3D.SetValue((float)this.DrawRangeX.Min, (float)this.DrawRangeY.Min, (float)this.DrawRangeZ.Min);
            pointF = this.TurnMatrix.ShadowPoint(pointF3D);
            this.u2DRangeX.SetRange((double)pointF.X, (double)pointF.X);
            this.u2DRangeY.SetRange((double)pointF.Y, (double)pointF.Y);
            pointF3D.SetValue((float)this.DrawRangeX.Min, (float)this.DrawRangeY.Min, (float)this.DrawRangeZ.Max);
            pointF = this.TurnMatrix.ShadowPoint(pointF3D);
            if (this.u2DRangeX.Min > (double)pointF.X)
            {
                this.u2DRangeX.Min = (double)pointF.X;
            }
            else if (this.u2DRangeX.Max < (double)pointF.X)
            {
                this.u2DRangeX.Max = (double)pointF.X;
            }
            if (this.u2DRangeY.Min > (double)pointF.Y)
            {
                this.u2DRangeY.Min = (double)pointF.Y;
            }
            else if (this.u2DRangeY.Max < (double)pointF.Y)
            {
                this.u2DRangeY.Max = (double)pointF.Y;
            }
            pointF3D.SetValue((float)this.DrawRangeX.Min, (float)this.DrawRangeY.Max, (float)this.DrawRangeZ.Min);
            pointF = this.TurnMatrix.ShadowPoint(pointF3D);
            if (this.u2DRangeX.Min > (double)pointF.X)
            {
                this.u2DRangeX.Min = (double)pointF.X;
            }
            else if (this.u2DRangeX.Max < (double)pointF.X)
            {
                this.u2DRangeX.Max = (double)pointF.X;
            }
            if (this.u2DRangeY.Min > (double)pointF.Y)
            {
                this.u2DRangeY.Min = (double)pointF.Y;
            }
            else if (this.u2DRangeY.Max < (double)pointF.Y)
            {
                this.u2DRangeY.Max = (double)pointF.Y;
            }
            pointF3D.SetValue((float)this.DrawRangeX.Min, (float)this.DrawRangeY.Max, (float)this.DrawRangeZ.Max);
            pointF = this.TurnMatrix.ShadowPoint(pointF3D);
            if (this.u2DRangeX.Min > (double)pointF.X)
            {
                this.u2DRangeX.Min = (double)pointF.X;
            }
            else if (this.u2DRangeX.Max < (double)pointF.X)
            {
                this.u2DRangeX.Max = (double)pointF.X;
            }
            if (this.u2DRangeY.Min > (double)pointF.Y)
            {
                this.u2DRangeY.Min = (double)pointF.Y;
            }
            else if (this.u2DRangeY.Max < (double)pointF.Y)
            {
                this.u2DRangeY.Max = (double)pointF.Y;
            }
            pointF3D.SetValue((float)this.DrawRangeX.Max, (float)this.DrawRangeY.Min, (float)this.DrawRangeZ.Min);
            pointF = this.TurnMatrix.ShadowPoint(pointF3D);
            if (this.u2DRangeX.Min > (double)pointF.X)
            {
                this.u2DRangeX.Min = (double)pointF.X;
            }
            else if (this.u2DRangeX.Max < (double)pointF.X)
            {
                this.u2DRangeX.Max = (double)pointF.X;
            }
            if (this.u2DRangeY.Min > (double)pointF.Y)
            {
                this.u2DRangeY.Min = (double)pointF.Y;
            }
            else if (this.u2DRangeY.Max < (double)pointF.Y)
            {
                this.u2DRangeY.Max = (double)pointF.Y;
            }
            pointF3D.SetValue((float)this.DrawRangeX.Max, (float)this.DrawRangeY.Min, (float)this.DrawRangeZ.Max);
            pointF = this.TurnMatrix.ShadowPoint(pointF3D);
            if (this.u2DRangeX.Min > (double)pointF.X)
            {
                this.u2DRangeX.Min = (double)pointF.X;
            }
            else if (this.u2DRangeX.Max < (double)pointF.X)
            {
                this.u2DRangeX.Max = (double)pointF.X;
            }
            if (this.u2DRangeY.Min > (double)pointF.Y)
            {
                this.u2DRangeY.Min = (double)pointF.Y;
            }
            else if (this.u2DRangeY.Max < (double)pointF.Y)
            {
                this.u2DRangeY.Max = (double)pointF.Y;
            }
            pointF3D.SetValue((float)this.DrawRangeX.Max, (float)this.DrawRangeY.Max, (float)this.DrawRangeZ.Min);
            pointF = this.TurnMatrix.ShadowPoint(pointF3D);
            if (this.u2DRangeX.Min > (double)pointF.X)
            {
                this.u2DRangeX.Min = (double)pointF.X;
            }
            else if (this.u2DRangeX.Max < (double)pointF.X)
            {
                this.u2DRangeX.Max = (double)pointF.X;
            }
            if (this.u2DRangeY.Min > (double)pointF.Y)
            {
                this.u2DRangeY.Min = (double)pointF.Y;
            }
            else if (this.u2DRangeY.Max < (double)pointF.Y)
            {
                this.u2DRangeY.Max = (double)pointF.Y;
            }
            pointF3D.SetValue((float)this.DrawRangeX.Max, (float)this.DrawRangeY.Max, (float)this.DrawRangeZ.Max);
            pointF = this.TurnMatrix.ShadowPoint(pointF3D);
            if (this.u2DRangeX.Min > (double)pointF.X)
            {
                this.u2DRangeX.Min = (double)pointF.X;
            }
            else if (this.u2DRangeX.Max < (double)pointF.X)
            {
                this.u2DRangeX.Max = (double)pointF.X;
            }
            if (this.u2DRangeY.Min > (double)pointF.Y)
            {
                this.u2DRangeY.Min = (double)pointF.Y;
            }
            else if (this.u2DRangeY.Max < (double)pointF.Y)
            {
                this.u2DRangeY.Max = (double)pointF.Y;
            }
            if (this.DrawLockZoom)
            {
                double num = (this.u2DRangeX.Length - this.u2DRangeY.Length) / 2.0;
                if (num > 0.0)
                {
                    DrawRange drawRange = this.u2DRangeY;
                    drawRange.Min -= num;
                    drawRange = this.u2DRangeY;
                    drawRange.Max += num;
                }
                else if (num < 0.0)
                {
                    DrawRange drawRange = this.u2DRangeX;
                    drawRange.Min += num;
                    drawRange = this.u2DRangeX;
                    drawRange.Max -= num;
                }
            }
            double length = this.u2DRangeX.Length;
            double min = this.u2DRangeX.Min;
            double max = this.u2DRangeX.Max;
            this.u2DRangeX.Min = min + (double)this.DrawOffset.X * length;
            this.u2DRangeX.Max = max + (double)this.DrawOffset.X * length;
            length = this.u2DRangeY.Length;
            min = this.u2DRangeY.Min;
            max = this.u2DRangeY.Max;
            this.u2DRangeY.Min = min + (double)this.DrawOffset.Y * length;
            this.u2DRangeY.Max = max + (double)this.DrawOffset.Y * length;
        }

        
        public virtual void ResetLocation()
        {
            this.TurnMatrix = ShadowMatrix.FromTurning(2.0, -2.0, -0.394);
            PointF drawOffset = new PointF(0f, 0f);
            this.DrawOffset = drawOffset;
            this.DrawEdgePercent = 0.03f;
        }

        
        protected virtual float PositionValueToDrawX(float ValueX)
        {
            float num = (float)this.u2DRangeX.Length;
            if (num <= 0f)
            {
                num = 1f;
            }
            return (float)((double)((float)this.ImageWidth) * ((double)this.DrawEdgePercent + (double)(1f - 2f * this.DrawEdgePercent) * ((double)ValueX - this.u2DRangeX.Min) / (double)num));
        }

         
        protected virtual float PositionValueToDrawY(float ValueY)
        {
            float num = (float)this.u2DRangeY.Length;
            if (num <= 0f)
            {
                num = 1f;
            }
            return (float)((double)((float)this.ImageHeight) * ((double)this.DrawEdgePercent + (double)(1f - 2f * this.DrawEdgePercent) * (this.u2DRangeY.Max - (double)ValueY) / (double)num));
        }

        
        protected virtual PointF PositionValueToDraw(PointF ValuePoint)
        {
            PointF result = new PointF(this.PositionValueToDrawX(ValuePoint.X), this.PositionValueToDrawY(ValuePoint.Y));
            return result;
        }

        
        protected virtual float PositionDrawToValueX(float DrawX)
        {
            float num = 1f - 2f * this.DrawEdgePercent;
            if (num <= 0f)
            {
                num = 1f;
            }
            DrawRange drawRange = this.u2DRangeX;
            return (float)((double)((DrawX / (float)this.ImageWidth - this.DrawEdgePercent) / num) * drawRange.Length + drawRange.Min);
        }

        
        protected virtual float PositionDrawToValueY(float DrawY)
        {
            float num = 1f - 2f * this.DrawEdgePercent;
            if (num <= 0f)
            {
                num = 1f;
            }
            DrawRange drawRange = this.u2DRangeY;
            return (float)(drawRange.Max - (double)((DrawY / (float)this.ImageHeight - this.DrawEdgePercent) / num) * drawRange.Length);
        }

        
        protected virtual PointF PositionDrawToValue(PointF DrawPoint)
        {
            PointF result = new PointF(this.PositionDrawToValueX(DrawPoint.X), this.PositionDrawToValueY(DrawPoint.Y));
            return result;
        }

        
        protected virtual float LengthValueToDrawX(float LengthX)
        {
            float num = (float)this.u2DRangeX.Length;
            if (num <= 0f)
            {
                num = 1f;
            }
            return LengthX * (float)this.ImageWidth / num * (1f - 2f * this.DrawEdgePercent);
        }

       
        protected virtual float LengthValueToDrawY(float LengthY)
        {
            float num = (float)this.u2DRangeY.Length;
            if (num <= 0f)
            {
                num = 1f;
            }
            return LengthY * (float)this.ImageHeight / num * (1f - 2f * this.DrawEdgePercent);
        }

        
        public virtual PointF PositionValueToDraw(PointF3D ValuePoint)
        {
            PointF pointF = this.TurnMatrix.ShadowPoint(ValuePoint);
            PointF result = new PointF(this.PositionValueToDrawX(pointF.X), this.PositionValueToDrawY(pointF.Y));
            return result;
        }

        
        public virtual PointF LengthValueToDraw(PointF3D StartPoint, PointF3D EndPoint)
        {
            PointF pointF = this.TurnMatrix.ShadowPoint(StartPoint);
            PointF pointF2 = this.TurnMatrix.ShadowPoint(EndPoint);
            PointF result = new PointF(this.LengthValueToDrawX(Math.Abs(pointF.X - pointF2.X)), this.LengthValueToDrawY(Math.Abs(pointF.Y - pointF2.Y)));
            return result;
        }
 
        public virtual PointF3D PositionDrawToValueKnownZ(PointF DrawPoint, float Z)
        {
            PointF pos = this.PositionDrawToValue(DrawPoint);
            return this.TurnMatrix.UnshadowPointKnownZ(pos, Z);
        }

         
        public virtual PointF3D PositionDrawToValueKnownY(PointF DrawPoint, float Y)
        {
            PointF pos = this.PositionDrawToValue(DrawPoint);
            return this.TurnMatrix.UnshadowPointKnownY(pos, Y);
        }

       
        public virtual PointF3D PositionDrawToValueKnownX(PointF DrawPoint, float X)
        {
            PointF pos = this.PositionDrawToValue(DrawPoint);
            return this.TurnMatrix.UnshadowPointKnownX(pos, X);
        }

        
        public virtual float DepthValueToDraw(PointF3D ValuePoint)
        {
            return this.TurnMatrix.DepthPoint(ValuePoint);
        }

     
        private const int ImageDefaultWidth = 1200;

         
        private const int ImageDefaultHeight = 1000;

       
        protected Bitmap uImageFunction;

        
        protected Bitmap uImagePoint;

         
        protected DrawRange uRangeX;

        
        protected DrawRange uRangeY;

        
        protected DrawRange uRangeZ;

        
        protected ShadowMatrix mTurnMatrix;

         
        protected DrawRange u2DRangeX;

        
        protected DrawRange u2DRangeY;

        
        protected bool b_DrawLockZoom;

        
        protected float d_DrawEdgePercent;

      
        protected PointF f_DrawOffset;

        
        protected List<DrawBase> list_DrawFunctionPartList;

        
        protected List<DrawBase> list_DrawPointPartList;

        
        public class DrawRange : ICloneable
        {
             
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

           
            public DrawRange(DrawRange Range)
            {
                this.d_Max = 0.0;
                this.d_Min = 0.0;
                this.SetRange(Range);
            }

            
            public virtual double Max
            {
                get
                {
                    return this.d_Max;
                }
                set
                {
                    this.d_Max = value;
                    if (this.d_Min > this.d_Max)
                    {
                        this.d_Min = this.d_Max;
                    }
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
                    if (this.d_Max < this.d_Min)
                    {
                        this.d_Max = this.d_Min;
                    }
                }
            }

            
            public virtual double Length
            {
                get
                {
                    return Math.Abs(this.Max - this.Min);
                }
            }

            
            public virtual bool IsIn(double Mid)
            {
                return Mid >= this.Min & Mid <= this.Max;
            }

            
            public virtual bool IsIn(DrawRange Mid)
            {
                return Mid.Min >= this.Min & Mid.Max <= this.Max;
            }

            
            public virtual void SetRange(double Min, double Max)
            {
                this.Max = Max;
                this.Min = Min;
            }

           
            public virtual void SetRange(DrawFunction3D.DrawRange Range)
            {
                this.SetRange(Range.Min, Range.Max);
            }

            
            public virtual void SetInRange(DrawFunction3D.DrawRange OutRange)
            {
                if (this.Min < OutRange.Min)
                {
                    this.Min = OutRange.Min;
                }
                if (this.Max > OutRange.Max)
                {
                    this.Max = OutRange.Max;
                }
            }

           
            public virtual void SetOutRange(DrawRange InRange)
            {
                if (this.Min > InRange.Min)
                {
                    this.Min = InRange.Min;
                }
                if (this.Max < InRange.Max)
                {
                    this.Max = InRange.Max;
                }
            }

          
            public new string ToString
            {
                get
                {
                    return string.Concat(new string[]
                    {
                        "[",
                        Conversions.ToString(this.Min),
                        ",",
                        Conversions.ToString(this.Max),
                        "]"
                    });
                }
            }

            
            public object Clone()
            {
                return new DrawFunction3D.DrawRange(this);
            }
 
            protected double d_Max;

            
            protected double d_Min;
        }

        
        public class PointF3D : ICloneable
        {
            
            public virtual float X
            {
                get
                {
                    return this.d_X;
                }
                set
                {
                    this.d_X = value;
                }
            }

           
            public virtual float Y
            {
                get
                {
                    return this.d_Y;
                }
                set
                {
                    this.d_Y = value;
                }
            }

          
            public virtual float Z
            {
                get
                {
                    return this.d_Z;
                }
                set
                {
                    this.d_Z = value;
                }
            }

           
            public void SetValue(float X, float Y, float Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }

          
            public PointF3D()
            {
                this.d_X = 0f;
                this.d_Y = 0f;
                this.d_Z = 0f;
                this.SetValue(0f, 0f, 0f);
            }

           
            public PointF3D(float X, float Y, float Z)
            {
                this.d_X = 0f;
                this.d_Y = 0f;
                this.d_Z = 0f;
                this.SetValue(X, Y, Z);
            }

           
            public PointF3D(PointF3D p)
            {
                this.d_X = 0f;
                this.d_Y = 0f;
                this.d_Z = 0f;
                this.SetValue(p.X, p.Y, p.Z);
            }

          
            public override string ToString()
            {
                return string.Concat(new string[]
                {
                    "(",
                    this.X.ToString(),
                    ", ",
                    this.Y.ToString(),
                    ", ",
                    this.Z.ToString(),
                    ")"
                });
            }

           
            public static bool IsSame(PointF3D left, PointF3D right)
            {
                return left.X == right.X & left.Y == right.Y & left.Z == right.Z;
            }

            
            public static bool operator ==(PointF3D left, PointF3D right)
            {
                return IsSame(left, right);
            }

             
            public static bool operator !=(PointF3D left, PointF3D right)
            {
                return !IsSame(left, right);
            }

            
            public static PointF3D Add(PointF3D left, PointF3D right)
            {
                return new PointF3D(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
            }

             
            public static PointF3D operator +(PointF3D left, PointF3D right)
            {
                return Add(left, right);
            }

            
            public static PointF3D Subtract(PointF3D left, PointF3D right)
            {
                return new PointF3D(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
            }

           
            public static PointF3D operator -(PointF3D left, PointF3D right)
            {
                return Subtract(left, right);
            }

            
            public object Clone()
            {
                return new PointF3D(this);
            }

            
            protected float d_X;

            
            protected float d_Y;

             
            protected float d_Z;
        }

        
        public class ShadowMatrix : ICloneable
        {
             
            public static ShadowMatrix FromTurningX(double XDegree)
            {
                ShadowMatrix shadowMatrix = new ShadowMatrix();
                shadowMatrix[0, 0] = 1.0;
                shadowMatrix[1, 1] = Math.Cos(XDegree);
                shadowMatrix[1, 2] = -Math.Sin(XDegree);
                shadowMatrix[2, 1] = Math.Sin(XDegree);
                shadowMatrix[2, 2] = Math.Cos(XDegree);
                shadowMatrix[3, 3] = 1.0;
                return shadowMatrix;
            }

            
            public static ShadowMatrix FromTurningY(double YDegree)
            {
                ShadowMatrix shadowMatrix = new ShadowMatrix();
                shadowMatrix[0, 0] = Math.Cos(YDegree);
                shadowMatrix[0, 2] = -Math.Sin(YDegree);
                shadowMatrix[1, 1] = 1.0;
                shadowMatrix[2, 0] = Math.Sin(YDegree);
                shadowMatrix[2, 2] = Math.Cos(YDegree);
                shadowMatrix[3, 3] = 1.0;
                return shadowMatrix;
            }

            
            public static ShadowMatrix FromTurningZ(double ZDegree)
            {
                ShadowMatrix shadowMatrix = new ShadowMatrix();
                shadowMatrix[0, 0] = Math.Cos(ZDegree);
                shadowMatrix[0, 1] = -Math.Sin(ZDegree);
                shadowMatrix[1, 0] = Math.Sin(ZDegree);
                shadowMatrix[1, 1] = Math.Cos(ZDegree);
                shadowMatrix[2, 2] = 1.0;
                shadowMatrix[3, 3] = 1.0;
                return shadowMatrix;
            }

            
            public static ShadowMatrix FromTurning(double XDegree, double YDegree, double ZDegree)
            {
                ShadowMatrix left = FromTurningX(XDegree);
                ShadowMatrix right = FromTurningY(YDegree);
                ShadowMatrix right2 = FromTurningZ(ZDegree);
                return left * right * right2;
            }

             
            public static ShadowMatrix Multiply(ShadowMatrix Left, ShadowMatrix Right)
            {
                ShadowMatrix shadowMatrix = new ShadowMatrix();
                int num = 0;
                checked
                {
                    int num2 = Left.RowCount - 1;
                    for (int i = num; i <= num2; i++)
                    {
                        int num3 = 0;
                        int num4 = Right.ColCount - 1;
                        for (int j = num3; j <= num4; j++)
                        {
                            double num5 = 0.0;
                            int num6 = 0;
                            int num7 = Left.ColCount - 1;
                            for (int k = num6; k <= num7; k++)
                            {
                                unchecked
                                {
                                    num5 += Left[i, k] * Right[k, j];
                                }
                            }
                            shadowMatrix[i, j] = num5;
                        }
                    }
                    return shadowMatrix;
                }
            }

            
            public static double VerticalityZDegreeZ(ShadowMatrix TurnMatrix)
            {
                double num = TurnMatrix[2, 0];
                double num2 = TurnMatrix[2, 1];
                double result;
                if (num2 == 0.0)
                {
                    result = 1.5707963267948966;
                }
                else
                {
                    result = Math.Atan2(-num, num2);
                }
                return result;
            }

             
            public virtual double VerticalityZDegreeZ()
            {
                return VerticalityZDegreeZ(this);
            }

           
            public static ShadowMatrix operator *(ShadowMatrix Left, ShadowMatrix Right)
            {
                return Multiply(Left, Right);
            }

            
            public static PointF ShadowPoint(PointF3D Pos, ShadowMatrix TurnMatrix)
            {
                return new PointF
                {
                    X = (float)((double)Pos.X * TurnMatrix[0, 0] + (double)Pos.Y * TurnMatrix[1, 0] + (double)Pos.Z * TurnMatrix[2, 0] + TurnMatrix[3, 0]),
                    Y = (float)((double)Pos.X * TurnMatrix[0, 1] + (double)Pos.Y * TurnMatrix[1, 1] + (double)Pos.Z * TurnMatrix[2, 1] + TurnMatrix[3, 1])
                };
            }

            
            public static PointF3D TransformPoint(PointF3D Pos, ShadowMatrix TurnMatrix)
            {
                return new PointF3D
                {
                    X = (float)((double)Pos.X * TurnMatrix[0, 0] + (double)Pos.Y * TurnMatrix[1, 0] + (double)Pos.Z * TurnMatrix[2, 0] + TurnMatrix[3, 0]),
                    Y = (float)((double)Pos.X * TurnMatrix[0, 1] + (double)Pos.Y * TurnMatrix[1, 1] + (double)Pos.Z * TurnMatrix[2, 1] + TurnMatrix[3, 1]),
                    Z = (float)((double)Pos.X * TurnMatrix[0, 2] + (double)Pos.Y * TurnMatrix[1, 2] + (double)Pos.Z * TurnMatrix[2, 2] + TurnMatrix[3, 2])
                };
            }
                
            public static PointF3D operator *(PointF3D Pos, ShadowMatrix TurnMatrix)
            {
                return TransformPoint(Pos, TurnMatrix);
            }

           
            public virtual PointF3D TransformPoint(PointF3D Pos)
            {
                return TransformPoint(Pos, this);
            }

             
            public static float DepthPoint(PointF3D Pos, ShadowMatrix TurnMatrix)
            {
                return (float)((double)Pos.X * TurnMatrix[0, 2] + (double)Pos.Y * TurnMatrix[1, 2] + (double)Pos.Z * TurnMatrix[2, 2] + TurnMatrix[3, 2]);
            }

           
            public float DepthPoint(PointF3D Pos)
            {
                return DepthPoint(Pos, this);
            }

             
            protected static bool Inverse(ref double a, ref double b, ref double c, ref double d)
            {
                double num = a * d - b * c;
                if (num == 0.0)
                {
                    return false;
                }
                double num2 = a;
                double num3 = b;
                double num4 = c;
                double num5 = d;
                a = num5 / num;
                b = -num4 / num;
                c = -num3 / num;
                d = num2 / num;
                return true;
            }

           
            public static PointF3D UnshadowPointKnownZ(PointF Pos, float Z, ShadowMatrix TurnMatrix)
            {
                PointF3D pointF3D = new PointF3D();
                double num = TurnMatrix[0, 0];
                double num2 = TurnMatrix[1, 0];
                double num3 = TurnMatrix[0, 1];
                double num4 = TurnMatrix[1, 1];
                double num5 = (double)Pos.X - TurnMatrix[2, 0] * (double)Z - TurnMatrix[3, 0];
                double num6 = (double)Pos.Y - TurnMatrix[2, 1] * (double)Z - TurnMatrix[3, 1];
                if (Inverse(ref num, ref num2, ref num3, ref num4))
                {
                    pointF3D.X = (float)(num5 * num + num6 * num3);
                    pointF3D.Y = (float)(num5 * num2 + num6 * num4);
                }
                pointF3D.Z = Z;
                return pointF3D;
            }

            
            public static PointF3D UnshadowPointKnownY(PointF Pos, float Y, ShadowMatrix TurnMatrix)
            {
                PointF3D pointF3D = new PointF3D();
                double num = TurnMatrix[0, 0];
                double num2 = TurnMatrix[2, 0];
                double num3 = TurnMatrix[0, 1];
                double num4 = TurnMatrix[2, 1];
                double num5 = (double)Pos.X - TurnMatrix[1, 0] * (double)Y - TurnMatrix[3, 0];
                double num6 = (double)Pos.Y - TurnMatrix[1, 1] * (double)Y - TurnMatrix[3, 1];
                if (Inverse(ref num, ref num2, ref num3, ref num4))
                {
                    pointF3D.X = (float)(num5 * num + num6 * num3);
                    pointF3D.Z = (float)(num5 * num2 + num6 * num4);
                }
                pointF3D.Y = Y;
                return pointF3D;
            }

            
            public static PointF3D UnshadowPointKnownX(PointF Pos, float X, ShadowMatrix TurnMatrix)
            {
                PointF3D pointF3D = new PointF3D();
                double num = TurnMatrix[1, 0];
                double num2 = TurnMatrix[2, 0];
                double num3 = TurnMatrix[1, 1];
                double num4 = TurnMatrix[2, 1];
                double num5 = (double)Pos.X - TurnMatrix[0, 0] * (double)X - TurnMatrix[3, 0];
                double num6 = (double)Pos.Y - TurnMatrix[0, 1] * (double)X - TurnMatrix[3, 1];
                if (Inverse(ref num, ref num2, ref num3, ref num4))
                {
                    pointF3D.Y = (float)(num5 * num + num6 * num3);
                    pointF3D.Z = (float)(num5 * num2 + num6 * num4);
                }
                pointF3D.X = X;
                return pointF3D;
            }

             
            public virtual PointF3D UnshadowPointKnownZ(PointF Pos, float Z)
            {
                return UnshadowPointKnownZ(Pos, Z, this);
            }

            
            public virtual PointF3D UnshadowPointKnownY(PointF Pos, float Y)
            {
                return UnshadowPointKnownY(Pos, Y, this);
            }

           
            public virtual PointF3D UnshadowPointKnownX(PointF Pos, float X)
            {
                return UnshadowPointKnownX(Pos, X, this);
            }

             
            public virtual PointF ShadowPoint(PointF3D Pos)
            {
                return ShadowPoint(Pos, this);
            }

            
            [IndexerName("Cell")]
            public virtual double this[int i, int j]
            {
                get
                {
                    return this.d_Cell[i, j];
                }
                set
                {
                    this.d_Cell[i, j] = value;
                }
            }

            
            public virtual int RowCount
            {
                get
                {
                    return checked(this.d_Cell.GetUpperBound(0) + 1);
                }
            }

            
            public virtual int ColCount
            {
                get
                {
                    return checked(this.d_Cell.GetUpperBound(1) + 1);
                }
            }

            
            public virtual bool IsIn(int Row, int Col)
            {
                return Row >= 0 & Row < this.RowCount & Col >= 0 & Col < this.ColCount;
            }

           
            public virtual double[,] ToArray()
            {
                return (double[,])this.d_Cell.Clone();
            }

            
            public virtual object Clone()
            {
                return new ShadowMatrix(this);
            }

          
            public ShadowMatrix()
            {
                this.d_Cell = new double[4, 4];
                int num = 0;
                checked
                {
                    int num2 = this.RowCount - 1;
                    for (int i = num; i <= num2; i++)
                    {
                        this[i, i] = 1.0;
                    }
                }
            }

             
            public ShadowMatrix(ShadowMatrix SM)
            {
                this.d_Cell = new double[4, 4];
                this.d_Cell = SM.ToArray();
            }

             
            protected double[,] d_Cell;
        }
    }
}
