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
    public class DevLevelController : ControllerBase
    {
        private readonly DashboardContext _context;
        private readonly IMapper _mapper;

        public DevLevelController(DashboardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DevLevel>>> GetDevLevels()
        {
            return await _context.DevLevels.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DevLevel>> GetDevLevelById(int id)
        {
            var devLevel = await _context.DevLevels
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);

            if (devLevel == null)
                return NotFound();

            return devLevel;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDevLevel(int id, UpdateDevLevelDto devLevelDto)
        {
            var devLevel = await _context.DevLevels.FindAsync(id);
            if (devLevel == null)
                return NotFound();

            _mapper.Map(devLevelDto, devLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<DevLevel>> PostDevLevels(CreateDevLevelDto devLevelDto)
        {
            var devLevel = _mapper.Map<DevLevel>(devLevelDto);

            _context.DevLevels.Add(devLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDevLevelById), new { id = devLevel.Id }, devLevel);
        }
    }
}