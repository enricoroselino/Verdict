using Ardalis.GuardClauses;

namespace Verdict.Web.Models;

public record Pagination
{
    public int Page { get; }
    public int PageSize { get; }
    public int Offset => (Page - 1) * PageSize;

    public Pagination(int page, int pageSize = 10)
    {
        Page = Guard.Against.NegativeOrZero(page, nameof(page),
            exceptionCreator: () => new ArgumentException("Page must be greater than zero."));
        PageSize = Guard.Against.NegativeOrZero(pageSize, nameof(pageSize),
            exceptionCreator: () => new ArgumentException("Page size must be greater than zero."));
    }
}