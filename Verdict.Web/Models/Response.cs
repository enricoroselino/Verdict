using System.Text.Json.Serialization;

namespace Verdict.Web.Models;

public abstract class Response
{
    public static Response<TData> Build<TData>(TData data, Meta? meta = null) =>
        meta is null ? new Response<TData>(data) : new Response<TData>(data, meta);
}

[Serializable]
public class Response<TData> : Response
{
    internal Response(TData data, Meta meta)
    {
        Data = data;
        Meta = meta;
    }

    internal Response(TData data) => Data = data;

    [JsonPropertyOrder(1)] public TData Data { get; init; }
    [JsonPropertyOrder(2)] public Meta? Meta { get; init; }
}