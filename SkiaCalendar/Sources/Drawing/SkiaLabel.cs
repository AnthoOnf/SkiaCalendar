using System;
using SkiaCalendar.Sources.Extensions;
using SkiaSharp;

namespace SkiaCalendar.Sources.Drawing
{
    public abstract class SkiaLabel : SkiaButton
    {
        protected abstract string Text { get; }
        protected abstract SKPaint Paint { get; }
        protected virtual bool IsCenteredVertically { get; } = false;

        protected override void DrawRect(SKCanvas canvas, SKRect size)
        {
            base.DrawRect(canvas, size);
            if (IsCenteredVertically)
                canvas.DrawTextCenteredVertically(
                    Text,
                    Paint,
                    new SKPoint(
                        x: size.Left + (size.Width / 2),
                        y: size.Top + (size.Height / 2)
                    )
                );
            else
                canvas.DrawText(
                    Text,
                    x: size.Left + (size.Width / 2),
                    y: size.Top + (size.Height / 2) + (Paint.TextSize / 2),//TODO, not right
                    paint: Paint
                );
        }
    }
}
