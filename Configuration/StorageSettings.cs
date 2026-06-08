namespace MyUtils.Configuration
{
    /// <summary>
    /// Cloud storage configuration (e.g. Azure Blob / AWS S3) — bind from "StorageSettings".
    /// </summary>
    public class StorageSettings
    {
        /// <summary>
        /// Name of the configuration section in appsettings.json to bind to this class.
        /// </summary>
        public const string SectionName = "StorageSettings";

        /// <summary>
        /// Storage provider type. Supported values: "Local" (for local file system), "AzureBlob" (for Azure Blob Storage), "S3" (for AWS S3). Default is "Local". Required for file upload functionality.
        /// </summary>
        public string Provider { get; set; } = "Local"; // Local | AzureBlob | S3

        /// <summary>
        /// Connection string for the storage provider. Required for AzureBlob and S3 providers.
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;

        /// <summary>
        /// Name of the container or bucket to use for storing files. Required for AzureBlob and S3 providers.
        /// </summary>
        public string ContainerName { get; set; } = string.Empty;

        /// <summary>
        /// Base URL for accessing stored files. Required for AzureBlob and S3 providers to generate public URLs for uploaded files. For local storage, this can be left empty or set to the base URL of your application if you serve files from a specific endpoint.
        /// </summary>
        public string BaseUrl { get; set; } = string.Empty;

        /// <summary>
        /// Maximum allowed file size for uploads in megabytes. Default is 10 MB. Must be a positive number. This setting can be used to validate file uploads before processing them, ensuring that users do not upload excessively large files that could impact performance or storage costs.
        /// </summary>
        public double MaxFileSizeMb { get; set; } = 10;
    }
}
