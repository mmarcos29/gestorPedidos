using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gestorPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] PedidoDto pedidoDto)
        {
            try
            {
                var pedido = await _pedidoService.CriarPedidoAsync(pedidoDto);
                return Ok(pedido);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro interno do servidor" });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPedido(int id)
        {
            try
            {
                var pedido = await _pedidoService.ObterPedidoPorIdAsync(id);
                if (pedido == null)
                    return NotFound(new { mensagem = "Pedido não encontrado" });

                return Ok(pedido);
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro interno do servidor" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarPedidos()
        {
            try
            {
                var pedidos = await _pedidoService.ListarPedidosAsync();
                return Ok(pedidos);
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro interno do servidor" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPedido(int id, [FromBody] PedidoDto pedidoDto)
        {
            try
            {
                var pedido = await _pedidoService.AtualizarPedidoAsync(id, pedidoDto);
                return Ok(pedido);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro interno do servidor" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPedido(int id)
        {
            try
            {
                await _pedidoService.ExcluirPedidoAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro interno do servidor" });
            }
        }
    }

}
