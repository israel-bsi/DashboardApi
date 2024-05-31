using AutoMapper;
using DashboardApi.Context;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class StatusController(DashboardContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
    {
        return await context.Status.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Status>> GetStatusById([FromRoute] int id)
    {
        var status = await context.Status
            .AsNoTracking()
            .FirstOrDefaultAsync(s=>s.Id == id);

        if (status == null)
            return NotFound();

        return status;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutStatus([FromRoute] int id, [FromBody] UpdateStatusDto statusDto)
    {
        var status = await context.Status.FindAsync(id);
        if (status == null)
            return NotFound();

        mapper.Map(statusDto, status);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Status>> PostStatus([FromBody] CreateStatusDto statusDto)
    {
        var status = mapper.Map<Status>(statusDto);

        context.Status.Add(status);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStatusById), new { id = status.Id }, status);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStatus([FromRoute] int id)
    {
        var projectStats = await context.Status.FindAsync(id);
        if (projectStats == null)
            return NotFound();

        context.Status.Remove(projectStats);
        await context.SaveChangesAsync();

        return NoContent();
    }
}