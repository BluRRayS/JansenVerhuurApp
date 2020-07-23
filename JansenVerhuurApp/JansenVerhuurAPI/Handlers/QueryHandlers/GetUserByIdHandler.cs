using AutoMapper;
using JansenVerhuurAPI.Queries;
using JansenVerhuurAPI.Responses;
using MediatR;
using JansenVerhuurAPI.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace JansenVerhuurAPI.Handlers.QueryHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

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
