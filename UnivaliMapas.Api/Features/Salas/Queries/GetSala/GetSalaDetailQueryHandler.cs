using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Api.Features.Salas.Queries.GetSala;

public class GetSalaDetailQueryHandler : IRequestHandler<GetSalaDetailQuery, GetSalaDetailDto>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;
    
    public GetSalaDetailQueryHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public async Task<GetSalaDetailDto> Handle(GetSalaDetailQuery request, CancellationToken cancellationToken)
    {
        var salaFromDatabase = await _repository.GetSalaByIdAsync(request.Id);
        return _mapper.Map<GetSalaDetailDto>(salaFromDatabase);
    }
}