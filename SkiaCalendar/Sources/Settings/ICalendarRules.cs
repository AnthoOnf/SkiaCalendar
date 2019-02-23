using System;
namespace SkiaCalendar.Sources.Settings
{
    public interface ICalendarRules
    {
        DateTime? MinSelectableDate { get; }
        DateTime? MaxSelectableDate { get; }
        bool IsDaySelectable(DateTime day, DateTime currentMonth);
        bool IsDayOutOfSelectableRange(DateTime day);
        bool IsDayInWeekEnd(DateTime day);
    }
}
