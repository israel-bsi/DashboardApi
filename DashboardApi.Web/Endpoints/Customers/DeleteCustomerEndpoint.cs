using DashboardApi.Core.Models;
using DashboardApi.Core.Response;
using DashboardApi.Web.Common.Api;
using DashboardApi.Core.Handler;
using DashboardApi.Core.Request.Customer;

namespace DashboardApi.Web.Endpoints.Customers;

public class DeleteCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder map)
    {
        map.MapDelete("/{id}", HandlerAsync)
            .WithName("Customers: Delete")
            .WithSummary("Deleta um cliente")
            .WithDescription("Deleta um cliente")
            .WithOrder(3)
            .Produces<Response<Customer?>>();
    }
    private static async Task<IResult> HandlerAsync(ICustomerHandler handler, int id)
    {
        var request = new DeleteCustomerRequest
        {
            Id = id
        };
        var result = await handler.DeleteAsync(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}