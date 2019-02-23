using System;
namespace SkiaCalendar.Sources.Calendar
{
    public class MonthSelectionState
    {
        public bool CanGoBack { get; set; }
        public bool CanGoForward { get; set; }
        public string MonthName { get; set; }
    }
}
