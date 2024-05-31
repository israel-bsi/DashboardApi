using AutoMapper;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Models;

namespace DashboardApi.Data.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
    }
}
