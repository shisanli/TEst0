using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class DrawString : DrawBase
    {
        protected DrawFunction3D.PointF3D p_DrawPoint;
        protected string str_DrawString;
        protected Brush brush_DrawBrush;
        protected Font font_DrawFont;

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

        public virtual string DrawStringA 
        {
            get
            {
                return this.str_DrawString;
            }
            set
            {
                this.str_DrawString = value;
            }
        }

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

        public virtual Font DrawFont
        {
            get
            {
                return this.font_DrawFont;
            }
            set
            {
                if (value == null)
                    return;
                this.font_DrawFont = value;
            }
        }

        public override float Depth
        {
            get
            {
                float num = 0.0f;
                if (this.IndexDrawFunction != null)
                    num = this.IndexDrawFunction.DepthValueToDraw(this.DrawPoint);
                return num;
            }
        }

        public DrawString(DrawFunction3D IndexDrawFunction)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.str_DrawString = "";
            this.brush_DrawBrush = Brushes.Black;
            this.font_DrawFont = new Font("Comic Sans MS", 13.5f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.IndexDrawFunction = IndexDrawFunction;
        }

        public DrawString(DrawFunction3D IndexDrawFunction, Brush DrawBrush)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.str_DrawString = "";
            this.brush_DrawBrush = Brushes.Black;
            this.font_DrawFont = new Font("Comic Sans MS", 13.5f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
        }

        public DrawString(DrawFunction3D IndexDrawFunction, string DrawString, Brush DrawBrush, DrawFunction3D.PointF3D DrawPoint)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.str_DrawString = "";
            this.brush_DrawBrush = Brushes.Black;
            this.font_DrawFont = new Font("Comic Sans MS", 13.5f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
            this.DrawPoint = DrawPoint;
            this.DrawStringA = DrawString;
        }

        public DrawString(DrawFunction3D IndexDrawFunction, string DrawString, Font DrawFont, Brush DrawBrush, DrawFunction3D.PointF3D DrawPoint)
        {
            this.p_DrawPoint = new DrawFunction3D.PointF3D();
            this.str_DrawString = "";
            this.brush_DrawBrush = Brushes.Black;
            this.font_DrawFont = new Font("Comic Sans MS", 13.5f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawBrush = DrawBrush;
            this.DrawPoint = DrawPoint;
            this.DrawStringA = DrawString;
            this.DrawStringA = DrawString;
        }

        public override void DrawPart(Graphics DrawGraph)
        {
            if (this.IndexDrawFunction == null)
                return;
            PointF draw = this.IndexDrawFunction.PositionValueToDraw(this.DrawPoint);
            DrawGraph.DrawString(this.DrawStringA, this.DrawFont, this.DrawBrush, draw.X, draw.Y);
        }

        public override object Clone()
        {
            return (object)new DrawFunctionLib.DrawFunction3DPart.DrawString(this.IndexDrawFunction, Conversions.ToString(this.DrawStringA.Clone()), (Font)this.DrawFont.Clone(), (Brush)this.DrawBrush.Clone(), (DrawFunction3D.PointF3D)this.DrawPoint.Clone());
        }
    }
}
