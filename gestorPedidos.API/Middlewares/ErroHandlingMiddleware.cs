using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestorPedidos.API.Middlewares
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErroHandlingMiddleware : ControllerBase
    {
    }
}
