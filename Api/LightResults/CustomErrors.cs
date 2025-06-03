using LightResults;

namespace Api.LightResults;

public sealed class NotFound : Error
{
    public NotFound() : base()
    {
        Message = "The requested resource could not be found.";
        Metadata = new Dictionary<string, object>()
        {
            { "statusCode", StatusCodes.Status404NotFound },
        };
    }
}

public sealed class BadRequest : Error
{
    private const string DefaultMessage = "Your request could not be processed due to invalid or missing data.";

    public BadRequest(IReadOnlyDictionary<string, string> errors) : base()
    {
        Message = DefaultMessage;
        Metadata = new Dictionary<string, object>()
        {
            { "statusCode", StatusCodes.Status400BadRequest },
            { "errors", errors }
        };
    }

    public BadRequest() : base()
    {
        Message = DefaultMessage;
        Metadata = new Dictionary<string, object>()
        {
            { "statusCode", StatusCodes.Status400BadRequest },
        };
    }
}

public sealed class Unauthorized : Error
{
    public Unauthorized() : base()
    {
        Message = "You must be authenticated to access this resource.";
        Metadata = new Dictionary<string, object>()
        {
            { "statusCode", StatusCodes.Status401Unauthorized },
        };
    }
}

public sealed class Forbidden : Error
{
    public Forbidden() : base()
    {
        Message = "You do not have permission to access this resource.";
        Metadata = new Dictionary<string, object>()
        {
            { "statusCode", StatusCodes.Status403Forbidden },
        };
    }
}

public sealed class UnprocessableEntity : Error
{
    public UnprocessableEntity() : base()
    {
        Message = "Your request was understood but contains data that cannot be processed.";
        Metadata = new Dictionary<string, object>()
        {
            { "statusCode", StatusCodes.Status422UnprocessableEntity },
        };
    }
}

public sealed class Conflict : Error
{
    public Conflict() : base()
    {
        Message = "A resource with the same identifier already exists, causing a conflict.";
        Metadata = new Dictionary<string, object>()
        {
            { "statusCode", StatusCodes.Status409Conflict },
        };
    }
}

public sealed class InternalServer : Error
{
    public InternalServer() : base()
    {
        Message = "The server encountered an error while processing your request.";
        Metadata = new Dictionary<string, object>()
        {
            { "statusCode", StatusCodes.Status500InternalServerError },
        };
    }
}