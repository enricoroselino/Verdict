using System.Text.Json.Serialization;

namespace Verdict.Web.Models;

[Serializable]
public class Error
{
    [JsonPropertyOrder(2)] public string Message { get; protected set; } = string.Empty;
    [JsonPropertyOrder(3)] public string? ErrorCode { get; protected set; }
    [JsonPropertyOrder(4)] public Dictionary<string, string>? ValidationErrors { get; protected set; }

    private Error()
    {
    }

    public static Error Create(string message)
    {
        return new Error()
        {
            Message = message,
        };
    }

    public void AddErrorCode(string errorCode) => ErrorCode = errorCode;
    public void AddValidationErrors(Dictionary<string, string> errors) => ValidationErrors = errors;
}