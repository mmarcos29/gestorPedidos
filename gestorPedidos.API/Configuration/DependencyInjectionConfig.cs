using gestorPedido.Domain.Interfaces;
using gestorPedidos.Application.Interfaces;
using gestorPedidos.Application.Messaging.Interfaces;
using gestorPedidos.Application.Services;
using gestorPedidos.Infra.Messaging;
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
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoDistribuidorService, PedidoDistribuidorService>();
            services.AddScoped<IPedidoDistribuidorRepository, PedidoDistribuidorRepository>();
            services.AddScoped<IContactAdressRepository, ContactAdressRepository>();
            services.AddScoped<IPedidoPublisher, PedidoPublisher>();
        }
    }
}
