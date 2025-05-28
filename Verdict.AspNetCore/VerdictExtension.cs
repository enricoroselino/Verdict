namespace Verdict.AspNetCore;

public static class VerdictExtension
{
    public static Verdict<T> Ok<T>(this Verdict<T> verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.StatusCode, StatusEnum.Ok));
    }

    public static Verdict<T> Created<T>(this Verdict<T> verdict, string location = "")
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusEnum.Created)
                .AddMetadata(WebMetadata.Location, location));
    }

    public static Verdict NoContent(this Verdict verdict)
    {
        return verdict.WithReason(r => r.AddMetadata(WebMetadata.StatusCode, StatusEnum.NoContent));
    }

    public static Verdict NotFound(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusEnum.NotFound)
                .SetMessage(DefaultMessage.NotFound));
    }

    public static Verdict BadRequest(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusEnum.BadRequest)
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
            r.AddMetadata(WebMetadata.StatusCode, StatusEnum.Unauthorized)
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
            r.AddMetadata(WebMetadata.StatusCode, StatusEnum.Forbidden)
                .SetMessage(DefaultMessage.Forbidden));
    }

    public static Verdict UnprocessableEntity(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusEnum.UnprocessableEntity)
                .SetMessage(DefaultMessage.UnprocessableEntity));
    }

    public static Verdict Conflict(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusEnum.Conflict)
                .SetMessage(DefaultMessage.Conflict));
    }

    public static Verdict InternalServer(this Verdict verdict)
    {
        return verdict.WithReason(r =>
            r.AddMetadata(WebMetadata.StatusCode, StatusEnum.InternalServerError)
                .SetMessage(DefaultMessage.InternalServerError));
    }
}