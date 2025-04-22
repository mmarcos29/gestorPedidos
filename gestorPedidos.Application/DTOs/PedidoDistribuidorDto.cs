namespace gestorPedidos.Application.DTOs
{
    public class PedidoDistribuidorDto
    {
        public int RevendaId { get; set; }
        public List<ItemPedidoDistribuidorDto> Itens { get; set; } = new();
    }
}
