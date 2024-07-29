using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class DrawEllipse : DrawBase
    {
        
        public DrawEllipse(DrawFunction3D IndexDrawFunction)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
        }

         
        public DrawEllipse(DrawFunction3D IndexDrawFunction, Pen DrawPen)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
        }

      
        public DrawEllipse(DrawFunction3D IndexDrawFunction, Pen DrawPen, DrawFunction3D.PointF3D DrawPoint, float DrawWidth, float DrawHeight)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
            this.DrawPoint = DrawPoint;
            this.DrawWidth = DrawWidth;
            this.DrawHeight = DrawHeight;
        }

        
        public virtual float DrawWidth
        {
            get
            {
                return this.f_DrawWidth;
            }
            set
            {
                this.f_DrawWidth = value;
            }
        }

        
        public virtual float DrawHeight
        {
            get
            {
                return this.f_DrawHeight;
            }
            set
            {
                this.f_DrawHeight = value;
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

         
        public virtual DrawFunction3D.PointF3D DrawPoint
        {
            get
            {
                return this.p_DrawPoint;
            }
            set
            {
                this.p_DrawPoint = value;
            }
        }

         
        public override float Depth
        {
            get
            {
                float result = 0f;
                if (this.IndexDrawFunction != null)
                {
                    result = this.IndexDrawFunction.DepthValueToDraw(this.DrawPoint);
                }
                return result;
            }
        }

        
        public override void DrawPart(Graphics DrawGraph)
        {
            if (this.IndexDrawFunction != null)
            {
                PointF pointF = this.IndexDrawFunction.PositionValueToDraw(this.DrawPoint);
                DrawGraph.DrawEllipse(this.DrawPen, pointF.X - this.DrawWidth / 2f, pointF.Y - this.DrawHeight / 2f, this.DrawWidth, this.DrawHeight);
            }
        }

        
        public override object Clone()
        {
            return new DrawEllipse(this.IndexDrawFunction, (Pen)this.DrawPen.Clone(), (DrawFunction3D.PointF3D)this.DrawPoint.Clone(), this.DrawWidth, this.DrawHeight);
        }

        
        protected DrawFunction3D.PointF3D p_DrawPoint;

       
        protected float f_DrawWidth;

         
        protected float f_DrawHeight;

         
        protected Pen pen_DrawPen;
    }
}
