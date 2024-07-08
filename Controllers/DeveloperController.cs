using AutoMapper;
using DashboardApi.Data;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashboardApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly DashboardContext _context;
        private readonly IMapper _mapper;

        public DeveloperController(DashboardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> GetDevelopers()
        {
            var developers = await _context.Developers
                .AsNoTracking()
                .ToListAsync();

            return Ok(developers);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Developer>> GetDeveloperById(int id)
        {
            var developer = await _context.Developers
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);

            if (developer == null)
                return NotFound();

            return Ok(developer);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDeveloper(int id, UpdateDeveloperDto developerDto)
        {
            var developer = await _context.Developers.FindAsync(id);

            if (developer == null)
                return NotFound();

            _mapper.Map(developerDto, developer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Developer>> PostDeveloper(CreateDeveloperDto developerDto)
        {
            var developer = _mapper.Map<Developer>(developerDto);

            _context.Developers.Add(developer);

            var devLevel = await _context.DevLevels.FindAsync(developerDto.DevLevelId);
            if (devLevel == null)
                return BadRequest(new { error = "Invalid DevLevelId" });

            developer.Devlevel = devLevel;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeveloperById), new { id = developer.Id }, developer);
        }
    }
}