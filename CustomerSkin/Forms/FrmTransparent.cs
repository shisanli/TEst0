﻿using System.Reflection;
using System.Runtime.InteropServices;

namespace CustomerSkin.Forms
{
    /// <summary>
    /// Class FrmTransparent.
    /// Implements the <see cref="CustomerSkin.Forms.FrmBase" />
    /// </summary>
    /// <seealso cref="CustomerSkin.Forms.FrmBase" />
    public partial class FrmTransparent : FrmBase
    {
        /// <summary>
        /// The wm activate
        /// </summary>
        private const int WM_ACTIVATE = 6;

        /// <summary>
        /// The wm activateapp
        /// </summary>
        private const int WM_ACTIVATEAPP = 28;

        /// <summary>
        /// The wm ncactivate
        /// </summary>
        private const int WM_NCACTIVATE = 134;

        /// <summary>
        /// The wa inactive
        /// </summary>
        private const int WA_INACTIVE = 0;

        /// <summary>
        /// The wm mouseactivate
        /// </summary>
        private const int WM_MOUSEACTIVATE = 33;

        /// <summary>
        /// The ma noactivate
        /// </summary>
        private const int MA_NOACTIVATE = 3;
        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        /// <summary>
        /// Gets or sets the frmchild.
        /// </summary>
        /// <value>The frmchild.</value>
        public FrmBase frmchild
        {
            get;
            set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmTransparent" /> class.
        /// </summary>
        public FrmTransparent()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            MethodInfo method = base.GetType().GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
            method.Invoke(this, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, new object[]
			{
				ControlStyles.Selectable,
				false
			}, Application.CurrentCulture);
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Form.Load" /> 事件。
        /// </summary>
        /// <param name="e">一个包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            base.ShowInTaskbar = false;
            base.ShowIcon = true;
        }
        /// <summary>
        /// Sets the active window.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr SetActiveWindow(IntPtr handle);

        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="m">要处理的 Windows <see cref="T:System.Windows.Forms.Message" />。</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 33)
            {
                m.Result = new IntPtr(3);
            }
            else
            {
                if (m.Msg == 134)
                {
                    if (((int)m.WParam & 65535) != 0)
                    {
                        if (m.LParam != IntPtr.Zero)
                        {
                            FrmTransparent.SetActiveWindow(m.LParam);
                        }
                        else
                        {
                            FrmTransparent.SetActiveWindow(IntPtr.Zero);
                        }
                    }
                }
                else if (m.Msg == 2000)
                {
                }
                base.WndProc(ref m);
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmTransparent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmTransparent_Load(object sender, EventArgs e)
        {
            if (frmchild != null)
            {
                frmchild.IsShowMaskDialog = false;
                var dia = frmchild.ShowDialog(this);
                this.DialogResult = dia;
            }
        }
    }
}
