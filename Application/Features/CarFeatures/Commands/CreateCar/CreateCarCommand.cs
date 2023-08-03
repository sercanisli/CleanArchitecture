using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using MediatR;

namespace Application.Features.CarFeatures.Commands.CreateCar
{
    public record CreateCarCommand(string Name, string Model, int EnginePower) : IRequest<MessageResponse>; 
}
