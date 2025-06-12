using Nebx.Verdict.AspNetCore.Constants;

namespace Nebx.Verdict.AspNetCore.Extensions;

public static class VerdictHttpHelper
{
    internal static Verdict<T> SetHttpError<T>(
        this Verdict<T> verdict,
        HttpStatusCodes statusCode,
        string message,
        IReadOnlyDictionary<string, string>? errors = null)
    {
        verdict.SetStatusCode(statusCode);
        verdict.SetMessage(message);
        if (errors != null) verdict.WithErrors(errors);

        return verdict;
    }

    internal static Verdict SetHttpError(
        this Verdict verdict,
        HttpStatusCodes statusCode,
        string message,
        IReadOnlyDictionary<string, string>? errors = null)
    {
        verdict.SetStatusCode(statusCode);
        verdict.SetMessage(message);
        if (errors != null) verdict.WithErrors(errors);

        return verdict;
    }

    internal static Verdict SetStatusCode(this Verdict verdict, HttpStatusCodes statusCode)
    {
        var metadata = new Dictionary<string, object> { [HttpKeys.StatusCode] = statusCode };
        return verdict.WithMetadata(metadata);
    }

    internal static Verdict<T> SetStatusCode<T>(this Verdict<T> verdict, HttpStatusCodes statusCode)
    {
        var metadata = new Dictionary<string, object> { [HttpKeys.StatusCode] = statusCode };
        return verdict.WithMetadata(metadata);
    }
}