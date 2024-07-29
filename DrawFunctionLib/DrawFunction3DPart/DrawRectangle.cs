using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class DrawRectangle : DrawBase
    {
        // Token: 0x060002B9 RID: 697 RVA: 0x0000A748 File Offset: 0x00008B48
        public DrawRectangle(DrawFunction3D IndexDrawFunction)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        // Token: 0x060002BA RID: 698 RVA: 0x0000A784 File Offset: 0x00008B84
        public DrawRectangle(DrawFunction3D IndexDrawFunction, Pen DrawPen)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
        }

        // Token: 0x060002BB RID: 699 RVA: 0x0000A7D4 File Offset: 0x00008BD4
        public DrawRectangle(DrawFunction3D IndexDrawFunction, Pen DrawPen, DrawFunction3D.PointF3D DrawPoint, float DrawWidth, float DrawHeight)
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

        // Token: 0x170000F6 RID: 246
        // (get) Token: 0x060002BC RID: 700 RVA: 0x0000A838 File Offset: 0x00008C38
        // (set) Token: 0x060002BD RID: 701 RVA: 0x0000A84C File Offset: 0x00008C4C
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

        // Token: 0x170000F7 RID: 247
        // (get) Token: 0x060002BE RID: 702 RVA: 0x0000A858 File Offset: 0x00008C58
        // (set) Token: 0x060002BF RID: 703 RVA: 0x0000A86C File Offset: 0x00008C6C
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

        // Token: 0x170000F8 RID: 248
        // (get) Token: 0x060002C0 RID: 704 RVA: 0x0000A878 File Offset: 0x00008C78
        // (set) Token: 0x060002C1 RID: 705 RVA: 0x0000A88C File Offset: 0x00008C8C
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

        // Token: 0x170000F9 RID: 249
        // (get) Token: 0x060002C2 RID: 706 RVA: 0x0000A898 File Offset: 0x00008C98
        // (set) Token: 0x060002C3 RID: 707 RVA: 0x0000A8AC File Offset: 0x00008CAC
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

        // Token: 0x170000FA RID: 250
        // (get) Token: 0x060002C4 RID: 708 RVA: 0x0000A8B8 File Offset: 0x00008CB8
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

        // Token: 0x060002C5 RID: 709 RVA: 0x0000A8E8 File Offset: 0x00008CE8
        public override void DrawPart(Graphics DrawGraph)
        {
            if (this.IndexDrawFunction != null)
            {
                PointF pointF = this.IndexDrawFunction.PositionValueToDraw(this.DrawPoint);
                DrawGraph.DrawRectangle(this.DrawPen, pointF.X - this.DrawWidth / 2f, pointF.Y - this.DrawHeight / 2f, this.DrawWidth, this.DrawHeight);
            }
        }

        // Token: 0x060002C6 RID: 710 RVA: 0x0000A950 File Offset: 0x00008D50
        public override object Clone()
        {
            return new DrawRectangle(this.IndexDrawFunction, (Pen)this.DrawPen.Clone(), (DrawFunction3D.PointF3D)this.DrawPoint.Clone(), this.DrawWidth, this.DrawHeight);
        }

        // Token: 0x04000106 RID: 262
        protected DrawFunction3D.PointF3D p_DrawPoint;

        // Token: 0x04000107 RID: 263
        protected float f_DrawWidth;

        // Token: 0x04000108 RID: 264
        protected float f_DrawHeight;

        // Token: 0x04000109 RID: 265
        protected Pen pen_DrawPen;
    }
}
