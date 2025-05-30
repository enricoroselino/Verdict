using Verdict.Web.Models;

namespace Verdict.Web;

public abstract class Response
{
    public int StatusCode { get; private init; }
    public Error? Error { get; init; }

    public static Response<TData> Build<TData>(TData data, Meta? meta = null, int statusCode = 200) =>
        meta is null
            ? new Response<TData>(data) { StatusCode = statusCode }
            : new Response<TData>(data, meta) { StatusCode = statusCode };

    public static Response<TData> Build<TData>(Error error, int statusCode = 200) =>
        new Response<TData>(error) { StatusCode = statusCode };
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

    public TData? Data { get; init; }
    public Meta? Meta { get; init; }
}