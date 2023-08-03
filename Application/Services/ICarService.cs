using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CarFeatures.Commands.CreateCar;
using Application.Features.CarFeatures.Quaries.GetAllCar;
using Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace Application.Services
{
    public interface ICarService
    {
        Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
        Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken);
    }
}
