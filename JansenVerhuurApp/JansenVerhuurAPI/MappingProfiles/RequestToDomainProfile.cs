using AutoMapper;
using JansenVerhuurAPI.Commands;
using JansenVerhuurAPI.Commands.User;
using Services.Enums;
using Services.Models;

namespace JansenVerhuurAPI.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CreateUserCommand, User>().ForMember(dest => dest.Role,
                opt => opt.MapFrom(src => (Role) src.Role));

            CreateMap<UpdateUserCommand, User>().ForMember(dest => dest.Role,
                opt => opt.MapFrom(src => (Role) src.Role));
        }
    }
}