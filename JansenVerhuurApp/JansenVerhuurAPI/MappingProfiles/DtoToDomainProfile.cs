using AutoMapper;
using Data.Dto;
using JansenVerhuurAPI.Domain;
using JansenVerhuurAPI.Enums;

namespace JansenVerhuurAPI.MappingProfiles
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<UserDto, User>().ForMember(dest =>
            dest.Role,
            opt => opt.MapFrom(src => (Role)src.Role));
        }
    }
}
