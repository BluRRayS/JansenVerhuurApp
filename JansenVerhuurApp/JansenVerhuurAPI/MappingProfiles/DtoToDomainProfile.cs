using AutoMapper;
using Data.Dto;
using Services.Enums;
using Services.Models;

namespace JansenVerhuurAPI.MappingProfiles
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<UserDto, User>().ForMember(dest =>
                    dest.Role,
                opt => opt.MapFrom(src => (Role) src.Role));
        }
    }
}