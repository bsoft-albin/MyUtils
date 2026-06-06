using MyUtils.Constants;

namespace MyUtils.Models;

/// <summary>
/// A standard API response wrapper with data, status, and message.
/// </summary>
public class ApiResponse<T>
{
    /// <summary>
    /// Indicates whether the API request was successful. True for success, false for failure.
    /// </summary>
    public bool Success { get; set; }
    /// <summary>
    /// A human-readable message providing more details about the response. For successful responses, this can be a confirmation message. For failed responses, this should describe the error or reason for failure.
    /// </summary>
    public string Message { get; set; } = string.Empty;
    /// <summary>
    /// The actual data payload of the response. This will be of type T for successful responses, and can be null for failed responses or when there is no data to return.
    /// </summary>
    public T Data { get; set; } = default!;
    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    public int StatusCode { get; set; }
    /// <summary>
    /// A list of error messages, if any.
    /// </summary>
    public List<string> Errors { get; set; } = [];
    /// <summary>
    /// The timestamp when the response was created.
    /// </summary>
    public DateTime Timestamp => DateTimeConsts.CurrentUtcDate;

    /// <summary>
    /// Returns a successful response with the provided data and an optional message. Default message is "OK".
    /// </summary>
    /// <param name="data">The data to include in the response.</param>
    /// <param name="message">An optional message to include in the response.</param>
    /// <returns>An <see cref="ApiResponse{T}"/> instance representing the successful response.</returns>
    public static ApiResponse<T> Ok(T data, string message = HttpStatusMessages.OK) => new()
    {
        Success = true,
        StatusCode = HttpStatusCodes.OK,
        Message = message,
        Data = data
    };

    /// <summary>
    /// Returns a successful response indicating that a resource was created, with the provided data and an optional message. Default message is "Created".
    /// </summary>
    /// <param name="data">The data to include in the response.</param>
    /// <param name="message">An optional message to include in the response.</param>
    /// <returns>An <see cref="ApiResponse{T}"/> instance representing the created response.</returns>
    public static ApiResponse<T> Created(T data, string message = HttpStatusMessages.Created) => new()
    {
        Success = true,
        StatusCode = HttpStatusCodes.Created,
        Message = message,
        Data = data
    };

    /// <summary>
    /// Returns a failed response with a message, optional status code (default 400), and optional list of error details.
    /// </summary>
    /// <param name="message">The error message to include in the response.</param>
    /// <param name="statusCode">The HTTP status code of the response. Default is 400 (Bad Request).</param>
    /// <param name="errors">A list of error messages, if any.</param>
    /// <returns>An <see cref="ApiResponse{T}"/> instance representing the failed response.</returns>
    public static ApiResponse<T> Fail(string message, int statusCode = HttpStatusCodes.BadRequest, List<string>? errors = null) => new()
    {
        Success = false,
        StatusCode = statusCode,
        Message = message,
        Errors = errors ?? []
    };

    /// <summary>
    /// Returns a failed response indicating that the requested resource was not found, with an optional message. Default message is "Not Found".
    /// </summary>
    /// <param name="message">The error message to include in the response. Default is "Not Found".</param>
    /// <returns>An <see cref="ApiResponse{T}"/> instance representing the not found response.</returns>
    public static ApiResponse<T> NotFound(string message = HttpStatusMessages.NotFound) => new()
    {
        Success = false,
        StatusCode = HttpStatusCodes.NotFound,
        Message = message
    };

    /// <summary>
    /// Returns a failed response indicating that the request is unauthorized, with an optional message. Default message is "Unauthorized".
    /// </summary>
    /// <param name="message">The error message to include in the response. Default is "Unauthorized".</param>
    /// <returns>An <see cref="ApiResponse{T}"/> instance representing the unauthorized response.</returns>
    public static ApiResponse<T> Unauthorized(string message = HttpStatusMessages.Unauthorized) => new()
    {
        Success = false,
        StatusCode = HttpStatusCodes.Unauthorized,
        Message = message
    };

    /// <summary>
    /// Returns a failed response indicating that access to the requested resource is forbidden, with an optional message. Default message is "Forbidden".
    /// </summary>
    /// <param name="message">The error message to include in the response. Default is "Forbidden".</param>
    /// <returns>An <see cref="ApiResponse{T}"/> instance representing the forbidden response.</returns>
    public static ApiResponse<T> Forbidden(string message = HttpStatusMessages.Forbidden) => new()
    {
        Success = false,
        StatusCode = HttpStatusCodes.Forbidden,
        Message = message
    };

    /// <summary>
    /// Returns a failed response indicating that an internal server error occurred, with an optional message. Default message is "Internal Server Error".
    /// </summary>
    /// <param name="message">The error message to include in the response. Default is "Internal Server Error".</param>
    /// <returns>An <see cref="ApiResponse{T}"/> instance representing the server error response.</returns>
    public static ApiResponse<T> ServerError(string message = HttpStatusMessages.InternalServerError) => new()
    {
        Success = false,
        StatusCode = HttpStatusCodes.InternalServerError,
        Message = message
    };

    /// <summary>
    /// Returns a validation error response with a list of validation error messages. Status code is set to 422 Unprocessable Entity.
    /// </summary>
    /// <param name="errors">A list of validation error messages.</param>
    /// <returns>An <see cref="ApiResponse{T}"/> instance representing the validation error response.</returns>
    public static ApiResponse<T> ValidationError(List<string> errors) => new()
    {
        Success = false,
        StatusCode = HttpStatusCodes.UnProcessableEntity,
        Message = HttpStatusMessages.UnProcessableEntity,
        Errors = errors
    };
}

/// <summary>Non-generic version for responses with no data payload in response.</summary>
public class ApiResponse : ApiResponse<object?>
{
    /// <summary>
    /// Returns a successful response with an optional message. Default message is "Success".
    /// </summary>
    /// <param name="message">The message to include in the response.</param>
    /// <returns>A successful <see cref="ApiResponse"/> instance.</returns>
    public static ApiResponse Ok(string message = HttpStatusMessages.OK) => new()
    {
        Success = true, StatusCode = HttpStatusCodes.OK, Message = message
    };

    /// <summary>
    /// Returns a failed response with a message, optional status code (default 400), and optional list of error details.
    /// </summary>
    /// <param name="message">The message to include in the response.</param>
    /// <param name="statusCode">The HTTP status code for the response. Default is 400.</param>
    /// <param name="errors">A list of error details. Default is null.</param>
    /// <returns>A failed <see cref="ApiResponse"/> instance.</returns>
    public static new ApiResponse Fail(string message, int statusCode = HttpStatusCodes.BadRequest, List<string>? errors = null) => new()
    {
        Success = false, StatusCode = statusCode, Message = message, Errors = errors ?? []
    };
}
