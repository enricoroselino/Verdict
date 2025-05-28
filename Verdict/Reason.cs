namespace Verdict;

public interface IReason
{
    public Dictionary<string, object> Metadata { get; }
    public Dictionary<string, string> Errors { get; }
    public string Message { get; }
}

public abstract class Reason : IReason
{
    public Dictionary<string, object> Metadata { get; }
    public Dictionary<string, string> Errors { get; }
    public string Message { get; protected set; } = string.Empty;

    protected Reason()
    {
        Metadata = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        Errors = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }

    protected Reason(string message) : this()
    {
        Message = message;
    }

    public Reason AddError(string key, string value)
    {
        Errors.Add(key, value);
        return this;
    }

    public Reason AddMetadata(string key, object value)
    {
        Metadata.TryAdd(key, value);
        return this;
    }
}