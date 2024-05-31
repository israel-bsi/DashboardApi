using System.Text.Json.Serialization;

namespace DashboardApi.Data.Models;

public class Project
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string AmountHours { get; set; } = null!;
    public DateTime RequestedAt { get; set; }
    public string Customer { get; set; } = null!;
    public decimal Value { get; set; }
    public int UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; } = null!;
    public int PaymentStatusId { get; set; }
    [JsonIgnore]
    public PaymentStatus PaymentStatus { get; set; } = null!;
    public DateTime LastUpdateAt { get; set; }
    [JsonIgnore]
    public IList<ProjectStatus> ProjectStats { get; set; } = null!;
    [JsonIgnore]
    public IList<Developer> Developers { get; set; } = null!;
}