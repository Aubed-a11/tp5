using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace TP08.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Hello");
            await _next(context);
        }
    }
}
