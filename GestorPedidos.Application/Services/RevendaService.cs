using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Exceptions;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Application.Services
{
    public class RevendaService : IRevendaService
    {
        private readonly GestorPedidosDbContext _context;

        public RevendaService(GestorPedidosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RevendaResponseDto>> ListarRevendasAsync()
        {
            var revendas = await _context.Revendas
               .Include(r => r.Contatos)
               .ThenInclude(c => c.Telefones)
               .Include(r => r.Enderecos)
               .ToListAsync();

            return revendas.Select(MapearRevendaResponse);
        }

        public async Task<RevendaResponseDto> ObterRevendaPorIdAsync(int id)
        {
            var r = await _context.Revendas
                .Include(r => r.Contatos)
                    .ThenInclude(c => c.Telefones)
                .Include(r => r.Enderecos)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (r == null) throw new NotFoundException("Revenda não encontrada.");

            return MapearRevendaResponse(r);
        }

        public async Task<RevendaResponseDto> CadastrarRevendaAsync(RevendaDto dto)
        {
            if (_context.Revendas.Any(r => r.Cnpj == dto.Cnpj))
                throw new ValidationException("CNPJ já cadastrado.");

            if (dto.Contatos.Count == 0 || !dto.Contatos.Any(c => c.Principal))
                throw new BadRequestException("É necessário ao menos um contato principal.");

            var nova = new Revenda
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

            _context.Revendas.Add(nova);
            await _context.SaveChangesAsync();

            var revendaResponse = MapearRevendaResponse(nova);
            return revendaResponse;
        }

        public async Task AtualizarRevendaAsync(int id, Revenda updated)
        {
            var revenda = await _context.Revendas
            .Include(r => r.Contatos)
            .ThenInclude(c => c.Telefones)
            .Include(r => r.Enderecos)
            .FirstOrDefaultAsync(r => r.Id == id);

            if (revenda == null) throw new NotFoundException("Revenda não encontrada.");

            revenda.Cnpj = updated.Cnpj;
            revenda.RazaoSocial = updated.RazaoSocial;
            revenda.NomeFantasia = updated.NomeFantasia;
            revenda.Email = updated.Email;
            _context.Contatos.RemoveRange(revenda.Contatos);
            _context.Enderecos.RemoveRange(revenda.Enderecos);

            revenda.Contatos = updated.Contatos;
            revenda.Enderecos = updated.Enderecos;

            await _context.SaveChangesAsync();
        }

        public async Task ExcluirRevendaAsync(int id)
        {
            var revenda = await _context.Revendas
            .Include(r => r.Contatos)
            .ThenInclude(c => c.Telefones)
            .Include(r => r.Enderecos)
            .FirstOrDefaultAsync(r => r.Id == id);

            if (revenda == null) throw new NotFoundException("Revenda não encontrada.");

            revenda.DeletedAt = DateTime.Now;
            _context.Revendas.Update(revenda);
            await _context.SaveChangesAsync();            
        }

        private RevendaResponseDto MapearRevendaResponse(Revenda revenda)
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
                    Telefones = c.Telefones.Select(t => new TelefoneDto
                    {
                        Ddd = t.Ddd,
                        Numero = t.Numero
                    }).ToList()
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
    }
}