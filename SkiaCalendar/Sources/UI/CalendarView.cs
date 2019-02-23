using System;
using Foundation;
using ObjCRuntime;
using SkiaCalendar.Sources.Calendar;
using SkiaCalendar.Sources.Drawing;
using SkiaCalendar.Sources.Settings;
using SkiaSharp.Views.iOS;
using UIKit;

namespace SkiaCalendar.Sources.UI
{
    public partial class CalendarView : UIView
    {
        private SKCanvasView _calendarGridView;
        private CalendarDrawer _calendarDrawer;
        private CalendarSettings _calendarSettings;

        public CalendarView()
        {
        }

        public CalendarView(IntPtr handle) : base(handle)
        {
        }

        public static CalendarView Create(CalendarSettings calendarSettings)
        {
            CalendarView calendarView = Runtime.GetNSObject(NSBundle.MainBundle.LoadNib("CalendarView", null, null).ValueAt(0)) as CalendarView;

            calendarView._calendarSettings = calendarSettings;
            calendarView._calendarGridView = new SKCanvasView();
            calendarView._calendarDrawer = new CalendarDrawer(calendarSettings, calendarView._calendarGridView.SetNeedsDisplay, calendarView.OnMonthChanged, calendarView._calendarSettings.BackgroundCellColor);

            calendarView.CalendarGridWrapperView.AddSubview(calendarView._calendarGridView);
            calendarView._calendarGridView.PaintSurface += calendarView.OnPaintSurface;
            calendarView._calendarGridView.SetNeedsDisplay();
            calendarView._calendarGridView.AddGestureRecognizer(new SkiaPressGestureRecognizer(calendarView._calendarGridView, calendarView.OnSliderTouchOrMove, calendarSettings));

            calendarView.NextButton.TouchUpInside += calendarView.OnNextButtonPressed;
            calendarView.PrevButton.TouchUpInside += calendarView.OnPrevButtonPressed;

            calendarView.MonthName.Font = SFFonts.UISFMedium();

            return calendarView;
        }

        public void ResizeAndLayoutIfNeeded(nfloat newHeight)
        {
            CalendarGridWrapperViewHeight.Constant = newHeight /*- CalendarMonthSelector.Frame.Height*/;

            LayoutIfNeeded();

            _calendarGridView.Frame = CalendarGridWrapperView.Bounds;
        }

        public void AdjustCalendarView()
        {
            nfloat availableHeight = Superview.Frame.Width;
            nfloat definedHeight = (availableHeight / CalendarDrawer.DAYS_PER_WEEK) * CalendarDrawer.MAX_DISPLAYED_WEEKS;

            ResizeAndLayoutIfNeeded(definedHeight);
        }

        private void OnMonthChanged(MonthSelectionState obj)
        {
            MonthName.Text = obj.MonthName;
            PrevButton.Enabled = PrevButton.UserInteractionEnabled = obj.CanGoBack;
            NextButton.Enabled = NextButton.UserInteractionEnabled = obj.CanGoForward;
        }

        void OnNextButtonPressed(object sender, EventArgs e)
        {
            _calendarDrawer.ChangeMonth(1);
        }

        void OnPrevButtonPressed(object sender, EventArgs e)
        {
            _calendarDrawer.ChangeMonth(-1);
        }

        void OnSliderTouchOrMove(SKTouchEventArgs sk)
        => _calendarDrawer.OnPressGesture(sk);

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
            => _calendarDrawer.Paint(e.Surface, e.Info);
    }
}
