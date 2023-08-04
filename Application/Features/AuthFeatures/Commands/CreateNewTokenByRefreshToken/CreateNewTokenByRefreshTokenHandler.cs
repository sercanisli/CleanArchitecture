using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.AuthFeatures.Commands.Login;
using Application.Services;
using MediatR;

namespace Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken
{
    public class CreateNewTokenByRefreshTokenHandler : IRequestHandler<CreateNewTokenByRefreshTokenCommand,LoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public CreateNewTokenByRefreshTokenHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            LoginCommandResponse response =
                await _authService.CreateTokenByRefreshTokenAsync(request, cancellationToken);
            return response;
        }
    }
}
