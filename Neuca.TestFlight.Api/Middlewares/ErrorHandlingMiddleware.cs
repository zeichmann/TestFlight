using System.Net;
using Neuca.TestFlight.Domain.DomainExceptions;
using Newtonsoft.Json;

namespace Neuca.TestFlight.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            string result = null;
            
            if (exception is DomainException)
            {   
                code = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(new
                {
                    error = (exception as DomainException).Message,
                });
            }

            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(result);
        }
    }
}
