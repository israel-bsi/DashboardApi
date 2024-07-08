using DashboardApi.Web.Common.Api;
using DashboardApi.Web.Endpoints.Customers;
using DashboardApi.Web.Endpoints.DevLevels;
using DashboardApi.Web.Endpoints.PaymentStatus;

namespace DashboardApi.Web.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("v1/customers")
            .WithTags("Customers")
            .MapEndpoint<CreateCustomerEndpoint>()
            .MapEndpoint<UpdateCustomerEndpoint>()
            .MapEndpoint<DeleteCustomerEndpoint>()
            .MapEndpoint<GetCustomerByIdEndpoint>()
            .MapEndpoint<GetAllCustomersEndpoint>();

        endpoints.MapGroup("v1/devlevels")
            .WithTags("DevLevels")
            .MapEndpoint<GetAllDevLevelsEndpoint>()
            .MapEndpoint<GetDevLevelByIdEndpoint>();

        endpoints.MapGroup("v1/paymentstatus")
            .WithTags("PaymentStatus")
            .MapEndpoint<GetAllPaymentStatusEndpoint>()
            .MapEndpoint<GetPaymentStatusByIdEndpoint>();
    }
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}