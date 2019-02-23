using System;
using SkiaCalendar.Sources.Drawing;
using SkiaCalendar.Sources.Extensions;
using SkiaCalendar.Sources.Settings;
using SkiaSharp;

namespace SkiaCalendar.Sources.Calendar
{
    public class CalendarDay : SkiaLabel
    {
        private readonly CalendarRules _rules;
        private readonly CalendarPaints _paints;
        private readonly DateTime _selectedMonth;
        private readonly int _totalWeeksToDisplay;

        public DateTime Date { get; private set; }

        public override bool IsSelectable => _rules.IsDaySelectable(Date, _selectedMonth);
        protected override bool IsCenteredVertically { get; } = true;
        public override bool ShowDebugRect { get; set; } = false;
        protected override string Text => Date.Day.ToString();

        public bool IsSelected { get; set; } = false;
        public int DayPos => Date.GetDayPositionInWeek();
        private bool _isToday => Date.Date == DateTime.Now.Date;

        public CalendarDay(DateTime d,
                        DateTime selectedMonth,
                        int totalWeeksToDisplay,
                        CalendarPaints paints,
                        CalendarRules calendarRules,
                        Action<DateTime> onPress,
                        bool isSelected = false)
        {
            Date = d;
            _paints = paints;
            _rules = calendarRules;
            _selectedMonth = selectedMonth;
            _totalWeeksToDisplay = totalWeeksToDisplay;
            OnPressAction = bt => onPress?.Invoke(Date);
            IsSelected = isSelected;
        }


        public int WeekPos =>
            (Date.Year < _selectedMonth.Year)
                ? (Date.GetWeekOfMonth(_selectedMonth) % 52)
                : (Date.Year > _selectedMonth.Year)
                    ? new DateTime(_selectedMonth.Year, _selectedMonth.Month, DateTime.DaysInMonth(_selectedMonth.Year, _selectedMonth.Month)).GetWeekOfMonth(_selectedMonth)
                    : Date.GetWeekOfMonth(_selectedMonth);

        protected override SKPaint Paint =>
            _rules.IsDaySelectable(Date, _selectedMonth)
                ? _isToday
                    ? _paints.PaintToday
                    : _paints.PaintDay
                : _isToday
                    ? _paints.PaintTodayDisabled
                    : _rules.IsDayIsInsideOfSelectedMonth(Date, _selectedMonth)
                        ? _paints.PaintDayDisabledInsideMonth
                        : _paints.PaintDayDisabled;

        protected override SKPaint BackgroundPaint =>
            _rules.IsDayOutOfSelectableRange(Date)
                ? _paints.PaintBackgroundDatePast
                : IsSelected
                    ? _paints.PaintSelected
                    : base.BackgroundPaint;

        protected override void DrawBackgroundRect(SKCanvas canvas, SKRect size)
        {
            if (_rules.IsDayOutOfSelectableRange(Date))
            {
                base.DrawBackgroundRect(canvas, size);
            }
            else
            {
                size.Inflate(-10, -10);
                canvas.DrawCircle(size.Location.X + (size.Width / 2),
                                  size.Location.Y + (size.Height / 2),
                                  size.Height / 2, BackgroundPaint);
            }
        }

        public override SKRect GetRect(SKRect canvasRect)
        {
            canvasRect.Top = CalendarDrawer.HeaderHeight;

            var w = canvasRect.Width / CalendarDrawer.DAYS_PER_WEEK;
            var h = canvasRect.Height / _totalWeeksToDisplay;

            return SKRect.Create(
                x: canvasRect.Left + (DayPos * w),
                y: canvasRect.Top + (WeekPos * h),
                width: w,
                height: h
            );
        }
    }
}
