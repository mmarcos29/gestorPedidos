using Microsoft.Extensions.Logging;

namespace gestorPedidos.Infra.Messaging
{
    //public class PedidoDistribuidorConsumer : IConsumer<PedidoDistribuidorMessage>
    //{
    //    private readonly ILogger<PedidoDistribuidorConsumer> _logger;

    //    public PedidoDistribuidorConsumer(ILogger<PedidoDistribuidorConsumer> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public async Task Consume(ConsumeContext<PedidoDistribuidorMessage> context)
    //    {
    //        var pedido = context.Message;

    //        _logger.LogInformation("Consumindo pedido {PedidoId} com {TotalItens} itens", pedido.PedidoId, pedido.Itens.Count);

    //        // Simula envio para AMBEV
    //        await Task.Delay(1000);

    //        _logger.LogInformation("Pedido enviado com sucesso.");
    //    }
    //}
}
