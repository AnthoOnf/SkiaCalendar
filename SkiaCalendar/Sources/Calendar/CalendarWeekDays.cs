using System;
using System.Collections.Generic;
using System.Linq;
using SkiaCalendar.Sources.Drawing;
using SkiaCalendar.Sources.Settings;
using SkiaSharp;

namespace SkiaCalendar.Sources.Calendar
{
    public class CalendarWeekDays : SkiaSprite
    {
        private SKPaint _paint { get; set; }
        private readonly List<string> _daysOfWeek;

        public CalendarWeekDays(SKPaint paint, Localize localize)
        {
            _paint = paint;

            _daysOfWeek = Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>()
                .Select(d => (((int)d + 1) % 7))
                .Select(d => localize.GetCurrentCultureInfo().DateTimeFormat.DayNames[d])
                .Select(d => d.Substring(0, 1))
                .ToList();
        }


        public override SKRect GetRect(SKRect canvasRect)
        {
            return SKRect.Create(
                x: 0,
                y: 0,
                width: canvasRect.Width,
                height: CalendarDrawer.HeaderHeight
            );
        }

        protected override void DrawRect(SKCanvas canvas, SKRect size)
        {
            for (var i = 0; i < _daysOfWeek.Count; i++)
            {
                canvas.DrawText(_daysOfWeek[i],
                    new SKPoint(
                        (size.Width / 7 * i) + (size.Width / 7 / 2),
                        (size.Top + (size.Height / 2) + (_paint.TextSize / 2))
                    ),
                    _paint);
            }
        }
    }
}
