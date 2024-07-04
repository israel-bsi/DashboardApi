using System.Text.Json.Serialization;

namespace DashboardApi.Data.Entities;

public class Developer
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int DevLevelId { get; set; }
    [JsonIgnore] public DevLevel Devlevel { get; set; } = null!;
    [JsonIgnore] public IReadOnlyCollection<Project>? Projects { get; set; }
}