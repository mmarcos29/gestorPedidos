using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gestorPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Busca todos os clientes.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponseDto>>> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        /// <summary>
        /// Busca o cliente pelo id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponseDto>> GetById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        /// <summary>
        /// Cadastra um novo cliente.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ClienteResponseDto>> Create([FromBody] ClienteDto dto)
        {
            var cliente = await _clienteService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        /// <summary>
        /// Edita o cadastro de um cliente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDto dto)
        {
            await _clienteService.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove um cliente da base.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteService.DeleteAsync(id);
            return NoContent();
        }
    }
}
