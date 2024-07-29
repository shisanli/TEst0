using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class DrawPolygon : DrawListPoints
    {
        // Token: 0x060002B2 RID: 690 RVA: 0x0000A614 File Offset: 0x00008A14
        public DrawPolygon(DrawFunction3D IndexDrawFunction)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        // Token: 0x060002B3 RID: 691 RVA: 0x0000A630 File Offset: 0x00008A30
        public DrawPolygon(DrawFunction3D IndexDrawFunction, Pen DrawPen)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
        }

        // Token: 0x060002B4 RID: 692 RVA: 0x0000A654 File Offset: 0x00008A54
        public DrawPolygon(DrawFunction3D IndexDrawFunction, Pen DrawPen, DrawFunction3D.PointF3D[] PointList)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
            this.PointList = PointList;
        }

        // Token: 0x170000F5 RID: 245
        // (get) Token: 0x060002B5 RID: 693 RVA: 0x0000A67C File Offset: 0x00008A7C
        // (set) Token: 0x060002B6 RID: 694 RVA: 0x0000A690 File Offset: 0x00008A90
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

        // Token: 0x060002B7 RID: 695 RVA: 0x0000A69C File Offset: 0x00008A9C
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
                    DrawGraph.DrawPolygon(this.DrawPen, array);
                }
            }
        }

        // Token: 0x060002B8 RID: 696 RVA: 0x0000A718 File Offset: 0x00008B18
        public override object Clone()
        {
            return new DrawPolygon(this.IndexDrawFunction, (Pen)this.DrawPen.Clone(), this.ClonePointList());
        }

        // Token: 0x04000105 RID: 261
        protected Pen pen_DrawPen;
    }
}
