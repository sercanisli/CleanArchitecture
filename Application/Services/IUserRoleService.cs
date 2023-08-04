using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserRoleFeatures.Commands.CreateUserRole;

namespace Application.Services
{
    public interface IUserRoleService
    {
        Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken);
    }
}
