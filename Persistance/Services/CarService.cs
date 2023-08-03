using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CarFeatures.Commands.CreateCar;
using Application.Features.CarFeatures.Quaries.GetAllCar;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarService(AppDbContext context, IMapper mapper, ICarRepository carRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _carRepository = carRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);
            await _carRepository.AddAsync(car, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            PaginationResult<Car> cars = await _carRepository
                .GetWhere(c => c.Name.ToLower().Contains(request.search.ToLower()))
                .OrderBy(c=>c.Name).ToPagedListAsync(request.pageNumber, request.pageSize, cancellationToken);
            return cars;
        }
    }
}
