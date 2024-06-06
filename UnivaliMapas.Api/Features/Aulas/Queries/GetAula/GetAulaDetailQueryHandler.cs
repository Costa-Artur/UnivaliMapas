using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Aulas.Queries.GetAula;

public class GetAulaDetailQueryHandler : IRequestHandler<GetAulaDetailDto, GetAulaDetailQuery>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public GetAulaDetailQueryHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
}