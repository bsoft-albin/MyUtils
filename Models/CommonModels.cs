using MyUtils.Constants;

namespace MyUtils.Models;

/// <summary>
/// A generic result type for service layer operations — avoids throwing exceptions for expected failures.
/// </summary>
public class Result<T>
{
    /// <summary>
    /// Indicates whether the operation was successful. This property is set to true when the operation completes successfully, and false when it fails. The IsSuccess property allows developers to easily check the outcome of an operation without needing to inspect error messages or other details, providing a simple and intuitive way to determine if the operation succeeded or encountered issues. When IsSuccess is false, the Error and Errors properties can be used to provide more information about what went wrong during the operation, enabling better debugging and user feedback.
    /// </summary>
    public bool IsSuccess { get; private set; }

    /// <summary>
    /// Indicates whether the operation failed. This property is the logical negation of IsSuccess, meaning it will be true when IsSuccess is false and vice versa. The IsFailure property provides a convenient way to check for failure conditions without needing to directly reference the IsSuccess property, allowing for more readable code when handling error scenarios. When IsFailure is true, developers can refer to the Error and Errors properties to gain insights into the specific issues that caused the operation to fail, facilitating better error handling and user communication.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// The value resulting from a successful operation. This property is only meaningful when IsSuccess is true, indicating that the operation completed successfully and produced a valid result. When IsSuccess is false, the Value property should not be accessed, as it may contain default or invalid data. The Value property allows for returning specific data from an operation without needing to throw exceptions for expected failure scenarios, enabling a more functional programming style where the outcome of an operation can be easily checked and handled without relying on exception handling for control flow.
    /// </summary>
    public T Value { get; private set; } = default!;

    /// <summary>
    /// A string representing the main error message when the operation fails. This property is intended to provide a concise summary of the failure, making it easy for developers and users to quickly understand the primary issue that occurred during the operation. The Error property can be used to store a single error message that captures the essence of the failure, while the Errors list can be used to provide additional context or details about multiple issues that may have arisen during the operation. This design allows for both a quick reference to the main error and a more comprehensive view of all errors when needed.
    /// </summary>
    public string Error { get; private set; } = string.Empty;

    /// <summary>
    /// A list of error messages representing the issues that occurred during the operation. This allows for more detailed error reporting when multiple issues occur, providing a comprehensive view of what went wrong while still maintaining a primary error message for quick reference. The Errors property can be used to store multiple error messages that may arise from different validation checks, exceptions, or other failure points within the operation, enabling better debugging and user feedback.
    /// </summary>
    public List<string> Errors { get; private set; } = [];

    private Result() { }

    /// <summary>
    /// Creates a success result with the provided value. This method is used when an operation completes successfully and needs to return a specific value. It sets the IsSuccess property to true, indicating that the operation was successful, and assigns the provided value to the Value property. The Error and Errors properties remain empty since there are no errors to report in a successful operation. This allows for a simple way to indicate success while also providing the relevant data that resulted from the operation, making it easy for callers to access the successful outcome without needing to check for errors or other conditions.
    /// </summary>
    /// <param name="value">The value resulting from the successful operation.</param>
    /// <returns>A Result object representing the successful outcome, containing the provided value.</returns>
    public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };

    /// <summary>
    /// Creates a failure result with a single error message. The provided error message is set as the main error message in the Error property, and it is also added to the Errors list for consistency. This allows for a simple way to create a failure result when only one error message is relevant, while still maintaining the structure of having both a primary error and a list of errors for potential future expansion or additional error messages.
    /// </summary>
    /// <param name="error">The error message representing the issue that occurred during the operation.</param>
    /// <returns>A Result object representing the failure, with the provided error message as the main error and the only entry in the Errors list.</returns>
    public static Result<T> Failure(string error) => new()
    {
        IsSuccess = false,
        Error = error,
        Errors = [error]
    };

    /// <summary>
    /// Creates a failure result with multiple errors. The first error in the list is used as the main error message, while the entire list is stored in the Errors property for reference. This allows for more detailed error reporting when multiple issues occur during an operation, providing a comprehensive view of what went wrong while still maintaining a primary error message for quick reference.
    /// </summary>
    /// <param name="errors">A list of error messages representing the issues that occurred during the operation.</param>
    /// <returns>A Result object representing the failure, with the first error as the main error message and the entire list of errors for reference.</returns>
    public static Result<T> Failure(List<string> errors) => new()
    {
        IsSuccess = false,
        Error = errors.FirstOrDefault() ?? "Unknown error",
        Errors = errors
    };

    /// <summary>Transforms the value if successful, otherwise propagates the failure.</summary>
    public Result<TOut> Map<TOut>(Func<T, TOut> transform) =>
        IsSuccess ? Result<TOut>.Success(transform(Value!)) : Result<TOut>.Failure(Errors);
}

/// <summary>Non-generic Result for operations that don't return a value.</summary>
public class Result
{
    /// <summary>
    /// Indicates whether the operation was successful. This property is set to true when the operation completes successfully, and false when it fails. The IsSuccess property allows developers to easily check the outcome of an operation without needing to inspect error messages or other details, providing a simple and intuitive way to determine if the operation succeeded or encountered issues. When IsSuccess is false, the Error and Errors properties can be used to provide more information about what went wrong during the operation, enabling better debugging and user feedback.
    /// </summary>
    public bool IsSuccess { get; private set; }

    /// <summary>
    /// Indicates whether the operation failed. This property is the logical negation of IsSuccess, meaning it will be true when IsSuccess is false and vice versa. The IsFailure property provides a convenient way to check for failure conditions without needing to directly reference the IsSuccess property, allowing for more readable code when handling error scenarios. When IsFailure is true, developers can refer to the Error and Errors properties to gain insights into the specific issues that caused the operation to fail, facilitating better error handling and user communication.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// A string representing the main error message when the operation fails. This property is intended to provide a concise summary of the failure, making it easy for developers and users to quickly understand the primary issue that occurred during the operation. The Error property can be used to store a single error message that captures the essence of the failure, while the Errors list can be used to provide additional context or details about multiple issues that may have arisen during the operation. This design allows for both a quick reference to the main error and a more comprehensive view of all errors when needed.
    /// </summary>
    public string Error { get; private set; } = string.Empty;

    /// <summary>
    /// A list of error messages representing the issues that occurred during the operation. This allows for more detailed error reporting when multiple issues occur, providing a comprehensive view of what went wrong while still maintaining a primary error message for quick reference. The Errors property can be used to store multiple error messages that may arise from different validation checks, exceptions, or other failure points within the operation, enabling better debugging and user feedback.
    /// </summary>
    public List<string> Errors { get; private set; } = [];

    private Result() { }

    /// <summary>
    /// Creates a success result without any value. This method is used when an operation completes successfully but does not need to return any specific data. It sets the IsSuccess property to true, indicating that the operation was successful, and leaves the Error and Errors properties empty since there are no errors to report. This allows for a simple way to indicate success in scenarios where the outcome of the operation is more important than any specific return value, such as when performing an action that modifies state or when the success of the operation is sufficient information for the caller.
    /// </summary>
    /// <returns>A new instance of Result representing a successful operation.</returns>
    public static Result Success() => new() { IsSuccess = true };

    /// <summary>
    /// Creates a failure result with a single error message. The provided error message is set as the main error message in the Error property, and it is also added to the Errors list for consistency. This allows for a simple way to create a failure result when only one error message is relevant, while still maintaining the structure of having both a primary error and a list of errors for potential future expansion or additional error messages.
    /// </summary>
    /// <param name="error">The error message representing the issue that occurred during the operation.</param>
    /// <returns>A new instance of Result representing a failure with the specified error.</returns>
    public static Result Failure(string error) => new()
    {
        IsSuccess = false,
        Error = error,
        Errors = [error]
    };

    /// <summary>
    /// Creates a failure result with multiple errors. The first error in the list is used as the main error message, while the entire list is stored in the Errors property for reference. This allows for more detailed error reporting when multiple issues occur during an operation, providing a comprehensive view of what went wrong while still maintaining a primary error message for quick reference.
    /// </summary>
    /// <param name="errors">A list of error messages representing the issues that occurred during the operation.</param>
    /// <returns>A new instance of Result representing a failure with the specified errors.</returns>
    public static Result Failure(List<string> errors) => new()
    {
        IsSuccess = false,
        Error = errors.FirstOrDefault() ?? "Unknown error",
        Errors = errors
    };
}

/// <summary>
/// Represents a key-value pair, e.g. for dropdowns and select lists.
/// </summary>
public class SelectItem
{
    /// <summary>
    /// The display label for the select item, which is typically shown to users in dropdowns, select lists, or other UI components where a selection is required. This label should be user-friendly and descriptive to help users understand what they are selecting. It can be a simple string that represents the option, such as "Option 1", "Active", "Inactive", or it can be more complex if needed (e.g., "United States (US)"). The Label property is essential for providing a clear and intuitive user experience when presenting selectable options in the UI.
    /// </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// The value associated with the select item, which is typically used in the backend or when processing the user's selection. This value can be a string that represents an identifier, code, or any relevant data that corresponds to the label. For example, if the label is "Active", the value might be "1" or "true". If the label is "United States (US)", the value might be "US". The Value property is crucial for handling the logic of user selections and can be used in form submissions, API calls, or any scenario where the selected option needs to be processed programmatically.
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the SelectItem class with default values. The Label and Value properties are initialized to empty strings, allowing for the creation of a SelectItem object without immediately providing specific values. This constructor can be useful in scenarios where the select item will be populated later or when creating a list of select items dynamically. It provides flexibility in how select items are created and allows for easy instantiation without requiring parameters at the time of object creation.
    /// </summary>
    public SelectItem() { }

    /// <summary>
    /// Initializes a new instance of the SelectItem class with the specified label and value. This constructor allows for creating a SelectItem object with both the display label and the associated value in a single step. The label parameter should be a user-friendly string that represents the option to be displayed in the UI, while the value parameter should be a string that represents the underlying data or identifier associated with that option. This constructor is useful for scenarios where you have both the label and value available at the time of creating the SelectItem object and want to set them directly without needing to assign them separately after instantiation.
    /// </summary>
    /// <param name="label">The display label for the select item.</param>
    /// <param name="value">The value associated with the select item.</param>
    public SelectItem(string label, string value) { Label = label; Value = value; }

    /// <summary>
    /// Creates a SelectItem from a label and a value of any type. The value is converted to a string using its ToString() method, and if the value is null, it defaults to an empty string. This static method provides a convenient way to create SelectItem instances without needing to manually convert values to strings before instantiation. It allows for flexibility in the types of values that can be used when creating select items, making it easier to work with various data types while still ensuring that the Value property is always a string suitable for use in UI components.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="label">The display label for the select item.</param>
    /// <param name="value">The value associated with the select item.</param>
    /// <returns>A new instance of SelectItem with the specified label and value.</returns>
    public static SelectItem From<T>(string label, T value) => new(label, value?.ToString() ?? string.Empty);
}

/// <summary>
/// A simple wrapper for returning file content from a service or controller.
/// </summary>
public class FileResult
{
    /// <summary>
    /// The file content as a byte array. This should contain the raw bytes of the file to be returned, which can be generated from various sources such as reading a file from disk, creating a file in memory, or receiving file content from an external service. The content will be sent to the client as part of the response when this FileResult is returned from a controller action or service method that handles file downloads.
    /// </summary>
    public byte[] Content { get; set; } = [];

    /// <summary>
    /// The MIME type of the file content, which indicates the type of file being returned (e.g., "application/pdf" for PDF files, "image/png" for PNG images, "text/plain" for plain text files). This information is important for the client to correctly handle and display the file. If not specified, it defaults to "application/octet-stream", which is a generic binary stream that can be used for any type of file but may not provide optimal handling on the client side. Setting the appropriate content type can enhance the user experience by allowing browsers and other clients to recognize and process the file correctly (e.g., displaying an image in the browser instead of prompting for download).
    /// </summary>
    public string ContentType { get; set; } = "application/octet-stream";

    /// <summary>
    /// The name of the file to be returned, which will be used as the default file name when the client downloads the file. This should include the appropriate file extension (e.g., "report.pdf", "image.png", "data.csv") to help clients recognize the file type and handle it accordingly. If not specified, it defaults to "download", which may not provide enough context for the user about the file's content or type. Providing a meaningful file name can improve the user experience by making it clear what the file contains and allowing for easier organization and retrieval on the client's device after download.
    /// </summary>
    public string FileName { get; set; } = "download";

    /// <summary>
    /// Initializes a new instance of the FileResult class with default values. The Content property is initialized to an empty byte array, the ContentType is set to "application/octet-stream" (a generic binary stream), and the FileName is set to "download". This constructor allows for creating a FileResult object without immediately providing file content, content type, or file name, which can be useful in scenarios where these values will be set later or when returning an empty file result as a placeholder.
    /// </summary>
    public FileResult() { }

    /// <summary>
    /// Initializes a new instance of the FileResult class with the specified content, content type, and file name. This constructor allows for creating a FileResult object with all necessary information for returning a file in a single step. The content parameter should contain the raw bytes of the file to be returned, the contentType parameter should specify the MIME type of the file, and the fileName parameter should provide a meaningful name for the file that includes the appropriate extension. This constructor is useful for scenarios where you have all the required information available at the time of creating the FileResult object and want to return it directly from a controller action or service method that handles file downloads.
    /// </summary>
    /// <param name="content">The raw bytes of the file to be returned.</param>
    /// <param name="contentType">The MIME type of the file content.</param>
    /// <param name="fileName">The name of the file to be returned, including the appropriate file extension.</param>
    public FileResult(byte[] content, string contentType, string fileName)
    {
        Content = content;
        ContentType = contentType;
        FileName = fileName;
    }
}

/// <summary>
/// Standard audit fields — inherit in your EF Core entities.
/// </summary>
public abstract class AuditableEntity
{
    /// <summary>
    /// The date and time when the entity was created. Initialized to the current UTC date and time by default.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTimeConsts.CurrentUtcDate;

    /// <summary>
    /// The date and time when the entity was last updated. This field is nullable to allow for entities that have not been updated since creation. It should be set to the current UTC date and time whenever the entity is modified and saved to the database.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// The identifier of the user who created the entity. This field is nullable to allow for entities that may be created by system processes or where user information is not available. It should be set to the appropriate user identifier (e.g., username, user ID) when the entity is created and saved to the database.
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// The identifier of the user who last updated the entity. This field is nullable to allow for entities that have not been updated since creation or where user information is not available. It should be set to the appropriate user identifier (e.g., username, user ID) whenever the entity is modified and saved to the database.
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Indicates whether the entity has been soft-deleted. Soft deletion allows for marking an entity as deleted without physically removing it from the database, enabling features like data recovery and audit trails. When this property is set to true, the entity should be treated as deleted in application logic, and typically, queries should be filtered to exclude soft-deleted entities unless explicitly requested. The DeletedAt property can be used to track when the entity was marked as deleted, providing additional context for auditing and potential recovery operations.
    /// </summary>
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// The date and time when the entity was soft-deleted. This field is nullable to allow for entities that have not been deleted. It should be set to the current UTC date and time when the entity is marked as deleted (i.e., when IsDeleted is set to true) and saved to the database. This information can be useful for auditing purposes, tracking deletion history, and implementing features like data recovery or automatic purging of old soft-deleted records.
    /// </summary>
    public DateTime? DeletedAt { get; set; }
}

/// <summary>
/// Base entity with a typed primary key — inherit in your EF Core entities.
/// </summary>
public abstract class BaseEntity<TKey> : AuditableEntity
{
    /// <summary>
    /// The primary key of the entity. The type is generic to allow flexibility (e.g., int, Guid, string).
    /// </summary>
    public TKey Id { get; set; } = default!;
}

/// <summary>Shorthand base entity with int PK.</summary>
public abstract class IntEntity : BaseEntity<int> { }

/// <summary>Shorthand base entity with Guid PK.</summary>
public abstract class GuidEntity : BaseEntity<Guid>
{
    /// <summary>
    /// Generates a new Guid for the Id when creating a new entity instance. This is useful for client-side creation before saving to the database.
    /// </summary>
    protected GuidEntity() => Id = Guid.NewGuid();
}
