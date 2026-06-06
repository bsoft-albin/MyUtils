using MyUtils.Helpers;

namespace MyUtils.Extensions;

/// <summary>
/// Extension methods for <see cref="DateTime"/>.
/// </summary>
public static class DateTimeExtensions
{
    /// <inheritdoc cref="DateHelper.ToIST"/>
    public static DateTime ToIST(this DateTime utcDateTime) => DateHelper.ToIST(utcDateTime);

    /// <inheritdoc cref="DateHelper.ISTToUtc"/>
    public static DateTime ToUtcFromIST(this DateTime istDateTime) => DateHelper.ISTToUtc(istDateTime);

    /// <inheritdoc cref="DateHelper.CalculateAge"/>
    public static int CalculateAge(this DateTime birthDate) => DateHelper.CalculateAge(birthDate);

    /// <inheritdoc cref="DateHelper.TimeAgo"/>
    public static string TimeAgo(this DateTime dateTime) => DateHelper.TimeAgo(dateTime);

    /// <inheritdoc cref="DateHelper.IsWeekend"/>
    public static bool IsWeekend(this DateTime date) => DateHelper.IsWeekend(date);

    /// <inheritdoc cref="DateHelper.IsWeekday"/>
    public static bool IsWeekday(this DateTime date) => DateHelper.IsWeekday(date);

    /// <inheritdoc cref="DateHelper.StartOfDay"/>
    public static DateTime StartOfDay(this DateTime date) => DateHelper.StartOfDay(date);

    /// <inheritdoc cref="DateHelper.EndOfDay"/>
    public static DateTime EndOfDay(this DateTime date) => DateHelper.EndOfDay(date);

    /// <inheritdoc cref="DateHelper.StartOfMonth"/>
    public static DateTime StartOfMonth(this DateTime date) => DateHelper.StartOfMonth(date);

    /// <inheritdoc cref="DateHelper.EndOfMonth"/>
    public static DateTime EndOfMonth(this DateTime date) => DateHelper.EndOfMonth(date);

    /// <inheritdoc cref="DateHelper.GetQuarter"/>
    public static int GetQuarter(this DateTime date) => DateHelper.GetQuarter(date);

    /// <inheritdoc cref="DateHelper.ToFriendlyString"/>
    public static string ToFriendlyString(this DateTime date) => DateHelper.ToFriendlyString(date);

    /// <summary>Returns true if the date is in the past.</summary>
    public static bool IsInPast(this DateTime date) => date < DateTime.UtcNow;

    /// <summary>Returns true if the date is in the future.</summary>
    public static bool IsInFuture(this DateTime date) => date > DateTime.UtcNow;

    /// <summary>Returns true if the date is today.</summary>
    public static bool IsToday(this DateTime date) => date.Date == DateTime.Today;

    /// <summary>Returns a Unix timestamp (seconds since epoch) for the DateTime.</summary>
    public static long ToUnixTimestamp(this DateTime date) =>
        (long)(date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

    /// <summary>Converts a Unix timestamp to a DateTime.</summary>
    public static DateTime FromUnixTimestamp(this long timestamp) =>
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
}
