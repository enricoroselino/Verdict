using System.Text.Json.Serialization;

namespace Verdict.AspNetCore.Responses;

public class ErrorBase
{
    protected ErrorBase()
    {
    }

    [JsonPropertyOrder(1)] public int StatusCode { get; protected set; }
    [JsonPropertyOrder(2)] public string RequestId { get; protected set; } = string.Empty;
    [JsonPropertyOrder(3)] public string Path { get; protected set; } = string.Empty;
    [JsonPropertyOrder(4)] public string Message { get; protected set; } = string.Empty;
    [JsonPropertyOrder(5)] public string? ErrorCode { get; protected set; }
    [JsonPropertyOrder(6)] public Dictionary<string, string>? ValidationErrors { get; protected set; }
}