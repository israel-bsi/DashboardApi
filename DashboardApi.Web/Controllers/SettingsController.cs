//using DashboardApi.Core.Models;
//using DashboardApi.Web.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace DashboardApi.Web.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class SettingsController(AppDbContext context) : ControllerBase
//{
//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<Settings>>> GetAllSettings()
//    {
//        var settings = await context.Settings.AsNoTracking().ToListAsync();
//        return settings;
//    }
//}