using Application.Abstractions;
using Application.Services;
using Domain.Repositories;
using GenericRepository;
using Infrastructure.Authentication;
using Infrastructure.Services;
using Persistance.Context;
using Persistance.Repositories;
using Persistance.Services;
using WebAPI.Middlewares;

namespace WebAPI.Configurations
{
    public class PersistanceDependencyInjectionServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IMailService, MailService>();
            services.AddTransient<ExceptionMiddleware>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IAuthService, AuthServie>();
        }
    }
}
