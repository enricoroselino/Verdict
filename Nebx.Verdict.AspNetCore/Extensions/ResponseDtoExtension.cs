using Microsoft.AspNetCore.Http;
using Nebx.Verdict.AspNetCore.Constants;
using Nebx.Verdict.AspNetCore.Models;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace Nebx.Verdict.AspNetCore.Extensions;

public static class ResponseDtoExtension
{
    public static IResult ToMinimalApiResult<T>(this SuccessDto<T> dto)
    {
        return Results.Ok(dto);
    }
}