using DashboardApi.Core.Handler;
using DashboardApi.Core.Models;
using DashboardApi.Core.Request.Customer;
using DashboardApi.Core.Response;
using DashboardApi.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Web.Handler;

public class CustomerHandler(AppDbContext context) : ICustomerHandler
{
    public async Task<Response<Customer?>> CreateAsync(CreateCustomerRequest request)
    {
        try
        {
            var customer = new Customer
            {
                Name = request.Name,
            };

            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();

            return new Response<Customer?>(customer, 201, "Cliente criado com sucesso");
        }
        catch
        {
            return new Response<Customer?>(null, 500, "Não foi possível criar o cliente");
        }
    }
    public async Task<Response<Customer?>> UpdateAsync(UpdateCustomerRequest request)
    {
        try
        {
            var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (customer == null)
                return new Response<Customer?>(null, 404, "Cliente não encontrado");

            customer.Name = request.Name;

            context.Customers.Update(customer);
            await context.SaveChangesAsync();
            return new Response<Customer?>(customer, 200, "Cliente atualizado com sucesso");
        }
        catch
        {
            return new Response<Customer?>(null, 500, "Não foi possível atualizar o cliente");
        }
    }
    public async Task<Response<Customer?>> DeleteAsync(DeleteCustomerRequest request)
    {
        try
        {
            var category = context.Customers.FirstOrDefault(x => x.Id == request.Id);

            if (category == null)
                return new Response<Customer?>(null, 404, "Cliente não encontrada");

            context.Customers.Remove(category);
            await context.SaveChangesAsync();
            return new Response<Customer?>(category, message: "Cliente excluido com sucesso");
        }
        catch
        {
            return new Response<Customer?>(null, 500, "Não foi possivel excluir o cliente");
        }
    }
    public async Task<Response<Customer?>> GetByIdAsync(GetCustomerByIdRequest request)
    {
        try
        {
            var category = await context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id);

            return category is null
                ? new Response<Customer?>(null, 404, "Cliente não encontrada")
                : new Response<Customer?>(category);
        }
        catch
        {
            return new Response<Customer?>(null, 500, "Não foi possivel retornar o cliente");
        }
    }
    public async Task<PagedResponse<List<Customer>>> GetAllAsync(GetAllCustomersRequest request)
    {
        try
        {
            var query = context
                .Customers
                .AsNoTracking()
                .OrderBy(x => x.Name);

            var customers = await query
                .Skip((request.PageNumber - 1) * request.PageSize) // 1-1 = 0 -> 0 * 25 = 0 depois 2-1 = 1 -> 1 * 25 = 25
                .Take(request.PageSize) //25 itens
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Customer>>(customers, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Customer>>(null, 500, "Não foi possivel consultar os clientes");
        }
    }
}