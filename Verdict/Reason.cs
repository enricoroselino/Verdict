namespace Verdict;

public interface IReason
{
    public Dictionary<string, object> Metadata { get; }
    public Dictionary<string, string> Errors { get; }
    public string Message { get; }
    public Reason AddMetadata(Dictionary<string, object> metadata);
    public Reason AddError(Dictionary<string, string> errors);
}

public abstract class Reason : IReason
{
    public Dictionary<string, object> Metadata { get; }
    public Dictionary<string, string> Errors { get; }
    public string Message { get; private set; } = string.Empty;

    protected Reason()
    {
        Metadata = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        Errors = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }

    protected Reason(string message) : this()
    {
        Message = message;
    }

    public Reason AddError(Dictionary<string, string> errors)
    {
        foreach (var kvp in errors)
        {
            Metadata[kvp.Key] = kvp.Value; // Overwrites if exists
        }

        return this;
    }

    public Reason AddMetadata(string key, object value)
    {
        Metadata[key] = value; // Overwrites if exists
        return this;
    }

    public Reason AddMetadata(Dictionary<string, object> metadata)
    {
        foreach (var kvp in metadata)
        {
            AddMetadata(kvp.Key, kvp.Value);
        }

        return this;
    }

    public Reason SetMessage(string message)
    {
        Message = message;
        return this;
    }
}