using System;
using System.Linq;
using SkiaCalendar.Sources.Drawing;
using SkiaCalendar.Sources.Extensions;
using SkiaCalendar.Sources.Settings;

namespace SkiaCalendar.Sources.Calendar
{
    public class CalendarMonth : SkiaSprite
    {
        private readonly Action<DateTime> _onSelectDate;

        public CalendarMonth(DateTime selectedMonth,
                            DateTime selectedDate,
                            Action<DateTime> onSelectDate,
                            CalendarPaints paints,
                            CalendarRules calendarRules)
        {
            _onSelectDate = onSelectDate;

            var firstDay = selectedMonth.GetFirstDayOfMonth();
            var firstDayOfFirstWeek = firstDay.AddDays(-firstDay.GetDayPositionInWeek());
            var lastDay = new DateTime(selectedMonth.Year, selectedMonth.Month, DateTime.DaysInMonth(selectedMonth.Year, selectedMonth.Month));
            var lastDayOfLastWeek = lastDay.AddDays(CalendarDrawer.DAYS_PER_WEEK - 1 - lastDay.GetDayPositionInWeek());
            var totalDays = (lastDayOfLastWeek - firstDayOfFirstWeek).Days + 1;
            var totalWeeks = (totalDays) / CalendarDrawer.DAYS_PER_WEEK;

            for (var d = 0; d < totalDays; d++)
            {
                var day = firstDayOfFirstWeek.AddDays(d);
                Add(new CalendarDay(day, selectedMonth, CalendarDrawer.MAX_DISPLAYED_WEEKS, paints, calendarRules, SelectDate, selectedDate.Date == day.Date));
            }
            Add(new SkiaGrid(1, 1, CalendarDrawer.DAYS_PER_WEEK, paints.PaintLine, 0, CalendarDrawer.HeaderHeight));

            Add(new SkiaGrid(totalWeeks, CalendarDrawer.MAX_DISPLAYED_WEEKS, CalendarDrawer.DAYS_PER_WEEK, paints.PaintLine, CalendarDrawer.HeaderHeight));
            Add(new CalendarWeekDays(paints.PaintHeaderDay));
        }

        private void SelectDate(DateTime time)
        {
            var days = GetDisplayList()
                .Where(s => s is CalendarDay)
                .Cast<CalendarDay>();

            foreach (CalendarDay d in days)
                d.IsSelected = d.Date.Date == time.Date;

            _onSelectDate?.Invoke(time);
        }
    }
}
