﻿using System.ComponentModel;

namespace CustomerSkin.Controls
{
    /// <summary>
    /// 父类节点
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// Implements the <see cref="CustomerSkin.Controls.IMenuItem" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    /// <seealso cref="CustomerSkin.Controls.IMenuItem" />
    [ToolboxItem(false)]
    public partial class UCMenuParentItem : UserControl, IMenuItem
    {
        /// <summary>
        /// Occurs when [selected item].
        /// </summary>
        public event EventHandler SelectedItem;

        /// <summary>
        /// The m data source
        /// </summary>
        private MenuItemEntity m_dataSource;
        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        public MenuItemEntity DataSource
        {
            get
            {
                return m_dataSource;
            }
            set
            {
                m_dataSource = value;
                if (value != null)
                {
                    lblTitle.Text = value.Text;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCMenuParentItem" /> class.
        /// </summary>
        public UCMenuParentItem()
        {
            InitializeComponent();
            lblTitle.MouseDown += lblTitle_MouseDown;
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="styles">key:属性名称,value:属性值</param>
        /// <exception cref="System.Exception">菜单元素设置样式异常</exception>
        /// <exception cref="Exception">菜单元素设置样式异常</exception>
        public void SetStyle(Dictionary<string, object> styles)
        {
            Type t = this.GetType();
            foreach (var item in styles)
            {
                var pro = t.GetProperty(item.Key);
                if (pro != null && pro.CanWrite)
                {
                    try
                    {
                        pro.SetValue(this, item.Value, null);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("菜单元素设置样式异常", ex);
                    }
                }
            }
        }

        /// <summary>
        /// 设置选中样式
        /// </summary>
        /// <param name="blnSelected">是否选中</param>
        public void SetSelectedStyle(bool? blnSelected)
        {
            if (blnSelected.HasValue)
            {
                if (blnSelected.Value)
                {
                    this.lblTitle.Image = Properties.Resources.sanjiao1;
                }
                else
                {
                    this.lblTitle.Image = Properties.Resources.sanjiao2;
                }
            }
            else
            {
                this.lblTitle.Image = null;
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the lblTitle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
            {
                SelectedItem(this, e);
            }
        }
    }
}
