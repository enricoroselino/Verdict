namespace Verdict;

public interface IReason
{
    public Dictionary<string, object> Metadata { get; }
    public Dictionary<string, string> Errors { get; }
    public string Message { get; }
}