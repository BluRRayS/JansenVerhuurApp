﻿using AutoMapper;
using Data.Dto;
using JansenVerhuurAPI.Domain;

namespace JansenVerhuurAPI.MappingProfiles
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
