using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace DrawFunctionLib
{
    public partial class DrawFunction2DShow: UserControl
    {
       



        protected virtual PictureBox PBMain
        {
           
            get
            {
                return this._PBMain;
            }
          
            set
            {
                MouseEventHandler value2 = new MouseEventHandler(this.PBMain_MouseDown);
                MouseEventHandler value3 = new MouseEventHandler(this.PBMain_MouseUp);
                MouseEventHandler value4 = new MouseEventHandler(this.PBMain_MouseMove);
                if (this._PBMain != null)
                {
                    this._PBMain.MouseDown -= value2;
                    this._PBMain.MouseUp -= value3;
                    this._PBMain.MouseMove -= value4;
                }
                this._PBMain = value;
                if (this._PBMain != null)
                {
                    this._PBMain.MouseDown += value2;
                    this._PBMain.MouseUp += value3;
                    this._PBMain.MouseMove += value4;
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

        internal virtual ToolStripMenuItem TSMI_AddPoint
        {
           
            get
            {
                return this._TSMI_AddPoint;
            }
           
            set
            {
                EventHandler value2 = new EventHandler(this.TSMI_AddPoint_Click);
                if (this._TSMI_AddPoint != null)
                {
                    this._TSMI_AddPoint.Click -= value2;
                }
                this._TSMI_AddPoint = value;
                if (this._TSMI_AddPoint != null)
                {
                    this._TSMI_AddPoint.Click += value2;
                }
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

        public virtual DrawFunction2D IndexDrawFunction
        {
            get
            {
                return this.df_Core;
            }
            set
            {
                this.df_Core = value;
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

        public DrawFunction2DShow()
        {
            this.single_FindMaxDistance = 15f;
            this.df_Core = null;
            this.b_EnableUsePoints = true;
            this.b_MouseDown = false;
            this.i_findPointIndex = -1;
            this.point_MouseDownPosition = default(Point);
            this.InitializeComponent();
            this.IndexDrawFunction = null;
            this.RefreshImage();
        }

        public virtual void RefreshImage()
        {
            if (this.IndexDrawFunction != null)
            {
                this.PBMain.BackgroundImage = this.IndexDrawFunction.ImageFunction;
                this.PBMain.Image = this.IndexDrawFunction.ImagePoint;
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
                if (this.df_Core != null)
                {
                    Collection<PointF> pointsList = this.df_Core.DrawPointsSettings.PointsList;
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

        private void PBMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (this.EnableUsePoints & this.df_Core != null))
            {
                this.i_findPointIndex = this.SearchNearistPoint(e.Location, this.MaxDistanceInSearch);
                if (this.i_findPointIndex >= 0 & this.i_findPointIndex <= checked(this.df_Core.DrawPointsSettings.PointsList.Count - 1))
                {
                    this.b_MouseDown = true;
                }
                else
                {
                    this.b_MouseDown = false;
                }
            }
        }

        private void PBMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (this.EnableUsePoints & this.df_Core != null & this.b_MouseDown) && (this.i_findPointIndex >= 0 & this.i_findPointIndex <= checked(this.df_Core.DrawPointsSettings.PointsList.Count - 1)))
            {
                this.df_Core.DrawPointsSettings.PointsList[this.i_findPointIndex] = this.df_Core.PositionDrawToValue(this.PositionViewToImage(e.Location));
                this.df_Core.DrawPoint(true);
                this.RefreshImage();
            }
        }


        private void PBMain_MouseUp(object sender, MouseEventArgs e)
        {
            this.b_MouseDown = false;
            if (e.Button == MouseButtons.Right)
            {
                Point position = e.Location;
                if (this.EnableUsePoints & this.df_Core != null)
                {
                    this.point_MouseDownPosition.X = e.Location.X;
                    this.point_MouseDownPosition.Y = e.Location.Y;
                    this.i_findPointIndex = this.SearchNearistPoint(e.Location, this.MaxDistanceInSearch);
                    if (this.i_findPointIndex >= 0 & this.i_findPointIndex <= checked(this.df_Core.DrawPointsSettings.PointsList.Count - 1))
                    {
                        this.TSMI_DeletePoint.Enabled = true;
                        position = this.PositionImageToView(this.df_Core.PositionValueToDraw(this.df_Core.DrawPointsSettings.PointsList[this.i_findPointIndex]));
                    }
                    else
                    {
                        this.TSMI_DeletePoint.Enabled = false;
                    }
                    if (this.df_Core.DrawPointsSettings.PointsList.Count > 0)
                    {
                        this.TSMI_ClearPoints.Enabled = true;
                    }
                    else
                    {
                        this.TSMI_ClearPoints.Enabled = false;
                    }
                    this.CMSMain.Show((Control)sender, position);
                }
            }
        }


        private void TSMI_AddPoint_Click(object sender, EventArgs e)
        {
            DrawFunction2D.PointsSettings drawPointsSettings = this.df_Core.DrawPointsSettings;
            PointF pointF = this.df_Core.PositionDrawToValue(this.PositionViewToImage(this.point_MouseDownPosition));
            if (drawPointsSettings.AddPoint(ref pointF))
            {
                this.df_Core.DrawPoint(true);
                this.RefreshImage();
            }
        }

        private void TSMI_DeletePoint_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(this.df_Core.DrawPointsSettings.RemoveAt(this.i_findPointIndex)))
            {
                this.df_Core.DrawPoint(true);
                this.RefreshImage();
            }
        }

        private void TSMI_ClearPoints_Click(object sender, EventArgs e)
        {
            if (this.df_Core.DrawPointsSettings.Clear())
            {
                this.df_Core.DrawPoint(true);
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

        
        
        private ToolStripMenuItem _TSMI_AddPoint;

        
         
        private ToolStripMenuItem _TSMI_DeletePoint;

        
         
        private ToolStripSeparator _ToolStripSeparator1;

        
        
        private ToolStripMenuItem _TSMI_ClearPoints;

        
        protected float single_FindMaxDistance;

        
        protected DrawFunction2D df_Core;

        
        protected bool b_EnableUsePoints;

        
        protected bool b_MouseDown;

       
        protected int i_findPointIndex;

       
        protected Point point_MouseDownPosition;
    }
}
