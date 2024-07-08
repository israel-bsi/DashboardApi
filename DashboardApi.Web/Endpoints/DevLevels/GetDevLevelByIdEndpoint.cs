using DashboardApi.Core.Enums;
using DashboardApi.Core.Handler;
using DashboardApi.Core.Request.DevLevel;
using DashboardApi.Core.Response;
using DashboardApi.Web.Common.Api;

namespace DashboardApi.Web.Endpoints.DevLevels;

public class GetDevLevelByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder map)
    {
        map.MapGet("/{id:int}", HandlerAsync)
            .WithName("DevLevel: Get by id")
            .WithSummary("Recupera um niveis")
            .WithDescription("Valores são sempre fixos")
            .WithOrder(1)
            .Produces<Response<EDevLevel>>();
    }
    private static async Task<IResult> HandlerAsync(IDevLevelHandler handler, int id)
    {
        var request = new GetDevLevelByIdRequest()
        {
            Id = id
        };
        var result = await handler.GetById(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}