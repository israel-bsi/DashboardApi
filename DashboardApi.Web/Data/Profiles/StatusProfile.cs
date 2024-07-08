using AutoMapper;
using DashboardApi.Core.Models;
using DashboardApi.Web.Data.Dtos;

namespace DashboardApi.Web.Data.Profiles;

public class StatusProfile : Profile
{
    public StatusProfile()
    {
        CreateMap<CreateStatusDto, Status>();
        CreateMap<UpdateStatusDto, Status>();
    }
}
