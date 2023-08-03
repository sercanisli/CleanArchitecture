using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.AuthFeatures.Commands.Register;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstraction;

namespace Presentation.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
