using Microsoft.AspNetCore.Http;
using Verdict.Web.Constants;
using Verdict.Web.Models;
using StatusCodes = Verdict.Web.Constants.StatusCodes;

namespace Verdict.Web.AspNetCore;

public static class VerdictExtension
{
    public static IResult ToResult(this IVerdict verdict)
    {
        if (!verdict.GetContext().Metadata.Any())
            throw new InvalidOperationException("Please set web context to verdict context");

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
        var validationErrors = context.Errors;
        var errorCode = metadata.TryGetValue(ContextConstant.ErrorCode, out var errorObj)
            ? errorObj as string
            : null;

        var error = Error.Create(context.Message);
        if (validationErrors.Count > 0) error.AddValidationErrors(validationErrors);
        if (errorCode is not null) error.AddErrorCode(errorCode);

        var response = Response.Failed(error, statusCode);
        return response.ToResult();
    }
}