using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JansenVerhuurAPI.Queries;
using JansenVerhuurAPI.Responses;
using MediatR;
using Services.Interfaces;

namespace JansenVerhuurAPI.Handlers.QueryHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetAllUsersHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }
    }
}