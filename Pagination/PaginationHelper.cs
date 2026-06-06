namespace MyUtils.Pagination;

/// <summary>
/// Represents a paginated result set with metadata.
/// </summary>
public class PagedResult<T>
{
    /// <summary>The items on the current page.</summary>
    public IQueryable<T> Items { get; set; } = default!;

    /// <summary>Current page number (1-based).</summary>
    public int Page { get; set; }

    /// <summary>Number of items per page.</summary>
    public int PageSize { get; set; }

    /// <summary>Total number of items across all pages.</summary>
    public int TotalCount { get; set; }

    /// <summary>Total number of pages.</summary>
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

    /// <summary>Whether a previous page exists.</summary>
    public bool HasPreviousPage => Page > 1;

    /// <summary>Whether a next page exists.</summary>
    public bool HasNextPage => Page < TotalPages;

    /// <summary>Index of the first item on this page (1-based).</summary>
    public int FirstItemIndex => TotalCount == 0 ? 0 : (Page - 1) * PageSize + 1;

    /// <summary>Index of the last item on this page (1-based).</summary>
    public int LastItemIndex => Math.Min(Page * PageSize, TotalCount);
}

/// <summary>
/// Represents incoming pagination and sorting parameters from a request.
/// </summary>
public class PagedRequest
{
    private int _page = 1;
    private int _pageSize = 10;

    /// <summary>Current page number (min: 1).</summary>
    public int Page
    {
        get => _page;
        set => _page = value < 1 ? 1 : value;
    }

    /// <summary>Page size (min: 1, max: 100).</summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value < 1 ? 1 : value > 100 ? 100 : value;
    }

    /// <summary>Optional field name to sort by.</summary>
    public string? SortBy { get; set; }

    /// <summary>Sort direction — true = ascending, false = descending.</summary>
    public bool Ascending { get; set; } = true;

    /// <summary>Optional search/filter keyword.</summary>
    public string? Search { get; set; }
}

/// <summary>
/// Static factory and extension methods for pagination.
/// </summary>
public static class PaginationHelper
{
    /// <summary>
    /// Paginates an IQueryable source based on the provided page and page size, returning a PagedResult with metadata.
    /// </summary>
    /// <typeparam name="T">The type of the items in the source.</typeparam>
    /// <param name="source">The source IQueryable to paginate.</param>
    /// <param name="page">The current page number (1-based).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A <see cref="PagedResult{T}"/> containing the paged items and metadata.</returns>
    public static PagedResult<T> Paginate<T>(IQueryable<T> source, int page, int pageSize)
    {
        IQueryable<T> items = source.Skip((page - 1) * pageSize).Take(pageSize);

        return new PagedResult<T>
        {
            Items = items,
            Page = page,
            PageSize = pageSize,
            TotalCount = items.Count()
        };
    }

    /// <summary>Creates a <see cref="PagedResult{T}"/> from already-paged data and a known total count.</summary>
    public static PagedResult<T> Create<T>(IQueryable<T> pagedItems, int page, int pageSize, int totalCount)
    {
        return new PagedResult<T>
        {
            Items = pagedItems,
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }

    /// <summary>Creates an empty paged result.</summary>
    public static PagedResult<T> Empty<T>(int page = 1, int pageSize = 10) => new() { Page = page, PageSize = pageSize, TotalCount = 0, Items = default! };
}
