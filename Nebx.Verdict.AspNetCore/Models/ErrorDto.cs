namespace Nebx.Verdict.AspNetCore.Models;

public record ErrorDto
{
    public int StatusCode { get; private set; }
    public string Message { get; private set; } = string.Empty;
    public string Path { get; private set; } = string.Empty;
    public string RequestId { get; private set; } = string.Empty;
    public IReadOnlyDictionary<string, string>? Errors { get; private set; }

    private ErrorDto()
    {
    }

    public static ErrorDto Create(string message, int statusCode, string path, string requestId)
    {
        return new ErrorDto()
        {
            StatusCode = statusCode,
            Message = message,
            Path = path,
            RequestId = requestId,
        };
    }

    public void AddErrors(IReadOnlyDictionary<string, string> errors)
    {
        if (errors.Count == 0) return;

        Errors = errors;
    }
}