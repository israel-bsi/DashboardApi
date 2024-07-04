using AutoMapper;
using DashboardApi.Context;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Entities;
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
    public async Task<ActionResult<Project>> GetProjectById(int id)
    {
        var project = await context.Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(p=>p.Id == id);

        if (project == null)
            return NotFound();

        return project;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutProject(int id, UpdateProjectDto projectDto)
    {
       var project = await context.Projects.FindAsync(id);
        if (project == null)
            return NotFound();

        mapper.Map(projectDto, project);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Project>> PostProject(CreateProjectDto projectDto)
    {
        var project = mapper.Map<Project>(projectDto);

        context.Projects.Add(project);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
    }
}