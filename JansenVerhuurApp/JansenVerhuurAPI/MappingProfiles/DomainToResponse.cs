using AutoMapper;
using JansenVerhuurAPI.Domain;
using JansenVerhuurAPI.Responses;

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
