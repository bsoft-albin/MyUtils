namespace MyUtils.Exceptions;

/// <summary>
/// Thrown when a requested resource is not found.
/// Maps to HTTP 404.
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Optional properties to provide more context about the missing resource, e.g. "User" and user ID.
    /// </summary>
    public string? ResourceName { get; }

    /// <summary>
    /// Optional key or identifier of the missing resource, e.g. user ID or email. This can be used to provide more specific error messages and for logging purposes to help identify which resource was not found.
    /// </summary>
    public object? ResourceKey { get; }

    /// <summary>
    /// Constructor that accepts a custom error message. This allows for flexibility in providing specific details about the not found resource, such as "User with ID 123 was not found." or "Product with SKU 'ABC123' was not found." By passing a custom message, developers can ensure that the error information is clear and relevant to the context of the failure, improving both debugging and user experience.
    /// </summary>
    /// <param name="message">The custom error message.</param>
    public NotFoundException(string message) : base(message) { }

    /// <summary>
    /// Constructor that accepts the resource name and key to generate a standardized error message. This constructor provides a convenient way to create a consistent error message format across the application, while still allowing for specific details about the missing resource. For example, if you call `new NotFoundException("User", 123)`, it will generate the message "User with key '123' was not found." This approach helps maintain uniformity in error handling and makes it easier for developers to understand the context of the error when it occurs.
    /// </summary>
    /// <param name="resourceName">The name of the missing resource.</param>
    /// <param name="resourceKey">The key or identifier of the missing resource.</param>
    public NotFoundException(string resourceName, object resourceKey) : base($"{resourceName} with key '{resourceKey}' was not found.")
    {
        ResourceName = resourceName;
        ResourceKey = resourceKey;
    }
}

/// <summary>
/// Thrown when a business rule or validation fails.
/// Maps to HTTP 400.
/// </summary>
public class BusinessException : Exception
{
    /// <summary>
    /// Optional error code to categorize the type of business error. This can be used by clients to programmatically handle specific error scenarios, such as "USER_ALREADY_EXISTS" or "INSUFFICIENT_FUNDS". By providing an error code, developers can create more robust error handling logic on the client side, allowing for better user feedback and automated responses based on the type of business rule violation that occurred.
    /// </summary>
    public string? ErrorCode { get; }

    /// <summary>
    /// List of error messages related to the business rule violation. This allows for multiple errors to be returned in a single response, which can be particularly useful for validation scenarios where multiple fields may have issues. For example, if a user submits a form with multiple invalid fields, the Errors list can contain messages for each field that failed validation, providing comprehensive feedback to the user about what needs to be corrected. This approach enhances the user experience by giving clear and actionable information about all the issues that need to be addressed.
    /// </summary>
    public List<string> Errors { get; }

    /// <summary>
    /// Constructor that accepts a single error message and an optional error code. This allows for quick and easy creation of a BusinessException when there is only one error to report. The provided message will be used as the exception message, and the error code can be used to categorize the error for client-side handling. If multiple errors need to be reported, the other constructor that accepts a list of errors can be used instead.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="errorCode">The optional error code.</param>
    public BusinessException(string message, string? errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
        Errors = [message];
    }

    /// <summary>
    /// Constructor that accepts a list of error messages and an optional error code. This allows for comprehensive reporting of multiple business rule violations in a single exception. The provided list of errors will be concatenated into a single message for the exception, while the individual errors can still be accessed through the Errors property. The error code can be used to categorize the type of business error for client-side handling, similar to the other constructor. This approach is particularly useful in scenarios like form validation, where multiple fields may have issues that need to be reported together.
    /// </summary>
    /// <param name="errors">The list of error messages.</param>
    /// <param name="errorCode">The optional error code.</param>
    public BusinessException(List<string> errors, string? errorCode = null) : base(string.Join("; ", errors))
    {
        ErrorCode = errorCode;
        Errors = errors;
    }
}

/// <summary>
/// Thrown when the current user is not authorized to perform an action.
/// Maps to HTTP 403.
/// </summary>
public class ForbiddenException(string message = "You do not have permission to perform this action.") : Exception(message)
{
}

/// <summary>
/// Thrown when authentication fails or credentials are missing.
/// Maps to HTTP 401.
/// </summary>
public class UnauthorizedException(string message = "Authentication is required.") : Exception(message)
{
}

/// <summary>
/// Thrown when an operation conflicts with the current state of a resource.
/// Maps to HTTP 409.
/// </summary>
public class ConflictException : Exception
{
    /// <summary>
    /// Constructor that accepts a custom error message. This allows for flexibility in providing specific details about the conflict, such as "User with email '
    /// </summary>
    /// <param name="message">The custom error message describing the conflict.</param>
    public ConflictException(string message) : base(message) { }

    /// <summary>
    /// Constructor that accepts the resource name and a detail message to generate a standardized error message. This constructor provides a convenient way to create a consistent error message format across the application, while still allowing for specific details about the conflict. For example, if you call `new ConflictException("User", "email already exists")`, it will generate the message "Conflict on User: email already exists." This approach helps maintain uniformity in error handling and makes it easier for developers to understand the context of the error when it occurs.
    /// </summary>
    /// <param name="resourceName">The name of the resource that caused the conflict.</param>
    /// <param name="detail">The detail message describing the conflict.</param>
    public ConflictException(string resourceName, string detail) : base($"Conflict on {resourceName}: {detail}") { }
}

/// <summary>
/// Thrown when model/input validation fails with multiple field errors.
/// Maps to HTTP 422.
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Dictionary of field names to their respective error messages. This allows for detailed reporting of validation errors for multiple fields in a structured way. For example, if a user submits a form with invalid data for multiple fields, the Failures dictionary can contain entries like "Email" => ["Email is required.", "Email must be a valid email address."] and "Password" => ["Password is required.", "Password must be at least 8 characters long."]. This structure makes it easier for clients to understand which fields have issues and what those issues are, enabling better user feedback and error handling on the client side.
    /// </summary>
    public Dictionary<string, string[]> Failures { get; }

    /// <summary>
    /// Constructor that accepts a dictionary of field errors. This allows for comprehensive reporting of validation errors for multiple fields in a single exception. The provided dictionary will be used to populate the Failures property, while the exception message can be a generic message indicating that validation failed. This approach is particularly useful in scenarios like form validation, where multiple fields may have issues that need to be reported together, providing clear and actionable information about what needs to be corrected.
    /// </summary>
    /// <param name="failures">The dictionary of field errors.</param>
    public ValidationException(Dictionary<string, string[]> failures) : base("One or more validation failures occurred.")
    {
        Failures = failures;
    }

    /// <summary>
    /// Constructor that accepts a single field and error message. This provides a convenient way to create a ValidationException when there is only one validation error to report. The provided field and error message will be used to populate the Failures dictionary, while the exception message can be a generic message indicating that validation failed. If multiple errors need to be reported, the other constructor that accepts a dictionary of failures can be used instead.
    /// </summary>
    /// <param name="field">The name of the field that caused the validation error.</param>
    /// <param name="error">The error message describing the validation failure.</param>
    public ValidationException(string field, string error) : base(error)
    {
        Failures = new Dictionary<string, string[]>
        {
            [field] = [error]
        };
    }
}

/// <summary>
/// Thrown when an external service or dependency call fails.
/// </summary>
public class ExternalServiceException(string serviceName, string message, Exception? innerException = null) : Exception($"[{serviceName}] {message}", innerException)
{
    /// <summary>
    /// The name of the external service that caused the exception. This can be used to provide more context about the source of the error, especially when multiple external services are involved in an application. For example, if a call to a payment gateway fails, the ServiceName could be set to "PaymentGateway", allowing developers and support teams to quickly identify which service is experiencing issues when reviewing logs or error reports.
    /// </summary>
    public string? ServiceName { get; } = serviceName;
}
