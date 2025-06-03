using System.Text.Json;
using System.Text.Json.Serialization;
using Api.Models;
using LightResults;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace Api.LightResults;

public static class ResultExtension
{
    public static IResult ToMinimalApiResult<T>(this Result<T> result)
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        };

        if (result.IsSuccess(out var data, out var error))
        {
            var response = Response.Create(200, data);
            return Results.Json(response, options: options, statusCode: 200);
        }

        var statusCode = error.Metadata.TryGetValue("statusCode", out var codeObj) && codeObj is int code
            ? code
            : 500;

        var validation = error.Metadata
            .TryGetValue("errors", out var errorsObj) && errorsObj is IReadOnlyDictionary<string, string> errors
            ? errors
            : null;

        var errorResponse = ErrorResponse.Create(statusCode, error.Message);
        if (validation is not null) errorResponse.AddErrors(validation);

        return Results.Json(errorResponse, options: options, statusCode: statusCode);
    }
}