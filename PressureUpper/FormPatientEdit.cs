using NPOI.SS.Formula.Functions;
using NPOI.XWPF.UserModel;
using Org.BouncyCastle.Utilities.Encoders;
using PressureUpper.Database;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Media.Media3D;

namespace PressureUpper
{
    public partial class FormPatientEdit : Form
    {
        public bool IsNew = true;
        private PatientLogic? patientLogic;
        private Doctor? selectDoctor;//选中的医生
        public Patient? patient;
        public FormPatientEdit()
        {
            InitializeComponent();
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            dtpEnterTime.Format = DateTimePickerFormat.Custom;
            dtpEnterTime.CustomFormat = "   ";
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



        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (patient != null) patient.IsSetContent = false;
            this.Close();
        }

        private void FormPatientEdit_Load(object sender, EventArgs e)
        {
            lblTitle.Text = IsNew ? "新增患者信息" : "修改患者信息";
            if (!IsNew && patient != null)
            {
                txtName.Text = patient.Name;
                txtNum.Text = patient.MedicalRecordNum;
                rdbMan.Checked = patient.Sex.Equals("1");
                rdbWoman.Checked = patient.Sex.Equals("0");
                txtWeight.Text = patient.Weight.ToString();
                txtHeight.Text = patient.Height.ToString();
                txtAge.Text = patient.Age.ToString();
                txtDoctorID.Text = patient.DoctorID.ToString();
                txtDoctor.Text = patient.Doctor;
                txtAnesthesiologistID.Text = patient.AnesthesiologistID.ToString();
                txtAnesthesiologist.Text = patient.Anesthesiologist;
                dtpEnterTime.Text = patient.EnterTime.ToString("D");
                txtScore.Text = patient.Score.ToString();
                txtMedicalHistory.Text = patient.MedicalHistory;
                txtDrugAllergy.Text = patient.DrugAllergy;
                txtDiagnosticResult.Text = patient.DiagnosticResult;
                txtOtherInformation.Text = patient.OtherInformation;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //CheckInput();
            if (txtNum.Text.Equals(string.Empty))
            {
                MessageBox.Show("病历号必须输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNum.Focus();
                return;
            }
            if (txtName.Text.Equals(string.Empty))
            {
                MessageBox.Show("患者姓名必须输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            if (!rdbMan.Checked && !rdbWoman.Checked)
            {
                MessageBox.Show("性别必须选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHeight.Text.Equals(string.Empty))
            {
                MessageBox.Show("身高必须输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHeight.Focus();
                return;
            }
            if (!ValidateHelper.IsNumber(txtHeight.Text))
            {
                MessageBox.Show("身高必须是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHeight.Text = "";
                txtHeight.Focus();
                return;
            }

            if (txtWeight.Text.Equals(string.Empty))
            {
                MessageBox.Show("体重必须输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHeight.Focus();
                return;
            }
            if (!ValidateHelper.IsNumber(txtWeight.Text))
            {
                MessageBox.Show("身高必须是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWeight.Text = "";
                txtWeight.Focus();
                return;
            }

            if (txtAge.Text.Equals(string.Empty))
            {
                MessageBox.Show("年龄必须输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAge.Focus();
                return;
            }
            if (!ValidateHelper.IsNumber(txtAge.Text))
            {
                MessageBox.Show("年龄必须是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAge.Text = "";
                txtAge.Focus();
                return;
            }

            if (txtDoctor.Text.Equals(string.Empty))
            {
                MessageBox.Show("医生必须选择输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSelectDoctorOne.Focus();
                return;
            }

            if (txtAnesthesiologist.Text.Equals(string.Empty))
            {
                MessageBox.Show("麻醉医生必须选择输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSelectDoctorTwo.Focus();
                return;
            }

            if (dtpEnterTime.Value.Equals(string.Empty))
            {
                MessageBox.Show("入院日期必须选择输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpEnterTime.Focus();
                return;
            }

            if (!ValidateHelper.IsNumber(txtScore.Text))
            {
                MessageBox.Show("评分必须是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtScore.Text = "";
                txtScore.Focus();
                return;
            }

            patient ??= new Patient();
            patient.Name = txtName.Text;
            patient.MedicalRecordNum = txtNum.Text;
            patient.Sex = rdbMan.Checked ? "男" : "女";
            patient.Weight = int.Parse(txtWeight.Text);
            patient.Height = int.Parse(txtHeight.Text);
            patient.Age = int.Parse(txtAge.Text);
            patient.DoctorID = int.Parse(txtDoctorID.Text);
            patient.Doctor = txtDoctor.Text;
            patient.AnesthesiologistID = int.Parse(txtAnesthesiologistID.Text);
            patient.Anesthesiologist = txtAnesthesiologist.Text;
            patient.EnterTime = dtpEnterTime.Value;
            patient.Score = decimal.Parse(txtScore.Text);
            patient.MedicalHistory = txtMedicalHistory.Text;
            patient.DrugAllergy = txtDrugAllergy.Text;
            patient.DiagnosticResult = txtDiagnosticResult.Text;
            patient.OtherInformation = txtOtherInformation.Text;
            patient.Mark = "";
            patient.IsDeleted = false;
            patient.IsSetContent = true;
            patientLogic ??= new PatientLogic();
            if (IsNew)
            {
                patientLogic.InsertPatient(patient);
            }
            else
            {
                patientLogic.UpdatePatient(patient);
            }
            this.DialogResult = DialogResult.OK;
        }



        private void DtpEnterTime_ValueChanged(object sender, EventArgs e)
        {
            dtpEnterTime.Format = DateTimePickerFormat.Long;
            dtpEnterTime.CustomFormat = null;
        }

        private void BtnSelectDoctorOne_Click(object sender, EventArgs e)
        {
            selectDoctor ??= new();
            FormDoctor frm = new(selectDoctor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDoctorID.Text = selectDoctor?.ID.ToString();
                txtDoctor.Text = selectDoctor?.Name;
            }
        }

        private void BtnSelectDoctorTwo_Click(object sender, EventArgs e)
        {
            selectDoctor ??= new();
            FormDoctor frm = new(selectDoctor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtAnesthesiologistID.Text = selectDoctor?.ID.ToString();
                txtAnesthesiologist.Text = selectDoctor?.Name;
            }
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
