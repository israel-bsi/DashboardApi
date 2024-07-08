using AutoMapper;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Entities;

namespace DashboardApi.Data.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}