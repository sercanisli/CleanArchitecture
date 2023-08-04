using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using MediatR;

namespace Application.Features.RoleFeatures.Commands.CreateRole
{
    public record CreateRoleCommand(string Name) : IRequest<MessageResponse>;
}
