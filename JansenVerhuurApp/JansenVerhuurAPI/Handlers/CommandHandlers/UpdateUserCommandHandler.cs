using AutoMapper;
using JansenVerhuurAPI.Commands;
using JansenVerhuurAPI.Domain;
using JansenVerhuurAPI.Interfaces;
using JansenVerhuurAPI.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JansenVerhuurAPI.Handlers.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var updatedUser = await _userService.UpdateAsync(user);
            return _mapper.Map<UserResponse>(updatedUser);
        }
    }
}
