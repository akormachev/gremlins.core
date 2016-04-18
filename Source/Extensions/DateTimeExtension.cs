namespace System
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets first day of month
        /// </summary>
        /// <param name="date">Date which specifies month</param>
        /// <returns>Date of first day of month</returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Gets first day of week
        /// </summary>
        /// <param name="date">Date which specifies week</param>
        /// <param name="startOfWeek">DayOfWeek opens week</param>
        /// <returns>Date of first day of week</returns>
        public static DateTime GetFirstDayOfWeek(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = date.DayOfWeek - startOfWeek;

            if (diff < 0)
                diff += 7;

            return date.AddDays(-1 * diff).Date;
        }
    }
}
