using System;
using System.Diagnostics;
using Foundation;
using SkiaCalendar.Sources.Settings;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using UIKit;

namespace SkiaCalendar.Sources.Drawing
{
    public class SkiaPressGestureRecognizer : UITapGestureRecognizer
    {
        private readonly SKCanvasView _view;
        private readonly Action<SKTouchEventArgs> _onTouchAction;
        private readonly CalendarSettings _calendarSettings;

        public SkiaPressGestureRecognizer(SKCanvasView view,
                                          Action<SKTouchEventArgs> onTouchAction,
                                          CalendarSettings calendarSettings)
        {
            _view = view;
            _onTouchAction = onTouchAction;
            _calendarSettings = calendarSettings;
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            UITouch t = touches.AnyObject as UITouch;

            var point = t.LocationInView(_view);

            Debug.WriteLine("SkiaPressGestureRecognizer" + point);

            _onTouchAction(new SKTouchEventArgs(0, SKTouchAction.Moved, // todo : check for type
                new SKPoint(
                    (float)point.X * _calendarSettings.ScaleFactor,
                    (float)point.Y * _calendarSettings.ScaleFactor
                ), true));
        }
    }
}
