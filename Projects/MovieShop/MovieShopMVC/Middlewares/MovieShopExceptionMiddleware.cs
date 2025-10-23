using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieShopMVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var exceptionDetails = new
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    ExceptionDateTime = DateTime.UtcNow,
                    ExceptionType = ex.GetType().ToString(),
                    Path = httpContext.Request.Method,
                    User = httpContext.User.Identity.IsAuthenticated ? httpContext.User.Identity.Name : null
                    // Email, UserId, QueryString, Headers, etc
                };

                // Log the exception (and the details) to Serilog / ILogger
                _logger.LogError(ex, "Unhandled exception occurred: {@ExceptionDetails}", exceptionDetails);

                // log JSON text version too
                string jsonLog = JsonSerializer.Serialize(exceptionDetails, new JsonSerializerOptions { WriteIndented = true });
                _logger.LogInformation("Exception JSON: {ExceptionJson}", jsonLog);

                // Redirect user to /Home/Error
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = 500;
                httpContext.Response.Redirect("/Home/Error");

            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
