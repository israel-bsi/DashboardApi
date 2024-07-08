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
    public class PaymentStatusController : ControllerBase
    {
        private readonly DashboardContext _context;
        private readonly IMapper _mapper;

        public PaymentStatusController(DashboardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentStatus>>> GetPaymentStatus()
        {
            return await _context.PaymentStatus.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PaymentStatus>> GetPaymentStatusById(int id)
        {
            var payment = await _context.PaymentStatus
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (payment == null)
                return NotFound();

            return payment;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPaymentStatus(int id, UpdatePaymentStatusDto paymentStatusDto)
        {
            var paymentStatus = await _context.PaymentStatus.FindAsync(id);
            if (paymentStatus == null)
                return NotFound();

            _mapper.Map(paymentStatusDto, paymentStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PaymentStatus>> PostPaymentStatus(CreatePaymentStatusDto paymentStatusDto)
        {
            var paymentStatus = _mapper.Map<PaymentStatus>(paymentStatusDto);

            _context.PaymentStatus.Add(paymentStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaymentStatusById), new { id = paymentStatus.Id }, paymentStatus);
        }
    }
}