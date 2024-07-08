namespace DashboardApi.Web.Common.Api;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder map);
}