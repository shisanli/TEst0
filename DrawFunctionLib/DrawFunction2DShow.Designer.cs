using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DrawFunctionLib
{
    partial class DrawFunction2DShow
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
            this.TSMI_DeletePoint = new ToolStripMenuItem();
            this.ToolStripSeparator1 = new ToolStripSeparator();
            this.TSMI_ClearPoints = new ToolStripMenuItem();
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
                this.ToolStripSeparator1,
                this.TSMI_ClearPoints
            });
            this.CMSMain.Name = "CMSMain";
            Control cmsmain = this.CMSMain;
            size = new Size(239, 76);
            cmsmain.Size = size;
            this.TSMI_AddPoint.Name = "TSMI_AddPoint";
            ToolStripItem tsmi_AddPoint = this.TSMI_AddPoint;
            size = new Size(238, 22);
            tsmi_AddPoint.Size = size;
            this.TSMI_AddPoint.Text = "Add Point(添加追踪点)";
            this.TSMI_DeletePoint.Name = "TSMI_DeletePoint";
            ToolStripItem tsmi_DeletePoint = this.TSMI_DeletePoint;
            size = new Size(238, 22);
            tsmi_DeletePoint.Size = size;
            this.TSMI_DeletePoint.Text = "Delete Point(移除追踪点)";
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripItem toolStripSeparator = this.ToolStripSeparator1;
            size = new Size(235, 6);
            toolStripSeparator.Size = size;
            this.TSMI_ClearPoints.Name = "TSMI_ClearPoints";
            ToolStripItem tsmi_ClearPoints = this.TSMI_ClearPoints;
            size = new Size(238, 22);
            tsmi_ClearPoints.Size = size;
            this.TSMI_ClearPoints.Text = "Clear Points(清空所有追踪点)";
            SizeF autoScaleDimensions = new SizeF(7f, 17f);
            this.AutoScaleDimensions = autoScaleDimensions;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.PBMain);
            this.Cursor = Cursors.Cross;
            this.Font = new Font("Comic Sans MS", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Padding margin = new Padding(3, 4, 3, 4);
            this.Margin = margin;
            this.Name = "DrawFunctionShow";
            size = new Size(100, 100);
            this.Size = size;
            ((ISupportInitialize)this.PBMain).EndInit();
            this.CMSMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
