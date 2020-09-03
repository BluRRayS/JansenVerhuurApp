using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JansenVerhuurAPI.Queries;
using JansenVerhuurAPI.Responses;
using MediatR;
using Services.Interfaces;

namespace JansenVerhuurAPI.Handlers.QueryHandlers.User
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetUserByIdHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetAsync(request.Id);
            return _mapper.Map<UserResponse>(user);
        }
    }
}