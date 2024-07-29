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
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {
            SetHelp();
        }

        private void SetHelp()
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