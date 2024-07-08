using DashboardApi.Core.Response;
using DashboardApi.Core;
using Microsoft.AspNetCore.Mvc;
using DashboardApi.Core.Models;
using DashboardApi.Web.Common.Api;
using DashboardApi.Core.Handler;
using DashboardApi.Core.Request.Customer;

namespace DashboardApi.Web.Endpoints.Customers;

public class GetAllCustomersEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder map)
    {
        map.MapGet("/", HandlerAsync)
            .WithName("Customers: Get All")
            .WithSummary("Recupera todas os clientes")
            .WithDescription("Recupera todos os clientes")
            .WithOrder(5)
            .Produces<PagedResponse<List<Customer>?>>();
    }
    private static async Task<IResult> HandlerAsync(ICustomerHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCustomersRequest()
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAllAsync(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}