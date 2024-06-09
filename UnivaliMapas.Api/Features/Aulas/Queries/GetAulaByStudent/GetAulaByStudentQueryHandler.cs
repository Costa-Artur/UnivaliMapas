using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Aulas.Queries.GetAulaByStudent;

public class GetAulaByStudentQueryHandler : IRequestHandler<GetAulaByStudentQuery, IEnumerable<GetAulaByStudentDto>>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;
    
    public GetAulaByStudentQueryHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<IEnumerable<GetAulaByStudentDto>> Handle(GetAulaByStudentQuery request, CancellationToken cancellationToken)
    {
        var aulasFromDatabase = await _repository.GetAulasByStudentIdAsync(request.StudentID);
        foreach (var aula in aulasFromDatabase)
        {
            Console.WriteLine(aula.Materia.Name + "QUERY HANDLER");
        }
        
        return _mapper.Map<IEnumerable<GetAulaByStudentDto>>(aulasFromDatabase);
    }
}