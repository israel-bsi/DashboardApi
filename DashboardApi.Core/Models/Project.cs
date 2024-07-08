using System.Text.Json.Serialization;
using DashboardApi.Core.Enums;

namespace DashboardApi.Core.Models;

public class Project
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AmountHours { get; set; } = string.Empty;
    public DateTime RequestedAt { get; set; } = DateTime.Now;
    public decimal Value { get; set; }
    public int UserId { get; set; }
    public int CustomerId { get; set; }
    public string Requester { get; set; } = string.Empty;
    public string RequesterEmail { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public EPaymentStatus PaymentStatus { get; set; } = EPaymentStatus.Pendente;
    public DateTime LastUpdateAt { get; set; } = DateTime.Now;
    [JsonIgnore] public Customer Customer { get; set; } = null!;
    [JsonIgnore] public User User { get; set; } = null!;
    [JsonIgnore] public IList<ProjectStatus> ProjectStats { get; set; } = null!;
    [JsonIgnore] public IList<Developer> Developers { get; set; } = null!;
}