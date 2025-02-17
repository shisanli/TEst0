using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using CustomerSkin.Win32;
using CustomerSkin.Win32.Struct;
using CustomerSkin.Win32.Const;

namespace CustomerSkin.SkinControl
{
    [ToolboxBitmap(typeof(TabControl))]
    public class SkinTabControl : TabControl
    {
        #region 变量
        private SkinAnimator animator;
        private UpDownButtonNativeWindow _upDownButtonNativeWindow;
        private Color _pagebaseColor = Color.FromArgb(166, 222, 255);
        private Color _arrowbaseColor = Color.FromArgb(166, 222, 255);
        private Color _backColor = Color.Transparent;
        private Color _pageborderColor = Color.FromArgb(23, 169, 254);
        private Color _arrowborderColor = Color.FromArgb(23, 169, 254);
        private Color _arrowColor = Color.FromArgb(0, 79, 125);
        private const string UpDownButtonClassName = "msctls_updown32";
        private ePageImagePosition pageImagePosition = ePageImagePosition.Left;
        private ContentAlignment pageTextAlign = ContentAlignment.MiddleCenter;
        private int radius = 6;
        private int imgTxtSpace = 4;
        private static readonly object EventPaintUpDownButton = new object();
        private DrawStyle drawType = DrawStyle.Img;
        private bool itemStretch = false;
        private Size imgSize = new Size(20, 20);
        private bool pagepalace = false;
        private Rectangle pagebackrectangle = new Rectangle(10, 10, 10, 10);
        private bool animationStart = true;
        /// <summary>
        /// 选项卡箭头区域
        /// </summary>
        private Rectangle _btnArrowRect = Rectangle.Empty;
        /// <summary>
        /// 是否获取了焦点
        /// </summary>
        private bool _isFocus = false;
        #endregion

        #region 无参构造函数
        public SkinTabControl()
            : base()
        {
            this.Font = CustomerSkin.Localization.Localizer.DefaultFont;
            //减少闪烁
            SetStyles();
            animator = new SkinAnimator();
            animator.AnimationType = AnimationType.HorizSlide;
            animator.DefaultAnimation.TimeCoeff = 2f;
            animator.DefaultAnimation.AnimateOnlyDifferences = false;
            //初始化变量
            this.ItemSize = new Size(70, 36);
            this.SizeMode = TabSizeMode.Fixed;
            this.BackColor = Color.Transparent;
        }
        #endregion

        #region 自定义事件
        public event UpDownButtonPaintEventHandler PaintUpDownButton
        {
            add { base.Events.AddHandler(EventPaintUpDownButton, value); }
            remove { base.Events.RemoveHandler(EventPaintUpDownButton, value); }
        }
        #endregion

        #region 属性
        /// <summary>
        /// 关闭按钮区域
        /// </summary>
        private Rectangle _closeRect = new Rectangle(2, 2, 12, 12);
        [Description("Page关闭按钮的位置及大小。")]
        [CategoryAttribute("PageClose")]
        public Rectangle CloseRect
        {
            get { return _closeRect; }
            set
            {
                _closeRect = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Page关闭按钮位置是否在右。
        /// </summary>
        private bool pageCloseLeftToRight = true;
        [Category("PageClose")]
        [DefaultValue(typeof(bool), "true")]
        [Description("Page关闭按钮位置是否在右。")]
        public bool PageCloseLeftToRight
        {
            get { return pageCloseLeftToRight; }
            set
            {
                if (pageCloseLeftToRight != value)
                {
                    pageCloseLeftToRight = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Page是否开启关闭按钮
        /// </summary>
        private bool pageCloseVisble = false;
        [Category("PageClose")]
        [DefaultValue(typeof(bool), "false")]
        [Description("Page是否开启关闭按钮")]
        public bool PageCloseVisble
        {
            get { return pageCloseVisble; }
            set
            {
                if (pageCloseVisble != value)
                {
                    pageCloseVisble = value;
                    this.Invalidate();
                }
            }
        }



        private Image pageCloseHover = Properties.Resources.tab_close_over;
        [CategoryAttribute("PageClose")]
        [Description("Page关闭按钮悬浮时图像")]
        public Image PageCloseHover
        {
            get { return pageCloseHover; }
            set
            {
                pageCloseHover = value;
                base.Invalidate(true);
            }
        }

        private Image pageCloseNormal = Properties.Resources.tab_close_normal;
        [CategoryAttribute("PageClose")]
        [Description("Page关闭按钮默认图像")]
        public Image PageCloseNormal
        {
            get { return pageCloseNormal; }
            set
            {
                pageCloseNormal = value;
                base.Invalidate(true);
            }
        }

        [DefaultValue(typeof(int), "4")]
        [Category("Page")]
        [Description("选项卡文本与图标之间的间隙")]
        public int ImgTxtSpace
        {
            get { return imgTxtSpace; }
            set
            {
                imgTxtSpace = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(DrawStyle), "1")]
        [Category("Page")]
        [Description("选项卡标签的绘画模式")]
        public DrawStyle DrawType
        {
            get { return drawType; }
            set
            {
                if (drawType != value)
                {
                    drawType = value;
                    base.Invalidate();
                }
            }
        }

        /// <summary>
        /// 选项卡标签大小是否可以自动拉伸
        /// </summary>
        [Category("Page")]
        [DefaultValue(typeof(bool), "false")]
        [Description("选项卡标签大小是否可以自动拉伸")]
        public bool ItemStretch
        {
            get { return itemStretch; }
            set
            {
                if ((Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom) || ItemStretch)
                {
                    itemStretch = value;
                    this.Invalidate();
                }
                else
                {
                    MessageBox.Show("自动拉伸不支持左右选项卡模式。", "界面库提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        /// <summary>
        /// Page图标大小
        /// </summary>
        [Category("Page")]
        [DefaultValue(typeof(Size), "20,20")]
        [Description("选项卡上图标的大小")]
        public Size ImgSize
        {
            get { return imgSize; }
            set
            {
                if (imgSize != value)
                {
                    imgSize = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Page是否开启九宫绘图
        /// </summary>
        [Category("Page")]
        [DefaultValue(typeof(bool), "false")]
        [Description("Page是否开启九宫绘图")]
        public bool PagePalace
        {
            get { return pagepalace; }
            set
            {
                if (pagepalace != value)
                {
                    pagepalace = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Page九宫绘画区域
        /// </summary>
        [Category("Page")]
        [DefaultValue(typeof(Rectangle), "10,10,10,10")]
        [Description("Page九宫绘画区域")]
        public Rectangle PageBackRectangle
        {
            get { return pagebackrectangle; }
            set
            {
                if (pagebackrectangle != value)
                {
                    pagebackrectangle = value;
                }
                this.Invalidate();
            }
        }

        private Image pageArrowHover = Properties.Resources.pagearrow_hover;
        [CategoryAttribute("PageArrow")]
        [Description("PageArrow菜单箭头悬浮时背景")]
        public Image PageArrowHover
        {
            get { return pageArrowHover; }
            set
            {
                pageArrowHover = value;
                base.Invalidate(true);
            }
        }

        private Image pageArrowDown = Properties.Resources.pagearrow_down;
        [CategoryAttribute("PageArrow")]
        [Description("PageArrow菜单箭头按下时背景")]
        public Image PageArrowDown
        {
            get { return pageArrowDown; }
            set
            {
                pageArrowDown = value;
                base.Invalidate(true);
            }
        }

        private bool pageArrowVisble = true;
        [CategoryAttribute("PageArrow")]
        [DefaultValue(true)]
        [Description("PageArrow菜单箭头是否显示")]
        public bool PageArrowVisble
        {
            get { return pageArrowVisble; }
            set
            {
                pageArrowVisble = value;
                base.Invalidate(true);
            }
        }

        private Image pageNorml = null;
        [CategoryAttribute("Page")]
        [Description("Page标签默认背景")]
        public Image PageNorml
        {
            get { return pageNorml; }
            set
            {
                pageNorml = value;
                base.Invalidate(true);
            }
        }

        private Image pageHover = Properties.Resources.tabpage_hover;
        [CategoryAttribute("Page")]
        [Description("Page标签悬浮时背景")]
        public Image PageHover
        {
            get { return pageHover; }
            set
            {
                pageHover = value;
                base.Invalidate(true);
            }
        }

        private Image pageDown = Properties.Resources.tabpage_down;
        [CategoryAttribute("Page")]
        [Description("Page标签按下时背景")]
        public Image PageDown
        {
            get { return pageDown; }
            set
            {
                pageDown = value;
                base.Invalidate(true);
            }
        }

        [Category("Page")]
        [Description("选项卡的圆角弧度")]
        [DefaultValue(typeof(int), "6")]
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value < 1 ? 1 : value;
                this.Invalidate(true);
            }
        }

        [Category("Page")]
        [Description("指定选项卡上图像与文本的对齐方式")]
        [DefaultValue(typeof(ePageImagePosition), "Overlay")]
        public ePageImagePosition PageImagePosition
        {
            get
            {
                return pageImagePosition;
            }
            set
            {
                pageImagePosition = value;
                this.Invalidate(true);
            }
        }

        [Category("Page")]
        [Description("将在选项卡标签上显示的文本的对齐方式")]
        [DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public ContentAlignment PageTextAlign
        {
            get
            {
                return pageTextAlign;
            }
            set
            {
                pageTextAlign = value;
                this.Invalidate(true);
            }
        }

        [Category("Skin")]
        [Description("动画效果控制")]
        public AnimationType AnimatorType
        {
            get { return animator.AnimationType; }
            set
            {
                if (value != animator.AnimationType)
                {
                    animator.AnimationType = value;
                }
            }
        }

        [Category("Skin")]
        //[Browsable(false)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("设置动画")]
        public Animation Animation
        {
            get { return animator.DefaultAnimation; }
            set
            {
                if (value != animator.DefaultAnimation)
                {
                    animator.DefaultAnimation = value;
                }
            }
        }

        /// <summary>
        /// 是否开启动画切换效果
        /// </summary>
        [Category("Skin")]
        [DefaultValue(typeof(bool), "true")]
        [Description("是否开启动画切换效果")]
        public bool AnimationStart
        {
            get { return animationStart; }
            set
            {
                if (animationStart != value)
                {
                    animationStart = value;
                }
            }
        }

        [Category("Page")]
        [Description("选项卡标签的背景色")]
        [DefaultValue(typeof(Color), "166, 222, 255")]
        public Color PageBaseColor
        {
            get { return _pagebaseColor; }
            set
            {
                _pagebaseColor = value;
                base.Invalidate(true);
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                base.Invalidate(true);
            }
        }

        //重写背景图片使其可见
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        //使背景图绘制模式可见
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [DefaultValue(typeof(Color), "23, 169, 254")]
        [Category("Page")]
        [Description("边框颜色")]
        public Color PageBorderColor
        {
            get { return _pageborderColor; }
            set
            {
                _pageborderColor = value;
                base.Invalidate(true);
            }
        }

        [DefaultValue(typeof(Color), "0, 79, 125")]
        [Category("Arrow")]
        [Description("左右选项卡的箭头颜色")]
        public Color ArrowColor
        {
            get { return _arrowColor; }
            set
            {
                _arrowColor = value;
                base.Invalidate(true);
            }
        }

        [DefaultValue(typeof(Color), "23, 169, 254")]
        [Category("Arrow")]
        [Description("左右选项卡的箭头边框颜色")]
        public Color ArrowBorderColor
        {
            get { return _arrowborderColor; }
            set
            {
                _arrowborderColor = value;
                base.Invalidate(true);
            }
        }

        [Category("Arrow")]
        [Description("左右选项卡的箭头背景色")]
        [DefaultValue(typeof(Color), "166, 222, 255")]
        public Color ArrowBaseColor
        {
            get { return _arrowbaseColor; }
            set
            {
                _arrowbaseColor = value;
                base.Invalidate(true);
            }
        }

        internal IntPtr UpDownButtonHandle
        {
            get { return FindUpDownButton(); }
        }

        #endregion

        #region 枚举
        public enum ePageImagePosition : int
        {
            Left = 0,
            Right = 1,
            Top = 2,
            Bottom = 3
        }
        #endregion

        #region 重载方法
        //消除边距
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                return new Rectangle(rect.Left - 4, rect.Top - 4, rect.Width + 8, rect.Height + 8);
            }
        }

        //绘画左右箭头按钮
        protected virtual void OnPaintUpDownButton(
            UpDownButtonPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.ClipRectangle;

            Color upButtonBaseColor = _arrowbaseColor;
            Color upButtonBorderColor = _arrowborderColor;
            Color upButtonArrowColor = _arrowColor;

            Color downButtonBaseColor = _arrowbaseColor;
            Color downButtonBorderColor = _arrowborderColor;
            Color downButtonArrowColor = _arrowColor;

            Rectangle upButtonRect = rect;
            upButtonRect.Width = rect.Width / 2 - 1;
            upButtonRect.Height -= 2;

            Rectangle downButtonRect = rect;
            downButtonRect.X = upButtonRect.Right + 2;
            downButtonRect.Width = rect.Width / 2 - 2;
            downButtonRect.Height -= 2;

            if (Enabled)
            {
                if (e.MouseOver)
                {
                    if (e.MousePress)
                    {
                        if (e.MouseInUpButton)
                        {
                            upButtonBaseColor = GetColor(_arrowbaseColor, 0, -35, -24, -9);
                        }
                        else
                        {
                            downButtonBaseColor = GetColor(_arrowbaseColor, 0, -35, -24, -9);
                        }
                    }
                    else
                    {
                        if (e.MouseInUpButton)
                        {
                            upButtonBaseColor = GetColor(_arrowbaseColor, 0, 35, 24, 9);
                        }
                        else
                        {
                            downButtonBaseColor = GetColor(_arrowbaseColor, 0, 35, 24, 9);
                        }
                    }
                }
            }
            else
            {
                upButtonBaseColor = SystemColors.Control;
                upButtonBorderColor = SystemColors.ControlDark;
                upButtonArrowColor = SystemColors.ControlDark;

                downButtonBaseColor = SystemColors.Control;
                downButtonBorderColor = SystemColors.ControlDark;
                downButtonArrowColor = SystemColors.ControlDark;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color backColor = Enabled ? _backColor : SystemColors.Control;

            using (SolidBrush brush = new SolidBrush(_backColor))
            {
                rect.Inflate(1, 1);
                g.FillRectangle(brush, rect);
            }

            RenderButton(
                g,
                upButtonRect,
                upButtonBaseColor,
                upButtonBorderColor,
                upButtonArrowColor,
                ArrowDirection.Left);
            RenderButton(
                g,
                downButtonRect,
                downButtonBaseColor,
                downButtonBorderColor,
                downButtonArrowColor,
                ArrowDirection.Right);

            UpDownButtonPaintEventHandler handler =
                base.Events[EventPaintUpDownButton] as UpDownButtonPaintEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //动画事件
        bool OneShow = false;
        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);
            if ((OneShow && DesignMode || !DesignMode) && AnimationStart)
            {
                animator.BeginUpdateSync(this, false, null, new Rectangle(0, ItemSize.Height + 3, Width, Height - ItemSize.Height - 3));
                BeginInvoke(new MethodInvoker(() => animator.EndUpdate(this)));
            }
            OneShow = true;
            this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!this.DesignMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Rectangle myTabRect = this.GetTabRect(this.SelectedIndex);
                    Rectangle PageCloseRect = new Rectangle(CloseRect.X + myTabRect.X, CloseRect.Y + myTabRect.Y, CloseRect.Width, CloseRect.Height);
                    if (this._btnArrowRect.Contains(e.Location) && PageArrowVisble)
                    {
                        this._isFocus = true;
                        base.Invalidate(this._btnArrowRect);
                    }
                    else if (selectPageClose.Contains(e.Location) && PageCloseVisble)
                    {
                        //如果鼠标在区域内就关闭选项卡   
                        this.TabPages.Remove(this.SelectedTab);
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //是否拉伸选项卡标签
            if ((Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom) && ItemStretch && base.TabCount != 0)
            {
                Multiline = false;
                SizeMode = TabSizeMode.Fixed;
                int ItemWidth = (this.Width - 3) / base.TabCount;
                int ItemHeight = ItemSize.Height;
                Size Items = new Size(ItemWidth, ItemHeight);
                if (base.ItemSize != Items)
                {
                    base.ItemSize = Items;
                }
            }
            else if ((Alignment == TabAlignment.Left || Alignment == TabAlignment.Right) && ItemStretch)
            {
                ItemStretch = false;
            }
            //绘画TabControl
            DrawTabContrl(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                {
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                {
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
                }
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (_upDownButtonNativeWindow != null)
            {
                _upDownButtonNativeWindow.Dispose();
                _upDownButtonNativeWindow = null;
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                {
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                {
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
                }
            }
        }

        #endregion

        #region 减少闪烁方法
        private void SetStyles()
        {
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }
        #endregion

        #region 绘画方法与私有方法
        private IntPtr FindUpDownButton()
        {
            return Win32.NativeMethods.FindWindowEx(
                base.Handle,
                IntPtr.Zero,
                UpDownButtonClassName,
                null);
        }

        private void DrawTabContrl(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            DrawDrawBackgroundAndHeader(g);
            DrawTabPages(e);
        }

        private void DrawDrawBackgroundAndHeader(Graphics g)
        {
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;

            switch (Alignment)
            {
                case TabAlignment.Top:
                    x = 0;
                    y = 0;
                    width = ClientRectangle.Width;
                    height = ClientRectangle.Height - DisplayRectangle.Height;
                    break;
                case TabAlignment.Bottom:
                    x = 0;
                    y = DisplayRectangle.Height;
                    width = ClientRectangle.Width;
                    height = ClientRectangle.Height - DisplayRectangle.Height;
                    break;
                case TabAlignment.Left:
                    x = 0;
                    y = 0;
                    width = ClientRectangle.Width - DisplayRectangle.Width;
                    height = ClientRectangle.Height;
                    break;
                case TabAlignment.Right:
                    x = DisplayRectangle.Width;
                    y = 0;
                    width = ClientRectangle.Width - DisplayRectangle.Width;
                    height = ClientRectangle.Height;
                    break;
            }

            Rectangle headerRect = new Rectangle(x, y, width, height);
            Color backColor = Enabled ? _backColor : SystemColors.Control;
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                g.FillRectangle(brush, ClientRectangle);
                g.FillRectangle(brush, headerRect);
            }
        }

        //指定绘画图像和文本的相对位置
        private void CalculateRect(
            TabPage page, Rectangle tabRect,
            out Rectangle imageRect, out Rectangle textRect)
        {
            Size txtsize = TextRenderer.MeasureText(page.Text, page.Font);
            int space = page.Text.Length == 0 ? 0 : ImgTxtSpace;
            imageRect = Rectangle.Empty;
            textRect = Rectangle.Empty;
            //判断图像是否为空，为空则直接返回文本的范围

            Image image = GetImageByTabPage(page);
            if (image == null)
            {
                textRect = tabRect;
                return;
            }
            else
            {
                switch (PageImagePosition)
                {
                    case ePageImagePosition.Left:
                        if (PageTextAlign == ContentAlignment.BottomLeft
                            || PageTextAlign == ContentAlignment.MiddleLeft
                            || PageTextAlign == ContentAlignment.TopLeft)
                        {
                            imageRect = new Rectangle(
                                tabRect.X,
                                tabRect.Y + (tabRect.Height - ImgSize.Height) / 2,
                                ImgSize.Width,
                                ImgSize.Height);
                            textRect = new Rectangle(
                                imageRect.Right + space,
                                tabRect.Y + (tabRect.Height - txtsize.Height) / 2,
                                //选项卡宽度  -  图片宽度      - 图片左边距               - 图片右边距
                                tabRect.Width - ImgSize.Width - (imageRect.X - tabRect.X) - space,
                                txtsize.Height);
                        }
                        else if (PageTextAlign == ContentAlignment.BottomCenter
                            || PageTextAlign == ContentAlignment.MiddleCenter
                            || PageTextAlign == ContentAlignment.TopCenter)
                        {
                            imageRect = new Rectangle(
                                tabRect.X + (tabRect.Width - (ImgSize.Width + txtsize.Width + space)) / 2,
                                tabRect.Y + (tabRect.Height - ImgSize.Height) / 2,
                                ImgSize.Width,
                                ImgSize.Height);
                            textRect = new Rectangle(
                                imageRect.Right + space,
                                tabRect.Y + (tabRect.Height - txtsize.Height) / 2,
                                //选项卡宽度  -  图片宽度      - 图片左边距               - 图片右边距
                                tabRect.Width - ImgSize.Width - (imageRect.X - tabRect.X) - space,
                                txtsize.Height);
                        }
                        else
                        {
                            imageRect = new Rectangle(
                                tabRect.X + tabRect.Width - (txtsize.Width + space) - ImgSize.Width,
                                tabRect.Y + (tabRect.Height - ImgSize.Height) / 2,
                                ImgSize.Width,
                                ImgSize.Height);
                            textRect = new Rectangle(
                                imageRect.Right + space,
                                tabRect.Y + (tabRect.Height - txtsize.Height) / 2,
                                txtsize.Width,
                                txtsize.Height);
                        }
                        break;
                    case ePageImagePosition.Top:
                        imageRect = new Rectangle(
                            tabRect.X + (tabRect.Width - ImgSize.Width) / 2,
                            tabRect.Y + (tabRect.Height - (ImgSize.Height + txtsize.Height + space)) / 2,
                            ImgSize.Width,
                            ImgSize.Height);
                        textRect = new Rectangle(
                            tabRect.X,
                            imageRect.Bottom + space,
                            tabRect.Width,
                            tabRect.Height - (imageRect.Bottom + space - tabRect.Top));
                        break;
                    case ePageImagePosition.Right:
                        if (PageTextAlign == ContentAlignment.BottomLeft
                            || PageTextAlign == ContentAlignment.MiddleLeft
                            || PageTextAlign == ContentAlignment.TopLeft)
                        {
                            imageRect = new Rectangle(
                                tabRect.X + txtsize.Width + space,
                                tabRect.Y + (tabRect.Height - ImgSize.Height) / 2,
                                ImgSize.Width,
                                ImgSize.Height);
                            textRect = new Rectangle(
                                tabRect.X,
                                tabRect.Y + (tabRect.Height - txtsize.Height) / 2,
                                txtsize.Width,
                                txtsize.Height);
                        }
                        else if (PageTextAlign == ContentAlignment.BottomCenter
                            || PageTextAlign == ContentAlignment.MiddleCenter
                            || PageTextAlign == ContentAlignment.TopCenter)
                        {
                            imageRect = new Rectangle(
                                tabRect.X + (tabRect.Width - (ImgSize.Width + txtsize.Width + space)) / 2 + (txtsize.Width + space),
                                tabRect.Y + (tabRect.Height - ImgSize.Height) / 2,
                                ImgSize.Width,
                                ImgSize.Height);
                            textRect = new Rectangle(
                                imageRect.X - txtsize.Width - space,
                                tabRect.Y + (tabRect.Height - txtsize.Height) / 2,
                                txtsize.Width,
                                txtsize.Height);
                        }
                        else
                        {
                            imageRect = new Rectangle(
                                tabRect.X + tabRect.Width - ImgSize.Width,
                                tabRect.Y + (tabRect.Height - ImgSize.Height) / 2,
                                ImgSize.Width,
                                ImgSize.Height);
                            textRect = new Rectangle(
                                imageRect.X - txtsize.Width - space,
                                tabRect.Y + (tabRect.Height - txtsize.Height) / 2,
                                txtsize.Width,
                                txtsize.Height);
                        }
                        break;
                    case ePageImagePosition.Bottom:
                        imageRect = new Rectangle(
                            tabRect.X + (tabRect.Width - ImgSize.Width) / 2,
                            tabRect.Y + (tabRect.Height - (ImgSize.Height + txtsize.Height + space)) / 2 + (txtsize.Height + space),
                            ImgSize.Width,
                            ImgSize.Height);
                        textRect = new Rectangle(
                            tabRect.X,
                            tabRect.Y,
                            tabRect.Width,
                            imageRect.Y - tabRect.Y - space);
                        break;
                }
            }

            imageRect.X += this.Padding.X;
            imageRect.Y += this.Padding.Y;
            textRect.X += this.Padding.X;
            textRect.Y += this.Padding.Y;
            //if (page.RightToLeft == RightToLeft.Yes)
            //{
            //    imageRect.X = tabRect.Width - imageRect.Right;
            //    textRect.X = tabRect.Width - textRect.Right;
            //}
        }

        //绘画Page标签
        Rectangle selectPageClose = Rectangle.Empty;
        private void DrawTabPages(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle tabRect;
            Point cusorPoint = PointToClient(MousePosition);
            bool hover;
            bool selected;
            bool hasSetClip = false;
            bool alignHorizontal =
                (Alignment == TabAlignment.Top ||
                Alignment == TabAlignment.Bottom);
            LinearGradientMode mode = LinearGradientMode.Vertical;

            if (alignHorizontal)
            {
                IntPtr upDownButtonHandle = UpDownButtonHandle;
                bool hasUpDown = upDownButtonHandle != IntPtr.Zero;
                if (hasUpDown)
                {
                    if (Win32.NativeMethods.IsWindowVisible(upDownButtonHandle))
                    {
                        RECT upDownButtonRect = new RECT();
                        Win32.NativeMethods.GetWindowRect(
                            upDownButtonHandle, ref upDownButtonRect);
                        Rectangle upDownRect = Rectangle.FromLTRB(
                            upDownButtonRect.Left,
                            upDownButtonRect.Top,
                            upDownButtonRect.Right,
                            upDownButtonRect.Bottom);
                        upDownRect = RectangleToClient(upDownRect);

                        switch (Alignment)
                        {
                            case TabAlignment.Top:
                                upDownRect.Y = 0;
                                break;
                            case TabAlignment.Bottom:
                                upDownRect.Y =
                                    ClientRectangle.Height - DisplayRectangle.Height;
                                break;
                        }
                        upDownRect.Height = ClientRectangle.Height;
                        g.SetClip(upDownRect, CombineMode.Exclude);
                        hasSetClip = true;
                    }
                }
            }

            for (int index = 0; index < base.TabCount; index++)
            {
                TabPage page = TabPages[index];
                tabRect = GetTabRect(index);
                if (ItemStretch && this.Width > 0)
                {
                    if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                    {
                        int ItemWidth = this.Width / base.TabCount;
                        int ItemHeight = ItemSize.Height;
                        int span = DrawType != DrawStyle.Draw ? 2 : 0;
                        int ItemX = index * ItemWidth + span;
                        int ItemY = tabRect.Y;
                        tabRect = new Rectangle(ItemX, ItemY, ItemWidth, ItemHeight);
                    }
                }
                hover = tabRect.Contains(cusorPoint);
                selected = SelectedIndex == index;

                Color baseColor = _pagebaseColor;
                Color borderColor = _pageborderColor;
                Image baseBack = PageNorml;
                Image pageArrow = null;
                Point cursorPoint = this.PointToClient(MousePosition);

                if (selected)
                {
                    baseColor = GetColor(_pagebaseColor, 0, -45, -30, -14);
                    baseBack = PageDown;
                }
                else if (hover)
                {
                    baseColor = GetColor(_pagebaseColor, 0, 35, 24, 9);
                    baseBack = PageHover;
                }
                //画背景
                if (DrawType == DrawStyle.Img && baseBack != null)
                {
                    //偏移标签达到无边距
                    int x = Alignment == TabAlignment.Right ? 1 : -2;
                    int y = Alignment == TabAlignment.Bottom ? 1 : -2;
                    tabRect.Offset(x, y);
                    Rectangle hoverRect = new Rectangle(tabRect.X + this.Padding.X, tabRect.Y + this.Padding.Y, tabRect.Width, tabRect.Height);
                    //是否启用九宫绘图
                    if (PagePalace)
                    {
                        ImageDrawRect.DrawRect(g, (Bitmap)baseBack, hoverRect, Rectangle.FromLTRB(PageBackRectangle.X, PageBackRectangle.Y, PageBackRectangle.Width, PageBackRectangle.Height), 1, 1);
                    }
                    else
                    {
                        this.DrawImage(g, baseBack, hoverRect);
                    }
                    if (selected && PageArrowVisble)
                    {
                        Point contextMenuLocation = this.PointToScreen(new Point(this._btnArrowRect.Left, this._btnArrowRect.Top + this._btnArrowRect.Height + 5));
                        ContextMenuStrip contextMenuStrip = this.TabPages[index].ContextMenuStrip;
                        if (contextMenuStrip != null)
                        {
                            contextMenuStrip.Closed -= new ToolStripDropDownClosedEventHandler(contextMenuStrip_Closed);
                            contextMenuStrip.Closed += new ToolStripDropDownClosedEventHandler(contextMenuStrip_Closed);
                            if (contextMenuLocation.X + contextMenuStrip.Width >
                           Screen.PrimaryScreen.WorkingArea.Width - 20)
                            {
                                contextMenuLocation.X = Screen.PrimaryScreen.WorkingArea.Width -
                                    contextMenuStrip.Width - 50;
                            }
                            if (tabRect.Contains(cursorPoint))
                            {
                                if (this._isFocus)
                                {
                                    pageArrow = pageArrowDown;
                                    contextMenuStrip.Show(contextMenuLocation);
                                }
                                else
                                {
                                    pageArrow = pageArrowHover;
                                }
                                this._btnArrowRect = new Rectangle(tabRect.X + tabRect.Width - pageArrow.Width, tabRect.Y, pageArrow.Width, tabRect.Height);
                            }
                            else if (this._isFocus)
                            {
                                pageArrow = pageArrowDown;
                                contextMenuStrip.Show(contextMenuLocation);
                            }
                            else
                            {
                                pageArrow = null;
                            }
                            if (pageArrow != null)
                            {
                                //当鼠标进入当前选中的的选项卡时，显示下拉按钮
                                this.DrawImage(g, pageArrow, this._btnArrowRect);
                            }
                        }
                    }
                }
                else if (DrawType == DrawStyle.Draw)
                {
                    RenderTabBackgroundInternal(
                        g,
                        tabRect,
                        baseColor,
                        borderColor,
                        .45F,
                        mode);
                }
                else
                {
                    //偏移标签达到无边距
                    int x = Alignment == TabAlignment.Right ? 1 : -2;
                    int y = Alignment == TabAlignment.Bottom ? 1 : -2;
                    tabRect.Offset(x, y);
                }
                //给图像位置和文本位置赋值
                Rectangle imageRect;
                Rectangle textRect;
                this.CalculateRect(page, tabRect, out imageRect, out textRect);
                //绘画图像
                DrawTabImage(g, page, imageRect);
                //绘画文字
                TextRenderer.DrawText(
                    g,
                    page.Text,
                    page.Font,
                    textRect,
                    page.ForeColor,
                    GetTextFormatFlags(PageTextAlign, page.RightToLeft == RightToLeft.Yes, page));
                //绘画关闭按钮
                if (PageCloseVisble)
                {
                    Rectangle PageCloseRect = new Rectangle(CloseRect.X + tabRect.X, CloseRect.Y + tabRect.Y, CloseRect.Width, CloseRect.Height);
                    if (PageCloseLeftToRight)
                    {
                        PageCloseRect = new Rectangle(tabRect.Right - CloseRect.Width - CloseRect.X, CloseRect.Y + tabRect.Y, CloseRect.Width, CloseRect.Height);
                    }
                    selectPageClose = PageCloseRect.Contains(cusorPoint) ? PageCloseRect : selectPageClose;
                    //如果是色调绘画模式
                    if (DrawType == DrawStyle.Draw)
                    {
                        Color closecolor = PageCloseRect.Contains(cusorPoint) ? GetColor(_pagebaseColor, 0, 35, 24, 9) : _pagebaseColor;
                        RenderBackgroundInternal(
                            g,
                            PageCloseRect,
                            closecolor,
                            borderColor,
                            0.45f,
                            true,
                            LinearGradientMode.Vertical);

                        //画关闭符号
                        using (Pen objpen = new Pen(Color.Black))
                        {
                            //自己画X
                            //"\"线
                            Point p1 = new Point(PageCloseRect.X + 3, PageCloseRect.Y + 3);
                            Point p2 = new Point(PageCloseRect.X + PageCloseRect.Width - 3, PageCloseRect.Y + PageCloseRect.Height - 3);
                            g.DrawLine(objpen, p1, p2);
                            //"/"线
                            Point p3 = new Point(PageCloseRect.X + 3, PageCloseRect.Y + PageCloseRect.Height - 3);
                            Point p4 = new Point(PageCloseRect.X + PageCloseRect.Width - 3, PageCloseRect.Y + 3);
                            g.DrawLine(objpen, p3, p4);
                        }
                    }
                    else if (DrawType == DrawStyle.Img)
                    {
                        Image img = PageCloseRect.Contains(cusorPoint) ? PageCloseHover : PageCloseNormal;
                        if (img != null)
                        {
                            g.DrawImage(img, PageCloseRect);
                        }
                    }
                }
            }
            if (hasSetClip)
            {
                g.ResetClip();
            }
        }

        void contextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this._isFocus = false;
            base.Invalidate(this._btnArrowRect);
        }

        private class TransparentControl : Control
        {
            protected override void OnPaintBackground(PaintEventArgs pevent) { }
            protected override void OnPaint(PaintEventArgs e) { }
        }

        public TextFormatFlags GetTextFormatFlags(
          ContentAlignment alignment,
          bool rightToleft,
          TabPage page)
        {
            TextFormatFlags flags = TextFormatFlags.WordBreak |
                TextFormatFlags.SingleLine;
            if (rightToleft)
            {
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            }
            else 
            {
                flags |= TextFormatFlags.Left;
            }

            switch (alignment)
            {
                case ContentAlignment.BottomCenter:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleCenter:
                    flags |= TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleLeft:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                case ContentAlignment.MiddleRight:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.TopCenter:
                    flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopLeft:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
            }

            Image image = GetImageByTabPage(page);
            if ((PageImagePosition == ePageImagePosition.Left || PageImagePosition == ePageImagePosition.Right) && image != null)
            {
                flags = TextFormatFlags.Left;
            }
            return flags;
        }

        /// <summary>
        /// 绘图
        /// </summary>
        /// <param name="g"></param>
        /// <param name="image"></param>
        /// <param name="rect"></param>
        private void DrawImage(Graphics g, Image image, Rectangle rect)
        {
            g.DrawImage(image, new Rectangle(rect.X, rect.Y, 5, rect.Height), 0, 0, 5, image.Height,
                GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle(rect.X + 5, rect.Y, rect.Width - 10, rect.Height), 5, 0, image.Width - 10, image.Height, GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle(rect.X + rect.Width - 5, rect.Y, 5, rect.Height), image.Width - 5, 0, 5, image.Height, GraphicsUnit.Pixel);
        }
        internal void RenderArrowInternal(
             Graphics g,
             Rectangle dropDownRect,
             ArrowDirection direction,
             Brush brush)
        {
            Point point = new Point(
                dropDownRect.Left + (dropDownRect.Width / 2),
                dropDownRect.Top + (dropDownRect.Height / 2));
            Point[] points = null;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points = new Point[] { 
                        new Point(point.X + 1, point.Y - 4), 
                        new Point(point.X + 1, point.Y + 4), 
                        new Point(point.X - 2, point.Y) };
                    break;

                case ArrowDirection.Up:
                    points = new Point[] { 
                        new Point(point.X - 3, point.Y + 1), 
                        new Point(point.X + 3, point.Y + 1), 
                        new Point(point.X, point.Y - 1) };
                    break;

                case ArrowDirection.Right:
                    points = new Point[] {
                        new Point(point.X - 1, point.Y - 4), 
                        new Point(point.X - 1, point.Y + 4), 
                        new Point(point.X + 2, point.Y) };
                    break;

                default:
                    points = new Point[] {
                        new Point(point.X - 3, point.Y - 1), 
                        new Point(point.X + 3, point.Y - 1), 
                        new Point(point.X, point.Y + 1) };
                    break;
            }
            g.FillPolygon(brush, points);
        }

        internal void RenderButton(
            Graphics g,
            Rectangle rect,
            Color baseColor,
            Color borderColor,
            Color arrowColor,
            ArrowDirection direction)
        {
            RenderBackgroundInternal(
                g,
                rect,
                baseColor,
                borderColor,
                0.45f,
                true,
                LinearGradientMode.Vertical);
            using (SolidBrush brush = new SolidBrush(arrowColor))
            {
                RenderArrowInternal(
                    g,
                    rect,
                    direction,
                    brush);
            }
        }

        internal void RenderBackgroundInternal(
          Graphics g,
          Rectangle rect,
          Color baseColor,
          Color borderColor,
          float basePosition,
          bool drawBorder,
          LinearGradientMode mode)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
               rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 68, 69, 54);

                ColorBlend blend = new ColorBlend();
                blend.Positions =
                    new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, rect);
            }
            if (baseColor.A > 80)
            {
                Rectangle rectTop = rect;
                if (mode == LinearGradientMode.Vertical)
                {
                    rectTop.Height = (int)(rectTop.Height * basePosition);
                }
                else
                {
                    rectTop.Width = (int)(rect.Width * basePosition);
                }
                using (SolidBrush brushAlpha =
                    new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                {
                    g.FillRectangle(brushAlpha, rectTop);
                }
            }

            if (drawBorder)
            {
                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawRectangle(pen, rect);
                }
            }
        }

        internal void RenderTabBackgroundInternal(
          Graphics g,
          Rectangle rect,
          Color baseColor,
          Color borderColor,
          float basePosition,
          LinearGradientMode mode)
        {
            using (GraphicsPath path = CreateTabPath(rect))
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                   rect, Color.Transparent, Color.Transparent, mode))
                {
                    Color[] colors = new Color[4];
                    colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                    colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                    colors[2] = baseColor;
                    colors[3] = GetColor(baseColor, 0, 68, 69, 54);

                    ColorBlend blend = new ColorBlend();
                    blend.Positions =
                        new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                    blend.Colors = colors;
                    brush.InterpolationColors = blend;
                    g.FillPath(brush, path);
                }

                if (baseColor.A > 80)
                {
                    Rectangle rectTop = rect;
                    if (mode == LinearGradientMode.Vertical)
                    {
                        rectTop.Height = (int)(rectTop.Height * basePosition);
                    }
                    else
                    {
                        rectTop.Width = (int)(rect.Width * basePosition);
                    }
                    using (SolidBrush brushAlpha =
                        new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                    {
                        g.FillRectangle(brushAlpha, rectTop);
                    }
                }

                rect.Inflate(-1, -1);
                using (GraphicsPath path1 = CreateTabPath(rect))
                {
                    using (Pen pen = new Pen(Color.FromArgb(255, 255, 255)))
                    {
                        if (Multiline)
                        {
                            g.DrawPath(pen, path1);
                        }
                        else
                        {
                            g.DrawLines(pen, path1.PathPoints);
                        }
                    }
                }

                using (Pen pen = new Pen(borderColor))
                {
                    if (Multiline)
                    {
                        g.DrawPath(pen, path);
                    }
                    {
                        g.DrawLines(pen, path.PathPoints);
                    }
                }
            }
        }

        private void DrawTabImage(Graphics g, TabPage page, Rectangle rect)
        {
            if (ImageList != null)
            {
                Image image = GetImageByTabPage(page);
                if (image != null)
                {
                    g.DrawImage(image, rect);
                }
            }
        }

        private GraphicsPath CreateTabPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            switch (Alignment)
            {
                case TabAlignment.Top:
                    rect.X++;
                    rect.Width -= 2;
                    path.AddLine(
                        rect.X,
                        rect.Bottom,
                        rect.X,
                        rect.Y + radius / 2);
                    path.AddArc(
                        rect.X,
                        rect.Y,
                        radius,
                        radius,
                        180F,
                        90F);
                    path.AddArc(
                        rect.Right - radius,
                        rect.Y,
                        radius,
                        radius,
                        270F,
                        90F);
                    path.AddLine(
                        rect.Right,
                        rect.Y + radius / 2,
                        rect.Right,
                        rect.Bottom);
                    break;
                case TabAlignment.Bottom:
                    rect.X++;
                    rect.Width -= 2;
                    path.AddLine(
                        rect.X,
                        rect.Y,
                        rect.X,
                        rect.Bottom - radius / 2);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius,
                        radius,
                        radius,
                        180,
                        -90);
                    path.AddArc(
                        rect.Right - radius,
                        rect.Bottom - radius,
                        radius,
                        radius,
                        90,
                        -90);
                    path.AddLine(
                        rect.Right,
                        rect.Bottom - radius / 2,
                        rect.Right,
                        rect.Y);

                    break;
                case TabAlignment.Left:
                    rect.Y++;
                    rect.Height -= 2;
                    path.AddLine(
                        rect.Right,
                        rect.Y,
                        rect.X + radius / 2,
                        rect.Y);
                    path.AddArc(
                        rect.X,
                        rect.Y,
                        radius,
                        radius,
                        270F,
                        -90F);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius,
                        radius,
                        radius,
                        180F,
                        -90F);
                    path.AddLine(
                        rect.X + radius / 2,
                        rect.Bottom,
                        rect.Right,
                        rect.Bottom);
                    break;
                case TabAlignment.Right:
                    rect.Y++;
                    rect.Height -= 2;
                    path.AddLine(
                        rect.X,
                        rect.Y,
                        rect.Right - radius / 2,
                        rect.Y);
                    path.AddArc(
                        rect.Right - radius,
                        rect.Y,
                        radius,
                        radius,
                        270F,
                        90F);
                    path.AddArc(
                        rect.Right - radius,
                        rect.Bottom - radius,
                        radius,
                        radius,
                        0F,
                        90F);
                    path.AddLine(
                        rect.Right - radius / 2,
                        rect.Bottom,
                        rect.X,
                        rect.Bottom);
                    break;
            }
            path.CloseFigure();
            return path;
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }

            return Color.FromArgb(a, r, g, b);
        }

        private Image GetImageByTabPage(TabPage page)
        {
            Image image = null;
            if (ImageList != null)
            {
                if (!string.IsNullOrEmpty(page.ImageKey))
                {
                    image = ImageList.Images[page.ImageKey];
                }
                else if (page.ImageIndex != -1)
                {
                    image = ImageList.Images[page.ImageIndex];
                }
            }
            return image;
        }
        #endregion

        #region UpDownButtonNativeWindow

        private class UpDownButtonNativeWindow : NativeWindow, IDisposable
        {
            private SkinTabControl _owner;
            private bool _bPainting;
            public const int VK_LBUTTON = 0x1;
            public const int VK_RBUTTON = 0x2;

            public UpDownButtonNativeWindow(SkinTabControl owner)
                : base()
            {
                _owner = owner;
                base.AssignHandle(owner.UpDownButtonHandle);
            }

            private bool LeftKeyPressed()
            {
                if (SystemInformation.MouseButtonsSwapped)
                {
                    return (Win32.NativeMethods.GetKeyState(VK_RBUTTON) < 0);
                }
                else
                {
                    return (Win32.NativeMethods.GetKeyState(VK_LBUTTON) < 0);
                }
            }

            private void DrawUpDownButton()
            {
                bool mouseOver = false;
                bool mousePress = LeftKeyPressed();
                bool mouseInUpButton = false;

                RECT rect = new RECT();

                Win32.NativeMethods.GetClientRect(base.Handle, ref rect);

                Rectangle clipRect = Rectangle.FromLTRB(
                    rect.Top, rect.Left, rect.Right, rect.Bottom);

                Win32.NativeMethods.Point cursorPoint = new Win32.NativeMethods.Point();
                Win32.NativeMethods.GetCursorPos(ref cursorPoint);
                Win32.NativeMethods.GetWindowRect(base.Handle, ref rect);

                mouseOver = Win32.NativeMethods.PtInRect(ref rect, cursorPoint);

                cursorPoint.x -= rect.Left;
                cursorPoint.y -= rect.Top;

                mouseInUpButton = cursorPoint.x < clipRect.Width / 2;

                using (Graphics g = Graphics.FromHwnd(base.Handle))
                {
                    UpDownButtonPaintEventArgs e =
                        new UpDownButtonPaintEventArgs(
                        g,
                        clipRect,
                        mouseOver,
                        mousePress,
                        mouseInUpButton);
                    _owner.OnPaintUpDownButton(e);
                }
            }

            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM.WM_PAINT:
                        if (!_bPainting)
                        {
                            PAINTSTRUCT ps =
                                new PAINTSTRUCT();
                            _bPainting = true;
                            Win32.NativeMethods.BeginPaint(m.HWnd, ref ps);
                            DrawUpDownButton();
                            Win32.NativeMethods.EndPaint(m.HWnd, ref ps);
                            _bPainting = false;
                            m.Result = Result.TRUE;
                        }
                        else
                        {
                            base.WndProc(ref m);
                        }
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }

            #region IDisposable 成员

            public void Dispose()
            {
                _owner = null;
                base.ReleaseHandle();
            }

            #endregion
        }

        #endregion
    }
    #region SkinTabPage
    //[Designer(typeof(System.Windows.Forms.Design.ScrollableControlDesigner))]
    public class SkinTabPage : TabPage
    {
        #region 无参构造与带参构造
        public SkinTabPage()
        {
            //初始化减少闪烁
            Init();
            this.BackColor = Color.White;
            this.UseVisualStyleBackColor = false;
        }


        public SkinTabPage(string text)
            : this()
        {
            //初始化减少闪烁
            Init();
            this.Text = text;
            this.BackColor = Color.White;
            this.UseVisualStyleBackColor = false;
        }
        #endregion

        #region 初始化
        public void Init()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ContainerControl, true);
        }
        #endregion

        #region 析构函数
        ~SkinTabPage()
        {
            GC.SuppressFinalize(this);
        }
        #endregion

        #region 属性
        [DefaultValue(true)]
        [Browsable(true)]
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
            }
        }
        #endregion
    }
    #endregion
}
