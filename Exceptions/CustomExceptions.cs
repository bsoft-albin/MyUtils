namespace MyUtils.Exceptions;

/// <summary>
/// Thrown when a requested resource is not found.
/// Maps to HTTP 404.
/// </summary>
public class NotFoundException : Exception
{
    public string? ResourceName { get; }
    public object? ResourceKey { get; }

    public NotFoundException(string message) : base(message) { }

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
    public string? ErrorCode { get; }
    public List<string> Errors { get; }

    public BusinessException(string message, string? errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
        Errors = [message];
    }

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
    public ConflictException(string message) : base(message) { }

    public ConflictException(string resourceName, string detail) : base($"Conflict on {resourceName}: {detail}") { }
}

/// <summary>
/// Thrown when model/input validation fails with multiple field errors.
/// Maps to HTTP 422.
/// </summary>
public class ValidationException : Exception
{
    public Dictionary<string, string[]> Failures { get; }

    public ValidationException(Dictionary<string, string[]> failures) : base("One or more validation failures occurred.")
    {
        Failures = failures;
    }

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
    public string? ServiceName { get; } = serviceName;
}
