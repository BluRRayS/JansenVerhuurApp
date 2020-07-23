using AutoMapper;
using JansenVerhuurAPI.Commands;
using Services.Domain;
using Services.Enums;

namespace JansenVerhuurAPI.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CreateUserCommand, User>().ForMember(dest => dest.Role,
            opt => opt.MapFrom(src => (Role)src.Role));

            CreateMap<UpdateUserCommand, User>().ForMember(dest => dest.Role,
            opt => opt.MapFrom(src => (Role)src.Role));
        }
    }
}
