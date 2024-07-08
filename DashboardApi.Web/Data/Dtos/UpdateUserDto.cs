namespace DashboardApi.Web.Data.Dtos;

public class UpdateUserDto
{
    public string Login { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool Adm { get; set; }
}