namespace Verdict;

public interface IReason
{
    public Dictionary<string, object> Metadata { get; }
    public Dictionary<string, string> Errors { get; }
    public string Message { get; }
    public IReason AddMetadata(string key, object value);
    public IReason AddMetadata(Dictionary<string, object> metadata);
    public IReason AddError(Dictionary<string, string> errors);
    public IReason SetMessage(string message);
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

    public IReason AddError(Dictionary<string, string> errors)
    {
        foreach (var kvp in errors)
        {
            Metadata[kvp.Key] = kvp.Value; // Overwrites if exists
        }

        return this;
    }

    public IReason AddMetadata(string key, object value)
    {
        Metadata[key] = value; // Overwrites if exists
        return this;
    }

    public IReason AddMetadata(Dictionary<string, object> metadata)
    {
        foreach (var kvp in metadata)
        {
            AddMetadata(kvp.Key, kvp.Value);
        }

        return this;
    }

    public IReason SetMessage(string message)
    {
        if (!string.IsNullOrWhiteSpace(Message)) return this;

        Message = message;
        return this;
    }
}