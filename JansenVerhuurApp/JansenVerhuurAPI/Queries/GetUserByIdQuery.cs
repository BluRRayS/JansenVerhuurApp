using JansenVerhuurAPI.Responses;
using MediatR;

namespace JansenVerhuurAPI.Queries
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}