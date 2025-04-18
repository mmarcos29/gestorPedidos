using Microsoft.AspNetCore.Mvc;
using gestorPedidos.Application.Services;
using gestorPedido.Domain.Entities;
using gestorPedido.Domain.Interfaces;
using System.Collections.Generic;

namespace gestorPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevendaController : ControllerBase
    {
        private readonly IRevendaService _revendaService;

        public RevendaController(IRevendaService revendaService)
        {
            _revendaService = revendaService;
        }

        // POST: api/revenda
        [HttpPost]
        public IActionResult CadastrarRevenda([FromBody] Revenda revenda)
        {
            if (_revendaService.CadastrarRevenda(revenda))
            {
                return Ok(new { message = "Revenda cadastrada com sucesso!" });
            }
            return BadRequest(new { message = "Erro ao cadastrar revenda." });
        }

        // POST: api/revenda/pedido
        [HttpPost("pedido")]
        public IActionResult ReceberPedido([FromBody] Pedido pedido)
        {
            if (pedido.Itens.Count < 1)
                return BadRequest("O pedido precisa ter pelo menos um item.");

            if (_revendaService.ValidarPedido(pedido))
            {
                return Ok(new { pedidoId = _revendaService.CriarPedido(pedido) });
            }

            return BadRequest("Pedido inválido.");
        }
    }
}
