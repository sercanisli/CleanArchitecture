using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken
{
    public class CreateNewTokenByRefreshTokenValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
    {
        public CreateNewTokenByRefreshTokenValidator()
        {
            RuleFor(r => r.UserId).NotEmpty().WithMessage("User can not be empty");
            RuleFor(r => r.UserId).NotNull().WithMessage("User can not be empty");
            RuleFor(r => r.RefreshToken).NotEmpty().WithMessage("Refresh Token can not be empty");
            RuleFor(r => r.RefreshToken).NotNull().WithMessage("Refresh Token can not be empty");

        }
    }
}
