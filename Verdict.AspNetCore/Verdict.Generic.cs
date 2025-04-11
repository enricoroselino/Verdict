namespace Verdict.AspNetCore;

public class Verdict<T> : VerdictBase<T>
{
    protected Verdict()
    {
    }

    internal Verdict(T payload) => Payload = payload;
    protected Verdict(VerdictStatus status) => Status = status;
    public static implicit operator T(Verdict<T> verdict) => verdict.Payload;
    public static implicit operator Verdict<T>(T value) => new(value);

    public static implicit operator Verdict<T>(Verdict verdict) => new(default(T)!)
    {
        Status = verdict.Status,
        ValidationErrors = verdict.ValidationErrors,
        ErrorMessage = verdict.ErrorMessage,
        ErrorCode = verdict.ErrorCode,
    };

    public static explicit operator Verdict(Verdict<T> verdict) => new()
    {
        Status = verdict.Status,
        ValidationErrors = verdict.ValidationErrors,
        ErrorMessage = verdict.ErrorMessage,
        ErrorCode = verdict.ErrorCode,
    };

    public static Verdict<T> Success(T value) => new(value);
    public static Verdict<T> Created(T value) => new(VerdictStatus.Created) { Payload = value };

    public static Verdict<T> Created(T value, string location) =>
        new(VerdictStatus.Created) { Payload = value, Location = location };

    public static Verdict<T> NoContent() => new(VerdictStatus.NoContent);

    public static Verdict<T> NotFound(string errorMessage) =>
        new(VerdictStatus.NotFound) { ErrorMessage = errorMessage };

    public static Verdict<T> Forbidden(string? errorMessage = null) => new(VerdictStatus.Forbidden)
        { ErrorMessage = errorMessage ?? "Forbidden" };

    public static Verdict<T> Unauthorized(string? errorMessage = null, string? errorCode = null) =>
        new(VerdictStatus.Unauthorized)
        {
            ErrorMessage = errorMessage ?? "Unauthorized",
            ErrorCode = errorCode
        };

    public static Verdict<T> BadRequest(string errorMessage) =>
        new(VerdictStatus.BadRequest) { ErrorMessage = errorMessage };

    public static Verdict<T> BadRequest(Dictionary<string, string> errors) =>
        new(VerdictStatus.BadRequest)
            { ValidationErrors = errors, ErrorMessage = "One or more validation failures have occurred." };

    public static Verdict<T> UnprocessableEntity(string errorMessage) =>
        new(VerdictStatus.UnprocessableEntity) { ErrorMessage = errorMessage };

    public static Verdict<T> Conflict(string errorMessage) =>
        new(VerdictStatus.Conflict) { ErrorMessage = errorMessage };

    public static Verdict<T> InternalError(string errorMessage) =>
        new(VerdictStatus.InternalError) { ErrorMessage = errorMessage };
}