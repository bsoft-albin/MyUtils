namespace MyUtils.Configuration
{
    /// <summary>
    /// Pagination defaults — bind from "PaginationSettings".
    /// </summary>
    public class PaginationSettings
    {
        /// <summary>
        /// Name of the configuration section in appsettings.json to bind to this class.
        /// </summary>
        public const string SectionName = "PaginationSettings";

        /// <summary>
        /// Default number of items per page for paginated API responses. Default is 10. Must be a positive integer.
        /// </summary>
        public int DefaultPageSize { get; set; } = 10;

        /// <summary>
        /// Maximum allowed items per page to prevent excessive data load. Default is 100. Must be a positive integer.
        /// </summary>
        public int MaxPageSize { get; set; } = 100;
    }
}
