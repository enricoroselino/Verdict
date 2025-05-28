namespace Verdict.Web.Models;

public class MetaBuilder
{
    private readonly Meta _meta = new();

    public MetaBuilder AddPagination(Pagination pagination, int totalCount)
    {
        _meta.AddPagination(pagination, totalCount);
        return this;
    }

    public Meta? Build() => _meta;
}