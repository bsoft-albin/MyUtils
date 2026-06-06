using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MyUtils.Helpers;

/// <summary>
/// Static helper methods for string operations.
/// </summary>
public static class StringHelper
{
    /// <summary>Returns true if the string is null, empty, or whitespace.</summary>
    public static bool IsNullOrEmpty(string? value) => string.IsNullOrWhiteSpace(value);

    /// <summary>Truncates a string to the given max length and appends suffix if cut.</summary>
    public static string Truncate(string value, int maxLength, string suffix = "...")
    {
        return string.IsNullOrEmpty(value) || value.Length <= maxLength ? value : value[..(maxLength - suffix.Length)] + suffix;
    }

    /// <summary>Converts a string to a URL-friendly slug. E.g. "Hello World!" => "hello-world"</summary>
    public static string ToSlug(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        value = value.ToLowerInvariant().Trim();
        value = Regex.Replace(value, @"[^a-z0-9\s-]", "");
        value = Regex.Replace(value, @"\s+", "-");
        value = Regex.Replace(value, @"-+", "-");
        return value.Trim('-');
    }

    /// <summary>Capitalizes the first letter of each word.</summary>
    public static string ToTitleCase(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? value : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
    }

    /// <summary>Capitalizes only the first letter of the string.</summary>
    public static string Capitalize(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? value : char.ToUpper(value[0]) + value[1..];
    }

    /// <summary>Converts a string to camelCase.</summary>
    public static string ToCamelCase(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        string[] words = value.Split([' ', '_', '-'], StringSplitOptions.RemoveEmptyEntries);
        return words[0].ToLower() + string.Concat(words.Skip(1).Select(ToTitleCase));
    }

    /// <summary>Converts a string to PascalCase.</summary>
    public static string ToPascalCase(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        string[] words = value.Split([' ', '_', '-'], StringSplitOptions.RemoveEmptyEntries);
        return string.Concat(words.Select(w => ToTitleCase(w)));
    }

    /// <summary>Removes all HTML tags from a string.</summary>
    public static string StripHtml(string html)
    {
        return string.IsNullOrWhiteSpace(html) ? string.Empty : Regex.Replace(html, "<.*?>", string.Empty);
    }

    /// <summary>Counts the number of words in a string.</summary>
    public static int WordCount(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? 0 : value.Split([' ', '\t', '\n'], StringSplitOptions.RemoveEmptyEntries).Length;
    }

    /// <summary>Reverses the characters in a string.</summary>
    public static string Reverse(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? value : new string([.. value.Reverse()]);
    }

    /// <summary>Checks if a string is a palindrome (ignores case & spaces).</summary>
    public static bool IsPalindrome(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        string clean = Regex.Replace(value.ToLower(), @"\s+", "");
        return clean == new string([.. clean.Reverse()]);
    }

    /// <summary>Masks part of a string. E.g. email masking: "te**@gmail.com"</summary>
    public static string Mask(string value, int visibleStart, int visibleEnd, char maskChar = '*')
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        if (value.Length <= visibleStart + visibleEnd)
        {
            return value;
        }

        string start = value[..visibleStart];
        string end = value[^visibleEnd..];
        string mask = new(maskChar, value.Length - visibleStart - visibleEnd);
        return start + mask + end;
    }

    /// <summary>Converts a string to a Base64 encoded string.</summary>
    public static string ToBase64(string value) => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));

    /// <summary>Decodes a Base64 encoded string.</summary>
    public static string FromBase64(string base64) => Encoding.UTF8.GetString(Convert.FromBase64String(base64));

    /// <summary>Generates a random alphanumeric string of the given length.</summary>
    public static string GenerateRandom(int length = 8)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new();
        return new string([.. Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)])]);
    }
}
