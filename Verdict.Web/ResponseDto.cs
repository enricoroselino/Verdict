using Verdict.Web.Models;

namespace Verdict.Web;

public abstract class ResponseDto
{
    public int StatusCode { get; protected set; }
    public Error? Error { get; init; }

    public static ResponseDto<TData?> Build<TData>(int statusCode, TData data, Meta? meta = null) =>
        meta is null
            ? new ResponseDto<TData?>(data) { StatusCode = statusCode }
            : new ResponseDto<TData?>(data, meta) { StatusCode = statusCode };

    public static ResponseDto<TData> Build<TData>(int statusCode, Error error) =>
        new ResponseDto<TData>(error) { StatusCode = statusCode };
}

[Serializable]
public class ResponseDto<TData> : ResponseDto
{
    internal ResponseDto(TData? data, Meta meta)
    {
        Data = data;
        Meta = meta;
    }

    internal ResponseDto(TData? data) => Data = data;
    internal ResponseDto(Error error) => Error = error;

    public TData? Data { get; init; }
    public Meta? Meta { get; init; }
}