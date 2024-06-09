namespace UnivaliMapas.Api.Models;

public class BlocoWithSalaDto
{
    public int BlocoID { get; set; }
    public char LetraBloco { get; set; }
    public List<SalaDto> Salas { get; set; } = new();
}