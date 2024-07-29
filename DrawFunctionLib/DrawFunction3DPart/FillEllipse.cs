using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class FillEllipse : DrawBase
    {
        // Token: 0x060002E8 RID: 744 RVA: 0x0000AFA4 File Offset: 0x000093A4
        public FillEllipse(DrawFunction3D IndexDrawFunction)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        // Token: 0x060002E9 RID: 745 RVA: 0x0000AFE0 File Offset: 0x000093E0
        public FillEllipse(DrawFunction3D IndexDrawFunction, Brush DrawBrush)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
        }

        // Token: 0x060002EA RID: 746 RVA: 0x0000B030 File Offset: 0x00009430
        public FillEllipse(DrawFunction3D IndexDrawFunction, Brush DrawBrush, DrawFunction3D.PointF3D DrawPoint, float DrawWidth, float DrawHeight)
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

        // Token: 0x17000104 RID: 260
        // (get) Token: 0x060002EB RID: 747 RVA: 0x0000B094 File Offset: 0x00009494
        // (set) Token: 0x060002EC RID: 748 RVA: 0x0000B0A8 File Offset: 0x000094A8
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

        // Token: 0x17000105 RID: 261
        // (get) Token: 0x060002ED RID: 749 RVA: 0x0000B0B4 File Offset: 0x000094B4
        // (set) Token: 0x060002EE RID: 750 RVA: 0x0000B0C8 File Offset: 0x000094C8
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

        // Token: 0x17000106 RID: 262
        // (get) Token: 0x060002EF RID: 751 RVA: 0x0000B0D4 File Offset: 0x000094D4
        // (set) Token: 0x060002F0 RID: 752 RVA: 0x0000B0E8 File Offset: 0x000094E8
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

        // Token: 0x17000107 RID: 263
        // (get) Token: 0x060002F1 RID: 753 RVA: 0x0000B0F4 File Offset: 0x000094F4
        // (set) Token: 0x060002F2 RID: 754 RVA: 0x0000B108 File Offset: 0x00009508
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

        // Token: 0x17000108 RID: 264
        // (get) Token: 0x060002F3 RID: 755 RVA: 0x0000B114 File Offset: 0x00009514
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

        // Token: 0x060002F4 RID: 756 RVA: 0x0000B144 File Offset: 0x00009544
        public override void DrawPart(Graphics DrawGraph)
        {
            if (this.IndexDrawFunction != null)
            {
                PointF pointF = this.IndexDrawFunction.PositionValueToDraw(this.DrawPoint);
                DrawGraph.FillEllipse(this.DrawBrush, pointF.X - this.DrawWidth / 2f, pointF.Y - this.DrawHeight / 2f, this.DrawWidth, this.DrawHeight);
            }
        }

        // Token: 0x060002F5 RID: 757 RVA: 0x0000B1AC File Offset: 0x000095AC
        public override object Clone()
        {
            return new FillEllipse(this.IndexDrawFunction, (Brush)this.DrawBrush.Clone(), (DrawFunction3D.PointF3D)this.DrawPoint.Clone(), this.DrawWidth, this.DrawHeight);
        }

        // Token: 0x04000112 RID: 274
        protected DrawFunction3D.PointF3D p_DrawPoint;

        // Token: 0x04000113 RID: 275
        protected float f_DrawWidth;

        // Token: 0x04000114 RID: 276
        protected float f_DrawHeight;

        // Token: 0x04000115 RID: 277
        protected Brush brush_DrawBrush;
    }
}
