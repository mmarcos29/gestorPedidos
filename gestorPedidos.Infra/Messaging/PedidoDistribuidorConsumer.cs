using gestorPedido.Domain.Entities;
using gestorPedidos.Application.Interfaces;
using gestorPedidos.Application.Messaging.Interfaces;
using MassTransit;
using System.Net.Http.Json;

namespace gestorPedidos.Infra.Messaging
{
    public class PedidoDistribuidorConsumer : IConsumer<PedidoDistribuidor>
    {
        private readonly IPedidoDistribuidorService _service;
        private readonly IPedidoDistribuidorQueue _pedidoDistribuidorQueue;
        private readonly HttpClient _httpClient;

        public PedidoDistribuidorConsumer(IPedidoDistribuidorService service, HttpClient httpClient, IPedidoDistribuidorQueue pedidoDistribuidorQueue)
        {
            _service = service;
            _httpClient = httpClient;
            _pedidoDistribuidorQueue = pedidoDistribuidorQueue;
        }

        public async Task Consume(ConsumeContext<PedidoDistribuidor> context)
        {
            var pedido = context.Message;
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:8080/api/DistribuidorMock/pedidos", pedido);
                if (response.IsSuccessStatusCode)
                {
                    var pedidoResponse = await _service.AtualizarStatusAsync(pedido.Id, true, "sucesso");
                    Console.WriteLine($"Pedido {pedido.Id} concluído com sucesso.");
                }
                else
                {
                    await _pedidoDistribuidorQueue.EnfileirarAsync(pedido);
                }
            }
            catch (Exception ex)
            {
                await _pedidoDistribuidorQueue.EnfileirarAsync(pedido);
                Console.WriteLine($"Erro ao processar pedido: {ex.Message}");
            }
        }
    }
}
