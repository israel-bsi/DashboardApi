using DashboardApi.Core.Enums;
using DashboardApi.Core.Handler;
using DashboardApi.Core.Response;
using DashboardApi.Core;
using DashboardApi.Core.Request.PaymentStatus;
using DashboardApi.Web.Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Web.Endpoints.PaymentStatus;

public class GetAllPaymentStatusEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder map)
    {
        map.MapGet("/", HandlerAsync)
            .WithName("PaymentStatus: Get All")
            .WithSummary("Recupera todos os status de pagamento")
            .WithDescription("Valores são sempre fixos")
            .WithOrder(2)
            .Produces<PagedResponse<List<EPaymentStatus>?>>();
    }
    private static async Task<IResult> HandlerAsync(IPaymentStatusHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllPaymentStatusRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAll(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}