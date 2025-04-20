namespace gestorPedidos.Application.DTOs.Response
{
    public class ErroResponseDto
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
    }
}
