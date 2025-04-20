using gestorPedido.Domain.Entities;
namespace gestorPedido.Domain.Interfaces
{
    public interface IRevendaRepository
    {
        void Add(Revenda revenda);
        Revenda GetByCnpj(string cnpj);
    }
}

