using System;
using System.Diagnostics;
using Foundation;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using UIKit;

namespace SkiaCalendar.Sources.Drawing
{
    public class SkiaPressGestureRecognizer : UITapGestureRecognizer
    {
        private readonly SKCanvasView _view;
        private readonly Action<SKTouchEventArgs> _onTouchAction;

        public SkiaPressGestureRecognizer(SKCanvasView view, Action<SKTouchEventArgs> onTouchAction)
        {
            _view = view;
            _onTouchAction = onTouchAction;
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            UITouch t = touches.AnyObject as UITouch;

            var point = t.LocationInView(_view);

            Debug.WriteLine("SkiaPressGestureRecognizer" + point);

            _onTouchAction(new SKTouchEventArgs(0, SKTouchAction.Moved, // todo : check for type
                new SKPoint(
                    (float)point.X * (float)UIScreen.MainScreen.Scale,
                    (float)point.Y * (float)UIScreen.MainScreen.Scale
                ), true));
        }
    }
}
