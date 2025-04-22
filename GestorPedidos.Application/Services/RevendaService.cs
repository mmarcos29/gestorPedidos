using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Exceptions;
using gestorPedidos.Application.Mappers;

namespace gestorPedidos.Application.Services
{
    public class RevendaService : IRevendaService
    {
        private readonly IRevendaRepository _revendaRepository;

        public RevendaService(IRevendaRepository revendaRepository)
        {
            _revendaRepository = revendaRepository;
        }

        public async Task<IEnumerable<RevendaResponseDto>> ListarRevendasAsync()
        {
            var revendas = await _revendaRepository.ListarRevendasAsync();
            return revendas.Select(RevendaMapper.ToResponseDto);
        }

        public async Task<RevendaResponseDto> ObterRevendaPorIdAsync(int id)
        {
            var revenda = await _revendaRepository.ObterPorIdAsync(id);
            if (revenda == null) throw new NotFoundException("Revenda não encontrada.");

            return RevendaMapper.ToResponseDto(revenda);
        }

        public async Task<RevendaResponseDto> CadastrarRevendaAsync(RevendaDto dto)
        {
            if (await _revendaRepository.CnpjExisteAsync(dto.Cnpj))
                throw new ValidationException("CNPJ já cadastrado.");

            if (dto.Contatos.Count == 0 || !dto.Contatos.Any(c => c.Principal))
                throw new BadRequestException("É necessário ao menos um contato principal.");

            var nova = RevendaMapper.ToEntity(dto);
            await _revendaRepository.AdicionarAsync(nova);
            await _revendaRepository.SaveChangesAsync();

            return RevendaMapper.ToResponseDto(nova);
        }

        public async Task AtualizarRevendaAsync(int id, Revenda updated)
        {
            var oldRevenda = await _revendaRepository.ObterPorIdAsync(id);
            var revenda = oldRevenda;
            if (revenda == null) throw new NotFoundException("Revenda não encontrada.");

            revenda.Cnpj = updated.Cnpj;
            revenda.RazaoSocial = updated.RazaoSocial;
            revenda.NomeFantasia = updated.NomeFantasia;
            revenda.Email = updated.Email;
            revenda.Contatos = updated.Contatos;
            revenda.Enderecos = updated.Enderecos;

            await _revendaRepository.AtualizarAsync(oldRevenda, revenda);
            await _revendaRepository.SaveChangesAsync();
        }

        public async Task ExcluirRevendaAsync(int id)
        {
            var oldRevenda = await _revendaRepository.ObterPorIdAsync(id);
            var revenda = oldRevenda;
            if (revenda == null) throw new NotFoundException("Revenda não encontrada.");

            revenda.DeletedAt = DateTime.Now;
            await _revendaRepository.AtualizarAsync(oldRevenda, revenda);
            await _revendaRepository.SaveChangesAsync();  
        }
    }
}