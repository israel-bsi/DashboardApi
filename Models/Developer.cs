namespace DashboardApi.Models;

public class Developer
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int DevLevelId { get; set; }
    public virtual DevLevels? Devlevel { get; set; }
}