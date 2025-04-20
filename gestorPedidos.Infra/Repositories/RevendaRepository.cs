using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using System.Collections.Generic;

namespace gestorPedidos.Infra.Repositories
{
    public class RevendaRepository : IRevendaRepository
    {
        private static List<Revenda> _revendas = new List<Revenda>();

        public void Add(Revenda revenda)
        {
            _revendas.Add(revenda);
        }

        public Revenda GetByCnpj(string cnpj)
        {
            return _revendas.FirstOrDefault(r => r.Cnpj == cnpj);
        }
    }
}
