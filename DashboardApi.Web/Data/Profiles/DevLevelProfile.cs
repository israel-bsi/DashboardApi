using AutoMapper;
using DashboardApi.Core.Models;
using DashboardApi.Web.Data.Dtos;

namespace DashboardApi.Web.Data.Profiles;

public class DevLevelProfile : Profile
{
    public DevLevelProfile()
    {
        CreateMap<CreateDevLevelDto, DevLevel>();
        CreateMap<UpdateDevLevelDto, DevLevel>();
    }
}