using gestorPedidos.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace gestorPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistribuidorMockController : ControllerBase
    {
        private readonly Random _random = new();

        /// <summary>
        /// Um exemplo de api de distribuidor instável 70% chance falhar
        /// </summary>
        [HttpPost("pedidos")]
        public IActionResult PostPedido([FromBody] PedidoDistribuidorDto request)
        {
            var shouldFail = _random.Next(0, 10) < 7;

            if (shouldFail)
            {
                return StatusCode(503, "DISTRIBUIDOR fora do ar");
            }

            return Ok("Pedido recebido com sucesso");
        }
    }
}
