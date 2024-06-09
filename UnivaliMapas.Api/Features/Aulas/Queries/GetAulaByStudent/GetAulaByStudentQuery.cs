using MediatR;

namespace UnivaliMapas.Features.Aulas.Queries.GetAulaByStudent;

public class GetAulaByStudentQuery : IRequest<IEnumerable<GetAulaByStudentDto>>
{
    public int StudentID { get; set; }
}