using System.Text.Json.Serialization;

namespace DashboardApi.Core.Models;

public class PaymentStatus
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    [JsonIgnore] public IReadOnlyCollection<Project>? Projects { get; set; }
}