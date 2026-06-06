using MyUtils.Helpers;

namespace MyUtils.Extensions;

/// <summary>
/// Extension methods for <see cref="string"/>.
/// </summary>
public static class StringExtensions
{
    /// <inheritdoc cref="StringHelper.IsNullOrEmpty"/>
    public static bool IsNullOrEmpty(this string? value) => StringHelper.IsNullOrEmpty(value);

    /// <inheritdoc cref="StringHelper.IsNullOrEmpty"/>
    public static bool IsNotNullOrEmpty(this string? value) => !StringHelper.IsNullOrEmpty(value);

    /// <inheritdoc cref="StringHelper.Truncate"/>
    public static string Truncate(this string value, int maxLength, string suffix = "...") => StringHelper.Truncate(value, maxLength, suffix);

    /// <inheritdoc cref="StringHelper.ToSlug"/>
    public static string ToSlug(this string value) => StringHelper.ToSlug(value);

    /// <inheritdoc cref="StringHelper.ToTitleCase"/>
    public static string ToTitleCase(this string value) => StringHelper.ToTitleCase(value);

    /// <inheritdoc cref="StringHelper.Capitalize"/>
    public static string Capitalize(this string value) => StringHelper.Capitalize(value);

    /// <inheritdoc cref="StringHelper.ToCamelCase"/>
    public static string ToCamelCase(this string value) => StringHelper.ToCamelCase(value);

    /// <inheritdoc cref="StringHelper.ToPascalCase"/>
    public static string ToPascalCase(this string value) => StringHelper.ToPascalCase(value);

    /// <inheritdoc cref="StringHelper.StripHtml"/>
    public static string StripHtml(this string html) => StringHelper.StripHtml(html);

    /// <inheritdoc cref="StringHelper.WordCount"/>
    public static int WordCount(this string value) => StringHelper.WordCount(value);

    /// <inheritdoc cref="StringHelper.Reverse"/>
    public static string Reverse(this string value) => StringHelper.Reverse(value);

    /// <inheritdoc cref="StringHelper.IsPalindrome"/>
    public static bool IsPalindrome(this string value) => StringHelper.IsPalindrome(value);

    /// <inheritdoc cref="StringHelper.Mask"/>
    public static string Mask(this string value, int visibleStart, int visibleEnd, char maskChar = '*') => StringHelper.Mask(value, visibleStart, visibleEnd, maskChar);

    /// <inheritdoc cref="StringHelper.ToBase64"/>
    public static string ToBase64(this string value) => StringHelper.ToBase64(value);

    /// <inheritdoc cref="StringHelper.FromBase64"/>
    public static string FromBase64(this string base64) => StringHelper.FromBase64(base64);

    /// <summary>Safely converts a string to an enum value, or returns default.</summary>
    public static T ToEnum<T>(this string value, T defaultValue = default!) where T : struct, Enum => Enum.TryParse<T>(value, ignoreCase: true, out T result) ? result : defaultValue;

    /// <summary>Converts the string to an int, or returns the default value if conversion fails.</summary>
    public static int ToInt(this string? value, int defaultValue = 0) => int.TryParse(value, out int result) ? result : defaultValue;

    /// <summary>Converts the string to a decimal, or returns the default value.</summary>
    public static decimal ToDecimal(this string? value, decimal defaultValue = 0m) => decimal.TryParse(value, out decimal result) ? result : defaultValue;

    /// <summary>Converts the string to a Guid, or returns Guid.Empty.</summary>
    public static Guid ToGuid(this string? value) => Guid.TryParse(value, out Guid result) ? result : Guid.Empty;

    /// <summary>Removes all whitespace from a string.</summary>
    public static string RemoveWhitespace(this string value) => new([.. value.Where(c => !char.IsWhiteSpace(c))]);

    /// <summary>Returns true if the string contains the given value (case-insensitive).</summary>
    public static bool ContainsIgnoreCase(this string value, string search) => value.Contains(search, StringComparison.OrdinalIgnoreCase);

    /// <summary>Repeats a string n times. E.g. "abc".Repeat(3) => "abcabcabc"</summary>
    public static string Repeat(this string value, int times) => string.Concat(Enumerable.Repeat(value, times));
}
