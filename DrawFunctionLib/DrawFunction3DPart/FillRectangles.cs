using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class FillRectangles : DrawListPoints
    {
        // Token: 0x06000316 RID: 790 RVA: 0x0000B76C File Offset: 0x00009B6C
        public FillRectangles(DrawFunction3D IndexDrawFunction)
        {
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        // Token: 0x06000317 RID: 791 RVA: 0x0000B79C File Offset: 0x00009B9C
        public FillRectangles(DrawFunction3D IndexDrawFunction, Brush DrawBrush)
        {
            this.f_DrawWidth = 1f;
            this.f_DrawHeight = 1f;
            this.brush_DrawBrush = Brushes.Blue;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
        }

       
        public FillRectangles(DrawFunction3D IndexDrawFunction, Brush DrawBrush, float DrawWidth, float DrawHeight, DrawFunction3D.PointF3D[] PointList)
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

        // Token: 0x17000112 RID: 274
        // (get) Token: 0x06000319 RID: 793 RVA: 0x0000B830 File Offset: 0x00009C30
        // (set) Token: 0x0600031A RID: 794 RVA: 0x0000B844 File Offset: 0x00009C44
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

        // Token: 0x17000113 RID: 275
        // (get) Token: 0x0600031B RID: 795 RVA: 0x0000B850 File Offset: 0x00009C50
        // (set) Token: 0x0600031C RID: 796 RVA: 0x0000B864 File Offset: 0x00009C64
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

        // Token: 0x17000114 RID: 276
        // (get) Token: 0x0600031D RID: 797 RVA: 0x0000B870 File Offset: 0x00009C70
        // (set) Token: 0x0600031E RID: 798 RVA: 0x0000B884 File Offset: 0x00009C84
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

        // Token: 0x0600031F RID: 799 RVA: 0x0000B890 File Offset: 0x00009C90
        public override void DrawPart(Graphics DrawGraph)
        {
            checked
            {
                if (this.PointList.Length > 0 & this.IndexDrawFunction != null)
                {
                    RectangleF[] array = new RectangleF[this.PointList.Length - 1 + 1];
                    int num = 0;
                    int num2 = this.PointList.Length - 1;
                    for (int i = num; i <= num2; i++)
                    {
                        array[i].Location = this.IndexDrawFunction.PositionValueToDraw(this.PointList[i]);
                        array[i].Width = this.DrawWidth;
                        array[i].Height = this.DrawHeight;
                    }
                    DrawGraph.FillRectangles(this.DrawBrush, array);
                }
            }
        }

        // Token: 0x06000320 RID: 800 RVA: 0x0000B930 File Offset: 0x00009D30
        public override object Clone()
        {
            return new FillRectangles(this.IndexDrawFunction, (Brush)this.DrawBrush.Clone(), this.DrawWidth, this.DrawHeight, this.ClonePointList());
        }

        // Token: 0x0400011E RID: 286
        protected float f_DrawWidth;

        // Token: 0x0400011F RID: 287
        protected float f_DrawHeight;

        // Token: 0x04000120 RID: 288
        protected Brush brush_DrawBrush;
    }
}
