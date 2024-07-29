using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class FillClosedCurve : DrawListPoints
    {
        // Token: 0x060002E1 RID: 737 RVA: 0x0000AE70 File Offset: 0x00009270
        public FillClosedCurve(DrawFunction3D IndexDrawFunction)
        {
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        // Token: 0x060002E2 RID: 738 RVA: 0x0000AE8C File Offset: 0x0000928C
        public FillClosedCurve(DrawFunction3D IndexDrawFunction, Brush DrawBrush)
        {
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
        }

        // Token: 0x060002E3 RID: 739 RVA: 0x0000AEB0 File Offset: 0x000092B0
        public FillClosedCurve(DrawFunction3D IndexDrawFunction, Brush DrawBrush, DrawFunction3D.PointF3D[] PointList)
        {
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
            this.PointList = PointList;
        }

        // Token: 0x17000103 RID: 259
        // (get) Token: 0x060002E4 RID: 740 RVA: 0x0000AED8 File Offset: 0x000092D8
        // (set) Token: 0x060002E5 RID: 741 RVA: 0x0000AEEC File Offset: 0x000092EC
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

        // Token: 0x060002E6 RID: 742 RVA: 0x0000AEF8 File Offset: 0x000092F8
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
                    DrawGraph.FillClosedCurve(this.DrawBrush, array);
                }
            }
        }

        // Token: 0x060002E7 RID: 743 RVA: 0x0000AF74 File Offset: 0x00009374
        public override object Clone()
        {
            return new FillClosedCurve(this.IndexDrawFunction, (Brush)this.DrawBrush.Clone(), this.ClonePointList());
        }

        // Token: 0x04000111 RID: 273
        protected Brush brush_DrawBrush;
    }
}
