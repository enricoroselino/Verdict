using Microsoft.AspNetCore.Http;

namespace Verdict.AspNetCore;

public static class VerdictExtension
{
    public static Verdict<T> Ok<T>(this Verdict<T> verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.StatusCode, StatusCodes.Status200OK));
    }

    public static Verdict<T> Created<T>(this Verdict<T> verdict, string location = "")
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusCodes.Status201Created)
                .AddMetadata(WebMetadata.Location, location));
    }

    public static Verdict NoContent(this Verdict verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.StatusCode, StatusCodes.Status204NoContent));
    }

    public static Verdict NotFound(this Verdict verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.ErrorCode, StatusCodes.Status404NotFound));
    }

    public static Verdict BadRequest(this Verdict verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.ErrorCode, StatusCodes.Status400BadRequest));
    }

    public static Verdict BadRequest(this Verdict verdict, Dictionary<string, string> errors)
    {
        return verdict.BadRequest()
            .WithReason(r => r.AddError(errors));
    }

    public static Verdict Unauthorized(this Verdict verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.ErrorCode, StatusCodes.Status401Unauthorized));
    }

    public static Verdict Unauthorized(this Verdict verdict, string errorCode)
    {
        return verdict.Unauthorized()
            .WithReason(r => r.AddMetadata(WebMetadata.ErrorCode, errorCode));
    }

    public static Verdict Forbidden(this Verdict verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.ErrorCode, StatusCodes.Status403Forbidden));
    }

    public static Verdict UnprocessableEntity(this Verdict verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.ErrorCode, StatusCodes.Status422UnprocessableEntity));
    }

    public static Verdict InternalServer(this Verdict verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.ErrorCode, StatusCodes.Status500InternalServerError));
    }
}