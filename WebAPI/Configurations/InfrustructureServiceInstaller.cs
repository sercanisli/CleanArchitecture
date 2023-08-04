using Application.Abstractions;
using Infrastructure.Authentication;
using WebAPI.OptionsSetup;

namespace WebAPI.Configurations
{
    public class InfrustructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
        }
    }
}
