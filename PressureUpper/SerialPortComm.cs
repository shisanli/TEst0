using System.IO.Ports;

namespace PressureUpper
{
    public class SerialPortComm
    {
        public delegate void EventHandle(byte[] readBuffer); //定义委托
        public event EventHandle DataReceived;//声明委托类型的变量

        public SerialPort serialPort;//定义串口全局变量
        Thread threadRead;//定义串口读取数据线程
        Thread threadSend;//定义串口发送数据线程
        volatile bool _keepReading;//读取数据线程运行标识（0：退出运行 1：允许运行）
        volatile bool _keepSending;//发送数据线程运行标识（0：退出运行 1：允许运行）
        byte[] bufSend;//发送数据数组
        int offSetSend;//从发送数据数组中第几个数据开始发送
        int countSend;//发送数据的长度
        /// <summary>
        /// 串口类构造函数
        /// </summary>
        public SerialPortComm()
        {
            serialPort = new SerialPort();
            threadRead = null;
            _keepReading = false;//读取数据线程运行标识（0：退出运行 1：允许运行）
            threadSend = null;
            _keepSending = false;//发送数据线程运行标识（0：退出运行 1：允许运行）
            offSetSend = 0;
            countSend = 0;//发送数据的长度
        }
        /// <summary>
        /// 串口是否打开
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return serialPort.IsOpen;
            }
        }
        /// <summary>
        /// 开启串口接收数据线程
        /// </summary>
        private void StartReading()
        {
            if (!_keepReading)//如果读取数据线程没有运行
            {
                _keepReading = true;//读取数据线程运行标识（0：退出运行 1：允许运行）
                threadRead = new Thread(new ThreadStart(ReadPort));//new一个线程给读数据线程
                threadRead.Start();//运行读数据线程
            }
        }
        /// <summary>
        /// 开启串口发送数据线程
        /// </summary>
        /// <param name="buffer">发送的数据</param>
        /// <param name="offSet">从发送数据数组中第几个数据开始发送</param>
        /// <param name="count">发送数据的长度</param>
        public void StartSending(byte[] buffer, int offSet, int count)
        {
            if (!_keepSending)//如果发送数据线程没有运行
            {
                _keepSending = true;//发送数据线程运行标识（0：退出运行 1：允许运行）
                bufSend = buffer;//赋值发送数据
                offSetSend = offSet;//从发送数据数组中第几个数据开始发送
                countSend = count;//发送数据的长度
                threadSend = new Thread(new ThreadStart(SendPort));//new一个线程给读数据线程
                threadSend.Start();//运行读数据线程
            }
        }
        /// <summary>
        /// 停止串口接收数据线程
        /// </summary>
        private void StopReading()
        {
            if (_keepReading)//读取数据线程运行标识（0：退出运行 1：允许运行）
            {
                _keepReading = false;//读取数据线程运行标识（0：退出运行 1：允许运行）
                threadRead.Join();//当threadRead调用Join方法的时候，调用该线程的线程（例如MainThread）就被停止执行，直到threadRead线程执行完毕。
                threadRead = null;//清空线程
            }
        }
        /// <summary>
        /// 停止串口发送数据线程
        /// </summary>
        private void StopSending()

        {
            if (_keepSending)//发送数据线程运行标识（0：退出运行 1：允许运行）
            {
                _keepSending = false;//发送数据线程运行标识（0：退出运行 1：允许运行）
                threadSend.Join();//当threadRead调用Join方法的时候，调用该线程的线程（例如MainThread）就被停止执行，直到threadRead线程执行完毕。
                threadSend = null;//清空线程
            }
        }
        /// <summary>
        /// 串口发送数据
        /// </summary>
        private void SendPort()
        {

            while (_keepSending)//发送数据线程运行标识（0：退出运行 1：允许运行）
            {
                if (countSend != 0)//发送数据的长度
                {
                    if (IsOpen)//如果串口已经打开了
                    {
                        Application.DoEvents();//实时响应其他事件，应用程序可以处理其他事件，防止阻塞其他的事件
                        serialPort.Write(bufSend, offSetSend, countSend);//串口发送数据
                    }
                }
                Thread.Sleep(100);//线程阻塞100mS
                StopSending();// 停止发送数据线程
            }
        }

        /// <summary>
        /// 串口接收数据
        /// </summary>
        private void ReadPort()
        {
            while (_keepReading)//读取数据线程运行标识（0：退出运行 1：允许运行）
            {
                if (serialPort.IsOpen)//如果串口已经打开
                {
                    int count = serialPort.BytesToRead;//获取接收到的数据长度
                    if (count > 0)
                    {
                        byte[] readBuffer = new byte[count];
                        try
                        {
                            Application.DoEvents();//实时响应其他事件，应用程序可以处理其他事件，防止阻塞其他的事件
                            serialPort.Read(readBuffer, 0, count);//串口读取数据
                            if (DataReceived != null)//如果委托事件不为空
                                DataReceived(readBuffer);//将接收到的数据复制给委托事件
                            Thread.Sleep(100);//线程阻塞100mS
                        }
                        catch (TimeoutException)
                        {
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        public void Open()
        {
            Close();//关闭串口
            serialPort.Open();//打开串口
            if (serialPort.IsOpen)//如果打开串口成功
            {
                StartReading();//开启接收数据线程
            }
            else
            {
                MessageBox.Show("串口打开失败！");
            }
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            StopReading();//停止串口接收数据线程
            StopSending();//停止串口发送数据线程
            serialPort.Close();//关闭串口
        }
        /// <summary>
        /// 串口发送数据
        /// </summary>
        /// <param name="buffer">发送的数据</param>
        /// <param name="offSet">从发送数据数组中第几个数据开始发送</param>
        /// <param name="count">发送数据的长度</param>
        public void WritePort(byte[] buffer, int offSet, int count)
        {
            if (IsOpen)//如果串口已经开启了
            {
                serialPort.Write(buffer, offSet, count);//串口发送数据
            }
        }
    }
}