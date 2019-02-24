using System;
using SkiaCalendar.Sources.Drawing;
using SkiaSharp;

namespace SkiaCalendar.Sources.Calendar
{
    public class CalendarPrevNext : SkiaLabel
    {
        private readonly int _direction;

        private readonly string _label;
        protected override string Text => _label;

        private readonly SKPaint _paint;
        protected override SKPaint Paint => _paint;

        public CalendarPrevNext(string label, int direction, SKPaint paint, Action<int> action)
        {
            _label = label;
            _direction = direction;
            _paint = paint;
            this.OnPressAction = bt => action?.Invoke(direction);
        }

        public override SKRect GetRect(SKRect size)
        {
            var w = 64;
            var h = 64;

            return SKRect.Create(
                x: _direction < 0 ? 0 : size.Width - w,
                y: size.Top,
                width: w,
                height: h
            );
        }
    }
}
