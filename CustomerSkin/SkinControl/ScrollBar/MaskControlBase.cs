
using System;
using System.Windows.Forms;
using CustomerSkin.Win32.Const;
using CustomerSkin.Win32;
using CustomerSkin.Win32.Struct;
using System.Drawing;

namespace CustomerSkin.SkinControl
{
    internal abstract class MaskControlBase : 
        NativeWindow, IDisposable
    {
        #region 变量

        private CreateParams _createParams;
        private bool _disposed;

        #endregion

        #region 带参构造

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd">被覆盖控件的句柄。</param>
        protected MaskControlBase(IntPtr hWnd)
            : base()
        {
            CreateParamsInternal(hWnd);
        }

        protected MaskControlBase(
            IntPtr hWnd, Rectangle rect)
        {
            CreateParamsInternal(hWnd, rect);
        }

        ~MaskControlBase()
        {
            Dispose(false);
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取窗口句柄是否已经创建。
        /// </summary>
        protected bool IsHandleCreated
        {
            get { return base.Handle != IntPtr.Zero; }
        }

        protected virtual CreateParams CreateParams
        {
            get
            {
                return _createParams;
            }
        }

        /// <summary>
        /// 创建窗口的句柄。
        /// </summary>
        internal protected void OnCreateHandle()
        {
            base.CreateHandle(CreateParams);
            SetZorder();
        }

        protected virtual void OnPaint(IntPtr hWnd)
        {
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            try
            {
                switch (m.Msg)
                {
                    case WM.WM_NCPAINT:
                    case WM.WM_PAINT:
                        OnPaint(m.HWnd);
                        break;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd">被覆盖控件句柄。</param>
        internal void CreateParamsInternal(IntPtr hWnd)
        {
            IntPtr hParent = Win32.NativeMethods.GetParent(hWnd);
            RECT rect = new RECT();
            Win32.NativeMethods.Point point = new Win32.NativeMethods.Point();

            Win32.NativeMethods.GetWindowRect(hWnd, ref rect);
            point.x = rect.Left;
            point.y = rect.Top;
            Win32.NativeMethods.ScreenToClient(hParent, ref point);

            int dwStyle =
                SS.SS_OWNERDRAW |
                WS.WS_CHILD |
                WS.WS_CLIPSIBLINGS |
                WS.WS_OVERLAPPED | WS.WS_VISIBLE;
            int dwExStyle = WS_EX.WS_EX_TOPMOST | WS_EX.WS_EX_TOOLWINDOW;
            _createParams = new CreateParams();

            _createParams.Parent = hParent;
            _createParams.ClassName = ClassName.STATIC;
            _createParams.Caption = null;
            _createParams.Style = dwStyle;
            _createParams.ExStyle = dwExStyle;
            _createParams.X = point.x;
            _createParams.Y = point.y;
            _createParams.Width = rect.Right - rect.Left;
            _createParams.Height = rect.Bottom - rect.Top;
        }

        internal void CreateParamsInternal(IntPtr hWnd, Rectangle rect)
        {
            IntPtr hParent = Win32.NativeMethods.GetParent(hWnd);

            int dwStyle =
                SS.SS_OWNERDRAW |
                WS.WS_CHILD |
                WS.WS_CLIPSIBLINGS |
                WS.WS_OVERLAPPED | WS.WS_VISIBLE;
            int dwExStyle = WS_EX.WS_EX_TOPMOST | WS_EX.WS_EX_TOOLWINDOW;
            _createParams = new CreateParams();

            _createParams.Parent = hParent;
            _createParams.ClassName = ClassName.STATIC;
            _createParams.Caption = null;
            _createParams.Style = dwStyle;
            _createParams.ExStyle = dwExStyle;
            _createParams.X = rect.X;
            _createParams.Y = rect.Y;
            _createParams.Width = rect.Width;
            _createParams.Height = rect.Height;
        }

        internal void DestroyHandleInternal()
        {
            if (IsHandleCreated)
            {
                base.DestroyHandle();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd">被覆盖控件句柄。</param>
        internal void CheckBounds(IntPtr hWnd)
        {
            RECT controlRect = new RECT();
            RECT maskRect = new RECT();

            Win32.NativeMethods.GetWindowRect(base.Handle, ref maskRect);
            Win32.NativeMethods.GetWindowRect(hWnd, ref controlRect);

            uint uFlag =
                SWP.SWP_NOACTIVATE |
                SWP.SWP_NOOWNERZORDER |
                SWP.SWP_NOZORDER;

            if (!Win32.NativeMethods.EqualRect(ref controlRect, ref maskRect))
            {
                Win32.NativeMethods.Point point = new Win32.NativeMethods.Point(controlRect.Left, controlRect.Top);
                IntPtr hParent = Win32.NativeMethods.GetParent(base.Handle);
                Win32.NativeMethods.ScreenToClient(hParent, ref point);

                Win32.NativeMethods.SetWindowPos(
                    base.Handle,
                    IntPtr.Zero,
                    point.x,
                    point.y,
                    controlRect.Right - controlRect.Left,
                    controlRect.Bottom - controlRect.Top,
                    uFlag);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd">被覆盖控件句柄。</param>
        internal void SetVisibale(IntPtr hWnd)
        {
            bool bVisible = (Win32.NativeMethods.GetWindowLong(
                hWnd,
                GWL.GWL_STYLE) & WS.WS_VISIBLE) == WS.WS_VISIBLE;
            SetVisibale(bVisible);
        }

        internal void SetVisibale(bool visibale)
        {
            if (visibale)
            {
                Win32.NativeMethods.ShowWindow(base.Handle, SW.SW_NORMAL);
            }
            else
            {
                Win32.NativeMethods.ShowWindow(base.Handle, SW.SW_HIDE);
            }
        }

        private void SetZorder()
        {
            uint uFlags =
                SWP.SWP_NOMOVE |
                SWP.SWP_NOSIZE |
                SWP.SWP_NOACTIVATE |
                SWP.SWP_NOOWNERZORDER;

            Win32.NativeMethods.SetWindowPos(
                base.Handle,
                HWND.HWND_TOP,
                0,
                0,
                0,
                0,
                uFlags);
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _createParams = null;
                }

                DestroyHandleInternal();
            }
            _disposed = true;
        }

        #endregion
    }
}
