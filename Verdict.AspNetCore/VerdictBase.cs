namespace Verdict.AspNetCore;

public abstract class VerdictBase<T> : IVerdict
{
    public T Payload { get; protected init; } = default!;
    public VerdictStatus Status { get; protected init; } = VerdictStatus.Ok;
    public bool IsSuccess => Status is VerdictStatus.Ok or VerdictStatus.NoContent or VerdictStatus.Created;
    public string ErrorMessage { get; protected init; } = string.Empty;
    public string? ErrorCode { get; protected init; }
    public Dictionary<string, string>? ValidationErrors { get; protected init; }
    public string Location { get; protected init; } = string.Empty;
    public object? GetValue() => Payload;
}