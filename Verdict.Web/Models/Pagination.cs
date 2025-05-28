using Ardalis.GuardClauses;

namespace Verdict.Web.Models;

public record Pagination
{
    public int Page { get; }
    public int PageSize { get; }
    public int Offset => (Page - 1) * PageSize;

    public const int DefaultSize = 10;
    private readonly HashSet<int> _permittedPageSizes = new HashSet<int>() {5, 10, 25};

    public Pagination(int page, int pageSize = DefaultSize)
    {
        _permittedPageSizes.Add(DefaultSize);
        if (!_permittedPageSizes.Contains(pageSize))
        {
            throw new ArgumentException($"Permitted page sizes are {string.Join(", ", _permittedPageSizes)}");
        }

        Page = Guard.Against.NegativeOrZero(page, nameof(page),
            exceptionCreator: () => new ArgumentException("Page must be greater than zero."));
        PageSize = Guard.Against.NegativeOrZero(pageSize, nameof(pageSize),
            exceptionCreator: () => new ArgumentException("Page size must be greater than zero."));
    }
}