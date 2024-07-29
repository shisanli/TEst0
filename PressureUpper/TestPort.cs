
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PressureUpper
{
    public partial class TestPort : Form
    {
        public Thread threadSend;
        private Thread threadReceive;
        private SerialPort s;
        int ifsend;
        public TestPort()
        {
            InitializeComponent();
            StartSerialPort();
        }

        public void StartSerialPort()
        {
            foreach (string c in SerialPort.GetPortNames())
            {
                if (c != "COM5") continue;
                Debug.WriteLine("GetPortNames: " + c);
                s = new SerialPort(c, 250000, Parity.None, 8,  StopBits.One);
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//注册gb2312字符集
                s.Encoding = System.Text.Encoding.GetEncoding("GB2312");
                s.Open();

                ThreadStart threadStart = new(SendToCom);//通过ThreadStart委托告诉子线程执行什么方法　　
                threadSend = new Thread(threadStart);
                threadSend.Start();
                ifsend = 1;
                ThreadStart threadStart1 = new(ReceiveFromCom);
                threadReceive = new Thread(threadStart1);
                threadReceive.Start();

               
            }
        }

        private void SendToCom()//向端口发送指令
        {
            string leftCode = "0x04";
            while (ifsend == 1)
            {
                
                int leftint = Convert.ToInt32(leftCode.Substring(leftCode.Length - 1, 1), 16);
                string s1 = string.Empty;
                s1 += (char)leftint;
                this.s.Write(s1);
                Thread.Sleep(1000);
                ifsend = 0;
            }
        }

        private void ReceiveFromCom()
        {
            try
            {
                s.DataReceived += new SerialDataReceivedEventHandler(s1DataReceived);
                s.ReceivedBytesThreshold = 20;
            }
            catch (Exception ereceive)
            {
                Console.WriteLine(ereceive);
            }
        }

        private void s1DataReceived(object sendr, SerialDataReceivedEventArgs e)//接收数据
        {
            string str = s.ReadLine();
            Debug.WriteLine("res: \n" + str);
            listBox1.Invoke(new MethodInvoker(() => listBox1.Items.Insert(listBox1.Items.Count, "res: \n" + str)));
        }
        private void TestPort_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (s.IsOpen) s.Close();
            System.Environment.Exit(0);
        }
    }
}
