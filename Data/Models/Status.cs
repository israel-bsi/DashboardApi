using System.Text.Json.Serialization;

namespace DashboardApi.Data.Models;

public class Status
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    [JsonIgnore]
    public IList<Project>? Projects { get; set; }
    [JsonIgnore]
    public IList<ProjectStatus>? ProjectStats { get; set; }
}