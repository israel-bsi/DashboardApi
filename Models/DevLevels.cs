using System.Text.Json.Serialization;

namespace DashboardApi.Models;

public class DevLevels
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
}