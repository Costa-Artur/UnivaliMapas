using UnivaliMapas.Api.Entities;

namespace UnivaliMapas.Features.Aulas.Queries.GetAulaByStudent;

public class SalaDto
{
    public int SalaId { get; set; }
    public int Number { get; set; }
    public BlocoWithoutSalaDto? Bloco { get; set; }
    public int BlocoId { get; set; }
}