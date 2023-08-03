using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using MediatR;

namespace Application.Features.AuthFeatures.Commands.Register
{
    public record RegisterCommand
        (string Email, string UserName, string LastName, string Password) : IRequest<MessageResponse>;
}
