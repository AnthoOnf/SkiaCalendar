using System;
namespace SkiaCalendar.Sources.Settings
{
    public class CalendarRules
    {
        public DateTime? MinSelectableDate { get; }
        public DateTime? MaxSelectableDate { get; }

        public CalendarRules(DateTime? minSelectableDate, DateTime? maxSelectableDate)
        {
            MinSelectableDate = minSelectableDate;
            MaxSelectableDate = maxSelectableDate;
        }

        public bool IsDayInWeekEnd(DateTime day)
        {
            return day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday;
        }

        public bool IsDayIsInsideOfSelectedMonth(DateTime day, DateTime month)
            => !IsDayOutsideOfSelectedMonth(day, month);

        public bool IsDayOutOfSelectableRange(DateTime day)
            => (MinSelectableDate.HasValue && day.Date < MinSelectableDate.Value) ||
               (MaxSelectableDate.HasValue && day.Date > MaxSelectableDate.Value);

        public bool IsDaySelectable(DateTime day, DateTime currentMonth)
            => !IsDayOutOfSelectableRange(day) &&
               !IsDayOutsideOfSelectedMonth(day, currentMonth);

        private bool IsDayOutsideOfSelectedMonth(DateTime day, DateTime month)
            => day.Month != month.Month || day.Year != month.Year;
    }
}
