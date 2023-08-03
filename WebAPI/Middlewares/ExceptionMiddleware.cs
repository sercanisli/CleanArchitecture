using Domain.Entities;
using FluentValidation;
using Persistance.Context;

namespace WebAPI.Middlewares
{
    public class ExceptionMiddleware:IMiddleware
    {
        private readonly AppDbContext _context;

        public ExceptionMiddleware(AppDbContext context)
        {
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        { 
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await LogExceptionToDatabaseAsync(e, context.Request);
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            if (e.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ValidationErrorDetails
                {
                    Errors = ((ValidationException)e).Errors.Select(s => s.PropertyName),
                    StatusCode = 403
                }.ToString());
            }

            return context.Response.WriteAsync(new ErrorResult
            {
                Message = e.Message,
                StatusCode = context.Response.StatusCode
            }.ToString());
        }

        private async Task LogExceptionToDatabaseAsync(Exception e, HttpRequest request)
        {
            ErrorLog errorLog = new()
            {
                ErrorMessage = e.Message,
                StackTrace = e.StackTrace,
                RequestPath = request.Path,
                RequestMethod = request.Method,
                Timestamp = DateTime.Now
            };
            await _context.Set<ErrorLog>().AddAsync(errorLog, default);
            await _context.SaveChangesAsync(default);
        }
    }
}
