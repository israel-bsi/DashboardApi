using System.Text.Json.Serialization;
using DashboardApi.Core.Enums;

namespace DashboardApi.Core.Models;

public class Developer
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int DevLevelId { get; set; }
    [JsonIgnore] public EDevLevel Devlevel { get; set; } = EDevLevel.Junior;
    [JsonIgnore] public IReadOnlyCollection<Project>? Projects { get; set; }
}