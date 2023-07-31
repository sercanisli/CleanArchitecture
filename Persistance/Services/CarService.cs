﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CarFeatures.Commands.CreateCar;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CarService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);
            await _context.Set<Car>().AddAsync(car,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}