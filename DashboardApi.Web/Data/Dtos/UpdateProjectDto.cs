namespace DashboardApi.Web.Data.Dtos;

public class UpdateProjectDto
{
    public int Order { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string AmountHours { get; set; } = null!;
    public DateTime RequestedAt { get; set; }
    public string Customer { get; set; } = null!;
    public decimal Value { get; set; }
}