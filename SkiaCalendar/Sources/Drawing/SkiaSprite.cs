using System;
using System.Diagnostics;
using SkiaSharp;

namespace SkiaCalendar.Sources.Drawing
{
    public class SkiaSprite : BaseDrawable
    {
        public virtual bool IsSelectable { get; } = true;
        public virtual bool ShowDebugRect { get; set; } = false;

        public SkiaSprite()
        {
            SetNeedsDisplayAction = (sprite) => { };
        }

        Lazy<uint> RandColor => new Lazy<uint>(() => (uint)(new Random(this.GetType().Name.GetHashCode()).NextDouble() * 0xFFFFFFFF));

        protected virtual SKPaint BackgroundPaint { get; } = new SKPaint
        {
            Color = 0x00000000
        };

        public override void Draw(SKCanvas canvas, SKRect size, bool isDebug = false)
        {
            base.Draw(canvas, size, isDebug);

            var rect = GetRect(size);
            DrawRect(canvas, rect);
            if (isDebug || ShowDebugRect)
            {
                canvas.DrawRect(rect, new SKPaint
                {
                    Color = new SKColor(RandColor.Value),
                    Style = SKPaintStyle.Stroke,
                });
            }
        }

        protected virtual void DrawRect(SKCanvas canvas, SKRect size)
        {
            DrawBackgroundRect(canvas, size);
        }

        protected virtual void DrawBackgroundRect(SKCanvas canvas, SKRect size)
        {
            canvas.DrawRect(size, BackgroundPaint);
        }

        public virtual SKRect GetRect(SKRect canvasRect) => canvasRect;
    }
}
