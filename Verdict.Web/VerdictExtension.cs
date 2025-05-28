using Verdict.Web.Constants;

namespace Verdict.Web;

public static class VerdictExtension
{
    public static Verdict<T> Ok<T>(this Verdict<T> verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.StatusCode, StatusCodes.Ok));
    }

    public static Verdict<T> Created<T>(this Verdict<T> verdict, string location = "")
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusCodes.Created)
                .AddMetadata(WebMetadata.Location, location));
    }

    public static Verdict NoContent(this Verdict verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.StatusCode, StatusCodes.NoContent));
    }

    public static Verdict NotFound(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusCodes.NotFound)
                .SetMessage(DefaultMessage.NotFound));
    }

    public static Verdict BadRequest(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusCodes.BadRequest)
                .SetMessage(DefaultMessage.BadRequest));
    }

    public static Verdict BadRequest(this Verdict verdict, Dictionary<string, string> errors)
    {
        return verdict.BadRequest()
            .WithReason(r => r.AddError(errors));
    }

    public static Verdict Unauthorized(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusCodes.Unauthorized)
                .SetMessage(DefaultMessage.Unauthorized));
    }

    public static Verdict Unauthorized(this Verdict verdict, string errorCode)
    {
        return verdict.Unauthorized()
            .WithReason(r => r.AddMetadata(WebMetadata.ErrorCode, errorCode));
    }

    public static Verdict Forbidden(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusCodes.Forbidden)
                .SetMessage(DefaultMessage.Forbidden));
    }

    public static Verdict UnprocessableEntity(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusCodes.UnprocessableEntity)
                .SetMessage(DefaultMessage.UnprocessableEntity));
    }

    public static Verdict Conflict(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusCodes.Conflict)
                .SetMessage(DefaultMessage.Conflict));
    }

    public static Verdict InternalServer(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusCodes.InternalServerError)
                .SetMessage(DefaultMessage.InternalServerError));
    }
}