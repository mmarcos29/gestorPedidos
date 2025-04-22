namespace gestorPedidos.Application.DTOs.Response
{
    public class PedidoDistribuidorResponseDto
    {
        public int Id { get; set; }
        public int RevendaId { get; set; }
        public string? NomeRevenda { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Retorno { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public List<ItemPedidoDistribuidorResponseDto> Itens { get; set; } = new();
    }
}
