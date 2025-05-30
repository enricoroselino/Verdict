using Microsoft.AspNetCore.Http;
using Verdict.Web.Models;

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
        var context = verdict.GetContext();

        var statusCode = context.GetStatusCode();
        var location = context.GetLocation();
        var meta = context.GetResponseMeta();
        var payload = verdict.GetValue();

        var response = statusCode is StatusCodes.Status201Created
            ? Response.Success(payload, location)
            : Response.Success(payload, meta, statusCode);

        return response.ToResult();
    }

    private static IResult ToError(IVerdict verdict)
    {
        var context = verdict.GetContext();

        var statusCode = context.GetStatusCode();
        var errorCode = context.GetErrorCode();
        var validationErrors = context.GetValidationErrors();

        var error = Error.Create(context.Message);
        if (errorCode is not null) error.AddErrorCode(errorCode);
        if (validationErrors != null && validationErrors.Count > 0) error.AddValidationErrors(validationErrors);

        var response = Response.Failed(error, statusCode);
        return response.ToResult();
    }
}