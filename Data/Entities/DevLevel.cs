using System.Text.Json.Serialization;

namespace DashboardApi.Data.Entities;

public class DevLevel
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    [JsonIgnore] public IReadOnlyCollection<Developer> Developers { get; set; } = null!;
}