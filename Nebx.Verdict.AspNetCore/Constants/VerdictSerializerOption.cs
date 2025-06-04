using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nebx.Verdict.AspNetCore.Constants;

public static class VerdictSerializerOption
{
    public static readonly JsonSerializerOptions MinimalApi = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
}