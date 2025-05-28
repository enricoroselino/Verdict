namespace Verdict;

public interface IVerdict
{
    public object? GetValue();
    public IReason GetReason();
    public bool IsSuccess { get; }
    public bool IsFailure { get; }
}