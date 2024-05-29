using DashboardApi.Context;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProjectController(AppDbContext context) : ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAllProjects()
    {
        var projects = context.Projects.ToList();
        return Ok(projects);
    }
}