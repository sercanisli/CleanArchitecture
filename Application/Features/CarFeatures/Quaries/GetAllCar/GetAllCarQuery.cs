using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;

namespace Application.Features.CarFeatures.Quaries.GetAllCar
{
    public record GetAllCarQuery(int pageNumber = 1, int pageSize=10, string search="" ) : IRequest<PaginationResult<Car>>;
}
