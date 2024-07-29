using Dashboard;
using FontAwesome.Sharp;
using PressureUpper.Database;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PressureUpper
{
    public partial class FormMainMenu : Form
    {
        private readonly int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        private IconButton? currentBtn;//当前按钮
        private readonly Panel leftBorderBtn;//当前菜单按钮左侧装饰颜色
        private bool IsMenuClose = true;//菜单是否展开
        private Form? CurrentForm;//当前打开的窗体
        private bool CanCloseCurrentForm = true;//是否能够关闭当前窗体


        private System.Windows.Forms.Timer Timer = null;
        //构造函数
        public FormMainMenu()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            leftBorderBtn = new Panel
            {
                Size = new Size(4, 52)
            };
            panelMenu.Controls.Add(leftBorderBtn);

            Timer = new System.Windows.Forms.Timer() { Interval = 100 };
            Timer.Tick += new EventHandler(Timer_Tick);
            base.Opacity = 0;
            Timer.Start();

            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.DoubleBuffered = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity >= 1)
            {
                Timer.Stop();
            }
            else
            {
                base.Opacity += 0.2;
            }
        }


        //颜色结构
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(192, 192, 0);
        }

        private void ActivateButton(object? senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DissableButton();
                currentBtn = (IconButton)senderBtn;
                //currentBtn.BackColor = Color.FromArgb(44, 119, 186);
                currentBtn.BackColor = Color.FromArgb(171, 155, 254);
                currentBtn.ForeColor = Color.White;
                //currentBtn.IconColor = Color.White;
                currentBtn.IconColor = Color.DodgerBlue;//.FromArgb(255, 128, 7);
                if (IsMenuClose)
                {
                    currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                    currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                }
                else
                {
                    currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                    currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                    currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                }
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                lblTigleChildForm.Text = currentBtn.Text.Trim();
                lblTigleChildForm.ForeColor = color;
            }
        }
        private void DissableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(116, 89, 255);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                //currentBtn.IconColor = Color.FromArgb(58, 116, 166);
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedorPrincipal.Region = region;
            this.Invalidate();

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, 10, 10));
        }


        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams paras = base.CreateParams;
        //        paras.ExStyle |= 0x02000000; //用双缓冲绘制窗口的所有子控件
        //        return paras;
        //    }
        //}
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(116, 89, 255));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        int lx, ly;
        int sw, sh;
        private void BtnMax_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMax.Visible = false;
            btnNormal.Visible = true;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Size.Width, this.Size.Height, 10, 10));

        }

        private void BtnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMax.Visible = true;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Size.Width, this.Size.Height, 10, 10));
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出程序?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void BtnShutDown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出程序?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(Environment.ExitCode);
            }
        }


        private void BtnMenu_Click(object sender, EventArgs e)
        {

            if (panelMenu.Width == 200)
            {
                panelMenu.Width = 65;
                panelContentForm.Width = 1718 + 200 - 65;
                panelContentForm.Location = new Point(65, 100);
                IsMenuClose = false;
            }
            else if (panelMenu.Width == 65)
            {
                panelMenu.Width = 200;
                panelContentForm.Width = 1718;
                panelContentForm.Location = new Point(200, 100);
                IsMenuClose = true;
            }
            ActivateButton(currentBtn, RGBColors.color1);
        }

        private void OpenFormToPanel(object formChild)
        {

            if (this.panelContentForm.Controls.Count > 0)
                this.panelContentForm.Controls.RemoveAt(0);
            if (formChild is Form chm)
            {
                chm.TopLevel = false;
                chm.FormBorderStyle = FormBorderStyle.None;
                chm.Dock = DockStyle.Fill;
                this.panelContentForm.Controls.Add(chm);
                this.panelContentForm.Tag = chm;
                chm.Show();
            }
        }

        private void DisplayFormDashboard()
        {
            //OpenFormToPanel(new FormDashboard());
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"{GlobalVariable.doctor?.Name}";
            //DisplayFormDashboard();
            BtnCloud_Click(this.btnCloud, e);
        }

        private void LoadDashboardForm(object sender, FormClosedEventArgs e)
        {
            DisplayFormDashboard();
        }


        private void TmDateTime_Tick(object sender, EventArgs e)
        {

            lblTime.Text = DateTime.Now.ToString("HH:mm:ssss");
        }


        #region 点击事件



        public void BtnCloud_Click(object sender, EventArgs e)
        {
            if (CanCloseCurrentForm)
            {
                CurrentForm?.Close();
            }
            CanCloseCurrentForm = true;
            ActivateButton(sender, RGBColors.color4);
            FormCloud frm = new(this);
            CurrentForm = frm;
            frm.FormClosed += new FormClosedEventHandler(PanelLogo_Click);
            OpenFormToPanel(frm);
        }
        private void BtnPatient_Click(object sender, EventArgs e)
        {
            CurrentForm?.Close();
            ActivateButton(sender, RGBColors.color1);
            FormPatient frm = new();
            CurrentForm = frm;
            OpenFormToPanel(frm);

        }

        private void BtnDoctor_Click(object sender, EventArgs e)
        {
            CurrentForm?.Close();
            ActivateButton(sender, RGBColors.color2);
            FormDoctor frm = new();
            CurrentForm = frm;
            OpenFormToPanel(frm);

        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            CurrentForm?.Close();
            ActivateButton(sender, RGBColors.color3);
            FormRecord frm = new();
            CurrentForm = frm;
            frm.FormClosed += new FormClosedEventHandler(LoadCloudOrReportForm);
            OpenFormToPanel(frm);
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            if (CanCloseCurrentForm)
            {
                CurrentForm?.Close();
            }
            ActivateButton(sender, RGBColors.color6);
            FormReport frm = new();
            CurrentForm = frm;
            OpenFormToPanel(frm);
        }
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            CurrentForm?.Close();
            ActivateButton(sender, RGBColors.color3);
            FormCheck frm = new();
            CurrentForm = frm;
            OpenFormToPanel(frm);

        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            CurrentForm?.Close();
            ActivateButton(sender, RGBColors.color4);
            FormAdminSetting frm = new();
            //frm.FormClosed += new FormClosedEventHandler(LoadCloudOrReportForm);
            CurrentForm = frm;
            frm.FormClosed += new FormClosedEventHandler(PanelLogo_Click);
            OpenFormToPanel(frm);
        }

        //调用btnSetting点击事件，以便打开设置页面
        public void LoadSettingForm(object sender, EventArgs e)
        {
            BtnSetting_Click(this.btnSetting, e);
        }

        //调用btnCloud点击事件，以便打开云图页面
        private void LoadCloudOrReportForm(object? sender, FormClosedEventArgs e)
        {
            if (GlobalVariable.CloudPlaybackOrReportView.Equals("Cloud") || GlobalVariable.CloudPlaybackOrReportView.Equals("Test"))
            {
                CanCloseCurrentForm = false;
                BtnCloud_Click(this.btnCloud, e);
            }
            else if (GlobalVariable.CloudPlaybackOrReportView.Equals("Report"))
            {
                CanCloseCurrentForm = false;
                BtnReport_Click(this.btnReport, e);
            }
            else if (GlobalVariable.CloudPlaybackOrReportView.Equals(string.Empty))
            {
                //DisplayFormDashboard();
            }
        }

        private void BtnAboutUs_Click(object sender, EventArgs e)
        {
            CurrentForm?.Close();
            ActivateButton(sender, RGBColors.color5);
            FormAboutUs frm = new();
            CurrentForm = frm;
            OpenFormToPanel(frm);
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            CurrentForm?.Close();
            ActivateButton(sender, RGBColors.color6);
            FormHelp frm = new();
            CurrentForm = frm;
            OpenFormToPanel(frm);
        }

        private void PanelLogo_Click(object? sender, EventArgs e)
        {
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            iconCurrentChildForm.IconColor = Color.DodgerBlue;
            lblTigleChildForm.Text = "首页";
            lblTigleChildForm.ForeColor = Color.DodgerBlue;
            leftBorderBtn.BackColor = Color.FromArgb(0, 21, 42);
            DissableButton();
            currentBtn = null;
            DisplayFormDashboard();
        }

        #endregion

        public void SetBatteryLevel(string level)
        {
            try
            {
                int num = int.Parse(level);
                if (num < 2600)
                {
                    btnLevel.Image = PressureUpper.Properties.Resources.battery01;
                }
                if (num > 2600 && num < 2700)
                {
                    btnLevel.Image = PressureUpper.Properties.Resources.battery02;
                }
                if (num > 2700 && num < 2800)
                {
                    btnLevel.Image = PressureUpper.Properties.Resources.battery03;
                }
                if (num > 2800 && num < 2900)
                {
                    btnLevel.Image = PressureUpper.Properties.Resources.battery04;
                }
                if (num > 2900)
                {
                    btnLevel.Image = PressureUpper.Properties.Resources.battery05;
                }
            }
            catch (Exception ex) { }

        }
    }
}
