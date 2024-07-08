using DashboardApi.Core.Handler;
using DashboardApi.Core.Models;
using DashboardApi.Core.Request.Customer;
using DashboardApi.Core.Response;
using DashboardApi.Web.Common.Api;

namespace DashboardApi.Web.Endpoints.Customers;

public class CreateCustomerEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder map)
    {
        map.MapPost("/", HandlerAsync)
            .WithName("Customers: Create")
            .WithSummary("Cria um novo cliente")
            .WithDescription("Cria um novo cliente")
            .WithOrder(1)
            .Produces<Response<Customer?>>();
    }
    private static async Task<IResult> HandlerAsync(ICustomerHandler handler,
        CreateCustomerRequest request)
    {
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
            ? Results.Created($"/{result.Data?.Id}", result)
            : Results.BadRequest(result);
    }
}