using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.UserRoleFeatures.Commands.CreateUserRole
{
    public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator()
        {
            RuleFor(r => r.UserId).NotEmpty().WithMessage("User Id can not be empty");
            RuleFor(r => r.UserId).NotNull().WithMessage("User Id can not be empty");

            RuleFor(r => r.RoleId).NotEmpty().WithMessage("Role Id can not be empty");
            RuleFor(r => r.RoleId).NotNull().WithMessage("Role Id can not be empty");

        }
    }
}
