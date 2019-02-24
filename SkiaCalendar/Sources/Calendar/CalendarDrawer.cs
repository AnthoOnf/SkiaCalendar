using System;
using System.Globalization;
using SkiaCalendar.Sources.Drawing;
using SkiaCalendar.Sources.Extensions;
using SkiaCalendar.Sources.Settings;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using UIKit;

namespace SkiaCalendar.Sources.Calendar
{
    public class CalendarDrawer : SkiaStage
    {
        public const int MAX_DISPLAYED_WEEKS = 6;
        public const int DAYS_PER_WEEK = 7;

        public static float HeaderHeight => 40;

        private readonly CalendarSettings _calendarSettings;
        private readonly Action<MonthSelectionState> _onMonthChange;

        private DateTime _selectedDate, _currentMonth;

        private readonly CalendarPaints _paints;
        private float _x, _y;
        private CalendarMonth _currentMonthSprite;

        public CalendarDrawer(CalendarSettings calendarSettings,
                              Action invalidate,
                              Action<MonthSelectionState> onMonthChange,
                              UIColor cellColor,
                              float marginH = 0,
                              float marginV = 0)
            : base(invalidate, cellColor.ToSKColor(), marginH, marginV)
        {
            _calendarSettings = calendarSettings;
            _onMonthChange = onMonthChange;
            _paints = new CalendarPaints(calendarSettings);
            _selectedDate = _currentMonth = calendarSettings.SelectedDate;
            ChangeMonth(0);
        }

        public void ChangeMonth(int direction)
        {
            ChangeMonth(new DateTime(_currentMonth.Year, _currentMonth.Month, 1).AddMonths(direction));
        }

        public void ChangeMonth(DateTime selectedMonth)
        {
            Clear();

            _currentMonth = selectedMonth;

            _currentMonthSprite = new CalendarMonth(_currentMonth, _selectedDate, SelectDate, _paints, _calendarSettings.CalendarRules, _calendarSettings);
            Add(_currentMonthSprite);

            SetNeedsDisplay();

            _onMonthChange?.Invoke(new MonthSelectionState
            {
                CanGoBack = !_calendarSettings.CalendarRules.MinSelectableDate.HasValue ||
                            _currentMonth.GetFirstDayOfMonth() > _calendarSettings.CalendarRules.MinSelectableDate.Value.GetFirstDayOfMonth(),
                CanGoForward = !_calendarSettings.CalendarRules.MaxSelectableDate.HasValue ||
                                _currentMonth.GetFirstDayOfMonth() < _calendarSettings.CalendarRules.MaxSelectableDate.Value.GetFirstDayOfMonth(),
                MonthName = _currentMonth.ToString(_calendarSettings.DateMonthFormat, _calendarSettings.Culture)
            });
        }

        public void SelectDate(DateTime selectedDay)
        {
            _selectedDate = selectedDay;
            _calendarSettings.OnDateSelected(selectedDay);

            SetNeedsDisplay();
        }

        public void Paint(SKSurface eSurface, SKImageInfo eInfo)
        {
            var canvas = eSurface.Canvas;
            var size = eInfo.Size;

            canvas.Scale(_calendarSettings.ScaleFactor);

            Draw(canvas, new SKRect(0, 0, size.Width / _calendarSettings.ScaleFactor,
                                          size.Height / _calendarSettings.ScaleFactor));
        }

        public void OnPressGesture(SKTouchEventArgs sk)
        {
            _x = sk.Location.X / _calendarSettings.ScaleFactor;
            _y = sk.Location.Y / _calendarSettings.ScaleFactor;
            var b = _currentMonthSprite?.GetSpriteAt<SkiaButton>(new SKPoint(_x, _y));
            b?.OnPress();
        }
    }
}
