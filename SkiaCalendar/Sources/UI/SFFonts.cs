using System;
using Foundation;
using SkiaSharp;
using UIKit;

namespace SkiaCalendar.Sources.UI
{
    public static class SFFonts
    {
        public static SKTypeface SFBold()
        {
            var customFontPath = NSBundle.MainBundle.PathForResource("SanFranciscoDisplay-Bold", ".otf", "Fonts");
            return SKTypeface.FromFile(customFontPath);
        }

        public static SKTypeface SFSemibold()
        {
            var customFontPath = NSBundle.MainBundle.PathForResource("SanFranciscoDisplay-Semibold", ".otf", "Fonts");
            return SKTypeface.FromFile(customFontPath);
        }

        public static SKTypeface SFMedium()
        {
            var customFontPath = NSBundle.MainBundle.PathForResource("SanFranciscoDisplay-Medium", ".otf", "Fonts");
            return SKTypeface.FromFile(customFontPath);
        }

        public static SKTypeface SFRegular()
        {
            var customFontPath = NSBundle.MainBundle.PathForResource("SanFranciscoDisplay-Regular", ".otf", "Fonts");
            return SKTypeface.FromFile(customFontPath);
        }

        public static SKTypeface SFLight()
        {
            var customFontPath = NSBundle.MainBundle.PathForResource("SanFranciscoDisplay-Light", ".otf", "Fonts");
            return SKTypeface.FromFile(customFontPath);
        }

        public static SKTypeface SFUltralight()
        {
            var customFontPath = NSBundle.MainBundle.PathForResource("SanFranciscoDisplay-Ultralight", ".otf", "Fonts");
            return SKTypeface.FromFile(customFontPath);
        }

        public static SKTypeface SFThin()
        {
            var customFontPath = NSBundle.MainBundle.PathForResource("SanFranciscoDisplay-Thin", ".otf", "Fonts");
            return SKTypeface.FromFile(customFontPath);
        }

        public static UIFont UISFMedium()
        {
            var customFontPath = NSBundle.MainBundle.PathForResource("SanFranciscoDisplay-Medium", ".otf", "Fonts");
            return UIFont.FromName("SanFranciscoDisplay-Medium", 18);
        }
    }
}
