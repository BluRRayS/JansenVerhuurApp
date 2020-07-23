using AutoMapper;
using JansenVerhuurAPI.Queries;
using Services.Domain;

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
