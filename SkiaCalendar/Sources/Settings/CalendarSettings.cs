using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace SkiaCalendar.Sources.Settings
{
    public class CalendarSettings
    {
        public CultureInfo Culture { get; set; } = new CultureInfo("en");
        public string DateMonthFormat { get; set; } = "MMMMM yyyy";

        public UIColor BackgroundCellColor => UIColor.FromRGB(44, 50, 80);

        public CalendarRules CalendarRules { get; set; }

        public DateTime SelectedDate { get; set; } = DateTime.Today;

        public Action<DateTime> OnDate;

        public DateTime MinDate { get; }
        public DateTime MaxDate { get; }

        public int ScaleFactor => (int)UIScreen.MainScreen.Scale;

        public CalendarSettings(DateTime minSelectableDate,
                                DateTime maxSelectableDate,
                                DateTime? selectedDate = null,
                                Action<DateTime> onDateSelected = null)
        {
            MinDate = minSelectableDate;
            MaxDate = maxSelectableDate;
            CalendarRules = new CalendarRules(MinDate, MaxDate);

            if (selectedDate != null)
                SelectedDate = selectedDate.Value;

            OnDate = onDateSelected;
        }

        public async Task OnDateSelected(DateTime selected)
        {
            SelectedDate = selected;
            OnDate?.Invoke(selected);
        }
    }
}
