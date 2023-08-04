﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using GenericRepository;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class UserRoleRepository : Repository<UserRole,AppDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context) : base(context)
        {
        }

    }
}
