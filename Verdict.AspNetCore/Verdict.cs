namespace Verdict.AspNetCore;

public class Verdict : Verdict<Verdict>
{
    internal Verdict()
    {
    }


    private Verdict(VerdictStatus status) : base(status)
    {
    }

    public static Verdict Success() => new();
    public static Verdict<T> Success<T>(T value) => new(value);
    public new static Verdict Failure(string message) => new(VerdictStatus.Failure) { ErrorMessage = message };
    public static Verdict<T> Created<T>(T value) => new(value);
    public new static Verdict NoContent() => new(VerdictStatus.NoContent);

    public new static Verdict NotFound(string message) =>
        new(VerdictStatus.NotFound) { ErrorMessage = message };

    public new static Verdict Forbidden(string? message = null) => new(VerdictStatus.Forbidden)
        { ErrorMessage = message ?? "Forbidden" };

    public new static Verdict Unauthorized(string? message = null, string? errorCode = null) =>
        new(VerdictStatus.Unauthorized)
        {
            ErrorMessage = message ?? "Unauthorized",
            ErrorCode = errorCode,
        };

    public new static Verdict BadRequest(string message) =>
        new(VerdictStatus.BadRequest) { ErrorMessage = message };

    public new static Verdict BadRequest(Dictionary<string, string> errors) =>
        new(VerdictStatus.BadRequest)
            { ValidationErrors = errors, ErrorMessage = "One or more validation failures have occurred." };

    public new static Verdict UnprocessableEntity(string message) =>
        new(VerdictStatus.UnprocessableEntity) { ErrorMessage = message };

    public new static Verdict Conflict(string message) =>
        new(VerdictStatus.Conflict) { ErrorMessage = message };

    public new static Verdict InternalError(string message) =>
        new(VerdictStatus.InternalError) { ErrorMessage = message };
}