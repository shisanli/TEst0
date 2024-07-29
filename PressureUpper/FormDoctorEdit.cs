using PressureUpper.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PressureUpper
{
    public partial class FormDoctorEdit : Form
    {
        public bool IsNew = true;//是否新增
        private DoctorLogic? doctorLogic;
        public Doctor? doctor;
        public FormDoctorEdit()
        {
            InitializeComponent();
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }
        public FormDoctorEdit(Doctor d)
        {
            doctor = d;
            InitializeComponent();
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            dtpCreateTime.Format = DateTimePickerFormat.Custom;
            dtpCreateTime.CustomFormat = "   ";
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

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (doctor != null) doctor.IsSetContent = false;
            this.Close();
        }

        private void FormDoctorEdit_Load(object sender, EventArgs e)
        {
            lblTitle.Text = IsNew ? "新增医生信息" : "修改医生信息";

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!txtPassword.Text.Equals(txtPasswordAgain.Text))
            {
                MessageBox.Show("两次输入的密码不一致请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = "";
                txtPasswordAgain.Text = "";
                txtPassword.Focus();
                return;
            }

            doctor ??= new Doctor();
            doctor.AccountNum = txtAccountNum.Text;
            doctor.Password = ValidateHelper.SHA1Encrypt(txtPassword.Text); 
            doctor.Name = txtName.Text;
            doctor.Sex = rdbMan.Checked ? "1" : "0";
            doctor.Department = txtDepartment.Text;
            doctor.CreateTime = dtpCreateTime.Value;
            doctor.IsAdmin = cmbBoxAdmin.Text.Equals("是") ? true : false;
            doctor.IsDeleted = false;
            doctorLogic ??= new DoctorLogic();
            if (IsNew)
            {
                doctorLogic.InsertDoctor(doctor);
            }
            else
            {
                doctorLogic.UpdateDoctor(doctor);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void DtpCreateTime_ValueChanged(object sender, EventArgs e)
        {
            dtpCreateTime.Format = DateTimePickerFormat.Long;
            dtpCreateTime.CustomFormat = null;
        }


        #region 阴影效果

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled = false;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return enabled == 1 ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }

        #endregion
    }
}
