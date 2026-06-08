namespace MyUtils.Configuration;

/// <summary>
/// JWT configuration settings — bind from appsettings.json section "JwtSettings".
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Name of the configuration section in appsettings.json to bind to this class.
    /// </summary>
    public const string SectionName = "JwtSettings";

    /// <summary>Secret key for signing tokens. Must be at least 32 characters.</summary>
    public string SecretKey { get; set; } = string.Empty;

    /// <summary>Token issuer (e.g. your app name or domain).</summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>Token audience (e.g. your app name or API).</summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>Access token expiry in minutes (default: 60).</summary>
    public int ExpiryMinutes { get; set; } = 60;

    /// <summary>Refresh token expiry in days (default: 7).</summary>
    public int RefreshTokenExpiryDays { get; set; } = 7;
}
