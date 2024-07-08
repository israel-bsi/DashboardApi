namespace DashboardApi.Web.Data.Dtos;

public class CreateDeveloperDto
{
    public string Name { get; set; } = null!;
    public int DevLevelId { get; set; }
}