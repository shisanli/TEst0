using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class DrawBeziers : DrawListPoints
    {
       
        public DrawBeziers(DrawFunction3D IndexDrawFunction)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
        }

         
        public DrawBeziers(DrawFunction3D IndexDrawFunction, Pen DrawPen)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
        }

         
        public DrawBeziers(DrawFunction3D IndexDrawFunction, Pen DrawPen, DrawFunction3D.PointF3D[] PointList)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
            this.PointList = PointList;
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
                    PointF[] array = new PointF[this.PointList.Length - 1 + 1];
                    int num = 0;
                    int num2 = this.PointList.Length - 1;
                    for (int i = num; i <= num2; i++)
                    {
                        array[i] = this.IndexDrawFunction.PositionValueToDraw(this.PointList[i]);
                    }
                    DrawGraph.DrawBeziers(this.DrawPen, array);
                }
            }
        }

        
        public override object Clone()
        {
            return new DrawBeziers(this.IndexDrawFunction, (Pen)this.DrawPen.Clone(), this.ClonePointList());
        }

        
        protected Pen pen_DrawPen;
    }
}
