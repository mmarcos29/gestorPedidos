using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MassTransit;

namespace gestorPedidos.Infra.Messaging
{
    public class RabbitMqHostedService : IHostedService
    {
        private readonly IBusControl _bus;
        private readonly ILogger<RabbitMqHostedService> _logger;

        public RabbitMqHostedService(IBusControl bus, ILogger<RabbitMqHostedService> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Iniciando o consumo das filas do RabbitMQ.");
                await _bus.StartAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao iniciar o RabbitMQ.");
                throw;
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Parando o consumo das filas do RabbitMQ.");
                await _bus.StopAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao parar o RabbitMQ.");
                throw;
            }
        }
    }
}
