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
        var metadata = verdict.GetContext().Metadata;
        
        var statusCode = (int)(StatusCodes)metadata[ContextConstant.StatusCode];
        var meta = metadata.TryGetValue(ContextConstant.Meta, out var metaObj) && metaObj is Meta castedMeta
            ? castedMeta
            : null;

        var response = Response.Success(verdict.GetValue(), meta, statusCode);
        return response.ToResult();
    }

    private static IResult ToError(IVerdict verdict)
    {
        var metadata = verdict.GetContext().Metadata;
        var context = verdict.GetContext();
        
        var statusCode = (int)(StatusCodes)metadata[ContextConstant.StatusCode];
        var message = context.Message;
        var errors = verdict.GetContext().Errors;

        var error = Error.Create(message)
            .AddValidationErrors(errors);

        var response = Response.Failed(error, statusCode);
        return response.ToResult();
    }
}