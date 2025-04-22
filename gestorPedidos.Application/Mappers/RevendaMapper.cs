using gestorPedido.Domain.Entities;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;

namespace gestorPedidos.Application.Mappers
{
    public static class RevendaMapper
    {
        public static RevendaResponseDto ToResponseDto(Revenda revenda)
        {
            return new RevendaResponseDto
            {
                Id = revenda.Id,
                NomeFantasia = revenda.NomeFantasia,
                Cnpj = revenda.Cnpj,
                RazaoSocial = revenda.RazaoSocial,
                Email = revenda.Email,
                Contatos = revenda.Contatos.Select(c => new ContatoDto
                {
                    Nome = c.Nome,
                    Principal = c.Principal,
                    Telefones = c.Telefones?.Select(t => new TelefoneDto
                    {
                        Ddd = t.Ddd,
                        Numero = t.Numero
                    }).ToList() ?? new List<TelefoneDto>()
                }).ToList(),
                Enderecos = revenda.Enderecos.Select(e => new EnderecoDto
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

        public static Revenda ToEntity(RevendaDto dto)
        {
            return new Revenda
            {
                Cnpj = dto.Cnpj,
                RazaoSocial = dto.RazaoSocial,
                NomeFantasia = dto.NomeFantasia,
                Email = dto.Email,
                Contatos = dto.Contatos.Select(c => new Contato
                {
                    Nome = c.Nome,
                    Principal = c.Principal,
                    Telefones = c.Telefones?.Select(t => new Telefone
                    {
                        Ddd = t.Ddd,
                        Numero = t.Numero
                    }).ToList() ?? new List<Telefone>()
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
