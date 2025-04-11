namespace Verdict.AspNetCore;

public enum VerdictStatus
{
    Ok,
    Failure,
    NoContent,
    Created,
    NotFound,
    Forbidden,
    Unauthorized,
    BadRequest,
    UnprocessableEntity,
    Conflict,
    InternalError,
}