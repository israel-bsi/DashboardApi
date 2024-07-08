using DashboardApi.Data;
using DashboardApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashboardApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly DashboardContext _context;

        public SettingsController(DashboardContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Settings>>> GetAllSettings()
        {
            var settings = await _context.Settings.AsNoTracking().ToListAsync();
            return settings;
        }
    }
}