﻿using AutoMapper;
using DashboardApi.Data;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController(DashboardContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await context.Users.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u=>u.Id == id);

        if (user == null)
            return NotFound();

        return user;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutUser(int id, UpdateUserDto userDto)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
            return NotFound();

        mapper.Map(userDto, user);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(CreateUserDto userDto)
    {
        var user = mapper.Map<User>(userDto);

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }
}