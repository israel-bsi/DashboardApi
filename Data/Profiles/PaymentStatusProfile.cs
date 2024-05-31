using AutoMapper;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Models;

namespace DashboardApi.Data.Profiles;

public class PaymentStatusProfile : Profile
{
    public PaymentStatusProfile()
    {
        CreateMap<CreatePaymentStatusDto, PaymentStatus>();
        CreateMap<UpdatePaymentStatusDto, PaymentStatus>();
    }
}