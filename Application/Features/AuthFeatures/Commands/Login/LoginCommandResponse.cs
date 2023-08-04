using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthFeatures.Commands.Login
{
    public record LoginCommandResponse(string Token, string RefreshToken,
        DateTime? RefreshTokenExpiresDate,
        string UserId
        )
    {
    }
}
