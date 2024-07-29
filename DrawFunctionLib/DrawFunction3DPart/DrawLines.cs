using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class DrawLines : DrawListPoints
    {
         
        public DrawLines(DrawFunction3D IndexDrawFunction)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
        }

       
        public DrawLines(DrawFunction3D IndexDrawFunction, Pen DrawPen)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
        }

        // Token: 0x060002AD RID: 685 RVA: 0x0000A520 File Offset: 0x00008920
        public DrawLines(DrawFunction3D IndexDrawFunction, Pen DrawPen, DrawFunction3D.PointF3D[] PointList)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
            this.PointList = PointList;
        }

        // Token: 0x170000F4 RID: 244
        // (get) Token: 0x060002AE RID: 686 RVA: 0x0000A548 File Offset: 0x00008948
        // (set) Token: 0x060002AF RID: 687 RVA: 0x0000A55C File Offset: 0x0000895C
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

        // Token: 0x060002B0 RID: 688 RVA: 0x0000A568 File Offset: 0x00008968
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
                    DrawGraph.DrawLines(this.DrawPen, array);
                }
            }
        }

        // Token: 0x060002B1 RID: 689 RVA: 0x0000A5E4 File Offset: 0x000089E4
        public override object Clone()
        {
            return new DrawLines(this.IndexDrawFunction, (Pen)this.DrawPen.Clone(), this.ClonePointList());
        }

        // Token: 0x04000104 RID: 260
        protected Pen pen_DrawPen;
    }
}
