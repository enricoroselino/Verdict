using Microsoft.AspNetCore.Http;
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
        var metadata = new Dictionary<string, object> { [VerdictHttpKey.StatusCode] = statusCode };
        if (errors != null) verdict.WithErrors(errors);

        return verdict
            .WithMetadata(metadata)
            .SetMessage(message);
    }

    private static Nebx.Verdict.Verdict SetHttpError(
        this Nebx.Verdict.Verdict verdict,
        int statusCode,
        string message,
        IReadOnlyDictionary<string, string>? errors = null)
    {
        var metadata = new Dictionary<string, object> { [VerdictHttpKey.StatusCode] = statusCode };
        if (errors != null) verdict.WithErrors(errors);

        return verdict
            .WithMetadata(metadata)
            .SetMessage(message);
    }

    public static Verdict<T> NotFound<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError(StatusCodes.Status404NotFound, VerdictHttpMessage.NotFound);
        return verdict;
    }

    public static Nebx.Verdict.Verdict NotFound(this Nebx.Verdict.Verdict verdict)
    {
        verdict.SetHttpError(StatusCodes.Status404NotFound, VerdictHttpMessage.NotFound);
        return verdict;
    }

    public static Verdict<T> BadRequest<T>(this Verdict<T> verdict, IReadOnlyDictionary<string, string>? errors = null)
    {
        verdict.SetHttpError(StatusCodes.Status400BadRequest, VerdictHttpMessage.BadRequest, errors);
        return verdict;
    }

    public static Verdict BadRequest(this Verdict verdict, IReadOnlyDictionary<string, string>? errors = null)
    {
        verdict.SetHttpError(StatusCodes.Status400BadRequest, VerdictHttpMessage.BadRequest, errors);
        return verdict;
    }

    public static Verdict<T> Forbidden<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError(StatusCodes.Status403Forbidden, VerdictHttpMessage.Forbidden);
        return verdict;
    }

    public static Verdict Forbidden(this Verdict verdict)
    {
        verdict.SetHttpError(StatusCodes.Status403Forbidden, VerdictHttpMessage.Forbidden);
        return verdict;
    }

    public static Verdict<T> Unauthorized<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError(StatusCodes.Status401Unauthorized, VerdictHttpMessage.Unauthorized);
        return verdict;
    }

    public static Verdict Unauthorized(this Verdict verdict)
    {
        verdict.SetHttpError(StatusCodes.Status401Unauthorized, VerdictHttpMessage.Unauthorized);
        return verdict;
    }

    public static Verdict<T> UnprocessableEntity<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError(StatusCodes.Status422UnprocessableEntity, VerdictHttpMessage.UnprocessableEntity);
        return verdict;
    }

    public static Verdict UnprocessableEntity(this Verdict verdict)
    {
        verdict.SetHttpError(StatusCodes.Status422UnprocessableEntity, VerdictHttpMessage.UnprocessableEntity);
        return verdict;
    }

    public static Verdict<T> Conflict<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError(StatusCodes.Status409Conflict, VerdictHttpMessage.Conflict);
        return verdict;
    }

    public static Verdict Conflict(this Verdict verdict)
    {
        verdict.SetHttpError(StatusCodes.Status409Conflict, VerdictHttpMessage.Conflict);
        return verdict;
    }

    public static Verdict<T> InternalError<T>(this Verdict<T> verdict)
    {
        verdict.SetHttpError(StatusCodes.Status500InternalServerError, VerdictHttpMessage.InternalServerError);
        return verdict;
    }

    public static Verdict InternalError(this Verdict verdict)
    {
        verdict.SetHttpError(StatusCodes.Status500InternalServerError, VerdictHttpMessage.InternalServerError);
        return verdict;
    }
}