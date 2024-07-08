using System.Text.Json.Serialization;

namespace DashboardApi.Core.Models;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool Adm { get; set; }
    [JsonIgnore] public IReadOnlyCollection<Project>? Projects { get; set; }
}