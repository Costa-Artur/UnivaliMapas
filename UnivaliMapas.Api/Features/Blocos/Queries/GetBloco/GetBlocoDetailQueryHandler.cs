using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Blocos.Queries.GetBloco;

public class GetBlocoDetailQueryHandler : IRequestHandler<GetBlocoDetailQuery, GetBlocoDetailDto>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public GetBlocoDetailQueryHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetBlocoDetailDto> Handle(GetBlocoDetailQuery request, CancellationToken cancellationToken)
    {
        var blocoFromDatabase = await _repository.GetBlocoByIdAsync(request.BlocoID);
        return _mapper.Map<GetBlocoDetailDto>(blocoFromDatabase);
    }
}