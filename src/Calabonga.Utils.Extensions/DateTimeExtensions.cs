using System;
using System.Collections.Generic;
using System.Text;

namespace Calabonga.Utils.Extensions
{
    /// <summary>
    /// DateTime extensions
    /// </summary>
    public static class DateTimeExtensions
    {
        private static readonly Dictionary<string, string> _dictionaryEn = new Dictionary<string, string>
        {
            { "Year", "y" },
            { "Week", "w" },
            { "Day", "d" },
            { "Hour", "h" },
            { "Minute", "m" },
            { "Second", "s" }
        };
        private static readonly Dictionary<string, string> _dictionaryRu = new Dictionary<string, string>
        {
            { "Year", "г" },
            { "Week", "н" },
            { "Day", "д" },
            { "Hour", "ч" },
            { "Minute", "м" },
            { "Second", "с" }
        };

        public static string ToJiraString(this TimeSpan source,
            Spacing spacing = Spacing.Space,
            CultureName cultureName = CultureName.En)
        {
            var stringBuilder = new StringBuilder();
            var dictionary = cultureName switch
            {
                CultureName.En => _dictionaryEn,
                CultureName.Ru => _dictionaryRu,
                _ => throw new ArgumentOutOfRangeException(nameof(cultureName), cultureName, null)
            };

            var space = spacing switch
            {
                Spacing.Space => " ",
                Spacing.Underscore => "_",
                Spacing.Dashed => "-",
                Spacing.NoSpace => "",
                _ => throw new ArgumentOutOfRangeException(nameof(spacing), spacing, null)
            };

            if (source.Days > 7)
            {
                stringBuilder.Append($"{source.Days / 7}{dictionary["Week"]}{space}");
                stringBuilder.Append($"{source.Days % 7}{dictionary["Day"]}{space}");
            }
            else if (source.Days == 7)
            {
                stringBuilder.Append($"1{dictionary["Week"]}{space}");
            }
            else if (source.Days > 0)
            {
                stringBuilder.Append($"{source.Days}{dictionary["Day"]}{space}");
            }

            if (source.Hours > 0)
            {
                stringBuilder.Append($"{source.Hours}{dictionary["Hour"]}{space}");
            }

            if (source.Minutes > 0)
            {
                stringBuilder.Append($"{source.Minutes}{dictionary["Minute"]}{space}");
            }

            if (source.Seconds > 0)
            {
                stringBuilder.Append($"{source.Seconds}{dictionary["Second"]}{space}");
            }

            return stringBuilder.ToString().TrimEnd('_', ' ', '-');
        }

        public static string ToJiraString(this DateTime source, DateTime? today)
        {
            var now = today ?? DateTime.UtcNow;
            var delta = now - source;

            return ToJiraString(delta);
        }

        /// <summary>
        /// Returns start date for selected month
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetMonthStartDay(this DateTime? date)
        {
            var currentDate = date ?? DateTime.Today;
            return new DateTime(currentDate.Year, currentDate.Month, 1);
        }

        /// <summary>
        /// Returns start date for selected month
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetMonthStartDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Returns end date for selected month
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetMonthEndDay(this DateTime? date)
        {
            var currentDate = date ?? DateTime.Today;
            return new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));
        }
        /// <summary>
        /// Returns end date for selected month
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetMonthEndDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        /// <summary>
        /// Returns start day of the week
        /// </summary>
        /// <param name="firstDayOfWeek"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetWeekStartDay(this DateTime? date, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            var currentDate = date ?? DateTime.Today;
            var diff = (int)currentDate.DayOfWeek - (int)firstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            var calculatedDate = currentDate.AddDays(-1 * diff).Date;
            return calculatedDate;
        }

        /// <summary>
        /// Returns start day of the week
        /// </summary>
        /// <param name="firstDayOfWeek"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetWeekStartDay(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            var diff = (int)date.DayOfWeek - (int)firstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            var calculatedDate = date.AddDays(-1 * diff).Date;
            return calculatedDate;
        }

        /// <summary>
        /// Returns end day of the week
        /// </summary>
        /// <param name="firstDayOfWeek"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetWeekEndDay(this DateTime? date, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            return GetWeekStartDay(date, firstDayOfWeek).AddDays(6);
        }

        /// <summary>
        /// Returns end day of the week
        /// </summary>
        /// <param name="firstDayOfWeek"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetWeekEndDay(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            return GetWeekStartDay(date, firstDayOfWeek).AddDays(6);
        }
    }

    public enum Spacing
    {
        Space,
        Underscore,
        Dashed,
        NoSpace
    }

    public enum CultureName
    {
        En,
        Ru
    }
}
