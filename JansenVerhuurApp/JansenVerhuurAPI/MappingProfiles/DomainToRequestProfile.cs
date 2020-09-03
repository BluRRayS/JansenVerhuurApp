using AutoMapper;
using JansenVerhuurAPI.Queries;
using Services.Models;

namespace JansenVerhuurAPI.MappingProfiles
{
    public class DomainToRequestProfile : Profile
    {
        public DomainToRequestProfile()
        {
            CreateMap<User, GetUserByIdQuery>();
        }
    }
}