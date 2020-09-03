using System.Threading;
using System.Threading.Tasks;
using JansenVerhuurAPI.Commands;
using JansenVerhuurAPI.Commands.User;
using MediatR;
using Services.Interfaces;

namespace JansenVerhuurAPI.Handlers.CommandHandlers.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteUserAsync(request.Id);
        }
    }
}