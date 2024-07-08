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
    public class StatusController : ControllerBase
    {
        private readonly DashboardContext _context;
        private readonly IMapper _mapper;

        public StatusController(DashboardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
        {
            return await _context.Status.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Status>> GetStatusById(int id)
        {
            var status = await _context.Status
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (status == null)
                return NotFound();

            return status;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutStatus(int id, UpdateStatusDto statusDto)
        {
            var status = await _context.Status.FindAsync(id);
            if (status == null)
                return NotFound();

            _mapper.Map(statusDto, status);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(CreateStatusDto statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);

            _context.Status.Add(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStatusById), new { id = status.Id }, status);
        }
    }
}