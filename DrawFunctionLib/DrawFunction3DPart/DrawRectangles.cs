using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class DrawRectangles : DrawListPoints
    {
        // Token: 0x060002C7 RID: 711 RVA: 0x0000A994 File Offset: 0x00008D94
        public DrawRectangles(DrawFunction3D IndexDrawFunction)
        {
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        // Token: 0x060002C8 RID: 712 RVA: 0x0000A9C4 File Offset: 0x00008DC4
        public DrawRectangles(DrawFunction3D IndexDrawFunction, Pen DrawPen)
        {
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
        }

        // Token: 0x060002C9 RID: 713 RVA: 0x0000A9FC File Offset: 0x00008DFC
        public DrawRectangles(DrawFunction3D IndexDrawFunction, Pen DrawPen, float DrawWidth, float DrawHeight, DrawFunction3D.PointF3D[] PointList)
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

        // Token: 0x170000FB RID: 251
        // (get) Token: 0x060002CA RID: 714 RVA: 0x0000AA58 File Offset: 0x00008E58
        // (set) Token: 0x060002CB RID: 715 RVA: 0x0000AA6C File Offset: 0x00008E6C
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

        // Token: 0x170000FC RID: 252
        // (get) Token: 0x060002CC RID: 716 RVA: 0x0000AA78 File Offset: 0x00008E78
        // (set) Token: 0x060002CD RID: 717 RVA: 0x0000AA8C File Offset: 0x00008E8C
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

        // Token: 0x170000FD RID: 253
        // (get) Token: 0x060002CE RID: 718 RVA: 0x0000AA98 File Offset: 0x00008E98
        // (set) Token: 0x060002CF RID: 719 RVA: 0x0000AAAC File Offset: 0x00008EAC
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

        // Token: 0x060002D0 RID: 720 RVA: 0x0000AAB8 File Offset: 0x00008EB8
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
                            DrawGraph.DrawRectangle(this.DrawPen, pointF.X - this.DrawWidth / 2f, pointF.Y - this.DrawHeight / 2f, this.DrawWidth, this.DrawHeight);
                        }
                    }
                }
            }
        }

        // Token: 0x060002D1 RID: 721 RVA: 0x0000AB4C File Offset: 0x00008F4C
        public override object Clone()
        {
            return new DrawRectangles(this.IndexDrawFunction, (Pen)this.DrawPen.Clone(), this.DrawWidth, this.DrawHeight, this.ClonePointList());
        }

        // Token: 0x0400010A RID: 266
        protected float f_DrawWidth;

        // Token: 0x0400010B RID: 267
        protected float f_DrawHeight;

        // Token: 0x0400010C RID: 268
        protected Pen pen_DrawPen;
    }
}
