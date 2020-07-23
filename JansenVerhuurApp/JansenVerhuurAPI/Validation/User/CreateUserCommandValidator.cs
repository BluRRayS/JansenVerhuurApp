using FluentValidation;
using JansenVerhuurAPI.Commands;

namespace JansenVerhuurAPI.Validation.User
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty();
        }
    }
}
