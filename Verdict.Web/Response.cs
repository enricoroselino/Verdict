using Verdict.Web.Models;

namespace Verdict.Web;

public class Response
{
    public int StatusCode { get; private init; }
    public Error? Error { get; init; }

    protected Response()
    {
    }

    private Response(Error error) => Error = error;

    public static Response<TData> Success<TData>(TData data, Meta? meta = null, int statusCode = 200) =>
        meta is null
            ? new Response<TData>(data) { StatusCode = statusCode }
            : new Response<TData>(data, meta) { StatusCode = statusCode };

    public static Response Failed(Error error, int statusCode) =>
        new Response(error) { StatusCode = statusCode };
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

    public TData? Data { get; init; }
    public Meta? Meta { get; init; }
}