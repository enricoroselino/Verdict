namespace Verdict;

public abstract class VerdictContext : IVerdictContext
{
    public Dictionary<string, object> Metadata { get; }
    public Dictionary<string, string> Errors { get; }
    public string Message { get; private set; } = string.Empty;

    protected VerdictContext()
    {
        Metadata = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        Errors = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }

    protected VerdictContext(string message) : this()
    {
        Message = message;
    }
    
    public VerdictContext AddErrors(Dictionary<string, string> errors)
    {
        foreach (var kvp in errors)
        {
            Metadata[kvp.Key] = kvp.Value; // Overwrites if exists
        }

        return this;
    }

    public VerdictContext AddMetadata(string key, object value)
    {
        Metadata[key] = value; // Overwrites if exists
        return this;
    }

    public VerdictContext AddMetadata(Dictionary<string, object> metadata)
    {
        foreach (var kvp in metadata)
        {
            AddMetadata(kvp.Key, kvp.Value);
        }

        return this;
    }

    public VerdictContext SetMessage(string message)
    {
        if (!string.IsNullOrWhiteSpace(Message)) return this;

        Message = message;
        return this;
    }
}