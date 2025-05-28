using System.Text.Json.Serialization;

namespace Verdict.Web.Models;

public abstract class Response
{
    public Error? Error { get; init; }

    public static Response<TData?> Build<TData>(TData data, Meta? meta = null) =>
        meta is null ? new Response<TData?>(data) : new Response<TData?>(data, meta);

    public static Response<TData> Build<TData>(Error error) => new Response<TData>(error);
}

[Serializable]
public class Response<TData> : Response
{
    internal Response(TData? data, Meta meta)
    {
        Data = data;
        Meta = meta;
    }

    internal Response(TData? data) => Data = data;
    internal Response(Error error) => Error = error;

    [JsonPropertyOrder(1)] public TData? Data { get; init; }
    [JsonPropertyOrder(2)] public Meta? Meta { get; init; }
}