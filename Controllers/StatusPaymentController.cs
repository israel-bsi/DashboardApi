using DashboardApi.Context;
using DashboardApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class StatusPaymentController(DashboardContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatusPayment>>> GetStatusPayments()
    {
        return await context.StatusPayments.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StatusPayment>> GetStatusPayment(int id)
    {
        var statusPayment = await context.StatusPayments.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

        if (statusPayment == null)
            return NotFound();

        return statusPayment;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutStatusPayment(int id, StatusPayment statusPayment)
    {
        if (id != statusPayment.Id)
            return BadRequest();

        context.Entry(statusPayment).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.StatusPayments.Any(s => s.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<StatusPayment>> PostStatusPayment(StatusPayment statusPayment)
    {
        context.StatusPayments.Add(statusPayment);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetStatusPayment", new { id = statusPayment.Id }, statusPayment);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStatusPayment(int id)
    {
        var statusPayment = await context.StatusPayments.FindAsync(id);
        if (statusPayment == null)
            return NotFound();

        context.StatusPayments.Remove(statusPayment);
        await context.SaveChangesAsync();

        return NoContent();
    }
}