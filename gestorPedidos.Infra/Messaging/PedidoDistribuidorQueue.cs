using gestorPedido.Domain.Entities;
using gestorPedidos.Application.Messaging.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace gestorPedidos.Infra.Messaging
{
    public class PedidoDistribuidorQueue : IPedidoDistribuidorQueue
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly ILogger<PedidoDistribuidorQueue> _logger;

        public PedidoDistribuidorQueue(ISendEndpointProvider sendEndpointProvider, ILogger<PedidoDistribuidorQueue> logger)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _logger = logger;
        }

        public async Task EnfileirarAsync(PedidoDistribuidor pedido)
        {
            try
            {
                var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:pedidoDistribuidorQueue"));
                await endpoint.Send(pedido, x =>
                {
                    x.SetRoutingKey("pedidoDistribuidorQueue.DLX");
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao enviar pedido para fila do RabbitMQ.");
                throw;
            }
        }
    }
}
