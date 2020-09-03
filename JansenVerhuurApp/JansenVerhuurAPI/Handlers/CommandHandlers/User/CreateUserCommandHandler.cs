using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JansenVerhuurAPI.Commands;
using JansenVerhuurAPI.Commands.User;
using JansenVerhuurAPI.Responses;
using MediatR;
using Services.Interfaces;

namespace JansenVerhuurAPI.Handlers.CommandHandlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Services.Models.User>(request);
            var createdUser = await _userService.CreateAsync(user);
            return _mapper.Map<UserResponse>(createdUser);
        }
    }
}