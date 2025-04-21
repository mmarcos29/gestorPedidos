using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
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

        /// <summary>
        /// Cria um novo pedido.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PedidoResponseDto>> CriarPedido([FromBody] PedidoDto pedidoDto)
        {
            var pedido = await _pedidoService.CriarPedidoAsync(pedidoDto);
            return Ok(pedido);            
        }

        /// <summary>
        /// Obtem pedido por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoResponseDto>> ObterPedidoPorId(int id)
        {
            
            var pedido = await _pedidoService.ObterPedidoPorIdAsync(id);
            return Ok(pedido);
            
        }

        /// <summary>
        /// Busca todos os pedidos.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoResponseDto>>> ListarTodosPedidos()
        {
            
            var pedidos = await _pedidoService.ListarPedidosAsync();
            return Ok(pedidos);
            
        }

        /// <summary>
        /// Altera um pedido existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPedido(int id, [FromBody] PedidoDto pedidoDto)
        {
            var pedido = await _pedidoService.AtualizarPedidoAsync(id, pedidoDto);
            return Ok(pedido);
           
        }

        /// <summary>
        /// Remove um pedido
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPedido(int id)
        {
            await _pedidoService.ExcluirPedidoAsync(id);
            return NoContent();
        }
    }

}
