using AutoMapper;
using JansenVerhuurAPI.Commands;
using JansenVerhuurAPI.Domain;
using JansenVerhuurAPI.Enums;

namespace JansenVerhuurAPI.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CreateUserCommand, User>().ForMember(dest => dest.Role,
            opt => opt.MapFrom(src => (Role)src.Role));
        }
    }
}
