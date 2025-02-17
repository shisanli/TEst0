using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CustomerSkin
{
    public delegate void SkinFormCaptionRenderEventHandler(
        object sender,
        SkinFormCaptionRenderEventArgs e);

    public class SkinFormCaptionRenderEventArgs : PaintEventArgs
    {
        private CustomerSkinMain _skinForm;
        private bool _active;

        public SkinFormCaptionRenderEventArgs(
            CustomerSkinMain skinForm,
            Graphics g,
            Rectangle clipRect,
            bool active)
            : base(g, clipRect)
        {
            _skinForm = skinForm;
            _active = active;
        }

        public CustomerSkinMain SkinForm
        {
            get { return _skinForm; }
        }

        public bool Active
        {
            get { return _active; }
        }
    }
}
