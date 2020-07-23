using AutoMapper;
using JansenVerhuurAPI.Responses;
using Services.Domain;

namespace JansenVerhuurAPI.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<User, UserResponse>();
        }
    }
}
