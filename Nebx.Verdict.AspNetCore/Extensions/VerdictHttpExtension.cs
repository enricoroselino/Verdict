using Nebx.Verdict.AspNetCore.Constants;

namespace Nebx.Verdict.AspNetCore.Extensions;

public static class VerdictHttpExtension
{
    private static Verdict<T> SetHttpError<T>(
        this Verdict<T> verdict,
        int statusCode,
        string message,
        IReadOnlyDictionary<string, string>? errors = null)
    {
        var metadata = new Dictionary<string, object> { [HttpKeys.StatusCode] = statusCode };
        if (errors != null) verdict.WithErrors(errors);

        return verdict
            .WithMetadata(metadata)
            .SetMessage(message);
    }

    private static Verdict SetHttpError(
        this Verdict verdict,
        int statusCode,
        string message,
        IReadOnlyDictionary<string, string>? errors = null)
    {
        var metadata = new Dictionary<string, object> { [HttpKeys.StatusCode] = statusCode };
        if (errors != null) verdict.WithErrors(errors);

        return verdict
            .WithMetadata(metadata)
            .SetMessage(message);
    }

    public static Verdict<T> NotFound<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.NotFound, DefaulHttpMessages.NotFound);
        return verdict;
    }

    public static Verdict NotFound(this Verdict verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.NotFound, DefaulHttpMessages.NotFound);
        return verdict;
    }

    public static Verdict<T> BadRequest<T>(this Verdict<T> verdict, IReadOnlyDictionary<string, string>? errors = null)
    {
        verdict.SetHttpError((int)HttpStatusCodes.BadRequest, DefaulHttpMessages.BadRequest, errors);
        return verdict;
    }

    public static Verdict BadRequest(this Verdict verdict, IReadOnlyDictionary<string, string>? errors = null)
    {
        verdict.SetHttpError((int)HttpStatusCodes.BadRequest, DefaulHttpMessages.BadRequest, errors);
        return verdict;
    }

    public static Verdict<T> Forbidden<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.Forbidden, DefaulHttpMessages.Forbidden);
        return verdict;
    }

    public static Verdict Forbidden(this Verdict verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.Forbidden, DefaulHttpMessages.Forbidden);
        return verdict;
    }

    public static Verdict<T> Unauthorized<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.Unauthorized, DefaulHttpMessages.Unauthorized);
        return verdict;
    }

    public static Verdict Unauthorized(this Verdict verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.Unauthorized, DefaulHttpMessages.Unauthorized);
        return verdict;
    }

    public static Verdict<T> UnprocessableEntity<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.UnprocessableEntity, DefaulHttpMessages.UnprocessableEntity);
        return verdict;
    }

    public static Verdict UnprocessableEntity(this Verdict verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.UnprocessableEntity, DefaulHttpMessages.UnprocessableEntity);
        return verdict;
    }

    public static Verdict<T> Conflict<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.Conflict, DefaulHttpMessages.Conflict);
        return verdict;
    }

    public static Verdict Conflict(this Verdict verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.Conflict, DefaulHttpMessages.Conflict);
        return verdict;
    }

    public static Verdict<T> InternalError<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.InternalServerError, DefaulHttpMessages.InternalServerError);
        return verdict;
    }

    public static Verdict InternalError(this Verdict verdict)
    {
        verdict.SetHttpError((int)HttpStatusCodes.InternalServerError, DefaulHttpMessages.InternalServerError);
        return verdict;
    }
}