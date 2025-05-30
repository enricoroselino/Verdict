using Microsoft.AspNetCore.Http;
using Verdict.Web.Constants;
using Verdict.Web.Models;
using StatusCodes = Verdict.Web.Constants.StatusCodes;

namespace Verdict.Web.AspNetCore;

public static class VerdictExtension
{
    public static IResult ToResult(this IVerdict verdict)
    {
        return verdict.IsSuccess ? ToSuccess(verdict) : ToError(verdict);
    }

    private static IResult ToSuccess(IVerdict verdict)
    {
        var metadata = verdict.GetReason().Metadata;
        var statusCode = (int)(StatusCodes)metadata[ReasonContext.StatusCode];
        var meta = metadata.TryGetValue(ReasonContext.Meta, out var metaObj) && metaObj is Meta castedMeta
            ? castedMeta
            : null;

        var response = Response.Success(verdict.GetValue(), meta, statusCode);
        return response.ToResult();
    }

    private static IResult ToError(IVerdict verdict)
    {
        //TODO: add validation error
        var statusCode = (int)(StatusCodes)verdict.GetReason().Metadata[ReasonContext.StatusCode];
        var message = verdict.GetReason().Message;

        var error = Error.Create(message);
        var response = Response.Failed(error, statusCode);
        return response.ToResult();
    }
}