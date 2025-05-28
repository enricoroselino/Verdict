namespace Verdict.Web;

public enum StatusEnum
{
    Ok = 200,
    NoContent = 204,
    Created = 201,
    Conflict = 409,
    Forbidden = 403,
    NotFound = 404,
    UnprocessableEntity = 422,
    Unauthorized = 401,
    BadRequest = 400,
    InternalServerError = 500,
}