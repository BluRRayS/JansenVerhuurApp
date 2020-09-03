using MediatR;

namespace JansenVerhuurAPI.Commands.User
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}