using DashboardApi.Core;
using DashboardApi.Core.Enums;
using DashboardApi.Core.Handler;
using DashboardApi.Core.Request.DevLevel;
using DashboardApi.Core.Response;
using DashboardApi.Web.Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Web.Endpoints.DevLevels;

public class GetAllDevLevelsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder map)
    {
        map.MapGet("/", HandlerAsync)
            .WithName("DevLevel: Get All")
            .WithSummary("Recupera todos os niveis")
            .WithDescription("Valores são sempre fixos")
            .WithOrder(2)
            .Produces<PagedResponse<List<EDevLevel>?>>();
    }
    private static async Task<IResult> HandlerAsync(IDevLevelHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllDevLevelsRequest()
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAll(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}