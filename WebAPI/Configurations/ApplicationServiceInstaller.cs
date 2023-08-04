using Application.Behaviors;
using FluentValidation;
using MediatR;

namespace WebAPI.Configurations
{
    public class ApplicationServiceInstaller:IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddMediatR(configure =>
                configure.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);

        }
    }
}
