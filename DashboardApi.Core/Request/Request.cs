using System.Text.Json.Serialization;

namespace DashboardApi.Core.Request;

public class Request
{
    [JsonIgnore]
    public string UserId { get; set; } = string.Empty;
}