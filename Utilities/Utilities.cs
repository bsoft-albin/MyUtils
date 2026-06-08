using System.Diagnostics;

namespace MyUtils.Utilities;

/// <summary>
/// Retry logic utility with exponential backoff.
/// </summary>
public static class RetryHelper
{
    /// <summary>
    /// Executes an async operation with retry logic.
    /// </summary>
    /// <param name="action">The async action to execute.</param>
    /// <param name="maxRetries">Maximum number of retry attempts (default: 3).</param>
    /// <param name="delayMs">Initial delay in milliseconds between retries (default: 200ms).</param>
    /// <param name="useExponentialBackoff">Double the delay on each retry if true.</param>
    public static async Task ExecuteAsync(
        Func<Task> action,
        int maxRetries = 3,
        int delayMs = 200,
        bool useExponentialBackoff = true)
    {
        int attempt = 0;
        while (true)
        {
            try
            {
                await action();
                return;
            }
            catch (Exception) when (attempt < maxRetries)
            {
                attempt++;
                int wait = useExponentialBackoff ? delayMs * (int)Math.Pow(2, attempt - 1) : delayMs;
                await Task.Delay(wait);
            }
        }
    }

    /// <summary>
    /// Executes an async function with retry logic and returns the result.
    /// </summary>
    public static async Task<T> ExecuteAsync<T>(
        Func<Task<T>> func,
        int maxRetries = 3,
        int delayMs = 200,
        bool useExponentialBackoff = true)
    {
        int attempt = 0;
        while (true)
        {
            try
            {
                return await func();
            }
            catch (Exception) when (attempt < maxRetries)
            {
                attempt++;
                int wait = useExponentialBackoff ? delayMs * (int)Math.Pow(2, attempt - 1) : delayMs;
                await Task.Delay(wait);
            }
        }
    }
}

/// <summary>
/// Guard clause helpers to validate method arguments early.
/// </summary>
public static class Guard
{
    /// <summary>Throws <see cref="ArgumentNullException"/> if value is null.</summary>
    public static T NotNull<T>(T? value, string paramName) where T : class =>
        value ?? throw new ArgumentNullException(paramName);

    /// <summary>Throws <see cref="ArgumentException"/> if string is null or whitespace.</summary>
    public static string NotNullOrEmpty(string? value, string paramName)
    {
        return string.IsNullOrWhiteSpace(value) ? throw new ArgumentException($"{paramName} must not be null or empty.", paramName) : value;
    }

    /// <summary>Throws <see cref="ArgumentOutOfRangeException"/> if value is less than min.</summary>
    public static T Min<T>(T value, T min, string paramName) where T : IComparable<T>
    {
        return value.CompareTo(min) < 0 ? throw new ArgumentOutOfRangeException(paramName, $"{paramName} must be >= {min}.") : value;
    }

    /// <summary>Throws <see cref="ArgumentOutOfRangeException"/> if value is greater than max.</summary>
    public static T Max<T>(T value, T max, string paramName) where T : IComparable<T>
    {
        return value.CompareTo(max) > 0 ? throw new ArgumentOutOfRangeException(paramName, $"{paramName} must be <= {max}.") : value;
    }

    /// <summary>Throws <see cref="ArgumentOutOfRangeException"/> if value is outside [min, max].</summary>
    public static T Range<T>(T value, T min, T max, string paramName) where T : IComparable<T>
    {
        return value.CompareTo(min) < 0 || value.CompareTo(max) > 0
            ? throw new ArgumentOutOfRangeException(paramName, $"{paramName} must be between {min} and {max}.")
            : value;
    }

    /// <summary>Throws <see cref="ArgumentException"/> if collection is null or empty.</summary>
    public static IEnumerable<T> NotEmpty<T>(IEnumerable<T>? collection, string paramName)
    {
        return collection == null || !collection.Any()
            ? throw new ArgumentException($"{paramName} must not be null or empty.", paramName)
            : collection;
    }

    /// <summary>Throws <see cref="ArgumentException"/> if value does not satisfy the predicate.</summary>
    public static T Requires<T>(T value, Func<T, bool> predicate, string paramName, string message)
    {
        return !predicate(value) ? throw new ArgumentException(message, paramName) : value;
    }
}

/// <summary>
/// Environment and configuration utilities.
/// </summary>
public static class EnvironmentHelper
{
    /// <summary>Returns the value of an environment variable, or a default if not set.</summary>
    public static string GetEnv(string key, string defaultValue = "") =>
        Environment.GetEnvironmentVariable(key) ?? defaultValue;

    /// <summary>Returns true if the current environment name matches (e.g. "Development").</summary>
    public static bool IsEnvironment(string environmentName) =>
        string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                      environmentName, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Convenience methods for common environment checks. E.g. IsDevelopment() returns true if ASPNETCORE_ENVIRONMENT is "Development".
    /// </summary>
    /// <returns>True if the current environment matches the specified environment name.</returns>
    public static bool IsDevelopment() => IsEnvironment("Development");

    /// <summary>
    /// Returns true if the current environment is "Production". Useful for toggling features or logging in production vs development environments.
    /// </summary>
    /// <returns>True if the current environment is "Production".</returns>
    public static bool IsProduction()  => IsEnvironment("Production");

    /// <summary>
    /// Returns true if the current environment is "Staging". Useful for toggling features or logging in staging vs other environments.
    /// </summary>
    /// <returns>True if the current environment is "Staging".</returns>
    public static bool IsStaging()     => IsEnvironment("Staging");

    /// <summary>Returns the machine name of the current host.</summary>
    public static string MachineName => Environment.MachineName;

    /// <summary>Returns the OS platform description.</summary>
    public static string OsPlatform =>
        System.Runtime.InteropServices.RuntimeInformation.OSDescription;
}

/// <summary>
/// Miscellaneous general-purpose utilities.
/// </summary>
public static class MiscUtils
{
    /// <summary>Measures the time taken to execute an action and returns elapsed milliseconds.</summary>
    public static long MeasureMs(Action action)
    {
        Stopwatch sw = Stopwatch.StartNew();
        action();
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }

    /// <summary>Measures the time taken to execute an async function and returns elapsed milliseconds.</summary>
    public static async Task<(T Result, long ElapsedMs)> MeasureAsync<T>(Func<Task<T>> func)
    {
        Stopwatch sw = Stopwatch.StartNew();
        T? result = await func();
        sw.Stop();
        return (result, sw.ElapsedMilliseconds);
    }

    /// <summary>Executes an action silently, swallowing any exception (fire-and-forget safety).</summary>
    public static void TryRun(Action action)
    {
        try { action(); } catch { /* intentionally swallowed */ }
    }

    /// <summary>Asynchronously executes a function silently, swallowing any exception.</summary>
    public static async Task TryRunAsync(Func<Task> func)
    {
        try { await func(); } catch { /* intentionally swallowed */ }
    }

    /// <summary>Creates a new GUID string (no dashes, uppercase). Useful for IDs.</summary>
    public static string NewId() => Guid.NewGuid().ToString("N").ToUpper();

    /// <summary>Creates a new short ID (first 8 chars of a GUID). Not globally unique — use for display only.</summary>
    public static string ShortId() => Guid.NewGuid().ToString("N")[..8].ToUpper();
}
