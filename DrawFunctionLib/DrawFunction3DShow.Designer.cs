using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DrawFunctionLib
{
    partial class DrawFunction3DShow
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            this.PBMain = new PictureBox();
            this.CMSMain = new ContextMenuStrip(this.components);
            this.TSMI_AddPoint = new ToolStripMenuItem();
            this.TSMI_InputTip = new ToolStripMenuItem();
            this.TSTB_X = new ToolStripTextBox();
            this.TSTB_Y = new ToolStripTextBox();
            this.TSTB_Z = new ToolStripTextBox();
            this.ToolStripSeparator2 = new ToolStripSeparator();
            this.TSMI_AddThisPoint = new ToolStripMenuItem();
            this.TSMI_DeletePoint = new ToolStripMenuItem();
            this.ToolStripSeparator4 = new ToolStripSeparator();
            this.TSMI_ClearPoints = new ToolStripMenuItem();
            this.ToolStripSeparator1 = new ToolStripSeparator();
            this.TSMI_Rotation = new ToolStripMenuItem();
            this.TSMI_RotationInput = new ToolStripMenuItem();
            this.TSTB_DX = new ToolStripTextBox();
            this.TSTB_DY = new ToolStripTextBox();
            this.TSTB_DZ = new ToolStripTextBox();
            this.ToolStripSeparator3 = new ToolStripSeparator();
            this.RotateImageToolStripMenuItem = new ToolStripMenuItem();
            this.TSMI_RotateImageTo = new ToolStripMenuItem();
            this.ToolStripSeparator5 = new ToolStripSeparator();
            this.TSMI_ResetLocation = new ToolStripMenuItem();
            ((ISupportInitialize)this.PBMain).BeginInit();
            this.CMSMain.SuspendLayout();
            this.SuspendLayout();
            this.PBMain.BackColor = Color.Transparent;
            this.PBMain.BackgroundImageLayout = ImageLayout.Stretch;
            this.PBMain.Dock = DockStyle.Fill;
            Control pbmain = this.PBMain;
            Point location = new Point(0, 0);
            pbmain.Location = location;
            this.PBMain.Name = "PBMain";
            Control pbmain2 = this.PBMain;
            Size size = new Size(100, 100);
            pbmain2.Size = size;
            this.PBMain.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PBMain.TabIndex = 0;
            this.PBMain.TabStop = false;
            this.CMSMain.Items.AddRange(new ToolStripItem[]
            {
                this.TSMI_AddPoint,
                this.TSMI_DeletePoint,
                this.ToolStripSeparator4,
                this.TSMI_ClearPoints,
                this.ToolStripSeparator1,
                this.TSMI_Rotation
            });
            this.CMSMain.Name = "CMSMain";
            Control cmsmain = this.CMSMain;
            size = new Size(143, 104);
            cmsmain.Size = size;
            this.TSMI_AddPoint.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.TSMI_InputTip,
                this.TSTB_X,
                this.TSTB_Y,
                this.TSTB_Z,
                this.ToolStripSeparator2,
                this.TSMI_AddThisPoint
            });
            this.TSMI_AddPoint.Name = "TSMI_AddPoint";
            ToolStripItem tsmi_AddPoint = this.TSMI_AddPoint;
            size = new Size(142, 22);
            tsmi_AddPoint.Size = size;
            this.TSMI_AddPoint.Text = "Add Point";
            this.TSMI_InputTip.Enabled = false;
            this.TSMI_InputTip.Name = "TSMI_InputTip";
            ToolStripItem tsmi_InputTip = this.TSMI_InputTip;
            size = new Size(172, 22);
            tsmi_InputTip.Size = size;
            this.TSMI_InputTip.Text = "Location(x, y, z)";
            this.TSTB_X.Name = "TSTB_X";
            ToolStripControlHost tstb_X = this.TSTB_X;
            size = new Size(100, 21);
            tstb_X.Size = size;
            this.TSTB_Y.Name = "TSTB_Y";
            ToolStripControlHost tstb_Y = this.TSTB_Y;
            size = new Size(100, 21);
            tstb_Y.Size = size;
            this.TSTB_Z.Name = "TSTB_Z";
            ToolStripControlHost tstb_Z = this.TSTB_Z;
            size = new Size(100, 21);
            tstb_Z.Size = size;
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripItem toolStripSeparator = this.ToolStripSeparator2;
            size = new Size(169, 6);
            toolStripSeparator.Size = size;
            this.TSMI_AddThisPoint.Name = "TSMI_AddThisPoint";
            ToolStripItem tsmi_AddThisPoint = this.TSMI_AddThisPoint;
            size = new Size(172, 22);
            tsmi_AddThisPoint.Size = size;
            this.TSMI_AddThisPoint.Text = "Add this Point";
            this.TSMI_DeletePoint.Name = "TSMI_DeletePoint";
            ToolStripItem tsmi_DeletePoint = this.TSMI_DeletePoint;
            size = new Size(142, 22);
            tsmi_DeletePoint.Size = size;
            this.TSMI_DeletePoint.Text = "Delete Point";
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            ToolStripItem toolStripSeparator2 = this.ToolStripSeparator4;
            size = new Size(139, 6);
            toolStripSeparator2.Size = size;
            this.TSMI_ClearPoints.Name = "TSMI_ClearPoints";
            ToolStripItem tsmi_ClearPoints = this.TSMI_ClearPoints;
            size = new Size(142, 22);
            tsmi_ClearPoints.Size = size;
            this.TSMI_ClearPoints.Text = "Clear Points";
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripItem toolStripSeparator3 = this.ToolStripSeparator1;
            size = new Size(139, 6);
            toolStripSeparator3.Size = size;
            this.TSMI_Rotation.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.TSMI_RotationInput,
                this.TSTB_DX,
                this.TSTB_DY,
                this.TSTB_DZ,
                this.ToolStripSeparator3,
                this.RotateImageToolStripMenuItem,
                this.TSMI_RotateImageTo,
                this.ToolStripSeparator5,
                this.TSMI_ResetLocation
            });
            this.TSMI_Rotation.Name = "TSMI_Rotation";
            ToolStripItem tsmi_Rotation = this.TSMI_Rotation;
            size = new Size(142, 22);
            tsmi_Rotation.Size = size;
            this.TSMI_Rotation.Text = "Rotation";
            this.TSMI_RotationInput.Enabled = false;
            this.TSMI_RotationInput.Name = "TSMI_RotationInput";
            ToolStripItem tsmi_RotationInput = this.TSMI_RotationInput;
            size = new Size(160, 22);
            tsmi_RotationInput.Size = size;
            this.TSMI_RotationInput.Text = "Degree(x,y,z)";
            this.TSTB_DX.Name = "TSTB_DX";
            ToolStripControlHost tstb_DX = this.TSTB_DX;
            size = new Size(100, 21);
            tstb_DX.Size = size;
            this.TSTB_DY.Name = "TSTB_DY";
            ToolStripControlHost tstb_DY = this.TSTB_DY;
            size = new Size(100, 21);
            tstb_DY.Size = size;
            this.TSTB_DZ.Name = "TSTB_DZ";
            ToolStripControlHost tstb_DZ = this.TSTB_DZ;
            size = new Size(100, 21);
            tstb_DZ.Size = size;
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            ToolStripItem toolStripSeparator4 = this.ToolStripSeparator3;
            size = new Size(157, 6);
            toolStripSeparator4.Size = size;
            this.RotateImageToolStripMenuItem.Name = "RotateImageToolStripMenuItem";
            ToolStripItem rotateImageToolStripMenuItem = this.RotateImageToolStripMenuItem;
            size = new Size(160, 22);
            rotateImageToolStripMenuItem.Size = size;
            this.RotateImageToolStripMenuItem.Text = "Rotate Image";
            this.TSMI_RotateImageTo.Name = "TSMI_RotateImageTo";
            ToolStripItem tsmi_RotateImageTo = this.TSMI_RotateImageTo;
            size = new Size(160, 22);
            tsmi_RotateImageTo.Size = size;
            this.TSMI_RotateImageTo.Text = "Rotate Image To";
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            ToolStripItem toolStripSeparator5 = this.ToolStripSeparator5;
            size = new Size(157, 6);
            toolStripSeparator5.Size = size;
            this.TSMI_ResetLocation.Name = "TSMI_ResetLocation";
            ToolStripItem tsmi_ResetLocation = this.TSMI_ResetLocation;
            size = new Size(160, 22);
            tsmi_ResetLocation.Size = size;
            this.TSMI_ResetLocation.Text = "Reset Location";
            SizeF autoScaleDimensions = new SizeF(7f, 17f);
            this.AutoScaleDimensions = autoScaleDimensions;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.PBMain);
            this.Cursor = Cursors.Cross;
            this.Font = new Font("Comic Sans MS", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Padding margin = new Padding(3, 4, 3, 4);
            this.Margin = margin;
            this.Name = "DrawFunction3DShow";
            size = new Size(100, 100);
            this.Size = size;
            ((ISupportInitialize)this.PBMain).EndInit();
            this.CMSMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
