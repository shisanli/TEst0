using DrawFunctionLib.DrawFunction3DPart;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawFunctionLib.DrawFunction3DModel
{
    public class DrawPoints : DrawBase
    {
       
        public virtual DrawPoints.PointsSettings DrawPointsSettings
        {
            get
            {
                return this.uDrawPointsSettings;
            }
            set
            {
                if (value != null)
                {
                    this.uDrawPointsSettings = value;
                }
            }
        }

        // Token: 0x06000218 RID: 536 RVA: 0x00007E94 File Offset: 0x00006294
        public DrawPoints(DrawFunction3D IndexDrawFunction)
        {
            this.uDrawPointsSettings = new DrawPoints.PointsSettings();
            this.IndexDrawFunction = IndexDrawFunction;
        }

        // Token: 0x06000219 RID: 537 RVA: 0x00007EB0 File Offset: 0x000062B0
        public override bool CalcualteModel()
        {
            bool result = false;
            this.PartList.Clear();
            checked
            {
                if (this.IndexDrawFunction != null)
                {
                    result = true;
                    DrawPoints.PointsSettings drawPointsSettings = this.DrawPointsSettings;
                    if (drawPointsSettings.PointsList.Count > 0)
                    {
                        int num = 0;
                        int num2 = drawPointsSettings.PointsList.Count - 1;
                        for (int i = num; i <= num2; i++)
                        {
                            this.PartList.Add(new DrawRectangle(this.IndexDrawFunction, drawPointsSettings.PenPoint, drawPointsSettings.PointsList[i], drawPointsSettings.DrawPointWidth, drawPointsSettings.DrawPointWidth));
                            if (drawPointsSettings.EnableDrawLine)
                            {
                                this.PartList.Add(new DrawLine(this.IndexDrawFunction, drawPointsSettings.PenLine, drawPointsSettings.PointsList[i], new DrawFunction3D.PointF3D(drawPointsSettings.PointsList[i].X, drawPointsSettings.PointsList[i].Y, (float)this.IndexDrawFunction.DrawRangeZ.Min)));
                                this.PartList.Add(new DrawLine(this.IndexDrawFunction, drawPointsSettings.PenLine, drawPointsSettings.PointsList[i], new DrawFunction3D.PointF3D((float)this.IndexDrawFunction.DrawRangeX.Min, drawPointsSettings.PointsList[i].Y, drawPointsSettings.PointsList[i].Z)));
                                this.PartList.Add(new DrawLine(this.IndexDrawFunction, drawPointsSettings.PenLine, drawPointsSettings.PointsList[i], new DrawFunction3D.PointF3D(drawPointsSettings.PointsList[i].X, (float)this.IndexDrawFunction.DrawRangeY.Min, drawPointsSettings.PointsList[i].Z)));
                            }
                            if (drawPointsSettings.EnableDrawPointValue)
                            {
                                this.PartList.Add(new DrawString(this.IndexDrawFunction, string.Concat(new string[]
                                {
                                    "(",
                                    drawPointsSettings.PointsList[i].X.ToString(drawPointsSettings.DrawFormat),
                                    ",",
                                    drawPointsSettings.PointsList[i].Y.ToString(drawPointsSettings.DrawFormat),
                                    ",",
                                    drawPointsSettings.PointsList[i].Z.ToString(drawPointsSettings.DrawFormat),
                                    ")"
                                }), drawPointsSettings.DrawFont, drawPointsSettings.BrushString, drawPointsSettings.PointsList[i]));
                            }
                        }
                    }
                }
                return result;
            }
        }

        // Token: 0x170000BB RID: 187
        // (get) Token: 0x0600021A RID: 538 RVA: 0x0000814C File Offset: 0x0000654C
        public override DrawBase.ModelType ModelStyle
        {
            get
            {
                return DrawBase.ModelType.Changed;
            }
        }

        // Token: 0x040000D1 RID: 209
        protected DrawPoints.PointsSettings uDrawPointsSettings;

        // Token: 0x02000026 RID: 38
        public class PointsSettings
        {
            // Token: 0x170000BC RID: 188
            // (get) Token: 0x0600021B RID: 539 RVA: 0x0000815C File Offset: 0x0000655C
            // (set) Token: 0x0600021C RID: 540 RVA: 0x00008170 File Offset: 0x00006570
            public virtual Font DrawFont
            {
                get
                {
                    return this.uDrawFont;
                }
                set
                {
                    if (value != null)
                    {
                        this.uDrawFont = value;
                    }
                }
            }

            // Token: 0x170000BD RID: 189
            // (get) Token: 0x0600021D RID: 541 RVA: 0x0000817C File Offset: 0x0000657C
            // (set) Token: 0x0600021E RID: 542 RVA: 0x00008190 File Offset: 0x00006590
            public virtual Brush BrushString
            {
                get
                {
                    return this.uBrushString;
                }
                set
                {
                    this.uBrushString = value;
                }
            }

            // Token: 0x170000BE RID: 190
            // (get) Token: 0x0600021F RID: 543 RVA: 0x0000819C File Offset: 0x0000659C
            // (set) Token: 0x06000220 RID: 544 RVA: 0x000081B0 File Offset: 0x000065B0
            public virtual string DrawFormat
            {
                get
                {
                    return this.uDrawFormat;
                }
                set
                {
                    if (value != null)
                    {
                        this.uDrawFormat = value;
                    }
                }
            }

            // Token: 0x170000BF RID: 191
            // (get) Token: 0x06000221 RID: 545 RVA: 0x000081BC File Offset: 0x000065BC
            // (set) Token: 0x06000222 RID: 546 RVA: 0x000081D0 File Offset: 0x000065D0
            public virtual Collection<DrawFunction3D.PointF3D> PointsList
            {
                get
                {
                    return this.uDrawPoints;
                }
                set
                {
                    if (value != null)
                    {
                        this.uDrawPoints = value;
                    }
                }
            }

            // Token: 0x170000C0 RID: 192
            // (get) Token: 0x06000223 RID: 547 RVA: 0x000081DC File Offset: 0x000065DC
            // (set) Token: 0x06000224 RID: 548 RVA: 0x000081F0 File Offset: 0x000065F0
            public virtual Pen PenPoint
            {
                get
                {
                    return this.uDrawPenPoint;
                }
                set
                {
                    if (value != null)
                    {
                        this.uDrawPenPoint = value;
                    }
                }
            }

            // Token: 0x170000C1 RID: 193
            // (get) Token: 0x06000225 RID: 549 RVA: 0x000081FC File Offset: 0x000065FC
            // (set) Token: 0x06000226 RID: 550 RVA: 0x00008210 File Offset: 0x00006610
            public virtual Pen PenLine
            {
                get
                {
                    return this.uDrawPenPointLine;
                }
                set
                {
                    if (value != null)
                    {
                        this.uDrawPenPointLine = value;
                    }
                }
            }

            // Token: 0x170000C2 RID: 194
            // (get) Token: 0x06000227 RID: 551 RVA: 0x0000821C File Offset: 0x0000661C
            // (set) Token: 0x06000228 RID: 552 RVA: 0x00008230 File Offset: 0x00006630
            public virtual bool EnableDrawPointValue
            {
                get
                {
                    return this.b_EnableDrawPointValue;
                }
                set
                {
                    this.b_EnableDrawPointValue = value;
                }
            }

            // Token: 0x170000C3 RID: 195
            // (get) Token: 0x06000229 RID: 553 RVA: 0x0000823C File Offset: 0x0000663C
            // (set) Token: 0x0600022A RID: 554 RVA: 0x00008250 File Offset: 0x00006650
            public virtual bool EnableDrawLine
            {
                get
                {
                    return this.b_EnableDrawLine;
                }
                set
                {
                    this.b_EnableDrawLine = value;
                }
            }

            // Token: 0x170000C4 RID: 196
            // (get) Token: 0x0600022B RID: 555 RVA: 0x0000825C File Offset: 0x0000665C
            // (set) Token: 0x0600022C RID: 556 RVA: 0x00008270 File Offset: 0x00006670
            public virtual float DrawPointWidth
            {
                get
                {
                    return this.uDrawPointWidth;
                }
                set
                {
                    if (value < 0f)
                    {
                        value = 0f;
                    }
                    this.uDrawPointWidth = value;
                }
            }

            // Token: 0x0600022D RID: 557 RVA: 0x00008288 File Offset: 0x00006688
            public virtual bool AddPoint(ref DrawFunction3D.PointF3D Point)
            {
                bool result = true;
                checked
                {
                    if (this.PointsList.Count > 0)
                    {
                        for (int i = this.PointsList.Count - 1; i >= 0; i += -1)
                        {
                            if (this.PointsList[i] == Point)
                            {
                                this.PointsList.RemoveAt(i);
                                result = false;
                            }
                        }
                    }
                    this.PointsList.Add(Point);
                    return result;
                }
            }

            // Token: 0x0600022E RID: 558 RVA: 0x000082F0 File Offset: 0x000066F0
            public virtual bool Remove(DrawFunction3D.PointF3D Point)
            {
                bool result = false;
                checked
                {
                    if (this.PointsList.Count > 0)
                    {
                        for (int i = this.PointsList.Count - 1; i >= 0; i += -1)
                        {
                            if (this.PointsList[i] == Point)
                            {
                                this.PointsList.RemoveAt(i);
                                result = true;
                            }
                        }
                    }
                    return result;
                }
            }

            // Token: 0x0600022F RID: 559 RVA: 0x00008348 File Offset: 0x00006748
            public virtual object RemoveAt(int Index)
            {
                if (Index >= 0 & Index <= checked(this.PointsList.Count - 1))
                {
                    this.PointsList.RemoveAt(Index);
                    return true;
                }
                return false;
            }

            // Token: 0x06000230 RID: 560 RVA: 0x0000838C File Offset: 0x0000678C
            public virtual bool Clear()
            {
                if (this.PointsList.Count > 0)
                {
                    this.PointsList.Clear();
                    return true;
                }
                return false;
            }

            // Token: 0x06000231 RID: 561 RVA: 0x000083B8 File Offset: 0x000067B8
            public PointsSettings()
            {
                this.uDrawFont = new Font("Comic Sans MS", 13.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.uDrawFormat = "0.###";
                this.uBrushString = new SolidBrush(Color.Black);
                this.uDrawPoints = new Collection<DrawFunction3D.PointF3D>();
                this.uDrawPenPoint = new Pen(Color.Red, 2f);
                this.uDrawPointWidth = 6f;
                this.uDrawPenPointLine = new Pen(Color.Purple, 1f);
                this.b_EnableDrawPointValue = true;
                this.b_EnableDrawLine = true;
                this.PenPoint.DashStyle = DashStyle.Dot;
                this.PenLine.DashStyle = DashStyle.DashDotDot;
            }

            // Token: 0x040000D2 RID: 210
            protected Font uDrawFont;

            // Token: 0x040000D3 RID: 211
            protected string uDrawFormat;

            // Token: 0x040000D4 RID: 212
            protected Brush uBrushString;

            // Token: 0x040000D5 RID: 213
            protected Collection<DrawFunction3D.PointF3D> uDrawPoints;

            // Token: 0x040000D6 RID: 214
            protected Pen uDrawPenPoint;

            // Token: 0x040000D7 RID: 215
            protected float uDrawPointWidth;

            // Token: 0x040000D8 RID: 216
            protected Pen uDrawPenPointLine;

            // Token: 0x040000D9 RID: 217
            protected bool b_EnableDrawPointValue;

            // Token: 0x040000DA RID: 218
            protected bool b_EnableDrawLine;
        }
    }
}
