using System.Text.Json.Serialization;

namespace DashboardApi.Data.Models;

public class PaymentStatus
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    [JsonIgnore]
    public IList<Project>? Projects { get; set; }
}