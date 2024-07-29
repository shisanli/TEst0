using Microsoft.Office.Interop.Word;
using System.ComponentModel;
using System.Reflection;

namespace PressureUpper
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            SetReport();
        }

        public void SetReport(string filePath = "")
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + @"Reports\Report20201212211818汪晨星静31.html"))
            {
                _Application wordApp;
                _Document wordDoc;
                Object Nothing = Missing.Value;
                Object path;
                if (filePath == "")
                {
                    path = System.Windows.Forms.Application.StartupPath + @"Reports\Report20201212211818汪晨星静31.doc";
                }
                else
                {
                    path = System.Windows.Forms.Application.StartupPath + @"Reports\" + filePath;
                }
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
            }

            webReport.ScriptErrorsSuppressed = true; //禁用错误脚本提示  
            webReport.IsWebBrowserContextMenuEnabled = false; // 禁用右键菜单  
            webReport.WebBrowserShortcutsEnabled = false; //禁用快捷键  
            webReport.AllowWebBrowserDrop = false; // 禁止文件拖动  

            webReport.Navigate(System.Windows.Forms.Application.StartupPath + @"Reports\Report20201212211818汪晨星静31.html");
            webReport.NewWindow += CancelEventHandler;
            //将焦点给web浏览器控件
            webReport.Focus();

        }

        public void CancelEventHandler(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            e.Handled = true;
        }
    }
}
