using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Features.Blocos.Queries.GetBloco;

public class GetBlocoWithSalaDetailDto
{
    public int BlocoID { get; set; }
    public char LetraBloco { get; set; }
    public List<SalaDto> Salas { get; set; } = new List<SalaDto>();
}