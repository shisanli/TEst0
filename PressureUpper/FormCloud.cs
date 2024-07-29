using DrawFunctionLib;
using FontAwesome.Sharp;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using PressureUpper.Database;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using static DrawFunctionLib.DrawFunction3D;

namespace PressureUpper
{
    public partial class FormCloud : Form
    {

        #region 初始变量
        FormMainMenu mainMenu;
        private TestRecord testRecord;
        private TestRecordLogic testRecordLogic;
        private bool IsComplete = false;//回放是否停止
        private Patient? selectPatient;
        private string fileRecordDataPathOne = string.Empty;
        private string fileRecordDataPathTwo = string.Empty;
        private StreamWriter writerOne;//写文本数据流对象1
        private StreamWriter writerTwo;//写文本数据流对象2
        private StreamReader readerOne;//读文本数据流对象1
        private StreamReader readerTwo;//读文本数据流对象2

        public string HardwareNumber = string.Empty;//设备号
        public string leftOrRight = string.Empty;//左膝还是右膝


        //public static float unit_ratio = 43.1f / 4095;
        public static float unit_ratio = 999.0f / 4095;



        private readonly Action DisplayAction;
        private readonly Action ComAction;
        private readonly Action PlaybackAction;
        int ting = 0; //是否停止
        int ifsend = 0;//是否发送
        int countReceive = 1;//接收总次数
        int countReceiveLeft = 1;//左侧接收总次数
        int sendCount = 1;//发送总次数
        public DrawModel3D_V2 Model3D = new DrawModel3D_V2();




        DrawFunction3D.PointF3D maxPoint;
        DrawFunction3D.PointF3D minPoint;
        DrawFunction3D.PointF3D centerPoint;

        private SerialPort? serialPortOne; //串口One
        private SerialPort? serialPortTwo; //串口Two


        private Thread threadSend;//数据发送线程
        private Thread threadReceiveOne;//串口1数据接收线程
        private Thread threadPlaybackOne;//数据回放线程

        private bool isReceiving = false;//是否接收中
        private bool isReceivingTwo = false;//是否接收中

        private double leftSum;//左侧总数
        private double rightSum;//右侧总数


        int num_value = 0, max_value_row = 0, max_value_col = 0, min_value_row = 0, min_value_col = 0;
        int num_valueleft = 0, max_value_rowleft = 0, max_value_colleft = 0, min_value_rowleft = 0, min_value_colleft = 0;
        float avg_value = 0, max_value = -9.9e30f, min_value = 9.9e30f, sum_F = 0, sum_x_F = 0, sum_y_F = 0, sum_z_F = 0;



        /// 模拟传感器数据
        private FormPressureMock formPressureMock;

        //图表控件模型用于角度数据显示
        private ChartViewModel ChartModelAngle;
        //图表控件模型用于实时数据显示
        private ChartViewModel ChartModelRealTime;
        //力差图表
        private ChartViewModel ChartModelDiff;
        //显示实时数据
        private bool IsRealTime = true;
        //是否抓取数据
        private bool IsCatchData = false;
        private string Angle = string.Empty;//抓取角度

        private bool IsClearZero = true;//是否清零
        private List<float[]> zeroTemp = new List<float[]>();//清零临时列表One
        private readonly int avgFrameCount = 10;//取均值帧数
        private float[] avgValue = new float[66];//均值one

        private float[] CorrectionFactorA = new float[30];//校正系数A
        private float[] CorrectionFactorB = new float[30];//校正系数B


        #endregion

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int wndproc);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public const int GWL_STYLE = -16;
        public const int WS_DISABLED = 0x8000000;





        //控制禁用状态下的按钮字体颜色
        public static void SetControlEnabled(Control c, bool enabled)
        {
            if (enabled)
            { SetWindowLong(c.Handle, GWL_STYLE, (~WS_DISABLED) & GetWindowLong(c.Handle, GWL_STYLE)); }
            else
            { SetWindowLong(c.Handle, GWL_STYLE, WS_DISABLED + GetWindowLong(c.Handle, GWL_STYLE)); }
        }



        public FormCloud(FormMainMenu m)
        {
            InitializeComponent();
            this.mainMenu = m;

            DisplayAction = new Action(DatabaseDisplayControl);//画图的线程
            ComAction = new Action(ComConnectionControl);//发送与接收的线程
            PlaybackAction = new Action(PlaybackControl);//回放的线程

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //cts = new CancellationTokenSource();
            //formPressureMock ??= new FormPressureMock();
            //formPressureMock.Show();


            for (var i = 0; i < 30; i++)
            {
                if (i < 15)
                {
                    CorrectionFactorA[i] = 0.079f;//校正系数A
                    CorrectionFactorB[i] = 0.0f;//校正系数B
                }
                else
                {
                    CorrectionFactorA[i] = 0.079f;//校正系数A
                    CorrectionFactorB[i] = 0.0f;//校正系数B
                }
            }

        }

        //开始测试
        private void BtnCloudStartTest_Click(object sender, EventArgs e)
        {
            if (!GlobalVariable.CloudPlaybackOrReportView.Equals("Cloud"))
            {
                if (GlobalVariable.serialPortOne == null && GlobalVariable.serialPortTwo == null)
                {
                    MessageBox.Show("请先点击'注册设备'按钮完成端口设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //mainMenu.LoadSettingForm(sender, e);
                    return;
                }
                if (txtCloudName.Text.Trim() == string.Empty)
                {

                    MessageBox.Show("请整填写被试姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCloudName.Focus();
                    return;
                }
                if (txtCloudHeight.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("请完整填写被试身高！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCloudHeight.Focus();
                    return;
                }
                if (!ValidateHelper.IsNumber(txtCloudHeight.Text))
                {
                    MessageBox.Show("被试者身高必须是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCloudHeight.Text = "";
                    txtCloudHeight.Focus();
                    return;
                }
                if (txtCloudWeight.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("请完整填写被试体重！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCloudWeight.Focus();
                    return;
                }

                if (!ValidateHelper.IsNumber(txtCloudWeight.Text))
                {
                    MessageBox.Show("被试者体重必须是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCloudWeight.Text = "";
                    txtCloudWeight.Focus();
                    return;
                }

                if (txtCloudAge.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("请完整填写被试年龄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCloudAge.Focus();
                    return;
                }

                if (!ValidateHelper.IsNumber(txtCloudAge.Text))
                {
                    MessageBox.Show("被试者年龄必须是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCloudAge.Text = "";
                    txtCloudAge.Focus();
                    return;
                }

                testRecord = new TestRecord
                {

                    Name = txtCloudName.Text,
                    Age = int.Parse(txtCloudAge.Text),
                    Weight = decimal.Parse(txtCloudWeight.Text),
                    Height = decimal.Parse(txtCloudAge.Text),
                    Sex = txtSex.Text,
                    MedicalRecordNum = txtNum.Text,
                    //EnterTime = DateTime.Parse(txtEnter.Text),
                    OperationDate = DateTime.Now,
                    BegainTime = DateTime.Now,
                    HardwareNumber = "",
                    Mark = "",
                    ReportPath = "",

                };
                avgValue = new float[66];//均值初始化
                IsComplete = false;
                IsClearZero = true;
                //连接串口
                ComAction.Invoke();
                //画图
                DisplayAction.Invoke();
                timerRealTime.Enabled = true;
            }
            else
            {
                if (!GlobalVariable.testRecord.OnePath.Equals(string.Empty))
                {
                    var file = Application.StartupPath + @"RecordData\" + GlobalVariable.testRecord.OnePath;
                    if (!File.Exists(file))
                    {
                        MessageBox.Show("记录文件不存在，无法回放！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                leftOrRight = GlobalVariable.testRecord.Left ? "Left" : "Right";
                IsCatchData = true;
                IsComplete = false;
                IsClearZero = true;
                SetDirectionInfo();
                PlaybackAction.Invoke();
                timerRealTime.Enabled = true;
            }



            //关闭功能，防止误操作
            //btnCloudStartTest.Enabled = false;
            SetControlEnabled(this.btnCloudStartTest, false);
            this.btnCloudStartTest.ForeColor = Color.Gainsboro;

            //启用暂停 完成 三维 按钮
            SetingPlaybackInfo(true);

            //timer1.Enabled = true;
        }



        #region 回放相关
        private void PlaybackControl()
        {
            if (GlobalVariable.testRecord == null) return;
            if (!GlobalVariable.testRecord.OnePath.Equals(string.Empty))
            {
                pictureBoxOne.Visible = false;
                ThreadStart threadStart = new(ReadFromFileOne);//通过ThreadStart委托告诉子线程执行什么方法　　
                threadPlaybackOne = new Thread(threadStart);
                Control.CheckForIllegalCrossThreadCalls = false;
                threadPlaybackOne.Start();

            }


        }

        private float getSensorPres(string num)
        {
            float result = 0f;
            try
            {
                result = float.Parse(Regex.Replace(num, @"[^0-9]+", ""));
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        private void ReadFromFileOne()
        {
            if (!GlobalVariable.testRecord.OnePath.Equals(string.Empty))
            {

                string file = Application.StartupPath + @"RecordData\" + GlobalVariable.testRecord.OnePath;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//注册gb2312字符集
                readerOne = new StreamReader(file, Encoding.GetEncoding("GB2312"));
                if (readerOne != null)
                {
                    try
                    {
                        string receiveData;
                        string[] data_receive;
                        int tempLength;
                        string strNum = string.Empty;
                        k = 0;//重置索引
                        float num = 0f;
                        pres = new float[66];
                        Model3D.Head.Read(System.Windows.Forms.Application.StartupPath + @"Profile\knee_mesh.txt");
                        while (!readerOne.EndOfStream && !IsComplete)
                        {
                            if (readerOne == null) break;
                            receiveData = readerOne.ReadLine();

                            //try
                            //{
                            if (receiveData != null)
                            {

                                if (receiveData != "" && !receiveData.Contains("帧号") && !receiveData.Contains("单片机唯一识别码") && !receiveData.Contains("设备型号") && !receiveData.Contains("电池电压"))
                                {
                                    data_receive = receiveData.TrimEnd(',').Split(',');
                                    if (data_receive.Length == 0) return;  //如果读空行，跳过 设备型号
                                    tempLength = data_receive.Length;
                                    if (tempLength == 15)
                                    {
                                        if (k == 0)
                                        {
                                            num = (float)Math.Truncate(getSensorPres(data_receive[0]) * CorrectionFactorA[0] + CorrectionFactorB[0]);
                                            pres[19] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[1]) * CorrectionFactorA[1] + CorrectionFactorB[1]);
                                            pres[12] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[2]) * CorrectionFactorA[2] + CorrectionFactorB[2]);
                                            pres[20] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[3]) * CorrectionFactorA[3] + CorrectionFactorB[3]);
                                            pres[6] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[4]) * CorrectionFactorA[4] + CorrectionFactorB[4]);
                                            pres[13] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[5]) * CorrectionFactorA[5] + CorrectionFactorB[5]);
                                            pres[7] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[6]) * CorrectionFactorA[6] + CorrectionFactorB[6]);
                                            pres[21] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[7]) * CorrectionFactorA[7] + CorrectionFactorB[7]);
                                            pres[14] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[8]) * CorrectionFactorA[8] + CorrectionFactorB[8]);
                                            pres[16] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[9]) * CorrectionFactorA[9] + CorrectionFactorB[9]);
                                            pres[24] = num > 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[10]) * CorrectionFactorA[10] + CorrectionFactorB[10]);
                                            pres[9] = num >= 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[11]) * CorrectionFactorA[11] + CorrectionFactorB[11]);
                                            pres[23] = num >= 0f ? 0f : num;

                                            num = (float)Math.Truncate(getSensorPres(data_receive[12]) * CorrectionFactorA[12] + CorrectionFactorB[12]);
                                            pres[8] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[13]) * CorrectionFactorA[13] + CorrectionFactorB[13]);
                                            pres[15] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[14]) * CorrectionFactorA[14] + CorrectionFactorB[14]);
                                            pres[22] = num < 0f ? 0f : num;
                                        }
                                        if (k == 1)
                                        {
                                            num = (float)Math.Truncate(getSensorPres(data_receive[0]) * CorrectionFactorA[15] + CorrectionFactorB[15]);
                                            pres[47] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[1]) * CorrectionFactorA[16] + CorrectionFactorB[16]);
                                            pres[40] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[2]) * CorrectionFactorA[17] + CorrectionFactorB[17]);
                                            pres[54] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[3]) * CorrectionFactorA[18] + CorrectionFactorB[18]);
                                            pres[46] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[4]) * CorrectionFactorA[19] + CorrectionFactorB[19]);
                                            pres[39] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[5]) * CorrectionFactorA[20] + CorrectionFactorB[20]);
                                            pres[45] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[6]) * CorrectionFactorA[21] + CorrectionFactorB[21]);
                                            pres[53] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[7]) * CorrectionFactorA[22] + CorrectionFactorB[22]);
                                            pres[52] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[8]) * CorrectionFactorA[23] + CorrectionFactorB[23]);
                                            pres[55] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[9]) * CorrectionFactorA[24] + CorrectionFactorB[24]);
                                            pres[41] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[10]) * CorrectionFactorA[25] + CorrectionFactorB[25]);
                                            pres[42] = num > 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[11]) * CorrectionFactorA[26] + CorrectionFactorB[26]);
                                            pres[48] = num > 0f ? 0f : num;

                                            num = (float)Math.Truncate(getSensorPres(data_receive[12]) * CorrectionFactorA[27] + CorrectionFactorB[27]);
                                            pres[56] = num < 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[13]) * CorrectionFactorA[28] + CorrectionFactorB[28]);
                                            pres[49] = num > 0f ? 0f : num;
                                            num = (float)Math.Truncate(getSensorPres(data_receive[14]) * CorrectionFactorA[29] + CorrectionFactorB[29]);
                                            pres[57] = num > 0f ? 0f : num;


                                            if (IsClearZero)//清零计算均值
                                            {
                                                zeroTemp.Add(pres);
                                                if (zeroTemp.Count == avgFrameCount)
                                                {
                                                    CalculateAvgValue();
                                                    zeroTemp.Clear();
                                                    IsClearZero = false;
                                                }
                                            }


                                            Model3D.Pressure.PressureBufferV2 = new float[66];
                                            setPressureAvg();
                                            Model3D.Pressure.PressureBufferV2 = (float[])pres.Clone(); //传递到画云图

                                            
                                            Model3D.Pressure.ReadFromBuffer(-1);
                                            this.Invoke(new MethodInvoker(() => SetChartIndex(Model3D.Pressure.PressureBufferV2, true)));
                                            draw3dShowOne.IndexDrawFunction = Model3D.DrawTools;


                                            Model3D.InitialSet();

                                            CalculateParameter(Model3D.Pressure.PressureV2, Model3D.Head.Data3D);
                                            Model3D.Draw3D(max_value_row, max_value_col, min_value_row, min_value_col, centerPoint);
                                            draw3dShowOne.Invoke(new MethodInvoker(() => draw3dShowOne.RefreshImage()));
                                            DrawPressure(Model3D.Pressure.PressureMax, draw2dShowOne);

                                        }
                                        k++;
                                    }
                                }
                                else
                                {

                                    k = 0;//重置索引
                                    pres = new float[66];

                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }



        #endregion
        #region 串口相关

      
        private void ComConnectionControl()//控制发送和接收两个线程的启动
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//注册gb2312字符集
            if (GlobalVariable.serialPortOne != null)
            {

                serialPortOne = GlobalVariable.serialPortOne;
                //serialPortOne.DtrEnable = false;
                //如果为 true，则启用数据终端就绪 (DTR)；否则为 false。 默认为 false。
                //serialPortOne.RtsEnable = false;
                //如果为 true，则启用请求发送 (RTS)；否则为 false。 默认为 false。
                serialPortOne.ReadBufferSize = 650;
                serialPortOne.Encoding = System.Text.Encoding.GetEncoding("GB2312");

                if (!serialPortOne.IsOpen)
                    this.serialPortOne.Open();

                //创建数据文件
                fileRecordDataPathOne = Application.StartupPath + @"RecordData\" + testRecord.Name + "-" + testRecord.BegainTime.ToString("yyyy-MM-dd-HH-mm-ss") + "-One.txt";
                FileStream stream = File.Open(fileRecordDataPathOne, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Seek(0, SeekOrigin.Begin);
                stream.SetLength(0);
                stream.Close();
                writerOne = new StreamWriter(fileRecordDataPathOne, true, Encoding.GetEncoding("gb2312"));

                //创建抓取角度文件
                fileRecordDataPathTwo = Application.StartupPath + @"AngleData\" + testRecord.Name + "-" + testRecord.BegainTime.ToString("yyyy-MM-dd-HH-mm-ss") + "-Angle..csv";
                stream = File.Open(fileRecordDataPathTwo, FileMode.OpenOrCreate, FileAccess.Write);
                string ColumnHead = "部位,角度,力差,合力,外力,内力,抓取时间";
                stream.Seek(0, SeekOrigin.Begin);
                stream.SetLength(0);
                stream.Close();
                writerTwo = new StreamWriter(fileRecordDataPathTwo, true, Encoding.GetEncoding("gb2312"));
                writerTwo.Write(ColumnHead + "\r\n");

                pictureBoxOne.Visible = false;

                ThreadStart threadStartOne = new(SerialPortOneDataReceived);// new(ReceiveFromComOne);
                threadReceiveOne = new Thread(threadStartOne);
                threadReceiveOne.Start();

            }
            


            ifsend = 0;
            ThreadStart threadStart = new(SendToCom);//通过ThreadStart委托告诉子线程执行什么方法　　
            threadSend = new Thread(threadStart);
            threadSend.Start();
            ifsend = 1;

            countReceive = 1;
            countReceiveLeft = 1;
            sendCount = 1;
        }


       

        private void SendToCom()//向端口发送指令
        {
            string leftCode = "0x02";
            //while (1 == 1)
            //{

            int leftint = Convert.ToInt32(leftCode.Substring(leftCode.Length - 1, 1), 16);
            string s1 = string.Empty;
            s1 += (char)leftint;
            if (serialPortOne != null && serialPortOne.IsOpen)
                this.serialPortOne.Write(s1);
            if (serialPortTwo != null && serialPortTwo.IsOpen)
                this.serialPortTwo.Write(s1);
            Thread.Sleep(2000);
            //}
        }


        private int k = 0;
        private float[] pres = new float[66];
        private void SerialPortOneDataReceived()//(object sendr, SerialDataReceivedEventArgs e)//串口一接收数据
        {
            //if (IsComplete) return;//如果完成则不进行接收
            string receiveData;
            string[] data_receive;
            int tempLength = 0;
            string strNum = string.Empty;
            int thistimes = 0;
            float num;
            while (!IsComplete)
            {
                try
                {
                    receiveData = serialPortOne.ReadLine();
                
                    isReceiving = true;
                    if (receiveData != null)
                    {
                        if (receiveData != "" && !receiveData.Contains("帧号") && !receiveData.Contains("image") && !receiveData.Contains("电池电压"))
                        {
                            DateTime beforeDT = System.DateTime.Now;
                            rightSum = 0;
                            writerOne.WriteLine(receiveData);//写入文件
                            data_receive = receiveData.TrimEnd(',').Split(',');
                            if (data_receive.Length == 0) return;  //如果读空行，跳过
                            tempLength = data_receive.Length;
                            if (tempLength == 15)
                            {
                                if (k == 0)
                                {
                                    num = (float)Math.Truncate(getSensorPres(data_receive[0]) * CorrectionFactorA[0] + CorrectionFactorB[0]);
                                    pres[19] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[1]) * CorrectionFactorA[1] + CorrectionFactorB[1]);
                                    pres[12] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[2]) * CorrectionFactorA[2] + CorrectionFactorB[2]);
                                    pres[20] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[3]) * CorrectionFactorA[3] + CorrectionFactorB[3]);
                                    pres[6] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[4]) * CorrectionFactorA[4] + CorrectionFactorB[4]);
                                    pres[13] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[5]) * CorrectionFactorA[5] + CorrectionFactorB[5]);
                                    pres[7] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[6]) * CorrectionFactorA[6] + CorrectionFactorB[6]);
                                    pres[21] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[7]) * CorrectionFactorA[7] + CorrectionFactorB[7]);
                                    pres[14] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[8]) * CorrectionFactorA[8] + CorrectionFactorB[8]);
                                    pres[16] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[9]) * CorrectionFactorA[9] + CorrectionFactorB[9]);
                                    pres[24] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[10]) * CorrectionFactorA[10] + CorrectionFactorB[10]);
                                    pres[9] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[11]) * CorrectionFactorA[11] + CorrectionFactorB[11]);
                                    pres[23] = num < 0f ? 0f : num;

                                    num = (float)Math.Truncate(getSensorPres(data_receive[12]) * CorrectionFactorA[12] + CorrectionFactorB[12]);
                                    pres[8] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[13]) * CorrectionFactorA[13] + CorrectionFactorB[13]);
                                    pres[15] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[14]) * CorrectionFactorA[14] + CorrectionFactorB[14]);
                                    pres[22] = num < 0f ? 0f : num;
                                }
                                if (k == 1)
                                {
                                    num = (float)Math.Truncate(getSensorPres(data_receive[0]) * CorrectionFactorA[15] + CorrectionFactorB[15]);
                                    pres[47] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[1]) * CorrectionFactorA[16] + CorrectionFactorB[16]);
                                    pres[40] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[2]) * CorrectionFactorA[17] + CorrectionFactorB[17]);
                                    pres[54] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[3]) * CorrectionFactorA[18] + CorrectionFactorB[18]);
                                    pres[46] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[4]) * CorrectionFactorA[19] + CorrectionFactorB[19]);
                                    pres[39] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[5]) * CorrectionFactorA[20] + CorrectionFactorB[20]);
                                    pres[45] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[6]) * CorrectionFactorA[21] + CorrectionFactorB[21]);
                                    pres[53] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[7]) * CorrectionFactorA[22] + CorrectionFactorB[22]);
                                    pres[52] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[8]) * CorrectionFactorA[23] + CorrectionFactorB[23]);
                                    pres[55] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[9]) * CorrectionFactorA[24] + CorrectionFactorB[24]);
                                    pres[41] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[10]) * CorrectionFactorA[25] + CorrectionFactorB[25]);
                                    pres[42] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[11]) * CorrectionFactorA[26] + CorrectionFactorB[26]);
                                    pres[48] = num < 0f ? 0f : num;

                                    num = (float)Math.Truncate(getSensorPres(data_receive[12]) * CorrectionFactorA[27] + CorrectionFactorB[27]);
                                    pres[56] = num < 0f ? 0f : num;
                                    num = (float)Math.Truncate(getSensorPres(data_receive[13]) * CorrectionFactorA[28] + CorrectionFactorB[28]);
                                    pres[49] = num < 0f ? 0f : num;
                                     num = (float)Math.Truncate(getSensorPres(data_receive[14]) * CorrectionFactorA[29] + CorrectionFactorB[29]);
                                    pres[57] = num < 0f ? 0f : num;

                                    if (!fileRecordDataPathOne.Equals(string.Empty))
                                        testRecord.OnePath = testRecord.Name + "-" + testRecord.BegainTime.ToString("yyyy-MM-dd-HH-mm-ss") + "-One.txt"; //数据文件路径


                                    if (IsClearZero)//清零计算均值
                                    {
                                        zeroTemp.Add(pres);
                                        if (zeroTemp.Count == avgFrameCount)
                                        {
                                            CalculateAvgValue();
                                            zeroTemp.Clear();
                                            IsClearZero = false;
                                        }
                                    }

                                    Model3D.Pressure.PressureBufferV2 = new float[66];
                                    setPressureAvg();
                                    Model3D.Pressure.PressureBufferV2 = (float[])pres.Clone(); //传递到画云图


                                    countReceive++;
                                    ++thistimes;
                                    DateTime afterDT = System.DateTime.Now;
                                    TimeSpan ts = afterDT.Subtract(beforeDT);
                                    int sleeptime = thistimes * 1000 / 10 - (int)ts.TotalMilliseconds;

                                }
                                k++;
                            }
                        }
                        else
                        {
                            writerOne.WriteLine(receiveData);//写入文件
                            k = 0;//重置索引
                            pres = new float[66];

                        }


                    }
                }
                catch (Exception e1)
                {
                    //Console.WriteLine(e1);
                    //Console.WriteLine("port_DataReceived-Error:" + e1.Message, 0);
                }
                finally
                {
                    isReceiving = false;
                }
            }

        }

        private void setPressureAvg()
        {
            for (int i = 0; i < pres.Length; ++i)
            {
                    pres[i] = (pres[i] - avgValue[i]) < 0 ? 0 : (pres[i] - avgValue[i]);
            }
        }

        private void CalculateAvgValue()
        {
            avgValue = new float[66];

            //列表零值相加
            foreach (float[] item in zeroTemp)
            {
                for (int i = 0; i < item.Length; ++i)
                {

                        avgValue[i] = avgValue[i] + item[i];
                }
            }

            //计算均值

            for (int i = 0; i < avgValue.Length; ++i)//有几行
            {
                    avgValue[i] = (float)Math.Floor(avgValue[i] / avgFrameCount);
            }
        }


        #endregion


        #region 绘图相关方法

        private void DatabaseDisplayControl()
        {

            if (GlobalVariable.serialPortOne != null)
            {
                ThreadStart dotask3 = new ThreadStart(DrawOne);
                Thread tskTHread3 = new Thread(dotask3);
                tskTHread3.Start();
                draw3dShowOne.Enabled = false;
            }
        }

        private float[] ChartDataBuff = new float[4];
        private void SetChartIndex(float[] pres, bool IsPlayBack = false)
        {
            float LeftSum = 0f;
            float RightSum = 0f;
            string csvValue = "\t";
            //左侧
            LeftSum += pres[19];
            LeftSum += pres[12];
            LeftSum += pres[20];
            LeftSum += pres[6];
            LeftSum += pres[13];
            LeftSum += pres[7];
            LeftSum += pres[21];
            LeftSum += pres[14];
            LeftSum += pres[16];
            LeftSum += pres[24];
            LeftSum += pres[9];
            LeftSum += pres[23];
            LeftSum += pres[8];
            LeftSum += pres[15];
            LeftSum += pres[22];

            //右侧

            RightSum += pres[47];
            RightSum += pres[40];
            RightSum += pres[54];
            RightSum += pres[46];
            RightSum += pres[39] ;
            RightSum += pres[45];
            RightSum += pres[53];
            RightSum += pres[52] ;
            RightSum += pres[55];
            RightSum += pres[41];
            RightSum += pres[42];
            RightSum += pres[48];
            RightSum += pres[56];
            RightSum += pres[49] ;
            RightSum += pres[57];

            //修正
            LeftSum = (float)Math.Floor(LeftSum / 15);
            RightSum = (float)Math.Floor(RightSum / 15);


            if (!leftOrRight.Equals(string.Empty) && leftOrRight.Equals("Right"))
            {

                lblPressureOne.Text = LeftSum.ToString();
                lblPressureTwo.Text = RightSum.ToString();
                lblPressureDiff.Text = (RightSum - LeftSum).ToString();
                lblPressureSum.Text = (RightSum + LeftSum).ToString();
                lblDirectionOne.Text = "内";
                lblDirectionTwo.Text = "外";
                ChartDataBuff[0] = RightSum - LeftSum;
                ChartDataBuff[1] = RightSum + LeftSum;
                ChartDataBuff[2] = LeftSum;
                ChartDataBuff[3] = RightSum;
                if (IsCatchData)
                {
                    if (Angle.Equals("0度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[0] = RightSum - LeftSum;
                        //ChartModelAngle.Series[0].Values[0] = RightSum - LeftSum;
                        //ChartModelAngle.Series[1].Values[0] = RightSum + LeftSum;
                        ChartModelAngle.Series[0].Values[0] = LeftSum;
                        ChartModelAngle.Series[1].Values[0] = RightSum;

                    }
                    if (Angle.Equals("30度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[1] = RightSum - LeftSum;
                        //ChartModelAngle.Series[0].Values[1] = RightSum - LeftSum;
                        //ChartModelAngle.Series[1].Values[1] = RightSum + LeftSum;
                        ChartModelAngle.Series[0].Values[1] = LeftSum;
                        ChartModelAngle.Series[1].Values[1] = RightSum;

                    }
                    if (Angle.Equals("45度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[2] = RightSum - LeftSum;
                        //ChartModelAngle.Series[0].Values[2] = RightSum - LeftSum;
                        //ChartModelAngle.Series[1].Values[2] = RightSum + LeftSum;
                        ChartModelAngle.Series[0].Values[2] = LeftSum;
                        ChartModelAngle.Series[1].Values[2] = RightSum;

                    }
                    if (Angle.Equals("60度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[3] = RightSum - LeftSum;
                        //ChartModelAngle.Series[0].Values[3] = RightSum - LeftSum;
                        //ChartModelAngle.Series[1].Values[3] = RightSum + LeftSum;
                        ChartModelAngle.Series[1].Values[3] = LeftSum;
                        ChartModelAngle.Series[1].Values[3] = RightSum;

                    }
                    if (Angle.Equals("90度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[4] = RightSum - LeftSum;
                        //ChartModelAngle.Series[0].Values[4] = RightSum - LeftSum;
                        //ChartModelAngle.Series[1].Values[4] = RightSum + LeftSum;
                        ChartModelAngle.Series[0].Values[4] = LeftSum;
                        ChartModelAngle.Series[1].Values[4] = RightSum;

                    }
                    if (Angle.Equals("120度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[5] = RightSum - LeftSum;
                        //ChartModelAngle.Series[0].Values[5] = RightSum - LeftSum;
                        //ChartModelAngle.Series[1].Values[5] = RightSum + LeftSum;
                        ChartModelAngle.Series[0].Values[5] = LeftSum;
                        ChartModelAngle.Series[1].Values[5] = RightSum;

                    }
                    if (!IsPlayBack)
                    {
                        //"部位,角度,力差,合力,外力,内力,抓取时间";
                        csvValue = "左膝," + Angle + "," + (RightSum - LeftSum).ToString() + "," + (RightSum + LeftSum).ToString() + "," + LeftSum + "," + RightSum + "," + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss fff") + "\r\n";
                        writerTwo.WriteLine(csvValue);
                        IsCatchData = false;
                    }
                }

            }
            if (!leftOrRight.Equals(string.Empty) && leftOrRight.Equals("Left"))
            {
                //lblPressureOne.Text = RightSum.ToString();
                //lblPressureTwo.Text = LeftSum.ToString();
                lblPressureOne.Text = LeftSum.ToString();
                lblPressureTwo.Text = RightSum.ToString();
                lblPressureDiff.Text = (LeftSum - RightSum).ToString();
                lblPressureSum.Text = (LeftSum + RightSum).ToString();
                lblDirectionOne.Text = "外";
                lblDirectionTwo.Text = "内";
                ChartDataBuff[0] = LeftSum - RightSum;
                ChartDataBuff[1] = LeftSum + RightSum;
                ChartDataBuff[2] = RightSum;
                ChartDataBuff[3] = LeftSum;

                if (IsCatchData)
                {
                    if (Angle.Equals("0度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[0] = LeftSum - RightSum;
                        //ChartModelAngle.Series[0].Values[0] = LeftSum - RightSum;
                        //ChartModelAngle.Series[1].Values[0] = LeftSum + RightSum;
                        ChartModelAngle.Series[0].Values[0] = RightSum;
                        ChartModelAngle.Series[1].Values[0] = LeftSum;

                    }
                    if (Angle.Equals("30度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[1] = LeftSum - RightSum;
                        //ChartModelAngle.Series[0].Values[1] = LeftSum - RightSum;
                        //ChartModelAngle.Series[1].Values[1] = LeftSum + RightSum;
                        ChartModelAngle.Series[0].Values[1] = RightSum;
                        ChartModelAngle.Series[1].Values[1] = LeftSum;

                    }
                    if (Angle.Equals("45度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[2] = LeftSum - RightSum;
                        //ChartModelAngle.Series[0].Values[2] = LeftSum - RightSum;
                        //ChartModelAngle.Series[1].Values[2] = LeftSum + RightSum;
                        ChartModelAngle.Series[0].Values[2] = RightSum;
                        ChartModelAngle.Series[1].Values[2] = LeftSum;

                    }
                    if (Angle.Equals("60度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[3] = LeftSum - RightSum;
                        //ChartModelAngle.Series[0].Values[3] = LeftSum - RightSum;
                        //ChartModelAngle.Series[1].Values[3] = LeftSum + RightSum;
                        ChartModelAngle.Series[0].Values[3] = RightSum;
                        ChartModelAngle.Series[1].Values[3] = LeftSum;

                    }
                    if (Angle.Equals("90度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[4] = LeftSum - RightSum;
                        //ChartModelAngle.Series[0].Values[4] = LeftSum - RightSum;
                        //ChartModelAngle.Series[1].Values[4] = LeftSum + RightSum;
                        ChartModelAngle.Series[0].Values[4] = RightSum;
                        ChartModelAngle.Series[1].Values[4] = LeftSum;

                    }
                    if (Angle.Equals("120度"))
                    {
                        ChartModelDiff.DiffSeries[0].Values[5] = LeftSum - RightSum;
                        //ChartModelAngle.Series[0].Values[5] = LeftSum - RightSum;
                        //ChartModelAngle.Series[1].Values[5] = LeftSum + RightSum;
                        ChartModelAngle.Series[0].Values[5] = RightSum;
                        ChartModelAngle.Series[1].Values[5] = LeftSum;

                    }
                    if (!IsPlayBack)
                    {
                        //"部位,角度,力差,合力,外力,内力,抓取时间";
                        csvValue = "右膝," + Angle + "," + (LeftSum - RightSum).ToString() + "," + (LeftSum + RightSum).ToString() + "," + RightSum + "," + LeftSum + "," + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss fff") + "\r\n";
                        writerTwo.WriteLine(csvValue);
                        IsCatchData = false;
                    }
                }
            }

        }

        private void DrawOne()
        {


            //Model3D.Head.Read(System.Windows.Forms.Application.StartupPath + @"Profile\Coodinate.txt");
            Model3D.Head.Read(System.Windows.Forms.Application.StartupPath + @"Profile\knee_mesh.txt");
            draw3dShowOne.IndexDrawFunction = Model3D.DrawTools;
            Model3D.InitialSet();
            while (!IsComplete)
            {
                try
                {
                    DateTime beforeDT = System.DateTime.Now;
                    Model3D.Pressure.ReadFromBuffer(-1);
                    this.Invoke(new MethodInvoker(() => SetChartIndex(Model3D.Pressure.PressureV2)));
                    CalculateParameter(Model3D.Pressure.PressureV2, Model3D.Head.Data3D);
                    Model3D.Draw3D(max_value_row, max_value_col, min_value_row, min_value_col, centerPoint);
                    draw3dShowOne.Invoke(new MethodInvoker(() => draw3dShowOne.RefreshImage()));
                    DrawPressure(Model3D.Pressure.PressureMax, draw2dShowOne);
                    DateTime afterDT = System.DateTime.Now;
                    TimeSpan ts = afterDT.Subtract(beforeDT);

                }
                catch (Exception ex) { }
            }
        }





        //重置压力云图的控件的函数
        public void InitialData()
        {

            draw3dShowOne.IndexDrawFunction = Model3D.DrawTools;

            //Model3D.Pressure.SetSize(Model3D.Head.RowCount, Model3D.Head.ColCount);
            if (Model3D.Pressure.Pressure == null) Model3D.Pressure.Readdb1616();
            Model3D.InitialSet();
        }

        private void CalculateParameter(float[] values, PointF3D[] data3D)
        {
            DrawFunction3D.PointF3D maxPointTemp = new DrawFunction3D.PointF3D();
            DrawFunction3D.PointF3D minPointTemp = new DrawFunction3D.PointF3D();
            DrawFunction3D.PointF3D centerPointTemp = new DrawFunction3D.PointF3D();
            float avg_value_temp = 0,
                //max_value_temp = -9.9e30f,
                //min_value_temp = 9.9e30f,
                max_value_temp = 999f,
                min_value_temp = 0f,
                sum_F_temp = 0,
                sum_x_F_temp = 0,
                sum_y_F_temp = 0,
                sum_z_F_temp = 0;
            float sum_x = 0, sum_y = 0, sum_z = 0;
            num_value = 0; max_value_row = 0; max_value_col = 0; min_value_row = 0; min_value_col = 0;
            for (int i = 0; i < values.Length; i++)
            {

                sum_F_temp += values[i];
                sum_x_F_temp += values[i] * data3D[i].X;
                sum_y_F_temp += values[i] * data3D[i].Y;
                sum_z_F_temp += values[i] * data3D[i].Z;
                avg_value_temp += values[i];
                if (max_value_temp < values[i])
                {
                    max_value_temp = values[i];
                    maxPointTemp = data3D[i];
                    max_value_row = i;
                }
                if (min_value_temp > values[i])
                {
                    if (values[i] > 0)
                    {
                        min_value_temp = values[i];
                        minPointTemp = data3D[i];
                    }
                }
                num_value++;
            }

            avg_value = avg_value_temp / 12; max_value = max_value_temp; min_value = min_value_temp;
            sum_F = sum_F_temp; sum_x_F = sum_x_F_temp; sum_y_F = sum_y_F_temp; sum_z_F = sum_z_F_temp;

            centerPointTemp = avg_value_temp > 0.001 ?
                new DrawFunction3D.PointF3D(sum_x_F_temp / avg_value_temp, sum_y_F_temp / avg_value_temp, sum_z_F_temp / avg_value_temp) : Model3D.Head.xiedianCenter;

            maxPoint = maxPointTemp;
            minPoint = minPointTemp;
            centerPoint = centerPointTemp;

        }




        private void DrawPressure(float p, DrawFunctionLib.DrawFunction2DShow d2d)
        {
            if (d2d.IndexDrawFunction == null)
            {
                d2d.IndexDrawFunction = new DrawFunctionLib.DrawFunction2D(300, 600);
                d2d.IndexDrawFunction.DrawRangeX.SetRange(0, 1);
                d2d.IndexDrawFunction.DrawRangeY.SetRange(0, DrawModel3D.PressureMax * unit_ratio);
                //d2d.IndexDrawFunction.DrawRangeY.SetRange(0, DrawModel3D.PressureMax);
                d2d.IndexDrawFunction.DrawEdgePercent = 0;
                d2d.IndexDrawFunction.DrawCoordinateSettings.CoordinateNameX = "";
                d2d.IndexDrawFunction.DrawCoordinateSettings.CoordinateNameY = "P.";
                d2d.IndexDrawFunction.DrawCoordinateSettings.CoordinateNumberX = 0;
                d2d.IndexDrawFunction.DrawCoordinateSettings.CoordinateNumberY = 10;
                d2d.IndexDrawFunction.DrawFormat = "0";
                d2d.IndexDrawFunction.DrawFontColor = Color.Gray;
                d2d.IndexDrawFunction.DrawFont = new Font("微软雅黑", 18.5F, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
                d2d.IndexDrawFunction.DrawCoordinateSettings.EnableDrawCoordinateValue = true;
                d2d.IndexDrawFunction.DrawCoordinateSettings.EnableDrawSubCoordinate = false;
                d2d.IndexDrawFunction.DrawCoordinateSettings.EnableDrawTopCoordinate = false;
                d2d.IndexDrawFunction.DrawCoordinateSettings.PenCoordinate =
                d2d.IndexDrawFunction.DrawCoordinateSettings.PenSubCoordinate;

                //this.uDrawPenCoordinate = new Pen(Color.Gray, 4f);  
                //this.uDrawPenSubCoordinate = new Pen(Color.Black, 1f);
            }

            d2d.IndexDrawFunction.DrawRangeY.SetRange(0, DrawModel3D.PressureMax * unit_ratio);
            Graphics g = d2d.IndexDrawFunction.ClearFunction();
            g.FillRectangle(new SolidBrush(Model3D.GetColor(p, DrawModel3D.PressureMin, DrawModel3D.PressureMax)),
                    d2d.IndexDrawFunction.PositionValueToDrawX((float)d2d.IndexDrawFunction.DrawRangeX.Min + 0.2F),
                    d2d.IndexDrawFunction.PositionValueToDrawY(p * unit_ratio),
                    d2d.IndexDrawFunction.LengthValueToDrawX((float)d2d.IndexDrawFunction.DrawRangeX.Length - 0.4F),
                    d2d.IndexDrawFunction.LengthValueToDrawY(p * unit_ratio));


            g.Dispose();
            g = null;

            d2d.IndexDrawFunction.DrawCoordinate(false);
            d2d.Invoke(new MethodInvoker(() => d2d.RefreshImage()));
        }

        #endregion

        private void BtnCloudEnd_Click(object sender, EventArgs e)
        {
            IsComplete = true;//设置完成
            pictureBoxOne.Visible = true;
            if (testRecord != null) //如果是测试保存数据
            {
                testRecord.EndTime = DateTime.Now;
                testRecord.HardwareNumber = HardwareNumber;
                testRecord.Left = leftOrRight.Equals("Left");
                testRecord.Right = leftOrRight.Equals("Right");
                testRecord.DoctorID = GlobalVariable.doctor.ID;
                testRecord.Doctor = GlobalVariable.doctor.Name;
                testRecord.OperationPart = leftOrRight.Equals("Left") ? "左膝" : "右膝";
                testRecord.TwoPath = testRecord.Name + "-" + testRecord.BegainTime.ToString("yyyy-MM-dd-HH-mm-ss") + "-Angle..csv";
                testRecordLogic ??= new TestRecordLogic();
                testRecordLogic.InsertTestRecord(testRecord);
                if (serialPortOne != null && serialPortOne.IsOpen)
                {
                    while (isReceiving)
                    {
                        Application.DoEvents();
                    }
                    serialPortOne.Close();
                    serialPortOne.Dispose();
                }

                if (serialPortTwo != null && serialPortTwo.IsOpen)
                {
                    while (isReceivingTwo)
                    {
                        Application.DoEvents();
                    }
                    serialPortTwo.Close();
                    serialPortTwo.Dispose();
                }
                CloseWriterAndReader();//关闭写
                SetControlEnabled(btnCloudStartTest, true);//启用开始按钮
                timerRealTime.Enabled = false;
                btnCloudStartTest.ForeColor = Color.White;
               
                ClearButton("Angle");
                ClearButton("RealTime");
            }
            else
            {
                //FormMainMenu.testRecord = null;
                CloseWriterAndReader();//回放则关闭文件读写
            }
            SetingPlaybackInfo(false);
            selectPatient = null;
            ChartModelRealTime.ClearRealTimeData();//清除实时数据
            lblPressureOne.Text = "0.00";
            lblPressureTwo.Text = "0.00";
            lblPressureDiff.Text = "0.00";
            lblPressureSum.Text = "0.00";
            ChartModelAngle.ClearAngleData();//清除角度数据
            ChartModelDiff.ClearDiffData();//清除差值数据
            ClearText();

        }
        private void ClearText()
        {
            txtCloudAge.Text = "";
            txtCloudHeight.Text = "";
            txtCloudName.Text = "";
            txtCloudWeight.Text = "";
            txtNum.Text = "";
            txtSex.Text = "";
            //txtEnter.Text = "";
            //txtOperation.Text = "";
        }

        private void CloseWriterAndReader()
        {
            readerOne?.Close();
            readerOne?.Dispose();
            readerTwo?.Close();
            readerTwo?.Dispose();
            writerOne?.Flush();
            writerOne?.Close();
            writerOne?.Dispose();
            writerTwo?.Flush();
            writerTwo?.Close();
            writerTwo?.Dispose();
        }

        private void FormCloud_Load(object sender, EventArgs e)
        {

            SetingPlaybackInfo(false);
            pictureBoxOne.Visible = true;
            pictureBoxOne.Image = DrawFunctionLib.Properties.Resources.Joint;

            
            //角度图表
            ChartModelAngle ??= new();
            cartesianChartAngle.Series = ChartModelAngle.Series;
            cartesianChartAngle.AxisY = ChartModelAngle.YAxis;
            cartesianChartAngle.AxisY[0].Separator.Step = 1;
            DefaultLegend customLegendAngle = new()
            {
                Foreground = System.Windows.Media.Brushes.Black
            };
            cartesianChartAngle.DefaultLegend = customLegendAngle;
            cartesianChartAngle.LegendLocation = LegendLocation.Right;
            cartesianChartAngle.AxisX = ChartModelAngle.XAxis;
            //cartesianChartOne.AxisX[0].Separator.Step = 10000;
            var tooltip = new DefaultTooltip { SelectionMode = TooltipSelectionMode.SharedYValues };
            cartesianChartAngle.DataTooltip = tooltip;

            //力差图表
            ChartModelDiff ??= new();
            cartesianChartDiff.Series = ChartModelDiff.DiffSeries;
            cartesianChartDiff.AxisY = ChartModelDiff.YAxis;
            cartesianChartDiff.AxisY[0].Separator.Step = 1;
            DefaultLegend customLegendDiff = new()
            {
                Foreground = System.Windows.Media.Brushes.Black
            };
            cartesianChartDiff.DefaultLegend = customLegendDiff;
            cartesianChartDiff.LegendLocation = LegendLocation.Right;
            cartesianChartDiff.AxisX = ChartModelDiff.XAxis;
            //cartesianChartDiff.DataTooltip = tooltip;

            //实时图表
            ChartModelRealTime ??= new(true);
            cartesianChartRealTime.Series = ChartModelRealTime.RealTimeSeries;
            ChartModelRealTime.ClearRealTimeData();//清除实时数据
            DefaultLegend customLegendRealTime = new()
            {
                Foreground = System.Windows.Media.Brushes.Black
            };
            cartesianChartRealTime.DefaultLegend = customLegendRealTime;
            cartesianChartRealTime.LegendLocation = LegendLocation.Right;
            cartesianChartRealTime.AxisX = ChartModelRealTime.XAxis;
        }

        private void SetingPlaybackInfo(bool enable)
        {
            if (GlobalVariable.testRecord != null)
            {
                txtCloudName.Text = GlobalVariable.testRecord.Name;
                txtCloudWeight.Text = GlobalVariable.testRecord.Weight.ToString();
                txtCloudHeight.Text = GlobalVariable.testRecord.Height.ToString();
                txtCloudAge.Text = GlobalVariable.testRecord.Age.ToString();
                txtNum.Text = GlobalVariable.testRecord.MedicalRecordNum;
                txtSex.Text = GlobalVariable.testRecord.Sex;
                //txtEnter.Text = GlobalVariable.testRecord.EnterTime.ToString("D");
                //txtOperation.Text = GlobalVariable.testRecord.OperationDate.ToString("D");
                btnCloudStartTest.Text = "   回放开始";
                btnCloudStartTest.Tag = "Playback";
                btnCloudEnd.Text = "   回放结束";
                btnCloudEnd.Tag = "Playback";
                btnCloudLeft.Tag = "Playback";
                btnRegister.Visible = true;
            }
            //SetControlEnabled(this.btnCloudLeft, enable);
            //this.btnCloudLeft.ForeColor = enable ? Color.White : Color.Gainsboro;

            SetControlEnabled(this.btnCloudEnd, enable);
            this.btnCloudEnd.ForeColor = enable ? Color.White : Color.Gainsboro;

        }

        private void BtnCloudExit_Click(object sender, EventArgs e)
        {

            //CloseWriterAndReader();
            this.Close();
        }

        private void SetDirectionInfo()
        {
            if (!leftOrRight.Equals(string.Empty) && leftOrRight.Equals("Left"))
            {
                btnCloudLeft.BackColor = Color.FromArgb(171, 155, 254);// Color.FromArgb(71, 156, 210);//.DodgerBlue;
                btnCloudLeft.ForeColor = Color.White;
                btnCloudRight.BackColor = Color.FromArgb(116, 89, 255);//.WhiteSmoke;
                btnCloudRight.ForeColor = Color.White;
                lblDirectionOne.Text = "外";
                lblDirectionTwo.Text = "内";
            }
            if (!leftOrRight.Equals(string.Empty) && leftOrRight.Equals("Right"))
            {
                btnCloudRight.BackColor = Color.FromArgb(171, 155, 254); //Color.FromArgb(71, 156, 210);//.DodgerBlue;
                btnCloudLeft.ForeColor = Color.White;
                btnCloudLeft.BackColor = Color.FromArgb(116, 89, 255);//.WhiteSmoke;;
                btnCloudLeft.ForeColor = Color.White;

                lblDirectionOne.Text = "内";
                lblDirectionTwo.Text = "外";
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            GlobalVariable.testRecord = null;
            GlobalVariable.CloudPlaybackOrReportView = "Test";
            //btnRegister.Visible = false;
            btnCloudStartTest.Text = "    开始测试";
            btnCloudEnd.Text = "    结束测试";
            //ClearText();
            SetControlEnabled(this.btnCloudStartTest, true);
            this.btnCloudStartTest.ForeColor = Color.White;

            FormRegisterInstrument frm = new();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //SetCorrectionFactor(CorrectionFactorA, CorrectionFactorB);//设置校正系数
                HardwareNumber = frm.HardwareNumber;
                leftOrRight = frm.leftOrRight;
                mainMenu.lblCurrentStatus.Text = "已连接";//设置主界面链接状态
                mainMenu.SetBatteryLevel(frm.BatteryLevel);
                SetDirectionInfo();

            }
        }

        private void SetCorrectionFactor(float[] A, float[] B)
        {
            A.CopyTo(CorrectionFactorA, 0);
            B.CopyTo(CorrectionFactorB, 0);
        }

        //选择患者
        private void BtnSelectPatient_Click(object sender, EventArgs e)
        {
            selectPatient ??= new();
            FormPatient formPatient = new(selectPatient);
            if (formPatient.ShowDialog() == DialogResult.OK)
            {
                txtCloudName.Text = selectPatient?.Name;
                txtNum.Text = selectPatient?.MedicalRecordNum;
                txtCloudHeight.Text = selectPatient?.Height.ToString();
                txtCloudWeight.Text = selectPatient?.Weight.ToString();
                txtCloudAge.Text = selectPatient?.Age.ToString();
                txtSex.Text = selectPatient?.Sex.ToString();
                //txtEnter.Text = selectPatient?.EnterTime.ToString("D");
                //txtOperation.Text = DateTime.Now.ToString("D");
            }
        }

        private void ClearButton(string type)
        {
            if (type.Equals("Angle"))
            {
                btn0.BackColor = Color.FromArgb(213, 231, 243);
                btn0.ForeColor = Color.FromArgb(101, 143, 185);

                btn30.BackColor = Color.FromArgb(213, 231, 243);
                btn30.ForeColor = Color.FromArgb(101, 143, 185);

                btn45.BackColor = Color.FromArgb(213, 231, 243);
                btn45.ForeColor = Color.FromArgb(101, 143, 185);

                btn60.BackColor = Color.FromArgb(213, 231, 243);
                btn60.ForeColor = Color.FromArgb(101, 143, 185);

                btn90.BackColor = Color.FromArgb(213, 231, 243);
                btn90.ForeColor = Color.FromArgb(101, 143, 185);

                btn120.BackColor = Color.FromArgb(213, 231, 243);
                btn120.ForeColor = Color.FromArgb(101, 143, 185);
            }
            if (type.Equals("RealTime"))
            {
                btnShwoDiff.BackColor = Color.FromArgb(66, 148, 204);
                btnShwoDiff.ForeColor = Color.White;
                btnShowSum.BackColor = Color.FromArgb(66, 148, 204);
                btnShowSum.ForeColor = Color.White;
                btnShowInside.BackColor = Color.FromArgb(66, 148, 204);
                btnShowInside.ForeColor = Color.White;
                btnShowOutside.BackColor = Color.FromArgb(66, 148, 204);
                btnShowOutside.ForeColor = Color.White;
            }
        }
        private void Angle_Click(object sender, EventArgs e)
        {

            IconButton? current = sender as IconButton;

            ClearButton("Angle");

            current.BackColor = Color.FromArgb(66, 148, 204);
            current.ForeColor = Color.White;
            Angle = current.Text;
        }


        private void BtnChartSwitchRealTim_Click(object sender, EventArgs e)
        {
            panelRealTime.Visible = true;
            panelAngle.Visible = false;

        }

        private void BtnChartSwitchAngle_Click(object sender, EventArgs e)
        {
            panelRealTime.Visible = false;
            panelAngle.Visible = true;
        }

        private void BtnCatch_Click(object sender, EventArgs e)
        {
            if (Angle.Equals(string.Empty))
            {
                MessageBox.Show("请先选择抓取角度！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            IsCatchData = true;
        }

        private void BtnShwoDiff_Click(object sender, EventArgs e)
        {
            IconButton? current = sender as IconButton;
            if (current.Tag.Equals("show"))
            {
                current.BackColor = Color.FromArgb(213, 231, 243);
                current.ForeColor = Color.FromArgb(101, 143, 185);
                current.Tag = "hide";
                ChartModelRealTime.DiffPressure.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                current.BackColor = Color.FromArgb(66, 148, 204);
                current.ForeColor = Color.White;
                current.Tag = "show";
                ChartModelRealTime.DiffPressure.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void BtnShowSum_Click(object sender, EventArgs e)
        {
            IconButton? current = sender as IconButton;
            if (current.Tag.Equals("show"))
            {
                current.BackColor = Color.FromArgb(213, 231, 243);
                current.ForeColor = Color.FromArgb(101, 143, 185);
                current.Tag = "hide";
                ChartModelRealTime.SumPressure.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                current.BackColor = Color.FromArgb(66, 148, 204);
                current.ForeColor = Color.White;
                current.Tag = "show";
                ChartModelRealTime.SumPressure.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void BtnShowInside_Click(object sender, EventArgs e)
        {
            IconButton? current = sender as IconButton;
            if (current.Tag.Equals("show"))
            {
                current.BackColor = Color.FromArgb(213, 231, 243);
                current.ForeColor = Color.FromArgb(101, 143, 185);
                current.Tag = "hide";
                ChartModelRealTime.InsidePressure.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                current.BackColor = Color.FromArgb(66, 148, 204);
                current.ForeColor = Color.White;
                current.Tag = "show";
                ChartModelRealTime.InsidePressure.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void BtnShowOutside_Click(object sender, EventArgs e)
        {
            IconButton? current = sender as IconButton;
            if (current.Tag.Equals("show"))
            {
                current.BackColor = Color.FromArgb(213, 231, 243);
                current.ForeColor = Color.FromArgb(101, 143, 185);
                current.Tag = "hide";
                ChartModelRealTime.OutsidePressure.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                current.BackColor = Color.FromArgb(66, 148, 204);
                current.ForeColor = Color.White;
                current.Tag = "show";
                ChartModelRealTime.OutsidePressure.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void TimerRealTime_Tick(object sender, EventArgs e)
        {
            if (!IsComplete)
            {
                ChartModelRealTime.DiffPressure.Values.Add(new ObservableValue(ChartDataBuff[0]));
                ChartModelRealTime.SumPressure.Values.Add(new ObservableValue(ChartDataBuff[1]));
                ChartModelRealTime.InsidePressure.Values.Add(new ObservableValue(ChartDataBuff[2]));
                ChartModelRealTime.OutsidePressure.Values.Add(new ObservableValue(ChartDataBuff[3]));

                if (ChartModelRealTime.DiffPressure.Values.Count > 6)
                {
                    ChartModelRealTime.DiffPressure.Values.RemoveAt(0);
                    ChartModelRealTime.SumPressure.Values.RemoveAt(0);
                    ChartModelRealTime.InsidePressure.Values.RemoveAt(0);
                    ChartModelRealTime.OutsidePressure.Values.RemoveAt(0);
                }
            }
        }


    }



}
