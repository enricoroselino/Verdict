using System.Text.Json.Serialization;

namespace Verdict.Web.Models;

public class Meta
{
    internal Meta()
    {
    }

    [JsonPropertyOrder(1)] public int? Page { get; private set; }
    [JsonPropertyOrder(2)] public int? TotalPages { get; private set; }
    [JsonPropertyOrder(3)] public int? TotalCount { get; private set; }

    [JsonPropertyOrder(4)]
    public bool? HasNextPage => Page.HasValue && PageSize.HasValue ? Page * PageSize < TotalCount : null;

    [JsonPropertyOrder(5)] public bool? HasPreviousPage => Page.HasValue && PageSize.HasValue ? Page > 1 : null;
    [JsonPropertyOrder(6)] public int? PageSize { get; private set; }

    internal void AddPagination(Pagination pagination, int totalCount)
    {
        var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize);
        var isPageInvalid = pagination.Page > 1 && pagination.Page > totalPages;

        Page = isPageInvalid ? 1 : pagination.Page;
        TotalPages = totalPages == 0 ? 1 : totalPages;
        PageSize = pagination.PageSize;
        TotalCount = totalCount;
    }
}