using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.AuthFeatures.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.Email).NotEmpty().WithMessage("Email can not be empty");
            RuleFor(r => r.Email).NotNull().WithMessage("Email can not be empty");
            RuleFor(r => r.Email).EmailAddress().WithMessage("Enter according to the e-mail format");

            RuleFor(r => r.UserName).NotEmpty().WithMessage("User Name can not be empty");
            RuleFor(r => r.UserName).NotNull().WithMessage("User Name can not be empty");
            RuleFor(r => r.UserName).MinimumLength(3).WithMessage("User Name must contain at least 3 characters");

            RuleFor(r => r.Password).NotEmpty().WithMessage("Password can not be empty");
            RuleFor(r => r.Password).NotNull().WithMessage("Password can not be empty");
            RuleFor(r => r.Password).Matches("[A-Z]").WithMessage("password must contain uppercase letters");
            RuleFor(r => r.Password).Matches("[a-z]").WithMessage("password must contain lowercase letters");
            RuleFor(r => r.Password).Matches("[0-9]").WithMessage("password must contain number");
            RuleFor(r => r.Password).Matches("[^a-zA-Z0-9]").WithMessage("password must contain simple characters");
        }
    }
}
