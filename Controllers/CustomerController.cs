using AutoMapper;
using DashboardApi.Context;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Controllers;

[Route("[controller]")]
[ApiController]
public class CustomerController(DashboardContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await context.Customers
            .AsNoTracking()
            .ToListAsync();

        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
    {
        var customer = await context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c=>c.Id == id);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutCustomer(int id, CustomerDto customerDto)
    {
        var customerToUpdate = await context.Customers.FindAsync(id);

        if (customerToUpdate == null)
            return NotFound();

        mapper.Map(customerDto, customerToUpdate);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> PostCustomer(CustomerDto customerDto)
    {
        var customer = mapper.Map<Customer>(customerDto);

        context.Customers.Add(customer);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }
}