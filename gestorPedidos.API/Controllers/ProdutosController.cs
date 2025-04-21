using gestorPedidos.Application.DTOs;
using gestorPedidos.Application.DTOs.Response;
using gestorPedidos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gestorPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Busca todos os produtos.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoResponseDto>>> GetAll()
        {
            var produtos = await _produtoService.GetAllAsync();
            return Ok(produtos);
        }

        /// <summary>
        /// Adiciona quantidades ao estoque de um produto.
        /// </summary>
        [HttpPatch("AdicionarEstoque")]
        public async Task<IActionResult> AdicionarEstoque([FromBody] AdicionarEstoqueDto dto)
        {
            var produto = await _produtoService.AdicionarEstoqueAsync(dto);
            return Ok(produto);
        }

        /// <summary>
        /// Busca um produto por id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoResponseDto>> GetById(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        /// <summary>
        /// Cadastra um produto
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ProdutoResponseDto>> Create([FromBody] ProdutoDto dto)
        {
            var produto = await _produtoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        /// <summary>
        /// altera um produto.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProdutoDto dto)
        {
            await _produtoService.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
