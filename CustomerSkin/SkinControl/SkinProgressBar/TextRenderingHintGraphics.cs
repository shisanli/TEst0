
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Text;

namespace CustomerSkin.SkinControl
{
    internal class TextRenderingHintGraphics : IDisposable
    {
        private Graphics _graphics;
        private TextRenderingHint _oldTextRenderingHint;

        public TextRenderingHintGraphics(Graphics graphics)
            : this(graphics, TextRenderingHint.AntiAlias)
        {
        }

        public TextRenderingHintGraphics(
            Graphics graphics,
            TextRenderingHint newTextRenderingHint)
        {
            _graphics = graphics;
            _oldTextRenderingHint = graphics.TextRenderingHint;
            _graphics.TextRenderingHint = newTextRenderingHint;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            _graphics.TextRenderingHint = _oldTextRenderingHint;
        }

        #endregion
    }
}
