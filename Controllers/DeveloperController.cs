using AutoMapper;
using DashboardApi.Context;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class DeveloperController(DashboardContext context, IMapper mapper) : ControllerBase
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
    public async Task<ActionResult<Developer>> GetDeveloperById([FromRoute] int id)
    {
        var developer = await context.Developers
            .AsNoTracking()
            .FirstOrDefaultAsync(d=>d.Id == id);

        if (developer == null)
            return NotFound();

        return Ok(developer);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutDeveloper([FromRoute]int id, [FromBody] UpdateDeveloperDto developerDto)
    {
        var developer = await context.Developers.FindAsync(id);

        if(developer == null)
            return NotFound();

        mapper.Map(developerDto, developer);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Developer>> PostDeveloper([FromBody] CreateDeveloperDto developerDto)
    {
        var developer = mapper.Map<Developer>(developerDto);

        context.Developers.Add(developer);

        var devLevel = await context.DevLevels.FindAsync(developerDto.DevLevelId);
        if (devLevel == null)
            return BadRequest(new {error = "Invalid DevLevelId" });

        developer.Devlevel = devLevel;
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDeveloperById), new { id = developer.Id }, developer);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDeveloper([FromRoute] int id)
    {
        var developer = await context.Developers.FindAsync(id);
        if (developer == null)
            return NotFound();

        context.Developers.Remove(developer);
        await context.SaveChangesAsync();

        return NoContent();
    }
}