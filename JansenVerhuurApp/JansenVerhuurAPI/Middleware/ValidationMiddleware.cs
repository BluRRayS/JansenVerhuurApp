using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace JansenVerhuurAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ValidationException ex)
            {

                // Todo Improve validation middleware;
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                var originBody = httpContext.Response.Body;
                try
                {
                    var memStream = new MemoryStream();
                    httpContext.Response.Body = memStream;

                    await _next(httpContext).ConfigureAwait(false);

                    memStream.Position = 0;
                    var responseBody = new StreamReader(memStream).ReadToEnd();

                    //Custom logic to modify response
                    responseBody = ex.Message.ToString();

                    var memoryStreamModified = new MemoryStream();
                    var sw = new StreamWriter(memoryStreamModified);
                    sw.Write(responseBody);
                    sw.Flush();
                    memoryStreamModified.Position = 0;

                    await memoryStreamModified.CopyToAsync(originBody).ConfigureAwait(false);
                }
                catch (Exception)
                {

                    Console.WriteLine("Could not set body of response!");
                }
                httpContext.Response.Body = originBody;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationMiddleware>();
        }
    }
}
