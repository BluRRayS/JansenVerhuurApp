using FluentValidation;
using JansenVerhuurAPI.Commands.Auth;
using JansenVerhuurAPI.Commands.User;

namespace JansenVerhuurAPI.Validation.Auth
{
    public class LoginCommandValidator: AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
        
    }
}