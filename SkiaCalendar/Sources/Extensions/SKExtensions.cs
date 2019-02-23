using System;
using SkiaSharp;

namespace SkiaCalendar.Sources.Extensions
{
    public static class SKExtensions
    {
        /// <remarks>https://stackoverflow.com/questions/27631736/meaning-of-top-ascent-baseline-descent-bottom-and-leading-in-androids-font</remarks>
        /// <remarks>https://gist.github.com/benoitjadinon/f0d62c094689aa2e4c8824afb1690f62</remarks>
        public static void DrawTextCenteredVertically(this SKCanvas canvas, string text, SKPaint paint, SKPoint point)
        {
            var textHeight = -paint.FontMetrics.Ascent + paint.FontMetrics.Descent;
            float textOffset = (textHeight / 2) - (paint.FontMetrics.Descent / 2);
            var textY = point.Y + textOffset;
            canvas.DrawText(text, point.X, textY, paint);
        }
    }
}
