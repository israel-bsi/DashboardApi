using AutoMapper;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Entities;

namespace DashboardApi.Data.Profiles;

public class DeveloperProfile : Profile
{
    public DeveloperProfile()
    {
        CreateMap<CreateDeveloperDto, Developer>();
        CreateMap<UpdateDeveloperDto, Developer>();
    }
}