using AutoMapper;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Models;

namespace DashboardApi.Data.Profiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<CreateProjectDto, Project>();
        CreateMap<UpdateProjectDto, Project>();
    }
}