using Verdict.Web.Constants;
using Verdict.Web.Models;

namespace Verdict.Web;

public static class VerdictStatusHelper
{
    public static Verdict<T> Ok<T>(this Verdict<T> verdict, Meta? meta = null)
    {
        verdict.WithContext(r => r.AddContext(ContextConstant.StatusCode, StatusCodes.Ok));
        if (meta is not null) verdict.WithContext(r => r.AddContext(ContextConstant.Meta, meta));
        return verdict;
    }

    public static Verdict<T> Created<T>(this Verdict<T> verdict, string location = "")
    {
        return verdict.WithContext(r =>
            r.AddContext(ContextConstant.StatusCode, StatusCodes.Created)
                .AddContext(ContextConstant.Location, location));
    }

    public static Verdict NoContent(this Verdict verdict)
    {
        return verdict.WithContext(r => r.AddContext(ContextConstant.StatusCode, StatusCodes.NoContent));
    }

    public static Verdict NotFound(this Verdict verdict)
    {
        return verdict.WithContext(r =>
            r.AddContext(ContextConstant.StatusCode, StatusCodes.NotFound)
                .SetMessage(DefaultMessage.NotFound));
    }

    public static Verdict BadRequest(this Verdict verdict)
    {
        return verdict.WithContext(r =>
            r.AddContext(ContextConstant.StatusCode, StatusCodes.BadRequest)
                .SetMessage(DefaultMessage.BadRequest));
    }

    public static Verdict BadRequest(this Verdict verdict, Dictionary<string, string> errors)
    {
        return verdict.BadRequest()
            .WithContext(r => r.AddErrors(errors));
    }

    public static Verdict Unauthorized(this Verdict verdict)
    {
        return verdict.WithContext(r =>
            r.AddContext(ContextConstant.StatusCode, StatusCodes.Unauthorized)
                .SetMessage(DefaultMessage.Unauthorized));
    }

    public static Verdict Unauthorized(this Verdict verdict, string errorCode)
    {
        return verdict.Unauthorized()
            .WithContext(r => r.AddContext(ContextConstant.ErrorCode, errorCode));
    }

    public static Verdict Forbidden(this Verdict verdict)
    {
        return verdict.WithContext(r =>
            r.AddContext(ContextConstant.StatusCode, StatusCodes.Forbidden)
                .SetMessage(DefaultMessage.Forbidden));
    }

    public static Verdict UnprocessableEntity(this Verdict verdict)
    {
        return verdict.WithContext(r =>
            r.AddContext(ContextConstant.StatusCode, StatusCodes.UnprocessableEntity)
                .SetMessage(DefaultMessage.UnprocessableEntity));
    }

    public static Verdict Conflict(this Verdict verdict)
    {
        return verdict.WithContext(r =>
            r.AddContext(ContextConstant.StatusCode, StatusCodes.Conflict)
                .SetMessage(DefaultMessage.Conflict));
    }

    public static Verdict InternalServer(this Verdict verdict)
    {
        return verdict.WithContext(r =>
            r.AddContext(ContextConstant.StatusCode, StatusCodes.InternalServerError)
                .SetMessage(DefaultMessage.InternalServerError));
    }
}