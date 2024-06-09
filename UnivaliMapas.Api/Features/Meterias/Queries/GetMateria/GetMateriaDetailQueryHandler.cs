using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Meterias.Queries.GetMateria;

public class GetMateriaDetailQueryHandler //: IRequestHandler<GetMateriaDetailQuery, GetMateriaDetailDto>
    {
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public GetMateriaDetailQueryHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
}