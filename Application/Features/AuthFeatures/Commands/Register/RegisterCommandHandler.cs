using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.DTOs;
using MediatR;

namespace Application.Features.AuthFeatures.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, MessageResponse>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<MessageResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authService.RegisterAsync(request);
            return new("User registration completed successfully.");
        }
    }
}
