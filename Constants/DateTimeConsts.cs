namespace MyUtils.Constants
{
    /// <summary>
    /// A static class containing constants and properties related to DateTime values, such as the current date and time in both local and UTC formats.
    /// </summary>
    public static class DateTimeConsts
    {
        public static DateTime CurrentDate => DateTime.Now;
        public static DateTime CurrentUtcDate => DateTime.UtcNow;
        public static DateTimeOffset CurrentDateOffset => DateTimeOffset.Now;
        public static DateTimeOffset CurrentUtcDateOffset => DateTimeOffset.UtcNow;
    }
}
