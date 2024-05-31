using AutoMapper;
using DashboardApi.Context;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class ProjectController(DashboardContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        return await context.Projects.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Project>> GetProjectById([FromRoute] int id)
    {
        var project = await context.Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(p=>p.Id == id);

        if (project == null)
            return NotFound();

        return project;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutProject([FromRoute] int id, [FromBody] UpdateProjectDto projectDto)
    {
       var project = await context.Projects.FindAsync(id);
        if (project == null)
            return NotFound();

        mapper.Map(projectDto, project);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Project>> PostProject([FromBody] CreateProjectDto projectDto)
    {
        var project = mapper.Map<Project>(projectDto);

        context.Projects.Add(project);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProject([FromRoute] int id)
    {
        var Project = await context.Projects.FindAsync(id);
        if (Project == null)
            return NotFound();

        context.Projects.Remove(Project);
        await context.SaveChangesAsync();

        return NoContent();
    }
}