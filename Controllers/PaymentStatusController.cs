using AutoMapper;
using DashboardApi.Context;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class PaymentStatusController(DashboardContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentStatus>>> GetPaymentStatus()
    {
        return await context.PaymentStatus.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaymentStatus>> GetPaymentStatusById(int id)
    {
        var payment = await context.PaymentStatus
            .AsNoTracking()
            .FirstOrDefaultAsync(p=>p.Id == id);

        if (payment == null)
            return NotFound();

        return payment;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutPaymentStatus(int id, UpdatePaymentStatusDto paymentStatusDto)
    {
        var paymentStatus = await context.PaymentStatus.FindAsync(id);
        if (paymentStatus == null)
            return NotFound();

        mapper.Map(paymentStatusDto, paymentStatus);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<PaymentStatus>> PostPaymentStatus(CreatePaymentStatusDto paymentStatusDto)
    {
        var paymentStatus = mapper.Map<PaymentStatus>(paymentStatusDto);

        context.PaymentStatus.Add(paymentStatus);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPaymentStatusById), new { id = paymentStatus.Id }, paymentStatus);
    }
}