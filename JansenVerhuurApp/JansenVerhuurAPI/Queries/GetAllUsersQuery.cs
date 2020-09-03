using System.Collections.Generic;
using JansenVerhuurAPI.Responses;
using MediatR;

namespace JansenVerhuurAPI.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserResponse>>
    {
    }
}