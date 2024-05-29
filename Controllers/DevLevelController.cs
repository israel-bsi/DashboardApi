using DashboardApi.Context;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DevLevelController(AppDbContext context) : ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAllDevLevels()
    {
        var devLevelsList = context.DevLevels.ToList();
        return Ok(devLevelsList);
    }
}