using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Verdict.Web.Constants;
using Verdict.Web.Models;
using StatusCodes = Verdict.Web.Constants.StatusCodes;

namespace Verdict.Web.AspNetCore;

public class ResponseFactory
{
    private readonly IVerdict _verdict;

    public ResponseFactory(IVerdict verdict)
    {
        _verdict = verdict;
    }

    private static JsonSerializerOptions SerializerOptions => new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    };

    private const string ContentType = "application/json";

    public IResult Create()
    {
        var reason = _verdict.GetReason();
        var statusCode = (StatusCodes)reason.Metadata[WebMetadata.StatusCode];

        return statusCode switch
        {
            StatusCodes.Ok => _verdict is Verdict ? Results.Ok() : Results.Ok(_verdict.GetValue()),
            StatusCodes.NoContent => Results.NoContent(),
            StatusCodes.Created => Results.Created("", _verdict.GetValue()),
            StatusCodes.Conflict => BuildError(reason, (int)statusCode),
            StatusCodes.Forbidden => BuildError(reason, (int)statusCode),
            StatusCodes.NotFound => BuildError(reason, (int)statusCode),
            StatusCodes.UnprocessableEntity => BuildError(reason, (int)statusCode),
            StatusCodes.Unauthorized => BuildError(reason, (int)statusCode),
            StatusCodes.BadRequest => BuildError(reason, (int)statusCode),
            StatusCodes.InternalServerError => BuildError(reason, (int)statusCode),
            _ => throw new NotSupportedException("Verdict to result is not supported.")
        };
    }

    private static IResult BuildError(IReason reason, int statusCode)
    {
        var message = reason.Message;

        // please handle from global exception
        if (statusCode is 500) throw new Exception(message);

        var error = Error.Create(statusCode, message);
        return Results.Json(error, options: SerializerOptions, contentType: ContentType, statusCode: statusCode);
    }
}