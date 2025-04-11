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
    public new static Verdict Failure() => new(VerdictStatus.Failure);
    public static Verdict<T> Success<T>(T value) => new(value);
    public static Verdict<T> Created<T>(T value) => new(value);
    public new static Verdict NoContent() => new(VerdictStatus.NoContent);

    public new static Verdict NotFound(string errorMessage) =>
        new(VerdictStatus.NotFound) { ErrorMessage = errorMessage };

    public new static Verdict Forbidden(string? errorMessage = null) => new(VerdictStatus.Forbidden)
        { ErrorMessage = errorMessage ?? "Forbidden" };

    public new static Verdict Unauthorized(string? errorMessage = null, string? errorCode = null) =>
        new(VerdictStatus.Unauthorized)
        {
            ErrorMessage = errorMessage ?? "Unauthorized",
            ErrorCode = errorCode,
        };

    public new static Verdict BadRequest(string errorMessage) =>
        new(VerdictStatus.BadRequest) { ErrorMessage = errorMessage };

    public new static Verdict BadRequest(Dictionary<string, string> errors) =>
        new(VerdictStatus.BadRequest)
            { ValidationErrors = errors, ErrorMessage = "One or more validation failures have occurred." };

    public new static Verdict UnprocessableEntity(string errorMessage) =>
        new(VerdictStatus.UnprocessableEntity) { ErrorMessage = errorMessage };

    public new static Verdict Conflict(string errorMessage) =>
        new(VerdictStatus.Conflict) { ErrorMessage = errorMessage };

    public new static Verdict InternalError(string errorMessage) =>
        new(VerdictStatus.InternalError) { ErrorMessage = errorMessage };
}