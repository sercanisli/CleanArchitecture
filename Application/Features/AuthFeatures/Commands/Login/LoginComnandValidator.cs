using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.AuthFeatures.Commands.Login
{
    public class LoginComnandValidator : AbstractValidator<LoginCommand>
    {
        public LoginComnandValidator()
        {
            RuleFor(r => r.userNameOrEmail).NotEmpty().WithMessage("User Name or Email can not be empty");
            RuleFor(r => r.userNameOrEmail).NotNull().WithMessage("User Name can not be empty");
            RuleFor(r => r.userNameOrEmail).MinimumLength(3).WithMessage("User Name must contain at least 3 characters");

            RuleFor(r => r.password).NotEmpty().WithMessage("Password can not be empty");
            RuleFor(r => r.password).NotNull().WithMessage("Password can not be empty");
            RuleFor(r => r.password).Matches("[A-Z]").WithMessage("password must contain uppercase letters");
            RuleFor(r => r.password).Matches("[a-z]").WithMessage("password must contain lowercase letters");
            RuleFor(r => r.password).Matches("[0-9]").WithMessage("password must contain number");
            RuleFor(r => r.password).Matches("[^a-zA-Z0-9]").WithMessage("password must contain simple characters");
        }
    }
}
