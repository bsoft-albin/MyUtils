namespace MyUtils.Constants;

/// <summary>
/// Common string/text/number/decimal constants.
/// </summary>
public static class AppConstants
{
    /// <summary>
    /// Default date/time format string for consistent parsing and formatting across the application. Format: "dd-MM-yyyy HH:mm" (e.g., "31-12-2024 23:59"). This format is chosen for its clarity and unambiguity, ensuring that dates are easily understood regardless of locale settings. It can be used in logging, user interfaces, and anywhere else date/time values need to be displayed or parsed in a consistent manner.
    /// </summary>
    public const string DefaultDateTimeFormat = "dd-MM-yyyy HH:mm";

    /// <summary>
    /// Default culture code for the application, used for localization and formatting. Set to "en-IN" (English - India) to ensure that date, time, number, and currency formats are consistent with Indian conventions. This is particularly important for applications targeting users in India, as it ensures that the user experience is tailored to their expectations and cultural norms. The default currency is set to "INR" (Indian Rupee) and the default time zone is set to "Asia/Kolkata" to further align with Indian standards.
    /// </summary>
    public const string DefaultCulture = "en-IN";

    /// <summary>
    /// Default currency code for the application, set to "INR" (Indian Rupee). This constant can be used throughout the application wherever currency formatting or display is needed, ensuring consistency in how monetary values are represented. By defining it as a constant, it also allows for easy updates in the future if there is a need to change the default currency for any reason.
    /// </summary>
    public const string DefaultCurrency = "INR";

    /// <summary>
    /// Default time zone identifier for the application, set to "Asia/Kolkata". This constant can be used to ensure that all date and time operations within the application are performed in the context of the Indian Standard Time (IST) zone. This is particularly important for applications that are primarily used by users in India, as it ensures that all timestamps, scheduling, and time-based calculations are accurate and relevant to their local time. By centralizing this value as a constant, it also allows for easy updates in the future if there is a need to change the default time zone.
    /// </summary>
    public const string DefaultTimeZone = "Asia/Kolkata";

    /// <summary>
    /// Default page size for pagination in API responses. This constant can be used to standardize the number of items returned in paginated responses across the application, ensuring a consistent user experience. Setting a default page size helps to prevent overwhelming users with too much data at once while also providing a reasonable amount of information per page. The maximum page size is set to 100 to prevent excessive data retrieval that could impact performance. These constants can be used in API controllers and services that implement pagination logic, allowing for easy adjustments to the default and maximum page sizes as needed in the future.
    /// </summary>
    public const int DefaultPageSize = 10;

    /// <summary>
    /// Maximum allowed page size for pagination in API responses. This constant is used to enforce a limit on the number of items that can be returned in a single paginated response, preventing excessive data retrieval that could lead to performance issues. By setting a maximum page size of 100, the application can ensure that it remains responsive and efficient even when handling large datasets. This constant can be referenced in pagination logic within API controllers and services to validate incoming page size parameters and enforce the defined limits consistently across the application.
    /// </summary>
    public const int MaxPageSize = 100;

    /// <summary>
    /// Expiry time for OTP (One-Time Password) codes in minutes. This constant can be used to define how long an OTP code remains valid after it has been generated. Setting a default expiry time of 5 minutes helps to enhance security by ensuring that OTP codes cannot be used indefinitely, reducing the risk of unauthorized access. This constant can be referenced in OTP generation and validation logic to enforce the defined expiry time consistently across the application.
    /// </summary>
    public const int OtpExpiryMinutes = 5;

    /// <summary>
    /// Maximum number of allowed attempts to verify an OTP code before it becomes invalid. This constant can be used to enhance security by limiting the number of times a user can attempt to enter an OTP code, reducing the risk of brute-force attacks. Setting a maximum of 3 attempts helps to balance security with user experience, allowing for a reasonable number of retries while still protecting against unauthorized access. This constant can be referenced in OTP validation logic to enforce the defined attempt limit consistently across the application.
    /// </summary>
    public const int JwtExpiryMinutes = 60;

    /// <summary>
    /// Expiry time for refresh tokens in days. This constant can be used to define how long a refresh token remains valid after it has been issued. Setting a default expiry time of 7 days allows users to maintain their authenticated sessions without needing to log in frequently, while still ensuring that refresh tokens do not remain valid indefinitely, which could pose security risks. This constant can be referenced in token generation and validation logic to enforce the defined expiry time consistently across the application.
    /// </summary>
    public const int RefreshTokenExpiryDays = 7;

    /// <summary>
    /// Authentication scheme name for JWT bearer tokens. This constant can be used to standardize the authentication scheme used across the application when implementing JWT-based authentication. By defining it as a constant, it ensures that all references to the authentication scheme are consistent and can be easily updated in the future if needed. This constant is typically used in authentication configuration and middleware setup to specify that the application should use JWT bearer tokens for authentication.
    /// </summary>
    public const string BearerScheme = "Bearer";
}
