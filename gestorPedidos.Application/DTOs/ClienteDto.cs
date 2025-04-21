namespace gestorPedidos.Application.DTOs
{
    public class ClienteDto
    {
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RevendaId { get; set; }
        public List<ContatoDto> Contatos { get; set; } = new();
        public List<EnderecoDto> Enderecos { get; set; } = new();
    }
}
