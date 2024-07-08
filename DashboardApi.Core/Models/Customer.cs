using System.Text.Json.Serialization;

namespace DashboardApi.Core.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    [JsonIgnore] public IReadOnlyCollection<Project>? Projects { get; set; }
}