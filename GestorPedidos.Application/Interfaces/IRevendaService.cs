using gestorPedido.Domain.Entities;
using System.Collections.Generic;

namespace gestorPedido.Domain.Interfaces
{
    public interface IRevendaService
    {
        bool CadastrarRevenda(Revenda revenda);
        bool ValidarPedido(Pedido pedido);
        string CriarPedido(Pedido pedido);
    }
}

