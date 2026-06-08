namespace MyUtils.Helpers;

/// <summary>
/// Static helper methods for DateTime operations.
/// </summary>
public static class DateHelper
{
    private static readonly TimeZoneInfo IstZone = TimeZoneInfo.FindSystemTimeZoneById(OperatingSystem.IsWindows() ? "India Standard Time" : "Asia/Kolkata");

    /// <summary>Returns current IST (India Standard Time) DateTime.</summary>
    public static DateTime NowIST() => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, IstZone);

    /// <summary>Converts a UTC DateTime to IST.</summary>
    /// <param name="utcDateTime">The UTC DateTime to convert.</param>
    /// <returns>The corresponding IST DateTime.</returns>
    public static DateTime ToIST(DateTime utcDateTime) => TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc), IstZone);

    /// <summary>Converts IST DateTime to UTC.</summary>
    /// <param name="istDateTime">The IST DateTime to convert.</param>
    /// <returns>The corresponding UTC DateTime.</returns>
    public static DateTime ISTToUtc(DateTime istDateTime) => TimeZoneInfo.ConvertTimeToUtc(istDateTime, IstZone);

    /// <summary>Calculates the age in years from a birth date.</summary>
    public static int CalculateAge(DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }

    /// <summary>Returns a human-readable relative time string. E.g. "3 days ago", "just now"</summary>
    public static string TimeAgo(DateTime dateTime)
    {
        TimeSpan span = DateTime.UtcNow - dateTime.ToUniversalTime();
        return span.TotalSeconds switch
        {
            < 60 => "just now",
            < 3600 => $"{(int)span.TotalMinutes} minute{Plural((int)span.TotalMinutes)} ago",
            < 86400 => $"{(int)span.TotalHours} hour{Plural((int)span.TotalHours)} ago",
            < 2592000 => $"{(int)span.TotalDays} day{Plural((int)span.TotalDays)} ago",
            < 31536000 => $"{(int)(span.TotalDays / 30)} month{Plural((int)(span.TotalDays / 30))} ago",
            _ => $"{(int)(span.TotalDays / 365)} year{Plural((int)(span.TotalDays / 365))} ago"
        };
    }

    /// <summary>Checks if a given date is a weekend (Saturday or Sunday).</summary>
    public static bool IsWeekend(DateTime date) => date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;

    /// <summary>Checks if a given date is a weekday.</summary>
    public static bool IsWeekday(DateTime date) => !IsWeekend(date);

    /// <summary>Returns the start of the day (00:00:00) for a given date.</summary>
    public static DateTime StartOfDay(DateTime date) => date.Date;

    /// <summary>Returns the end of the day (23:59:59.999) for a given date.</summary>
    public static DateTime EndOfDay(DateTime date) => date.Date.AddDays(1).AddTicks(-1);

    /// <summary>Returns the first day of the month for a given date.</summary>
    public static DateTime StartOfMonth(DateTime date) => new(date.Year, date.Month, 1);

    /// <summary>Returns the last day of the month for a given date.</summary>
    public static DateTime EndOfMonth(DateTime date) => new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);

    /// <summary>Returns the number of business days between two dates (Mon–Fri).</summary>
    public static int BusinessDaysBetween(DateTime start, DateTime end)
    {
        if (start > end)
        {
            (start, end) = (end, start);
        }

        int days = 0;
        for (DateTime d = start; d <= end; d = d.AddDays(1))
        {
            if (IsWeekday(d))
            {
                days++;
            }
        }

        return days;
    }

    /// <summary>Formats a DateTime to a friendly display string. E.g. "25 Jun 2025, 10:30 AM"</summary>
    public static string ToFriendlyString(DateTime date) => date.ToString("dd MMM yyyy, hh:mm tt");

    /// <summary>Returns the quarter (1–4) for a given date.</summary>
    public static int GetQuarter(DateTime date) => (date.Month - 1) / 3 + 1;

    /// <summary>Checks if a year is a leap year.</summary>
    public static bool IsLeapYear(int year) => DateTime.IsLeapYear(year);

    private static string Plural(int count) => count == 1 ? "" : "s";
}
