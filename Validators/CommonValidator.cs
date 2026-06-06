using System.Text.RegularExpressions;

namespace MyUtils.Validators;

/// <summary>
/// Common data validation methods — email, phone, URL, Aadhaar, PAN, GST, and more.
/// </summary>
public static partial class CommonValidator
{
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase)]
    private static partial Regex EmailRegex();

    [GeneratedRegex(@"[\s\-\+]")]
    private static partial Regex PhoneCleanupRegex();

    [GeneratedRegex(@"^[6-9]\d{9}$", RegexOptions.IgnoreCase)]
    private static partial Regex IndianMobileRegex();

    [GeneratedRegex(@"^[2-9]\d{11}$", RegexOptions.IgnoreCase)]
    private static partial Regex AadharRegex();

    [GeneratedRegex(@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$", RegexOptions.IgnoreCase)]
    private static partial Regex PanNoRegex();

    [GeneratedRegex(@"^[0-3][0-9][A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$", RegexOptions.IgnoreCase)]
    private static partial Regex GstRegex();

    [GeneratedRegex(@"^[1-9][0-9]{5}$", RegexOptions.IgnoreCase)]
    private static partial Regex PincodeRegex();

    [GeneratedRegex(@"^[A-Z]{4}0[A-Z0-9]{6}$", RegexOptions.IgnoreCase)]
    private static partial Regex IfscRegex();

    /// <summary>Validates an email address format.</summary>
    public static bool IsValidEmail(string? email)
    {
        return !string.IsNullOrWhiteSpace(email) && EmailRegex().IsMatch(email.Trim());
    }

    /// <summary>Validates an Indian mobile number (10 digits, starts with 6–9).</summary>
    public static bool IsValidIndianMobile(string? phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            return false;
        }

        string cleaned = PhoneCleanupRegex().Replace(phone, "");
        if (cleaned.StartsWith("91") && cleaned.Length == 12)
        {
            cleaned = cleaned[2..];
        }

        return IndianMobileRegex().IsMatch(cleaned.Trim());
    }

    /// <summary>Validates an Aadhaar number (12 digits).</summary>
    public static bool IsValidAadhaar(string? aadhaar)
    {
        if (string.IsNullOrWhiteSpace(aadhaar))
        {
            return false;
        }

        string cleaned = aadhaar.Replace(" ", "").Replace("-", "");
        return AadharRegex().IsMatch(cleaned.Trim());
    }

    /// <summary>Validates a PAN number. E.g. "ABCDE1234F"</summary>
    public static bool IsValidPAN(string? pan)
    {
        return !string.IsNullOrWhiteSpace(pan) && PanNoRegex().IsMatch(pan.Trim().ToUpper());
    }

    /// <summary>Validates a GST number (15-character Indian format).</summary>
    public static bool IsValidGST(string? gst)
    {
        return !string.IsNullOrWhiteSpace(gst) && GstRegex().IsMatch(gst.Trim().ToUpper());
    }

    /// <summary>Validates a URL (http or https).</summary>
    public static bool IsValidUrl(string? url)
    {
        return !string.IsNullOrWhiteSpace(url) && Uri.TryCreate(url, UriKind.Absolute, out Uri? result) &&
               (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
    }

    /// <summary>Validates a 6-digit Indian PIN code.</summary>
    public static bool IsValidPinCode(string? pin)
    {
        return !string.IsNullOrWhiteSpace(pin) && PincodeRegex().IsMatch(pin.Trim());
    }

    /// <summary>Validates a password by minimum length and optional complexity rules.</summary>
    public static bool IsStrongPassword(string? password,
        int minLength = 8,
        bool requireUppercase = true,
        bool requireDigit = true,
        bool requireSpecial = true)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < minLength)
        {
            return false;
        }

        if (requireUppercase && !password.Any(char.IsUpper))
        {
            return false;
        }

        if (requireDigit && !password.Any(char.IsDigit))
        {
            return false;
        }

        return !requireSpecial || password.Any("!@#$%^&*()_+-=[]{}|;':\",./<>?".Contains);
    }

    /// <summary>Checks if a date of birth represents an adult (18+).</summary>
    public static bool IsAdult(DateTime dateOfBirth) =>
        DateTime.Today >= dateOfBirth.AddYears(18);

    /// <summary>Validates an IFSC code (Indian bank format).</summary>
    public static bool IsValidIFSC(string? ifsc)
    {
        return !string.IsNullOrWhiteSpace(ifsc) && IfscRegex().IsMatch(ifsc.Trim().ToUpper());
    }

    /// <summary>Returns true if the string contains only alphanumeric characters.</summary>
    public static bool IsAlphanumeric(string? value)
    {
        return !string.IsNullOrWhiteSpace(value) && value.All(char.IsLetterOrDigit);
    }
}
