using gestorPedido.Domain.Entities;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Interfaces;
using gestorPedidos.Application.Mappers;
using gestorPedidos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace gestorPedidos.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly GestorPedidosDbContext _context;

        public ClienteService(GestorPedidosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetAllAsync()
        {
            var clientes = await _context.Clientes
                .Include(c => c.Contatos)
                    .ThenInclude(t => t.Telefones)
                .Include(c => c.Enderecos)
                .Include(c => c.Revenda)
                .ToListAsync();

            return clientes.Select(ClienteMapper.ToResponseDto);
        }

        public async Task<ClienteResponseDto?> GetByIdAsync(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Contatos)
                    .ThenInclude(t => t.Telefones)
                .Include(c => c.Enderecos)
                .Include(c => c.Revenda)
                .FirstOrDefaultAsync(c => c.Id == id);

            return cliente == null ? null : ClienteMapper.ToResponseDto(cliente);
        }

        public async Task<ClienteResponseDto> CreateAsync(ClienteDto dto)
        {
            var cliente = ClienteMapper.ToEntity(dto);

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return ClienteMapper.ToResponseDto(cliente);
        }

        public async Task UpdateAsync(int id, ClienteDto dto)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Contatos)
                    .ThenInclude(t => t.Telefones)
                .Include(c => c.Enderecos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                throw new KeyNotFoundException("Cliente não encontrado.");

            cliente.Nome = dto.Nome;
            cliente.Cpf = dto.Cpf;
            cliente.Email = dto.Email;
            cliente.RevendaId = dto.RevendaId;

            _context.Contatos.RemoveRange(cliente.Contatos);
            _context.Enderecos.RemoveRange(cliente.Enderecos);

            cliente.Contatos = dto.Contatos.Select(c => new Contato
            {
                Nome = c.Nome,
                Principal = c.Principal,
                Telefones = c.Telefones.Select(t => new Telefone
                {
                    Ddd = t.Ddd,
                    Numero = t.Numero
                }).ToList()
            }).ToList();

            cliente.Enderecos = dto.Enderecos.Select(e => new Endereco
            {
                Logradouro = e.Logradouro,
                Numero = e.Numero,
                Bairro = e.Bairro,
                Cidade = e.Cidade,
                Estado = e.Estado,
                Cep = e.Cep
            }).ToList();

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
                throw new KeyNotFoundException("Cliente não encontrado.");

            cliente.DeletedAt = DateTime.UtcNow;
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
