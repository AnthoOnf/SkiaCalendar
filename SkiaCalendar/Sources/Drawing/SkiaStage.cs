using System;
using SkiaSharp;

namespace SkiaCalendar.Sources.Drawing
{
    /// <summary>
    /// The stage is the equivalent of a cell
    /// </summary>
    public class SkiaStage : BaseDrawable
    {
        protected float MarginH { get; private set; }
        protected float MarginV { get; private set; }

        private readonly SKColor _backgroundColor;

        public SkiaStage(Action invalidate, SKColor backgroundColor, float marginH = 0, float marginV = 0)
        {
            MarginH = marginH;
            MarginV = marginV;
            _backgroundColor = backgroundColor;

            SetNeedsDisplayAction = s => invalidate?.Invoke();
        }

        public override void Draw(SKCanvas canvas, SKRect size, bool isDebug = false)
        {
            canvas.Clear(_backgroundColor);
            base.Draw(canvas, size, isDebug);
        }
    }
}
