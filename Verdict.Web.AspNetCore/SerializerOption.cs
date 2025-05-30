using System.Text.Json;
using System.Text.Json.Serialization;

namespace Verdict.Web.AspNetCore;

public static class SerializerOption
{
    public static readonly JsonSerializerOptions Value = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
}