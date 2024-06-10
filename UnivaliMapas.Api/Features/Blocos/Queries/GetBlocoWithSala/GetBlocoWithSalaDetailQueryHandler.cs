using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Blocos.Queries.GetBloco;

public class GetBlocoWithSalaDetailQueryHandler : IRequestHandler<GetBlocoWithSalaDetailQuery, IEnumerable<GetBlocoWithSalaDetailDto>>
{
    private readonly IUnivaliRepository _blocoRepository;
    private readonly IMapper _mapper;

    public GetBlocoWithSalaDetailQueryHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _blocoRepository = repository;
    }

    public async Task<IEnumerable<GetBlocoWithSalaDetailDto>> Handle(GetBlocoWithSalaDetailQuery request, CancellationToken cancellationToken)
    {
        var blocoFromDatabase = await _blocoRepository.GetBlocosWithSalasByIdAsync();
        return _mapper.Map<IEnumerable<GetBlocoWithSalaDetailDto>>(blocoFromDatabase);
    }
}
