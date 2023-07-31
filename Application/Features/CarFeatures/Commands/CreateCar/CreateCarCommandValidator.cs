using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.CarFeatures.Commands.CreateCar
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Car name can not be empty!");
            RuleFor(c => c.Name).NotNull().WithMessage("Car name can not be empty!");
            RuleFor(c => c.Name).MinimumLength(3).WithMessage("Car name must contain at least 3 characters ");

            RuleFor(c => c.Model).NotEmpty().WithMessage("Car model can not be empty!");
            RuleFor(c => c.Model).NotNull().WithMessage("Car model can not be empty!");
            RuleFor(c => c.Model).MinimumLength(3).WithMessage("Car model must contain at least 3 characters ");

            RuleFor(c => c.EnginePower).NotEmpty().WithMessage("Engine power can not be empty!");
            RuleFor(c => c.EnginePower).NotNull().WithMessage("Engine power can not be empty!");
            RuleFor(c => c.EnginePower).GreaterThan(0).WithMessage("Engine power must be greater than 0");
        }
    }
}
