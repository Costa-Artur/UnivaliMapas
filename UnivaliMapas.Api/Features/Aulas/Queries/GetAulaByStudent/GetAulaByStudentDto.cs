using UnivaliMapas.Api.Entities;

namespace UnivaliMapas.Features.Aulas.Queries.GetAulaByStudent;

public class GetAulaByStudentDto
{
    public DateTime  Data { get; set; }
    public MateriaDto? Materia { get; set; }
    public Sala? Sala { get; set; }
}