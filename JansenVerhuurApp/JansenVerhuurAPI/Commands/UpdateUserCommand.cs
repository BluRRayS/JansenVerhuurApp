using JansenVerhuurAPI.Responses;
using MediatR;

namespace JansenVerhuurAPI.Commands
{
    public class UpdateUserCommand : IRequest<UserResponse>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
