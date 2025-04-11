namespace Verdict.AspNetCore;

public class InternalServerException : Exception
{
    private const string ErrorMessage = "An unexpected error occurred while processing your request.";

    public InternalServerException(string? message = null) : base(message ?? ErrorMessage)
    {
    }
}