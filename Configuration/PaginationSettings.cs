namespace MyUtils.Configuration
{
    /// <summary>
    /// Pagination defaults — bind from "PaginationSettings".
    /// </summary>
    public class PaginationSettings
    {
        public const string SectionName = "PaginationSettings";

        public int DefaultPageSize { get; set; } = 10;
        public int MaxPageSize { get; set; } = 100;
    }
}
