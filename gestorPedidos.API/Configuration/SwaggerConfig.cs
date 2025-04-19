using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace gestorPedidos.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestor de Pedidos", Version = "v1" });
            });
        }
    }
}
