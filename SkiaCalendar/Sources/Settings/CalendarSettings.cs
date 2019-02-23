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
        public UIColor BackgroundCellColor => UIColor.FromRGB(44, 50, 80);

        public CalendarRules CalendarRules { get; set; }
        public Localize Localize;

        public DateTime SelectedDate { get; set; }
        public string DateFormat => "MMMMM yyyy";

        public Action<DateTime> OnDate;
        public event Action<DateTime> DateSelected;


        public CultureInfo CurrentCultureInfo() => Localize.GetCurrentCultureInfo();

        public string MondayText => "Monday";
        public string TuesdayText => "Tuesday";
        public string WednesdayText => "Wednesday";
        public string ThursdayText => "Thursday";
        public string FridayText => "Friday";
        public string SaturdayText => "Saturday";
        public string SundayText => "Sunday";

        public DateTime MinDate { get; }
        public DateTime MaxDate { get; }
        public DateTime MinMonth => new DateTime(MinDate.Year, MinDate.Month, 1);
        public DateTime MaxMonth => new DateTime(MaxDate.Year, MaxDate.Month, 1);

        public CalendarSettings(Localize localize,
                                CalendarRules calendarRules = null,
                                DateTime selectedDate = new DateTime(),
                                Action<DateTime> onDateSelected = null)
        {
            Localize = localize;
            if (calendarRules != null)
                CalendarRules = calendarRules;
            SelectedDate = selectedDate;
            OnDate = onDateSelected;
        }

        public async Task OnDateSelected(DateTime selected)
        {
            SelectedDate = selected;
            OnDate?.Invoke(selected);
        }
    }
}
