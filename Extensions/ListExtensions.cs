namespace MyUtils.Extensions;

/// <summary>
/// Extension methods for collections — IEnumerable, List, Array.
/// </summary>
public static class ListExtensions
{
    /// <summary>Returns true if the collection is null or has no elements.</summary>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source) =>
        source == null || !source.Any();

    /// <summary>Returns true if the collection has at least one element.</summary>
    public static bool IsNotNullOrEmpty<T>(this IEnumerable<T>? source) =>
        !source.IsNullOrEmpty();

    /// <summary>Paginates a collection and returns the requested page.</summary>
    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int page, int pageSize)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(page, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);
        return source.Skip((page - 1) * pageSize).Take(pageSize);
    }

    /// <summary>Splits a list into chunks of the given size.</summary>
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
    {
        List<T> list = [.. source];
        for (int i = 0; i < list.Count; i += chunkSize)
        {
            yield return list.Skip(i).Take(chunkSize);
        }
    }

    /// <summary>Randomly shuffles the elements of a list.</summary>
    public static IList<T> Shuffle<T>(this IList<T> source)
    {
        List<T> list = [.. source];
        Random rng = new();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
        return list;
    }

    /// <summary>Returns a random element from the collection.</summary>
    public static T? RandomElement<T>(this IEnumerable<T> source)
    {
        List<T> list = [.. source];
        return list.Count == 0 ? default : list[new Random().Next(list.Count)];
    }

    /// <summary>Removes duplicate elements by a key selector.</summary>
    public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) =>
        source.GroupBy(keySelector).Select(g => g.First());

    /// <summary>Performs an action on each element (ForEach for IEnumerable).</summary>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (T item in source)
        {
            action(item);
        }
    }

    /// <summary>Safely gets an element at an index, returning default if out of range.</summary>
    public static T? SafeGet<T>(this IList<T> source, int index) =>
        index >= 0 && index < source.Count ? source[index] : default;

    /// <summary>Converts a collection to a comma-separated string.</summary>
    public static string ToCsv<T>(this IEnumerable<T> source, string separator = ", ") =>
        string.Join(separator, source);

    /// <summary>Returns the collection if not null/empty, or a fallback collection.</summary>
    public static IEnumerable<T> OrDefault<T>(this IEnumerable<T>? source, IEnumerable<T>? fallback = null) =>
        source.IsNullOrEmpty() ? (fallback ?? []) : source!;

    /// <summary>Flattens a nested collection into a single sequence.</summary>
    public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> source) =>
        source.SelectMany(x => x);

    /// <summary>Returns all elements except those at the given indices.</summary>
    public static IEnumerable<T> ExceptAt<T>(this IList<T> source, params int[] indices)
    {
        HashSet<int> set = [.. indices];
        return source.Where((_, i) => !set.Contains(i));
    }

    /// <summary>Returns true if all elements in the collection are unique.</summary>
    public static bool AllUnique<T>(this IEnumerable<T> source) =>
        source.GroupBy(x => x).All(g => g.Count() == 1);
}
