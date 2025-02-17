using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CustomerSkin
{
    public delegate void SkinFormControlBoxRenderEventHandler(
        object sender,
        SkinFormControlBoxRenderEventArgs e);

    public class SkinFormControlBoxRenderEventArgs : PaintEventArgs
    {
        private CustomerSkinMain _form;
        private bool _active;
        private ControlBoxState _controlBoxState;
        private ControlBoxStyle _controlBoxStyle;
        private CmSysButton _CmSysbutton;

        public SkinFormControlBoxRenderEventArgs(
            CustomerSkinMain form,
            Graphics graphics,
            Rectangle clipRect,
            bool active,
            ControlBoxStyle controlBoxStyle,
            ControlBoxState controlBoxState,
            CmSysButton cmSysbutton = null)
            : base(graphics, clipRect)
        {
            _form = form;
            _active = active;
            _controlBoxState = controlBoxState;
            _controlBoxStyle = controlBoxStyle;
            _CmSysbutton = cmSysbutton;
        }
        public CmSysButton CmSysButton
        {
            get { return _CmSysbutton; }
        }

        public CustomerSkinMain Form
        {
            get { return _form; }
        }

        public bool Active
        {
            get { return _active; }
        }

        public ControlBoxStyle ControlBoxStyle
        {
            get { return _controlBoxStyle; }
        }

        public ControlBoxState ControlBoxtate
        {
            get { return _controlBoxState; }
        }
    }
}
