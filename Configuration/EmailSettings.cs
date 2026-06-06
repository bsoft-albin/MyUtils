namespace MyUtils.Configuration
{
    /// <summary>
    /// SMTP / email configuration — bind from appsettings.json section "EmailSettings".
    /// </summary>
    public class EmailSettings
    {
        public const string SectionName = "EmailSettings";

        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 587;
        public bool UseSsl { get; set; } = true;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        /// <summary>Display name shown as the sender.</summary>
        public string FromName { get; set; } = string.Empty;

        /// <summary>From email address.</summary>
        public string FromAddress { get; set; } = string.Empty;
    }
}
