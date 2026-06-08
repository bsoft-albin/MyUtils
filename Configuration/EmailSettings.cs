namespace MyUtils.Configuration
{
    /// <summary>
    /// SMTP / email configuration — bind from appsettings.json section "EmailSettings".
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// Name of the configuration section in appsettings.json to bind to this class.
        /// </summary>
        public const string SectionName = "EmailSettings";

        /// <summary>
        /// SMTP server host (e.g., "smtp.gmail.com"). Required for sending emails.
        /// </summary>
        public string Host { get; set; } = string.Empty;

        /// <summary>
        /// SMTP server port (e.g., 587 for TLS, 465 for SSL). Required for sending emails.
        /// </summary>
        public int Port { get; set; } = 587;

        /// <summary>
        /// Whether to use SSL/TLS for the SMTP connection. Typically true for secure email servers. Required for sending emails.
        /// </summary>
        public bool UseSsl { get; set; } = true;

        /// <summary>
        /// SMTP server username. Required for authentication.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// SMTP server password. Required for authentication. Note: In production, consider using secure secrets management instead of storing in appsettings.json.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>Display name shown as the sender.</summary>
        public string FromName { get; set; } = string.Empty;

        /// <summary>From email address.</summary>
        public string FromAddress { get; set; } = string.Empty;
    }
}
