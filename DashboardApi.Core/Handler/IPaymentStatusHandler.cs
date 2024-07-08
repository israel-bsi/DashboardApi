using DashboardApi.Core.Models;
using DashboardApi.Core.Request.PaymentStatus;
using DashboardApi.Core.Response;

namespace DashboardApi.Core.Handler;

public interface IPaymentStatusHandler
{
    Task<PagedResponse<List<PaymentStatus>>> GetAll(GetAllPaymentStatusRequest request);
    Task<Response<PaymentStatus>> GetById(GetPaymentStatusByIdRequest request);
}