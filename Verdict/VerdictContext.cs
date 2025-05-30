namespace Verdict;

public abstract class VerdictContext : IVerdictContext
{
    public Dictionary<string, object> Metadata { get; }
    public string Message { get; private set; } = string.Empty;

    protected VerdictContext()
    {
        Metadata = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
    }

    protected VerdictContext(string message) : this()
    {
        Message = message;
    }

    public VerdictContext AddMetadata(string key, object value)
    {
        Metadata[key] = value; // Overwrites if exists
        return this;
    }

    public VerdictContext SetMessage(string message)
    {
        if (!string.IsNullOrWhiteSpace(Message)) return this;

        Message = message;
        return this;
    }
}