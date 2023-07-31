using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstraction;

namespace Domain.Entities
{
    public class Car : Entity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int EnginePower { get; set; }

    }
}
