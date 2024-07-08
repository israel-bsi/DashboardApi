using AutoMapper;
using DashboardApi.Core.Models;
using DashboardApi.Web.Data;
using DashboardApi.Web.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Web.Controllers;

[Route("[controller]")]
[ApiController]
public class DeveloperController(AppDbContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Developer>>> GetDevelopers()
    {
        var developers = await context.Developers
            .AsNoTracking()
            .ToListAsync();

        return Ok(developers);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Developer>> GetDeveloperById(int id)
    {
        var developer = await context.Developers
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);

        if (developer == null)
            return NotFound();

        return Ok(developer);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutDeveloper(int id, UpdateDeveloperDto developerDto)
    {
        var developer = await context.Developers.FindAsync(id);

        if (developer == null)
            return NotFound();

        mapper.Map(developerDto, developer);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Developer>> PostDeveloper(CreateDeveloperDto developerDto)
    {
        var developer = mapper.Map<Developer>(developerDto);

        context.Developers.Add(developer);

        var devLevel = await context.DevLevels.FindAsync(developerDto.DevLevelId);
        if (devLevel == null)
            return BadRequest(new { error = "Invalid DevLevelId" });

        developer.Devlevel = devLevel;
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDeveloperById), new { id = developer.Id }, developer);
    }
}