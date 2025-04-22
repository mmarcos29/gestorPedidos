using gestorPedido.Domain.Entities;

namespace gestorPedido.Domain.Interfaces
{
    public interface IContactAdressRepository
    {
        Task ClearContactAdressAsync(ICollection<Contato> contatos, ICollection<Endereco> enderecos);
    }
}
