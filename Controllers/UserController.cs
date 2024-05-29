using DashboardApi.Context;
using DashboardApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController(DashboardContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await context.Users.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await context.Users.AsNoTracking().Where(u => u.Id == id).FirstOrDefaultAsync();

        if (user == null)
            return NotFound();

        return user;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();

        context.Entry(user).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.Users.Any(e => e.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
            return NotFound();

        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return NoContent();
    }
}