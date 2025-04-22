namespace gestorPedidos.Application.DTOs.Response
{
    public class ItemPedidoDistribuidorResponseDto
    {
        public int ProdutoId { get; set; }
        public string? NomeProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
