
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using CustomerSkin.SkinClass;
using CustomerSkin.Win32;
using CustomerSkin.Win32.Const;

namespace CustomerSkin.SkinControl
{
    [ToolboxBitmap(typeof(TextBox))]
    public class SkinWaterTextBox : TextBox
    {
        #region 构造函数
        public SkinWaterTextBox()
        {
            this.Font = CustomerSkin.Localization.Localizer.DefaultFont;
        } 
        #endregion

        #region 变量
        /// <summary>
        /// 水印文字
        /// </summary>
        private string _waterText = string.Empty;
        /// <summary>
        /// 水印文字的颜色
        /// </summary>
        private Color _waterColor = Color.FromArgb(127, 127, 127);
        #endregion

        #region 属性
        /// <summary>
        /// 
        /// </summary>
        [Description("水印文字"), Category("Skin")]
        public string WaterText
        {
            get { return this._waterText; }
            set
            {
                this._waterText = value;
                base.Invalidate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("水印的颜色"), Category("Skin")]
        public Color WaterColor
        {
            get { return this._waterColor; }
            set
            {
                this._waterColor = value;
                base.Invalidate();
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 绘制水印
        /// </summary>
        private void WmPaintWater(ref Message m)
        {
            using (Graphics g = Graphics.FromHwnd(base.Handle))
            {
                //最高质量绘制文字
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                if (this.Text.Length == 0 &&
                    !string.IsNullOrEmpty(this._waterText) &&
                    !this.Focused)
                {
                    TextFormatFlags flags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
                    if (this.RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                    {
                        flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                    }
                    TextRenderer.DrawText(g, this._waterText, new Font(CustomerSkin.Localization.Localizer.DefaultFont.FontFamily, 8.5f), this.ClientRectangle, this._waterColor, flags);
                }
            }
        }
        #endregion

        #region 重载事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM.WM_PAINT || m.Msg == WM.WM_CTLCOLOREDIT)
                this.WmPaintWater(ref m);//绘制水印
        }
        #endregion
    }
}
