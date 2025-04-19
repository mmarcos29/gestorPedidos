using gestorPedido.Domain.Entities;
using gestorPedidos.Infra.Context;

namespace gestorPedidos.Infra.Seeds
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, GestorPedidosDbContext context)
        {
            if (context.Revendas.Any())
                return;

            var revenda = new Revenda
            {
                Cnpj = "12.345.678/0001-99",
                RazaoSocial = "Revenda Exemplo LTDA",
                NomeFantasia = "Revenda Exemplo",
                Email = "contato@revendaexemplo.com",
                Contatos = new List<Contato>
                {
                    new Contato
                    {
                        Nome = "João da Silva",
                        Principal = true,
                        Telefones = new List<Telefone>
                        {
                            new Telefone { Ddd = "11", Numero = "987654321" },
                            new Telefone { Ddd = "11", Numero = "912345678" }
                        }
                    }
                },
                Enderecos = new List<Endereco>
                {
                    new Endereco
                    {
                        Logradouro = "Rua Exemplo",
                        Numero = "123",
                        Bairro = "Centro",
                        Cidade = "São Paulo",
                        Estado = "SP",
                        Cep = "01000-000"
                    }
                }
            };

            context.Revendas.Add(revenda);

            context.SaveChanges();
        }
    }
}
