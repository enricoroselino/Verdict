using Microsoft.AspNetCore.Http;

namespace Verdict.AspNetCore;

public enum StatusEnum
{
    Ok = StatusCodes.Status200OK,
    NoContent = StatusCodes.Status204NoContent,
    Created = StatusCodes.Status201Created,
    Conflict = StatusCodes.Status409Conflict,
    Forbidden = StatusCodes.Status403Forbidden,
    NotFound = StatusCodes.Status404NotFound,
    UnprocessableEntity = StatusCodes.Status422UnprocessableEntity,
    Unauthorized = StatusCodes.Status401Unauthorized,
    BadRequest = StatusCodes.Status400BadRequest,
    InternalServerError = StatusCodes.Status500InternalServerError,
}