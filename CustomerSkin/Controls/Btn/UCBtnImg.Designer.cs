﻿namespace CustomerSkin.Controls
{
    /// <summary>
    /// Class UCBtnImg.
    /// Implements the <see cref="CustomerSkin.Controls.UCBtnExt" />
    /// </summary>
    /// <seealso cref="CustomerSkin.Controls.UCBtnExt" />
    partial class UCBtnImg
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Image = global::CustomerSkin.Properties.Resources.back;
            // 
            // UCBtnImg
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.IsShowTips = true;
            this.Name = "UCBtnImg";
            this.ResumeLayout(false);

        }

        #endregion

    }
}
