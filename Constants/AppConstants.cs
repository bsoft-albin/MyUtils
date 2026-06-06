namespace MyUtils.Constants;

/// <summary>
/// Common string/text constants.
/// </summary>
public static class AppConstants
{
    public const string DefaultDateTimeFormat = "dd-MM-yyyy HH:mm";
    public const string DefaultCulture = "en-IN";
    public const string DefaultCurrency = "INR";
    public const string DefaultTimeZone = "Asia/Kolkata";
    public const int DefaultPageSize = 10;
    public const int MaxPageSize = 100;
    public const int OtpExpiryMinutes = 5;
    public const int JwtExpiryMinutes = 60;
    public const int RefreshTokenExpiryDays = 7;
    public const string BearerScheme = "Bearer";
}
