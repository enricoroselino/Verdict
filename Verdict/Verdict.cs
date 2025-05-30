using Verdict.Contexts;

namespace Verdict;

public class Verdict<T> : IVerdict
{
    public T Payload { get; internal init; } = default!;
    public VerdictContext VerdictContext { get; internal init; } = null!;
    public bool IsSuccess => VerdictContext is Success;
    public bool IsFailure => !IsSuccess;
    public object? GetValue() => Payload;
    public IVerdictContext GetContext() => VerdictContext;

    public static implicit operator Verdict<T>(Verdict verdict) => new Verdict<T>()
    {
        VerdictContext = verdict.VerdictContext,
        Payload = default(T)!,
    };

    public static implicit operator Verdict(Verdict<T> verdict) => new Verdict()
    {
        VerdictContext = verdict.VerdictContext,
    };

    protected Verdict()
    {
    }

    internal Verdict(T value) => Payload = value;

    public static Verdict<T> Success(T value) => new Verdict<T>(value) { VerdictContext = new Success() };
    public static Verdict<T> Failed() => new Verdict<T>() { VerdictContext = new Failure() };
    public static Verdict<T> Failed(string message) => new Verdict<T>() { VerdictContext = new Failure(message) };

    public Verdict<T> WithContext(Action<VerdictContext> configure)
    {
        configure(VerdictContext);
        return this;
    }
}

public class Verdict : Verdict<Verdict>
{
    internal Verdict() : base()
    {
    }

    public static Verdict Success() => new Verdict() { VerdictContext = new Success() };
    public static Verdict<T> Success<T>(T value) => new Verdict<T>(value) { VerdictContext = new Success() };
    public new static Verdict Failed() => new Verdict() { VerdictContext = new Failure() };
    public new static Verdict Failed(string message) => new Verdict() { VerdictContext = new Failure(message) };

    public new Verdict WithContext(Action<VerdictContext> configure)
    {
        configure(VerdictContext);
        return this;
    }
}