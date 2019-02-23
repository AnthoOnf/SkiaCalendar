using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Foundation;

namespace SkiaCalendar.Sources.Settings
{
    public class Localize
    {
        public string GetCurrentCultureInfoString()
        {
            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref.Replace("_", "-"); // turns pt_BR into pt-BR
            }
            return netLanguage;
        }

        private string GetLocalLang() => GetCurrentCultureInfoString().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[0];

        public void UpdateNativeLanguage(string language)
        {
            var cultureInfo = new CultureInfo("en");

            try
            {
                cultureInfo = new CultureInfo(language);
            }
            catch
            {
                Debug.WriteLine($"ERRRRROOOORRR ! UpdateNativeLanguage {language}");
            }

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            NSUserDefaults.StandardUserDefaults.SetValueForKey(NSArray.FromStrings(language), new NSString("AppleLanguages"));
            NSUserDefaults.StandardUserDefaults.Synchronize();
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            CultureInfo result = new CultureInfo("en");
            var lang = GetLocalLang();

            try
            {
                result = new CultureInfo(lang);
            }
            catch { Debug.WriteLine($"Error ! BaseLocalize.UpdateNativeLanguage {lang} not found. Set 'en' by default"); }

            return result;
        }

        public virtual Dictionary<string, string> Langs { get; } = new Dictionary<string, string>
        {
            ["fr"] = "Français",
            ["en"] = "English",
            ["de"] = "Deutsch",
            ["nl"] = "Nederlands"
        };
    }
}
