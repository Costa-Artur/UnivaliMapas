using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Features.Aulas.Queries.GetAula;

public class GetAulaDetailDto
{
    public DateTime  Data { get; set; }
    //public List<MateraDto> Materia { get; set; } = new List<MateraDto>();
    public int MateriaId { get; set; }
    public List<SalaDto> Salas { get; set; } = new List<SalaDto>();
    public int SalaId { get; set; }
}