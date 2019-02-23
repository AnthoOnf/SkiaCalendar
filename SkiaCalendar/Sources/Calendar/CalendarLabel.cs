using System;
using SkiaCalendar.Sources.Drawing;
using SkiaSharp;

namespace SkiaCalendar.Sources.Calendar
{
    public class CalendarLabel : SkiaLabel
    {
        private Func<string> _text;
        protected override string Text => _text?.Invoke();

        private SKPaint _paint;
        protected override SKPaint Paint => _paint;

        public CalendarLabel(Func<string> text, SKPaint paint)
        {
            _text = text;
            _paint = paint;
        }

        public override SKRect GetRect(SKRect canvasRect)
        {
            return new SKRect(canvasRect.Left, canvasRect.Top, canvasRect.Width, Paint.TextSize * 2);
        }
    }
}
