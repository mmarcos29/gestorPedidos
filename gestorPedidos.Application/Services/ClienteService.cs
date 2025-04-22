using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Exceptions;
using gestorPedidos.Application.Interfaces;
using gestorPedidos.Application.Mappers;

namespace gestorPedidos.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;            
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();

            return clientes.Select(ClienteMapper.ToResponseDto);
        }

        public async Task<ClienteResponseDto?> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado.");

            return ClienteMapper.ToResponseDto(cliente);
        }

        public async Task<ClienteResponseDto> CreateAsync(ClienteDto dto)
        {
            var cliente = ClienteMapper.ToEntity(dto);

            await _clienteRepository.AddAsync(cliente);

            return ClienteMapper.ToResponseDto(cliente);
        }

        public async Task UpdateAsync(int id, ClienteDto dto)
        {
            var OldClient = await _clienteRepository.GetByIdAsync(id);
            var cliente = OldClient;

            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado.");

            cliente.Nome = dto.Nome;
            cliente.Cpf = dto.Cpf;
            cliente.Email = dto.Email;
            cliente.RevendaId = dto.RevendaId;

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

            await _clienteRepository.UpdateAsync(OldClient, cliente);
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado.");

            await _clienteRepository.DeleteAsync(cliente);
        }
    }
}
