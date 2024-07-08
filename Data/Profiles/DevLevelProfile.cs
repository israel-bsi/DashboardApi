﻿using AutoMapper;
using DashboardApi.Data.Dtos;
using DashboardApi.Data.Entities;

namespace DashboardApi.Data.Profiles
{
    public class DevLevelProfile : Profile
    {
        public DevLevelProfile()
        {
            CreateMap<CreateDevLevelDto, DevLevel>();
            CreateMap<UpdateDevLevelDto, DevLevel>();
        }
    }
}