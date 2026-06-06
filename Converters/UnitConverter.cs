namespace MyUtils.Converters
{
    /// <summary>
    /// Unit conversion helpers — temperature, distance, weight, data size.
    /// </summary>
    public static class UnitConverter
    {
        // ── Temperature ───────────────────────────────────────────────────

        public static double CelsiusToFahrenheit(double celsius) => celsius * 9 / 5 + 32;
        public static double FahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;
        public static double CelsiusToKelvin(double celsius) => celsius + 273.15;
        public static double KelvinToCelsius(double kelvin) => kelvin - 273.15;

        // ── Distance ─────────────────────────────────────────────────────

        public static double KmToMiles(double km) => km * 0.621371;
        public static double MilesToKm(double miles) => miles / 0.621371;
        public static double MetersToFeet(double meters) => meters * 3.28084;
        public static double FeetToMeters(double feet) => feet / 3.28084;

        // ── Weight ───────────────────────────────────────────────────────

        public static double KgToLbs(double kg) => kg * 2.20462;
        public static double LbsToKg(double lbs) => lbs / 2.20462;
        public static double KgToGrams(double kg) => kg * 1000;
        public static double GramsToKg(double grams) => grams / 1000;

        // ── Data Size ─────────────────────────────────────────────────────

        public static double BytesToKb(long bytes) => bytes / 1024.0;
        public static double BytesToMb(long bytes) => bytes / (1024.0 * 1024);
        public static double BytesToGb(long bytes) => bytes / (1024.0 * 1024 * 1024);
        public static long KbToBytes(double kb) => (long)(kb * 1024);
        public static long MbToBytes(double mb) => (long)(mb * 1024 * 1024);

        // ── Time ─────────────────────────────────────────────────────────

        public static double MinutesToHours(double minutes) => minutes / 60;
        public static double HoursToMinutes(double hours) => hours * 60;
        public static double SecondsToMinutes(double seconds) => seconds / 60;
        public static double DaysToHours(double days) => days * 24;
    }
}
