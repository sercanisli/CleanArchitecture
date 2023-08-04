using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.DTOs;
using MediatR;

namespace Application.Features.RoleFeatures.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand,MessageResponse>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<MessageResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleService.CreateAsync(request);
            return new("Role registration done");
        }
    }
}
