using DashboardApi.Context;
using DashboardApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class StatusProjectController(DashboardContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatusProject>>> GetStatusProjects()
    {
        return await context.StatusProjects.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StatusProject>> GetStatusProject(int id)
    {
        var statusProject = await context.StatusProjects.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        if (statusProject == null)
            return NotFound();

        return statusProject;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutStatusProject(int id, StatusProject statusProject)
    {
        if (id != statusProject.Id)
            return BadRequest();

        context.Entry(statusProject).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.StatusProjects.Any(e => e.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<StatusProject>> PostStatusProject(StatusProject statusProject)
    {
        context.StatusProjects.Add(statusProject);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetStatusProject", new { id = statusProject.Id }, statusProject);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStatusProject(int id)
    {
        var statusProject = await context.StatusProjects.FindAsync(id);
        if (statusProject == null)
            return NotFound();

        context.StatusProjects.Remove(statusProject);
        await context.SaveChangesAsync();

        return NoContent();
    }
}