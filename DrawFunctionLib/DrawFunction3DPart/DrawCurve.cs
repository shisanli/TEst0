using System.Drawing;

namespace DrawFunctionLib.DrawFunction3DPart
{
    public class DrawCurve : DrawListPoints
    {
        protected Pen pen_DrawPen;

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

        public DrawCurve(DrawFunction3D IndexDrawFunction)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
        }

        public DrawCurve(DrawFunction3D IndexDrawFunction, Pen DrawPen)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
        }

        public DrawCurve(DrawFunction3D IndexDrawFunction, Pen DrawPen, DrawFunction3D.PointF3D[] PointList)
        {
            this.pen_DrawPen = Pens.Black;
            this.IndexDrawFunction = IndexDrawFunction;
            this.DrawPen = DrawPen;
            this.PointList = PointList;
        }

        public override void DrawPart(Graphics DrawGraph)
        {
            if (!(this.PointList.Length > 0 & this.IndexDrawFunction != null))
                return;
            PointF[] points = new PointF[checked(this.PointList.Length - 1 + 1)];
            int num1 = 0;
            int num2 = checked(this.PointList.Length - 1);
            int index = num1;
            while (index <= num2)
            {
                points[index] = this.IndexDrawFunction.PositionValueToDraw(this.PointList[index]);
                checked { ++index; }
            }
            DrawGraph.DrawCurve(this.DrawPen, points);
        }

        public override object Clone()
        {
            return (object)new DrawBeziers(this.IndexDrawFunction, (Pen)this.DrawPen.Clone(), this.ClonePointList());
        }
    }
}
