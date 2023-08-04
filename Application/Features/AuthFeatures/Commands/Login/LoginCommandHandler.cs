﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using MediatR;

namespace Application.Features.AuthFeatures.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand,LoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            LoginCommandResponse response = await _authService.LoginAsync(request, cancellationToken);
            return response;
        }
    }
}
