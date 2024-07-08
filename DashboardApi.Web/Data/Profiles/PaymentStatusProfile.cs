using AutoMapper;
using DashboardApi.Core.Models;
using DashboardApi.Web.Data.Dtos;

namespace DashboardApi.Web.Data.Profiles;

public class PaymentStatusProfile : Profile
{
    public PaymentStatusProfile()
    {
        CreateMap<CreatePaymentStatusDto, PaymentStatus>();
        CreateMap<UpdatePaymentStatusDto, PaymentStatus>();
    }
}