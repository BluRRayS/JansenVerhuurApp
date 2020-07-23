using MediatR;

namespace JansenVerhuurAPI.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
