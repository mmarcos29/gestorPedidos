using Microsoft.Extensions.DependencyInjection;
using gestorPedidos.Application.Services;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Infra.Repositories;

namespace gestorPedidos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRevendaService, RevendaService>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IRevendaRepository, RevendaRepository>();
        }
    }
}
