using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class FillRectangle : DrawBase
    {
        // Token: 0x06000308 RID: 776 RVA: 0x0000B520 File Offset: 0x00009920
        public FillRectangle(DrawFunction3D IndexDrawFunction)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        // Token: 0x06000309 RID: 777 RVA: 0x0000B55C File Offset: 0x0000995C
        public FillRectangle(DrawFunction3D IndexDrawFunction, Brush DrawBrush)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
        }

        // Token: 0x0600030A RID: 778 RVA: 0x0000B5AC File Offset: 0x000099AC
        public FillRectangle(DrawFunction3D IndexDrawFunction, Brush DrawBrush, DrawFunction3D.PointF3D DrawPoint, float DrawWidth, float DrawHeight)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
            this.DrawPoint = DrawPoint;
            this.DrawWidth = DrawWidth;
            this.DrawHeight = DrawHeight;
        }

        // Token: 0x1700010D RID: 269
        // (get) Token: 0x0600030B RID: 779 RVA: 0x0000B610 File Offset: 0x00009A10
        // (set) Token: 0x0600030C RID: 780 RVA: 0x0000B624 File Offset: 0x00009A24
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

        // Token: 0x1700010E RID: 270
        // (get) Token: 0x0600030D RID: 781 RVA: 0x0000B630 File Offset: 0x00009A30
        // (set) Token: 0x0600030E RID: 782 RVA: 0x0000B644 File Offset: 0x00009A44
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

        // Token: 0x1700010F RID: 271
        // (get) Token: 0x0600030F RID: 783 RVA: 0x0000B650 File Offset: 0x00009A50
        // (set) Token: 0x06000310 RID: 784 RVA: 0x0000B664 File Offset: 0x00009A64
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

        // Token: 0x17000110 RID: 272
        // (get) Token: 0x06000311 RID: 785 RVA: 0x0000B670 File Offset: 0x00009A70
        // (set) Token: 0x06000312 RID: 786 RVA: 0x0000B684 File Offset: 0x00009A84
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

        // Token: 0x17000111 RID: 273
        // (get) Token: 0x06000313 RID: 787 RVA: 0x0000B690 File Offset: 0x00009A90
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

        // Token: 0x06000314 RID: 788 RVA: 0x0000B6C0 File Offset: 0x00009AC0
        public override void DrawPart(Graphics DrawGraph)
        {
            if (this.IndexDrawFunction != null)
            {
                PointF pointF = this.IndexDrawFunction.PositionValueToDraw(this.DrawPoint);
                DrawGraph.FillRectangle(this.DrawBrush, pointF.X - this.DrawWidth / 2f, pointF.Y - this.DrawHeight / 2f, this.DrawWidth, this.DrawHeight);
            }
        }

        // Token: 0x06000315 RID: 789 RVA: 0x0000B728 File Offset: 0x00009B28
        public override object Clone()
        {
            return new FillRectangle(this.IndexDrawFunction, (Brush)this.DrawBrush.Clone(), (DrawFunction3D.PointF3D)this.DrawPoint.Clone(), this.DrawWidth, this.DrawHeight);
        }

        // Token: 0x0400011A RID: 282
        protected DrawFunction3D.PointF3D p_DrawPoint;

        // Token: 0x0400011B RID: 283
        protected float f_DrawWidth;

        // Token: 0x0400011C RID: 284
        protected float f_DrawHeight;

        // Token: 0x0400011D RID: 285
        protected Brush brush_DrawBrush;
    }
}
