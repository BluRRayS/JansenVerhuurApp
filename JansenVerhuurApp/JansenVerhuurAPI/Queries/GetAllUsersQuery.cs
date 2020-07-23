using JansenVerhuurAPI.Responses;
using MediatR;
using System.Collections.Generic;

namespace JansenVerhuurAPI.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserResponse>>
    {

    }
}
