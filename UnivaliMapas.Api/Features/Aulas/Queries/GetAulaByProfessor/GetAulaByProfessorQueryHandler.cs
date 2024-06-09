using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Aulas.Queries.GetAulaByProfessor;

public class GetAulaByProfessorQueryHandler : IRequestHandler<GetAulaByProfessorQuery, IEnumerable<GetAulaByProfessorDto>>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;
    
    public GetAulaByProfessorQueryHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<IEnumerable<GetAulaByProfessorDto>> Handle(GetAulaByProfessorQuery request, CancellationToken cancellationToken)
    {
        var aulasFromDatabase = await _repository.GetAulasByProfessorIdAsync(request.ProfessorID);
        foreach (var aula in aulasFromDatabase)
        {
            Console.WriteLine(aula.Materia.Name + "QUERY HANDLER");
        }
        
        return _mapper.Map<IEnumerable<GetAulaByProfessorDto>>(aulasFromDatabase);
    }
}