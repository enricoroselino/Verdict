using Microsoft.AspNetCore.Http;
using Verdict.AspNetCore.Responses;

namespace Verdict.AspNetCore.Extensions;

public static class VerdictAspNetExtensions
{
    private const string ContentType = ErrorResponse.ContentType;

    public static IResult ToResult(this IVerdict verdict, HttpContext context)
    {
        return verdict.Status switch
        {
            VerdictStatus.Ok => verdict is Verdict ? Results.Ok() : Results.Ok(verdict.GetValue()),
            VerdictStatus.NoContent => Results.NoContent(),
            VerdictStatus.Created => Results.Created(verdict.Location, verdict.GetValue()),
            VerdictStatus.NotFound => NotFound(verdict, context),
            VerdictStatus.Forbidden => Forbidden(verdict, context),
            VerdictStatus.Unauthorized => Unauthorized(verdict, context),
            VerdictStatus.BadRequest => BadRequest(verdict, context),
            VerdictStatus.UnprocessableEntity => UnprocessableEntity(verdict, context),
            VerdictStatus.Conflict => Conflict(verdict, context),
            VerdictStatus.InternalError => ErrorResult(verdict),
            _ => throw new NotSupportedException("Verdict to result is not supported.")
        };
    }

    private static IResult UnprocessableEntity(IVerdict verdict, HttpContext context)
    {
        const int statusCode = StatusCodes.Status403Forbidden;
        var response = ErrorResponse.Create(context, statusCode, verdict.ErrorMessage);
        return Results.UnprocessableEntity(response);
    }

    private static IResult Forbidden(IVerdict verdict, HttpContext context)
    {
        const int statusCode = StatusCodes.Status403Forbidden;
        var response = ErrorResponse.Create(context, statusCode, verdict.ErrorMessage);
        return Results.Json(response, contentType: ContentType, statusCode: statusCode);
    }

    private static IResult NotFound(IVerdict verdict, HttpContext context)
    {
        const int statusCode = StatusCodes.Status404NotFound;
        var response = ErrorResponse.Create(context, statusCode, verdict.ErrorMessage);
        return Results.NotFound(response);
    }

    private static IResult BadRequest(IVerdict verdict, HttpContext context)
    {
        const int statusCode = StatusCodes.Status400BadRequest;
        var response = ErrorResponse.Create(context, statusCode, verdict.ErrorMessage);
        if (verdict.ValidationErrors is not null) response.AddValidationErrors(verdict.ValidationErrors);
        return Results.BadRequest(response);
    }

    private static IResult Conflict(IVerdict verdict, HttpContext context)
    {
        const int statusCode = StatusCodes.Status409Conflict;
        var response = ErrorResponse.Create(context, statusCode, verdict.ErrorMessage);
        return Results.Conflict(response);
    }

    private static IResult Unauthorized(IVerdict verdict, HttpContext context)
    {
        const int statusCode = StatusCodes.Status401Unauthorized;
        var response = ErrorResponse.Create(context, statusCode, verdict.ErrorMessage);
        if (!string.IsNullOrWhiteSpace(verdict.ErrorCode)) response.AddErrorCode(verdict.ErrorCode);
        return Results.Json(response, contentType: ContentType, statusCode: statusCode);
    }

    private static IResult ErrorResult(IVerdict verdict)
    {
        // exceptional event should have exceptional handling
        // this should be handled by GlobalExceptionHandler
        throw new InternalServerException(verdict.ErrorMessage);
    }
}