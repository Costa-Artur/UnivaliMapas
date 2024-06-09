using UnivaliMapas.Api.Entities;
using UnivaliMapas.Features.Aulas.Queries.GetAulaByStudent;

namespace UnivaliMapas.Features.Aulas.Queries.GetAulaByProfessor;

public class GetAulaByProfessorDto
{
    public DateTime  Data { get; set; }
    public MateriaDto? Materia { get; set; }
    public SalaDto? Sala { get; set; }
}