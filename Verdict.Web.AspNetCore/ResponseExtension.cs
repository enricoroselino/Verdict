using Microsoft.AspNetCore.Http;

namespace Verdict.Web.AspNetCore;

public static class ResponseExtension
{
    public static IResult ToResult<T>(this Response<T> response)
    {
        return Results.Json(response, options: SerializerOption.Value, statusCode: response.StatusCode);
    }

    public static IResult ToResult(this Response response)
    {
        return Results.Json(response, options: SerializerOption.Value, statusCode: response.StatusCode);
    }
}