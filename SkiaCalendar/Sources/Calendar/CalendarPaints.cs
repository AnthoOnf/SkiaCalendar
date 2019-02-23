using System;
using Foundation;
using SkiaCalendar.Sources.Settings;
using SkiaCalendar.Sources.UI;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using UIKit;

namespace SkiaCalendar.Sources.Calendar
{
    public class CalendarPaints
    {
        public SKPaint EmptyCell { get; }
        public SKPaint PaintHeaderDay { get; }
        public SKPaint PaintDay { get; }
        public SKPaint PaintDayDisabled { get; }
        public SKPaint PaintToday { get; }
        public SKPaint PaintTodayDisabled { get; }
        public SKPaint PaintDayDisabledInsideMonth { get; }

        public CalendarPaints(CalendarSettings calendarSettings)
        {
            PaintHeaderDay = new SKPaint
            {
                IsAntialias = true,
                TextSize = 14,
                TextAlign = SKTextAlign.Center,
                Color = UIColor.FromRGB(255, 255, 255).ToSKColor(),
                Style = SKPaintStyle.Fill,
                Typeface = SFFonts.SFSemibold(),
                StrokeWidth = 1,
            };

            PaintDay = new SKPaint
            {
                IsAntialias = true,
                TextSize = 14,
                TextAlign = SKTextAlign.Center,
                Color = UIColor.FromRGB(216, 216, 216).ToSKColor(),
                Style = SKPaintStyle.Fill,
                Typeface = SFFonts.SFMedium(),
                StrokeWidth = 1,
            };

            PaintToday = new SKPaint
            {
                IsAntialias = true,
                TextSize = 14,
                TextAlign = SKTextAlign.Center,
                Color = UIColor.FromRGB(255, 255, 255).ToSKColor(),
                Style = SKPaintStyle.Fill,
                Typeface = SFFonts.SFBold(),
                StrokeWidth = 1,
            };
            PaintTodayDisabled = new SKPaint
            {
                IsAntialias = true,
                TextSize = 14,
                TextAlign = SKTextAlign.Center,
                Color = UIColor.FromRGBA(255, 176, 177, 176).ToSKColor(),
                Style = SKPaintStyle.Fill,
                Typeface = SFFonts.SFMedium(),
                StrokeWidth = 1,
            };

            PaintDayDisabled = new SKPaint
            {
                IsAntialias = true,
                TextSize = 14,
                TextAlign = SKTextAlign.Center,
                Color = UIColor.FromRGBA(255, 176, 177, 0).ToSKColor(),
                Style = SKPaintStyle.Fill,
                Typeface = SFFonts.SFMedium(),
                StrokeWidth = 1,
            };

            PaintDayDisabledInsideMonth = new SKPaint
            {
                IsAntialias = true,
                TextSize = 14,
                TextAlign = SKTextAlign.Center,
                Color = UIColor.FromRGBA(216, 216, 216, (30 * 255) / 100).ToSKColor(),
                Style = SKPaintStyle.Fill,
                Typeface = SFFonts.SFMedium(),
                StrokeWidth = 1,
            };
        }

        public SKPaint PaintSelected { get; } = new SKPaint
        {
            IsAntialias = true,
            Color = UIColor.FromRGBA(127, 207, 220, (20 * 255) / 100).ToSKColor(),
            Style = SKPaintStyle.Fill,
        };

        public SKPaint PaintBackgroundDatePast { get; } = new SKPaint
        {
            IsAntialias = true,
            Color = UIColor.FromRGBA(243, 243, 243, 0).ToSKColor(),
            Style = SKPaintStyle.Fill,
        };

        public SKPaint PaintLine { get; } = new SKPaint
        {
            IsAntialias = true,
            Color = UIColor.FromRGBA(126, 150, 171, 0).ToSKColor(),
            Style = SKPaintStyle.Fill,
            StrokeWidth = 0,
        };


    }
}
