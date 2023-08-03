using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.AuthFeatures.Commands.Register;

namespace Application.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterCommand request); //CancellationToken istemedim user manager içerisinde kullanılmaz..
    }
}
