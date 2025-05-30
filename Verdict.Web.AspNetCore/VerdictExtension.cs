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
        //TODO: check if any location in created
        var statusCode = (int)(StatusCodes)verdict.GetReason().Metadata[WebMetadata.StatusCode];
        var response = Response.Success(verdict.GetValue(), statusCode: statusCode);
        return response.ToResult();
    }

    private static IResult ToError(IVerdict verdict)
    {
        //TODO: add validation error
        var statusCode = (int)(StatusCodes)verdict.GetReason().Metadata[WebMetadata.StatusCode];
        var message = verdict.GetReason().Message;

        var error = Error.Create(message);
        var response = Response.Failed(error, statusCode);
        return response.ToResult();
    }
}