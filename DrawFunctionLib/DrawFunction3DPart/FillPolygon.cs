using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class FillPolygon : DrawListPoints
    {
       
        public FillPolygon(DrawFunction3D IndexDrawFunction)
        {
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        
        public FillPolygon(DrawFunction3D IndexDrawFunction, Brush DrawBrush)
        {
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
        }

        public FillPolygon(DrawFunction3D IndexDrawFunction, Brush DrawBrush, DrawFunction3D.PointF3D[] PointList)
        {
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
            this.PointList = PointList;
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
                    DrawGraph.FillPolygon(this.DrawBrush, array);
                }
            }
        }

       
        public override object Clone()
        {
            return new FillPolygon(this.IndexDrawFunction, (Brush)this.DrawBrush.Clone(), this.ClonePointList());
        }

        // Token: 0x04000119 RID: 281
        protected Brush brush_DrawBrush;
    }
}
