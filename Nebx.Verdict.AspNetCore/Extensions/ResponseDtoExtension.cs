using Microsoft.AspNetCore.Http;
using Nebx.Verdict.AspNetCore.Models;

namespace Nebx.Verdict.AspNetCore.Extensions;

public static class ResponseDtoExtension
{
    public static IResult ToMinimalApiResult(this ResponseDto dto) => Results.Ok(dto);
}