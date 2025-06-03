using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Nebx.Verdict.AspNetCore.Constants;
using Nebx.Verdict.AspNetCore.Models;

namespace Nebx.Verdict.AspNetCore.Extensions;

public static class VerdictToResultExtension
{
    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    public static IResult ToMinimalApiResult(
        this IVerdict verdict,
        IHttpContextAccessor accessor,
        VerdictSuccessType verdictSuccessType = VerdictSuccessType.Ok)
    {
        return verdict.IsSuccess
            ? CreateSuccessResponse(verdict, verdictSuccessType)
            : CreateErrorResponse(verdict, accessor);
    }

    private static IResult CreateSuccessResponse(IVerdict verdict, VerdictSuccessType verdictSuccessType)
    {
        return verdictSuccessType switch
        {
            VerdictSuccessType.Ok => verdict is Verdict ? Results.Ok() : Results.Ok(verdict.GetValue()),
            VerdictSuccessType.NoContent => Results.NoContent(),
            VerdictSuccessType.Created => Results.Created("", verdict.GetValue()),
            _ => throw new ArgumentOutOfRangeException(nameof(verdictSuccessType), verdictSuccessType, null)
        };
    }

    private static IResult CreateErrorResponse(IVerdict verdict, IHttpContextAccessor accessor)
    {
        var metadata = verdict.GetMetadata() ?? throw new InvalidOperationException("Metadata is null");
        var context = accessor.HttpContext ?? throw new InvalidOperationException("Http context is null");
        var statusCode = (int)metadata[VerdictHttpKey.StatusCode];

        var path = context.Request.Path;
        var requestId = context.TraceIdentifier;
        var response = ErrorDto.Create(verdict.Message, statusCode, path, requestId);

        var errors = verdict.GetErrors();
        if (errors != null) response.AddErrors(errors);

        return Results.Json(response, options: SerializerOptions, statusCode: response.StatusCode);
    }
}