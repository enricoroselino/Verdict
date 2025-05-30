namespace Verdict;

public interface IVerdictContext
{
    public Dictionary<string, object> Metadata { get; }
    public string Message { get; }
}