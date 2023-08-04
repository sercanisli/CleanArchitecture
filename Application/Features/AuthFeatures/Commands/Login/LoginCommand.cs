using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.AuthFeatures.Commands.Login
{
    public record LoginCommand (string userNameOrEmail, string password):IRequest<LoginCommandResponse>
    {
    }
}
