using gestorPedido.Domain.Entities;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Infra.Seeds
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, GestorPedidosDbContext context)
        {
            if (context.Revendas.Any())
                return;

            resetaIdentity(context);

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

            // Criando Produtos
            var produtos = new List<Produto>
            {
                new Produto { Nome = "Produto 1", Preco = 10.99m },
                new Produto { Nome = "Produto 2", Preco = 20.99m },
                new Produto { Nome = "Produto 3", Preco = 30.99m }
            };

            context.Produtos.AddRange(produtos);
            context.SaveChanges();

            // Criando Clientes e associando à revenda
            var clientes = new List<Cliente>
            {
                new Cliente
                {
                    Nome = "Cliente 1",
                    Cpf = "123.456.789-00",
                    Email = "cliente1@example.com",
                    RevendaId = revenda.Id,
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
                    }
                },
                new Cliente
                {
                    Nome = "Cliente 2",
                    Cpf = "987.654.321-00",
                    Email = "cliente2@example.com",
                    RevendaId = revenda.Id,  // Associando o cliente à revenda
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
                    }
                }
            };

            context.Clientes.AddRange(clientes);
            context.SaveChanges();

            // Criando Pedidos
            var pedidos = new List<Pedido>
            {
                new Pedido
                {
                    ClienteId = clientes[0].Id, // Associando o cliente 1 ao pedido
                    DataPedido = DateTime.Now,
                    RevendaId = revenda.Id
                },
                new Pedido
                {
                    ClienteId = clientes[1].Id, // Associando o cliente 2 ao pedido
                    DataPedido = DateTime.Now.AddDays(1),
                    RevendaId = revenda.Id
                }
            };

            context.Pedidos.AddRange(pedidos);
            context.SaveChanges();

            // Criando Itens de Pedido
            var itensPedido = new List<ItemPedido>
            {
                new ItemPedido
                {
                    Pedido = pedidos[0],
                    Produto = produtos[0],  // Produto 1
                    Quantidade = 2
                },
                new ItemPedido
                {
                    Pedido = pedidos[0],
                    Produto = produtos[1],  // Produto 2
                    Quantidade = 1
                },
                new ItemPedido
                {
                    Pedido = pedidos[1],
                    Produto = produtos[1],  // Produto 2
                    Quantidade = 3
                },
                new ItemPedido
                {
                    Pedido = pedidos[1],
                    Produto = produtos[2],  // Produto 3
                    Quantidade = 1
                }
            };

           
            context.ItensPedidos.AddRange(itensPedido);
            context.SaveChanges();
        }
        private static void resetaIdentity(GestorPedidosDbContext context)
        {
            var tablesWithIdentity = new[] {
                "Clientes", "Revendas", "Produtos", "Pedidos", "Enderecos", "Contatos", "Telefones", "ItensPedidos"
};

            foreach (var table in tablesWithIdentity)
            {
                context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT ('{table}', RESEED, 0)");
            }
        }
    }
}
