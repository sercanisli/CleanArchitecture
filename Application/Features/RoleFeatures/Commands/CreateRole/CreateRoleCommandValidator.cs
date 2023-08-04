using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.RoleFeatures.Commands.CreateRole
{
    public class CreateRoleCommandValidator: AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(r=>r.Name).NotEmpty().WithMessage("Role name can not be empty");
            RuleFor(r=>r.Name).NotNull().WithMessage("Role name can not be empty");
        }
    }
}
