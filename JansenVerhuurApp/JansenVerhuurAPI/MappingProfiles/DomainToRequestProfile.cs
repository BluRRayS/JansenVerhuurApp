using AutoMapper;
using JansenVerhuurAPI.Domain;
using JansenVerhuurAPI.Queries;

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
