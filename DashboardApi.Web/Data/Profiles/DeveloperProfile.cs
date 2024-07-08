using AutoMapper;
using DashboardApi.Core.Models;
using DashboardApi.Web.Data.Dtos;

namespace DashboardApi.Web.Data.Profiles;

public class DeveloperProfile : Profile
{
    public DeveloperProfile()
    {
        CreateMap<CreateDeveloperDto, Developer>();
        CreateMap<UpdateDeveloperDto, Developer>();
    }
}