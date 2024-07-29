using PressureUpper.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PressureUpper
{
    public partial class FormRegisterInstrument : Form
    {
        private RecordQueryCondition? condition;
        private SerialPort? serialPortOne;
        private bool success=false;

        public string BatteryLevel = string.Empty;//电池电压
        public string HardwareNumber = string.Empty;//设备号
        public string leftOrRight = string.Empty;//左膝还是右膝
        public FormRegisterInstrument()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }
        public FormRegisterInstrument(RecordQueryCondition c)
        {
            condition = c;
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

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void FormMantCliente_Load(object sender, EventArgs e)
        {

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (HardwareNumber.Equals(string.Empty)|| BatteryLevel.Equals(string.Empty))
            {
                MessageBox.Show("串口设备未激活，请插入设备后点'激活'按钮后再执行完成操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (leftOrRight.Equals(string.Empty))
            {
                MessageBox.Show("请选择手术部位,左膝还是右膝！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string[] PortNames = SerialPort.GetPortNames(); //获取本机串口名称，存入PortNames数组中
            string leftCode = "0x04";
            string receiveData;
            string[] receiveDataSplit;
            BatteryLevel = string.Empty;
            HardwareNumber = string.Empty;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//注册gb2312字符集
            foreach (string PortName in PortNames)
            {
                
                try
                {
                    serialPortOne = new SerialPort(PortName, 115200, Parity.None, 8, StopBits.One);
                    serialPortOne.DtrEnable = false;
                    serialPortOne.RtsEnable = false;
                    serialPortOne.Encoding = Encoding.GetEncoding("GB2312");
                    serialPortOne.Open();
                    //serialPortOne.ReadTimeout = 1000;
                    serialPortOne.WriteTimeout = 1000;
                    int leftint = Convert.ToInt32(leftCode.Substring(leftCode.Length - 1, 1), 16);
                    string s1 = string.Empty;
                    s1 += (char)leftint;
                    serialPortOne.Write(s1);

                    success = false;
                    int setNum = 0;
                    while (!success)
                    {
                        receiveData = serialPortOne.ReadLine();
                        if (receiveData != null && !receiveData.Equals(string.Empty))
                        {
                            receiveDataSplit = receiveData.Split(':');
                            if (receiveDataSplit.Length > 0)
                            {
                                if (receiveDataSplit[0].Equals("设备型号"))
                                {
                                    lblOne.Text = receiveData;
                                    setNum++;
                                }
                                if (receiveDataSplit[0].Equals("单片机唯一识别码"))
                                {
                                    lblNum.Text = receiveDataSplit[1];
                                    HardwareNumber = receiveDataSplit[1];
                                    setNum++;
                                }

                                if (receiveDataSplit[0].Equals("电池电压"))
                                {
                                    lblLevel.Text = receiveData;
                                    BatteryLevel= receiveDataSplit[1];
                                    setNum++;
                                }
                            }
                        }
                        if (setNum == 3)
                        {
                            success = true;
                            btnOne.BackColor = Color.Green;
                            GlobalVariable.serialPortOne = serialPortOne;
                            GlobalVariable.BatteryLevel= BatteryLevel;
                            GlobalVariable.Status = "已连接";
                            lblStatus.Text = "已连接";
                            MessageBox.Show("串口" + PortName + "连接测试完成，连接正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }

                    }
                    if (serialPortOne.IsOpen) serialPortOne.Close();
                    if (success)
                        return;
                }
                catch (Exception ex)
                {
                    success = false;
                    string s = ex.Message;
                    //MessageBox.Show("串口" + PortName + "连接出现错误，请确认已经正确连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    serialPortOne = null;
                }
                if (success)
                    break;
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

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            btnLeft.BackColor = Color.FromArgb(171, 155, 254);// Color.DodgerBlue;
            btnLeft.ForeColor = Color.White;
            btnRight.BackColor = Color.FromArgb(233, 235, 244);
            btnRight.ForeColor = Color.Black;
            leftOrRight = "Left";
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            btnRight.BackColor = Color.FromArgb(171, 155, 254);// Color.DodgerBlue;
            btnRight.ForeColor = Color.White;
            btnLeft.BackColor = Color.FromArgb(233, 235, 244);
            btnLeft.ForeColor = Color.Black;
            leftOrRight = "Right";
        }
    }
}
