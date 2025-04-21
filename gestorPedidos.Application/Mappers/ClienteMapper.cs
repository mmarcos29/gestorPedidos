using gestorPedido.Domain.Entities;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.DTOs;

namespace gestorPedidos.Application.Mappers
{
    public class ClienteMapper
    {
        public static ClienteResponseDto ToResponseDto(Cliente cliente)
        {
            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email = cliente.Email,
                RevendaId = cliente.RevendaId,
                Contatos = cliente.Contatos.Select(c => new ContatoDto
                {
                    Nome = c.Nome,
                    Principal = c.Principal,
                    Telefones = c.Telefones.Select(t => new TelefoneDto
                    {
                        Ddd = t.Ddd,
                        Numero = t.Numero
                    }).ToList()
                }).ToList(),
                Enderecos = cliente.Enderecos.Select(e => new EnderecoDto
                {
                    Logradouro = e.Logradouro,
                    Numero = e.Numero,
                    Bairro = e.Bairro,
                    Cidade = e.Cidade,
                    Estado = e.Estado,
                    Cep = e.Cep
                }).ToList()
            };
        }

        public static Cliente ToEntity(ClienteDto dto)
        {
            return new Cliente
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Email = dto.Email,
                RevendaId = dto.RevendaId,
                Contatos = dto.Contatos.Select(c => new Contato
                {
                    Nome = c.Nome,
                    Principal = c.Principal,
                    Telefones = c.Telefones.Select(t => new Telefone
                    {
                        Ddd = t.Ddd,
                        Numero = t.Numero
                    }).ToList()
                }).ToList(),
                Enderecos = dto.Enderecos.Select(e => new Endereco
                {
                    Logradouro = e.Logradouro,
                    Numero = e.Numero,
                    Bairro = e.Bairro,
                    Cidade = e.Cidade,
                    Estado = e.Estado,
                    Cep = e.Cep
                }).ToList()
            };
        }
    }
}
