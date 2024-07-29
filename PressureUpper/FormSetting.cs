using System.Diagnostics;
using System.IO.Ports;

namespace PressureUpper
{
    public partial class FormSetting : Form
    {
        private SerialPort? serialPortOne;
        private SerialPort? serialPortTwo;
        private bool IsTest = false;
        public FormSetting()
        {
            InitializeComponent();
        }



        private void FormSetting_Load(object sender, EventArgs e)
        {
            SetPorts();
        }

        private void SetPorts()
        {
            string[] PortNames = SerialPort.GetPortNames(); //获取本机串口名称，存入PortNames数组中
            comboBoxPortOne.Text = "";
            comboBoxPortTwo.Text = "";
            comboBoxPortOne.Items.Clear();
            comboBoxPortTwo.Items.Clear();
            for (int i = 0; i < PortNames.Count(); i++)
            {
                comboBoxPortOne.Items.Add(PortNames[i]);   //将数组内容加载到comboBox控件中
                comboBoxPortTwo.Items.Add(PortNames[i]);

            }
        }

        private void TestPorts()
        {
            string one = comboBoxPortOne.Text;
            string two = comboBoxPortTwo.Text;
            string leftCode = "0x02";
            if (one.Equals(string.Empty) && two.Equals(string.Empty))
            {
                MessageBox.Show("至少要选择一个串口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (one.Equals(two))
            {
                MessageBox.Show("两个串口不能相同！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!one.Equals(string.Empty))
            {
                try
                {
                    serialPortOne = new SerialPort(one, 250000, Parity.None, 8, StopBits.One);
                    serialPortOne.DtrEnable = false;
                    serialPortOne.RtsEnable = false;
                    serialPortOne.Open();
                    serialPortOne.ReadTimeout = 1000;
                    serialPortOne.WriteTimeout = 1000;
                    int leftint = Convert.ToInt32(leftCode.Substring(leftCode.Length - 1, 1), 16);
                    string s1 = string.Empty;
                    s1 += (char)leftint;
                    serialPortOne.Write(s1);
                    if (serialPortOne.IsOpen) serialPortOne.Close();
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    MessageBox.Show("串口一连接出现错误，请确认已经正确连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    serialPortOne = null;
                    return;
                }
                MessageBox.Show("串口一连接测试完成，连接正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!two.Equals(string.Empty))
            {
                try
                {
                    serialPortTwo = new SerialPort(two, 250000, Parity.None, 8, StopBits.One);
                    serialPortTwo.DtrEnable = false;
                    serialPortTwo.RtsEnable = false;
                    serialPortTwo.Open();
                    serialPortTwo.ReadTimeout = 1000;
                    serialPortTwo.WriteTimeout = 1000;
                    int leftint = Convert.ToInt32(leftCode.Substring(leftCode.Length - 1, 1), 16);
                    string s1 = string.Empty;
                    s1 += (char)leftint;
                    serialPortTwo.Write(s1);
                    if (serialPortTwo.IsOpen) serialPortTwo.Close();
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    MessageBox.Show("串口二连接出现错误，请确认已经正确连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    serialPortTwo = null;
                    return;
                }
                MessageBox.Show("串口二连接测试完成，连接正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            IsTest = true;

        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            TestPorts();
            
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            string exefile = Application.StartupPath + @"CH341SER.EXE";
            if (File.Exists(exefile))
            {
                Process process = new Process();
                // params 为 string 类型的参数，多个参数以空格分隔，如果某个参数为空，可以传入””
                ProcessStartInfo startInfo = new ProcessStartInfo(exefile, "");
                process.StartInfo = startInfo;
                process.Start();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetPorts();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!IsTest)
            {
                MessageBox.Show("请点击\"测试连接\"按钮，确保已经正确连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            GlobalVariable.testRecord = null;
            GlobalVariable.serialPortOne = serialPortOne;
            GlobalVariable.serialPortTwo = serialPortTwo;
            GlobalVariable.CloudPlaybackOrReportView = "Test";
            this.Close();
        }
    }
}
