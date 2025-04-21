using gestorPedido.Domain.Interfaces;
using gestorPedidos.Application.Interfaces;
using gestorPedidos.Application.Services;
using gestorPedidos.Infra.Repositories;

namespace gestorPedidos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRevendaService, RevendaService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IRevendaRepository, RevendaRepository>();
        }
    }
}
