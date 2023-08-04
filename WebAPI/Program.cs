using WebAPI.Configurations;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(
    builder.Configuration, builder.Host, typeof(IServiceInstaller).Assembly
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
