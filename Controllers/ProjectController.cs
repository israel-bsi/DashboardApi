using DashboardApi.Context;
using DashboardApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class ProjectController(DashboardContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        return await context.Projects.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Project>> GetProject(int id)
    {
        var project = await context.Projects.AsNoTracking().Where(p => p.Id == id).FirstOrDefaultAsync();

        if (project == null)
            return NotFound();

        return project;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutProject(int id, Project project)
    {
        if (id != project.Id)
            return BadRequest();

        context.Entry(project).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.Projects.Any(e => e.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Project>> PostProject(Project project)
    {
        context.Projects.Add(project);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetProject", new { id = project.Id }, project);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var Project = await context.Projects.FindAsync(id);
        if (Project == null)
            return NotFound();

        context.Projects.Remove(Project);
        await context.SaveChangesAsync();

        return NoContent();
    }
}