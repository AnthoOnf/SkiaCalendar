using System;
using SkiaCalendar.Sources.Calendar;
using SkiaCalendar.Sources.Extensions;
using SkiaCalendar.Sources.Settings;
using SkiaCalendar.Sources.UI;
using UIKit;

namespace SkiaCalendar
{
    public partial class ViewController : UIViewController
    {
        private CalendarView _calendarView;
        CalendarSettings settings;

        protected ViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Localize localize = new Localize();

            TimeSpan TimeTillLastPossibleDate = TimeSpan.FromDays(365);
            var minDate = DateTime.Today;
            var maxDate = DateTime.Today.Add(TimeTillLastPossibleDate);

            CalendarRules CalendarRules = new CalendarRules(minDate, maxDate);

            settings = new CalendarSettings(localize, CalendarRules, minDate);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _calendarView = CalendarView.Create(settings);
            this.CalendarContentView.AddSubview(_calendarView);
            _calendarView.FillParent();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            AdjustCalendarView();
        }

        private void AdjustCalendarView()
        {
            nfloat availableHeight;
            availableHeight = this.CalendarContentView.Frame.Width; // will be drawn as a square based on width
            nfloat definedHeight = (availableHeight / CalendarDrawer.DAYS_PER_WEEK) * CalendarDrawer.MAX_DISPLAYED_WEEKS;

            _calendarView.ResizeAndLayoutIfNeeded(definedHeight);
        }
    }
}
