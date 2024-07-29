using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PressureUpper
{
    public partial class FormAboutUs : Form
    {
        public FormAboutUs()
        {
            InitializeComponent();
        }

        private void FormAboutUs_Load(object sender, EventArgs e)
        {
            SetHome();
        }

        private void SetHome()
        {
            webAbout.ScriptErrorsSuppressed = true; //禁用错误脚本提示  
            webAbout.IsWebBrowserContextMenuEnabled = false; // 禁用右键菜单  
            webAbout.WebBrowserShortcutsEnabled = false; //禁用快捷键  
            webAbout.AllowWebBrowserDrop = false; // 禁止文件拖动  

            webAbout.Navigate(System.Windows.Forms.Application.StartupPath + @"Content\Home.html");
            webAbout.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
            webAbout.NewWindow += CancelEventHandler;
            //将焦点给web浏览器控件
            webAbout.Focus();
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
