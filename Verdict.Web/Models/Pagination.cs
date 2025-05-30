namespace Verdict.Web.Models;

public record Pagination
{
    public int Page { get; }
    public int PageSize { get; }
    public int Offset => (Page - 1) * PageSize;

    public Pagination(int page, int pageSize = 10)
    {
        if (page <= 0) throw new ArgumentException("Page must be greater than zero.");
        if (pageSize <= 0) throw new ArgumentException("Page size must be greater than zero.");

        Page = page;
        PageSize = pageSize;
    }
}