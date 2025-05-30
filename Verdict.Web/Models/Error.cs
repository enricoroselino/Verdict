namespace Verdict.Web.Models;

[Serializable]
public class Error
{
    public string Message { get; protected set; } = string.Empty;
    public string? Code { get; protected set; }
    public Dictionary<string, string>? Validation { get; protected set; }

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

    public void AddErrorCode(string errorCode) => Code = errorCode;

    public void AddValidationErrors(Dictionary<string, string> errors) => Validation = errors;
}