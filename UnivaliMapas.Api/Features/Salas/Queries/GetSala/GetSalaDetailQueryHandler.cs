using AutoMapper;
using MediatR;

namespace UnivaliMapas.Api.Features.Salas.Queries.GetSala;

public class GetSalaDetailQueryHandler : IRequestHandler<GetSalaDetailQuery, GetSalaDetailDto>
{
    private readonly IMapper _mapper;
    
    public GetSalaDetailQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public Task<GetSalaDetailDto> Handle(GetSalaDetailQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}