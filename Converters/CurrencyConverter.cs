using System.Globalization;

namespace MyUtils.Converters
{
    /// <summary>
    /// Currency-related formatting helpers.
    /// </summary>
    public static class CurrencyConverter
    {
        /// <summary>Formats a decimal as Indian Rupees. E.g. 1234567.89 => "₹12,34,567.89"</summary>
        public static string ToINR(decimal amount)
        {
            CultureInfo culture = new("en-IN");
            return amount.ToString("C", culture);
        }

        /// <summary>Formats a decimal as USD. E.g. 1234.5 => "$1,234.50"</summary>
        public static string ToUSD(decimal amount) => amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-US"));

        /// <summary>Rounds a currency value to 2 decimal places.</summary>
        public static decimal Round(decimal amount) => Math.Round(amount, 2, MidpointRounding.AwayFromZero);

        /// <summary>Calculates the GST amount and returns (baseAmount, gstAmount, total).</summary>
        public static (decimal Base, decimal Gst, decimal Total) CalculateGst(decimal amount, decimal gstPercent)
        {
            decimal gst = Round(amount * gstPercent / 100);
            return (amount, gst, amount + gst);
        }

        /// <summary>Calculates discount and returns (discountAmount, finalPrice).</summary>
        public static (decimal DiscountAmount, decimal FinalPrice) ApplyDiscount(decimal price, decimal discountPercent)
        {
            decimal discount = Round(price * discountPercent / 100);
            return (discount, price - discount);
        }
    }
}
