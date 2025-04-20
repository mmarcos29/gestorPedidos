using gestorPedido.Domain.Entities;
using gestorPedidos.Application.DTOs;
using gestorPedidos.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class RevendasController : ControllerBase
{
    private readonly GestorPedidosDbContext _context;

    public RevendasController(GestorPedidosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var revendas = await _context.Revendas
            .Include(r => r.Contatos)
            .ThenInclude(c => c.Telefones)
            .Include(r => r.Enderecos)
            .ToListAsync();

        return Ok(revendas);
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarRevenda([FromBody] RevendaDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (_context.Revendas.Any(r => r.Cnpj == dto.Cnpj))
            return BadRequest("CNPJ já cadastrado.");

        if (dto.Contatos.Count == 0 || !dto.Contatos.Any(c => c.Principal))
            return BadRequest("É necessário ter ao menos um contato principal.");

        var revenda = new Revenda
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


        _context.Revendas.Add(revenda);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CadastrarRevenda), new { id = revenda.Id }, revenda);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var revenda = await _context.Revendas
            .Include(r => r.Contatos)
            .ThenInclude(c => c.Telefones)
            .Include(r => r.Enderecos)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (revenda == null) return NotFound();

        return Ok(revenda);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Revenda updated)
    {
        var revenda = await _context.Revendas
            .Include(r => r.Contatos)
            .ThenInclude(c => c.Telefones)
            .Include(r => r.Enderecos)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (revenda == null) return NotFound();

        revenda.Cnpj = updated.Cnpj;
        revenda.RazaoSocial = updated.RazaoSocial;
        revenda.NomeFantasia = updated.NomeFantasia;
        revenda.Email = updated.Email;
        _context.Contatos.RemoveRange(revenda.Contatos);
        _context.Enderecos.RemoveRange(revenda.Enderecos);

        revenda.Contatos = updated.Contatos;
        revenda.Enderecos = updated.Enderecos;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var revenda = await _context.Revendas
            .Include(r => r.Contatos)
            .ThenInclude(c => c.Telefones)
            .Include(r => r.Enderecos)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (revenda == null) return NotFound();

        revenda.DeletedAt = DateTime.Now;
        _context.Revendas.Update(revenda);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
