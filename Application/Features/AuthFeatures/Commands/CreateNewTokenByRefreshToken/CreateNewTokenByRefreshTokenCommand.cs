using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.AuthFeatures.Commands.Login;
using MediatR;

namespace Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken
{
    public record CreateNewTokenByRefreshTokenCommand(string UserId, string RefreshToken) : IRequest<LoginCommandResponse>
    {
    }
}
