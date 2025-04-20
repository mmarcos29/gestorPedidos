using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RevendasController : ControllerBase
{
    private readonly IRevendaService _revendaService;

    public RevendasController(IRevendaService revendaService)
    {
        _revendaService = revendaService;
    }

    /// <summary>
    /// Busca todos as revendas.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var revendas = await _revendaService.ListarRevendasAsync();
        return Ok(revendas);
    }

    /// <summary>
    /// Cria uma revenda.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CadastrarRevenda([FromBody] RevendaDto dto)
    {
        var nova = await _revendaService.CadastrarRevendaAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = nova.Id }, nova);
    }

    /// <summary>
    /// Obtem revenda por ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _revendaService.ObterRevendaPorIdAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Edita o cadastro de uma revenda.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Revenda updated)
    {
        await _revendaService.AtualizarRevendaAsync(id, updated);
        return NoContent();
    }

    /// <summary>
    /// remove uma revenda.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _revendaService.ExcluirRevendaAsync(id);
        return NoContent();
    }
}
