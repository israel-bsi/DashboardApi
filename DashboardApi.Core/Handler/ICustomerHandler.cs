using DashboardApi.Core.Models;
using DashboardApi.Core.Request.Customer;
using DashboardApi.Core.Response;

namespace DashboardApi.Core.Handler;

public interface ICustomerHandler
{
    Task<Response<Customer?>> CreateAsync(CreateCustomerRequest request);
    Task<Response<Customer?>> UpdateAsync(UpdateCustomerRequest request);
    Task<Response<Customer?>> DeleteAsync(DeleteCustomerRequest request);
    Task<Response<Customer?>> GetByIdAsync(GetCustomerByIdRequest request);
    Task<PagedResponse<List<Customer>>> GetAllAsync(GetAllCustomersRequest request);
}