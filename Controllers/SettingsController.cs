﻿using DashboardApi.Data;
using DashboardApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SettingsController(DashboardContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Settings>>> GetAllSettings()
    {
        var settings = await context.Settings.AsNoTracking().ToListAsync();
        return settings;
    }
}