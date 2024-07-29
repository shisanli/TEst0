using DrawFunctionLib.DrawFunction3DPart;
using System.Drawing;

namespace DrawFunctionLib.DrawFunction3DModel
{
    public class FillCube : DrawBase
    {
        protected CubeSettings uCubeSettings;
        protected FillPolygon drawpart_0;
        protected FillPolygon drawpart_1;
        protected FillPolygon drawpart_2;
        protected FillPolygon drawpart_3;
        protected FillPolygon drawpart_4;
        protected FillPolygon drawpart_5;

        public virtual FillCube.CubeSettings DrawCubeSettings
        {
            get
            {
                return this.uCubeSettings;
            }
            set
            {
                this.uCubeSettings = value;
            }
        }

        public virtual FillPolygon DrawPart0
        {
            get
            {
                return this.drawpart_0;
            }
        }

        public virtual FillPolygon DrawPart1
        {
            get
            {
                return this.drawpart_1;
            }
        }

        public virtual FillPolygon DrawPart2
        {
            get
            {
                return this.drawpart_2;
            }
        }

        public virtual FillPolygon DrawPart3
        {
            get
            {
                return this.drawpart_3;
            }
        }

        public virtual FillPolygon DrawPart4
        {
            get
            {
                return this.drawpart_4;
            }
        }

        public virtual FillPolygon DrawPart5
        {
            get
            {
                return this.drawpart_5;
            }
        }

        public override DrawBase.ModelType ModelStyle
        {
            get
            {
                return DrawBase.ModelType.Fixed;
            }
        }

        public FillCube(DrawFunction3D IndexDrawFunction)
        {
            this.uCubeSettings = new FillCube.CubeSettings();
            this.drawpart_0 = new FillPolygon((DrawFunction3D)null);
            this.drawpart_1 = new FillPolygon((DrawFunction3D)null);
            this.drawpart_2 = new FillPolygon((DrawFunction3D)null);
            this.drawpart_3 = new FillPolygon((DrawFunction3D)null);
            this.drawpart_4 = new FillPolygon((DrawFunction3D)null);
            this.drawpart_5 = new FillPolygon((DrawFunction3D)null);
            this.IndexDrawFunction = IndexDrawFunction;
        }

        protected void InitialPart()
        {
            FillCube.CubeSettings drawCubeSettings = this.DrawCubeSettings;
            this.drawpart_0.IndexDrawFunction = this.IndexDrawFunction;
            this.drawpart_1.IndexDrawFunction = this.IndexDrawFunction;
            this.drawpart_2.IndexDrawFunction = this.IndexDrawFunction;
            this.drawpart_3.IndexDrawFunction = this.IndexDrawFunction;
            this.drawpart_4.IndexDrawFunction = this.IndexDrawFunction;
            this.drawpart_5.IndexDrawFunction = this.IndexDrawFunction;
            this.drawpart_0.DrawBrush = drawCubeSettings.DrawBrush;
            this.drawpart_1.DrawBrush = drawCubeSettings.DrawBrush;
            this.drawpart_2.DrawBrush = drawCubeSettings.DrawBrush;
            this.drawpart_3.DrawBrush = drawCubeSettings.DrawBrush;
            this.drawpart_4.DrawBrush = drawCubeSettings.DrawBrush;
            this.drawpart_5.DrawBrush = drawCubeSettings.DrawBrush;
            this.drawpart_0.PointList = new DrawFunction3D.PointF3D[4]
            {
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), (float) (-(double) drawCubeSettings.OffsetY / 2.0), (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), drawCubeSettings.OffsetY / 2f, (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, drawCubeSettings.OffsetY / 2f, (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, (float) (-(double) drawCubeSettings.OffsetY / 2.0), (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint
            };
            this.drawpart_1.PointList = new DrawFunction3D.PointF3D[4]
            {
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), (float) (-(double) drawCubeSettings.OffsetY / 2.0), drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), drawCubeSettings.OffsetY / 2f, drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, drawCubeSettings.OffsetY / 2f, drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, (float) (-(double) drawCubeSettings.OffsetY / 2.0), drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint
            };
            this.drawpart_2.PointList = new DrawFunction3D.PointF3D[4]
            {
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), (float) (-(double) drawCubeSettings.OffsetY / 2.0), (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), (float) (-(double) drawCubeSettings.OffsetY / 2.0), drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), drawCubeSettings.OffsetY / 2f, drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), drawCubeSettings.OffsetY / 2f, (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint
            };
            this.drawpart_3.PointList = new DrawFunction3D.PointF3D[4]
            {
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, (float) (-(double) drawCubeSettings.OffsetY / 2.0), (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, (float) (-(double) drawCubeSettings.OffsetY / 2.0), drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, drawCubeSettings.OffsetY / 2f, drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, drawCubeSettings.OffsetY / 2f, (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint
            };
            this.drawpart_4.PointList = new DrawFunction3D.PointF3D[4]
            {
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, drawCubeSettings.OffsetY / 2f, (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, drawCubeSettings.OffsetY / 2f, drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), drawCubeSettings.OffsetY / 2f, drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), drawCubeSettings.OffsetY / 2f, (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint
            };
            this.drawpart_5.PointList = new DrawFunction3D.PointF3D[4]
            {
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, (float) (-(double) drawCubeSettings.OffsetY / 2.0), (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D(drawCubeSettings.OffsetX / 2f, (float) (-(double) drawCubeSettings.OffsetY / 2.0), drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), (float) (-(double) drawCubeSettings.OffsetY / 2.0), drawCubeSettings.OffsetZ / 2f) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint,
        new DrawFunction3D.PointF3D((float) (-(double) drawCubeSettings.OffsetX / 2.0), (float) (-(double) drawCubeSettings.OffsetY / 2.0), (float) (-(double) drawCubeSettings.OffsetZ / 2.0)) * drawCubeSettings.TurnMatrix + drawCubeSettings.BasePoint
            };
        }

        public override bool CalcualteModel()
        {
            bool flag = false;
            this.PartList.Clear();
            if (this.IndexDrawFunction != null)
            {
                flag = true;
                this.InitialPart();
                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)this.drawpart_0);
                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)this.drawpart_1);
                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)this.drawpart_2);
                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)this.drawpart_3);
                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)this.drawpart_4);
                this.PartList.Add((DrawFunctionLib.DrawFunction3DPart.DrawBase)this.drawpart_5);
            }
            return flag;
        }

        public class CubeSettings
        {
            protected DrawFunction3D.PointF3D p_BasePoint;
            protected DrawFunction3D.ShadowMatrix matrix_TurnMatrix;
            protected Brush brush_DrawBrush;
            protected float f_OffsetX;
            protected float f_OffsetY;
            protected float f_OffsetZ;

            public virtual DrawFunction3D.PointF3D BasePoint
            {
                get
                {
                    return this.p_BasePoint;
                }
                set
                {
                    this.p_BasePoint = value;
                }
            }

            public virtual DrawFunction3D.ShadowMatrix TurnMatrix
            {
                get
                {
                    return this.matrix_TurnMatrix;
                }
                set
                {
                    this.matrix_TurnMatrix = value;
                }
            }

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

            public virtual float OffsetX
            {
                get
                {
                    return this.f_OffsetX;
                }
                set
                {
                    this.f_OffsetX = value;
                }
            }

            public virtual float OffsetY
            {
                get
                {
                    return this.f_OffsetY;
                }
                set
                {
                    this.f_OffsetY = value;
                }
            }

            public virtual float OffsetZ
            {
                get
                {
                    return this.f_OffsetZ;
                }
                set
                {
                    this.f_OffsetZ = value;
                }
            }

            public CubeSettings()
            {
                this.p_BasePoint = new DrawFunction3D.PointF3D();
                this.matrix_TurnMatrix = new DrawFunction3D.ShadowMatrix();
                this.brush_DrawBrush = (Brush)new SolidBrush(Color.FromArgb(100, Color.Blue));
                this.f_OffsetX = 0.5f;
                this.f_OffsetY = 0.5f;
                this.f_OffsetZ = 0.5f;
            }
        }
    }
}
