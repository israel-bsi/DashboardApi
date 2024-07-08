using DashboardApi.Core.Handler;
using DashboardApi.Core.Models;
using DashboardApi.Core.Request.Customer;
using DashboardApi.Core.Response;
using DashboardApi.Web.Common.Api;

namespace DashboardApi.Web.Endpoints.Customers;

public class GetCustomerByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder map)
    {
        map.MapGet("/{id}", HandlerAsync)
            .WithName("Customers: Get by Id")
            .WithSummary("Recupera um cliente")
            .WithDescription("Recupera um cliente")
            .WithOrder(4)
            .Produces<Response<Customer?>>();
    }
    private static async Task<IResult> HandlerAsync(ICustomerHandler handler, int id)
    {
        var request = new GetCustomerByIdRequest()
        {
            Id = id
        };
        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}