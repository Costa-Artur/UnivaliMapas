using MediatR;

namespace UnivaliMapas.Features.Aulas.Queries.GetAulaByProfessor;

public class GetAulaByProfessorQuery : IRequest<IEnumerable<GetAulaByProfessorDto>>
{
    public int ProfessorID { get; set; }
}