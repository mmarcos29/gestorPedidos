using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;

namespace gestorPedidos.Application.Services
{
    public class RevendaService : IRevendaService
    {
        private readonly IRevendaRepository _revendaRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public RevendaService(IRevendaRepository revendaRepository, IPedidoRepository pedidoRepository)
        {
            _revendaRepository = revendaRepository;
            _pedidoRepository = pedidoRepository;
        }

        public bool CadastrarRevenda(Revenda revenda)
        {
            if (revenda == null)
                return false;

            _revendaRepository.Add(revenda);
            return true;
        }

        public bool ValidarPedido(Pedido pedido)
        {
            if (pedido.Itens.Sum(item => item.Quantidade) < 1000)
                return false;

            return true;
        }

        public string CriarPedido(Pedido pedido)
        {
            var pedidoId = _pedidoRepository.Add(pedido);
            return pedidoId;
        }
    }
}

