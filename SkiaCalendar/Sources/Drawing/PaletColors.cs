using System;
using SkiaCalendar.Sources.Settings;
using SkiaCalendar.Sources.UI;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using UIKit;

namespace SkiaCalendar.Sources.Drawing
{
    public abstract class PaletColors
    {
        private readonly CalendarSettings _calendarSettings;

        public PaletColors(CalendarSettings calendarSettings)
        {
            _calendarSettings = calendarSettings;
        }

        public virtual SKPaint PaintHeaderDay { get; } = new SKPaint
        {
            IsAntialias = true,
            TextSize = 14,
            TextAlign = SKTextAlign.Center,
            Color = UIColor.FromRGB(255, 255, 255).ToSKColor(),
            Style = SKPaintStyle.Fill,
            Typeface = SFFonts.SFSemibold(),
            StrokeWidth = 1,
        };

        public virtual SKPaint PaintDay { get; } = new SKPaint
        {
            IsAntialias = true,
            TextSize = 14,
            TextAlign = SKTextAlign.Center,
            Color = UIColor.FromRGB(216, 216, 216).ToSKColor(),
            Style = SKPaintStyle.Fill,
            Typeface = SFFonts.SFMedium(),
            StrokeWidth = 1,
        };

        public virtual SKPaint PaintToday { get; } = new SKPaint
        {
            IsAntialias = true,
            TextSize = 14,
            TextAlign = SKTextAlign.Center,
            Color = UIColor.FromRGB(255, 255, 255).ToSKColor(),
            Style = SKPaintStyle.Fill,
            Typeface = SFFonts.SFBold(),
            StrokeWidth = 1,
        };

        public virtual SKPaint PaintTodayDisabled { get; } = new SKPaint
        {
            IsAntialias = true,
            TextSize = 14,
            TextAlign = SKTextAlign.Center,
            Color = UIColor.FromRGBA(255, 176, 177, 176).ToSKColor(),
            Style = SKPaintStyle.Fill,
            Typeface = SFFonts.SFMedium(),
            StrokeWidth = 1,
        };

        public virtual SKPaint PaintDayDisabled { get; } = new SKPaint
        {
            IsAntialias = true,
            TextSize = 14,
            TextAlign = SKTextAlign.Center,
            Color = UIColor.FromRGBA(255, 176, 177, 0).ToSKColor(),
            Style = SKPaintStyle.Fill,
            Typeface = SFFonts.SFMedium(),
            StrokeWidth = 1,
        };

        public virtual SKPaint PaintDayDisabledInsideMonth { get; } = new SKPaint
        {
            IsAntialias = true,
            TextSize = 14,
            TextAlign = SKTextAlign.Center,
            Color = UIColor.FromRGBA(216, 216, 216, (30 * 255) / 100).ToSKColor(),
            Style = SKPaintStyle.Fill,
            Typeface = SFFonts.SFMedium(),
            StrokeWidth = 1,
        };

        public virtual SKPaint PaintSelected { get; } = new SKPaint
        {
            IsAntialias = true,
            Color = UIColor.FromRGBA(127, 207, 220, (20 * 255) / 100).ToSKColor(),
            Style = SKPaintStyle.Fill,
        };

        public virtual SKPaint PaintBackgroundDatePast { get; } = new SKPaint
        {
            IsAntialias = true,
            Color = UIColor.FromRGBA(243, 243, 243, 0).ToSKColor(),
            Style = SKPaintStyle.Fill,
        };

        public virtual SKPaint PaintLine { get; } = new SKPaint
        {
            IsAntialias = true,
            Color = UIColor.FromRGBA(126, 150, 171, 0).ToSKColor(),
            Style = SKPaintStyle.Fill,
            StrokeWidth = 0,
        };
    }
}
