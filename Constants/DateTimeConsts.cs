namespace MyUtils.Constants
{
    /// <summary>
    /// A static class containing constants and properties related to DateTime values, such as the current date and time in both local and UTC formats.
    /// </summary>
    public static class DateTimeConsts
    {
        /// <summary>
        /// Gets the current local date and time.
        /// </summary>
        public static DateTime CurrentDate => DateTime.Now;

        /// <summary>
        /// Gets the current date and time in Coordinated Universal Time (UTC).
        /// </summary>
        public static DateTime CurrentUtcDate => DateTime.UtcNow;

        /// <summary>
        /// Gets the current local date and time as a DateTimeOffset, which includes the offset from UTC.
        /// </summary>
        public static DateTimeOffset CurrentDateOffset => DateTimeOffset.Now;

        /// <summary>
        /// Gets the current date and time in Coordinated Universal Time (UTC) as a DateTimeOffset, which includes the offset from UTC (which will be zero for UTC time).
        /// </summary>
        public static DateTimeOffset CurrentUtcDateOffset => DateTimeOffset.UtcNow;
    }
}
