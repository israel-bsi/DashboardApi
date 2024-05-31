using System.Text.Json.Serialization;

namespace DashboardApi.Data.Models;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool Adm { get; set; }
    [JsonIgnore]
    public IList<Project>? Projects { get; set; }
}