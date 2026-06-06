namespace MyUtils.Configuration
{
    /// <summary>
    /// Cloud storage configuration (e.g. Azure Blob / AWS S3) — bind from "StorageSettings".
    /// </summary>
    public class StorageSettings
    {
        public const string SectionName = "StorageSettings";

        public string Provider { get; set; } = "Local"; // Local | AzureBlob | S3
        public string ConnectionString { get; set; } = string.Empty;
        public string ContainerName { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public double MaxFileSizeMb { get; set; } = 10;
    }
}
