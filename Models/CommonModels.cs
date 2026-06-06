using MyUtils.Constants;

namespace MyUtils.Models;

/// <summary>
/// A generic result type for service layer operations — avoids throwing exceptions for expected failures.
/// </summary>
public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;
    public T Value { get; private set; } = default!;
    public string Error { get; private set; } = string.Empty;
    public List<string> Errors { get; private set; } = [];

    private Result() { }

    public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };

    public static Result<T> Failure(string error) => new()
    {
        IsSuccess = false,
        Error = error,
        Errors = [error]
    };

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
    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;
    public string Error { get; private set; } = string.Empty;
    public List<string> Errors { get; private set; } = [];

    private Result() { }

    public static Result Success() => new() { IsSuccess = true };

    public static Result Failure(string error) => new()
    {
        IsSuccess = false,
        Error = error,
        Errors = [error]
    };

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
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    public SelectItem() { }
    public SelectItem(string label, string value) { Label = label; Value = value; }

    public static SelectItem From<T>(string label, T value) => new(label, value?.ToString() ?? string.Empty);
}

/// <summary>
/// A simple wrapper for returning file content from a service or controller.
/// </summary>
public class FileResult
{
    public byte[] Content { get; set; } = [];
    public string ContentType { get; set; } = "application/octet-stream";
    public string FileName { get; set; } = "download";

    public FileResult() { }

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
    public DateTime CreatedAt { get; set; } = DateTimeConsts.CurrentUtcDate;
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
}

/// <summary>
/// Base entity with a typed primary key — inherit in your EF Core entities.
/// </summary>
public abstract class BaseEntity<TKey> : AuditableEntity
{
    public TKey Id { get; set; } = default!;
}

/// <summary>Shorthand base entity with int PK.</summary>
public abstract class IntEntity : BaseEntity<int> { }

/// <summary>Shorthand base entity with Guid PK.</summary>
public abstract class GuidEntity : BaseEntity<Guid>
{
    protected GuidEntity() => Id = Guid.NewGuid();
}
