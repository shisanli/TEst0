
using DrawFunctionLib;
using Microsoft.Office.Interop.Word;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Reflection;
using static DrawFunctionLib.DrawFunction3D;

namespace PressureUpper
{
    public partial class MainForm : Form
    {
        #region 初始变量
        private string filePath;//文件路径
        private string s1, s2, s3, s4, s5, s6, s7, s8;//校准系数
        string sleft1, sleft2, sleft3, sleft4, sleft5, sleft6, sleft7, sleft8;//同上 校准系数 左侧
        private ToolStripMenuItem SelectItem;
        private readonly System.Action DisplayAction;
        private readonly System.Action ComAction;
        private SettingDataRecord dataRecord;
        int ting = 0; //是否停止
        int ifsend = 0;//是否发送
        int countReceive = 1;//接收总次数
        int countReceiveLeft = 1;//左侧接收总次数
        int sendCount = 1;//发送总次数
        int phase, phaseLeft;//压力
        public DrawModel3D Model3D = new DrawModel3D();
        public DrawModel3D Model3DLeft = new DrawModel3D();
        private delegate void buttonCallBackZero();
        private buttonCallBackZero btnCallBackZero;
        private delegate void buttonCallBackOne();
        private buttonCallBackOne btnCallBackOne;
        private delegate void buttonCallBackTwo();
        private buttonCallBackTwo btnCallBackTwo;

        DrawFunction3D.PointF3D maxPoint, minPoint, centerPoint;
        DrawFunction3D.PointF3D maxPointleft, minPointleft, centerPointleft;

        SerialPort serialPortOne;      //串口
        int csvDisplaying = 0; int csvIndex = 0;

        private Thread threadSend;//数据发送线程
        private Thread threadReceive;//数据接收线程

        private string leftCode; //左侧代码
        private string rightCode;//右侧代码
        private bool isReceiving = false;//是否接收中
        int caiYangPinLv = 50; //采样频率
        private float PhaseRecWeight1, PhaseRecWeight2;
        double[] F = new double[8];
        double[] Fleft = new double[8];
        List<double> Farray = new List<double>();       //记录一个传感器压力和
        List<double> FleftArray = new List<double>();
        double SF = 95;//步频
        private double leftSum;//左侧总数
        private double rightSum;//右侧总数
        private string[,] dataReceived = new string[14, 14];//到达数据
        private string[,] dataReceivedLeft = new string[1, 9];//左侧到达数据

        List<List<double>> FListLeft = new List<List<double>>();
        List<List<double>> FListRight = new List<List<double>>();

        System.Data.DataTable dataImport = new System.Data.DataTable();
        System.Data.DataTable dataExport = new System.Data.DataTable();
        int daimn, daexn = 0;
        Boolean boolscore = false;
        int num_value = 0, max_value_row = 0, max_value_col = 0, min_value_row = 0, min_value_col = 0;
        int num_valueleft = 0, max_value_rowleft = 0, max_value_colleft = 0, min_value_rowleft = 0, min_value_colleft = 0;
        float avg_value = 0, max_value = -9.9e30f, min_value = 9.9e30f, sum_F = 0, sum_x_F = 0, sum_y_F = 0, sum_z_F = 0;

        /// 画折线图的参数
        private Queue<double> dataQueue = new Queue<double>(55);
        private Queue<double> dataQueueLeft = new Queue<double>(55);
        private int num = 5;//每次删除增加几个点

        #endregion

        public MainForm()
        {
            InitializeComponent();
            string[] PortNames = SerialPort.GetPortNames(); //获取本机串口名称，存入PortNames数组中
            for (int i = 0; i < PortNames.Count(); i++)
            {
                comboCom.Items.Add(PortNames[i]);   //将数组内容加载到comboBox控件中

            }
            btnCallBackZero = new buttonCallBackZero(lianxu);
            btnCallBackOne = new buttonCallBackOne(lianxu1);
            btnCallBackTwo = new buttonCallBackTwo(lianxu2);

            DisplayAction = new System.Action(DatabaseDisplayControl);//画图的线程
            ComAction = new System.Action(ComConnectionControl);//发送与接收的线程
        }

        //自定义系统按钮被点击时触发的事件
        private void FrmMain_SysBottomClick(object sender, EventArgs e)
        {
            //如果点击的是工具菜单按钮
            //if (e.SysButton.Name == "SysTool")
           // {
                //System.Drawing.Point l = PointToScreen(e.SysButton.Location);
                //l.Y += e.SysButton.Size.Height + 1;
                ToolMenu.Show();

            //}
        }

        //选项卡选中今日热点时触发
        private void tabShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabShow.SelectedIndex == 7)
            {
                webNew.ScriptErrorsSuppressed = true; //禁用错误脚本提示  
                webNew.IsWebBrowserContextMenuEnabled = false; // 禁用右键菜单  
                webNew.WebBrowserShortcutsEnabled = false; //禁用快捷键  
                webNew.AllowWebBrowserDrop = false; // 禁止文件拖动  

                webNew.Navigate(System.Windows.Forms.Application.StartupPath + @"Content\Home.html");
                webNew.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
                webNew.NewWindow += CancelEventHandler;
                //将焦点给web浏览器控件
                webNew.Focus();
            }
            if (tabShow.SelectedIndex == 8)
            {
                webHelp.ScriptErrorsSuppressed = true; //禁用错误脚本提示  
                webHelp.IsWebBrowserContextMenuEnabled = false; // 禁用右键菜单  
                webHelp.WebBrowserShortcutsEnabled = false; //禁用快捷键  
                webHelp.AllowWebBrowserDrop = false; // 禁止文件拖动  

                webHelp.Navigate(System.Windows.Forms.Application.StartupPath + @"Content\Help.html");
                webHelp.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
                webHelp.NewWindow += CancelEventHandler;
                //将焦点给web浏览器控件
                webHelp.Focus();
            }

            if (tabShow.SelectedIndex == 4)
            {
                lodding.Show();
                _Application wordApp;
                _Document wordDoc;
                Object Nothing = Missing.Value;
                Object path = System.Windows.Forms.Application.StartupPath + @"Reports\Report20201212211818汪晨星静31.doc";
                wordApp = new ApplicationClass();
                wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                wordApp.Visible = false;
                //wordDoc = wordApp.Documents.Open(ref path, ref Nothing, ref Nothing, ref Nothing);
                wordDoc = wordApp.Documents.Open(ref path, ref Nothing,
                        ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                        ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                object format = WdSaveFormat.wdFormatFilteredHTML;
                Object newPath = System.Windows.Forms.Application.StartupPath + @"Reports\Report20201212211818汪晨星静31.html";
                wordDoc.SaveAs(ref newPath, ref format, ref Nothing, ref Nothing, ref Nothing,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                wordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                Console.WriteLine("Created!");

                webReport.ScriptErrorsSuppressed = true; //禁用错误脚本提示  
                webReport.IsWebBrowserContextMenuEnabled = false; // 禁用右键菜单  
                webReport.WebBrowserShortcutsEnabled = false; //禁用快捷键  
                webReport.AllowWebBrowserDrop = false; // 禁止文件拖动  

                webReport.Navigate(System.Windows.Forms.Application.StartupPath + @"Reports\Report20201212211818汪晨星静31.html");
                webReport.NewWindow += CancelEventHandler;
                //将焦点给web浏览器控件
                webReport.Focus();
                lodding.Hide();
            }
        }
        //禁用新窗口打开  
        public void CancelEventHandler(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            e.Handled = true;
        }

        #region 换肤菜单
        /// <summary>
        /// 选中的MenuItem
        /// </summary>

        private void SkinTool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //选中当前Item
            item.Checked = true;
            //取消选中上一个Item，并存储当前Item
            SelectItem.Checked = false;
            SelectItem = item;
            //如果是0，则是默认皮肤
            if (item.Tag.ToString().Equals("0"))
            {
                //this.Back = ImageObject.GetResBitmap("PressureUpper.Skin.Back.jpg");
                //this.Opacity = this.SkinOpacity = 0.99;
            }
            else
            {
                //其他皮肤，从程序集资源中提取，并且设置透明度为不透明
                //this.Opacity = this.SkinOpacity = 0.99;
                //this.Back = ImageObject.GetResBitmap(string.Format("PressureUpper.Skin.{0}.jpg", item.Tag));
            }
        }
        #endregion

        private void MenuItem_Quit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SelectItem = MenuItem_DefaultSkin;
            this.currentTimer.Start();
        }

        private void currentTimer_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = "当前时间：" + DateTime.Now.ToString("F");
        }

        private void btnCloudStartTest_Click(object sender, EventArgs e)
        {
            double a = 0.00;
            if (txtCloudName.Text.Trim() == String.Empty)
            {

                MessageBox.Show("请整填写被试姓名！");
                txtCloudName.Focus();
                return;
            }
            if (txtCloudHeight.Text.Trim() == String.Empty)
            {
                MessageBox.Show("请完整填写被试身高！");
                txtCloudHeight.Focus();
                return;
            }
            if (txtCloudWeight.Text.Trim() == String.Empty)
            {
                MessageBox.Show("请完整填写被试体重！");
                txtCloudWeight.Focus();
                return;
            }
            if (txtCloudAge.Text.Trim() == String.Empty)
            {
                MessageBox.Show("请完整填写被试年龄！");
                txtCloudAge.Focus();
                return;
            }

            //InitChart();

            //连接串口
            ComAction.Invoke();

            //画图
            DisplayAction.Invoke();

            //关闭功能，防止误操作
            btnCloudStartTest.Enabled = false;

            //timer1.Enabled = true;
        }

        #region 串口相关
        private void ComConnectionControl()//控制发送和接收两个线程的启动
        {
            if (dataRecord != null)
            {
                PhaseRecWeight1 = dataRecord.regWeight1;
                PhaseRecWeight2 = dataRecord.regWeight2;
                leftCode = dataRecord.leftCode;
                rightCode = dataRecord.rightCode;
                caiYangPinLv = dataRecord.MessageCaiyangpinlv;
                serialPortOne = new SerialPort(dataRecord.MessagePortName, Convert.ToInt32(dataRecord.MessageBaudRate), Parity.None, 8, StopBits.One);
                //serialPortOne.DtrEnable = true;
                //serialPortOne.RtsEnable = true;
                serialPortOne.DtrEnable = false;
                //如果为 true，则启用数据终端就绪 (DTR)；否则为 false。 默认为 false。
                serialPortOne.RtsEnable = false;
                //如果为 true，则启用请求发送 (RTS)；否则为 false。 默认为 false。
                //try
                //{
                this.serialPortOne.Open();
                //}catch(Exception e)
                //{
                //    string msg = e.Message;
                //}
                serialPortOne.ReadTimeout = 1000;
                serialPortOne.WriteTimeout = 1000;
            }
            else
            {
                MessageBox.Show("请先完成端口设置！");
                tabShow.SelectedIndex = 6;
                return;
            }
            ThreadStart threadStart = new(SendToCom);//通过ThreadStart委托告诉子线程执行什么方法　　
            threadSend = new Thread(threadStart);
            threadSend.Start();
            ifsend = 1;
            ThreadStart threadStart1 = new(ReceiveFromCom);
            threadReceive = new Thread(threadStart1);
            threadReceive.Start();
            countReceive = 1;
            countReceiveLeft = 1;
            sendCount = 1;
        }

        private void SendToCom()//向端口发送指令
        {
            string leftCode = "0x02";
            while (ifsend == 1)
            {

                int leftint = Convert.ToInt32(leftCode.Substring(leftCode.Length - 1, 1), 16);
                string s1 = string.Empty;
                s1 += (char)leftint;
                this.serialPortOne.Write(s1);
                Thread.Sleep(1000);
            }

            //while (ifsend == 1)
            //{
            //    int leftint = Convert.ToInt32(leftCode.Substring(leftCode.Length - 1, 1), 16);
            //    int rightint = Convert.ToInt32(rightCode.Substring(rightCode.Length - 1, 1), 16);
            //    string s1 = string.Empty;
            //    s1 += (char)leftint;
            //    string s2 = string.Empty;
            //    s2 += (char)rightint;
            //    this.serialPortOne.Write(s1);
            //    Thread.Sleep(1000 / caiYangPinLv);
            //    this.serialPortOne.Write(s2);
            //    Thread.Sleep(1000 / caiYangPinLv);
            //    sendCount += 1;
            //}
        }

        private void ReceiveFromCom()
        {
            try
            {
                serialPortOne.DataReceived += new SerialDataReceivedEventHandler(s1DataReceived);
                serialPortOne.ReceivedBytesThreshold = 20;
            }
            catch (Exception ereceive)
            {
                Console.WriteLine(ereceive);
            }
        }

        private int k = 0;
        private int[,] pres = new int[14, 14];
        private void s1DataReceived(object sendr, SerialDataReceivedEventArgs e)//接收数据
        {
            Console.WriteLine("接受测试");
            string receiveData;
            string[] data_receive;
            int tempLength;
            string strNum = string.Empty;
            receiveData = serialPortOne.ReadLine();

            //try
            //{
            isReceiving = true;
            if (receiveData != null)
            {

                if (receiveData != "" && !receiveData.StartsWith("?") && !receiveData.StartsWith("image"))
                {
                    rightSum = 0;
                    Debug.WriteLine("接收到第" + countReceive.ToString() + "帧数据");
                    Debug.WriteLine(receiveData);
                    data_receive = receiveData.TrimEnd(',').Split(',');
                    if (data_receive.Length == 0) return;  //如果读空行，跳过
                    tempLength = data_receive.Length - 1;
                    tempLength = tempLength > 14 ? 14 : tempLength;
                    for (int i = 0; i < tempLength; i++)
                    {
                        strNum = System.Text.RegularExpressions.Regex.Replace(data_receive[i], @"[^0-9]+", "");//提取字符串中的数字
                        pres[k, i] = int.Parse(strNum);
                        //int.TryParse(data_receive[i + 1], out pres[k, i]);
                        if (tempLength == 11)
                        {
                            pres[k, 12] = 0; pres[k, 13] = 0;
                        }
                    }

                    WriteText();//压力云图旁边的textbox显示数字
                    if (k == 13)
                    {
                        Model3D.Pressure.ReadCOM1616(pres);//传递到画云图
                        countReceive++;

                    }
                    k++;
                }
                else
                {
                    k = 0;//重置索引
                    pres = new int[14, 14];
                }


            }
            //}
            //catch (Exception e1)
            //{
            //    Console.WriteLine(e1);
            //    Console.WriteLine("port_DataReceived-Error:" + e1.Message, 0);
            //}
            //finally
            //{
            //    isReceiving = false;
            //}

        }


        #endregion


        #region 绘图相关方法

        private void DatabaseDisplayControl()
        {
            if (ting == 1)
            {
                ting = 0;
                draw3dShowOne.Enabled = true;
                draw3dShowTwo.Enabled = true;
            }
            else
            {
                ting = 1;
                ThreadStart dotask3 = new ThreadStart(tingch);
                Thread tskTHread3 = new Thread(dotask3);
                tskTHread3.Start();
                draw3dShowOne.Enabled = false;
                draw3dShowTwo.Enabled = false;
            }
        }

        //坐垫和靠背的压力云图
        private void tingch()
        {
            while (ting == 1)
            {
                try
                {
                    if (Model3D.Head.Data3D == null) Model3D.Head.Read(System.Windows.Forms.Application.StartupPath + @"Profile\Coodinate.txt");
                    if (Model3D.Head.xiedian == null) Model3D.Head.ReadXiedian(System.Windows.Forms.Application.StartupPath + @"Profile\xiedian.txt");
                    if (Model3DLeft.Head.Data3D == null) Model3DLeft.Head.Read(System.Windows.Forms.Application.StartupPath + @"Profile\Coodinate.txt");
                    if (Model3DLeft.Head.xiedian == null) Model3DLeft.Head.ReadXiedian(System.Windows.Forms.Application.StartupPath + @"Profile\xiedianleft.txt");

                    draw3dShowOne.IndexDrawFunction = Model3D.DrawTools;
                    draw3dShowTwo.IndexDrawFunction = Model3DLeft.DrawTools;
                    Model3D.Pressure.SetSize(Model3D.Head.RowCount, Model3D.Head.ColCount);
                    Model3DLeft.Pressure.SetSize(Model3DLeft.Head.RowCount, Model3DLeft.Head.ColCount);

                    InitialData();
                    if (Model3D.Pressure.Pressure != null)
                    {
                        CalculateParameter(Model3D.Pressure.Pressure, Model3D.Head.Data3D);
                        Model3D.Draw3D(max_value_row, max_value_col, min_value_row, min_value_col, centerPoint);
                        
                    }
                    if (Model3DLeft.Pressure.Pressure != null)
                    {
                        CalculateParameterLeft(Model3DLeft.Pressure.Pressure, Model3DLeft.Head.Data3D);
                        Model3DLeft.Draw3D(max_value_rowleft, max_value_colleft, min_value_rowleft, min_value_colleft, centerPointleft);
                    }


                    draw3dShowOne.Invoke(btnCallBackZero);
                    draw3dShowTwo.Invoke(btnCallBackZero);
                    ++csvIndex;
                }
                catch
                {

                }
            }
        }


        //重置压力云图的控件的函数
        public void InitialData()
        {
            draw3dShowOne.IndexDrawFunction = Model3D.DrawTools;
            draw3dShowTwo.IndexDrawFunction = Model3DLeft.DrawTools;
            Model3D.Pressure.SetSize(Model3D.Head.RowCount, Model3D.Head.ColCount);
            Model3DLeft.Pressure.SetSize(Model3DLeft.Head.RowCount, Model3DLeft.Head.ColCount);
            if (Model3D.Pressure.Pressure == null) Model3D.Pressure.Readdb1616();
            if (Model3DLeft.Pressure.Pressure == null) Model3DLeft.Pressure.Readdb1616Left();
            Model3D.InitialSet();
            Model3DLeft.InitialSet();
        }

        private void CalculateParameter(float[,] values, PointF3D[,] data3D)
        {
            DrawFunction3D.PointF3D maxPointTemp = new DrawFunction3D.PointF3D();
            DrawFunction3D.PointF3D minPointTemp = new DrawFunction3D.PointF3D();
            DrawFunction3D.PointF3D centerPointTemp = new DrawFunction3D.PointF3D();
            float avg_value_temp = 0, 
                max_value_temp = -9.9e30f, 
                min_value_temp = 9.9e30f, 
                sum_F_temp = 0, 
                sum_x_F_temp = 0, 
                sum_y_F_temp = 0, 
                sum_z_F_temp = 0;
            float sum_x = 0, sum_y = 0, sum_z = 0;
            num_value = 0; max_value_row = 0; max_value_col = 0; min_value_row = 0; min_value_col = 0;
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {

                    sum_F_temp += values[i, j];
                    sum_x_F_temp += values[i, j] * data3D[i, j].X;
                    sum_y_F_temp += values[i, j] * data3D[i, j].Y;
                    sum_z_F_temp += values[i, j] * data3D[i, j].Z;
                    avg_value_temp += values[i, j];
                    if (max_value_temp < values[i, j])
                    {
                        max_value_temp = values[i, j];
                        maxPointTemp = data3D[i, j];
                        max_value_row = i;
                        max_value_col = j;
                    }
                    if (min_value_temp > values[i, j])
                    {
                        if (values[i, j] > 0)
                        {
                            min_value_temp = values[i, j];
                            minPointTemp = data3D[i, j];
                            min_value_row = i;
                            min_value_col = j;
                        }
                    }
                    num_value++;
                }
            }

            avg_value = avg_value_temp / 14; max_value = max_value_temp; min_value = min_value_temp;
            sum_F = sum_F_temp; sum_x_F = sum_x_F_temp; sum_y_F = sum_y_F_temp; sum_z_F = sum_z_F_temp;

            centerPointTemp = avg_value_temp > 0.001 ?
                new DrawFunction3D.PointF3D(sum_x_F_temp / avg_value_temp, sum_y_F_temp / avg_value_temp, sum_z_F_temp / avg_value_temp) : Model3D.Head.xiedianCenter;

            maxPoint = maxPointTemp; minPoint = minPointTemp; centerPoint = centerPointTemp;

        }
        private void CalculateParameterLeft(float[,] values, DrawFunction3D.PointF3D[,] data3D)
        {
            
            DrawFunction3D.PointF3D maxPointTemp = new DrawFunction3D.PointF3D(),
                minPointTemp = new DrawFunction3D.PointF3D(),
                centerPointTemp = new DrawFunction3D.PointF3D();
            float avg_value_temp = 0, max_value_temp = -9.9e30f, min_value_temp = 9.9e30f, sum_F_temp = 0, sum_x_F_temp = 0, sum_y_F_temp = 0, sum_z_F_temp = 0;
            float sum_x = 0, sum_y = 0, sum_z = 0;
            num_valueleft = 0; max_value_rowleft = 0; max_value_colleft = 0; min_value_rowleft = 0; min_value_colleft = 0;
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {

                    sum_F_temp += values[i, j];
                    sum_x_F_temp += values[i, j] * data3D[i, j].X;
                    sum_y_F_temp += values[i, j] * data3D[i, j].Y;
                    sum_z_F_temp += values[i, j] * data3D[i, j].Z;
                    avg_value_temp += values[i, j];
                    if (max_value_temp < values[i, j])
                    {
                        max_value_temp = values[i, j];
                        maxPointTemp = data3D[i, j];
                        max_value_rowleft = i;
                        max_value_colleft = j;
                    }
                    if (min_value_temp > values[i, j])
                    {
                        if (values[i, j] > 0)
                        {
                            min_value_temp = values[i, j];
                            minPointTemp = data3D[i, j];
                            min_value_rowleft = i;
                            min_value_colleft = j;
                        }
                    }
                    num_valueleft++;
                }
            }

            avg_value = avg_value_temp / 8; max_value = max_value_temp; min_value = min_value_temp;
            sum_F = sum_F_temp; sum_x_F = sum_x_F_temp; sum_y_F = sum_y_F_temp; sum_z_F = sum_z_F_temp;

            //avg_value_temp = avg_value_temp > 0.001 ? avg_value_temp : 1;
            centerPointTemp = avg_value_temp > 0.001 ?
                new DrawFunction3D.PointF3D(sum_x_F_temp / avg_value_temp, sum_y_F_temp / avg_value_temp, sum_z_F_temp / avg_value_temp) : Model3DLeft.Head.xiedianCenter;

            maxPointleft = maxPointTemp; minPointleft = minPointTemp; centerPointleft = centerPointTemp;

        }

        private void lianxu()
        {
            //draw3dShowOne.SetView(0, 0, 0);
            draw3dShowOne.RefreshImage();
            draw3dShowTwo.RefreshImage();
        }
        private void lianxu1()
        {
            draw2dShowOne.RefreshImage();
            draw2dShowTwo.RefreshImage();
        }
        private void lianxu2()
        {  //暂时注释掉 
            //df2dsPressure.RefreshImage();
            //df2dsPressureLeft.RefreshImage();
        }

        private void WriteText()//压力云图旁边的textbox显示压力数值
        {
            //云图右侧文本框赋值
        }

        private double FinalScore(List<List<double>> fll, List<List<double>> flr)
        {

            double finalscore = 0;
            int leftCount = fll.Count();
            int rightCount = flr.Count();
            string leftMaxArea = "";
            string rightMaxArea = "";
            Console.WriteLine("左脚：" + leftCount.ToString() + ", 右脚：" + rightCount.ToString());

            //{时间得分，动力学得分，步态相位比例的分，变异性得分，冲量，峰值压力区域，摆动相比例,压力峰值}            
            Console.WriteLine("evaluate left");
            double[] leftEval = NewEvaluate(fll);
            Console.WriteLine("---------------" + "\n" + "evaluate right");
            double[] rightEval = NewEvaluate(flr);
            //double[] leftEval = { 0, 0,0, 0, 39.01, 6, 0.4, 2.32 };
            //double[] rightEval = { 0, 0, 0, 0, 39.01, 6, 0.4, 2.32 };
            //压力峰值区域
            switch (leftEval[5])
            {
                case 1: leftMaxArea = "足跟外侧"; break;
                case 2: leftMaxArea = "足跟中部"; break;
                case 3: leftMaxArea = "足跟内侧"; break;
                case 4: leftMaxArea = "第一跖骨"; break;
                case 5: leftMaxArea = "大脚趾"; break;
                case 6: leftMaxArea = "第二、三跖骨"; break;
                case 7: leftMaxArea = "第四、五跖骨"; break;
                case 8: leftMaxArea = "足弓外侧"; break;
            }
            switch (rightEval[5])
            {
                case 1: rightMaxArea = "足跟外侧"; break;
                case 2: rightMaxArea = "足跟中部"; break;
                case 3: rightMaxArea = "足跟内侧"; break;
                case 4: rightMaxArea = "第一跖骨"; break;
                case 5: rightMaxArea = "大脚趾"; break;
                case 6: rightMaxArea = "第二、三跖骨"; break;
                case 7: rightMaxArea = "第四、五跖骨"; break;
                case 8: rightMaxArea = "足弓外侧"; break;
            }
            if (leftEval[7] >= rightEval[7])
            {
                //暂时注释掉 下方
                //textBox26.Text = leftMaxArea;
            }
            else
            {
                //暂时注释掉 下方
                //textBox26.Text = rightMaxArea;
            }
            //计算对称性得分 冲量-摆动相比例-支撑相比例
            double scoreSymmetry = 0.25 * ((Math.Max(leftEval[4], rightEval[4])) / (Math.Min(leftEval[4], rightEval[4])) +
                (Math.Max(leftEval[6], rightEval[6])) / (Math.Min(leftEval[6], rightEval[6])) +
                (Math.Max(1 - leftEval[6], 1 - rightEval[6])) / (Math.Min(1 - leftEval[6], 1 - rightEval[6])) +
                (Math.Max(leftEval[7], rightEval[7])) / (Math.Min(leftEval[7], rightEval[7])));
            scoreSymmetry = 1 / scoreSymmetry;//取对称性的倒数作为最终分数
            //计算总分
            double scoreFinalleft = 0.2307 * leftEval[0] + 0.4882 * leftEval[1] + 0.1459 * leftEval[2] + 0.0919 * scoreSymmetry + 0.0433 * leftEval[3];
            double scoreFinalright = 0.2307 * rightEval[0] + 0.4882 * rightEval[1] + 0.1459 * rightEval[2] + 0.0919 * scoreSymmetry + 0.0433 * rightEval[3];
            finalscore = Math.Round(100 * Math.Min(scoreFinalleft, scoreFinalright), 2);
            //暂时注释掉 下方
            //textBox24.Text = finalscore.ToString(); 
            //textBox36.Text = Math.Round(Math.Max(1 - leftEval[6], 1 - rightEval[6]) / Math.Min(1 - leftEval[6], 1 - rightEval[6]), 2).ToString();
            //textBox35.Text = Math.Round(Math.Max(leftEval[6], rightEval[6]) / Math.Min(leftEval[6], rightEval[6]), 2).ToString();
            //textBox34.Text = Math.Round(Math.Max(leftEval[7], rightEval[7]) / Math.Min(leftEval[7], rightEval[7]), 2).ToString();
            //textBox33.Text = Math.Round(Math.Max(leftEval[4], rightEval[4]) / Math.Min(leftEval[4], rightEval[4]), 2).ToString();




            //画压力冲量的和总分的图,显示数据

            DataRow exrow = dataExport.NewRow();
            exrow[0] = daimn + 1;
            //暂时注释掉 下方
            //exrow[1] = textBox20.Text;
            //exrow[2] = textBox21.Text;
            //exrow[3] = textBox22.Text;
            //exrow[4] = textBox23.Text;
            //exrow[5] = textBox36.Text;
            //exrow[6] = textBox35.Text;
            //exrow[7] = textBox34.Text;
            //exrow[8] = textBox33.Text;
            //exrow[9] = textBox30.Text;
            //exrow[10] = textBox31.Text;
            //exrow[11] = textBox27.Text;
            //exrow[12] = textBox26.Text;
            //exrow[13] = textBox25.Text;
            //exrow[14] = textBox39.Text;
            //exrow[15] = textBox38.Text;
            //exrow[16] = textBox37.Text;
            //exrow[17] = textBox24.Text;
            //exrow[18] = textBox28.Text;
            exrow[19] = leftEval[0];
            exrow[20] = leftEval[1];
            exrow[21] = leftEval[2];
            exrow[22] = scoreSymmetry;
            exrow[23] = leftEval[3];
            dataExport.Rows.Add(exrow);
            daimn++;


            return finalscore;
        }

        private double[] NewEvaluate(List<List<double>> fll)//输入时间压力序列，输出评估结果
        {
            //步态周期时间，支撑相时间，摆动相时间，冲量，单支撑相比例，双支撑相比例，摆动比例，最大力，最大力区域，支撑相对称性，摆动对称，F对称，I对称，支撑变异，摆变异，步频变异；
            double Tc, Tstand, Tswing, IFdt, Rstand, Rdoublestand, Rswing, Fmax, /*Fmaxarea,*/ /*Sstand, Sswing, Sf, Si*/CVstand, CVswing, CVsf;
            string Fmaxarea;
            try
            {

                //分割步态周期
                List<double> SwingStart = new List<double>();
                List<double> CycleEnd = new List<double>();

                for (int i = 1; i < fll.Count() - 1; i++)
                {
                    if (fll[i][9] == 6 && fll[i - 1][9] != 6)
                    {
                        SwingStart.Add(Convert.ToDouble(i));
                    }
                    if (fll[i][9] == 6 && fll[i + 1][9] != 6 && SwingStart.Count > 0)
                    {
                        CycleEnd.Add(Convert.ToDouble(i));
                    }
                }


                //取出各个1-6、1-6、1-6 ！不知道怎么提取的newlist！
                List<List<double>> newl = new List<List<double>>();
                for (int i = 0; i < fll.Count(); i++)
                {
                    newl.Add(fll[i]);
                }

                //计算步态周期
                double tctemp = 0;
                Tc = 0;
                double[] dtc = new double[CycleEnd.Count()];
                for (int i = 0; i < CycleEnd.Count() - 1; i++)
                {
                    dtc[i] = (CycleEnd[i + 1] - CycleEnd[i]) * 1 / Convert.ToDouble(10);
                    tctemp += dtc[i];
                }
                Tc = tctemp / (CycleEnd.Count());
                //计算步频
                SF = 120 / Tc;

                //计算摆动相
                double tstemp = 0;
                Tswing = 0;
                double[] dts = new double[CycleEnd.Count()];
                for (int i = 0; i < CycleEnd.Count(); i++)
                {
                    dts[i] = (CycleEnd[i] - SwingStart[i]) * 1 / Convert.ToDouble(10);
                    tstemp += dts[i];
                }
                Tswing = tstemp / (CycleEnd.Count());
                //计算支撑相
                Tstand = Tc - Tswing;

                //摆动相比例
                Rswing = Tswing / Tc;
                //支撑相比例，不计算单支撑相和双支撑相了，只计算总的支撑相
                Rstand = 1 - Rswing;


                //动力学参数
                //压力冲量
                double Fdt = 0;
                for (int i = 0; i < newl.Count(); i++)
                {
                    Fdt += newl[i][10];
                }
                IFdt = Fdt * 1 / Convert.ToDouble(10);

                //去掉其他列
                double maxvalueline = 0;
                int maxpos = 1;
                for (int i = 0; i < newl.Count(); i++)
                {
                    newl[i].RemoveAt(10);
                    newl[i].RemoveAt(9);
                    newl[i].RemoveAt(0);
                    for (int j = 0; j < newl[i].Count(); j++)
                    {
                        if (newl[i][j] > maxvalueline)
                        {
                            maxvalueline = newl[i][j];
                            maxpos = j + 1;//最大值区域
                        }
                    }
                }
                //足底压力峰值
                Fmax = maxvalueline;

                //变异性
                //步态周期dtc、摆动相时间dts=dtswing、支撑相时间 的序列
                double[] dtstand = new double[dtc.Length];
                double dtcVar = 0, dtsVar = 0, dtstandVar = 0;
                for (int i = 0; i < dtc.Length; i++)
                {
                    dtstand[i] = dtc[i] - dts[i];

                    dtcVar += Math.Pow(dtc[i] - Tc, 2);
                    dtsVar += Math.Pow(dts[i] - Tswing, 2);
                    dtstandVar += Math.Pow(dtstand[i] - Tstand, 2);
                }

                dtcVar /= dtc.Length;
                dtsVar /= dtc.Length;
                dtstandVar /= dtc.Length;

                CVsf = (Math.Pow(dtcVar, 0.5)) / Tc;
                CVswing = (Math.Pow(dtsVar, 0.5)) / Tswing;
                CVstand = (Math.Pow(dtstandVar, 0.5)) / Tstand;



                //分数
                double scoreTime = 0;
                double scoreForce = 0;
                double scorePhase = 0;
                double scoreVary = 0;
                scoreTime = (1 - (Math.Abs(SF - 106)) / 106) + (1 - (Math.Abs(Tc - 1.16)) / 1.16) + (1 - (Math.Abs(Tswing - 0.47)) / 0.47) + (1 - (Math.Abs(Tstand - 0.69)) / 0.69);
                scoreTime = 0.25 * scoreTime;
                double isMaxAreaRight = 0.6;
                if (maxpos == 6) { isMaxAreaRight = 1; }
                scoreForce = 0.3 * (1 - (Math.Abs(Fmax - 2.32)) / 100) + 0.4 * (1 - (Math.Abs(IFdt * 5 - 100)) / 100) + 0.3 * isMaxAreaRight;
                scorePhase = 0.6 * (1 - (Math.Abs(Rstand - 0.6)) / 0.6) + /*0.3 * (1 - (Math.Abs(Rdoublestand - 0.2)) / 0.2) +*/ 0.4 * (1 - (Math.Abs(Rswing - 0.4)) / 0.4);
                //！
                scoreVary = 0.3 * (1 - CVstand / 100) + 0.3 * (1 - CVswing / 100) + 0.4 * (1 - CVsf / 100);



                //暂时注释掉 下方
                //textBox20.Text = Math.Round(SF, 2).ToString();
                //textBox21.Text = Math.Round(Tc, 2).ToString();
                //textBox22.Text = Math.Round(Tstand, 2).ToString();
                //textBox23.Text = Math.Round(Tswing, 2).ToString();


                //textBox31.Text = Math.Round(Rstand, 2).ToString();
                //textBox30.Text = Math.Round(Rswing, 2).ToString();

                //textBox27.Text = Math.Round(Fmax, 2).ToString();
                //textBox25.Text = Math.Round(IFdt, 2).ToString();

                //textBox39.Text = Math.Round(CVswing, 2).ToString();
                //textBox38.Text = Math.Round(CVstand, 2).ToString();
                //textBox37.Text = Math.Round(CVsf, 2).ToString();

                //返回值
                double[] a = new double[8];
                a[0] = scoreTime;
                a[1] = scoreForce;
                a[2] = scorePhase;
                a[3] = scoreVary;
                a[4] = IFdt;//冲量s
                a[5] = maxpos;//压力峰值区域
                a[6] = Rswing;//摆动相时间比例
                a[7] = Fmax;
                for (int i = 0; i < 3; i++)
                {
                    if (a[i] < 0)
                    {
                        a[i] = 0 - a[i];
                    }
                    if (a[i] > 1)
                    {
                        a[i] = a[i] - 1;
                    }
                }
                return a;
            }
            catch (Exception exc)
            {
                Console.WriteLine("出错:" + exc);
                Console.WriteLine("--------");
                double[] a = new double[8];
                for (int i = 0; i < 3; i++)
                {
                    a[i] = 0;
                }
                a[4] = 10;
                a[6] = 6;
                a[7] = 1;

                return a;
            }

        }
        #endregion

        private void btnCloudPort_Click(object sender, EventArgs e)
        {
            //setCom();
            tabShow.SelectedIndex = 6;
        }

        private void btnSettingOk_Click(object sender, EventArgs e)
        {
            dataRecord ??= new SettingDataRecord();
            dataRecord.MessagePortName = comboCom.Text.ToString();
            dataRecord.MessageBaudRate = comboBtl.SelectedItem.ToString();
            dataRecord.leftCode = comboKbNum.SelectedItem.ToString();
            dataRecord.rightCode = comboZdNum.SelectedItem.ToString();
            if (Convert.ToInt32(txtPl.Text) > 40)
            {
                dataRecord.MessageCaiyangpinlv = 40;
            }
            else { dataRecord.MessageCaiyangpinlv = Convert.ToInt32(txtPl.Text); }
            tabShow.SelectedIndex = 0;
        }

        private void btnCloudExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);//退出程序
        }
    }
}
