using DashboardApi.Context;
using DashboardApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class DevLevelsController(DashboardContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DevLevels>>> GetDevLevels()
    {
        return await context.DevLevels.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DevLevels>> GetDevLevels(int id)
    {
        var devLevels = await context.DevLevels.AsNoTracking().Where(d => d.Id == id).FirstOrDefaultAsync();

        if (devLevels == null)
            return NotFound();

        return devLevels;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutDevLevels(int id, DevLevels DevLevels)
    {
        if (id != DevLevels.Id)
            return BadRequest();

        context.Entry(DevLevels).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.DevLevels.Any(e => e.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<DevLevels>> PostDevLevels(DevLevels DevLevels)
    {
        context.DevLevels.Add(DevLevels);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetDevLevels", new { id = DevLevels.Id }, DevLevels);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDevLevels(int id)
    {
        var devLevels = await context.DevLevels.FindAsync(id);
        if (devLevels == null)
            return NotFound();

        context.DevLevels.Remove(devLevels);
        await context.SaveChangesAsync();

        return NoContent();
    }
}