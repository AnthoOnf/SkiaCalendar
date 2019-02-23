using System;
using System.Globalization;
using SkiaCalendar.Sources.Extensions;
using SkiaCalendar.Sources.Settings;
using SkiaCalendar.Sources.UI;
using UIKit;

namespace SkiaCalendar
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CalendarSettings settings = new CalendarSettings(DateTime.Today, DateTime.Today.Add(TimeSpan.FromDays(365)))
            {
                Culture = new CultureInfo("fr"),
                DateMonthFormat = "MMMM yyyy"
            };

            CalendarView calendarView = CalendarView.Create(settings);
            this.CalendarContentView.AddSubview(calendarView);
            calendarView.FillParent();
            calendarView.AdjustCalendarView();
        }
    }
}
