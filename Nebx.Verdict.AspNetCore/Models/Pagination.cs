namespace Nebx.Verdict.AspNetCore.Models;

public record Pagination
{
    public int Page { get; }
    public int PageSize { get; }
    public int Offset => (Page - 1) * PageSize;
    public const int DefaultSize = 10;

    public Pagination(int page, int pageSize = DefaultSize)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(page);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pageSize);

        Page = page;
        PageSize = pageSize;
    }
}