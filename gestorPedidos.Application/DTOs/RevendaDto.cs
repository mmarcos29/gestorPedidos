using gestorPedidos.Application.DTOs;

public class RevendaDto
{
    public required string Cnpj { get; set; }
    public required string RazaoSocial { get; set; }
    public required string NomeFantasia { get; set; }
    public required string Email { get; set; }

    public required List<ContatoDto> Contatos { get; set; }
    public required List<EnderecoDto> Enderecos { get; set; }
}
