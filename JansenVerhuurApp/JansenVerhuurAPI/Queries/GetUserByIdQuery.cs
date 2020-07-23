using JansenVerhuurAPI.Responses;
using MediatR;

namespace JansenVerhuurAPI.Queries
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
