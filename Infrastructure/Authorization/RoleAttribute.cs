using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Authorization
{
    public class RoleAttribute : Attribute, IAuthorizationFilter 
    {
        private readonly string _role; 
        private readonly IUserRoleRepository _userRoleRepository;
        public RoleAttribute(string role, IUserRoleRepository userRoleRepository)
        {
            _role = role;
            _userRoleRepository = userRoleRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context) 
        {
            var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim ! == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            
            var userHasRole = _userRoleRepository
                .GetWhere(u => u.UserId == userIdClaim.Value)
                .Include(u => u.Role).Any(u => u.Role.Name == _role);

            if (userHasRole==false)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            
        }
    }
}
