namespace Nebx.Verdict.AspNetCore.Models;

public record ResponseDto
{
    public object? Data { get; private set; }
    public MetaDto? Meta { get; private set; }

    private ResponseDto()
    {
    }

    public static ResponseDto Create(object? data)
    {
        return new ResponseDto()
        {
            Data = data,
        };
    }

    public static ResponseDto Create(object? data, MetaDto meta)
    {
        return new ResponseDto()
        {
            Data = data,
            Meta = meta,
        };
    }
}