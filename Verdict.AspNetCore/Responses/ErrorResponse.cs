using Microsoft.AspNetCore.Http;

namespace Verdict.AspNetCore.Responses;

[Serializable]
public class ErrorResponse : ErrorBase
{
    private ErrorResponse() : base()
    {
    }

    public const string ContentType = "application/json";

    public static ErrorResponse Create(HttpContext context, int statusCode, string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = ContentType;

        return new ErrorResponse()
        {
            StatusCode = statusCode,
            Message = message,
            RequestId = context.TraceIdentifier,
            Path = context.Request.Path,
        };
    }

    public void AddErrorCode(string errorCode) => ErrorCode = errorCode;
    public void AddValidationErrors(Dictionary<string, string> errors) => ValidationErrors = errors;
}