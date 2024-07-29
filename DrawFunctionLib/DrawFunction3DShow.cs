using DrawFunctionLib.DrawFunction3DModel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.ObjectModel;

namespace DrawFunctionLib
{
    public partial class DrawFunction3DShow : UserControl
    {
       


        protected virtual PictureBox PBMain
        {

            get
            {
                return this._PBMain;
            }
           
            set
            {
                MouseEventHandler value2 = new MouseEventHandler(this.PBMain_MouseUp);
                MouseEventHandler value3 = new MouseEventHandler(this.PBMain_MouseMove);
                MouseEventHandler value4 = new MouseEventHandler(this.PBMain_MouseWheel);
                MouseEventHandler value5 = new MouseEventHandler(this.PBMain_MouseDown);
                if (this._PBMain != null)
                {
                    this._PBMain.MouseUp -= value2;
                    this._PBMain.MouseMove -= value3;
                    this._PBMain.MouseWheel -= value4;
                    this._PBMain.MouseDown -= value5;
                }
                this._PBMain = value;
                if (this._PBMain != null)
                {
                    this._PBMain.MouseUp += value2;
                    this._PBMain.MouseMove += value3;
                    this._PBMain.MouseWheel += value4;
                    this._PBMain.MouseDown += value5;
                }
            }
        }

        internal virtual ContextMenuStrip CMSMain
        {
         
            get
            {
                return this._CMSMain;
            }
          
            set
            {
                this._CMSMain = value;
            }
        }

        internal virtual ToolStripMenuItem TSMI_DeletePoint
        {
          
            get
            {
                return this._TSMI_DeletePoint;
            }
         
            set
            {
                EventHandler value2 = new EventHandler(this.TSMI_DeletePoint_Click);
                if (this._TSMI_DeletePoint != null)
                {
                    this._TSMI_DeletePoint.Click -= value2;
                }
                this._TSMI_DeletePoint = value;
                if (this._TSMI_DeletePoint != null)
                {
                    this._TSMI_DeletePoint.Click += value2;
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator1
        {
           
            get
            {
                return this._ToolStripSeparator1;
            }
           
            set
            {
                this._ToolStripSeparator1 = value;
            }
        }

        internal virtual ToolStripMenuItem TSMI_ClearPoints
        {
           
            get
            {
                return this._TSMI_ClearPoints;
            }
          
            set
            {
                EventHandler value2 = new EventHandler(this.TSMI_ClearPoints_Click);
                if (this._TSMI_ClearPoints != null)
                {
                    this._TSMI_ClearPoints.Click -= value2;
                }
                this._TSMI_ClearPoints = value;
                if (this._TSMI_ClearPoints != null)
                {
                    this._TSMI_ClearPoints.Click += value2;
                }
            }
        }

        internal virtual ToolStripMenuItem TSMI_AddPoint
        {
           
            get
            {
                return this._TSMI_AddPoint;
            }
          
            set
            {
                this._TSMI_AddPoint = value;
            }
        }

        internal virtual ToolStripMenuItem TSMI_InputTip
        {
            
            get
            {
                return this._TSMI_InputTip;
            }
           
            
            set
            {
                this._TSMI_InputTip = value;
            }
        }

        internal virtual ToolStripTextBox TSTB_X
        {
           
            get
            {
                return this._TSTB_X;
            }
            
            set
            {
                this._TSTB_X = value;
            }
        }

        internal virtual ToolStripTextBox TSTB_Y
        {
           
            get
            {
                return this._TSTB_Y;
            }
           
            set
            {
                this._TSTB_Y = value;
            }
        }

        internal virtual ToolStripTextBox TSTB_Z
        {
           
            get
            {
                return this._TSTB_Z;
            }
           
            set
            {
                this._TSTB_Z = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator2
        {
           
            get
            {
                return this._ToolStripSeparator2;
            }
           
            set
            {
                this._ToolStripSeparator2 = value;
            }
        }

        internal virtual ToolStripMenuItem TSMI_AddThisPoint
        {
          
            get
            {
                return this._TSMI_AddThisPoint;
            }
         
            set
            {
                EventHandler value2 = new EventHandler(this.TSMI_AddPoint_Click);
                if (this._TSMI_AddThisPoint != null)
                {
                    this._TSMI_AddThisPoint.Click -= value2;
                }
                this._TSMI_AddThisPoint = value;
                if (this._TSMI_AddThisPoint != null)
                {
                    this._TSMI_AddThisPoint.Click += value2;
                }
            }
        }

        internal virtual ToolStripMenuItem TSMI_Rotation
        {
          
            get
            {
                return this._TSMI_Rotation;
            }
           
            set
            {
                this._TSMI_Rotation = value;
            }
        }

        internal virtual ToolStripMenuItem TSMI_RotationInput
        {
           
            get
            {
                return this._TSMI_RotationInput;
            }
           
            set
            {
                this._TSMI_RotationInput = value;
            }
        }

        internal virtual ToolStripTextBox TSTB_DX
        {
          
            get
            {
                return this._TSTB_DX;
            }
           
            set
            {
                this._TSTB_DX = value;
            }
        }

        internal virtual ToolStripTextBox TSTB_DY
        {
          
            get
            {
                return this._TSTB_DY;
            }
         
            set
            {
                this._TSTB_DY = value;
            }
        }

        internal virtual ToolStripTextBox TSTB_DZ
        {
           
            get
            {
                return this._TSTB_DZ;
            }
           
            set
            {
                this._TSTB_DZ = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator3
        {
           
            get
            {
                return this._ToolStripSeparator3;
            }
          
            set
            {
                this._ToolStripSeparator3 = value;
            }
        }

        internal virtual ToolStripMenuItem RotateImageToolStripMenuItem
        {
           
            get
            {
                return this._RotateImageToolStripMenuItem;
            }
           
            set
            {
                EventHandler value2 = new EventHandler(this.RotateImageToolStripMenuItem_Click);
                if (this._RotateImageToolStripMenuItem != null)
                {
                    this._RotateImageToolStripMenuItem.Click -= value2;
                }
                this._RotateImageToolStripMenuItem = value;
                if (this._RotateImageToolStripMenuItem != null)
                {
                    this._RotateImageToolStripMenuItem.Click += value2;
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator4
        {
          
            get
            {
                return this._ToolStripSeparator4;
            }
          
            set
            {
                this._ToolStripSeparator4 = value;
            }
        }

        internal virtual ToolStripMenuItem TSMI_RotateImageTo
        {
           
            get
            {
                return this._TSMI_RotateImageTo;
            }
           
            set
            {
                EventHandler value2 = new EventHandler(this.TSMI_RotateImageTo_Click);
                if (this._TSMI_RotateImageTo != null)
                {
                    this._TSMI_RotateImageTo.Click -= value2;
                }
                this._TSMI_RotateImageTo = value;
                if (this._TSMI_RotateImageTo != null)
                {
                    this._TSMI_RotateImageTo.Click += value2;
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator5
        {
          
            get
            {
                return this._ToolStripSeparator5;
            }
          
            set
            {
                this._ToolStripSeparator5 = value;
            }
        }

        internal virtual ToolStripMenuItem TSMI_ResetLocation
        {
           
            get
            {
                return this._TSMI_ResetLocation;
            }
           
            set
            {
                EventHandler value2 = new EventHandler(this.TSMI_ResetLoaction_Click);
                if (this._TSMI_ResetLocation != null)
                {
                    this._TSMI_ResetLocation.Click -= value2;
                }
                this._TSMI_ResetLocation = value;
                if (this._TSMI_ResetLocation != null)
                {
                    this._TSMI_ResetLocation.Click += value2;
                }
            }
        }

       
        public event RefreshDrawEventHandler RefreshDraw;

        public virtual bool IsOnTurning
        {
            get
            {
                return this.b_MouseDownLeft | this.b_MouseDownRight;
            }
        }

        public virtual PictureBox PBShow
        {
            get
            {
                return this.PBMain;
            }
        }

        public virtual DrawFunction3D IndexDrawFunction
        {
            get
            {
                return this.df_Core;
            }
            set
            {
                this.df_Core = value;
                if (this.dp_IndexDrawPoints != null)
                {
                    this.dp_IndexDrawPoints.IndexDrawFunction = this.df_Core;
                }
            }
        }

        public virtual DrawPoints IndexDrawPoints
        {
            get
            {
                return this.dp_IndexDrawPoints;
            }
            set
            {
                this.dp_IndexDrawPoints = value;
                if (this.dp_IndexDrawPoints != null)
                {
                    this.dp_IndexDrawPoints.IndexDrawFunction = this.df_Core;
                }
            }
        }

        public virtual bool EnableUsePoints
        {
            get
            {
                return this.b_EnableUsePoints;
            }
            set
            {
                this.b_EnableUsePoints = value;
            }
        }

        public virtual float MaxDistanceInSearch
        {
            get
            {
                return this.single_FindMaxDistance;
            }
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                this.single_FindMaxDistance = value;
            }
        }

        public virtual bool EnableUseTurn
        {
            get
            {
                return this.b_EnableUseTurn;
            }
            set
            {
                this.b_EnableUseTurn = value;
            }
        }

        public DrawFunction3DShow()
        {
            base.Enter += this.DrawFunction3DShow_Enter;
            this.single_FindMaxDistance = 15f;
            this.df_Core = null;
            this.dp_IndexDrawPoints = new DrawPoints(null);
            this.b_EnableUseTurn = true;
            this.b_EnableUsePoints = true;
            this.b_MouseDownLeft = false;
            this.b_MouseDownRight = false;
            this.b_MouseTurn = false;
            this.i_findPointIndex = -1;
            this.point_MouseDownPosition = default(Point);
            this.matrix_TrunMatrix = null;
            this.pointf_Offset = default(PointF);
            this.InitializeComponent();
            this.IndexDrawFunction = null;
            this.RefreshImage();
        }

        public virtual void RefreshImage()
        {
            if (this.IndexDrawFunction != null)
            {
                //DrawFunctionLib.Properties.Resources.Joint;//

                //this.PBMain.BackgroundImage =  this.IndexDrawFunction.ImageFunction;
                //this.PBMain.Image = this.IndexDrawFunction.ImagePoint;

                // 上面两行为原来正确  下面为修改背景后
                this.PBMain.BackgroundImageLayout = ImageLayout.Center;
                //this.PBMain.SizeMode = PictureBoxSizeMode.Zoom;  //01-02-29新增 适应屏幕缩放
                //this.PBMain.Width= DrawFunctionLib.Properties.Resources.Joint.Width;
                //this.PBMain.Height= DrawFunctionLib.Properties.Resources.Joint.Height;
                this.PBMain.BackgroundImage = DrawFunctionLib.Properties.Resources.Joint;// this.IndexDrawFunction.ImageFunction;
                this.PBMain.Image = this.IndexDrawFunction.ImageFunction;// this.IndexDrawFunction.ImagePoint;
            }
            else
            {
                this.PBMain.BackgroundImage = null;
                this.PBMain.Image = null;
            }
            this.PBMain.Refresh();
        }

        public virtual Bitmap ToPrintImage()
        {
            Bitmap bitmap = new Bitmap(this.df_Core.ImageFunction);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(this.BackColor);
            graphics.DrawImage(this.df_Core.ImageFunction, 0, 0);
            graphics.DrawImage(this.df_Core.ImagePoint, 0, 0);
            return bitmap;
        }

        public virtual int SearchNearistPoint(Point Location, float MaxDistance = 0f)
        {
            int result = -1;
            checked
            {
                if (this.df_Core != null & this.dp_IndexDrawPoints != null)
                {
                    Collection<DrawFunction3D.PointF3D> pointsList = this.dp_IndexDrawPoints.DrawPointsSettings.PointsList;
                    float num = -1f;
                    Point point = default(Point);
                    if (pointsList.Count > 0)
                    {
                        int num2 = 0;
                        int num3 = pointsList.Count - 1;
                        for (int i = num2; i <= num3; i++)
                        {
                            point = this.PositionImageToView(this.df_Core.PositionValueToDraw(pointsList[i]));
                            float num4 = (float)Math.Sqrt((double)((point.X - Location.X) * (point.X - Location.X) + (point.Y - Location.Y) * (point.Y - Location.Y)));
                            if ((MaxDistance <= 0f || num4 <= MaxDistance) && (num < 0f || num4 < num))
                            {
                                num = num4;
                                result = i;
                            }
                        }
                    }
                }
                return result;
            }
        }

        public virtual DrawFunction3D.PointF3D CalculateTurnParameter(Point StartPoint, Point EndPoint)
        {
            return new DrawFunction3D.PointF3D
            {
                X = (float)(3.14 * (double)(checked(EndPoint.Y - StartPoint.Y)) / (double)this.PBMain.Height),
                Y = (float)(-3.14 * (double)(checked(EndPoint.X - StartPoint.X)) / (double)this.PBMain.Width),
                Z = 0f
            };
        }

        public virtual PointF CalculateOffset(Point StartPoint, Point EndPoint)
        {
            PointF result = default(PointF);
            checked
            {
                result.X = (float)((double)(0 - (EndPoint.X - StartPoint.X)) / (double)this.PBMain.Width);
                result.Y = (float)((double)(EndPoint.Y - StartPoint.Y) / (double)this.PBMain.Height);
            }
            if (this.df_Core != null)
            {
                if (this.df_Core.DrawEdgePercent > 0f & this.df_Core.DrawEdgePercent < 1f)
                {
                    result.X /= 1f - this.df_Core.DrawEdgePercent * 2f;
                    result.Y /= 1f - this.df_Core.DrawEdgePercent * 2f;
                }
                else if (this.df_Core.DrawEdgePercent < 0f & this.df_Core.DrawEdgePercent > -1f)
                {
                    result.X *= 1f + this.df_Core.DrawEdgePercent;
                    result.Y *= 1f + this.df_Core.DrawEdgePercent;
                }
                else if (this.df_Core.DrawEdgePercent <= -1f)
                {
                    result.X /= -this.df_Core.DrawEdgePercent * 2f;
                    result.Y /= -this.df_Core.DrawEdgePercent * 2f;
                }
            }
            return result;
        }

        protected void PBMain_MouseDown(object sender, MouseEventArgs e)
        {
        //    int num;
        //    int num2=0;
        //    int num4=0;
        //    object obj;
        //    try
        //    {
        //    IL_00:
        //        ProjectData.ClearProjectError();
        //        num = -2;
        //    IL_08:
        //         num2 = 2;
        //        if (e.Button != MouseButtons.Left)
        //        {
        //            num2 = 11;
        //            //goto IL_B0;
        //        }
        //    IL_1B:
        //        num2 = 3;
        //        if (!(this.EnableUseTurn & this.df_Core != null))
        //        {
        //            //goto IL_13E;
        //            if (num4 != 0)
        //            {
        //                ProjectData.ClearProjectError();
        //            }
        //        }
        //    IL_36:
        //        num2 = 4;
        //        this.PBMain.Focus();
        //    IL_45:
        //        num2 = 5;
        //        this.point_MouseDownPosition.X = e.X;
        //    IL_59:
        //        num2 = 6;
        //        this.point_MouseDownPosition.Y = e.Y;
        //    IL_6D:
        //        num2 = 7;
        //        this.pointf_Offset = new PointF(this.df_Core.DrawOffset.X, this.df_Core.DrawOffset.Y);
        //    IL_A1:
        //        num2 = 8;
        //        this.b_MouseDownRight = true;
        //    IL_AB:
        //        goto IL_1E9;
        //    IL_B0:
        //        num2 = 11;
        //        if (e.Button != MouseButtons.Right)
        //        {
        //            goto IL_13E;
        //        }
        //    IL_C1:
        //        num2 = 12;
        //        if (!(this.EnableUseTurn & this.df_Core != null))
        //        {
        //            goto IL_13E;
        //        }
        //    IL_DA:
        //        num2 = 13;
        //        this.PBMain.Focus();
        //    IL_EA:
        //        num2 = 14;
        //        this.point_MouseDownPosition.X = e.X;
        //    IL_FF:
        //        num2 = 15;
        //        this.point_MouseDownPosition.Y = e.Y;
        //    IL_114:
        //        num2 = 16;
        //        this.matrix_TrunMatrix = (DrawFunction3D.ShadowMatrix)this.df_Core.TurnMatrix.Clone();
        //    IL_133:
        //        num2 = 17;
        //        this.b_MouseDownLeft = true;
        //    IL_13E:
        //        goto IL_1E9;
        //    IL_143:
        //        int num3 = num4 + 1;
        //        num4 = 0; 
        //    IL_1A1:
        //        goto IL_1DE;
        //    IL_1A3:
        //        num4 = num2; 
        //    IL_1BC:;
        //    }
        //    catch (Exception ex)
        //    {
        //         String s=ex.Message;
        //        //goto IL_1A3;
        //        num4 = num2;
        //    }
        //IL_1DE:
        //    throw ProjectData.CreateProjectError(-2146828237);
        //IL_1E9:
        //    if (num4 != 0)
        //    {
        //        ProjectData.ClearProjectError();
        //    }
        }

        private void PBMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0 && (this.EnableUseTurn & this.df_Core != null))
            {
                float num = (float)Math.Abs((double)e.Delta / 120.0);
                if (e.Delta < 0)
                {
                    if ((double)this.df_Core.DrawEdgePercent > -0.5)
                    {
                        DrawFunction3D drawFunction3D = this.df_Core;
                        drawFunction3D.DrawEdgePercent = (float)((double)drawFunction3D.DrawEdgePercent + 0.05 * (double)num);
                    }
                    else
                    {
                        DrawFunction3D drawFunction3D = this.df_Core;
                        drawFunction3D.DrawEdgePercent /= 2f * num;
                    }
                }
                else if ((double)this.df_Core.DrawEdgePercent >= -0.5)
                {
                    DrawFunction3D drawFunction3D = this.df_Core;
                    drawFunction3D.DrawEdgePercent = (float)((double)drawFunction3D.DrawEdgePercent - 0.05 * (double)num);
                }
                else
                {
                    DrawFunction3D drawFunction3D = this.df_Core;
                    drawFunction3D.DrawEdgePercent *= 2f * num;
                }
                this.df_Core.DrawFunction(true);
                this.df_Core.DrawPoint(true);
                RefreshDrawEventHandler refreshDrawEvent = this.RefreshDrawEvent;
                if (refreshDrawEvent != null)
                {
                    refreshDrawEvent();
                }
                this.RefreshImage();
            }
        }

        protected void PBMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.EnableUseTurn & this.df_Core != null & this.b_MouseDownRight)
                {
                    Point startPoint = this.point_MouseDownPosition;
                    Point endPoint = new Point(e.X, e.Y);
                    PointF pointF = this.CalculateOffset(startPoint, endPoint);
                    DrawFunction3D drawFunction3D = this.df_Core;
                    PointF drawOffset = new PointF(this.pointf_Offset.X + pointF.X, this.pointf_Offset.Y + pointF.Y);
                    drawFunction3D.DrawOffset = drawOffset;
                    this.df_Core.DrawFunction(true);
                    this.df_Core.DrawPoint(true);
                    DrawFunction3DShow.RefreshDrawEventHandler refreshDrawEvent = this.RefreshDrawEvent;
                    if (refreshDrawEvent != null)
                    {
                        refreshDrawEvent();
                    }
                    this.RefreshImage();
                }
            }
            else if (e.Button == MouseButtons.Right && (this.EnableUseTurn & this.df_Core != null & this.b_MouseDownLeft))
            {
                this.b_MouseTurn = true;
                Point startPoint2 = this.point_MouseDownPosition;
                Point endPoint = new Point(e.X, e.Y);
                DrawFunction3D.PointF3D pointF3D = this.CalculateTurnParameter(startPoint2, endPoint);
                DrawFunction3D.ShadowMatrix right = DrawFunction3D.ShadowMatrix.FromTurning((double)pointF3D.X, (double)pointF3D.Y, (double)pointF3D.Z);
                this.df_Core.TurnMatrix = this.matrix_TrunMatrix * right;
                this.df_Core.TurnMatrix = this.df_Core.TurnMatrix * DrawFunction3D.ShadowMatrix.FromTurningZ(this.df_Core.TurnMatrix.VerticalityZDegreeZ());
                this.df_Core.DrawFunction(true);
                this.df_Core.DrawPoint(true);
                DrawFunction3DShow.RefreshDrawEventHandler refreshDrawEvent = this.RefreshDrawEvent;
                if (refreshDrawEvent != null)
                {
                    refreshDrawEvent();
                }
                this.RefreshImage();
            }
        }

        protected void PBMain_MouseUp(object sender, MouseEventArgs e)
        {
            this.b_MouseDownLeft = false;
            this.b_MouseDownRight = false;
            if (e.Button == MouseButtons.Right & !this.b_MouseTurn)
            {
                Point position = e.Location;
                if (this.EnableUsePoints & this.df_Core != null & this.dp_IndexDrawPoints != null)
                {
                    this.point_MouseDownPosition.X = e.Location.X;
                    this.point_MouseDownPosition.Y = e.Location.Y;
                    this.i_findPointIndex = this.SearchNearistPoint(e.Location, this.MaxDistanceInSearch);
                    if (this.i_findPointIndex >= 0 & this.i_findPointIndex <= checked(this.dp_IndexDrawPoints.DrawPointsSettings.PointsList.Count - 1))
                    {
                        this.TSMI_DeletePoint.Enabled = this.EnableUsePoints;
                        position = this.PositionImageToView(this.df_Core.PositionValueToDraw(this.dp_IndexDrawPoints.DrawPointsSettings.PointsList[this.i_findPointIndex]));
                    }
                    else
                    {
                        this.TSMI_DeletePoint.Enabled = false;
                    }
                    this.TSMI_AddPoint.Enabled = this.EnableUsePoints;
                    this.TSMI_Rotation.Enabled = this.EnableUseTurn;
                    if (this.dp_IndexDrawPoints.DrawPointsSettings.PointsList.Count > 0)
                    {
                        this.TSMI_ClearPoints.Enabled = this.EnableUsePoints;
                    }
                    else
                    {
                        this.TSMI_ClearPoints.Enabled = false;
                    }
                    this.CMSMain.Show((Control)sender, position);
                }
            }
            this.b_MouseTurn = false;
        }

        private void TSMI_ResetLoaction_Click(object sender, EventArgs e)
        {
            if (this.df_Core != null)
            {
                this.df_Core.ResetLocation();
                this.df_Core.DrawFunction(true);
                this.df_Core.DrawPoint(true);
                DrawFunction3DShow.RefreshDrawEventHandler refreshDrawEvent = this.RefreshDrawEvent;
                if (refreshDrawEvent != null)
                {
                    refreshDrawEvent();
                }
                this.RefreshImage();
            }
        }

        private void DrawFunction3DShow_Enter(object sender, EventArgs e)
        {
            int num;
            int num4=0;
            int num2 = 0;
            object obj;
            try
            {
            IL_00:
                ProjectData.ClearProjectError();
                num = -2;
            IL_08:
                 num2 = 2;
                this.PBMain.Focus();
            IL_16:
                goto IL_79;
            IL_18:
                int num3 = num4 + 1;
                num4 = 0; 
            IL_32:
                goto IL_6E;
            IL_34:
                num4 = num2; 
            IL_4C:;
            }
            catch(Exception ex) 
            {
                //ex = (Exception)obj2;
                //goto IL_34;
                num4 = num2;
            }
        IL_6E:
            throw ProjectData.CreateProjectError(-2146828237);
        IL_79:
            if (num4 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }

        public bool KeyControl(KeyEventArgs e)
        {
            bool flag = false;
            if (this.df_Core != null)
            {
                float num;
                if (e.Alt)
                {
                    num = 0.01f;
                }
                else
                {
                    num = 0.1f;
                }
                if (e.KeyCode == Keys.Left)
                {
                    flag = true;
                    this.df_Core.TurnMatrix = DrawFunction3D.ShadowMatrix.Multiply(this.df_Core.TurnMatrix, DrawFunction3D.ShadowMatrix.FromTurning(0.0, (double)(-(double)num), 0.0));
                }
                if (e.KeyCode == Keys.Right)
                {
                    flag = true;
                    this.df_Core.TurnMatrix = DrawFunction3D.ShadowMatrix.Multiply(this.df_Core.TurnMatrix, DrawFunction3D.ShadowMatrix.FromTurning(0.0, (double)num, 0.0));
                }
                if (e.KeyCode == Keys.Up)
                {
                    flag = true;
                    this.df_Core.TurnMatrix = DrawFunction3D.ShadowMatrix.Multiply(this.df_Core.TurnMatrix, DrawFunction3D.ShadowMatrix.FromTurning((double)num, 0.0, 0.0));
                }
                if (e.KeyCode == Keys.Down)
                {
                    flag = true;
                    this.df_Core.TurnMatrix = DrawFunction3D.ShadowMatrix.Multiply(this.df_Core.TurnMatrix, DrawFunction3D.ShadowMatrix.FromTurning((double)(-(double)num), 0.0, 0.0));
                }
                if (e.KeyCode == Keys.Prior)
                {
                    flag = true;
                    this.df_Core.TurnMatrix = DrawFunction3D.ShadowMatrix.Multiply(this.df_Core.TurnMatrix, DrawFunction3D.ShadowMatrix.FromTurning(0.0, 0.0, (double)num));
                }
                if (e.KeyCode == Keys.Next)
                {
                    flag = true;
                    this.df_Core.TurnMatrix = DrawFunction3D.ShadowMatrix.Multiply(this.df_Core.TurnMatrix, DrawFunction3D.ShadowMatrix.FromTurning(0.0, 0.0, (double)(-(double)num)));
                }
                if (flag)
                {
                    this.df_Core.DrawFunction(true);
                    this.df_Core.DrawPoint(true);
                    DrawFunction3DShow.RefreshDrawEventHandler refreshDrawEvent = this.RefreshDrawEvent;
                    if (refreshDrawEvent != null)
                    {
                        refreshDrawEvent();
                    }
                    this.RefreshImage();
                }
            }
            return flag;
        }

        protected void TSMI_AddPoint_Click(object sender, EventArgs e)
        {
            double num = Conversion.Val(this.TSTB_X.Text);
            double num2 = Conversion.Val(this.TSTB_Y.Text);
            double num3 = Conversion.Val(this.TSTB_Z.Text);
            this.TSTB_X.Text = num.ToString();
            this.TSTB_Y.Text = num2.ToString();
            this.TSTB_Z.Text = num3.ToString();
            if (this.dp_IndexDrawPoints != null)
            {
                DrawPoints.PointsSettings drawPointsSettings = this.dp_IndexDrawPoints.DrawPointsSettings;
                DrawFunction3D.PointF3D pointF3D = new DrawFunction3D.PointF3D((float)num, (float)num2, (float)num3);
                if (drawPointsSettings.AddPoint(ref pointF3D))
                {
                    this.df_Core.DrawPartListPoint.Clear();
                    this.dp_IndexDrawPoints.CalcualteModel();
                    this.df_Core.DrawPartListPoint.AddRange(this.dp_IndexDrawPoints.PartList);
                    this.df_Core.DrawPoint(true);
                    this.RefreshImage();
                }
            }
        }

        protected void TSMI_DeletePoint_Click(object sender, EventArgs e)
        {
            if (this.dp_IndexDrawPoints != null && Conversions.ToBoolean(this.dp_IndexDrawPoints.DrawPointsSettings.RemoveAt(this.i_findPointIndex)))
            {
                this.df_Core.DrawPartListPoint.Clear();
                this.dp_IndexDrawPoints.CalcualteModel();
                this.df_Core.DrawPartListPoint.AddRange(this.dp_IndexDrawPoints.PartList);
                this.df_Core.DrawPoint(true);
                this.RefreshImage();
            }
        }

        protected void TSMI_ClearPoints_Click(object sender, EventArgs e)
        {
            if (this.dp_IndexDrawPoints != null && this.dp_IndexDrawPoints.DrawPointsSettings.Clear())
            {
                this.df_Core.DrawPartListPoint.Clear();
                this.dp_IndexDrawPoints.CalcualteModel();
                this.df_Core.DrawPartListPoint.AddRange(this.dp_IndexDrawPoints.PartList);
                this.df_Core.DrawPoint(true);
                this.RefreshImage();
            }
        }

        protected void RotateImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double xdegree = Conversion.Val(this.TSTB_DX.Text);
            double ydegree = Conversion.Val(this.TSTB_DY.Text);
            double zdegree = Conversion.Val(this.TSTB_DZ.Text);
            this.TSTB_DX.Text = xdegree.ToString();
            this.TSTB_DY.Text = ydegree.ToString();
            this.TSTB_DZ.Text = zdegree.ToString();
            if (this.df_Core != null)
            {
                this.df_Core.TurnMatrix = DrawFunction3D.ShadowMatrix.Multiply(this.df_Core.TurnMatrix, DrawFunction3D.ShadowMatrix.FromTurning(xdegree, ydegree, zdegree));
                this.df_Core.DrawFunction(true);
                this.df_Core.DrawPoint(true);
                RefreshDrawEventHandler refreshDrawEvent = this.RefreshDrawEvent;
                if (refreshDrawEvent != null)
                {
                    refreshDrawEvent();
                }
                this.RefreshImage();
            }
        }

        protected void TSMI_RotateImageTo_Click(object sender, EventArgs e)
        {
            double xdegree = Conversion.Val(this.TSTB_DX.Text);
            double ydegree = Conversion.Val(this.TSTB_DY.Text);
            double zdegree = Conversion.Val(this.TSTB_DZ.Text);
            this.TSTB_DX.Text = xdegree.ToString();
            this.TSTB_DY.Text = ydegree.ToString();
            this.TSTB_DZ.Text = zdegree.ToString();
            if (this.df_Core != null)
            {
                this.df_Core.TurnMatrix = DrawFunction3D.ShadowMatrix.FromTurning(xdegree, ydegree, zdegree);
                this.df_Core.DrawFunction(true);
                this.df_Core.DrawPoint(true);
                RefreshDrawEventHandler refreshDrawEvent = this.RefreshDrawEvent;
                if (refreshDrawEvent != null)
                {
                    refreshDrawEvent();
                }
                this.RefreshImage();
            }
        }

        public virtual int PositionImageToViewX(float ImageX)
        {
            return checked((int)Math.Round((double)(unchecked(ImageX / (float)this.df_Core.ImageWidth * (float)this.PBMain.Width))));
        }

        public virtual int PositionImageToViewY(float ImageY)
        {
            return checked((int)Math.Round((double)(unchecked(ImageY / (float)this.df_Core.ImageHeight * (float)this.PBMain.Height))));
        }

      
        public virtual Point PositionImageToView(PointF ImagePoint)
        {
            Point result = new Point(this.PositionImageToViewX(ImagePoint.X), this.PositionImageToViewY(ImagePoint.Y));
            return result;
        }

       
        public virtual float PositionViewToImageX(int ViewX)
        {
            return (float)((double)(checked(ViewX * this.df_Core.ImageWidth)) / (double)this.PBMain.Width);
        }

        
        public virtual float PositionViewToImageY(int ViewY)
        {
            return (float)((double)(checked(ViewY * this.df_Core.ImageHeight)) / (double)this.PBMain.Height);
        }

       
        public virtual PointF PositionViewToImage(Point ViewPoint)
        {
            PointF result = new PointF(this.PositionViewToImageX(ViewPoint.X), this.PositionViewToImageY(ViewPoint.Y));
            return result;
        }

        //private IContainer components;

        
       
        private PictureBox _PBMain;

       
      
        private ContextMenuStrip _CMSMain;

       
        
        private ToolStripMenuItem _TSMI_DeletePoint;

        
        
        private ToolStripSeparator _ToolStripSeparator1;

        
        
        private ToolStripMenuItem _TSMI_ClearPoints;

       
       
        private ToolStripMenuItem _TSMI_AddPoint;

       
      
        private ToolStripMenuItem _TSMI_InputTip;

       
       
        private ToolStripTextBox _TSTB_X;

       
       
        private ToolStripTextBox _TSTB_Y;

       
        
        private ToolStripTextBox _TSTB_Z;

       
        private ToolStripSeparator _ToolStripSeparator2;

        
        private ToolStripMenuItem _TSMI_AddThisPoint;

       
        private ToolStripMenuItem _TSMI_Rotation;

        
        private ToolStripMenuItem _TSMI_RotationInput;

        
        private ToolStripTextBox _TSTB_DX;

        
        private ToolStripTextBox _TSTB_DY;

       
        private ToolStripTextBox _TSTB_DZ;

        
        private ToolStripSeparator _ToolStripSeparator3;

        
        private ToolStripMenuItem _RotateImageToolStripMenuItem;

        
        private ToolStripSeparator _ToolStripSeparator4;

       
        private ToolStripMenuItem _TSMI_RotateImageTo;

       
        private ToolStripSeparator _ToolStripSeparator5;

       
        private ToolStripMenuItem _TSMI_ResetLocation;

       
        protected float single_FindMaxDistance;

        
        protected DrawFunction3D df_Core;

       
        protected DrawPoints dp_IndexDrawPoints;

        
        protected bool b_EnableUseTurn;

        
        protected bool b_EnableUsePoints;

       
        protected bool b_MouseDownLeft;

        
        protected bool b_MouseDownRight;

       
        protected bool b_MouseTurn;

        
        protected int i_findPointIndex;

       
        protected Point point_MouseDownPosition;

       
        protected DrawFunction3D.ShadowMatrix matrix_TrunMatrix;

      
        protected PointF pointf_Offset;
        private readonly RefreshDrawEventHandler RefreshDrawEvent;

        public delegate void RefreshDrawEventHandler();

    }
}