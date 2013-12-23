using System;

namespace Omnimedia.Core.Extensions
{
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Text display of a timespan.
        /// </summary>
        /// <param name="ts">The timespan.</param>
        /// <returns></returns>
        public static string ToStringDisplay(this TimeSpan timeSpan)
        {
            double delta = Math.Abs(timeSpan.TotalSeconds);

            if (delta < 60)
                return timeSpan.Seconds <= 1 ? "une seconde" : String.Format("{0} secondes", timeSpan.Seconds);
            if (delta < 120)
                return "une minute";
            if (delta < 2700)
                return String.Format("{0} minutes", timeSpan.Minutes);
            if (delta < 5400)
                return "une heure";
            if (delta < 86400)
                return String.Format("{0} heures", timeSpan.Hours);
            if (delta < 172800)
                return "un jour";

            return String.Format("{0} jours", timeSpan.Days);
        }
    }
}