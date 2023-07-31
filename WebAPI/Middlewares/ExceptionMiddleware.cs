using FluentValidation;

namespace WebAPI.Middlewares
{
    public class ExceptionMiddleware:IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        { 
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
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
    }
}
