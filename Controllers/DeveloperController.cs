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
    public async Task<IActionResult> GetDevelopers()
    {
        var developers = await context.Developers
            .Include(dl=>dl.Devlevel)
            .AsNoTracking()
            .ToListAsync();
        return Ok(developers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDeveloper([FromRoute] int id)
    {
        var developer = await context.Developers
            .Include(dl=>dl.Devlevel)
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
    public async Task<IActionResult> PostDeveloper([FromBody] CreateDeveloperDto developerDto)
    {
        var developer = mapper.Map<Developer>(developerDto);

        context.Developers.Add(developer);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetDeveloper", new { id = developer.Id }, developer);
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