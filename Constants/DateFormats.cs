namespace MyUtils.Constants
{
    /// <summary>
    /// Common date/time format strings.
    /// </summary>
    public static class DateFormats
    {
        /// <summary>
        /// Standard date and time format strings for consistent parsing and formatting across the application. These formats can be used in logging, user interfaces, and anywhere else date/time values need to be displayed or parsed in a consistent manner. The formats include:
        /// </summary>
        public const string Date = "yyyy-MM-dd";

        /// <summary>
        /// The DateTime format "yyyy-MM-dd HH:mm:ss" is a common and widely used format for representing date and time values. It follows the pattern of year (4 digits), month (2 digits), day (2 digits), hour (24-hour format, 2 digits), minute (2 digits), and second (2 digits). This format is unambiguous and easily sortable, making it ideal for logging, data storage, and display in user interfaces. The ISO 8601 format "yyyy-MM-ddTHH:mm:ssZ" is also included for representing date and time in a standardized way that includes the time zone information (UTC in this case). The friendly date formats provide more human-readable representations of dates and times for display purposes.
        /// </summary>
        public const string DateTime = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// The ISO 8601 date and time format "yyyy-MM-ddTHH:mm:ssZ" is a widely accepted standard for representing date and time values in a machine-readable format. It follows the pattern of year (4 digits), month (2 digits), day (2 digits), followed by the letter 'T' to separate the date and time components, then hour (24-hour format, 2 digits), minute (2 digits), second (2 digits), and ends with 'Z' to indicate that the time is in Coordinated Universal Time (UTC). This format is particularly useful for data interchange between systems, as it is unambiguous and can be easily parsed by both humans and machines. It is commonly used in APIs, logging, and any scenario where a standardized representation of date and time is required.
        /// </summary>
        public const string DateTimeISO = "yyyy-MM-ddTHH:mm:ssZ";

        /// <summary>
        /// Friendly date and time formats for display purposes. These formats are designed to be more human-readable and are often used in user interfaces, reports, and any context where dates and times are presented to end-users. The "dd MMM yyyy" format displays the day as a two-digit number, the month as a three-letter abbreviation, and the year as a four-digit number (e.g., "31 Dec 2024"). The "dd MMM yyyy, hh:mm tt" format includes both the date and time, with the time displayed in 12-hour format followed by an AM/PM designator (e.g., "31 Dec 2024, 11:59 PM"). The Time12H and Time24H formats provide options for displaying time in either 12-hour or 24-hour formats, depending on user preferences or regional conventions. The MonthYear format is useful for displaying just the month and year (e.g., "Dec 2024"), while the FileName format provides a compact representation of date and time that can be used in file names to ensure uniqueness and chronological sorting.
        /// </summary>
        public const string FriendlyDate = "dd MMM yyyy";

        /// <summary>
        /// The friendly date and time format "dd MMM yyyy, hh:mm tt" is designed to provide a more human-readable representation of date and time values. In this format, the day is displayed as a two-digit number (e.g., "01" for the first day of the month), the month is represented as a three-letter abbreviation (e.g., "Jan" for January, "Feb" for February), and the year is shown as a four-digit number (e.g., "2024"). The time component is displayed in 12-hour format, with hours represented as two digits (e.g., "01" for 1 AM or 1 PM), followed by minutes as two digits (e.g., "05" for five minutes past the hour), and an AM/PM designator ("AM" for times from midnight to just before noon, and "PM" for times from noon to just before midnight). This format is particularly useful for displaying date and time information in user interfaces, reports, and any context where readability is a priority, as it provides clear and concise information that is easy for users to understand at a glance.
        /// </summary>
        public const string FriendlyDateTime = "dd MMM yyyy, hh:mm tt";

        /// <summary>
        /// Time formats for displaying time values in either 12-hour or 24-hour formats. The "hh:mm tt" format represents time in 12-hour format, where "hh" is the hour (01-12), "mm" is the minute (00-59), and "tt" is the AM/PM designator. For example, "02:30 PM" represents 2:30 in the afternoon. The "HH:mm" format represents time in 24-hour format, where "HH" is the hour (00-23) and "mm" is the minute (00-59). For example, "14:30" represents 2:30 in the afternoon. These formats can be used in user interfaces, reports, and any context where time values need to be displayed in a clear and user-friendly manner, allowing for flexibility based on user preferences or regional conventions.
        /// </summary>
        public const string Time12H = "hh:mm tt";

        /// <summary>
        /// The time format "HH:mm" represents time in 24-hour format, where "HH" is the hour (00-23) and "mm" is the minute (00-59). For example, "14:30" represents 2:30 in the afternoon. This format is commonly used in many parts of the world and is often preferred for its clarity and lack of ambiguity compared to 12-hour formats. It can be used in user interfaces, reports, scheduling applications, and any context where time values need to be displayed in a clear and concise manner without the need for an AM/PM designator. The 24-hour format is particularly useful in professional and technical contexts, such as transportation schedules, military time, and international communication, where precision and clarity are essential.
        /// </summary>
        public const string Time24H = "HH:mm";

        /// <summary>
        /// The month and year format "MMM yyyy" is designed to provide a concise and human-readable representation of a specific month within a particular year. In this format, "MMM" represents the month as a three-letter abbreviation (e.g., "Jan" for January, "Feb" for February, "Mar" for March), while "yyyy" represents the year as a four-digit number (e.g., "2024"). For example, "Dec 2024" would represent December of the year 2024. This format is particularly useful for displaying date information in contexts where the specific day is not relevant or necessary, such as in financial reports, subscription billing cycles, or any scenario where summarizing data by month and year is more meaningful than including the day. It provides a clear and concise way to communicate time periods without overwhelming users with unnecessary details.
        /// </summary>
        public const string MonthYear = "MMM yyyy";

        /// <summary>
        /// The file name date and time format "yyyyMMddHHmmssfff" is designed to provide a compact and sortable representation of date and time values that can be safely used in file names. In this format, "yyyy" represents the year as a four-digit number (e.g., "2024"), "MM" represents the month as a two-digit number (e.g., "01" for January, "12" for December), "dd" represents the day of the month as a two-digit number (e.g., "01" for the first day of the month), "HH" represents the hour in 24-hour format as a two-digit number (e.g., "00" for midnight, "23" for 11 PM), "mm" represents the minute as a two-digit number (e.g., "00" for the top of the hour, "59" for one minute before the next hour), "ss" represents the second as a two-digit number (e.g., "00" for the start of a minute, "59" for one second before the next minute), and "fff" represents the milliseconds as a three-digit number (e.g., "000" for the start of a second, "999" for one millisecond before the next second). This format ensures that file names are unique and can be easily sorted chronologically when listed in a directory, making it ideal for scenarios such as logging, backups, or any situation where multiple files are generated over time and need to be organized by their creation date and time.
        /// </summary>
        public const string FileName = "yyyyMMddHHmmssfff";
    }
}
