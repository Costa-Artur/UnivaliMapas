using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Features.Blocos.Queries.GetBloco;

public class GetBlocoWithSalaDetailDto
{
    public char LetraBloco { get; set; }
    public List<SalaDto> Salas { get; set; } = new List<SalaDto>();
}