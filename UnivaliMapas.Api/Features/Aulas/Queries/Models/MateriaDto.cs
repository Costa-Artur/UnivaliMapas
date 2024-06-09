using UnivaliMapas.Api.Entities;

namespace UnivaliMapas.Features.Aulas.Queries.GetAulaByStudent;

public class MateriaDto
{
    public string Name { get; set; } = string.Empty;
    public ProfessorDto? Professor { get; set; }
}