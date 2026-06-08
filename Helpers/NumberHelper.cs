namespace MyUtils.Helpers;

/// <summary>
/// Static helper methods for number and math operations.
/// </summary>
public static class NumberHelper
{
    /// <summary>Clamps a value between a min and max.</summary>
    public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
    {
        if (value.CompareTo(min) < 0)
        {
            return min;
        }

        return value.CompareTo(max) > 0 ? max : value;
    }

    /// <summary>Checks if a number is between two values (inclusive).</summary>
    public static bool IsBetween(double value, double min, double max) => value >= min && value <= max;

    /// <summary>Rounds to the nearest specified interval. E.g. RoundTo(17, 5) = 15</summary>
    public static double RoundTo(double value, double interval) => Math.Round(value / interval) * interval;

    /// <summary>Converts a number to its ordinal string. E.g. 1 => "1st", 2 => "2nd"</summary>
    public static string ToOrdinal(int number)
    {
        if (number <= 0)
        {
            return number.ToString();
        }

        string suffix = (number % 100) switch
        {
            11 or 12 or 13 => "th",
            _ => (number % 10) switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            }
        };
        return $"{number}{suffix}";
    }

    /// <summary>Calculates the percentage of part relative to total. E.g. 25 out of 200 = 12.5%</summary>
    public static double Percentage(double part, double total) => total == 0 ? 0 : Math.Round(part / total * 100, 2);

    /// <summary>Checks if a number is prime.</summary>
    public static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>Returns the factorial of a non-negative integer.</summary>
    public static long Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("Factorial is not defined for negative numbers.");
        }

        if (n == 0 || n == 1)
        {
            return 1;
        }

        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    /// <summary>Formats a number with Indian numbering system. E.g. 1234567 => "12,34,567"</summary>
    public static string ToIndianFormat(long number)
    {
        if (number < 0)
        {
            return "-" + ToIndianFormat(-number);
        }

        string s = number.ToString();
        if (s.Length <= 3)
        {
            return s;
        }

        string result = s[^3..];
        s = s[..^3];
        while (s.Length > 2)
        {
            result = s[^2..] + "," + result;
            s = s[..^2];
        }
        return s + "," + result;
    }

    /// <summary>Converts a number to words. E.g. 42 => "Forty Two"</summary>
    public static string ToWords(int number)
    {
        if (number == 0)
        {
            return "Zero";
        }

        if (number < 0)
        {
            return "Minus " + ToWords(-number);
        }

        string[] ones = ["", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
                          "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                          "Seventeen", "Eighteen", "Nineteen"];
        string[] tens = ["", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];
        if (number < 20)
        {
            return ones[number];
        }

        if (number < 100)
        {
            return tens[number / 10] + (number % 10 != 0 ? " " + ones[number % 10] : "");
        }

        if (number < 1000)
        {
            return ones[number / 100] + " Hundred" + (number % 100 != 0 ? " " + ToWords(number % 100) : "");
        }

        if (number < 100000)
        {
            return ToWords(number / 1000) + " Thousand" + (number % 1000 != 0 ? " " + ToWords(number % 1000) : "");
        }

        return number < 10000000
            ? ToWords(number / 100000) + " Lakh" + (number % 100000 != 0 ? " " + ToWords(number % 100000) : "")
            : ToWords(number / 10000000) + " Crore" + (number % 10000000 != 0 ? " " + ToWords(number % 10000000) : "");
    }

    /// <summary>Safe integer parse with a default fallback.</summary>
    public static int ParseOrDefault(string? value, int defaultValue = 0) => int.TryParse(value, out int result) ? result : defaultValue;

    /// <summary>Safe decimal parse with a default fallback.</summary>
    public static decimal ParseDecimalOrDefault(string? value, decimal defaultValue = 0m) => decimal.TryParse(value, out decimal result) ? result : defaultValue;
}
