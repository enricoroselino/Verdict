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

    public Error AddErrorCode(string errorCode)
    {
        Code = errorCode;
        return this;
    }

    public Error AddValidationErrors(Dictionary<string, string> errors)
    {
        Validation = errors;
        return this;
    }
}