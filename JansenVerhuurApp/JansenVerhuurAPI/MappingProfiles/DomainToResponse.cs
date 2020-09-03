using AutoMapper;
using JansenVerhuurAPI.Responses;
using Services.Models;

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