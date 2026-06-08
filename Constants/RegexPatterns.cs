namespace MyUtils.Constants
{
    /// <summary>
    /// Regex pattern constants for common validations.
    /// </summary>
    public static class RegexPatterns
    {
        /// <summary>Email address validation pattern.</summary>
        public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        /// <summary>Indian mobile number validation pattern.</summary>
        public const string IndianMobile = @"^[6-9]\d{9}$";

        /// <summary>PAN number validation pattern.</summary>
        public const string PAN = @"^[A-Z]{5}[0-9]{4}[A-Z]{1}$";

        /// <summary>Aadhaar number validation pattern.</summary>
        public const string Aadhaar = @"^[2-9]\d{11}$";

        /// <summary>GSTIN validation pattern.</summary>
        public const string GST = @"^[0-3][0-9][A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$";

        /// <summary>IFSC code validation pattern.</summary>
        public const string IFSC = @"^[A-Z]{4}0[A-Z0-9]{6}$";

        /// <summary>Indian PIN code validation pattern.</summary>
        public const string PinCode = @"^[1-9][0-9]{5}$";

        /// <summary>Alphabetic characters only validation pattern.</summary>
        public const string AlphaOnly = @"^[a-zA-Z]+$";

        /// <summary>Alphanumeric characters only validation pattern.</summary>
        public const string AlphaNum = @"^[a-zA-Z0-9]+$";

        /// <summary>URL validation pattern.</summary>
        public const string Url = @"^https?://[^\s/$.?#].[^\s]*$";

        /// <summary>URL slug validation pattern.</summary>
        public const string Slug = @"^[a-z0-9]+(?:-[a-z0-9]+)*$";

        /// <summary>Hex color code validation pattern.</summary>
        public const string HexColor = @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";

        /// <summary>IPv4 address validation pattern.</summary>
        public const string IPv4 = @"^(\d{1,3}\.){3}\d{1,3}$";
    }
}
