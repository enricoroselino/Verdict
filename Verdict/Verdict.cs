namespace Verdict;

public interface IVerdict
{
    public object? GetValue();
    public Reason Reason { get; }
    public bool IsSuccess { get; }
    public bool IsFailure { get; }
}

public class Verdict<T> : IVerdict
{
    public T Payload { get; protected init; } = default!;
    public Reason Reason { get; protected init; } = null!;
    public bool IsSuccess => Reason is Success;
    public bool IsFailure => !IsSuccess;
    public object? GetValue() => Payload;

    public static implicit operator Verdict<T>(Verdict verdict) => new Verdict<T>()
    {
        Reason = verdict.Reason,
        Payload = default(T)!,
    };

    public static implicit operator Verdict(Verdict<T> verdict) => new Verdict()
    {
        Reason = verdict.Reason,
    };

    protected Verdict()
    {
    }

    internal Verdict(T value) => Payload = value;

    public static Verdict<T> Success(T value) => new Verdict<T>(value) { Reason = new Success() };

    public static Verdict<T> Failed(string message) => new Verdict<T>() { Reason = new Failure(message) };
}

public class Verdict : Verdict<Verdict>
{
    internal Verdict() : base()
    {
    }

    public static Verdict Success() => new Verdict() { Reason = new Success() };

    public static Verdict<T> Success<T>(T value) => new Verdict<T>(value) { Reason = new Success() };
    public new static Verdict Failed(string message) => new Verdict() { Reason = new Failure(message) };
}