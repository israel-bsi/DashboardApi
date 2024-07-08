using DashboardApi.Core.Enums;
using DashboardApi.Core.Handler;
using DashboardApi.Core.Models;
using DashboardApi.Core.Request.PaymentStatus;
using DashboardApi.Core.Response;

namespace DashboardApi.Web.Handler;

public class PaymentStatusHandler : IPaymentStatusHandler
{
    public Task<PagedResponse<List<PaymentStatus>>> GetAll(GetAllPaymentStatusRequest request)
    {
        try
        {
            var enumValues = Enum.GetValues(typeof(EPaymentStatus))
                .Cast<EPaymentStatus>()
                .Select(e => new PaymentStatus { Id = (int)e, Description = e.ToString() })
                .ToList();

            return Task.FromResult(new PagedResponse<List<PaymentStatus>>(enumValues));
        }
        catch
        {
            return Task.FromResult(new PagedResponse<List<PaymentStatus>>(null, 500, "Não foi possivel carregar os status de pagamento"));
        }
    }
    public Task<Response<PaymentStatus>> GetById(GetPaymentStatusByIdRequest request)
    {
        try
        {
            var enumValue = Enum.GetValues(typeof(EPaymentStatus))
                .Cast<EPaymentStatus>()
                .FirstOrDefault(e => (int)e == request.Id);

            var devLevel = new PaymentStatus { Id = (int)enumValue, Description = enumValue.ToString() };

            return Task.FromResult(new Response<PaymentStatus>(devLevel));
        }
        catch
        {
            return Task.FromResult(new Response<PaymentStatus>(null, 500, "Não foi possivel carregar o status de pagamento"));
        }
    }
}