using System.Text.Json.Serialization;

namespace Verdict.Web.Models;

[Serializable]
public class ErrorResponse
{
    [JsonPropertyOrder(1)] public int StatusCode { get; protected set; }
    [JsonPropertyOrder(2)] public string RequestId { get; protected set; } = string.Empty;
    [JsonPropertyOrder(3)] public string Path { get; protected set; } = string.Empty;
    [JsonPropertyOrder(4)] public string Message { get; protected set; } = string.Empty;
    [JsonPropertyOrder(5)] public string? ErrorCode { get; protected set; }
    [JsonPropertyOrder(6)] public Dictionary<string, string>? ValidationErrors { get; protected set; }

    private ErrorResponse() : base()
    {
    }

    public static ErrorResponse Create(int statusCode, string message, string requestId, string path)
    {
        return new ErrorResponse()
        {
            StatusCode = statusCode,
            Message = message,
            RequestId = requestId,
            Path = path,
        };
    }

    public void AddErrorCode(string errorCode) => ErrorCode = errorCode;
    public void AddValidationErrors(Dictionary<string, string> errors) => ValidationErrors = errors;
}