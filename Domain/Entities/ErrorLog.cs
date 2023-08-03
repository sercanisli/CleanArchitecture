using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstraction;

namespace Domain.Entities
{
    public class ErrorLog: Entity
    {
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string RequestPath { get; set; } 
        public string RequestMethod { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
