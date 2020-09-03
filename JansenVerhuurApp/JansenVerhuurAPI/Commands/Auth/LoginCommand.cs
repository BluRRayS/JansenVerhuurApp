using JansenVerhuurAPI.Responses;
using MediatR;

namespace JansenVerhuurAPI.Commands.Auth
{
    public class LoginCommand :  IRequest<AuthenticationResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}