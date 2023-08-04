using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.AuthFeatures.Commands.Login;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateTokenAsync(User user);
    }
}
