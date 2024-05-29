namespace DashboardApi.Models;

public class Project
{
    public int Id { get; set; }
    //public int? Title { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string AmountHours { get; set; } = null!;
    public DateTime RequestedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? ValidationInitiatedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public string Customer { get; set; } = null!;
    public decimal Value { get; set; }
    public int? StatusId { get; set; }
    //public int? DeveloperId { get; set; }
    public int? UserId { get; set; }
    public int? PaymentId { get; set; }
    public DateTime LastUpdateAt { get; set; }
}