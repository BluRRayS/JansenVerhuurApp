using AutoMapper;
using Data.Dto;
using Services.Models;

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