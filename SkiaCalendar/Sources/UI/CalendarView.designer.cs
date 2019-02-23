// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SkiaCalendar.Sources.UI
{
    [Register("CalendarView")]
    partial class CalendarView
    {
        [Outlet]
        UIKit.UIView CalendarGridWrapperView { get; set; }

        [Outlet]
        UIKit.NSLayoutConstraint CalendarGridWrapperViewHeight { get; set; }

        [Outlet]
        UIKit.UILabel MonthName { get; set; }

        [Outlet]
        UIKit.UIButton NextButton { get; set; }

        [Outlet]
        UIKit.UIButton PrevButton { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (CalendarGridWrapperView != null)
            {
                CalendarGridWrapperView.Dispose();
                CalendarGridWrapperView = null;
            }

            if (CalendarGridWrapperViewHeight != null)
            {
                CalendarGridWrapperViewHeight.Dispose();
                CalendarGridWrapperViewHeight = null;
            }

            if (PrevButton != null)
            {
                PrevButton.Dispose();
                PrevButton = null;
            }

            if (NextButton != null)
            {
                NextButton.Dispose();
                NextButton = null;
            }

            if (MonthName != null)
            {
                MonthName.Dispose();
                MonthName = null;
            }
        }
    }
}
