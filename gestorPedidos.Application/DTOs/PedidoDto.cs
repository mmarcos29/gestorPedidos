namespace gestorPedidos.Application.DTOs
{
    public class PedidoDto
    {
        public required int ClienteId { get; set; }
        public required int RevendaId { get; set; }
        public List<ItemPedidoDto>? Itens { get; set; }
    }
}
