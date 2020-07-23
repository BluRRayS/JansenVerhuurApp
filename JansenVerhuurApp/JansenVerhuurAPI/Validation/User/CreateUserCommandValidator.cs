using FluentValidation;
using JansenVerhuurAPI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
