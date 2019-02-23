using System;
using System.Globalization;

namespace SkiaCalendar.Sources.Extensions
{
    public static class DateTimeExtensions
    {
        public static readonly GregorianCalendar Calendar = new GregorianCalendar();

        public static int GetDayPositionInWeek(this DateTime time)
            => (((int)time.DayOfWeek) + 6) % 7; //TODO : depends on the culture ?

        public static int GetWeekOfMonth(this DateTime time, DateTime first)
            => time.GetWeekOfYear() - first.GetWeekOfYear();

        static int GetWeekOfYear(this DateTime time)
            => Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

        public static DateTime GetFirstDayOfMonth(this DateTime time)
            => new DateTime(time.Year, time.Month, 1);

        public static bool IsSameMonthAndYear(this DateTime src, DateTime dest)
            => src.Month == dest.Month && src.Year == dest.Year;

        public static bool IsSameDate(this DateTime src, DateTime dest)
            => src.Day == dest.Day &&
               src.Month == dest.Month &&
               src.Year == dest.Year;
    }
}
