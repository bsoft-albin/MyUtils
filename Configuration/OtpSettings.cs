namespace MyUtils.Configuration
{
    /// <summary>
    /// OTP / verification configuration — bind from "OtpSettings".
    /// </summary>
    public class OtpSettings
    {
        public const string SectionName = "OtpSettings";

        public int Length { get; set; } = 6;
        public int ExpiryMinutes { get; set; } = 5;
        public int MaxAttempts { get; set; } = 3;
    }
}
