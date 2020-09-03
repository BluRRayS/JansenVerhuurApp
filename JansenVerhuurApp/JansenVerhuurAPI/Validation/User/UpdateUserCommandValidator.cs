using FluentValidation;
using JansenVerhuurAPI.Commands.User;

namespace JansenVerhuurAPI.Validation.User
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Middlename).MaximumLength(50);
            RuleFor(x => x.Lastname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Role).NotEmpty();
        }
    }
}