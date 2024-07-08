using AutoMapper;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Entities;

namespace DashboardApi.Data.Profiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<CreateStatusDto, Status>();
            CreateMap<UpdateStatusDto, Status>();
        }
    }
}
