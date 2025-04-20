using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace gestorPedidos.API.Middlewares
{
    public class ErroHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErroHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsync($"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
