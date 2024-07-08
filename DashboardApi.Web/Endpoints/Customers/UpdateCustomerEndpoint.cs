using DashboardApi.Core.Handler;
using DashboardApi.Core.Models;
using DashboardApi.Core.Request.Customer;
using DashboardApi.Core.Response;
using DashboardApi.Web.Common.Api;

namespace DashboardApi.Web.Endpoints.Customers;

public class UpdateCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder map)
    {
        map.MapPut("/{id}", HandlerAsync)
            .WithName("Customers: Update")
            .WithSummary("Atualiza um cliente")
            .WithDescription("Atualiza um cliente")
            .WithOrder(2)
            .Produces<Response<Customer?>>();
    }
    private static async Task<IResult> HandlerAsync(ICustomerHandler handler,
        UpdateCustomerRequest request, int id)
    {
        request.Id = id;
        var result = await handler.UpdateAsync(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}