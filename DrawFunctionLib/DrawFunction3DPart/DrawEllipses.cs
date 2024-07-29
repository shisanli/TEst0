using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class DrawEllipses : DrawListPoints
    {
         
        public DrawEllipses(DrawFunction3D IndexDrawFunction)
        {
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
        }

         
        public DrawEllipses(DrawFunction3D IndexDrawFunction, Pen DrawPen)
        {
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
        }

      
        public DrawEllipses(DrawFunction3D IndexDrawFunction, Pen DrawPen, float DrawWidth, float DrawHeight, DrawFunction3D.PointF3D[] PointList)
        {
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
            this.PointList = PointList;
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

        
        public override void DrawPart(Graphics DrawGraph)
        {
            checked
            {
                if (this.PointList.Length > 0 & this.IndexDrawFunction != null)
                {
                    int num = 0;
                    int num2 = this.PointList.Length - 1;
                    for (int i = num; i <= num2; i++)
                    {
                        PointF pointF = this.IndexDrawFunction.PositionValueToDraw(this.PointList[i]);
                        unchecked
                        {
                            DrawGraph.DrawEllipse(this.DrawPen, pointF.X - this.DrawWidth / 2f, pointF.Y - this.DrawHeight / 2f, this.DrawWidth, this.DrawHeight);
                        }
                    }
                }
            }
        }

        
        public override object Clone()
        {
            return new DrawEllipses(this.IndexDrawFunction, (Pen)this.DrawPen.Clone(), this.DrawWidth, this.DrawHeight, this.ClonePointList());
        }

        
        protected float f_DrawWidth;

      
        protected float f_DrawHeight;

        
        protected Pen pen_DrawPen;
    }
}
