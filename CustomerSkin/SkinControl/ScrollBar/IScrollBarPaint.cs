using System;
namespace CustomerSkin.SkinControl
{
    public interface IScrollBarPaint
    {
        void OnPaintScrollBarArrow(PaintScrollBarArrowEventArgs e);
        void OnPaintScrollBarThumb(PaintScrollBarThumbEventArgs e);
        void OnPaintScrollBarTrack(PaintScrollBarTrackEventArgs e);
    }
}
