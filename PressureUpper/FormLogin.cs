using PressureUpper.Database;
using System.Runtime.InteropServices;

namespace PressureUpper
{
    public partial class FormLogin : Form
    {
        private DoctorLogic? doctorLogic;
        private Doctor? doctor;
        public FormLogin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
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

        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }



        private void BtnOk_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtName.Text.Equals(string.Empty)) return;
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPassword.Text.Equals(string.Empty)) return;
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void Login()
        {
            if (txtName.Text.Equals(string.Empty))
            {
                MessageBox.Show("医生账号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            if (txtPassword.Text.Equals(string.Empty))
            {
                MessageBox.Show("登录密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }
            doctorLogic ??= new DoctorLogic();
            doctor = doctorLogic.GetDoctorByAccountNum(txtName.Text);
            if (doctor != null)
            {
                if (doctor.Password.Equals(ValidateHelper.SHA1Encrypt(txtPassword.Text)) == false)
                {
                    MessageBox.Show("登录密码错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Text = "";
                    txtPassword.Focus();
                    return;
                }
                GlobalVariable.doctor = doctor;
            }
            else
            {
                MessageBox.Show("医生账号不存在，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Text = "";
                txtPassword.Text = "";
                txtName.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
