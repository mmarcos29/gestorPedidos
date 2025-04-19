using gestorPedidos.Application.DTOs;

public class ContatoDto
{
    public required string Nome { get; set; }
    public bool Principal { get; set; }

    public required List<TelefoneDto> Telefones { get; set; }
}
