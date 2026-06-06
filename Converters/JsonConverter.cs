using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyUtils.Converters;

/// <summary>
/// JSON serialization/deserialization helpers using System.Text.Json.
/// </summary>
public static class JsonConverter
{
    private static readonly JsonSerializerOptions DefaultOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private static readonly JsonSerializerOptions PrettyOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    /// <summary>Serializes an object to a JSON string (camelCase).</summary>
    public static string Serialize<T>(T obj) => JsonSerializer.Serialize(obj, DefaultOptions);

    /// <summary>Serializes an object to a pretty-printed JSON string.</summary>
    public static string SerializePretty<T>(T obj) => JsonSerializer.Serialize(obj, PrettyOptions);

    /// <summary>Deserializes a JSON string to the specified type. Returns default on failure.</summary>
    public static T? Deserialize<T>(string json)
    {
        try { return JsonSerializer.Deserialize<T>(json, DefaultOptions); }
        catch { return default; }
    }

    /// <summary>Tries to deserialize a JSON string; returns true and the result if successful.</summary>
    public static bool TryDeserialize<T>(string json, out T? result)
    {
        try
        {
            result = JsonSerializer.Deserialize<T>(json, DefaultOptions);
            return result != null;
        }
        catch { result = default; return false; }
    }

    /// <summary>Deep clones an object via JSON round-trip.</summary>
    public static T? DeepClone<T>(T obj) => Deserialize<T>(Serialize(obj));
}
