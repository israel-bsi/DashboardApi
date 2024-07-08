using DashboardApi.Core.Enums;
using DashboardApi.Core.Handler;
using DashboardApi.Core.Request.PaymentStatus;
using DashboardApi.Core.Response;
using DashboardApi.Web.Common.Api;

namespace DashboardApi.Web.Endpoints.PaymentStatus;

public class GetPaymentStatusByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder map)
    {
        map.MapGet("/{id:int}", HandlerAsync)
            .WithName("PaymentStatus: Get by id")
            .WithSummary("Recupera um status de pagamento")
            .WithDescription("Valores são sempre fixos")
            .WithOrder(1)
            .Produces<Response<EPaymentStatus>>();
    }
    private static async Task<IResult> HandlerAsync(IPaymentStatusHandler handler, int id)
    {
        var request = new GetPaymentStatusByIdRequest()
        {
            Id = id
        };
        var result = await handler.GetById(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}