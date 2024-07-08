//using AutoMapper;
//using DashboardApi.Core.Models;
//using DashboardApi.Web.Data;
//using DashboardApi.Web.Data.Dtos;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace DashboardApi.Web.Controllers;

//[Route("[controller]")]
//[ApiController]
//public class StatusController(AppDbContext context, IMapper mapper) : ControllerBase
//{
//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
//    {
//        return await context.Status.AsNoTracking().ToListAsync();
//    }

//    [HttpGet("{id:int}")]
//    public async Task<ActionResult<Status>> GetStatusById(int id)
//    {
//        var status = await context.Status
//            .AsNoTracking()
//            .FirstOrDefaultAsync(s => s.Id == id);

//        if (status == null)
//            return NotFound();

//        return status;
//    }

//    [HttpPut("{id:int}")]
//    public async Task<IActionResult> PutStatus(int id, UpdateStatusDto statusDto)
//    {
//        var status = await context.Status.FindAsync(id);
//        if (status == null)
//            return NotFound();

//        mapper.Map(statusDto, status);
//        await context.SaveChangesAsync();

//        return NoContent();
//    }

//    [HttpPost]
//    public async Task<ActionResult<Status>> PostStatus(CreateStatusDto statusDto)
//    {
//        var status = mapper.Map<Status>(statusDto);

//        context.Status.Add(status);
//        await context.SaveChangesAsync();

//        return CreatedAtAction(nameof(GetStatusById), new { id = status.Id }, status);
//    }
//}