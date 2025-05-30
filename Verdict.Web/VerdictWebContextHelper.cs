using Verdict.Web.Constants;
using Verdict.Web.Models;

namespace Verdict.Web;

public static class VerdictWebContextHelper
{
    public static Meta? GetResponseMeta(this IVerdictContext context)
    {
        var metadata = context.Metadata;
        var meta = metadata.TryGetValue(WebMetadataConstant.ResponseMeta, out var metaObj) && metaObj is Meta castedMeta
            ? castedMeta
            : null;

        return meta;
    }

    public static int GetStatusCode(this IVerdictContext context)
    {
        return (int)(StatusCodes)context.Metadata[WebMetadataConstant.StatusCode];
    }

    public static string? GetErrorCode(this IVerdictContext context)
    {
        var metadata = context.Metadata;
        var errorCode = metadata.TryGetValue(WebMetadataConstant.ErrorCode, out var errorObj)
            ? errorObj as string
            : null;

        return errorCode;
    }

    public static Dictionary<string, string>? GetValidationErrors(this IVerdictContext context)
    {
        var metadata = context.Metadata;
        var errors = metadata.TryGetValue(WebMetadataConstant.ValidationErrors, out var validationObj)
            ? validationObj as Dictionary<string, string>
            : null;

        return errors;
    }
}