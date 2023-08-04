using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using MediatR;

namespace Application.Features.UserRoleFeatures.Commands.CreateUserRole
{
    public record CreateUserRoleCommand(string RoleId, string UserId) : IRequest<MessageResponse>;
}
