using DashboardApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeveloperController(AppDbContext context) : ControllerBase
{

    [HttpGet("GetAll")]
    public IActionResult GetAllDevelopers()
    {
        var devs = context.Developers.ToList();
        return Ok(devs);
    }

    [HttpGet("GetAllWithRole")]
    public IActionResult GetAllDevelopersWithRole()
    {
        var devs = context.Developers.Include(d => d.Devlevel).ToList();
        return Ok(devs);
    }
}