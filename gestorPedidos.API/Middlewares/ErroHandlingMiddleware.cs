using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace gestorPedidos.API.Middlewares
{
    public class ErroHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErroHandlingMiddleware> _logger;

        public ErroHandlingMiddleware(RequestDelegate next, ILogger<ErroHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao processar a requisição.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string message = "Ocorreu um erro inesperado.";
            string? details = exception.Message;

            switch (exception)
            {
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;

                case BadRequestException:
                case ValidationException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;

                case UnauthorizedException:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = exception.Message;
                    break;

                case ForbiddenException:
                    statusCode = HttpStatusCode.Forbidden;
                    message = exception.Message;
                    break;

                default:
                    details = exception.ToString();
                    break;
            }

            var response = new ErroResponseDto
            {
                Status = (int)statusCode,
                Message = message,
                Details = details
            };

            var result = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}