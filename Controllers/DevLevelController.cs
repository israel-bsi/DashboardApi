using AutoMapper;
using DashboardApi.Context;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Entities;
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
    public async Task<ActionResult<DevLevel>> GetDevLevelById(int id)
    {
        var devLevel = await context.DevLevels
            .AsNoTracking()
            .FirstOrDefaultAsync(d=>d.Id == id);
        
        if (devLevel == null)
            return NotFound();

        return devLevel;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutDevLevel(int id, UpdateDevLevelDto devLevelDto)
    {
        var devLevel = await context.DevLevels.FindAsync(id);
        if (devLevel == null)
            return NotFound();

        mapper.Map(devLevelDto, devLevel);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<DevLevel>> PostDevLevels(CreateDevLevelDto devLevelDto)
    {
        var devLevel = mapper.Map<DevLevel>(devLevelDto);

        context.DevLevels.Add(devLevel);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDevLevelById), new { id = devLevel.Id }, devLevel);
    }
}