namespace MyUtils.Configuration
{
    /// <summary>
    /// OTP / verification configuration — bind from "OtpSettings".
    /// </summary>
    public class OtpSettings
    {
        /// <summary>
        /// Name of the configuration section in appsettings.json to bind to this class.
        /// </summary>
        public const string SectionName = "OtpSettings";

        /// <summary>
        /// Length of the OTP code (e.g., 6 for a 6-digit numeric code). Default is 6. Must be a positive integer.
        /// </summary>
        public int Length { get; set; } = 6;

        /// <summary>
        /// Expiry time for the OTP code in minutes. Default is 5 minutes. Must be a positive integer.
        /// </summary>
        public int ExpiryMinutes { get; set; } = 5;

        /// <summary>
        /// Maximum number of allowed attempts to verify the OTP before it becomes invalid. Default is 3. Must be a positive integer.
        /// </summary>
        public int MaxAttempts { get; set; } = 3;
    }
}
