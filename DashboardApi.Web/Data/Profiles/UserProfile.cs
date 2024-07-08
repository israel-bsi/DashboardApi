using AutoMapper;
using DashboardApi.Core.Models;
using DashboardApi.Web.Data.Dtos;

namespace DashboardApi.Web.Data.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
    }
}
