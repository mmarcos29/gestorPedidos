using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gestorPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosDistribuidorController : ControllerBase
    {
        private readonly IPedidoDistribuidorService _service;

        public PedidosDistribuidorController(IPedidoDistribuidorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Envia um pedido ao distribuidor
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PedidoDistribuidorResponseDto>> Criar([FromBody] PedidoDistribuidorDto dto)
        {
            var result = await _service.CriarPedidoAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// localiza um pedido enviado
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDistribuidorResponseDto>> ObterPorId(int id)
        {
            var result = await _service.ObterPedidoPorIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// lista todos os pedidos enviados ao distribuidor
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDistribuidorResponseDto>>> ListarTodos()
        {
            var result = await _service.ListarPedidosAsync();
            return Ok(result);
        }

        /// <summary>
        /// lista todos os pedidos enviados ao distribuidor (concluidos)
        /// </summary>
        [HttpGet("concluidos")]
        public async Task<ActionResult<IEnumerable<PedidoDistribuidorResponseDto>>> ObterConcluidos()
        {
            var result = await _service.ObterConcluidosAsync();
            return Ok(result);
        }

        /// <summary>
        /// lista todos os pedidos enviados ao distribuidor (pendentes)
        /// </summary>
        [HttpGet("pendentes")]
        public async Task<ActionResult<IEnumerable<PedidoDistribuidorResponseDto>>> ObterPendentes()
        {
            var result = await _service.ObterPendentesAsync();
            return Ok(result);
        }
    }
}
