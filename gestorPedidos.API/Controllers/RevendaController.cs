using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestorPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevendaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("API funcionando!");

    }
}
