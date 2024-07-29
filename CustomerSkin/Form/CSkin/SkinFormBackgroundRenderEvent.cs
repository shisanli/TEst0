using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CustomerSkin
{
     public delegate void SkinFormBackgroundRenderEventHandler(
        object sender,
        SkinFormBackgroundRenderEventArgs e);

    public class SkinFormBackgroundRenderEventArgs : PaintEventArgs
    {
        private CustomerSkinMain _skinForm;

        public SkinFormBackgroundRenderEventArgs(
            CustomerSkinMain skinForm,
            Graphics g,
            Rectangle clipRect)
            : base(g, clipRect)
        {
            _skinForm = skinForm;
        }

        public CustomerSkinMain SkinForm
        {
            get { return _skinForm; }
        }
    }
}
