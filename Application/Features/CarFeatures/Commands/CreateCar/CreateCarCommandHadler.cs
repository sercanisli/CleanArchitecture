using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.DTOs;
using MediatR;

namespace Application.Features.CarFeatures.Commands.CreateCar
{
    public class CreateCarCommandHadler : IRequestHandler<CreateCarCommand, MessageResponse>
    {
        private readonly ICarService _carService;

        public CreateCarCommandHadler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<MessageResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _carService.CreateAsync(request,cancellationToken);
            return new("Car created.");
        }
    }
}
