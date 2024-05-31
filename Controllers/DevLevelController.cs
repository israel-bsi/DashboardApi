using AutoMapper;
using DashboardApi.Context;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class DevLevelController(DashboardContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DevLevel>>> GetDevLevels()
    {
        return await context.DevLevels.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DevLevel>> GetDevLevelById([FromRoute] int id)
    {
        var devLevel = await context.DevLevels
            .AsNoTracking()
            .FirstOrDefaultAsync(d=>d.Id == id);
        
        if (devLevel == null)
            return NotFound();

        return devLevel;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutDevLevel([FromRoute] int id, [FromBody] UpdateDevLevelDto devLevelDto)
    {
        var devLevel = await context.DevLevels.FindAsync(id);
        if (devLevel == null)
            return NotFound();

        mapper.Map(devLevelDto, devLevel);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<DevLevel>> PostDevLevels([FromBody] CreateDevLevelDto devLevelDto)
    {
        var devLevel = mapper.Map<DevLevel>(devLevelDto);

        context.DevLevels.Add(devLevel);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDevLevelById), new { id = devLevel.Id }, devLevel);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDevLevels([FromRoute] int id)
    {
        var devLevel = await context.DevLevels.FindAsync(id);
        if (devLevel == null)
            return NotFound();

        context.DevLevels.Remove(devLevel);
        await context.SaveChangesAsync();

        return NoContent();
    }
}