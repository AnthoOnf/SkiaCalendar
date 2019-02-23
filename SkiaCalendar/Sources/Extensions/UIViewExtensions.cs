using System;
using UIKit;

namespace SkiaCalendar.Sources.Extensions
{
    public static class UIViewExtensions
    {
        public static void FillParent(this UIView childView)
        {
            EnsureTranslateAutoResizing(childView);

            childView.Superview.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[childView]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, "childView", childView));
            childView.Superview.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[childView]|", NSLayoutFormatOptions.DirectionLeadingToTrailing, "childView", childView));
        }

        public static void EnsureTranslateAutoResizing(UIView view)
        {
            if (view != null && view.TranslatesAutoresizingMaskIntoConstraints)
                view.TranslatesAutoresizingMaskIntoConstraints = false;
        }
    }
}
