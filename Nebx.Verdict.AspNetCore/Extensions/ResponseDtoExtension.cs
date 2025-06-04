using Microsoft.AspNetCore.Http;
using Nebx.Verdict.AspNetCore.Constants;
using Nebx.Verdict.AspNetCore.Models;

namespace Nebx.Verdict.AspNetCore.Extensions;

public static class ResponseDtoExtension
{
    public static IResult ToMinimalApiResult(this ResponseDto dto) =>
        Results.Json(
            dto,
            options: VerdictSerializerOption.MinimalApi,
            contentType: VerdictContentType.Json,
            statusCode: StatusCodes.Status200OK);
}