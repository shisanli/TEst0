using System;
using System.Drawing;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class DrawLine : DrawBase
    {
        protected DrawFunction3D.PointF3D p_StartPoint;
        protected DrawFunction3D.PointF3D p_EndPoint;
        protected Pen pen_DrawPen;

        public virtual DrawFunction3D.PointF3D StartPoint
        {
            get
            {
                return this.p_StartPoint;
            }
            set
            {
                this.p_StartPoint = value;
            }
        }

        public virtual DrawFunction3D.PointF3D EndPoint
        {
            get
            {
                return this.p_EndPoint;
            }
            set
            {
                this.p_EndPoint = value;
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

        public override float Depth
        {
            get
            {
                float num = 0.0f;
                if (this.IndexDrawFunction != null)
                    num = Math.Min(this.IndexDrawFunction.DepthValueToDraw(this.StartPoint), this.IndexDrawFunction.DepthValueToDraw(this.EndPoint));
                return num;
            }
        }

        public DrawLine(DrawFunction3D IndexDrawFunction)
        {
            this.p_StartPoint = new DrawFunction3D.PointF3D();
            this.p_EndPoint = new DrawFunction3D.PointF3D();
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        public DrawLine(DrawFunction3D IndexDrawFunction, Pen DrawPen)
        {
            this.p_StartPoint = new DrawFunction3D.PointF3D();
            this.p_EndPoint = new DrawFunction3D.PointF3D();
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
        }

        public DrawLine(DrawFunction3D IndexDrawFunction, Pen DrawPen, DrawFunction3D.PointF3D StartPoint, DrawFunction3D.PointF3D EndPoint)
        {
            this.p_StartPoint = new DrawFunction3D.PointF3D();
            this.p_EndPoint = new DrawFunction3D.PointF3D();
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
        }

        public override void DrawPart(Graphics DrawGraph)
        {
            if (this.IndexDrawFunction == null)
                return;
            PointF draw1 = this.IndexDrawFunction.PositionValueToDraw(this.StartPoint);
            PointF draw2 = this.IndexDrawFunction.PositionValueToDraw(this.EndPoint);
            DrawGraph.DrawLine(this.DrawPen, draw1.X, draw1.Y, draw2.X, draw2.Y);
        }

        public override object Clone()
        {
            return (object)new DrawLine(this.IndexDrawFunction, (Pen)this.DrawPen.Clone(), (DrawFunction3D.PointF3D)this.StartPoint.Clone(), (DrawFunction3D.PointF3D)this.EndPoint.Clone());
        }
    }
}
