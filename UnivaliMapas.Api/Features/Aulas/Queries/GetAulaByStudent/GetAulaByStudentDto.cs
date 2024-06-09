using UnivaliMapas.Api.Entities;

namespace UnivaliMapas.Features.Aulas.Queries.GetAulaByStudent;

public class GetAulaByStudentDto
{
    public int AulaId { get; set; }
    public DateTime  Data { get; set; }
    public MateriaDto? Materia { get; set; }
    public SalaDto? Sala { get; set; }
}