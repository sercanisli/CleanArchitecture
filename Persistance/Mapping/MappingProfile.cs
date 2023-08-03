using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.AuthFeatures.Commands.Register;
using Application.Features.CarFeatures.Commands.CreateCar;
using AutoMapper;
using Domain.Entities;

namespace Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCarCommand, Car>().ReverseMap();
            CreateMap<RegisterCommand, User>();
        }
    }
}
