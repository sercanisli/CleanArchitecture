using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.DTOs;
using MediatR;

namespace Application.Features.UserRoleFeatures.Commands.CreateUserRole
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand,MessageResponse>
    {
        private readonly IUserRoleService _userRoleService;

        public CreateUserRoleCommandHandler(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        public async Task<MessageResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            await _userRoleService.CreateAsync(request, cancellationToken);
            return new("Role assignment successfully realized");
        }
    }
}
