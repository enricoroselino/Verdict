namespace Verdict;

public interface IVerdict
{
    public object? GetValue();
    public IVerdictContext GetContext();
    public bool IsSuccess { get; }
    public bool IsFailure { get; }
}