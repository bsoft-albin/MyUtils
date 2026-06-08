namespace MyUtils.Converters
{
    /// <summary>
    /// Unit conversion helpers — temperature, distance, weight, data size.
    /// </summary>
    public static class UnitConverter
    {
        // ── Temperature ───────────────────────────────────────────────────

        /// <summary>
        /// Converts Celsius to Fahrenheit.
        /// </summary>
        /// <param name="celsius">Temperature in Celsius.</param>
        /// <returns>Temperature in Fahrenheit.</returns>
        public static double CelsiusToFahrenheit(double celsius) => celsius * 9 / 5 + 32;

        /// <summary>
        /// Converts Fahrenheit to Celsius.
        /// </summary>
        /// <param name="fahrenheit">Temperature in Fahrenheit.</param>
        /// <returns>Temperature in Celsius.</returns>
        public static double FahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;

        /// <summary>
        /// Converts Celsius to Kelvin.
        /// </summary>
        /// <param name="celsius">Temperature in Celsius.</param>
        /// <returns>Temperature in Kelvin.</returns>
        public static double CelsiusToKelvin(double celsius) => celsius + 273.15;

        /// <summary>
        /// Converts Kelvin to Celsius.
        /// </summary>
        /// <param name="kelvin">Temperature in Kelvin.</param>
        /// <returns>Temperature in Celsius.</returns>
        public static double KelvinToCelsius(double kelvin) => kelvin - 273.15;

        // ── Distance ─────────────────────────────────────────────────────

        /// <summary>
        /// Converts kilometers to miles. 1 km ≈ 0.621371 miles.
        /// </summary>
        /// <param name="km">Distance in kilometers.</param>
        /// <returns>Distance in miles.</returns>
        public static double KmToMiles(double km) => km * 0.621371;

        /// <summary>
        /// Converts miles to kilometers. 1 mile ≈ 1.60934 km.
        /// </summary>
        /// <param name="miles">Distance in miles.</param>
        /// <returns>Distance in kilometers.</returns>
        public static double MilesToKm(double miles) => miles / 0.621371;

        /// <summary>
        /// Converts meters to feet. 1 meter ≈ 3.28084 feet.
        /// </summary>
        /// <param name="meters">Distance in meters.</param>
        /// <returns>Distance in feet.</returns>
        public static double MetersToFeet(double meters) => meters * 3.28084;

        /// <summary>
        /// Converts feet to meters. 1 foot ≈ 0.3048 meters.
        /// </summary>
        /// <param name="feet">Distance in feet.</param>
        /// <returns>Distance in meters.</returns>
        public static double FeetToMeters(double feet) => feet / 3.28084;

        // ── Weight ───────────────────────────────────────────────────────

        /// <summary>
        /// Converts kilograms to pounds. 1 kg ≈ 2.20462 lbs.
        /// </summary>
        /// <param name="kg">Weight in kilograms.</param>
        /// <returns>Weight in pounds.</returns>
        public static double KgToLbs(double kg) => kg * 2.20462;

        /// <summary>
        /// Converts pounds to kilograms. 1 lb ≈ 0.453592 kg.
        /// </summary>
        /// <param name="lbs">Weight in pounds.</param>
        /// <returns>Weight in kilograms.</returns>
        public static double LbsToKg(double lbs) => lbs / 2.20462;

        /// <summary>
        /// Converts kilograms to grams. 1 kg = 1000 g.
        /// </summary>
        /// <param name="kg">Weight in kilograms.</param>
        /// <returns>Weight in grams.</returns>
        public static double KgToGrams(double kg) => kg * 1000;

        /// <summary>
        /// Converts grams to kilograms. 1000 g = 1 kg.
        /// </summary>
        /// <param name="grams">Weight in grams.</param>
        /// <returns>Weight in kilograms.</returns>
        public static double GramsToKg(double grams) => grams / 1000;

        // ── Data Size ─────────────────────────────────────────────────────
        
        /// <summary>
        /// Converts bytes to kilobytes. 1 KB = 1024 bytes.
        /// </summary>
        /// <param name="bytes">Data size in bytes.</param>
        /// <returns>Data size in kilobytes.</returns>
        public static double BytesToKb(long bytes) => bytes / 1024.0;

        /// <summary>
        /// Converts bytes to megabytes. 1 MB = 1024 KB = 1024 * 1024 bytes.
        /// </summary>
        /// <param name="bytes">Data size in bytes.</param>
        /// <returns>Data size in megabytes.</returns>
        public static double BytesToMb(long bytes) => bytes / (1024.0 * 1024);

        /// <summary>
        /// Converts bytes to gigabytes. 1 GB = 1024 MB = 1024 * 1024 KB = 1024 * 1024 * 1024 bytes.
        /// </summary>
        /// <param name="bytes">Data size in bytes.</param>
        /// <returns>Data size in gigabytes.</returns>
        public static double BytesToGb(long bytes) => bytes / (1024.0 * 1024 * 1024);

        /// <summary>
        /// Converts kilobytes to bytes. 1 KB = 1024 bytes.
        /// </summary>
        /// <param name="kb">Data size in kilobytes.</param>
        /// <returns>Data size in bytes.</returns>
        public static long KbToBytes(double kb) => (long)(kb * 1024);

        /// <summary>
        /// Converts megabytes to bytes. 1 MB = 1024 KB = 1024 * 1024 bytes.
        /// </summary>
        /// <param name="mb">Data size in megabytes.</param>
        /// <returns>Data size in bytes.</returns>
        public static long MbToBytes(double mb) => (long)(mb * 1024 * 1024);

        // ── Time ─────────────────────────────────────────────────────────

        /// <summary>
        /// Converts minutes to hours. 60 minutes = 1 hour.
        /// </summary>
        /// <param name="minutes">Time in minutes.</param>
        /// <returns>Time in hours.</returns>
        public static double MinutesToHours(double minutes) => minutes / 60;

        /// <summary>
        /// Converts hours to minutes. 1 hour = 60 minutes.
        /// </summary>
        /// <param name="hours">Time in hours.</param>
        /// <returns>Time in minutes.</returns>
        public static double HoursToMinutes(double hours) => hours * 60;

        /// <summary>
        /// Converts seconds to minutes. 60 seconds = 1 minute.
        /// </summary>
        /// <param name="seconds">Time in seconds.</param>
        /// <returns>Time in minutes.</returns>
        public static double SecondsToMinutes(double seconds) => seconds / 60;

        /// <summary>
        /// Converts days to hours. 1 day = 24 hours.
        /// </summary>
        /// <param name="days">Time in days.</param>
        /// <returns>Time in hours.</returns>
        public static double DaysToHours(double days) => days * 24;
    }
}
