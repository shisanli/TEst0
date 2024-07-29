using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class FillEllipses : DrawListPoints
    {
        // Token: 0x060002F6 RID: 758 RVA: 0x0000B1F0 File Offset: 0x000095F0
        public FillEllipses(DrawFunction3D IndexDrawFunction)
        {
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        // Token: 0x060002F7 RID: 759 RVA: 0x0000B220 File Offset: 0x00009620
        public FillEllipses(DrawFunction3D IndexDrawFunction, Brush DrawBrush)
        {
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
        }

        // Token: 0x060002F8 RID: 760 RVA: 0x0000B258 File Offset: 0x00009658
        public FillEllipses(DrawFunction3D IndexDrawFunction, Brush DrawBrush, float DrawWidth, float DrawHeight, DrawFunction3D.PointF3D[] PointList)
        {
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
            this.PointList = PointList;
            this.DrawWidth = DrawWidth;
            this.DrawHeight = DrawHeight;
        }

        // Token: 0x17000109 RID: 265
        // (get) Token: 0x060002F9 RID: 761 RVA: 0x0000B2B4 File Offset: 0x000096B4
        // (set) Token: 0x060002FA RID: 762 RVA: 0x0000B2C8 File Offset: 0x000096C8
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

        // Token: 0x1700010A RID: 266
        // (get) Token: 0x060002FB RID: 763 RVA: 0x0000B2D4 File Offset: 0x000096D4
        // (set) Token: 0x060002FC RID: 764 RVA: 0x0000B2E8 File Offset: 0x000096E8
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

        // Token: 0x1700010B RID: 267
        // (get) Token: 0x060002FD RID: 765 RVA: 0x0000B2F4 File Offset: 0x000096F4
        // (set) Token: 0x060002FE RID: 766 RVA: 0x0000B308 File Offset: 0x00009708
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

        // Token: 0x060002FF RID: 767 RVA: 0x0000B314 File Offset: 0x00009714
        public override void DrawPart(Graphics DrawGraph)
        {
            checked
            {
                if (this.PointList.Length > 0 & this.IndexDrawFunction != null)
                {
                    PointF pointF = default(PointF);
                    int num = 0;
                    int num2 = this.PointList.Length - 1;
                    for (int i = num; i <= num2; i++)
                    {
                        pointF = this.IndexDrawFunction.PositionValueToDraw(this.PointList[i]);
                        unchecked
                        {
                            DrawGraph.FillEllipse(this.DrawBrush, pointF.X - this.DrawWidth / 2f, pointF.Y - this.DrawHeight / 2f, this.DrawWidth, this.DrawHeight);
                        }
                    }
                }
            }
        }

        // Token: 0x06000300 RID: 768 RVA: 0x0000B3B0 File Offset: 0x000097B0
        public override object Clone()
        {
            return new FillEllipses(this.IndexDrawFunction, (Brush)this.DrawBrush.Clone(), this.DrawWidth, this.DrawHeight, this.ClonePointList());
        }

        // Token: 0x04000116 RID: 278
        protected float f_DrawWidth;

        // Token: 0x04000117 RID: 279
        protected float f_DrawHeight;

        // Token: 0x04000118 RID: 280
        protected Brush brush_DrawBrush;
    }
}
