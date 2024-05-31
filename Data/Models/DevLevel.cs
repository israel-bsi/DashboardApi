using System.Text.Json.Serialization;

namespace DashboardApi.Data.Models;

public class DevLevel
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    [JsonIgnore]
    public IList<Developer> Developers { get; set; } = null!;
}