﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Authorization
{
    public class RoleFilterAttribute : TypeFilterAttribute
    {
        public RoleFilterAttribute(string role) : base(typeof(RoleAttribute))
        {
            Arguments = new object[] { role };
        }
    }
}
